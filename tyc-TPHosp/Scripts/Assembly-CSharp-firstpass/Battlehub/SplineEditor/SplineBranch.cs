using System;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public struct SplineBranch
	{
		public int SplineIndex;

		public bool Inbound;

		public SplineBranch(int splineIndex, bool inbound)
		{
			SplineIndex = splineIndex;
			Inbound = inbound;
		}
	}
}
