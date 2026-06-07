namespace NAudio.Wave.SampleProviders
{
	public class PanningSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider source;

		private float pan;

		private float leftMultiplier;

		private float rightMultiplier;

		private readonly WaveFormat waveFormat;

		private float[] sourceBuffer;

		private IPanStrategy panStrategy;

		public float Pan
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public IPanStrategy PanStrategy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WaveFormat WaveFormat => null;

		public PanningSampleProvider(ISampleProvider source)
		{
		}

		private void UpdateMultipliers()
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
