using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Geometry
{
	public class MeshOctreeNode
	{
		public const int MAX_TRIANGLES = 20;

		public const float MIN_NODE_SIZE = 0.05f;

		public const float EPSILON = 1E-05f;

		private static List<int> sClosestTrianglesIndexes;

		public Vector3 Center;

		public Vector3 Size;

		public Vector3 Min;

		public Vector3 Max;

		public MeshOctreeNode[] Children;

		public List<int> TriangleIndexes;

		public Vector3[] MeshVertices;

		public int[] MeshTriangles;

		public MeshOctreeNode()
		{
		}

		public MeshOctreeNode(Vector3 rCenter, Vector3 rSize)
		{
		}

		public MeshOctreeNode(float rX, float rY, float rZ, Vector3 rSize)
		{
		}

		public MeshOctreeNode(float rX, float rY, float rZ, Vector3 rSize, Vector3[] rVertexArray, int[] rTriangleArray)
		{
		}

		public bool ContainsPoint(Vector3 rPoint)
		{
			return false;
		}

		public bool ContainsPoint(Vector3 rPoint, float rRadius)
		{
			return false;
		}

		public Vector3 ClosestPoint(Vector3 rPoint)
		{
			return default(Vector3);
		}

		public Vector3 ClosestPoint(Vector3 rPoint, float rRadius)
		{
			return default(Vector3);
		}

		public int ClosestTriangle(Vector3 rPoint)
		{
			return 0;
		}

		public MeshOctreeNode ClosestNode(Vector3 rPoint)
		{
			return null;
		}

		public void Insert(int rTriangleIndex)
		{
		}

		public void Insert(int rTriangleIndex, Vector3 rTriangleCenter, float rTriangleRadius)
		{
		}

		public void Insert(int rTriangleIndex, Vector3 rTriangleCenter, Vector3 rTriangleMin, Vector3 rTriangleMax)
		{
		}

		public virtual void Split()
		{
		}

		public void GetTriangles(Vector3 rPoint, float rRadius, List<int> rTriangles)
		{
		}

		public void GetTriangleBounds(int rTriangleIndex, out Vector3 rTriangleCenter, out float rTriangleRadius)
		{
			rTriangleCenter = default(Vector3);
			rTriangleRadius = default(float);
		}

		public void GetTriangleBounds(int rTriangleIndex, out Vector3 rTriangleCenter, out Vector3 rTriangleMin, out Vector3 rTriangleMax)
		{
			rTriangleCenter = default(Vector3);
			rTriangleMin = default(Vector3);
			rTriangleMax = default(Vector3);
		}

		public void OnSceneGUI(Transform rTransform)
		{
		}
	}
}
