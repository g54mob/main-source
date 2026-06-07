namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public enum IterationStatus
	{
		Continue = 0,
		Converged = 1,
		Diverged = 2,
		StoppedWithoutConvergence = 3,
		Cancelled = 4,
		Failure = 5
	}
}
