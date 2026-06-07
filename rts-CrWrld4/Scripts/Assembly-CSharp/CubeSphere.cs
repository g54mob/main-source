using UnityEngine;

public class CubeSphere : MonoBehaviour
{
	public int gridSize;

	public float radius;

	private Mesh mesh;

	private Vector3[] vertices;

	private Vector3[] normals;

	private Color32[] cubeUV;

	private void Awake()
	{
	}

	private void Generate()
	{
	}

	private void CreateVertices()
	{
	}

	private void SetVertex(int i, int x, int y, int z)
	{
	}

	private void CreateTriangles()
	{
	}

	private int CreateTopFace(int[] triangles, int t, int ring)
	{
		return 0;
	}

	private int CreateBottomFace(int[] triangles, int t, int ring)
	{
		return 0;
	}

	private static int SetQuad(int[] triangles, int i, int v00, int v10, int v01, int v11)
	{
		return 0;
	}

	private void CreateColliders()
	{
	}
}
