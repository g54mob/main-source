namespace MathNet.Numerics.Distributions
{
	public interface IUnivariateDistribution : IDistribution
	{
		double Mean { get; }

		double Variance { get; }

		double StdDev { get; }

		double Entropy { get; }

		double Skewness { get; }

		double Median { get; }

		double CumulativeDistribution(double x);
	}
}
