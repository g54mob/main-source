using System;
using System.Runtime.CompilerServices;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	public struct JobBuildContours : IJob
	{
		public CompactVoxelField field;

		public float maxError;

		public float maxEdgeLength;

		public int buildFlags;

		public float cellSize;

		public NativeList<VoxelContour> outputContours;

		public NativeList<int> outputVerts;

		public void Execute()
		{
			outputContours.Clear();
			outputVerts.Clear();
			int width = field.width;
			int depth = field.depth;
			int num = width * depth;
			NativeArray<ushort> flags = new NativeArray<ushort>(field.spans.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < num; i += field.width)
			{
				for (int j = 0; j < field.width; j++)
				{
					CompactVoxelCell compactVoxelCell = field.cells[j + i];
					int k = compactVoxelCell.index;
					for (int num2 = compactVoxelCell.index + compactVoxelCell.count; k < num2; k++)
					{
						ushort num3 = 0;
						CompactVoxelSpan compactVoxelSpan = field.spans[k];
						if (compactVoxelSpan.reg == 0 || (compactVoxelSpan.reg & 0x8000) == 32768)
						{
							flags[k] = 0;
							continue;
						}
						for (int l = 0; l < 4; l++)
						{
							int num4 = 0;
							if ((long)compactVoxelSpan.GetConnection(l) != 63)
							{
								int index = field.cells[field.GetNeighbourIndex(j + i, l)].index + compactVoxelSpan.GetConnection(l);
								num4 = field.spans[index].reg;
							}
							if (num4 == compactVoxelSpan.reg)
							{
								num3 |= (ushort)(1 << l);
							}
						}
						flags[k] = (ushort)(num3 ^ 0xF);
					}
				}
			}
			NativeList<int> verts = new NativeList<int>(256, Allocator.Temp);
			NativeList<int> simplified = new NativeList<int>(64, Allocator.Temp);
			for (int m = 0; m < num; m += field.width)
			{
				for (int n = 0; n < field.width; n++)
				{
					CompactVoxelCell compactVoxelCell2 = field.cells[n + m];
					int num5 = compactVoxelCell2.index;
					for (int num6 = compactVoxelCell2.index + compactVoxelCell2.count; num5 < num6; num5++)
					{
						if (flags[num5] == 0 || flags[num5] == 15)
						{
							flags[num5] = 0;
							continue;
						}
						int reg = field.spans[num5].reg;
						if (reg != 0 && (reg & 0x8000) != 32768)
						{
							int area = field.areaTypes[num5];
							verts.Clear();
							simplified.Clear();
							WalkContour(n, m, num5, flags, verts);
							SimplifyContour(verts, simplified, maxError, buildFlags);
							RemoveDegenerateSegments(simplified);
							VoxelContour value = new VoxelContour
							{
								vertexStartIndex = outputVerts.Length,
								nverts = simplified.Length / 4,
								reg = reg,
								area = area
							};
							outputVerts.AddRange(simplified.AsArray());
							outputContours.Add(in value);
						}
					}
				}
			}
			verts.Dispose();
			simplified.Dispose();
			for (int num7 = 0; num7 < outputContours.Length; num7++)
			{
				VoxelContour cb = outputContours[num7];
				NativeArray<int> verts2 = outputVerts.AsArray();
				if (CalcAreaOfPolygon2D(verts2, cb.vertexStartIndex, cb.nverts) >= 0)
				{
					continue;
				}
				int num8 = -1;
				for (int num9 = 0; num9 < outputContours.Length; num9++)
				{
					if (num7 != num9 && outputContours[num9].nverts > 0 && outputContours[num9].reg == cb.reg && CalcAreaOfPolygon2D(verts2, outputContours[num9].vertexStartIndex, outputContours[num9].nverts) > 0)
					{
						num8 = num9;
						break;
					}
				}
				if (num8 != -1)
				{
					VoxelContour ca = outputContours[num8];
					GetClosestIndices(verts2, ca.vertexStartIndex, ca.nverts, cb.vertexStartIndex, cb.nverts, out var ia, out var ib);
					if (ia != -1 && ib != -1 && MergeContours(outputVerts, ref ca, ref cb, ia, ib))
					{
						outputContours[num8] = ca;
						outputContours[num7] = cb;
					}
				}
			}
		}

		private void GetClosestIndices(NativeArray<int> verts, int vertexStartIndexA, int nvertsa, int vertexStartIndexB, int nvertsb, out int ia, out int ib)
		{
			int num = 268435455;
			ia = -1;
			ib = -1;
			for (int i = 0; i < nvertsa; i++)
			{
				int num2 = (i + 1) % nvertsa;
				int num3 = (i + nvertsa - 1) % nvertsa;
				int num4 = vertexStartIndexA + i * 4;
				int b = vertexStartIndexA + num2 * 4;
				int a = vertexStartIndexA + num3 * 4;
				for (int j = 0; j < nvertsb; j++)
				{
					int num5 = vertexStartIndexB + j * 4;
					if (Ileft(verts, a, num4, num5) && Ileft(verts, num4, b, num5))
					{
						int num6 = verts[num5] - verts[num4];
						int num7 = verts[num5 + 2] / field.width - verts[num4 + 2] / field.width;
						int num8 = num6 * num6 + num7 * num7;
						if (num8 < num)
						{
							ia = i;
							ib = j;
							num = num8;
						}
					}
				}
			}
		}

		public static bool MergeContours(NativeList<int> verts, ref VoxelContour ca, ref VoxelContour cb, int ia, int ib)
		{
			int num = 0;
			int length = verts.Length;
			for (int i = 0; i <= ca.nverts; i++)
			{
				int num2 = ca.vertexStartIndex + (ia + i) % ca.nverts * 4;
				verts.Add(verts[num2]);
				verts.Add(verts[num2 + 1]);
				verts.Add(verts[num2 + 2]);
				verts.Add(verts[num2 + 3]);
				num++;
			}
			for (int j = 0; j <= cb.nverts; j++)
			{
				int num3 = cb.vertexStartIndex + (ib + j) % cb.nverts * 4;
				verts.Add(verts[num3]);
				verts.Add(verts[num3 + 1]);
				verts.Add(verts[num3 + 2]);
				verts.Add(verts[num3 + 3]);
				num++;
			}
			ca.vertexStartIndex = length;
			ca.nverts = num;
			cb.vertexStartIndex = 0;
			cb.nverts = 0;
			return true;
		}

		public void SimplifyContour(NativeList<int> verts, NativeList<int> simplified, float maxError, int buildFlags)
		{
			bool flag = false;
			for (int i = 0; i < verts.Length; i += 4)
			{
				if ((verts[i + 3] & 0xFFFF) != 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				int j = 0;
				for (int num = verts.Length / 4; j < num; j++)
				{
					int num2 = (j + 1) % num;
					bool num3 = (verts[j * 4 + 3] & 0xFFFF) != (verts[num2 * 4 + 3] & 0xFFFF);
					bool flag2 = (verts[j * 4 + 3] & 0x20000) != (verts[num2 * 4 + 3] & 0x20000);
					if (num3 || flag2)
					{
						simplified.Add(verts[j * 4]);
						simplified.Add(verts[j * 4 + 1]);
						simplified.Add(verts[j * 4 + 2]);
						simplified.Add(in j);
					}
				}
			}
			if (simplified.Length == 0)
			{
				int value = verts[0];
				int value2 = verts[1];
				int value3 = verts[2];
				int value4 = 0;
				int value5 = verts[0];
				int value6 = verts[1];
				int value7 = verts[2];
				int value8 = 0;
				for (int k = 0; k < verts.Length; k += 4)
				{
					int num4 = verts[k];
					int num5 = verts[k + 1];
					int num6 = verts[k + 2];
					if (num4 < value || (num4 == value && num6 < value3))
					{
						value = num4;
						value2 = num5;
						value3 = num6;
						value4 = k / 4;
					}
					if (num4 > value5 || (num4 == value5 && num6 > value7))
					{
						value5 = num4;
						value6 = num5;
						value7 = num6;
						value8 = k / 4;
					}
				}
				simplified.Add(in value);
				simplified.Add(in value2);
				simplified.Add(in value3);
				simplified.Add(in value4);
				simplified.Add(in value5);
				simplified.Add(in value6);
				simplified.Add(in value7);
				simplified.Add(in value8);
			}
			int num7 = verts.Length / 4;
			maxError *= maxError;
			int num8 = 0;
			while (num8 < simplified.Length / 4)
			{
				int num9 = (num8 + 1) % (simplified.Length / 4);
				int a = simplified[num8 * 4];
				_ = simplified[num8 * 4 + 1];
				int a2 = simplified[num8 * 4 + 2];
				int num10 = simplified[num8 * 4 + 3];
				int b = simplified[num9 * 4];
				_ = simplified[num9 * 4 + 1];
				int b2 = simplified[num9 * 4 + 2];
				int num11 = simplified[num9 * 4 + 3];
				float num12 = 0f;
				int num13 = -1;
				int num14;
				int num15;
				int num16;
				if (b > a || (b == a && b2 > a2))
				{
					num14 = 1;
					num15 = (num10 + num14) % num7;
					num16 = num11;
				}
				else
				{
					num14 = num7 - 1;
					num15 = (num11 + num14) % num7;
					num16 = num10;
					Memory.Swap(ref a, ref b);
					Memory.Swap(ref a2, ref b2);
				}
				if ((verts[num15 * 4 + 3] & 0xFFFF) == 0 || (verts[num15 * 4 + 3] & 0x20000) == 131072)
				{
					while (num15 != num16)
					{
						float num17 = VectorMath.SqrDistancePointSegmentApproximate(verts[num15 * 4], verts[num15 * 4 + 2] / field.width, a, a2 / field.width, b, b2 / field.width);
						if (num17 > num12)
						{
							num12 = num17;
							num13 = num15;
						}
						num15 = (num15 + num14) % num7;
					}
				}
				if (num13 != -1 && num12 > maxError)
				{
					simplified.ResizeUninitialized(simplified.Length + 4);
					simplified.AsUnsafeSpan().Move((num8 + 1) * 4, (num8 + 2) * 4, simplified.Length - (num8 + 2) * 4);
					simplified[(num8 + 1) * 4] = verts[num13 * 4];
					simplified[(num8 + 1) * 4 + 1] = verts[num13 * 4 + 1];
					simplified[(num8 + 1) * 4 + 2] = verts[num13 * 4 + 2];
					simplified[(num8 + 1) * 4 + 3] = num13;
				}
				else
				{
					num8++;
				}
			}
			float num18 = maxEdgeLength / cellSize;
			if (num18 > 0f && (buildFlags & 7) != 0)
			{
				int num19 = 0;
				while (num19 < simplified.Length / 4 && simplified.Length / 4 <= 200)
				{
					int num20 = (num19 + 1) % (simplified.Length / 4);
					int num21 = simplified[num19 * 4];
					int num22 = simplified[num19 * 4 + 2];
					int num23 = simplified[num19 * 4 + 3];
					int num24 = simplified[num20 * 4];
					int num25 = simplified[num20 * 4 + 2];
					int num26 = simplified[num20 * 4 + 3];
					int num27 = -1;
					int num28 = (num23 + 1) % num7;
					bool flag3 = false;
					if ((buildFlags & 1) != 0 && (verts[num28 * 4 + 3] & 0xFFFF) == 0)
					{
						flag3 = true;
					}
					if ((buildFlags & 2) != 0 && (verts[num28 * 4 + 3] & 0x20000) == 131072)
					{
						flag3 = true;
					}
					if ((buildFlags & 4) != 0 && (verts[num28 * 4 + 3] & 0x8000) == 32768)
					{
						flag3 = true;
					}
					if (flag3)
					{
						int num29 = num24 - num21;
						int num30 = num25 / field.width - num22 / field.width;
						if ((float)(num29 * num29 + num30 * num30) > num18 * num18)
						{
							int num31 = ((num26 < num23) ? (num26 + num7 - num23) : (num26 - num23));
							if (num31 > 1)
							{
								num27 = ((num24 <= num21 && (num24 != num21 || num25 <= num22)) ? ((num23 + (num31 + 1) / 2) % num7) : ((num23 + num31 / 2) % num7));
							}
						}
					}
					if (num27 != -1)
					{
						simplified.Resize(simplified.Length + 4, NativeArrayOptions.UninitializedMemory);
						simplified.AsUnsafeSpan().Move((num19 + 1) * 4, (num19 + 2) * 4, simplified.Length - (num19 + 2) * 4);
						simplified[(num19 + 1) * 4] = verts[num27 * 4];
						simplified[(num19 + 1) * 4 + 1] = verts[num27 * 4 + 1];
						simplified[(num19 + 1) * 4 + 2] = verts[num27 * 4 + 2];
						simplified[(num19 + 1) * 4 + 3] = num27;
					}
					else
					{
						num19++;
					}
				}
			}
			for (int l = 0; l < simplified.Length / 4; l++)
			{
				int num32 = (simplified[l * 4 + 3] + 1) % num7;
				int num33 = simplified[l * 4 + 3];
				simplified[l * 4 + 3] = (verts[num32 * 4 + 3] & 0xFFFF) | (verts[num33 * 4 + 3] & 0x10000);
			}
		}

		public void WalkContour(int x, int z, int i, NativeArray<ushort> flags, NativeList<int> verts)
		{
			int j;
			for (j = 0; (flags[i] & (ushort)(1 << j)) == 0; j++)
			{
			}
			int num = j;
			int num2 = i;
			int num3 = field.areaTypes[i];
			int num4 = 0;
			while (num4++ < 40000)
			{
				if ((flags[i] & (ushort)(1 << j)) != 0)
				{
					bool isBorderVertex = false;
					bool flag = false;
					int value = x;
					int value2 = GetCornerHeight(x, z, i, j, ref isBorderVertex);
					int value3 = z;
					switch (j)
					{
					case 0:
						value3 += field.width;
						break;
					case 1:
						value++;
						value3 += field.width;
						break;
					case 2:
						value++;
						break;
					}
					int value4 = 0;
					CompactVoxelSpan compactVoxelSpan = field.spans[i];
					if ((long)compactVoxelSpan.GetConnection(j) != 63)
					{
						int index = field.cells[field.GetNeighbourIndex(x + z, j)].index + compactVoxelSpan.GetConnection(j);
						value4 = field.spans[index].reg;
						if (num3 != field.areaTypes[index])
						{
							flag = true;
						}
					}
					if (isBorderVertex)
					{
						value4 |= 0x10000;
					}
					if (flag)
					{
						value4 |= 0x20000;
					}
					verts.Add(in value);
					verts.Add(in value2);
					verts.Add(in value3);
					verts.Add(in value4);
					flags[i] = (ushort)(flags[i] & ~(1 << j));
					j = (j + 1) & 3;
				}
				else
				{
					int num5 = -1;
					int num6 = x + VoxelUtilityBurst.DX[j];
					int num7 = z + VoxelUtilityBurst.DZ[j] * field.width;
					CompactVoxelSpan compactVoxelSpan2 = field.spans[i];
					if ((long)compactVoxelSpan2.GetConnection(j) != 63)
					{
						num5 = field.cells[num6 + num7].index + compactVoxelSpan2.GetConnection(j);
					}
					if (num5 == -1)
					{
						Debug.LogWarning("Degenerate triangles might have been generated.\nUsually this is not a problem, but if you have a static level, try to modify the graph settings slightly to avoid this edge case.");
						break;
					}
					x = num6;
					z = num7;
					i = num5;
					j = (j + 3) & 3;
				}
				if (num2 == i && num == j)
				{
					break;
				}
			}
		}

		public unsafe int GetCornerHeight(int x, int z, int i, int dir, ref bool isBorderVertex)
		{
			CompactVoxelSpan compactVoxelSpan = field.spans[i];
			int num = compactVoxelSpan.y;
			int num2 = (dir + 1) & 3;
			byte* intPtr = stackalloc byte[16];
			// IL initblk instruction
			System.Runtime.CompilerServices.Unsafe.InitBlock(intPtr, 0, 16);
			uint* ptr = (uint*)intPtr;
			*ptr = (uint)(field.spans[i].reg | (field.areaTypes[i] << 16));
			if ((long)compactVoxelSpan.GetConnection(dir) != 63)
			{
				int neighbourIndex = field.GetNeighbourIndex(x + z, dir);
				int index = field.cells[neighbourIndex].index + compactVoxelSpan.GetConnection(dir);
				CompactVoxelSpan compactVoxelSpan2 = field.spans[index];
				num = Math.Max(num, compactVoxelSpan2.y);
				ptr[1] = (uint)(compactVoxelSpan2.reg | (field.areaTypes[index] << 16));
				if ((long)compactVoxelSpan2.GetConnection(num2) != 63)
				{
					int neighbourIndex2 = field.GetNeighbourIndex(neighbourIndex, num2);
					int index2 = field.cells[neighbourIndex2].index + compactVoxelSpan2.GetConnection(num2);
					CompactVoxelSpan compactVoxelSpan3 = field.spans[index2];
					num = Math.Max(num, compactVoxelSpan3.y);
					ptr[2] = (uint)(compactVoxelSpan3.reg | (field.areaTypes[index2] << 16));
				}
			}
			if ((long)compactVoxelSpan.GetConnection(num2) != 63)
			{
				int neighbourIndex3 = field.GetNeighbourIndex(x + z, num2);
				int index3 = field.cells[neighbourIndex3].index + compactVoxelSpan.GetConnection(num2);
				CompactVoxelSpan compactVoxelSpan4 = field.spans[index3];
				num = Math.Max(num, compactVoxelSpan4.y);
				ptr[3] = (uint)(compactVoxelSpan4.reg | (field.areaTypes[index3] << 16));
				if ((long)compactVoxelSpan4.GetConnection(dir) != 63)
				{
					int neighbourIndex4 = field.GetNeighbourIndex(neighbourIndex3, dir);
					int index4 = field.cells[neighbourIndex4].index + compactVoxelSpan4.GetConnection(dir);
					CompactVoxelSpan compactVoxelSpan5 = field.spans[index4];
					num = Math.Max(num, compactVoxelSpan5.y);
					ptr[2] = (uint)(compactVoxelSpan5.reg | (field.areaTypes[index4] << 16));
				}
			}
			bool flag = *ptr != 0 && ptr[1] != 0 && ptr[2] != 0 && ptr[3] != 0;
			for (int j = 0; j < 4; j++)
			{
				int num3 = j;
				int num4 = (j + 1) & 3;
				int num5 = (j + 2) & 3;
				int num6 = (j + 3) & 3;
				bool num7 = (ptr[num3] & ptr[num4] & 0x8000) != 0 && ptr[num3] == ptr[num4];
				bool flag2 = ((ptr[num5] | ptr[num6]) & 0x8000) == 0;
				bool flag3 = ptr[num5] >> 16 == ptr[num6] >> 16;
				if (num7 && flag2 && flag3 && flag)
				{
					isBorderVertex = true;
					break;
				}
			}
			return num;
		}

		private static void RemoveRange(NativeList<int> arr, int index, int count)
		{
			for (int i = index; i < arr.Length - count; i++)
			{
				arr[i] = arr[i + count];
			}
			arr.Resize(arr.Length - count, NativeArrayOptions.UninitializedMemory);
		}

		private static void RemoveDegenerateSegments(NativeList<int> simplified)
		{
			for (int i = 0; i < simplified.Length / 4; i++)
			{
				int num = i + 1;
				if (num >= simplified.Length / 4)
				{
					num = 0;
				}
				if (simplified[i * 4] == simplified[num * 4] && simplified[i * 4 + 2] == simplified[num * 4 + 2])
				{
					RemoveRange(simplified, i, 4);
				}
			}
		}

		private int CalcAreaOfPolygon2D(NativeArray<int> verts, int vertexStartIndex, int nverts)
		{
			int num = 0;
			int num2 = 0;
			int num3 = nverts - 1;
			while (num2 < nverts)
			{
				int num4 = vertexStartIndex + num2 * 4;
				int num5 = vertexStartIndex + num3 * 4;
				num += verts[num4] * (verts[num5 + 2] / field.width) - verts[num5] * (verts[num4 + 2] / field.width);
				num3 = num2++;
			}
			return (num + 1) / 2;
		}

		private static bool Ileft(NativeArray<int> verts, int a, int b, int c)
		{
			return (verts[b] - verts[a]) * (verts[c + 2] - verts[a + 2]) - (verts[c] - verts[a]) * (verts[b + 2] - verts[a + 2]) <= 0;
		}
	}
}
