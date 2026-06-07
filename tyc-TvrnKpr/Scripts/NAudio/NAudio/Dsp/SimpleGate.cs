namespace NAudio.Dsp
{
	internal class SimpleGate : AttRelEnvelope
	{
		private double threshdB;

		private double thresh;

		private double env;

		public double Threshold
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public SimpleGate()
			: base(0.0, 0.0, 0.0)
		{
		}

		public void Process(ref double in1, ref double in2)
		{
		}
	}
}
