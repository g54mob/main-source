using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	internal class WaveOutBuffer : IDisposable
	{
		private readonly WaveHeader header;

		private readonly int bufferSize;

		private readonly byte[] buffer;

		private readonly IWaveProvider waveStream;

		private readonly object waveOutLock;

		private GCHandle hBuffer;

		private IntPtr hWaveOut;

		private GCHandle hHeader;

		private GCHandle hThis;

		public bool InQueue => false;

		public int BufferSize => 0;

		public WaveOutBuffer(IntPtr hWaveOut, int bufferSize, IWaveProvider bufferFillStream, object waveOutLock)
		{
		}

		~WaveOutBuffer()
		{
		}

		public void Dispose()
		{
		}

		protected void Dispose(bool disposing)
		{
		}

		internal bool OnDone()
		{
			return false;
		}

		private void WriteToWaveOut()
		{
		}
	}
}
