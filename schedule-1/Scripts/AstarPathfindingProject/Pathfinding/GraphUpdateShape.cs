using UnityEngine;

namespace Pathfinding
{
	public class GraphUpdateShape
	{
		private Vector3[] _points;

		private Vector3[] _convexPoints;

		private bool _convex;

		private Vector3 right;

		private Vector3 forward;

		private Vector3 up;

		private Vector3 origin;

		public float minimumHeight;

		public Vector3[] points
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool convex
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public GraphUpdateShape()
		{
		}

		public GraphUpdateShape(Vector3[] points, bool convex, Matrix4x4 matrix, float minimumHeight)
		{
		}

		private void CalculateConvexHull()
		{
		}

		public Bounds GetBounds()
		{
			return default(Bounds);
		}

		public static Bounds GetBounds(Vector3[] points, Matrix4x4 matrix, float minimumHeight)
		{
			return default(Bounds);
		}

		private static Bounds GetBounds(Vector3[] points, Vector3 right, Vector3 up, Vector3 forward, Vector3 origin, float minimumHeight)
		{
			return default(Bounds);
		}

		public bool Contains(GraphNode node)
		{
			return false;
		}

		public bool Contains(Vector3 point)
		{
			return false;
		}
	}
}
