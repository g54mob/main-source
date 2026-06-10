using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using UnityEngine;

namespace NSMedieval.Tools
{
	public static class MeshDataUtils
	{
		private static readonly Vector3[] BaseQuadVertices = new Vector3[4]
		{
			new Vector3(-0.5f, 0f, -0.5f),
			new Vector3(0.5f, 0f, -0.5f),
			new Vector3(0.5f, 0f, 0.5f),
			new Vector3(-0.5f, 0f, 0.5f)
		};

		private static readonly int[] CubeTriangles = new int[36]
		{
			0, 2, 1, 0, 3, 2, 2, 3, 4, 2,
			4, 5, 1, 2, 5, 1, 5, 6, 0, 7,
			4, 0, 4, 3, 5, 4, 7, 5, 7, 6,
			0, 6, 7, 0, 1, 6
		};

		public static void RotateMeshAround(ref List<Vector3> verts, Vector3 axis, float degrees)
		{
			for (int i = 0; i < verts.Count; i++)
			{
				verts[i] = Quaternion.AngleAxis(degrees, axis) * verts[i];
			}
		}

		public static void TranslateMesh(ref List<Vector3> verts, Vector3 offset)
		{
			for (int i = 0; i < verts.Count; i++)
			{
				verts[i] += offset;
			}
		}

		public static void AddToMesh(ref List<Vector3> sourceVertices, ref List<int> sourceTriangles, ref List<Vector3> destVertices, ref List<int> destTriangles)
		{
			int count = destVertices.Count;
			foreach (int sourceTriangle in sourceTriangles)
			{
				destTriangles.Add(sourceTriangle + count);
			}
			foreach (Vector3 sourceVertex in sourceVertices)
			{
				destVertices.Add(sourceVertex);
			}
		}

		public static void AddToMesh(ref List<Vector3> sourceVertices, ref List<int> sourceTriangles, ref List<Color> sourceColors, ref List<Vector2> sourceUVs, ref List<Vector3> destVertices, ref List<int> destTriangles, ref List<Color> destColors, ref List<Vector2> destUvs)
		{
			int count = destVertices.Count;
			foreach (int sourceTriangle in sourceTriangles)
			{
				destTriangles.Add(sourceTriangle + count);
			}
			destVertices.AddRange(sourceVertices);
			if (sourceColors.Count == 0)
			{
				Color item = new Color(1f, 1f, 1f, 1f);
				for (int i = 0; i < sourceVertices.Count; i++)
				{
					destColors.Add(item);
				}
			}
			else
			{
				destColors.AddRange(sourceColors);
			}
			if (sourceUVs.Count == 0)
			{
				for (int j = 0; j < sourceVertices.Count; j++)
				{
					destUvs.Add(Vector2.zero);
				}
			}
			else
			{
				destUvs.AddRange(sourceUVs);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AppendUnitQuad(ref List<Vector3> vertices, ref List<int> triangles, Vector3 position)
		{
			AppendQuad(ref vertices, ref triangles, position + BaseQuadVertices[0], position + BaseQuadVertices[1], position + BaseQuadVertices[2], position + BaseQuadVertices[3]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AppendQuad(ref List<Vector3> vertices, ref List<int> triangles, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
		{
			int count = vertices.Count;
			vertices.Add(v1);
			vertices.Add(v2);
			vertices.Add(v3);
			vertices.Add(v4);
			triangles.Add(count + 2);
			triangles.Add(count + 1);
			triangles.Add(count);
			triangles.Add(count);
			triangles.Add(count + 3);
			triangles.Add(count + 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CachedAppendTriangle(List<Vector3> vertices, List<int> triangles, Dictionary<Vector3, int> cache, Vector3 v0, Vector3 v1, Vector3 v2)
		{
			if (!cache.TryGetValue(v0, out var value))
			{
				cache.Add(v0, vertices.Count);
				triangles.Add(vertices.Count);
				vertices.Add(v0);
			}
			else
			{
				triangles.Add(value);
			}
			if (!cache.TryGetValue(v1, out var value2))
			{
				cache.Add(v1, vertices.Count);
				triangles.Add(vertices.Count);
				vertices.Add(v1);
			}
			else
			{
				triangles.Add(value2);
			}
			if (!cache.TryGetValue(v2, out var value3))
			{
				cache.Add(v2, vertices.Count);
				triangles.Add(vertices.Count);
				vertices.Add(v2);
			}
			else
			{
				triangles.Add(value3);
			}
		}

		public static void AppendTriangle(ref List<Vector3> vertices, ref List<int> triangles, Vector3 v1, Vector3 v2, Vector3 v3)
		{
			int count = vertices.Count;
			vertices.Add(v1);
			vertices.Add(v2);
			vertices.Add(v3);
			triangles.Add(count);
			triangles.Add(count + 1);
			triangles.Add(count + 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int CachedAppendTriangleVertex(List<Vector3> vertices, List<int> triangles, Dictionary<Vector3, int> cache, Vector3 v0)
		{
			if (!cache.TryGetValue(v0, out var value))
			{
				int count = vertices.Count;
				cache.Add(v0, count);
				triangles.Add(count);
				vertices.Add(v0);
				return count;
			}
			triangles.Add(value);
			return -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AppendCube(ref List<Vector3> vertices, ref List<int> triangles, float posX, float posY, float posZ, float sizeX, float sizeY, float sizeZ)
		{
			int count = vertices.Count;
			vertices.Add(new Vector3(posX, posY, posZ));
			vertices.Add(new Vector3(posX + sizeX, posY, posZ));
			vertices.Add(new Vector3(posX + sizeX, posY + sizeY, posZ));
			vertices.Add(new Vector3(posX, posY + sizeY, posZ));
			vertices.Add(new Vector3(posX, posY + sizeY, posZ + sizeZ));
			vertices.Add(new Vector3(posX + sizeX, posY + sizeY, posZ + sizeZ));
			vertices.Add(new Vector3(posX + sizeX, posY, posZ + sizeZ));
			vertices.Add(new Vector3(posX, posY, posZ + sizeZ));
			int[] cubeTriangles = CubeTriangles;
			foreach (int num in cubeTriangles)
			{
				triangles.Add(num + count);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AppendCube(ref List<Vector3> vertices, ref List<int> triangles, Vector3 pos, Vector3 size)
		{
			int count = vertices.Count;
			vertices.Add(new Vector3(pos.x, pos.y, pos.z));
			vertices.Add(new Vector3(pos.x + size.x, pos.y, pos.z));
			vertices.Add(new Vector3(pos.x + size.x, pos.y + size.y, pos.z));
			vertices.Add(new Vector3(pos.x, pos.y + size.y, pos.z));
			vertices.Add(new Vector3(pos.x, pos.y + size.y, pos.z + size.z));
			vertices.Add(new Vector3(pos.x + size.x, pos.y + size.y, pos.z + size.z));
			vertices.Add(new Vector3(pos.x + size.x, pos.y, pos.z + size.z));
			vertices.Add(new Vector3(pos.x, pos.y, pos.z + size.z));
			int[] cubeTriangles = CubeTriangles;
			foreach (int num in cubeTriangles)
			{
				triangles.Add(num + count);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AppendCube(ref List<Vector3> vertices, ref List<int> triangles, float posX, float posY, float posZ, float size)
		{
			AppendCube(ref vertices, ref triangles, posX, posY, posZ, size, size, size);
		}

		public static void ToMesh(ref Mesh mesh, ref List<Vector3> vertices, ref List<int> triangles, List<Color> colors, List<Vector2> uvs)
		{
			if (mesh == null)
			{
				Log.Error("Given mesh cannot be null.", "C:\\GIT\\dev\\Assets\\Scripts\\Tools\\MeshDataUtils.cs");
				return;
			}
			mesh.vertices = vertices.ToArray();
			mesh.triangles = triangles.ToArray();
			if (colors != null)
			{
				mesh.colors = colors.ToArray();
			}
			if (uvs != null)
			{
				mesh.SetUVs(0, uvs);
			}
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			mesh.RecalculateBounds();
		}

		public static Mesh ToMesh(ref List<Vector3> vertices, ref List<int> triangles, ref List<Color> colors, ref List<Vector2> uvs)
		{
			Mesh mesh = new Mesh();
			ToMesh(ref mesh, ref vertices, ref triangles, colors, uvs);
			return mesh;
		}

		public static Mesh ToMesh(ref List<Vector3> vertices, ref List<int> triangles)
		{
			Mesh mesh = new Mesh();
			ToMesh(ref mesh, ref vertices, ref triangles, null, null);
			return mesh;
		}

		public static void FromMesh(Mesh mesh, out List<Vector3> vertices, out List<int> triangles, out List<Color> colors, out List<Vector2> uvs)
		{
			vertices = new List<Vector3>();
			triangles = new List<int>();
			colors = new List<Color>();
			uvs = new List<Vector2>();
			mesh.GetVertices(vertices);
			mesh.GetColors(colors);
			mesh.GetUVs(0, uvs);
			triangles.AddRange(mesh.GetTriangles(0));
		}

		public static void ScaleMesh(ref List<Vector3> verts, Vector3 scale)
		{
			for (int i = 0; i < verts.Count; i++)
			{
				verts[i] = new Vector3(verts[i].x * scale.x, verts[i].y * scale.y, verts[i].z * scale.z);
			}
		}
	}
}
