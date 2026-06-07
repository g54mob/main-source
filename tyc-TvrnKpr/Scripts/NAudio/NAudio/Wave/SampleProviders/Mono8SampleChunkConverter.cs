namespace NAudio.Wave.SampleProviders
{
	internal class Mono8SampleChunkConverter : ISampleChunkConverter
	{
		private int offset;

		private byte[] sourceBuffer;

		private int sourceBytes;

		public bool Supports(WaveFormat waveFormat)
		{
			return false;
		}

		public void LoadNextChunk(IWaveProvider source, int samplePairsRequired)
		{
		}

		public bool GetNextSample(out float sampleLeft, out float sampleRight)
		{
			sampleLeft = default(float);
			sampleRight = default(float);
			return false;
		}
	}
}
