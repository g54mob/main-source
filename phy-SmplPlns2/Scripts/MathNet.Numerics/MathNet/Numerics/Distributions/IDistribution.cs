using System;

namespace MathNet.Numerics.Distributions
{
	public interface IDistribution
	{
		System.Random RandomSource { get; set; }
	}
}
