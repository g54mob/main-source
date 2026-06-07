using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Common.Meshes
{
	public static class NormalSolver
	{
		private struct VertexKey : IEquatable<VertexKey>
		{
			private const int Tolerance = 100000;

			private readonly int _hash;

			private readonly long _x;

			private readonly long _y;

			private readonly long _z;

			public VertexKey(Vector3 position)
			{
				_x = (long)Mathf.Round(position.x * 100000f);
				_y = (long)Mathf.Round(position.y * 100000f);
				_z = (long)Mathf.Round(position.z * 100000f);
				_hash = ((_x * 7) ^ (_y * 13) ^ (_z * 27)).GetHashCode();
			}

			public override bool Equals(object obj)
			{
				VertexKey vertexKey = (VertexKey)obj;
				if (_x == vertexKey._x && _y == vertexKey._y)
				{
					return _z == vertexKey._z;
				}
				return false;
			}

			public bool Equals(VertexKey other)
			{
				if (_x == other._x && _y == other._y)
				{
					return _z == other._z;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return _hash;
			}
		}

		private sealed class VertexEntry
		{
			public int Count;

			public int[] TriangleIndex = new int[4];

			public int[] VertexIndex = new int[4];

			private int _reserved = 4;

			public void Add(int vertIndex, int triIndex)
			{
				if (_reserved == Count)
				{
					_reserved *= 2;
					Array.Resize(ref TriangleIndex, _reserved);
					Array.Resize(ref VertexIndex, _reserved);
				}
				TriangleIndex[Count] = triIndex;
				VertexIndex[Count] = vertIndex;
				Count++;
			}
		}

		private static Dictionary<VertexKey, VertexEntry> _dictionary;

		private static VertexEntry[] _vertexEntryPool;

		static NormalSolver()
		{
			ResetCacheData();
		}

		public static void RecalculateNormals(Mesh mesh, float angle, int ignoreNormalsType)
		{
			angle *= MathF.PI / 180f;
			Vector3[] vertices = mesh.vertices;
			int num = vertices.Length;
			int[] triangles = mesh.triangles;
			Vector3[] array = new Vector3[triangles.Length / 3];
			Vector3[] array2 = new Vector3[num];
			Dictionary<VertexKey, VertexEntry> dictionary = _dictionary;
			dictionary.Clear();
			int num2 = 0;
			if (_vertexEntryPool.Length < num)
			{
				int num3 = _vertexEntryPool.Length;
				Array.Resize(ref _vertexEntryPool, num);
				for (int i = num3; i < num; i++)
				{
					_vertexEntryPool[i] = new VertexEntry();
				}
			}
			for (int j = 0; j < triangles.Length; j += 3)
			{
				int num4 = triangles[j];
				int num5 = triangles[j + 1];
				int num6 = triangles[j + 2];
				Vector3 lhs = vertices[num5] - vertices[num4];
				Vector3 rhs = vertices[num6] - vertices[num4];
				Vector3 normalized = Vector3.Cross(lhs, rhs).normalized;
				switch (ignoreNormalsType)
				{
				case 1:
					if (System.Math.Abs(Mathf.Abs(normalized.z) - 1f) <= 0.01f)
					{
						continue;
					}
					break;
				case 2:
					if (System.Math.Abs(normalized.z - 1f) <= 0.01f)
					{
						continue;
					}
					break;
				}
				int num7 = j / 3;
				array[num7] = normalized;
				VertexKey key = new VertexKey(vertices[num4]);
				if (!dictionary.TryGetValue(key, out var value))
				{
					value = _vertexEntryPool[num2++];
					value.Count = 0;
					dictionary.Add(key, value);
				}
				value.Add(num4, num7);
				key = new VertexKey(vertices[num5]);
				if (!dictionary.TryGetValue(key, out value))
				{
					value = _vertexEntryPool[num2++];
					value.Count = 0;
					dictionary.Add(key, value);
				}
				value.Add(num5, num7);
				key = new VertexKey(vertices[num6]);
				if (!dictionary.TryGetValue(key, out value))
				{
					value = _vertexEntryPool[num2++];
					value.Count = 0;
					dictionary.Add(key, value);
				}
				value.Add(num6, num7);
			}
			foreach (VertexEntry value2 in dictionary.Values)
			{
				for (int k = 0; k < value2.Count; k++)
				{
					Vector3 vector = default(Vector3);
					for (int l = 0; l < value2.Count; l++)
					{
						if (value2.VertexIndex[k] == value2.VertexIndex[l])
						{
							vector += array[value2.TriangleIndex[l]];
						}
						else if (Mathf.Acos(Mathf.Clamp(Vector3.Dot(array[value2.TriangleIndex[k]], array[value2.TriangleIndex[l]]), -0.99999f, 0.99999f)) <= angle)
						{
							vector += array[value2.TriangleIndex[l]];
						}
					}
					array2[value2.VertexIndex[k]] = vector.normalized;
				}
			}
			mesh.normals = array2;
		}

		private static void ResetCacheData()
		{
			_vertexEntryPool = new VertexEntry[0];
			_dictionary = new Dictionary<VertexKey, VertexEntry>();
		}
	}
}
