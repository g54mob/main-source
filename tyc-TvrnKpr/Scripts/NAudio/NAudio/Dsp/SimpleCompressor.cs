namespace NAudio.Dsp
{
	internal class SimpleCompressor : AttRelEnvelope
	{
		private double envdB;

		public double MakeUpGain { get; set; }

		public double Threshold { get; set; }

		public double Ratio { get; set; }

		public SimpleCompressor(double attackTime, double releaseTime, double sampleRate)
			: base(0.0, 0.0, 0.0)
		{
		}

		public SimpleCompressor()
			: base(0.0, 0.0, 0.0)
		{
		}

		public void InitRuntime()
		{
		}

		public void Process(ref double in1, ref double in2)
		{
		}
	}
}
