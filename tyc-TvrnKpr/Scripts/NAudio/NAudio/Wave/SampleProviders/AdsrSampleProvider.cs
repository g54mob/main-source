using NAudio.Dsp;

namespace NAudio.Wave.SampleProviders
{
	public class AdsrSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider source;

		private readonly EnvelopeGenerator adsr;

		private float attackSeconds;

		private float releaseSeconds;

		public float AttackSeconds
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ReleaseSeconds
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public WaveFormat WaveFormat => null;

		public AdsrSampleProvider(ISampleProvider source)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}

		public void Stop()
		{
		}
	}
}
