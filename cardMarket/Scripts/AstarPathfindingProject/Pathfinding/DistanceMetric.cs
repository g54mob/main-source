using UnityEngine;

namespace Pathfinding
{
	public struct DistanceMetric
	{
		public Vector3 projectionAxis;

		public float distanceScaleAlongProjectionDirection;

		public static readonly DistanceMetric Euclidean = new DistanceMetric
		{
			projectionAxis = Vector3.zero,
			distanceScaleAlongProjectionDirection = 0f
		};

		public bool isProjectedDistance => projectionAxis != Vector3.zero;

		public static DistanceMetric ClosestAsSeenFromAboveSoft()
		{
			return new DistanceMetric
			{
				projectionAxis = Vector3.positiveInfinity,
				distanceScaleAlongProjectionDirection = 0.2f
			};
		}

		public static DistanceMetric ClosestAsSeenFromAboveSoft(Vector3 up)
		{
			return new DistanceMetric
			{
				projectionAxis = up,
				distanceScaleAlongProjectionDirection = 0.2f
			};
		}

		public static DistanceMetric ClosestAsSeenFromAbove()
		{
			return new DistanceMetric
			{
				projectionAxis = Vector3.positiveInfinity,
				distanceScaleAlongProjectionDirection = 0f
			};
		}

		public static DistanceMetric ClosestAsSeenFromAbove(Vector3 up)
		{
			return new DistanceMetric
			{
				projectionAxis = up,
				distanceScaleAlongProjectionDirection = 0f
			};
		}
	}
}
