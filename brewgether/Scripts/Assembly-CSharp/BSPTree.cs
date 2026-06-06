using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class BSPTree : MonoBehaviour
{
	public class Node
	{
		public Vector3 partitionPoint;

		public Vector3 partitionNormal;

		public Node positiveChild;

		public Node negativeChild;

		public int[] triangles;
	}

	[SerializeField]
	private bool drawMeshTreeOnStart;

	private int triangleCount;

	private int vertexCount;

	private Vector3[] vertices;

	private int[] tris;

	private Vector3[] triangleNormals;

	private Mesh mesh;

	private Node tree;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public Vector3 ClosestPointOn(Vector3 to, float radius)
	{
		return default(Vector3);
	}

	private void FindClosestTriangles(Node node, Vector3 to, float radius, List<int> triangles)
	{
	}

	private Vector3 ClosestPointOnTriangle(int[] triangles, Vector3 to)
	{
		return default(Vector3);
	}

	private void BuildTriangleTree()
	{
	}

	private void RecursivePartition(List<int> triangles, int depth, Node parent)
	{
	}

	private void Split(List<int> triangles, Vector3 partitionPoint, Vector3 partitionNormal, out List<int> positiveTriangles, out List<int> negativeTriangles)
	{
		positiveTriangles = null;
		negativeTriangles = null;
	}

	private bool PointAbovePlane(Vector3 planeOrigin, Vector3 planeNormal, Vector3 point)
	{
		return false;
	}

	private float PointDistanceFromPlane(Vector3 planeOrigin, Vector3 planeNormal, Vector3 point)
	{
		return 0f;
	}

	public static void ClosestPointOnTriangleToPoint(ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3, ref Vector3 point, out Vector3 result)
	{
		result = default(Vector3);
	}

	private void DrawTriangleSet(int[] triangles, Color color)
	{
	}
}
