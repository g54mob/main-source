namespace NAudio.Wave
{
	public class SilenceProvider : IWaveProvider
	{
		public WaveFormat WaveFormat { get; private set; }

		public SilenceProvider(WaveFormat wf)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
