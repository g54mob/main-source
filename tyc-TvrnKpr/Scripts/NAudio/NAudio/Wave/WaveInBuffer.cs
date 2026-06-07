using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	internal class WaveInBuffer : IDisposable
	{
		private readonly WaveHeader header;

		private readonly int bufferSize;

		private readonly byte[] buffer;

		private GCHandle hBuffer;

		private IntPtr waveInHandle;

		private GCHandle hHeader;

		private GCHandle hThis;

		public byte[] Data => null;

		public bool Done => false;

		public bool InQueue => false;

		public int BytesRecorded => 0;

		public int BufferSize => 0;

		public WaveInBuffer(IntPtr waveInHandle, int bufferSize)
		{
		}

		public void Reuse()
		{
		}

		~WaveInBuffer()
		{
		}

		public void Dispose()
		{
		}

		protected void Dispose(bool disposing)
		{
		}
	}
}
