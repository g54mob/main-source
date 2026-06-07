namespace NAudio.Wave
{
	public class WaveInProvider : IWaveProvider
	{
		private IWaveIn waveIn;

		private BufferedWaveProvider bufferedWaveProvider;

		public WaveFormat WaveFormat => null;

		public WaveInProvider(IWaveIn waveIn)
		{
		}

		private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
