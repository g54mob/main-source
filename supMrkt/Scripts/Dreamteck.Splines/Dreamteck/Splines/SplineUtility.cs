namespace Dreamteck.Splines
{
	public static class SplineUtility
	{
		public enum MergeSide
		{
			Start = 0,
			End = 1
		}

		public static void Merge(SplineComputer baseSpline, SplineComputer addedSpline, MergeSide side, bool mergeEndpoints = false, bool destroyAddedSpline = false)
		{
		}
	}
}
