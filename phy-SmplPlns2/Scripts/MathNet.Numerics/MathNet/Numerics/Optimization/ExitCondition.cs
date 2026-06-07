namespace MathNet.Numerics.Optimization
{
	public enum ExitCondition
	{
		None = 0,
		InvalidValues = 1,
		ExceedIterations = 2,
		RelativePoints = 3,
		RelativeGradient = 4,
		LackOfProgress = 5,
		AbsoluteGradient = 6,
		WeakWolfeCriteria = 7,
		BoundTolerance = 8,
		StrongWolfeCriteria = 9,
		Converged = 10,
		ManuallyStopped = 11
	}
}
