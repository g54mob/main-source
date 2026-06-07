using NAudio.Dsp;

namespace NAudio.Wave.SampleProviders
{
	public class WdlResamplingSampleProvider : ISampleProvider
	{
		private readonly WdlResampler resampler;

		private readonly WaveFormat outFormat;

		private readonly ISampleProvider source;

		private readonly int channels;

		public WaveFormat WaveFormat => null;

		public WdlResamplingSampleProvider(ISampleProvider source, int newSampleRate)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
