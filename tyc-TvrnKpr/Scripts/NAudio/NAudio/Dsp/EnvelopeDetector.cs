namespace NAudio.Dsp
{
	internal class EnvelopeDetector
	{
		private double sampleRate;

		private double ms;

		private double coeff;

		public double TimeConstant
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

		public EnvelopeDetector()
		{
		}

		public EnvelopeDetector(double ms, double sampleRate)
		{
		}

		public void Run(double inValue, ref double state)
		{
		}

		private void SetCoef()
		{
		}
	}
}
