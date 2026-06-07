using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.Util
{
	public class PathInterpolator
	{
		private List<Vector3> path;

		private float distanceToSegmentStart;

		private float currentDistance;

		private float currentSegmentLength;

		private float totalDistance;

		public virtual Vector3 position => default(Vector3);

		public Vector3 endPoint => default(Vector3);

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

		public int segmentIndex { get; private set; }

		public bool valid => false;

		public void GetRemainingPath(List<Vector3> buffer)
		{
		}

		public void SetPath(List<Vector3> path)
		{
		}

		public void MoveToSegment(int index, float fractionAlongSegment)
		{
		}

		public void MoveToClosestPoint(Vector3 point)
		{
		}

		public void MoveToLocallyClosestPoint(Vector3 point, bool allowForwards = true, bool allowBackwards = true)
		{
		}

		public void MoveToCircleIntersection2D(Vector3 circleCenter3D, float radius, IMovementPlane transform)
		{
		}

		protected virtual void PrevSegment()
		{
		}

		protected virtual void NextSegment()
		{
		}
	}
}
