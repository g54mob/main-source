namespace Jobberwocky.MIConvexHull
{
	public enum ConvexHullCreationResultOutcome
	{
		Success = 0,
		DimensionSmallerTwo = 1,
		DimensionTwoWrongMethod = 2,
		NotEnoughVerticesForDimension = 3,
		NonUniformDimension = 4,
		DegenerateData = 5,
		UnknownError = 6
	}
}
