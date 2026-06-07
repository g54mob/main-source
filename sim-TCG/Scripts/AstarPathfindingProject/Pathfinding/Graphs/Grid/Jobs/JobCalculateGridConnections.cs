using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast, CompileSynchronously = true)]
	public struct JobCalculateGridConnections : IJobParallelForBatched
	{
		public float maxStepHeight;

		public Vector3 up;

		public IntBounds bounds;

		public int3 arrayBounds;

		public NumNeighbours neighbours;

		public bool use2D;

		public bool cutCorners;

		public bool maxStepUsesSlope;

		public float characterHeight;

		public bool layeredDataLayout;

		[ReadOnly]
		public UnsafeSpan<bool> nodeWalkable;

		[ReadOnly]
		public UnsafeSpan<float4> nodeNormals;

		[ReadOnly]
		public UnsafeSpan<Vector3> nodePositions;

		[WriteOnly]
		public UnsafeSpan<ulong> nodeConnections;

		public bool allowBoundsChecks => false;

		public static bool IsValidConnection(float4 nodePosA, float4 nodeNormalA, bool nodeWalkableB, float4 nodePosB, float4 nodeNormalB, bool maxStepUsesSlope, float maxStepHeight, float4 up)
		{
			if (!nodeWalkableB)
			{
				return false;
			}
			if (!maxStepUsesSlope)
			{
				return math.abs(math.dot(up, nodePosB - nodePosA)) <= maxStepHeight;
			}
			float4 float5 = nodePosB - nodePosA;
			float num = math.dot(float5, up);
			if (math.abs(num) <= maxStepHeight)
			{
				return true;
			}
			float4 y = (float5 - num * up) * 0.5f;
			float num2 = math.dot(nodeNormalA, up);
			float num3 = 0f - math.dot(nodeNormalA - num2 * up, y);
			num2 = math.dot(nodeNormalB, up);
			float num4 = math.dot(nodeNormalB - num2 * up, y);
			return math.abs(num + num4 - num3) <= maxStepHeight;
		}

		public void Execute(int start, int count)
		{
			if (layeredDataLayout)
			{
				ExecuteLayered(start, count);
			}
			else
			{
				ExecuteFlat(start, count);
			}
		}

		public void ExecuteFlat(int start, int count)
		{
			if (maxStepHeight <= 0f || use2D)
			{
				maxStepHeight = float.PositiveInfinity;
			}
			float4 float5 = new float4(up.x, up.y, up.z, 0f);
			NativeArray<int> nativeArray = new NativeArray<int>(8, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < 8; i++)
			{
				nativeArray[i] = GridGraph.neighbourZOffsets[i] * arrayBounds.x + GridGraph.neighbourXOffsets[i];
			}
			UnsafeSpan<float3> unsafeSpan = nodePositions.Reinterpret<float3>();
			start += bounds.min.z;
			for (int j = start; j < start + count; j++)
			{
				int num = 255;
				if (j == 0)
				{
					num &= -146;
				}
				if (j == arrayBounds.z - 1)
				{
					num &= -101;
				}
				for (int k = bounds.min.x; k < bounds.max.x; k++)
				{
					int num2 = j * arrayBounds.x + k;
					if (!nodeWalkable[num2])
					{
						nodeConnections[num2] = 0uL;
						continue;
					}
					int num3 = num;
					if (k == 0)
					{
						num3 &= -201;
					}
					if (k == arrayBounds.x - 1)
					{
						num3 &= -51;
					}
					float4 nodePosA = new float4(unsafeSpan[num2], 0f);
					float4 nodeNormalA = nodeNormals[num2];
					for (int l = 0; l < 8; l++)
					{
						int index = num2 + nativeArray[l];
						if ((num3 & (1 << l)) != 0 && !IsValidConnection(nodePosA, nodeNormalA, nodeWalkable[index], new float4(unsafeSpan[index], 0f), nodeNormals[index], maxStepUsesSlope, maxStepHeight, float5))
						{
							num3 &= ~(1 << l);
						}
					}
					nodeConnections[num2] = (ulong)GridNode.FilterDiagonalConnections(num3, neighbours, cutCorners);
				}
			}
		}

		public void ExecuteLayered(int start, int count)
		{
			if (maxStepHeight <= 0f || use2D)
			{
				maxStepHeight = float.PositiveInfinity;
			}
			float4 x = new float4(up.x, up.y, up.z, 0f);
			NativeArray<int> nativeArray = new NativeArray<int>(8, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < 8; i++)
			{
				nativeArray[i] = GridGraph.neighbourZOffsets[i] * arrayBounds.x + GridGraph.neighbourXOffsets[i];
			}
			int num = arrayBounds.z * arrayBounds.x;
			start += bounds.min.z;
			for (int j = bounds.min.y; j < bounds.max.y; j++)
			{
				for (int k = start; k < start + count; k++)
				{
					for (int l = bounds.min.x; l < bounds.max.x; l++)
					{
						ulong num2 = 0uL;
						int num3 = k * arrayBounds.x + l;
						int num4 = num3 + j * num;
						float4 float5 = new float4(nodePositions[num4], 0f);
						float4 nodeNormalA = nodeNormals[num4];
						if (nodeWalkable[num4])
						{
							float num5 = math.dot(x, float5);
							float num6;
							if (j == arrayBounds.y - 1 || !math.any(nodeNormals[num4 + num]))
							{
								num6 = float.PositiveInfinity;
							}
							else
							{
								float4 y = new float4(nodePositions[num4 + num], 0f);
								num6 = math.max(0f, math.dot(x, y) - num5);
							}
							for (int m = 0; m < 8; m++)
							{
								int num7 = l + GridGraph.neighbourXOffsets[m];
								int num8 = k + GridGraph.neighbourZOffsets[m];
								int num9 = 15;
								if (num7 >= 0 && num8 >= 0 && num7 < arrayBounds.x && num8 < arrayBounds.z)
								{
									int num10 = num3 + nativeArray[m];
									for (int n = 0; n < arrayBounds.y; n++)
									{
										int num11 = num10 + n * num;
										float4 y2 = new float4(nodePositions[num11], 0f);
										float num12 = math.dot(x, y2);
										float num13;
										if (n == arrayBounds.y - 1 || !math.any(nodeNormals[num11 + num]))
										{
											num13 = float.PositiveInfinity;
										}
										else
										{
											float4 y3 = new float4(nodePositions[num11 + num], 0f);
											num13 = math.max(0f, math.dot(x, y3) - num12);
										}
										float num14 = math.max(num12, num5);
										if (math.min(num12 + num13, num5 + num6) - num14 >= characterHeight && IsValidConnection(float5, nodeNormalA, nodeWalkable[num11], new float4(nodePositions[num11], 0f), nodeNormals[num11], maxStepUsesSlope, maxStepHeight, x))
										{
											num9 = n;
										}
									}
								}
								num2 |= (ulong)((long)num9 << 4 * m);
							}
						}
						else
						{
							num2 = 4294967295uL;
						}
						nodeConnections[num4] = num2;
					}
				}
			}
		}
	}
}
