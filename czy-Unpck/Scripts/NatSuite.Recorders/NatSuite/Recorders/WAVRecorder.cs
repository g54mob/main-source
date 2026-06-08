using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NatSuite.Recorders.Internal;
using UnityEngine;

namespace NatSuite.Recorders
{
	public sealed class WAVRecorder : IMediaRecorder
	{
		private readonly int sampleRate;

		private readonly int channelCount;

		private readonly FileStream stream;

		private int sampleCount;

		public (int width, int height) frameSize => default((int, int));

		public WAVRecorder(int sampleRate, int channelCount)
		{
			this.sampleRate = sampleRate;
			this.channelCount = channelCount;
			stream = new FileStream(Utility.GetPath(".wav"), FileMode.Create);
			sampleCount = 0;
			byte[] array = new byte[44];
			stream.Write(array, 0, array.Length);
		}

		public unsafe void CommitSamples(float[] sampleBuffer, long timestamp = 0L)
		{
			fixed (float* nativeBuffer = sampleBuffer)
			{
				CommitSamples(nativeBuffer, sampleBuffer.Length, timestamp);
			}
		}

		public unsafe void CommitSamples(float* nativeBuffer, int sampleCount, long timestamp = 0L)
		{
			fixed (short* ptr = new short[sampleCount])
			{
				for (int i = 0; i < sampleCount; i++)
				{
					ptr[i] = (short)(nativeBuffer[i] * 32767f);
				}
				new UnmanagedMemoryStream((byte*)ptr, sampleCount * 2).CopyTo(stream);
			}
			this.sampleCount += sampleCount;
		}

		public Task<string> FinishWriting()
		{
			stream.Seek(0L, SeekOrigin.Begin);
			stream.Write(Encoding.UTF8.GetBytes("RIFF"), 0, 4);
			stream.Write(BitConverter.GetBytes(stream.Length - 8), 0, 4);
			stream.Write(Encoding.UTF8.GetBytes("WAVE"), 0, 4);
			stream.Write(Encoding.UTF8.GetBytes("fmt "), 0, 4);
			stream.Write(BitConverter.GetBytes(16), 0, 4);
			stream.Write(BitConverter.GetBytes((ushort)1), 0, 2);
			stream.Write(BitConverter.GetBytes(channelCount), 0, 2);
			stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);
			stream.Write(BitConverter.GetBytes(sampleRate * channelCount * 2), 0, 4);
			stream.Write(BitConverter.GetBytes((ushort)(channelCount * 2)), 0, 2);
			stream.Write(BitConverter.GetBytes((ushort)16), 0, 2);
			stream.Write(Encoding.UTF8.GetBytes("data"), 0, 4);
			stream.Write(BitConverter.GetBytes(sampleCount * 2), 0, 4);
			stream.Dispose();
			return Task.FromResult(stream.Name);
		}

		unsafe void IMediaRecorder.CommitFrame<T>(T[] pixelBuffer, long timestamp)
		{
			fixed (T* nativeBuffer = pixelBuffer)
			{
				((IMediaRecorder)this).CommitFrame((void*)nativeBuffer, timestamp);
			}
		}

		unsafe void IMediaRecorder.CommitFrame(void* nativeBuffer, long timestamp)
		{
			Debug.LogError("NatCorder Error: WAVRecorder does not support committing video frames");
		}
	}
}
