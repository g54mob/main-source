namespace Coherence.Common
{
	public interface IRandom
	{
		double NextDouble();

		double NextNormalDistribution(double mean, double deviation);
	}
}
