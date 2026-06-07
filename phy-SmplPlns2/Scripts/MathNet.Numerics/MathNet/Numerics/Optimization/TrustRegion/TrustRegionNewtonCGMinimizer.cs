namespace MathNet.Numerics.Optimization.TrustRegion
{
	public sealed class TrustRegionNewtonCGMinimizer : TrustRegionMinimizerBase
	{
		public TrustRegionNewtonCGMinimizer(double gradientTolerance = 1E-08, double stepTolerance = 1E-08, double functionTolerance = 1E-08, double radiusTolerance = 1E-08, int maximumIterations = -1)
			: base(TrustRegionSubproblem.NewtonCG(), gradientTolerance, stepTolerance, functionTolerance, radiusTolerance, maximumIterations)
		{
		}
	}
}
