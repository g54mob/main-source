using UnityEngine;

public static class GeometryBuilder
{
	public static Mesh Box(float scale)
	{
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[8]
		{
			new Vector3(-1f, -1f, 1f) * scale,
			new Vector3(1f, -1f, 1f) * scale,
			new Vector3(-1f, -1f, -1f) * scale,
			new Vector3(1f, -1f, -1f) * scale,
			new Vector3(-1f, 1f, 1f) * scale,
			new Vector3(1f, 1f, 1f) * scale,
			new Vector3(-1f, 1f, -1f) * scale,
			new Vector3(1f, 1f, -1f) * scale
		};
		mesh.subMeshCount = 1;
		mesh.uv = new Vector2[8]
		{
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero
		};
		Mesh mesh2 = mesh;
		mesh2.SetIndices(new int[24]
		{
			0, 1, 1, 3, 3, 2, 2, 0, 0, 4,
			1, 5, 2, 6, 3, 7, 4, 5, 5, 7,
			7, 6, 6, 4
		}, MeshTopology.Lines, 0);
		return mesh2;
	}

	public static Mesh CornerBox(float scale, float cornerSize)
	{
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[32]
		{
			new Vector3(1f, 1f, 1f) * scale,
			new Vector3(1f - cornerSize, 1f, 1f) * scale,
			new Vector3(1f, 1f - cornerSize, 1f) * scale,
			new Vector3(1f, 1f, 1f - cornerSize) * scale,
			new Vector3(1f, 1f, -1f) * scale,
			new Vector3(1f - cornerSize, 1f, -1f) * scale,
			new Vector3(1f, 1f - cornerSize, -1f) * scale,
			new Vector3(1f, 1f, -1f + cornerSize) * scale,
			new Vector3(1f, -1f, 1f) * scale,
			new Vector3(1f - cornerSize, -1f, 1f) * scale,
			new Vector3(1f, -1f + cornerSize, 1f) * scale,
			new Vector3(1f, -1f, 1f - cornerSize) * scale,
			new Vector3(1f, -1f, -1f) * scale,
			new Vector3(1f - cornerSize, -1f, -1f) * scale,
			new Vector3(1f, -1f + cornerSize, -1f) * scale,
			new Vector3(1f, -1f, -1f + cornerSize) * scale,
			new Vector3(-1f, 1f, 1f) * scale,
			new Vector3(-1f + cornerSize, 1f, 1f) * scale,
			new Vector3(-1f, 1f - cornerSize, 1f) * scale,
			new Vector3(-1f, 1f, 1f - cornerSize) * scale,
			new Vector3(-1f, 1f, -1f) * scale,
			new Vector3(-1f + cornerSize, 1f, -1f) * scale,
			new Vector3(-1f, 1f - cornerSize, -1f) * scale,
			new Vector3(-1f, 1f, -1f + cornerSize) * scale,
			new Vector3(-1f, -1f, 1f) * scale,
			new Vector3(-1f + cornerSize, -1f, 1f) * scale,
			new Vector3(-1f, -1f + cornerSize, 1f) * scale,
			new Vector3(-1f, -1f, 1f - cornerSize) * scale,
			new Vector3(-1f, -1f, -1f) * scale,
			new Vector3(-1f + cornerSize, -1f, -1f) * scale,
			new Vector3(-1f, -1f + cornerSize, -1f) * scale,
			new Vector3(-1f, -1f, -1f + cornerSize) * scale
		};
		mesh.subMeshCount = 1;
		mesh.uv = new Vector2[32]
		{
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero,
			Vector2.zero
		};
		Mesh mesh2 = mesh;
		mesh2.SetIndices(new int[48]
		{
			0, 1, 0, 2, 0, 3, 4, 5, 4, 6,
			4, 7, 8, 9, 8, 10, 8, 11, 12, 13,
			12, 14, 12, 15, 16, 17, 16, 18, 16, 19,
			20, 21, 20, 22, 20, 23, 24, 25, 24, 26,
			24, 27, 28, 29, 28, 30, 28, 31
		}, MeshTopology.Lines, 0);
		return mesh2;
	}
}
