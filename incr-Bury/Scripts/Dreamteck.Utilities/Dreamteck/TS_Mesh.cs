using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dreamteck
{
	public class TS_Mesh
	{
		public Vector3[] vertices = new Vector3[0];

		public Vector3[] normals = new Vector3[0];

		public Vector4[] tangents = new Vector4[0];

		public Color[] colors = new Color[0];

		public Vector2[] uv = new Vector2[0];

		public Vector2[] uv2 = new Vector2[0];

		public Vector2[] uv3 = new Vector2[0];

		public Vector2[] uv4 = new Vector2[0];

		public int[] triangles = new int[0];

		public List<int[]> subMeshes = new List<int[]>();

		public TS_Bounds bounds = new TS_Bounds(Vector3.zero, Vector3.zero);

		public IndexFormat indexFormat;

		public volatile bool hasUpdate;

		private int[] _submeshTrisCount = new int[0];

		private int[] _submeshOffsets = new int[0];

		public int vertexCount
		{
			get
			{
				return vertices.Length;
			}
			set
			{
			}
		}

		public TS_Mesh()
		{
		}

		public TS_Mesh(Mesh mesh)
		{
			CreateFromMesh(mesh);
		}

		public void Clear()
		{
			vertices = new Vector3[0];
			normals = new Vector3[0];
			tangents = new Vector4[0];
			colors = new Color[0];
			uv = new Vector2[0];
			uv2 = new Vector2[0];
			uv3 = new Vector2[0];
			uv4 = new Vector2[0];
			triangles = new int[0];
			subMeshes = new List<int[]>();
			bounds = new TS_Bounds(Vector3.zero, Vector3.zero);
		}

		public void CreateFromMesh(Mesh mesh)
		{
			vertices = mesh.vertices;
			normals = mesh.normals;
			tangents = mesh.tangents;
			colors = mesh.colors;
			uv = mesh.uv;
			uv2 = mesh.uv2;
			uv3 = mesh.uv3;
			uv4 = mesh.uv4;
			triangles = mesh.triangles;
			bounds = new TS_Bounds(mesh.bounds);
			indexFormat = mesh.indexFormat;
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				subMeshes.Add(mesh.GetTriangles(i));
			}
		}

		public void Combine(List<TS_Mesh> combineMeshes)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < combineMeshes.Count; i++)
			{
				num += combineMeshes[i].vertices.Length;
				num2 += combineMeshes[i].triangles.Length;
				if (combineMeshes[i].subMeshes.Count > num3)
				{
					num3 = combineMeshes[i].subMeshes.Count;
				}
			}
			if (_submeshTrisCount.Length != num3)
			{
				_submeshTrisCount = new int[num3];
			}
			else
			{
				for (int j = 0; j < _submeshTrisCount.Length; j++)
				{
					_submeshTrisCount[j] = 0;
				}
			}
			for (int k = 0; k < combineMeshes.Count; k++)
			{
				for (int l = 0; l < combineMeshes[k].subMeshes.Count; l++)
				{
					_submeshTrisCount[l] += combineMeshes[k].subMeshes[l].Length;
				}
			}
			if (vertices.Length != num)
			{
				vertices = new Vector3[num];
			}
			if (normals.Length != num)
			{
				normals = new Vector3[num];
			}
			if (uv.Length != num)
			{
				uv = new Vector2[num];
			}
			if (uv2.Length != num)
			{
				uv2 = new Vector2[num];
			}
			if (uv3.Length != num)
			{
				uv3 = new Vector2[num];
			}
			if (uv4.Length != num)
			{
				uv4 = new Vector2[num];
			}
			if (colors.Length != num)
			{
				colors = new Color[num];
			}
			if (tangents.Length != num)
			{
				tangents = new Vector4[num];
			}
			if (triangles.Length != num2)
			{
				triangles = new int[num2];
			}
			if (subMeshes.Count > num3)
			{
				subMeshes.Clear();
			}
			int num4 = 0;
			int num5 = 0;
			if (_submeshOffsets.Length != num3)
			{
				_submeshOffsets = new int[num3];
			}
			else
			{
				for (int m = 0; m < _submeshOffsets.Length; m++)
				{
					_submeshOffsets[m] = 0;
				}
			}
			for (int n = 0; n < combineMeshes.Count; n++)
			{
				combineMeshes[n].vertices.CopyTo(vertices, num4);
				combineMeshes[n].normals.CopyTo(normals, num4);
				combineMeshes[n].uv.CopyTo(uv, num4);
				combineMeshes[n].uv2.CopyTo(uv2, num4);
				combineMeshes[n].uv3.CopyTo(uv3, num4);
				combineMeshes[n].uv4.CopyTo(uv4, num4);
				combineMeshes[n].colors.CopyTo(colors, num4);
				combineMeshes[n].tangents.CopyTo(tangents, num4);
				for (int num6 = 0; num6 < combineMeshes[n].triangles.Length; num6++)
				{
					int num7 = num6 + num5;
					triangles[num7] = combineMeshes[n].triangles[num6] + num4;
				}
				num5 += combineMeshes[n].triangles.Length;
				for (int num8 = 0; num8 < combineMeshes[n].subMeshes.Count; num8++)
				{
					if (num8 >= subMeshes.Count)
					{
						subMeshes.Add(new int[_submeshTrisCount[num8]]);
					}
					else if (subMeshes[num8].Length != _submeshTrisCount[num8])
					{
						subMeshes[num8] = new int[_submeshTrisCount[num8]];
					}
					int[] array = combineMeshes[n].subMeshes[num8];
					for (int num9 = 0; num9 < array.Length; num9++)
					{
						int num10 = _submeshOffsets[num8] + num9;
						subMeshes[num8][num10] = array[num9] + num4;
					}
					_submeshOffsets[num8] += array.Length;
				}
				num4 += combineMeshes[n].vertices.Length;
			}
		}

		public void AddMeshes(List<TS_Mesh> addedMeshes)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < addedMeshes.Count; i++)
			{
				num += addedMeshes[i].vertexCount;
				num2 += addedMeshes[i].triangles.Length;
				if (addedMeshes[i].subMeshes.Count > num3)
				{
					num3 = addedMeshes[i].subMeshes.Count;
				}
			}
			int[] array = new int[num3];
			_ = new int[num3];
			for (int j = 0; j < addedMeshes.Count; j++)
			{
				for (int k = 0; k < addedMeshes[j].subMeshes.Count; k++)
				{
					array[k] += addedMeshes[j].subMeshes[k].Length;
				}
			}
			Vector3[] array2 = new Vector3[vertices.Length + num];
			Vector3[] array3 = new Vector3[vertices.Length + num];
			Vector2[] array4 = new Vector2[vertices.Length + num];
			Vector2[] array5 = new Vector2[vertices.Length + num];
			Vector2[] array6 = new Vector2[vertices.Length + num];
			Vector2[] array7 = new Vector2[vertices.Length + num];
			Color[] array8 = new Color[vertices.Length + num];
			Vector4[] array9 = new Vector4[tangents.Length + num];
			int[] array10 = new int[triangles.Length + num2];
			List<int[]> list = new List<int[]>();
			for (int l = 0; l < array.Length; l++)
			{
				list.Add(new int[array[l]]);
				if (l < subMeshes.Count)
				{
					array[l] = subMeshes[l].Length;
				}
				else
				{
					array[l] = 0;
				}
			}
			num = vertexCount;
			num2 = triangles.Length;
			vertices.CopyTo(array2, 0);
			normals.CopyTo(array3, 0);
			uv.CopyTo(array4, 0);
			uv2.CopyTo(array5, 0);
			uv3.CopyTo(array6, 0);
			uv4.CopyTo(array7, 0);
			colors.CopyTo(array8, 0);
			tangents.CopyTo(array9, 0);
			triangles.CopyTo(array10, 0);
			for (int m = 0; m < addedMeshes.Count; m++)
			{
				addedMeshes[m].vertices.CopyTo(array2, num);
				addedMeshes[m].normals.CopyTo(array3, num);
				addedMeshes[m].uv.CopyTo(array4, num);
				addedMeshes[m].uv2.CopyTo(array5, num);
				addedMeshes[m].uv3.CopyTo(array6, num);
				addedMeshes[m].uv4.CopyTo(array7, num);
				addedMeshes[m].colors.CopyTo(array8, num);
				addedMeshes[m].tangents.CopyTo(array9, num);
				for (int n = num2; n < num2 + addedMeshes[m].triangles.Length; n++)
				{
					array10[n] = addedMeshes[m].triangles[n - num2] + num;
				}
				for (int num4 = 0; num4 < addedMeshes[m].subMeshes.Count; num4++)
				{
					for (int num5 = array[num4]; num5 < array[num4] + addedMeshes[m].subMeshes[num4].Length; num5++)
					{
						list[num4][num5] = addedMeshes[m].subMeshes[num4][num5 - array[num4]] + num;
					}
					array[num4] += addedMeshes[m].subMeshes[num4].Length;
				}
				num2 += addedMeshes[m].triangles.Length;
				num += addedMeshes[m].vertexCount;
			}
			vertices = array2;
			normals = array3;
			uv = array4;
			uv2 = array5;
			uv3 = array6;
			uv4 = array7;
			colors = array8;
			tangents = array9;
			triangles = array10;
			subMeshes = list;
		}

		public static TS_Mesh Copy(TS_Mesh input)
		{
			TS_Mesh tS_Mesh = new TS_Mesh();
			tS_Mesh.vertices = new Vector3[input.vertices.Length];
			input.vertices.CopyTo(tS_Mesh.vertices, 0);
			tS_Mesh.normals = new Vector3[input.normals.Length];
			input.normals.CopyTo(tS_Mesh.normals, 0);
			tS_Mesh.uv = new Vector2[input.uv.Length];
			input.uv.CopyTo(tS_Mesh.uv, 0);
			tS_Mesh.uv2 = new Vector2[input.uv2.Length];
			input.uv2.CopyTo(tS_Mesh.uv2, 0);
			tS_Mesh.uv3 = new Vector2[input.uv3.Length];
			input.uv3.CopyTo(tS_Mesh.uv3, 0);
			tS_Mesh.uv4 = new Vector2[input.uv4.Length];
			input.uv4.CopyTo(tS_Mesh.uv4, 0);
			tS_Mesh.colors = new Color[input.colors.Length];
			input.colors.CopyTo(tS_Mesh.colors, 0);
			tS_Mesh.tangents = new Vector4[input.tangents.Length];
			input.tangents.CopyTo(tS_Mesh.tangents, 0);
			tS_Mesh.triangles = new int[input.triangles.Length];
			input.triangles.CopyTo(tS_Mesh.triangles, 0);
			tS_Mesh.subMeshes = new List<int[]>();
			for (int i = 0; i < input.subMeshes.Count; i++)
			{
				tS_Mesh.subMeshes.Add(new int[input.subMeshes[i].Length]);
				input.subMeshes[i].CopyTo(tS_Mesh.subMeshes[i], 0);
			}
			tS_Mesh.bounds = new TS_Bounds(input.bounds.center, input.bounds.size);
			tS_Mesh.indexFormat = input.indexFormat;
			return tS_Mesh;
		}

		public void Absorb(TS_Mesh input)
		{
			if (vertices.Length != input.vertexCount)
			{
				vertices = new Vector3[input.vertexCount];
			}
			if (normals.Length != input.normals.Length)
			{
				normals = new Vector3[input.normals.Length];
			}
			if (colors.Length != input.colors.Length)
			{
				colors = new Color[input.colors.Length];
			}
			if (uv.Length != input.uv.Length)
			{
				uv = new Vector2[input.uv.Length];
			}
			if (uv2.Length != input.uv2.Length)
			{
				uv2 = new Vector2[input.uv2.Length];
			}
			if (uv3.Length != input.uv3.Length)
			{
				uv3 = new Vector2[input.uv3.Length];
			}
			if (uv4.Length != input.uv4.Length)
			{
				uv4 = new Vector2[input.uv4.Length];
			}
			if (tangents.Length != input.tangents.Length)
			{
				tangents = new Vector4[input.tangents.Length];
			}
			if (triangles.Length != input.triangles.Length)
			{
				triangles = new int[input.triangles.Length];
			}
			input.vertices.CopyTo(vertices, 0);
			input.normals.CopyTo(normals, 0);
			input.colors.CopyTo(colors, 0);
			input.uv.CopyTo(uv, 0);
			input.uv2.CopyTo(uv2, 0);
			input.uv3.CopyTo(uv3, 0);
			input.uv4.CopyTo(uv4, 0);
			input.tangents.CopyTo(tangents, 0);
			input.triangles.CopyTo(triangles, 0);
			if (subMeshes.Count == input.subMeshes.Count)
			{
				for (int i = 0; i < subMeshes.Count; i++)
				{
					if (input.subMeshes[i].Length != subMeshes[i].Length)
					{
						subMeshes[i] = new int[input.subMeshes[i].Length];
					}
					input.subMeshes[i].CopyTo(subMeshes[i], 0);
				}
			}
			else
			{
				subMeshes = new List<int[]>();
				for (int j = 0; j < input.subMeshes.Count; j++)
				{
					subMeshes.Add(new int[input.subMeshes[j].Length]);
					input.subMeshes[j].CopyTo(subMeshes[j], 0);
				}
			}
			bounds = new TS_Bounds(input.bounds.center, input.bounds.size);
		}

		public void WriteMesh(ref Mesh input)
		{
			if (input == null)
			{
				input = new Mesh();
			}
			input.Clear();
			input.indexFormat = indexFormat;
			input.vertices = vertices;
			input.normals = normals;
			if (tangents.Length == vertices.Length)
			{
				input.tangents = tangents;
			}
			if (colors.Length == vertices.Length)
			{
				input.colors = colors;
			}
			if (uv.Length == vertices.Length)
			{
				input.uv = uv;
			}
			if (uv2.Length == vertices.Length)
			{
				input.uv2 = uv2;
			}
			if (uv3.Length == vertices.Length)
			{
				input.uv3 = uv3;
			}
			if (uv4.Length == vertices.Length)
			{
				input.uv4 = uv4;
			}
			input.triangles = triangles;
			if (subMeshes.Count > 0)
			{
				input.subMeshCount = subMeshes.Count;
				for (int i = 0; i < subMeshes.Count; i++)
				{
					input.SetTriangles(subMeshes[i], i);
				}
			}
			input.RecalculateBounds();
			hasUpdate = false;
		}
	}
}
