using System;
using UnityEngine;

public class WireRenderer : MonoBehaviour
{
	[Serializable]
	public class WireVertex
	{
		public Vector3 point;

		public float radius;

		public Color color;

		public WireVertex(Vector3 pt, float r, Color c)
		{
		}
	}

	public WireVertex[] vertices;

	public Material material;

	public int crossSegments;

	public Renderer rend;

	public bool hasCollider;

	public MeshCollider meshCollider;

	public int colId;

	private int prevCrossSegments;

	private int prevVertLength;

	private Vector3[] meshVertices;

	private Vector2[] uvs;

	private Color[] colors;

	private int[] tris;

	private int[] lastVertices;

	private int[] theseVertices;

	private Quaternion rotation;

	public Mesh genMesh;

	public MeshFilter meshFilter;

	private Vector3[] crossPoints { get; set; }

	private Vector3[] prevCrossPoints { get; set; }

	private void Awake()
	{
	}

	public void SetPoints(Vector3[] pos, float r, int col)
	{
	}

	private void CreateGeometry()
	{
	}
}
