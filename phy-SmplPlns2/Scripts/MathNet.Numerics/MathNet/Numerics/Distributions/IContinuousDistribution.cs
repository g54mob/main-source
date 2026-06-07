using System.Collections.Generic;

namespace MathNet.Numerics.Distributions
{
	public interface IContinuousDistribution : IUnivariateDistribution, IDistribution
	{
		double Mode { get; }

		double Minimum { get; }

		double Maximum { get; }

		double Density(double x);

		double DensityLn(double x);

		double Sample();

		void Samples(double[] values);

		IEnumerable<double> Samples();
	}
}
