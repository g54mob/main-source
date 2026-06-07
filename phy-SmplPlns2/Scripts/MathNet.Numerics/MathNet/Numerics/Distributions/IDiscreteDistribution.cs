using System.Collections.Generic;

namespace MathNet.Numerics.Distributions
{
	public interface IDiscreteDistribution : IUnivariateDistribution, IDistribution
	{
		int Mode { get; }

		int Minimum { get; }

		int Maximum { get; }

		double Probability(int k);

		double ProbabilityLn(int k);

		int Sample();

		void Samples(int[] values);

		IEnumerable<int> Samples();
	}
}
