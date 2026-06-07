using System;

namespace Pathfinding
{
	[Serializable]
	public struct PathRequestSettings
	{
		public GraphMask graphMask;

		public int[] tagPenalties;

		public int traversableTags;

		public ITraversalProvider traversalProvider;

		public static PathRequestSettings Default => default(PathRequestSettings);
	}
}
