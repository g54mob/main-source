using UnityEngine;

public class RoundedCube : MonoBehaviour
{
	public int xSize;

	public int ySize;

	public int zSize;

	public int roundness;

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

	private void AddBoxCollider(float x, float y, float z)
	{
	}

	private void AddCapsuleCollider(int direction, float x, float y, float z)
	{
	}
}
