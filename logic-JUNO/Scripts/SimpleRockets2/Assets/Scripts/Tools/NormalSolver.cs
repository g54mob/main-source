using System;
using System.Collections.Generic;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Tools
{
	public static class NormalSolver
	{
		public enum Options
		{
			None = 0,
			FlattenTop = 1,
			FlattenBottom = 2
		}

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

		private static Vector3[] _faceNormals;

		private static VertexEntry[] _vertexEntryPool;

		static NormalSolver()
		{
			ResetCacheData();
		}

		public static void RecalculateNormals(Mesh mesh, float angle, Options options = Options.None)
		{
			int[] triangles = mesh.triangles;
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = new Vector3[vertices.Length];
			RecalculateNormals(angle, triangles, vertices, normals, null, null, options);
			mesh.normals = normals;
		}

		public static void RecalculateNormals(float angle, int[] triangles, Vector3[] vertices, Vector3[] normals, Vector2[] uvs, Vector3[] originalNormals, Options options = Options.None)
		{
			int num = vertices.Length;
			int num2 = triangles.Length / 3;
			int num3 = 0;
			if (num2 != _faceNormals.Length)
			{
				_faceNormals = new Vector3[num2];
			}
			if (_vertexEntryPool.Length < num)
			{
				int num4 = _vertexEntryPool.Length;
				Array.Resize(ref _vertexEntryPool, num);
				for (int i = num4; i < num; i++)
				{
					_vertexEntryPool[i] = new VertexEntry();
				}
			}
			for (int j = 0; j < triangles.Length; j += 3)
			{
				int num5 = triangles[j];
				int num6 = triangles[j + 1];
				int num7 = triangles[j + 2];
				Vector3 lhs = vertices[num6] - vertices[num5];
				Vector3 rhs = vertices[num7] - vertices[num5];
				Vector3 normalized = Vector3.Cross(lhs, rhs).normalized;
				int num8 = j / 3;
				_faceNormals[num8] = normalized;
				VertexEntry value;
				if (uvs == null || uvs.Length <= num5 || (double)uvs[num5].x > -0.5)
				{
					Dictionary<VertexKey, VertexEntry> dictionary = _dictionary;
					VertexKey key = new VertexKey(vertices[num5]);
					if (!dictionary.TryGetValue(key, out value))
					{
						value = _vertexEntryPool[num3++];
						value.Count = 0;
						_dictionary.Add(key, value);
					}
					value.Add(num5, num8);
				}
				else
				{
					normals[num5] = originalNormals[num5];
				}
				if (uvs == null || uvs.Length <= num6 || (double)uvs[num6].x > -0.5)
				{
					Dictionary<VertexKey, VertexEntry> dictionary2 = _dictionary;
					VertexKey key = new VertexKey(vertices[num6]);
					if (!dictionary2.TryGetValue(key, out value))
					{
						value = _vertexEntryPool[num3++];
						value.Count = 0;
						_dictionary.Add(key, value);
					}
					value.Add(num6, num8);
				}
				else
				{
					normals[num6] = originalNormals[num6];
				}
				if (uvs == null || uvs.Length <= num7 || (double)uvs[num7].x > -0.5)
				{
					Dictionary<VertexKey, VertexEntry> dictionary3 = _dictionary;
					VertexKey key = new VertexKey(vertices[num7]);
					if (!dictionary3.TryGetValue(key, out value))
					{
						value = _vertexEntryPool[num3++];
						value.Count = 0;
						_dictionary.Add(key, value);
					}
					value.Add(num7, num8);
				}
				else
				{
					normals[num7] = originalNormals[num7];
				}
			}
			angle *= MathF.PI / 180f;
			bool flag = (options & Options.FlattenTop) > Options.None;
			bool flag2 = (options & Options.FlattenBottom) > Options.None;
			float num9 = -9999f;
			float num10 = 9999f;
			for (int k = 0; k < vertices.Length; k++)
			{
				float y = vertices[k].y;
				num9 = Mathf.Max(y, num9);
				num10 = Mathf.Min(y, num10);
			}
			foreach (VertexEntry value2 in _dictionary.Values)
			{
				for (int l = 0; l < value2.Count; l++)
				{
					int num11 = value2.VertexIndex[l];
					bool flag3 = Utilities.CompareFloats(vertices[num11].y, num9, 0.01f);
					bool flag4 = Utilities.CompareFloats(vertices[num11].y, num10, 0.01f);
					bool flag5 = Mathf.Approximately(Vector3.Dot(_faceNormals[value2.TriangleIndex[l]], new Vector3(1f, 0f, 1f)), 0f);
					Vector3 vector = default(Vector3);
					for (int m = 0; m < value2.Count; m++)
					{
						if (num11 == value2.VertexIndex[m])
						{
							vector += _faceNormals[value2.TriangleIndex[m]];
							continue;
						}
						bool flag6 = Mathf.Approximately(Vector3.Dot(_faceNormals[value2.TriangleIndex[m]], new Vector3(1f, 0f, 1f)), 0f);
						if ((flag5 == flag6 || ((!flag3 || flag) && (!flag4 || flag2))) && Mathf.Acos(Mathf.Clamp(Vector3.Dot(_faceNormals[value2.TriangleIndex[l]], _faceNormals[value2.TriangleIndex[m]]), -0.99999f, 0.99999f)) <= angle)
						{
							vector += _faceNormals[value2.TriangleIndex[m]];
						}
					}
					if (((flag && flag3) || (flag2 && flag4)) && Mathf.Abs(normals[num11].y) < 0.9f)
					{
						vector.y = 0f;
					}
					if (vector.x == 0f && vector.y == 0f && vector.z == 0f)
					{
						vector = Vector3.up;
					}
					else
					{
						vector.Normalize();
					}
					normals[num11] = vector;
				}
			}
			_dictionary.Clear();
		}

		private static void ResetCacheData()
		{
			_faceNormals = new Vector3[0];
			_vertexEntryPool = new VertexEntry[0];
			_dictionary = new Dictionary<VertexKey, VertexEntry>();
		}
	}
}
