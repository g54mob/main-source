using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile]
	public struct JobFilterDiagonalConnections : IJobParallelForBatched
	{
		public Slice3D slice;

		public NumNeighbours neighbours;

		public bool cutCorners;

		public UnsafeSpan<ulong> nodeConnections;

		public bool allowBoundsChecks => false;

		public void Execute(int start, int count)
		{
			slice.AssertMatchesOuter(nodeConnections);
			int3 outerSize = slice.outerSize;
			NativeArray<int> nativeArray = new NativeArray<int>(8, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < 8; i++)
			{
				nativeArray[i] = GridGraph.neighbourZOffsets[i] * outerSize.x + GridGraph.neighbourXOffsets[i];
			}
			ulong num = 0uL;
			for (int j = 0; j < GridGraph.hexagonNeighbourIndices.Length; j++)
			{
				num |= (ulong)(15L << 4 * GridGraph.hexagonNeighbourIndices[j]);
			}
			int num2 = (cutCorners ? 1 : 2);
			int num3 = outerSize.x * outerSize.z;
			start += slice.slice.min.z;
			for (int k = slice.slice.min.y; k < slice.slice.max.y; k++)
			{
				for (int l = start; l < start + count; l++)
				{
					for (int m = slice.slice.min.x; m < slice.slice.max.x; m++)
					{
						int num4 = l * outerSize.x + m;
						int index = num4 + k * num3;
						switch (neighbours)
						{
						case NumNeighbours.Four:
							nodeConnections[index] |= 0xFFFF0000u;
							break;
						case NumNeighbours.Eight:
						{
							ulong num5 = nodeConnections[index];
							if (num5 == uint.MaxValue)
							{
								break;
							}
							for (int n = 0; n < 4; n++)
							{
								int num6 = 0;
								ulong num7 = (num5 >> n * 4) & 0xF;
								ulong num8 = (num5 >> (n + 1) % 4 * 4) & 0xF;
								ulong num9 = (num5 >> (n + 4) * 4) & 0xF;
								if (num9 == 15)
								{
									continue;
								}
								if (num7 != 15)
								{
									int num10 = (n + 1) % 4;
									int index2 = num4 + nativeArray[n] + (int)num7 * num3;
									if (((nodeConnections[index2] >> num10 * 4) & 0xF) == num9)
									{
										num6++;
									}
								}
								if (num8 != 15)
								{
									int num11 = n;
									int index3 = num4 + nativeArray[(n + 1) % 4] + (int)num8 * num3;
									if (((nodeConnections[index3] >> num11 * 4) & 0xF) == num9)
									{
										num6++;
									}
								}
								if (num6 < num2)
								{
									num5 |= (ulong)(15L << (n + 4) * 4);
								}
							}
							nodeConnections[index] = num5;
							break;
						}
						case NumNeighbours.Six:
							nodeConnections[index] = (nodeConnections[index] | ~num) & 0xFFFFFFFFu;
							break;
						}
					}
				}
			}
		}
	}
}
