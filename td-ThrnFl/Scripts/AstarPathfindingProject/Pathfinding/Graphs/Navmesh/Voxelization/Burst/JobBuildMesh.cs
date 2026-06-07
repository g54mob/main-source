using System;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile]
	public struct JobBuildMesh : IJob
	{
		public NativeList<int> contourVertices;

		public NativeList<VoxelContour> contours;

		public VoxelMesh mesh;

		public CompactVoxelField field;

		private static bool Diagonal(int i, int j, int n, NativeArray<int> verts, NativeArray<int> indices)
		{
			if (InCone(i, j, n, verts, indices))
			{
				return Diagonalie(i, j, n, verts, indices);
			}
			return false;
		}

		private static bool InCone(int i, int j, int n, NativeArray<int> verts, NativeArray<int> indices)
		{
			int num = (indices[i] & 0xFFFFFFF) * 3;
			int num2 = (indices[j] & 0xFFFFFFF) * 3;
			int c = (indices[Next(i, n)] & 0xFFFFFFF) * 3;
			int num3 = (indices[Prev(i, n)] & 0xFFFFFFF) * 3;
			if (LeftOn(num3, num, c, verts))
			{
				if (Left(num, num2, num3, verts))
				{
					return Left(num2, num, c, verts);
				}
				return false;
			}
			if (LeftOn(num, num2, c, verts))
			{
				return !LeftOn(num2, num, num3, verts);
			}
			return true;
		}

		private static bool Left(int a, int b, int c, NativeArray<int> verts)
		{
			return Area2(a, b, c, verts) < 0;
		}

		private static bool LeftOn(int a, int b, int c, NativeArray<int> verts)
		{
			return Area2(a, b, c, verts) <= 0;
		}

		private static bool Collinear(int a, int b, int c, NativeArray<int> verts)
		{
			return Area2(a, b, c, verts) == 0;
		}

		public static int Area2(int a, int b, int c, NativeArray<int> verts)
		{
			return (verts[b] - verts[a]) * (verts[c + 2] - verts[a + 2]) - (verts[c] - verts[a]) * (verts[b + 2] - verts[a + 2]);
		}

		private static bool Diagonalie(int i, int j, int n, NativeArray<int> verts, NativeArray<int> indices)
		{
			int a = (indices[i] & 0xFFFFFFF) * 3;
			int num = (indices[j] & 0xFFFFFFF) * 3;
			for (int k = 0; k < n; k++)
			{
				int num2 = Next(k, n);
				if (k != i && num2 != i && k != j && num2 != j)
				{
					int num3 = (indices[k] & 0xFFFFFFF) * 3;
					int num4 = (indices[num2] & 0xFFFFFFF) * 3;
					if (!Vequal(a, num3, verts) && !Vequal(num, num3, verts) && !Vequal(a, num4, verts) && !Vequal(num, num4, verts) && Intersect(a, num, num3, num4, verts))
					{
						return false;
					}
				}
			}
			return true;
		}

		private static bool Xorb(bool x, bool y)
		{
			return !x ^ !y;
		}

		private static bool IntersectProp(int a, int b, int c, int d, NativeArray<int> verts)
		{
			if (Collinear(a, b, c, verts) || Collinear(a, b, d, verts) || Collinear(c, d, a, verts) || Collinear(c, d, b, verts))
			{
				return false;
			}
			if (Xorb(Left(a, b, c, verts), Left(a, b, d, verts)))
			{
				return Xorb(Left(c, d, a, verts), Left(c, d, b, verts));
			}
			return false;
		}

		private static bool Between(int a, int b, int c, NativeArray<int> verts)
		{
			if (!Collinear(a, b, c, verts))
			{
				return false;
			}
			if (verts[a] != verts[b])
			{
				if (verts[a] > verts[c] || verts[c] > verts[b])
				{
					if (verts[a] >= verts[c])
					{
						return verts[c] >= verts[b];
					}
					return false;
				}
				return true;
			}
			if (verts[a + 2] > verts[c + 2] || verts[c + 2] > verts[b + 2])
			{
				if (verts[a + 2] >= verts[c + 2])
				{
					return verts[c + 2] >= verts[b + 2];
				}
				return false;
			}
			return true;
		}

		private static bool Intersect(int a, int b, int c, int d, NativeArray<int> verts)
		{
			if (IntersectProp(a, b, c, d, verts))
			{
				return true;
			}
			if (Between(a, b, c, verts) || Between(a, b, d, verts) || Between(c, d, a, verts) || Between(c, d, b, verts))
			{
				return true;
			}
			return false;
		}

		private static bool Vequal(int a, int b, NativeArray<int> verts)
		{
			if (verts[a] == verts[b])
			{
				return verts[a + 2] == verts[b + 2];
			}
			return false;
		}

		private static int Prev(int i, int n)
		{
			if (i - 1 < 0)
			{
				return n - 1;
			}
			return i - 1;
		}

		private static int Next(int i, int n)
		{
			if (i + 1 >= n)
			{
				return 0;
			}
			return i + 1;
		}

		private static int AddVertex(NativeList<Int3> vertices, NativeHashMap<Int3, int> vertexMap, Int3 vertex)
		{
			if (vertexMap.TryGetValue(vertex, out var item))
			{
				return item;
			}
			vertices.AddNoResize(vertex);
			vertexMap.Add(vertex, vertices.Length - 1);
			return vertices.Length - 1;
		}

		public void Execute()
		{
			int num = 3;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < contours.Length; i++)
			{
				if (contours[i].nverts >= 3)
				{
					num2 += contours[i].nverts;
					num3 += contours[i].nverts - 2;
					num4 = Math.Max(num4, contours[i].nverts);
				}
			}
			mesh.verts.Clear();
			if (num2 > mesh.verts.Capacity)
			{
				mesh.verts.SetCapacity(num2);
			}
			mesh.tris.ResizeUninitialized(num3 * num);
			mesh.areas.ResizeUninitialized(num3);
			NativeList<Int3> verts = mesh.verts;
			NativeList<int> tris = mesh.tris;
			NativeList<int> areas = mesh.areas;
			NativeArray<int> indices = new NativeArray<int>(num4, Allocator.Temp);
			NativeArray<int> tris2 = new NativeArray<int>(num4 * 3, Allocator.Temp);
			NativeArray<bool> verticesToRemove = new NativeArray<bool>(num2, Allocator.Temp);
			NativeHashMap<Int3, int> vertexMap = new NativeHashMap<Int3, int>(num2, Allocator.Temp);
			int num5 = 0;
			int num6 = 0;
			for (int j = 0; j < contours.Length; j++)
			{
				VoxelContour voxelContour = contours[j];
				if (voxelContour.nverts >= 3)
				{
					for (int k = 0; k < voxelContour.nverts; k++)
					{
						contourVertices[voxelContour.vertexStartIndex + k * 4 + 2] /= field.width;
					}
					for (int l = 0; l < voxelContour.nverts; l++)
					{
						int num7 = contourVertices[voxelContour.vertexStartIndex + l * 4 + 3];
						int index = (indices[l] = AddVertex(verts, vertexMap, new Int3(contourVertices[voxelContour.vertexStartIndex + l * 4], contourVertices[voxelContour.vertexStartIndex + l * 4 + 1], contourVertices[voxelContour.vertexStartIndex + l * 4 + 2])));
						verticesToRemove[index] = (num7 & 0x10000) != 0;
					}
					int num9 = Triangulate(voxelContour.nverts, verts.AsArray().Reinterpret<int>(12), indices, tris2);
					if (num9 < 0)
					{
						num9 = -num9;
					}
					for (int m = 0; m < num9 * 3; m++)
					{
						tris[num5] = tris2[m];
						num5++;
					}
					for (int n = 0; n < num9; n++)
					{
						areas[num6] = voxelContour.area;
						num6++;
					}
				}
			}
			mesh.tris.ResizeUninitialized(num5);
			mesh.areas.ResizeUninitialized(num6);
			RemoveTileBorderVertices(ref mesh, verticesToRemove);
		}

		private void RemoveTileBorderVertices(ref VoxelMesh mesh, NativeArray<bool> verticesToRemove)
		{
			NativeArray<byte> arr = new NativeArray<byte>(mesh.verts.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int num = mesh.verts.Length - 1; num >= 0; num--)
			{
				if (verticesToRemove[num] && CanRemoveVertex(ref mesh, num, arr.AsUnsafeSpan()))
				{
					RemoveVertex(ref mesh, num);
				}
			}
		}

		private bool CanRemoveVertex(ref VoxelMesh mesh, int vertexToRemove, UnsafeSpan<byte> vertexScratch)
		{
			int num = 0;
			for (int i = 0; i < mesh.tris.Length; i += 3)
			{
				int num2 = 0;
				for (int j = 0; j < 3; j++)
				{
					if (mesh.tris[i + j] == vertexToRemove)
					{
						num2++;
					}
				}
				if (num2 > 0)
				{
					if (num2 > 1)
					{
						throw new Exception("Degenerate triangle. This should have already been removed.");
					}
					num++;
				}
			}
			if (num <= 2)
			{
				return false;
			}
			vertexScratch.FillZeros();
			for (int k = 0; k < mesh.tris.Length; k += 3)
			{
				int num3 = 0;
				int num4 = 2;
				while (num3 < 3)
				{
					if (mesh.tris[k + num3] == vertexToRemove || mesh.tris[k + num4] == vertexToRemove)
					{
						int num5 = mesh.tris[k + num3];
						int num6 = mesh.tris[k + num4];
						vertexScratch[(num6 == vertexToRemove) ? num5 : num6]++;
					}
					num4 = num3++;
				}
			}
			int num7 = 0;
			for (int l = 0; l < vertexScratch.Length; l++)
			{
				if (vertexScratch[l] == 1)
				{
					num7++;
				}
			}
			return num7 <= 2;
		}

		private void RemoveVertex(ref VoxelMesh mesh, int vertexToRemove)
		{
			NativeList<int> nativeList = new NativeList<int>(16, Allocator.Temp);
			int value = -1;
			for (int i = 0; i < mesh.tris.Length; i += 3)
			{
				int num = -1;
				for (int j = 0; j < 3; j++)
				{
					if (mesh.tris[i + j] == vertexToRemove)
					{
						num = j;
						break;
					}
				}
				if (num != -1)
				{
					value = mesh.areas[i / 3];
					nativeList.Add(mesh.tris[i + (num + 1) % 3]);
					nativeList.Add(mesh.tris[i + (num + 2) % 3]);
					mesh.tris[i] = mesh.tris[mesh.tris.Length - 3];
					mesh.tris[i + 1] = mesh.tris[mesh.tris.Length - 3 + 1];
					mesh.tris[i + 2] = mesh.tris[mesh.tris.Length - 3 + 2];
					mesh.tris.Length -= 3;
					mesh.areas.RemoveAtSwapBack(i / 3);
					i -= 3;
				}
			}
			NativeList<int> nativeList2 = new NativeList<int>(nativeList.Length / 2 + 1, Allocator.Temp);
			nativeList2.Add(nativeList[nativeList.Length - 2]);
			nativeList2.Add(nativeList[nativeList.Length - 1]);
			nativeList.Length -= 2;
			while (nativeList.Length > 0)
			{
				for (int num2 = nativeList.Length - 2; num2 >= 0; num2 -= 2)
				{
					int num3 = nativeList[num2];
					int num4 = nativeList[num2 + 1];
					bool flag = false;
					if (nativeList2[0] == num4)
					{
						nativeList2.InsertRange(0, 1);
						nativeList2[0] = num3;
						flag = true;
					}
					if (nativeList2[nativeList2.Length - 1] == num3)
					{
						nativeList2.AddNoResize(num4);
						flag = true;
					}
					if (flag)
					{
						nativeList[num2] = nativeList[nativeList.Length - 2];
						nativeList[num2 + 1] = nativeList[nativeList.Length - 1];
						nativeList.Length -= 2;
					}
				}
			}
			mesh.verts.RemoveAt(vertexToRemove);
			for (int k = 0; k < mesh.tris.Length; k++)
			{
				if (mesh.tris[k] > vertexToRemove)
				{
					mesh.tris[k]--;
				}
			}
			for (int l = 0; l < nativeList2.Length; l++)
			{
				if (nativeList2[l] > vertexToRemove)
				{
					nativeList2[l]--;
				}
			}
			int num5 = (nativeList2.Length - 2) * 3;
			int length = mesh.tris.Length;
			mesh.tris.Length += num5;
			int num6 = Triangulate(nativeList2.Length, mesh.verts.AsArray().Reinterpret<int>(12), nativeList2.AsArray(), mesh.tris.AsArray().GetSubArray(length, num5));
			if (num6 < 0)
			{
				num6 = -num6;
			}
			mesh.tris.ResizeUninitialized(length + num6 * 3);
			mesh.areas.AddReplicate(in value, num6);
		}

		private static int Triangulate(int n, NativeArray<int> verts, NativeArray<int> indices, NativeArray<int> tris)
		{
			int num = 0;
			NativeArray<int> nativeArray = tris;
			int num2 = 0;
			for (int i = 0; i < n; i++)
			{
				int num3 = Next(i, n);
				int j = Next(num3, n);
				if (Diagonal(i, j, n, verts, indices))
				{
					indices[num3] |= 1073741824;
				}
			}
			while (n > 3)
			{
				int num4 = int.MaxValue;
				int num5 = -1;
				for (int k = 0; k < n; k++)
				{
					int num6 = Next(k, n);
					if ((indices[num6] & 0x40000000) != 0)
					{
						int num7 = (indices[k] & 0xFFFFFFF) * 3;
						int num8 = (indices[Next(num6, n)] & 0xFFFFFFF) * 3;
						int num9 = verts[num8] - verts[num7];
						int num10 = verts[num8 + 2] - verts[num7 + 2];
						int num11 = num9 * num9 + num10 * num10;
						if (num11 < num4)
						{
							num4 = num11;
							num5 = k;
						}
					}
				}
				if (num5 == -1)
				{
					Debug.LogWarning("Degenerate triangles might have been generated.\nUsually this is not a problem, but if you have a static level, try to modify the graph settings slightly to avoid this edge case.");
					return -num;
				}
				int num12 = num5;
				int num13 = Next(num12, n);
				int index = Next(num13, n);
				nativeArray[num2] = indices[num12] & 0xFFFFFFF;
				num2++;
				nativeArray[num2] = indices[num13] & 0xFFFFFFF;
				num2++;
				nativeArray[num2] = indices[index] & 0xFFFFFFF;
				num2++;
				num++;
				n--;
				for (int l = num13; l < n; l++)
				{
					indices[l] = indices[l + 1];
				}
				if (num13 >= n)
				{
					num13 = 0;
				}
				num12 = Prev(num13, n);
				if (Diagonal(Prev(num12, n), num13, n, verts, indices))
				{
					indices[num12] |= 1073741824;
				}
				else
				{
					indices[num12] &= 268435455;
				}
				if (Diagonal(num12, Next(num13, n), n, verts, indices))
				{
					indices[num13] |= 1073741824;
				}
				else
				{
					indices[num13] &= 268435455;
				}
			}
			nativeArray[num2] = indices[0] & 0xFFFFFFF;
			num2++;
			nativeArray[num2] = indices[1] & 0xFFFFFFF;
			num2++;
			nativeArray[num2] = indices[2] & 0xFFFFFFF;
			num2++;
			return num + 1;
		}
	}
}
