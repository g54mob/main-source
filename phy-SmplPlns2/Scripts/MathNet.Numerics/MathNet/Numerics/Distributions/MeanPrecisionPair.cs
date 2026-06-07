namespace MathNet.Numerics.Distributions
{
	public struct MeanPrecisionPair
	{
		public double Mean { get; set; }

		public double Precision { get; set; }

		public MeanPrecisionPair(double m, double p)
		{
			Mean = m;
			Precision = p;
		}
	}
}
