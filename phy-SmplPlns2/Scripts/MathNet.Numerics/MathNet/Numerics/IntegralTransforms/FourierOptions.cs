using System;

namespace MathNet.Numerics.IntegralTransforms
{
	[Flags]
	public enum FourierOptions
	{
		InverseExponent = 1,
		AsymmetricScaling = 2,
		NoScaling = 4,
		Default = 0,
		Matlab = 2,
		NumericalRecipes = 5
	}
}
