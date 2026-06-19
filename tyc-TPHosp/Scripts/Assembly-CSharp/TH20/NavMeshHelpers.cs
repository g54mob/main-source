using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	public static class NavMeshHelpers
	{
		private class IntEqualityComparer : IEqualityComparer<int>
		{
			public bool Equals(int x, int y)
			{
				return x == y;
			}

			public int GetHashCode(int obj)
			{
				return obj.GetHashCode();
			}
		}

		private class Vector3EqualityComparer : IEqualityComparer<Vector3>
		{
			public bool Equals(Vector3 x, Vector3 y)
			{
				return x == y;
			}

			public int GetHashCode(Vector3 obj)
			{
				return obj.GetHashCode();
			}
		}

		private class IntIntKVPComparer : IEqualityComparer<KeyValuePair<int, int>>
		{
			public bool Equals(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
			{
				if (x.Key == y.Key)
				{
					return x.Value == y.Value;
				}
				return false;
			}

			private static int CombineHashCodes(int h1, int h2)
			{
				return ((h1 << 5) + h1) ^ h2;
			}

			public int GetHashCode(KeyValuePair<int, int> obj)
			{
				return CombineHashCodes(obj.Key.GetHashCode(), obj.Value.GetHashCode());
			}
		}

		public struct Edge
		{
			public int v1;

			public int v2;

			public Edge(int aV1, int aV2)
			{
				v1 = aV1;
				v2 = aV2;
			}
		}

		private static readonly IntEqualityComparer IntEqualityComparerInstance = new IntEqualityComparer();

		private static readonly Vector3EqualityComparer Vector3EqualityComparerInstance = new Vector3EqualityComparer();

		private static readonly Dictionary<int, int> IndexRemappingCache = new Dictionary<int, int>(IntEqualityComparerInstance);

		private static readonly Dictionary<Vector3, int> FirstVertexInstanceCache = new Dictionary<Vector3, int>(Vector3EqualityComparerInstance);

		private static readonly IntIntKVPComparer IntIntKVPComparerInstance = new IntIntKVPComparer();

		private static readonly Dictionary<KeyValuePair<int, int>, int> NeighbourEdgesCache = new Dictionary<KeyValuePair<int, int>, int>(IntIntKVPComparerInstance);

		private const int InvalidLabel = int.MaxValue;

		public static NavMeshAreaLookup BuildNavMeshAreaLookup(Vector3 worldOffset, float planeHeight)
		{
			NavMeshTriangulation navMeshTriangulation = UnityEngine.AI.NavMesh.CalculateTriangulation();
			int[] array = DeDuplicateEdges(RemoveVerticesNotOnPlane(navMeshTriangulation.indices, navMeshTriangulation.vertices, planeHeight), navMeshTriangulation.vertices);
			Vector3[] vertices = navMeshTriangulation.vertices;
			int[] array2 = CalculateConnectedComponentLabels(neighbours: CalculateNeighbours(array), numTriangles: array.Length / 3);
			DebugDrawNavMeshIslands(array, array2, vertices, worldOffset);
			return CreateNavMeshAreaLookup(array, vertices, array2);
		}

		private static int[] RemoveVerticesNotOnPlane(int[] indices, Vector3[] vertices, float planeHeight)
		{
			if (planeHeight <= 0f)
			{
				return indices;
			}
			List<int> list = new List<int>(indices.Length);
			for (int i = 0; i < indices.Length; i += 3)
			{
				int num = indices[i];
				if (vertices[num].y >= planeHeight)
				{
					list.Add(indices[i]);
					list.Add(indices[i + 1]);
					list.Add(indices[i + 2]);
				}
			}
			return list.ToArray();
		}

		public static int[] FixWindingOrder(int[] indices, Vector3[] vertices)
		{
			int num = indices.Length / 3;
			int[] array = new int[indices.Length];
			Array.Copy(indices, array, indices.Length);
			for (int i = 0; i < num; i++)
			{
				Vector3 vector = vertices[indices[i * 3]];
				Vector3 vector2 = vertices[indices[i * 3 + 1]];
				Vector3 vector3 = vertices[indices[i * 3 + 2]];
				Vector3 lhs = vector2 - vector;
				Vector3 rhs = vector3 - vector;
				if (CrossProductXZVector3(lhs, rhs) > 0f)
				{
					array[i * 3] = indices[i * 3 + 1];
					array[i * 3 + 1] = indices[i * 3];
				}
			}
			return array;
		}

		private static float CrossProductXZVector3(Vector3 lhs, Vector3 rhs)
		{
			return lhs.x * rhs.z - lhs.z * rhs.x;
		}

		private static int Bit(int a, int b)
		{
			return (a & (1 << b)) >> b;
		}

		private static Color IntegerToColour(int i, int a)
		{
			int num = Bit(i, 1) + Bit(i, 3) * 2 + 1;
			int num2 = Bit(i, 2) + Bit(i, 4) * 2 + 1;
			int num3 = Bit(i, 0) + Bit(i, 5) * 2 + 1;
			return new Color(1f - (float)num * 63f / 255f, (float)num2 * 63f / 255f, 1f - (float)num3 * 63f / 255f, a);
		}

		private static void DebugDrawNavMeshIslands(int[] indices, int[] labels, Vector3[] vertices, Vector3 offset)
		{
			if (DebugVars.ShowNavMeshUpdateDebug.Value)
			{
				for (int i = 0; i < indices.Length / 3; i++)
				{
					Color color = IntegerToColour(labels[i], 255);
					float duration = 2f;
					DebugDrawUtils.Line(vertices[indices[i * 3]] + offset, vertices[indices[i * 3 + 1]] + offset, color, duration);
					DebugDrawUtils.Line(vertices[indices[i * 3 + 1]] + offset, vertices[indices[i * 3 + 2]] + offset, color, duration);
					DebugDrawUtils.Line(vertices[indices[i * 3 + 2]] + offset, vertices[indices[i * 3]] + offset, color, duration);
				}
			}
		}

		private static void DebugWriteNavMeshIslandsToOBJFile(int[] indices, int[] labels, Vector3[] vertices, string path)
		{
			StreamWriter streamWriter = new StreamWriter(path);
			for (int i = 0; i < vertices.Length; i++)
			{
				streamWriter.Write("v {0} {1} {2}\n", vertices[i].x, vertices[i].y, vertices[i].z);
			}
			int num = indices.Length / 3;
			for (int j = 0; j < num; j++)
			{
				streamWriter.Write("o Island{0}\n", labels[j]);
				streamWriter.Write("f {0} {1} {2}\n", indices[j * 3] + 1, indices[j * 3 + 1] + 1, indices[j * 3 + 2] + 1);
			}
			streamWriter.Close();
		}

		public static int[] DeDuplicateEdges(int[] indices, Vector3[] vertices)
		{
			Dictionary<int, int> indexRemappingCache = IndexRemappingCache;
			Dictionary<Vector3, int> firstVertexInstanceCache = FirstVertexInstanceCache;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 key = RoundVectorToVeryClose(vertices[i]);
				if (firstVertexInstanceCache.TryGetValue(key, out var value))
				{
					indexRemappingCache[i] = value;
				}
				else
				{
					firstVertexInstanceCache.Add(key, i);
				}
			}
			int[] array = new int[indices.Length];
			Array.Copy(indices, array, indices.Length);
			for (int j = 0; j < indices.Length; j++)
			{
				if (indexRemappingCache.TryGetValue(indices[j], out var value2))
				{
					array[j] = value2;
				}
			}
			IndexRemappingCache.Clear();
			FirstVertexInstanceCache.Clear();
			return array;
		}

		private static Vector3 RoundVectorToVeryClose(Vector3 vec)
		{
			return new Vector3(Mathf.Round(vec.x * 1000f) / 1000f, Mathf.Round(vec.y * 1000f) / 1000f, Mathf.Round(vec.z * 1000f) / 1000f);
		}

		public static int[] CalculateNeighbours(int[] indices)
		{
			int num = indices.Length / 3;
			Dictionary<KeyValuePair<int, int>, int> neighbourEdgesCache = NeighbourEdgesCache;
			for (int i = 0; i < num; i++)
			{
				neighbourEdgesCache[new KeyValuePair<int, int>(indices[i * 3], indices[i * 3 + 1])] = i;
				neighbourEdgesCache[new KeyValuePair<int, int>(indices[i * 3 + 1], indices[i * 3 + 2])] = i;
				neighbourEdgesCache[new KeyValuePair<int, int>(indices[i * 3 + 2], indices[i * 3])] = i;
			}
			int[] array = new int[num * 3];
			for (int j = 0; j < num; j++)
			{
				if (!neighbourEdgesCache.TryGetValue(new KeyValuePair<int, int>(indices[j * 3 + 1], indices[j * 3]), out var value))
				{
					value = -1;
				}
				if (!neighbourEdgesCache.TryGetValue(new KeyValuePair<int, int>(indices[j * 3 + 2], indices[j * 3 + 1]), out var value2))
				{
					value2 = -1;
				}
				if (!neighbourEdgesCache.TryGetValue(new KeyValuePair<int, int>(indices[j * 3], indices[j * 3 + 2]), out var value3))
				{
					value3 = -1;
				}
				array[j * 3] = value;
				array[j * 3 + 1] = value2;
				array[j * 3 + 2] = value3;
			}
			NeighbourEdgesCache.Clear();
			return array;
		}

		public static int[] CalculateConnectedComponentLabels(int numTriangles, int[] neighbours)
		{
			int num = 1;
			int[] array = new int[numTriangles];
			ArrayUtils.Populate(array, int.MaxValue);
			DisjointSetOfInts disjointSetOfInts = new DisjointSetOfInts();
			for (int i = 0; i < numTriangles; i++)
			{
				int num2 = ((neighbours[i * 3] >= 0) ? array[neighbours[i * 3]] : int.MaxValue);
				int num3 = ((neighbours[i * 3 + 1] >= 0) ? array[neighbours[i * 3 + 1]] : int.MaxValue);
				int num4 = ((neighbours[i * 3 + 2] >= 0) ? array[neighbours[i * 3 + 2]] : int.MaxValue);
				int num5 = Math.Min(Math.Min(num2, num3), num4);
				if (num5 == int.MaxValue)
				{
					disjointSetOfInts.MakeSet(num);
					array[i] = num;
					num++;
					continue;
				}
				array[i] = num5;
				if (num2 != int.MaxValue)
				{
					disjointSetOfInts.Union(num5, num2);
				}
				if (num3 != int.MaxValue)
				{
					disjointSetOfInts.Union(num5, num3);
				}
				if (num4 != int.MaxValue)
				{
					disjointSetOfInts.Union(num5, num4);
				}
			}
			for (int j = 0; j < numTriangles; j++)
			{
				array[j] = disjointSetOfInts.Find(array[j]);
			}
			return array;
		}

		private static NavMeshAreaLookup CreateNavMeshAreaLookup(int[] indices, Vector3[] vertices, int[] islandIDs)
		{
			return new NavMeshAreaLookup(indices, vertices, islandIDs);
		}

		public static List<Edge> GetEdges(int[] aIndices)
		{
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < aIndices.Length; i += 3)
			{
				int num = aIndices[i];
				int num2 = aIndices[i + 1];
				int num3 = aIndices[i + 2];
				list.Add(new Edge(num, num2));
				list.Add(new Edge(num2, num3));
				list.Add(new Edge(num3, num));
			}
			return list;
		}

		public static List<Edge> FindBoundary(this List<Edge> aEdges)
		{
			List<Edge> list = new List<Edge>(aEdges);
			for (int num = list.Count - 1; num > 0; num--)
			{
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					if (list[num].v1 == list[num2].v2 && list[num].v2 == list[num2].v1)
					{
						list.RemoveAt(num);
						list.RemoveAt(num2);
						num--;
						break;
					}
				}
			}
			return list;
		}

		public static List<Edge> SortEdges(this List<Edge> aEdges)
		{
			List<Edge> list = new List<Edge>(aEdges);
			for (int i = 0; i < list.Count - 2; i++)
			{
				Edge edge = list[i];
				for (int j = i + 1; j < list.Count; j++)
				{
					Edge value = list[j];
					if (edge.v2 == value.v1)
					{
						if (j != i + 1)
						{
							list[j] = list[i + 1];
							list[i + 1] = value;
						}
						break;
					}
				}
			}
			return list;
		}
	}
}
