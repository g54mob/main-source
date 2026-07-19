using UnityEngine;

public class MeshMirror : MonoBehaviour
{
	public static void MultiplyMeshCoordinates(Vector3 mul, Mesh mesh)
	{
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = mult(vertices[i], mul);
			normals[i] = mult(normals[i], mul);
		}
		mesh.vertices = vertices;
		mesh.normals = normals;
		mesh.RecalculateBounds();
		mesh.RecalculateTangents();
	}

	public static void FlipTris(Mesh mesh)
	{
		for (int i = 0; i < mesh.subMeshCount; i++)
		{
			int[] triangles = mesh.GetTriangles(i);
			for (int j = 0; j < triangles.Length; j += 3)
			{
				int num = triangles[j + 1];
				triangles[j + 1] = triangles[j + 2];
				triangles[j + 2] = num;
			}
			mesh.SetTriangles(triangles, i);
		}
	}

	public static void FlipModelX(Mesh mesh)
	{
		MultiplyMeshCoordinates(new Vector3(-1f, 1f, 1f), mesh);
		FlipTris(mesh);
	}

	public static void FlipModelY(Mesh mesh)
	{
		MultiplyMeshCoordinates(new Vector3(1f, -1f, 1f), mesh);
		FlipTris(mesh);
	}

	public static void FlipModelZ(Mesh mesh)
	{
		MultiplyMeshCoordinates(new Vector3(1f, 1f, -1f), mesh);
		FlipTris(mesh);
	}

	private static Vector3 mult(Vector3 x, Vector3 y)
	{
		return new Vector3(x.x * y.x, x.y * y.y, x.z * y.z);
	}
}
