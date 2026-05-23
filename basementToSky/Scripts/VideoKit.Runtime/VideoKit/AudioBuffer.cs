using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using VideoKit.Internal;

namespace VideoKit
{
	public readonly struct AudioBuffer : IDisposable
	{
		private readonly IntPtr handle;

		private unsafe readonly float* audioData;

		public unsafe NativeArray<float> data
		{
			get
			{
				handle.GetAudioBufferData(out var dataPointer).Throw();
				handle.GetAudioBufferSampleCount(out var sampleCount).Throw();
				return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<float>(dataPointer, sampleCount, Allocator.None);
			}
		}

		public int sampleRate
		{
			get
			{
				if (handle.GetAudioBufferSampleRate(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public int channelCount
		{
			get
			{
				if (handle.GetAudioBufferChannelCount(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public long timestamp
		{
			get
			{
				if (handle.GetSampleBufferTimestamp(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0L;
				}
				return result;
			}
		}

		public unsafe AudioBuffer(int sampleRate, int channelCount, float[] data, long timestamp = 0L)
		{
			int num = data.Length * 4;
			audioData = (float*)UnsafeUtility.Malloc(num, 16, Allocator.Persistent);
			fixed (float* source = data)
			{
				UnsafeUtility.MemCpy(audioData, source, num);
			}
			VideoKit.Internal.VideoKit.CreateAudioBuffer(sampleRate, channelCount, audioData, data.Length, timestamp, out handle).Throw();
		}

		public unsafe AudioBuffer(int sampleRate, int channelCount, NativeArray<float> data, long timestamp = 0L)
			: this(sampleRate, channelCount, (float*)data.GetUnsafePtr(), data.Length, timestamp)
		{
		}

		public unsafe AudioBuffer(int sampleRate, int channelCount, float* data, int sampleCount, long timestamp = 0L)
			: this((VideoKit.Internal.VideoKit.CreateAudioBuffer(sampleRate, channelCount, data, sampleCount, timestamp, out var audioBuffer).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? audioBuffer : ((IntPtr)0))
		{
		}

		public unsafe void Dispose()
		{
			handle.ReleaseSampleBuffer();
			UnsafeUtility.Free(audioData, Allocator.Persistent);
		}

		internal unsafe AudioBuffer(IntPtr buffer)
		{
			handle = buffer;
			audioData = null;
		}

		public static implicit operator IntPtr(AudioBuffer audioBuffer)
		{
			return audioBuffer.handle;
		}
	}
}
