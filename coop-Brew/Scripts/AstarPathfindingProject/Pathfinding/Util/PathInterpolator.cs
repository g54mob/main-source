using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.Util
{
	public class PathInterpolator
	{
		public struct Cursor
		{
			private PathInterpolator interpolator;

			private int version;

			private float currentDistance;

			private float distanceToSegmentStart;

			private float currentSegmentLength;

			private int segmentIndex { get; set; }

			public int segmentCount => 0;

			public Vector3 endPoint => default(Vector3);

			public float fractionAlongCurrentSegment
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public bool valid => false;

			public Vector3 tangent => default(Vector3);

			public float remainingDistance
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float distance
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public Vector3 position => default(Vector3);

			public Vector3 curvatureDirection => default(Vector3);

			public static Cursor StartOfPath(PathInterpolator interpolator)
			{
				return default(Cursor);
			}

			public void GetRemainingPath(List<Vector3> buffer)
			{
			}

			private void AssertValid()
			{
			}

			public void GetTangents(out Vector3 t1, out Vector3 t2)
			{
				t1 = default(Vector3);
				t2 = default(Vector3);
			}

			public void MoveToNextCorner()
			{
			}

			public bool MoveToClosestIntersectionWithLineSegment(Vector3 origin, Vector3 direction, Vector2 range)
			{
				return false;
			}

			private void MoveToSegment(int index, float fractionAlongSegment)
			{
			}

			public void MoveToClosestPoint(Vector3 point)
			{
			}

			public void MoveToLocallyClosestPoint(Vector3 point, bool allowForwards = true, bool allowBackwards = true)
			{
			}

			public void MoveToCircleIntersection2D<T>(Vector3 circleCenter3D, float radius, T transform) where T : IMovementPlane
			{
			}

			private static float IntegrateSmoothingKernel(float a, float b, float smoothingDistance)
			{
				return 0f;
			}

			private static float IntegrateSmoothingKernel2(float a, float b, float smoothingDistance)
			{
				return 0f;
			}

			private static Vector3 IntegrateSmoothTangent(Vector3 p1, Vector3 p2, ref Vector3 tangent, ref float distance, float expectedRadius, float smoothingDistance)
			{
				return default(Vector3);
			}

			public Vector3 EstimateSmoothTangent(Vector3 normalizedTangent, float smoothingDistance, float expectedRadius, Vector3 beforePathStartContribution, bool forward = true, bool backward = true)
			{
				return default(Vector3);
			}

			public Vector3 EstimateSmoothCurvature(Vector3 tangent, float smoothingDistance, float expectedRadius)
			{
				return default(Vector3);
			}

			public void MoveWithTurningSpeed(float time, float speed, float turningSpeed, ref Vector3 tangent)
			{
			}

			private void PrevSegment()
			{
			}

			private void NextSegment()
			{
			}
		}

		private List<Vector3> path;

		private int version;

		private float totalDistance;

		public bool valid => false;

		public Cursor start => default(Cursor);

		public Cursor AtDistanceFromStart(float distance)
		{
			return default(Cursor);
		}

		public void SetPath(List<Vector3> path)
		{
		}
	}
}
