using System;
using NAudio.Wave;

namespace NAudio.MediaFoundation
{
	public abstract class MediaFoundationTransform : IWaveProvider, IDisposable
	{
		protected readonly IWaveProvider sourceProvider;

		protected readonly WaveFormat outputWaveFormat;

		private readonly byte[] sourceBuffer;

		private byte[] outputBuffer;

		private int outputBufferOffset;

		private int outputBufferCount;

		private IMFTransform transform;

		private bool disposed;

		private long inputPosition;

		private long outputPosition;

		private bool initializedForStreaming;

		public WaveFormat WaveFormat => null;

		public MediaFoundationTransform(IWaveProvider sourceProvider, WaveFormat outputFormat)
		{
		}

		private void InitializeTransformForStreaming()
		{
		}

		protected abstract IMFTransform CreateTransform();

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
		}

		~MediaFoundationTransform()
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private void EndStreamAndDrain()
		{
		}

		private int ReadFromTransform()
		{
			return 0;
		}

		private static long BytesToNsPosition(int bytes, WaveFormat waveFormat)
		{
			return 0L;
		}

		private IMFSample ReadFromSource()
		{
			return null;
		}

		private int ReadFromOutputBuffer(byte[] buffer, int offset, int needed)
		{
			return 0;
		}

		public void Reposition()
		{
		}
	}
}
