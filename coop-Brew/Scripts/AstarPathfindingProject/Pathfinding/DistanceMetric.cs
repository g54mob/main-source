using UnityEngine;

namespace Pathfinding
{
	public struct DistanceMetric
	{
		public Vector3 projectionAxis;

		public float distanceScaleAlongProjectionDirection;

		public static readonly DistanceMetric Euclidean;

		public bool isProjectedDistance => false;

		public static DistanceMetric ClosestAsSeenFromAboveSoft()
		{
			return default(DistanceMetric);
		}

		public static DistanceMetric ClosestAsSeenFromAboveSoft(Vector3 up)
		{
			return default(DistanceMetric);
		}

		public static DistanceMetric ClosestAsSeenFromAbove()
		{
			return default(DistanceMetric);
		}

		public static DistanceMetric ClosestAsSeenFromAbove(Vector3 up)
		{
			return default(DistanceMetric);
		}
	}
}
