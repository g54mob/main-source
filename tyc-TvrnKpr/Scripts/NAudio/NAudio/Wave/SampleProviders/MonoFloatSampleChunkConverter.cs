namespace NAudio.Wave.SampleProviders
{
	internal class MonoFloatSampleChunkConverter : ISampleChunkConverter
	{
		private int sourceSample;

		private byte[] sourceBuffer;

		private WaveBuffer sourceWaveBuffer;

		private int sourceSamples;

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
