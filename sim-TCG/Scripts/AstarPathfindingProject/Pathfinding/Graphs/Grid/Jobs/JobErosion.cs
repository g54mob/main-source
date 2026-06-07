using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobErosion<AdjacencyMapper> : IJob where AdjacencyMapper : GridAdjacencyMapper, new()
	{
		public IntBounds bounds;

		public IntBounds writeMask;

		public NumNeighbours neighbours;

		public int erosion;

		public bool erosionUsesTags;

		public int erosionStartTag;

		[ReadOnly]
		public NativeArray<ulong> nodeConnections;

		[ReadOnly]
		public NativeArray<bool> nodeWalkable;

		[WriteOnly]
		public NativeArray<bool> outNodeWalkable;

		public NativeArray<int> nodeTags;

		public int erosionTagsPrecedenceMask;

		private static readonly int[] hexagonNeighbourIndices = new int[6] { 1, 2, 5, 0, 3, 7 };

		public void Execute()
		{
			Slice3D slice3D = new Slice3D(bounds, bounds);
			int3 size = slice3D.slice.size;
			slice3D.AssertMatchesOuter(nodeConnections);
			slice3D.AssertMatchesOuter(nodeWalkable);
			slice3D.AssertMatchesOuter(outNodeWalkable);
			slice3D.AssertMatchesOuter(nodeTags);
			(int, int, int) outerStrides = slice3D.outerStrides;
			int item = outerStrides.Item1;
			int item2 = outerStrides.Item2;
			int item3 = outerStrides.Item3;
			(int, int, int) innerStrides = slice3D.innerStrides;
			int item4 = innerStrides.Item1;
			int item5 = innerStrides.Item2;
			int item6 = innerStrides.Item3;
			NativeArray<int> nativeArray = new NativeArray<int>(8, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < 8; i++)
			{
				nativeArray[i] = GridGraph.neighbourZOffsets[i] * item6 + GridGraph.neighbourXOffsets[i] * item4;
			}
			NativeArray<int> nativeArray2 = new NativeArray<int>(slice3D.length, Allocator.Temp);
			AdjacencyMapper val = new AdjacencyMapper();
			IntBounds slice = slice3D.slice;
			int num = val.LayerCount(slice);
			int outerStartIndex = slice3D.outerStartIndex;
			if (neighbours == NumNeighbours.Six)
			{
				for (int j = 1; j < size.z - 1; j++)
				{
					for (int k = 1; k < size.x - 1; k++)
					{
						for (int l = 0; l < num; l++)
						{
							int nodeIndex = j * item3 + k * item + l * item2 + outerStartIndex;
							int num2 = j * item6 + k * item4;
							int num3 = num2 + l * item5;
							int num4 = int.MaxValue;
							for (int m = 3; m < 6; m++)
							{
								int direction = hexagonNeighbourIndices[m];
								NativeArray<ulong> nativeArray3 = nodeConnections;
								if (!val.HasConnection(nodeIndex, direction, nativeArray3))
								{
									num4 = -1;
									continue;
								}
								int x = num4;
								NativeArray<ulong> nativeArray4 = nodeConnections;
								NativeArray<int> neighbourOffsets = nativeArray;
								num4 = math.min(x, nativeArray2[val.GetNeighbourIndex(num2, num3, direction, nativeArray4, neighbourOffsets, item5)]);
							}
							nativeArray2[num3] = num4 + 1;
						}
					}
				}
				for (int num5 = size.z - 2; num5 > 0; num5--)
				{
					for (int num6 = size.x - 2; num6 > 0; num6--)
					{
						for (int n = 0; n < num; n++)
						{
							int nodeIndex2 = num5 * item3 + num6 * item + n * item2 + outerStartIndex;
							int num7 = num5 * item6 + num6 * item4;
							int num8 = num7 + n * item5;
							int num9 = int.MaxValue;
							for (int num10 = 3; num10 < 6; num10++)
							{
								int direction2 = hexagonNeighbourIndices[num10];
								NativeArray<ulong> nativeArray5 = nodeConnections;
								if (!val.HasConnection(nodeIndex2, direction2, nativeArray5))
								{
									num9 = -1;
									continue;
								}
								int x2 = num9;
								NativeArray<ulong> nativeArray6 = nodeConnections;
								NativeArray<int> neighbourOffsets2 = nativeArray;
								num9 = math.min(x2, nativeArray2[val.GetNeighbourIndex(num7, num8, direction2, nativeArray6, neighbourOffsets2, item5)]);
							}
							nativeArray2[num8] = math.min(nativeArray2[num8], num9 + 1);
						}
					}
				}
			}
			else
			{
				for (int num11 = 1; num11 < size.z - 1; num11++)
				{
					for (int num12 = 1; num12 < size.x - 1; num12++)
					{
						for (int num13 = 0; num13 < num; num13++)
						{
							int nodeIndex3 = num11 * item3 + num12 * item + num13 * item2 + outerStartIndex;
							int num14 = num11 * item6 + num12 * item4;
							int num15 = num14 + num13 * item5;
							int x3 = -1;
							NativeArray<ulong> nativeArray7 = nodeConnections;
							if (val.HasConnection(nodeIndex3, 0, nativeArray7))
							{
								NativeArray<ulong> nativeArray8 = nodeConnections;
								NativeArray<int> neighbourOffsets3 = nativeArray;
								x3 = nativeArray2[val.GetNeighbourIndex(num14, num15, 0, nativeArray8, neighbourOffsets3, item5)];
							}
							int y = -1;
							NativeArray<ulong> nativeArray9 = nodeConnections;
							if (val.HasConnection(nodeIndex3, 3, nativeArray9))
							{
								NativeArray<ulong> nativeArray10 = nodeConnections;
								NativeArray<int> neighbourOffsets4 = nativeArray;
								y = nativeArray2[val.GetNeighbourIndex(num14, num15, 3, nativeArray10, neighbourOffsets4, item5)];
							}
							nativeArray2[num15] = math.min(x3, y) + 1;
						}
					}
				}
				for (int num16 = size.z - 2; num16 > 0; num16--)
				{
					for (int num17 = size.x - 2; num17 > 0; num17--)
					{
						for (int num18 = 0; num18 < num; num18++)
						{
							int num19 = num16 * item3 + num17 * item + num18 * item2 + outerStartIndex;
							int num20 = num16 * item6 + num17 * item4;
							int num21 = num20 + num18 * item5;
							int x4 = -1;
							NativeArray<ulong> nativeArray11 = nodeConnections;
							if (val.HasConnection(num19, 2, nativeArray11))
							{
								NativeArray<ulong> nativeArray12 = nodeConnections;
								NativeArray<int> neighbourOffsets5 = nativeArray;
								x4 = nativeArray2[val.GetNeighbourIndex(num20, num21, 2, nativeArray12, neighbourOffsets5, item5)];
							}
							int y2 = -1;
							NativeArray<ulong> nativeArray13 = nodeConnections;
							if (val.HasConnection(num19, 1, nativeArray13))
							{
								NativeArray<ulong> nativeArray14 = nodeConnections;
								NativeArray<int> neighbourOffsets6 = nativeArray;
								y2 = nativeArray2[val.GetNeighbourIndex(num20, num21, 1, nativeArray14, neighbourOffsets6, item5)];
							}
							nativeArray2[num21] = math.min(nativeArray2[num19], math.min(x4, y2) + 1);
						}
					}
				}
			}
			IntBounds intBounds = writeMask.Offset(-bounds.min);
			for (int num22 = erosionStartTag; num22 < erosionStartTag + erosion; num22++)
			{
				erosionTagsPrecedenceMask |= 1 << num22;
			}
			for (int num23 = intBounds.min.y; num23 < intBounds.max.y; num23++)
			{
				for (int num24 = intBounds.min.z; num24 < intBounds.max.z; num24++)
				{
					for (int num25 = intBounds.min.x; num25 < intBounds.max.x; num25++)
					{
						int index = num25 * item + num23 * item2 + num24 * item3 + outerStartIndex;
						int index2 = num25 * item4 + num23 * item5 + num24 * item6;
						if (erosionUsesTags)
						{
							int num26 = nodeTags[index];
							outNodeWalkable[index] = nodeWalkable[index];
							if (nativeArray2[index2] < erosion)
							{
								if (((erosionTagsPrecedenceMask >> num26) & 1) != 0)
								{
									nodeTags[index] = (nodeWalkable[index] ? math.min(31, nativeArray2[index2] + erosionStartTag) : 0);
								}
							}
							else if (num26 >= erosionStartTag && num26 < erosionStartTag + erosion)
							{
								nodeTags[index] = 0;
							}
						}
						else
						{
							outNodeWalkable[index] = nodeWalkable[index] & (nativeArray2[index2] >= erosion);
						}
					}
				}
			}
		}
	}
}
