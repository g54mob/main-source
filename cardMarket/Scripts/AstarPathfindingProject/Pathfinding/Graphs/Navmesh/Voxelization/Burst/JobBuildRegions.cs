using System;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	public struct JobBuildRegions : IJob
	{
		public struct RelevantGraphSurfaceInfo
		{
			public float3 position;

			public float range;
		}

		public CompactVoxelField field;

		public NativeList<ushort> distanceField;

		public int borderSize;

		public int minRegionSize;

		public NativeQueue<Int3> srcQue;

		public NativeQueue<Int3> dstQue;

		public RecastGraph.RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		public NativeArray<RelevantGraphSurfaceInfo> relevantGraphSurfaces;

		public float cellSize;

		public float cellHeight;

		public Matrix4x4 graphTransform;

		public Bounds graphSpaceBounds;

		private void MarkRectWithRegion(int minx, int maxx, int minz, int maxz, ushort region, NativeArray<ushort> srcReg)
		{
			int num = maxz * field.width;
			for (int i = minz * field.width; i < num; i += field.width)
			{
				for (int j = minx; j < maxx; j++)
				{
					CompactVoxelCell compactVoxelCell = field.cells[i + j];
					int k = compactVoxelCell.index;
					for (int num2 = compactVoxelCell.index + compactVoxelCell.count; k < num2; k++)
					{
						if (field.areaTypes[k] != 0)
						{
							srcReg[k] = region;
						}
					}
				}
			}
		}

		public static bool FloodRegion(int x, int z, int i, uint level, ushort r, CompactVoxelField field, NativeArray<ushort> distanceField, NativeArray<ushort> srcReg, NativeArray<ushort> srcDist, NativeArray<Int3> stack, NativeArray<int> flags, NativeArray<bool> closed)
		{
			int num = field.areaTypes[i];
			int num2 = 1;
			stack[0] = new Int3
			{
				x = x,
				y = i,
				z = z
			};
			srcReg[i] = r;
			srcDist[i] = 0;
			int num3 = (int)((level >= 2) ? (level - 2) : 0);
			int num4 = 0;
			NativeList<CompactVoxelCell> cells = field.cells;
			NativeList<CompactVoxelSpan> spans = field.spans;
			NativeList<int> areaTypes = field.areaTypes;
			while (num2 > 0)
			{
				num2--;
				Int3 obj = stack[num2];
				int y = obj.y;
				int x2 = obj.x;
				int z2 = obj.z;
				CompactVoxelSpan compactVoxelSpan = spans[y];
				ushort num5 = 0;
				for (int j = 0; j < 4; j++)
				{
					if ((long)compactVoxelSpan.GetConnection(j) == 63)
					{
						continue;
					}
					int num6 = x2 + VoxelUtilityBurst.DX[j];
					int num7 = z2 + VoxelUtilityBurst.DZ[j] * field.width;
					int index = cells[num6 + num7].index + compactVoxelSpan.GetConnection(j);
					if (areaTypes[index] != num)
					{
						continue;
					}
					ushort num8 = srcReg[index];
					if ((num8 & 0x8000) == 32768)
					{
						continue;
					}
					if (num8 != 0 && num8 != r)
					{
						num5 = num8;
						break;
					}
					int num9 = (j + 1) & 3;
					int connection = spans[index].GetConnection(num9);
					if ((long)connection == 63)
					{
						continue;
					}
					int num10 = num6 + VoxelUtilityBurst.DX[num9];
					int num11 = num7 + VoxelUtilityBurst.DZ[num9] * field.width;
					int index2 = cells[num10 + num11].index + connection;
					if (areaTypes[index2] == num)
					{
						ushort num12 = srcReg[index2];
						if ((num12 & 0x8000) != 32768 && num12 != 0 && num12 != r)
						{
							num5 = num12;
							break;
						}
					}
				}
				if (num5 != 0)
				{
					srcReg[y] = 0;
					srcDist[y] = ushort.MaxValue;
					continue;
				}
				num4++;
				closed[y] = true;
				for (int k = 0; k < 4; k++)
				{
					if ((long)compactVoxelSpan.GetConnection(k) == 63)
					{
						continue;
					}
					int num13 = x2 + VoxelUtilityBurst.DX[k];
					int num14 = z2 + VoxelUtilityBurst.DZ[k] * field.width;
					int num15 = cells[num13 + num14].index + compactVoxelSpan.GetConnection(k);
					if (areaTypes[num15] == num && srcReg[num15] == 0)
					{
						if (distanceField[num15] >= num3 && flags[num15] == 0)
						{
							srcReg[num15] = r;
							srcDist[num15] = 0;
							stack[num2] = new Int3
							{
								x = num13,
								y = num15,
								z = num14
							};
							num2++;
						}
						else
						{
							flags[num15] = r;
							srcDist[num15] = 2;
						}
					}
				}
			}
			return num4 > 0;
		}

		public void Execute()
		{
			srcQue.Clear();
			dstQue.Clear();
			int width = field.width;
			int depth = field.depth;
			int num = width * depth;
			int length = field.spans.Length;
			int num2 = 8;
			NativeArray<ushort> nativeArray = new NativeArray<ushort>(length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<ushort> srcDist = new NativeArray<ushort>(length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<bool> closed = new NativeArray<bool>(length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<int> flags = new NativeArray<int>(length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<Int3> stack = new NativeArray<Int3>(length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < length; i++)
			{
				nativeArray[i] = 0;
				srcDist[i] = ushort.MaxValue;
				closed[i] = false;
				flags[i] = 0;
			}
			NativeList<ushort> nativeList = distanceField;
			NativeList<int> areaTypes = field.areaTypes;
			NativeList<CompactVoxelCell> cells = field.cells;
			ushort num3 = 2;
			MarkRectWithRegion(0, borderSize, 0, depth, (ushort)(num3 | 0x8000), nativeArray);
			num3++;
			MarkRectWithRegion(width - borderSize, width, 0, depth, (ushort)(num3 | 0x8000), nativeArray);
			num3++;
			MarkRectWithRegion(0, width, 0, borderSize, (ushort)(num3 | 0x8000), nativeArray);
			num3++;
			MarkRectWithRegion(0, width, depth - borderSize, depth, (ushort)(num3 | 0x8000), nativeArray);
			num3++;
			int num4 = 0;
			for (int j = 0; j < distanceField.Length; j++)
			{
				num4 = math.max(distanceField[j], num4);
			}
			NativeArray<int> nativeArray2 = new NativeArray<int>(num4 / 2 + 1, Allocator.Temp);
			for (int k = 0; k < field.spans.Length; k++)
			{
				if ((nativeArray[k] & 0x8000) != 32768 && areaTypes[k] != 0)
				{
					nativeArray2[distanceField[k] / 2]++;
				}
			}
			NativeArray<int> nativeArray3 = new NativeArray<int>(nativeArray2.Length, Allocator.Temp);
			for (int l = 1; l < nativeArray3.Length; l++)
			{
				nativeArray3[l] = nativeArray3[l - 1] + nativeArray2[l - 1];
			}
			int length2 = nativeArray3[nativeArray3.Length - 1] + nativeArray2[nativeArray2.Length - 1];
			NativeArray<Int3> nativeArray4 = new NativeArray<Int3>(length2, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			int num5 = 0;
			int num6 = 0;
			while (num5 < num)
			{
				for (int m = 0; m < field.width; m++)
				{
					CompactVoxelCell compactVoxelCell = cells[num5 + m];
					int n = compactVoxelCell.index;
					for (int num7 = compactVoxelCell.index + compactVoxelCell.count; n < num7; n++)
					{
						if ((nativeArray[n] & 0x8000) != 32768 && areaTypes[n] != 0)
						{
							nativeArray4[nativeArray3[distanceField[n] / 2]++] = new Int3(m, n, num5);
						}
					}
				}
				num5 += width;
				num6++;
			}
			for (int num8 = nativeArray2.Length - 1; num8 >= 0; num8--)
			{
				uint num9 = (uint)(num8 * 2);
				int num10 = nativeArray2[num8];
				for (int num11 = 0; num11 < num10; num11++)
				{
					Int3 value = nativeArray4[nativeArray3[num8] - num11 - 1];
					int y = value.y;
					if (flags[y] != 0 && nativeArray[y] == 0)
					{
						nativeArray[y] = (ushort)flags[y];
						srcQue.Enqueue(value);
						closed[y] = true;
					}
				}
				for (int num12 = 0; num12 < num2; num12++)
				{
					if (srcQue.Count <= 0)
					{
						break;
					}
					while (srcQue.Count > 0)
					{
						Int3 int5 = srcQue.Dequeue();
						int num13 = areaTypes[int5.y];
						CompactVoxelSpan compactVoxelSpan = field.spans[int5.y];
						ushort value2 = nativeArray[int5.y];
						closed[int5.y] = true;
						ushort num14 = (ushort)(srcDist[int5.y] + 2);
						for (int num15 = 0; num15 < 4; num15++)
						{
							int connection = compactVoxelSpan.GetConnection(num15);
							if ((long)connection == 63)
							{
								continue;
							}
							int num16 = int5.x + VoxelUtilityBurst.DX[num15];
							int num17 = int5.z + VoxelUtilityBurst.DZ[num15] * field.width;
							int num18 = cells[num16 + num17].index + connection;
							if ((nativeArray[num18] & 0x8000) == 32768 || num13 != areaTypes[num18] || num14 >= srcDist[num18])
							{
								continue;
							}
							if (nativeList[num18] < num9)
							{
								srcDist[num18] = num14;
								flags[num18] = value2;
							}
							else if (!closed[num18])
							{
								srcDist[num18] = num14;
								if (nativeArray[num18] == 0)
								{
									dstQue.Enqueue(new Int3(num16, num18, num17));
								}
								nativeArray[num18] = value2;
							}
						}
					}
					Memory.Swap(ref srcQue, ref dstQue);
				}
				NativeArray<ushort> nativeArray5 = distanceField.AsArray();
				for (int num19 = 0; num19 < num10; num19++)
				{
					Int3 int6 = nativeArray4[nativeArray3[num8] - num19 - 1];
					if (nativeArray[int6.y] == 0 && FloodRegion(int6.x, int6.z, int6.y, num9, num3, field, nativeArray5, nativeArray, srcDist, stack, flags, closed))
					{
						num3++;
					}
				}
			}
			ushort maxRegions = num3;
			Matrix4x4 matrix4x = Matrix4x4.TRS(graphSpaceBounds.min, Quaternion.identity, Vector3.one) * Matrix4x4.Scale(new Vector3(cellSize, cellHeight, cellSize));
			Matrix4x4 matrix4x2 = graphTransform * matrix4x * Matrix4x4.Translate(new Vector3(0.5f, 0f, 0.5f));
			FilterSmallRegions(field, nativeArray, minRegionSize, maxRegions, relevantGraphSurfaces, relevantGraphSurfaceMode, matrix4x2);
			for (int num20 = 0; num20 < length; num20++)
			{
				CompactVoxelSpan value3 = field.spans[num20];
				value3.reg = nativeArray[num20];
				field.spans[num20] = value3;
			}
		}

		private static int union_find_find(NativeArray<int> arr, int x)
		{
			if (arr[x] < 0)
			{
				return x;
			}
			return arr[x] = union_find_find(arr, arr[x]);
		}

		private static void union_find_union(NativeArray<int> arr, int a, int b)
		{
			a = union_find_find(arr, a);
			b = union_find_find(arr, b);
			if (a != b)
			{
				if (arr[a] > arr[b])
				{
					int num = a;
					a = b;
					b = num;
				}
				arr[a] += arr[b];
				arr[b] = a;
			}
		}

		public static void FilterSmallRegions(CompactVoxelField field, NativeArray<ushort> reg, int minRegionSize, int maxRegions, NativeArray<RelevantGraphSurfaceInfo> relevantGraphSurfaces, RecastGraph.RelevantGraphSurfaceMode relevantGraphSurfaceMode, float4x4 voxel2worldMatrix)
		{
			bool flag = relevantGraphSurfaces.Length != 0 && relevantGraphSurfaceMode != RecastGraph.RelevantGraphSurfaceMode.DoNotRequire;
			if (!flag && minRegionSize <= 0)
			{
				return;
			}
			NativeArray<int> arr = new NativeArray<int>(maxRegions, Allocator.Temp);
			NativeArray<ushort> nativeArray = new NativeArray<ushort>(maxRegions, Allocator.Temp);
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = -1;
			}
			int length = arr.Length;
			int num = field.width * field.depth;
			int num2 = 2 | ((relevantGraphSurfaceMode == RecastGraph.RelevantGraphSurfaceMode.OnlyForCompletelyInsideTile) ? 1 : 0);
			if (flag)
			{
				float4x4 a = math.inverse(voxel2worldMatrix);
				for (int j = 0; j < relevantGraphSurfaces.Length; j++)
				{
					RelevantGraphSurfaceInfo relevantGraphSurfaceInfo = relevantGraphSurfaces[j];
					int3 int5 = (int3)math.round(math.transform(a, relevantGraphSurfaceInfo.position));
					if (int5.x < 0 || int5.z < 0 || int5.x >= field.width || int5.z >= field.depth)
					{
						continue;
					}
					float num3 = math.length(voxel2worldMatrix.c1.xyz);
					int num4 = (int)(relevantGraphSurfaceInfo.range / num3);
					CompactVoxelCell compactVoxelCell = field.cells[int5.x + int5.z * field.width];
					for (int k = compactVoxelCell.index; k < compactVoxelCell.index + compactVoxelCell.count; k++)
					{
						if (Math.Abs(field.spans[k].y - int5.y) <= num4 && reg[k] != 0)
						{
							nativeArray[union_find_find(arr, reg[k] & -32769)] |= 2;
						}
					}
				}
			}
			for (int l = 0; l < num; l += field.width)
			{
				for (int m = 0; m < field.width; m++)
				{
					CompactVoxelCell compactVoxelCell2 = field.cells[m + l];
					for (int n = compactVoxelCell2.index; n < compactVoxelCell2.index + compactVoxelCell2.count; n++)
					{
						CompactVoxelSpan compactVoxelSpan = field.spans[n];
						int num5 = reg[n];
						if ((num5 & -32769) == 0)
						{
							continue;
						}
						if (num5 >= length)
						{
							nativeArray[union_find_find(arr, num5 & -32769)] |= 1;
							continue;
						}
						int num6 = union_find_find(arr, num5);
						arr[num6]--;
						for (int num7 = 0; num7 < 4; num7++)
						{
							if ((long)compactVoxelSpan.GetConnection(num7) == 63)
							{
								continue;
							}
							int num8 = m + VoxelUtilityBurst.DX[num7];
							int num9 = l + VoxelUtilityBurst.DZ[num7] * field.width;
							int index = field.cells[num8 + num9].index + compactVoxelSpan.GetConnection(num7);
							int num10 = reg[index];
							if (num5 != num10 && (num10 & -32769) != 0)
							{
								if ((num10 & 0x8000) != 0)
								{
									nativeArray[num6] |= 1;
								}
								else
								{
									union_find_union(arr, num6, num10);
								}
							}
						}
					}
				}
			}
			for (int num11 = 0; num11 < arr.Length; num11++)
			{
				nativeArray[union_find_find(arr, num11)] |= nativeArray[num11];
			}
			for (int num12 = 0; num12 < arr.Length; num12++)
			{
				int index2 = union_find_find(arr, num12);
				if ((nativeArray[index2] & 1) != 0)
				{
					arr[index2] = -minRegionSize - 2;
				}
				if (flag && (nativeArray[index2] & num2) == 0)
				{
					arr[index2] = -1;
				}
			}
			for (int num13 = 0; num13 < reg.Length; num13++)
			{
				int num14 = reg[num13];
				if (num14 < length && arr[union_find_find(arr, num14)] >= -minRegionSize - 1)
				{
					reg[num13] = 0;
				}
			}
		}
	}
}
