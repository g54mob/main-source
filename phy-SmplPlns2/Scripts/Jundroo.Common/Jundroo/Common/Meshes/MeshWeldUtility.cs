using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Common.Meshes
{
	public static class MeshWeldUtility
	{
		private struct VertexKey : IEquatable<VertexKey>
		{
			private const byte FLAG_COLOR = 4;

			private const byte FLAG_NORMAL = 1;

			private const byte FLAG_UV = 2;

			private readonly byte flags;

			private readonly int px;

			private readonly int py;

			private readonly int pz;

			private readonly int nx;

			private readonly int ny;

			private readonly int nz;

			private readonly int ux;

			private readonly int uy;

			private readonly int cx;

			private readonly int cy;

			private readonly int cz;

			private readonly int cw;

			public VertexKey(Vector3 pos, Vector3 normal, Vector2 uv, Color color, float tolerance, bool hasNormal, bool hasUV, bool hasColor)
			{
				flags = 0;
				if (hasNormal)
				{
					flags |= 1;
				}
				if (hasUV)
				{
					flags |= 2;
				}
				if (hasColor)
				{
					flags |= 4;
				}
				if (tolerance <= 0f)
				{
					px = FloatToIntBits(pos.x);
					py = FloatToIntBits(pos.y);
					pz = FloatToIntBits(pos.z);
					nx = (hasNormal ? FloatToIntBits(normal.x) : 0);
					ny = (hasNormal ? FloatToIntBits(normal.y) : 0);
					nz = (hasNormal ? FloatToIntBits(normal.z) : 0);
					ux = (hasUV ? FloatToIntBits(uv.x) : 0);
					uy = (hasUV ? FloatToIntBits(uv.y) : 0);
					cx = (hasColor ? FloatToIntBits(color.r) : 0);
					cy = (hasColor ? FloatToIntBits(color.g) : 0);
					cz = (hasColor ? FloatToIntBits(color.b) : 0);
					cw = (hasColor ? FloatToIntBits(color.a) : 0);
				}
				else
				{
					float num = 1f / tolerance;
					px = Mathf.RoundToInt(pos.x * num);
					py = Mathf.RoundToInt(pos.y * num);
					pz = Mathf.RoundToInt(pos.z * num);
					nx = (hasNormal ? Mathf.RoundToInt(normal.x * num) : 0);
					ny = (hasNormal ? Mathf.RoundToInt(normal.y * num) : 0);
					nz = (hasNormal ? Mathf.RoundToInt(normal.z * num) : 0);
					ux = (hasUV ? Mathf.RoundToInt(uv.x * num) : 0);
					uy = (hasUV ? Mathf.RoundToInt(uv.y * num) : 0);
					cx = (hasColor ? Mathf.RoundToInt(color.r * num) : 0);
					cy = (hasColor ? Mathf.RoundToInt(color.g * num) : 0);
					cz = (hasColor ? Mathf.RoundToInt(color.b * num) : 0);
					cw = (hasColor ? Mathf.RoundToInt(color.a * num) : 0);
				}
			}

			public bool Equals(VertexKey other)
			{
				if (flags != other.flags)
				{
					return false;
				}
				if (px != other.px || py != other.py || pz != other.pz)
				{
					return false;
				}
				if ((flags & 1) != 0 && (nx != other.nx || ny != other.ny || nz != other.nz))
				{
					return false;
				}
				if ((flags & 2) != 0 && (ux != other.ux || uy != other.uy))
				{
					return false;
				}
				if ((flags & 4) != 0 && (cx != other.cx || cy != other.cy || cz != other.cz || cw != other.cw))
				{
					return false;
				}
				return true;
			}

			public override bool Equals(object obj)
			{
				if (obj is VertexKey other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				int num = 17;
				num = num * 23 + px;
				num = num * 23 + py;
				num = num * 23 + pz;
				num = num * 23 + flags;
				if ((flags & 1) != 0)
				{
					num = num * 23 + nx;
					num = num * 23 + ny;
					num = num * 23 + nz;
				}
				if ((flags & 2) != 0)
				{
					num = num * 23 + ux;
					num = num * 23 + uy;
				}
				if ((flags & 4) != 0)
				{
					num = num * 23 + cx;
					num = num * 23 + cy;
					num = num * 23 + cz;
					num = num * 23 + cw;
				}
				return num;
			}

			private static int FloatToIntBits(float f)
			{
				return BitConverter.SingleToInt32Bits(f);
			}
		}

		public static void Weld(Mesh mesh, float tolerance = 0f, bool includeNormals = true, bool includeUV = true, bool includeColors = false)
		{
			if (mesh == null)
			{
				throw new ArgumentNullException("mesh");
			}
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			Vector2[] uv = mesh.uv;
			Color[] colors = mesh.colors;
			Vector4[] tangents = mesh.tangents;
			BoneWeight[] boneWeights = mesh.boneWeights;
			bool flag = normals != null && normals.Length == vertices.Length && includeNormals;
			bool flag2 = uv != null && uv.Length == vertices.Length && includeUV;
			bool flag3 = colors != null && colors.Length == vertices.Length && includeColors;
			bool flag4 = tangents != null && tangents.Length == vertices.Length;
			bool flag5 = boneWeights != null && boneWeights.Length == vertices.Length;
			List<Vector3> list = new List<Vector3>(vertices.Length);
			List<Vector3> list2 = (flag ? new List<Vector3>(vertices.Length) : null);
			List<Vector2> list3 = (flag2 ? new List<Vector2>(vertices.Length) : null);
			List<Color> list4 = (flag3 ? new List<Color>(vertices.Length) : null);
			List<Vector4> list5 = (flag4 ? new List<Vector4>(vertices.Length) : null);
			List<BoneWeight> list6 = (flag5 ? new List<BoneWeight>(vertices.Length) : null);
			int[] array = new int[vertices.Length];
			Dictionary<VertexKey, int> dictionary = new Dictionary<VertexKey, int>(vertices.Length);
			for (int i = 0; i < vertices.Length; i++)
			{
				VertexKey key = new VertexKey(vertices[i], flag ? normals[i] : default(Vector3), flag2 ? uv[i] : default(Vector2), flag3 ? colors[i] : default(Color), tolerance, flag, flag2, flag3);
				if (dictionary.TryGetValue(key, out var value))
				{
					array[i] = value;
					continue;
				}
				int count = list.Count;
				dictionary.Add(key, count);
				array[i] = count;
				list.Add(vertices[i]);
				if (flag)
				{
					list2.Add(normals[i]);
				}
				if (flag2)
				{
					list3.Add(uv[i]);
				}
				if (flag3)
				{
					list4.Add(colors[i]);
				}
				if (flag4)
				{
					list5.Add(tangents[i]);
				}
				if (flag5)
				{
					list6.Add(boneWeights[i]);
				}
			}
			int subMeshCount = mesh.subMeshCount;
			List<int>[] array2 = new List<int>[subMeshCount];
			for (int j = 0; j < subMeshCount; j++)
			{
				int[] triangles = mesh.GetTriangles(j);
				List<int> list7 = new List<int>(triangles.Length);
				foreach (int num in triangles)
				{
					list7.Add(array[num]);
				}
				array2[j] = list7;
			}
			mesh.Clear();
			mesh.SetVertices(list);
			if (flag)
			{
				mesh.SetNormals(list2);
			}
			if (flag2)
			{
				mesh.SetUVs(0, list3);
			}
			if (flag3)
			{
				mesh.SetColors(list4);
			}
			if (flag4)
			{
				mesh.SetTangents(list5);
			}
			if (flag5)
			{
				mesh.boneWeights = list6.ToArray();
			}
			mesh.subMeshCount = subMeshCount;
			for (int l = 0; l < subMeshCount; l++)
			{
				mesh.SetTriangles(array2[l], l);
			}
			mesh.RecalculateBounds();
		}
	}
}
