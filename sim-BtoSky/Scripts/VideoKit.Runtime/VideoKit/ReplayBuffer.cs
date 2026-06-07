using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using VideoKit.Clocks;

namespace VideoKit
{
	public sealed class ReplayBuffer
	{
		private readonly struct Packet : IDisposable
		{
			public readonly byte[] data;

			public readonly GCHandle handle;

			public readonly PixelBuffer buffer;

			public unsafe Packet(int width, int height, long timestamp)
			{
				data = ArrayPool<byte>.Shared.Rent(width * height * 4);
				handle = GCHandle.Alloc(data, GCHandleType.Pinned);
				buffer = new PixelBuffer(width, height, PixelBuffer.Format.RGBA8888, (byte*)(void*)handle.AddrOfPinnedObject(), 0, timestamp);
			}

			public void Dispose()
			{
				buffer.Dispose();
				handle.Free();
				ArrayPool<byte>.Shared.Return(data);
			}
		}

		private readonly MediaRecorder.Format format;

		private readonly int width;

		private readonly int height;

		private readonly float frameRate;

		private readonly float duration;

		private readonly float chunkDurationNs;

		private readonly string? prefix;

		private readonly RealtimeClock clock;

		private readonly BlockingCollection<Action> queue;

		private readonly TaskCompletionSource<bool> finishSource;

		private readonly Thread worker;

		private MediaRecorder? recorder;

		private ulong recorderIdx;

		private Task<MediaAsset> chunkTask;

		public ReplayBuffer(MediaRecorder.Format format, int width, int height, float frameRate, float duration, string? prefix = null)
		{
			this.width = width;
			this.height = height;
			this.frameRate = frameRate;
			this.duration = duration;
			chunkDurationNs = (duration + 2f) * 1E+09f;
			this.prefix = prefix;
			clock = new RealtimeClock();
			queue = new BlockingCollection<Action>();
			finishSource = new TaskCompletionSource<bool>();
			worker = new Thread((ThreadStart)async delegate
			{
				foreach (Action item in queue.GetConsumingEnumerable())
				{
					item();
				}
				finishSource.SetResult(result: true);
			});
			chunkTask = Task.FromResult<MediaAsset>(null);
			worker.Start();
		}

		public void Append(PixelBuffer pixelBuffer, PixelBuffer.Rotation rotation = PixelBuffer.Rotation._0)
		{
			int num;
			int num2;
			if (rotation != PixelBuffer.Rotation._90)
			{
				num = ((rotation == PixelBuffer.Rotation._270) ? 1 : 0);
				if (num == 0)
				{
					num2 = pixelBuffer.width;
					goto IL_002b;
				}
			}
			else
			{
				num = 1;
			}
			num2 = pixelBuffer.height;
			goto IL_002b;
			IL_002b:
			int num3 = num2;
			int num4 = ((num != 0) ? pixelBuffer.width : pixelBuffer.height);
			if (num3 != width || num4 != height)
			{
				throw new ArgumentException($"Cannot append pixel buffer with size {num3}x{num4} to replay buffer with size {width}x{height}");
			}
			Packet packet = new Packet(num3, num4, clock.timestamp);
			pixelBuffer.CopyTo(packet.buffer, rotation);
			queue.Add(delegate
			{
				FlushPacket(in packet);
			});
		}

		public async Task<MediaAsset?> FinishWriting()
		{
			queue.CompleteAdding();
			await finishSource.Task;
			if (recorder == null)
			{
				throw new InvalidOperationException("Recorder failed to finish writing because no pixel buffers were appended");
			}
			MediaAsset result = await recorder.FinishWriting();
			MediaAsset mediaAsset = await chunkTask;
			if (result.duration < duration && mediaAsset != null)
			{
				result = await MediaAsset.FromConcatenatingAssets(new MediaAsset[2] { mediaAsset, result }, format, prefix);
			}
			if (result.duration > duration)
			{
				result = await result.TakeLast(duration, format, prefix);
			}
			return result;
		}

		private void FlushPacket(in Packet packet)
		{
			ulong num = (ulong)((float)packet.buffer.timestamp / chunkDurationNs);
			if (recorderIdx < num && recorder != null)
			{
				chunkTask = recorder.FinishWriting();
				recorder = null;
			}
			if (recorder == null)
			{
				recorder = MediaRecorder.Create(format, width, height, frameRate, 0, 0, 20000000, 1, 0.8f, 64000, prefix).Result;
				recorderIdx = num;
			}
			recorder.Append(packet.buffer);
			packet.Dispose();
		}
	}
}
