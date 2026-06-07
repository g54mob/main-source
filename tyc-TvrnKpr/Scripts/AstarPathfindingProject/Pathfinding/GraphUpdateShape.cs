using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public class GraphUpdateShape
	{
		public struct BurstShape
		{
			[DeallocateOnJobCompletion]
			private NativeArray<Vector3> points;

			private float3 origin;

			private float3 right;

			private float3 forward;

			private bool containsEverything;

			public static BurstShape Everything => default(BurstShape);

			public BurstShape(GraphUpdateShape scene, Allocator allocator)
			{
				points = default(NativeArray<Vector3>);
				origin = default(float3);
				right = default(float3);
				forward = default(float3);
				containsEverything = false;
			}

			public bool Contains(float3 point)
			{
				return false;
			}
		}

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
