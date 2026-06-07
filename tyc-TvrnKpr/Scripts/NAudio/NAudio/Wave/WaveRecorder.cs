using System;

namespace NAudio.Wave
{
	public class WaveRecorder : IWaveProvider, IDisposable
	{
		private WaveFileWriter writer;

		private IWaveProvider source;

		public WaveFormat WaveFormat => null;

		public WaveRecorder(IWaveProvider source, string destination)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
