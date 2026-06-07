using UnityEngine;

namespace Lightbug.Utilities
{
	public readonly struct HitInfoFilter
	{
		public readonly LayerMask collisionLayerMask;

		public readonly bool ignoreRigidbodies;

		public readonly bool ignoreTriggers;

		public readonly LayerMask ignorePhysicsLayerMask;

		public readonly float minimumDistance;

		public readonly float maximumDistance;

		public HitInfoFilter(LayerMask collisionLayerMask, bool ignoreRigidbodies, bool ignoreTriggers, int ignoredLayerMask = 0, float minimumDistance = 0f, float maximumDistance = float.PositiveInfinity)
		{
			this.collisionLayerMask = collisionLayerMask;
			this.ignoreRigidbodies = ignoreRigidbodies;
			this.ignoreTriggers = ignoreTriggers;
			ignorePhysicsLayerMask = ignoredLayerMask;
			this.minimumDistance = minimumDistance;
			this.maximumDistance = maximumDistance;
		}
	}
}
