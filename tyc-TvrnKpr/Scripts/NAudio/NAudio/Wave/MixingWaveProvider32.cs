using System.Collections.Generic;

namespace NAudio.Wave
{
	public class MixingWaveProvider32 : IWaveProvider
	{
		private List<IWaveProvider> inputs;

		private WaveFormat waveFormat;

		private int bytesPerSample;

		public int InputCount => 0;

		public WaveFormat WaveFormat => null;

		public MixingWaveProvider32()
		{
		}

		public MixingWaveProvider32(IEnumerable<IWaveProvider> inputs)
		{
		}

		public void AddInputStream(IWaveProvider waveProvider)
		{
		}

		public void RemoveInputStream(IWaveProvider waveProvider)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private static void Sum32BitAudio(byte[] destBuffer, int offset, byte[] sourceBuffer, int bytesRead)
		{
		}
	}
}
