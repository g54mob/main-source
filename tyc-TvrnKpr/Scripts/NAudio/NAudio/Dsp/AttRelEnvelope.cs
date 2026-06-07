namespace NAudio.Dsp
{
	internal class AttRelEnvelope
	{
		protected const double DC_OFFSET = 1E-25;

		private readonly EnvelopeDetector attack;

		private readonly EnvelopeDetector release;

		public double Attack
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double Release
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double SampleRate
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public AttRelEnvelope(double attackMilliseconds, double releaseMilliseconds, double sampleRate)
		{
		}

		public void Run(double inValue, ref double state)
		{
		}
	}
}
