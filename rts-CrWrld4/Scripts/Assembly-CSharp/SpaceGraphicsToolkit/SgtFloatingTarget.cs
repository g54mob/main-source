using System;

namespace SpaceGraphicsToolkit
{
	public class SgtFloatingTarget : SgtLinkedBehaviour<SgtFloatingTarget>
	{
		public string WarpName;

		public SgtLength WarpDistance;

		[NonSerialized]
		private SgtFloatingPoint cachedPoint;

		[NonSerialized]
		private bool cachedPointSet;

		public SgtFloatingPoint CachedPoint => null;
	}
}
