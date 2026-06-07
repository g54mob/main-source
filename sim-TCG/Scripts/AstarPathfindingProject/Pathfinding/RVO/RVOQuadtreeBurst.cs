using System;
using Pathfinding.Drawing;
using Pathfinding.ECS.RVO;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	public struct RVOQuadtreeBurst
	{
		[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast)]
		public struct JobBuild : IJob
		{
			public NativeArray<int> agents;

			[ReadOnly]
			public NativeArray<float3> agentPositions;

			[ReadOnly]
			public NativeArray<AgentIndex> agentVersions;

			[ReadOnly]
			public NativeArray<float> agentSpeeds;

			[ReadOnly]
			public NativeArray<float> agentRadii;

			[WriteOnly]
			public NativeArray<float3> outBoundingBox;

			[WriteOnly]
			public NativeArray<int> outAgentCount;

			public NativeArray<int> outChildPointers;

			public NativeArray<float> outMaxSpeeds;

			public NativeArray<float> outMaxRadius;

			public NativeArray<float> outArea;

			[WriteOnly]
			public NativeArray<float3> outAgentPositions;

			[WriteOnly]
			public NativeArray<float> outAgentRadii;

			public int numAgents;

			public MovementPlane movementPlane;

			private static int Partition(NativeSlice<int> indices, int startIndex, int endIndex, NativeSlice<float> coordinates, float splitPoint)
			{
				for (int i = startIndex; i < endIndex; i++)
				{
					if (coordinates[indices[i]] > splitPoint)
					{
						endIndex--;
						int value = indices[i];
						indices[i] = indices[endIndex];
						indices[endIndex] = value;
						i--;
					}
				}
				return endIndex;
			}

			private void BuildNode(float3 boundsMin, float3 boundsMax, int depth, int agentsStart, int agentsEnd, int nodeOffset, ref int firstFreeChild)
			{
				if (agentsEnd - agentsStart > 16 && depth < 10)
				{
					if (movementPlane == MovementPlane.Arbitrary)
					{
						NativeSlice<float> coordinates = new NativeSlice<float3>(agentPositions).SliceWithStride<float>(0);
						NativeSlice<float> coordinates2 = new NativeSlice<float3>(agentPositions).SliceWithStride<float>(4);
						NativeSlice<float> coordinates3 = new NativeSlice<float3>(agentPositions).SliceWithStride<float>(8);
						float3 float5 = (boundsMin + boundsMax) * 0.5f;
						int num = Partition(agents, agentsStart, agentsEnd, coordinates, float5.x);
						int num2 = Partition(agents, agentsStart, num, coordinates2, float5.y);
						int num3 = Partition(agents, num, agentsEnd, coordinates2, float5.y);
						int num4 = Partition(agents, agentsStart, num2, coordinates3, float5.z);
						int num5 = Partition(agents, num2, num, coordinates3, float5.z);
						int num6 = Partition(agents, num, num3, coordinates3, float5.z);
						int num7 = Partition(agents, num3, agentsEnd, coordinates3, float5.z);
						int num8 = firstFreeChild;
						outChildPointers[nodeOffset] = num8;
						firstFreeChild += 8;
						float3 float6 = boundsMin;
						float3 float7 = float5;
						float3 float8 = boundsMax;
						BuildNode(new float3(float6.x, float6.y, float6.z), new float3(float7.x, float7.y, float7.z), depth + 1, agentsStart, num4, num8, ref firstFreeChild);
						BuildNode(new float3(float6.x, float6.y, float7.z), new float3(float7.x, float7.y, float8.z), depth + 1, num4, num2, num8 + 1, ref firstFreeChild);
						BuildNode(new float3(float6.x, float7.y, float6.z), new float3(float7.x, float8.y, float7.z), depth + 1, num2, num5, num8 + 2, ref firstFreeChild);
						BuildNode(new float3(float6.x, float7.y, float7.z), new float3(float7.x, float8.y, float8.z), depth + 1, num5, num, num8 + 3, ref firstFreeChild);
						BuildNode(new float3(float7.x, float6.y, float6.z), new float3(float8.x, float7.y, float7.z), depth + 1, num, num6, num8 + 4, ref firstFreeChild);
						BuildNode(new float3(float7.x, float6.y, float7.z), new float3(float8.x, float7.y, float8.z), depth + 1, num6, num3, num8 + 5, ref firstFreeChild);
						BuildNode(new float3(float7.x, float7.y, float6.z), new float3(float8.x, float8.y, float7.z), depth + 1, num3, num7, num8 + 6, ref firstFreeChild);
						BuildNode(new float3(float7.x, float7.y, float7.z), new float3(float8.x, float8.y, float8.z), depth + 1, num7, agentsEnd, num8 + 7, ref firstFreeChild);
					}
					else if (movementPlane == MovementPlane.XY)
					{
						NativeSlice<float> coordinates4 = new NativeSlice<float3>(agentPositions).SliceWithStride<float>(0);
						NativeSlice<float> coordinates5 = new NativeSlice<float3>(agentPositions).SliceWithStride<float>(4);
						float3 float9 = (boundsMin + boundsMax) * 0.5f;
						int num9 = Partition(agents, agentsStart, agentsEnd, coordinates4, float9.x);
						int num10 = Partition(agents, agentsStart, num9, coordinates5, float9.y);
						int num11 = Partition(agents, num9, agentsEnd, coordinates5, float9.y);
						int num12 = firstFreeChild;
						outChildPointers[nodeOffset] = num12;
						firstFreeChild += 4;
						BuildNode(new float3(boundsMin.x, boundsMin.y, boundsMin.z), new float3(float9.x, float9.y, boundsMax.z), depth + 1, agentsStart, num10, num12, ref firstFreeChild);
						BuildNode(new float3(boundsMin.x, float9.y, boundsMin.z), new float3(float9.x, boundsMax.y, boundsMax.z), depth + 1, num10, num9, num12 + 1, ref firstFreeChild);
						BuildNode(new float3(float9.x, boundsMin.y, boundsMin.z), new float3(boundsMax.x, float9.y, boundsMax.z), depth + 1, num9, num11, num12 + 2, ref firstFreeChild);
						BuildNode(new float3(float9.x, float9.y, boundsMin.z), new float3(boundsMax.x, boundsMax.y, boundsMax.z), depth + 1, num11, agentsEnd, num12 + 3, ref firstFreeChild);
					}
					else
					{
						NativeSlice<float> coordinates6 = new NativeSlice<float3>(agentPositions).SliceWithStride<float>(0);
						NativeSlice<float> coordinates7 = new NativeSlice<float3>(agentPositions).SliceWithStride<float>(8);
						float3 float10 = (boundsMin + boundsMax) * 0.5f;
						int num13 = Partition(agents, agentsStart, agentsEnd, coordinates6, float10.x);
						int num14 = Partition(agents, agentsStart, num13, coordinates7, float10.z);
						int num15 = Partition(agents, num13, agentsEnd, coordinates7, float10.z);
						int num16 = firstFreeChild;
						outChildPointers[nodeOffset] = num16;
						firstFreeChild += 4;
						BuildNode(new float3(boundsMin.x, boundsMin.y, boundsMin.z), new float3(float10.x, boundsMax.y, float10.z), depth + 1, agentsStart, num14, num16, ref firstFreeChild);
						BuildNode(new float3(boundsMin.x, boundsMin.y, float10.z), new float3(float10.x, boundsMax.y, boundsMax.z), depth + 1, num14, num13, num16 + 1, ref firstFreeChild);
						BuildNode(new float3(float10.x, boundsMin.y, boundsMin.z), new float3(boundsMax.x, boundsMax.y, float10.z), depth + 1, num13, num15, num16 + 2, ref firstFreeChild);
						BuildNode(new float3(float10.x, boundsMin.y, float10.z), new float3(boundsMax.x, boundsMax.y, boundsMax.z), depth + 1, num15, agentsEnd, num16 + 3, ref firstFreeChild);
					}
				}
				else
				{
					outChildPointers[nodeOffset] = agentsStart | (agentsEnd << 15) | 0x40000000;
				}
			}

			private void CalculateSpeeds(int nodeCount)
			{
				for (int num = nodeCount - 1; num >= 0; num--)
				{
					if ((outChildPointers[num] & 0x40000000) != 0)
					{
						int num2 = outChildPointers[num] & 0x7FFF;
						int num3 = (outChildPointers[num] >> 15) & 0x7FFF;
						float num4 = 0f;
						for (int i = num2; i < num3; i++)
						{
							num4 = math.max(num4, agentSpeeds[agents[i]]);
						}
						outMaxSpeeds[num] = num4;
						float num5 = 0f;
						for (int j = num2; j < num3; j++)
						{
							num5 = math.max(num5, agentRadii[agents[j]]);
						}
						outMaxRadius[num] = num5;
						float num6 = 0f;
						for (int k = num2; k < num3; k++)
						{
							num6 += agentRadii[agents[k]] * agentRadii[agents[k]];
						}
						outArea[num] = num6;
					}
					else
					{
						int num7 = outChildPointers[num];
						if (movementPlane == MovementPlane.Arbitrary)
						{
							float num8 = 0f;
							float num9 = 0f;
							float num10 = 0f;
							for (int l = 0; l < 8; l++)
							{
								num8 = math.max(num8, outMaxSpeeds[num7 + l]);
								num9 = math.max(num9, outMaxSpeeds[num7 + l]);
								num10 += outArea[num7 + l];
							}
							outMaxSpeeds[num] = num8;
							outMaxRadius[num] = num9;
							outArea[num] = num10;
						}
						else
						{
							outMaxSpeeds[num] = math.max(math.max(outMaxSpeeds[num7], outMaxSpeeds[num7 + 1]), math.max(outMaxSpeeds[num7 + 2], outMaxSpeeds[num7 + 3]));
							outMaxRadius[num] = math.max(math.max(outMaxRadius[num7], outMaxRadius[num7 + 1]), math.max(outMaxRadius[num7 + 2], outMaxRadius[num7 + 3]));
							outArea[num] = outArea[num7] + outArea[num7 + 1] + outArea[num7 + 2] + outArea[num7 + 3];
						}
					}
				}
			}

			public void Execute()
			{
				float3 float5 = float.PositiveInfinity;
				float3 float6 = float.NegativeInfinity;
				int num = 0;
				for (int i = 0; i < numAgents; i++)
				{
					if (agentVersions[i].Valid)
					{
						agents[num++] = i;
						float5 = math.min(float5, agentPositions[i]);
						float6 = math.max(float6, agentPositions[i]);
					}
				}
				outAgentCount[0] = num;
				if (num == 0)
				{
					ref NativeArray<float3> reference = ref outBoundingBox;
					float3 value = (outBoundingBox[1] = float3.zero);
					reference[0] = value;
					return;
				}
				outBoundingBox[0] = float5;
				outBoundingBox[1] = float6;
				int firstFreeChild = 1;
				BuildNode(float5, float6, 0, 0, num, 0, ref firstFreeChild);
				CalculateSpeeds(firstFreeChild);
				NativeArray<float3>.Copy(agentPositions, outAgentPositions, numAgents);
				NativeArray<float>.Copy(agentRadii, outAgentRadii, numAgents);
			}
		}

		public struct QuadtreeQuery
		{
			public float3 position;

			public float speed;

			public float timeHorizon;

			public float agentRadius;

			public int outputStartIndex;

			public int maxCount;

			public NativeArray<int> result;

			public NativeArray<float> resultDistances;
		}

		[BurstCompile]
		public struct DebugDrawJob : IJob
		{
			public CommandBuilder draw;

			[ReadOnly]
			public RVOQuadtreeBurst quadtree;

			public void Execute()
			{
				quadtree.DebugDraw(draw);
			}
		}

		private const int LeafSize = 16;

		private const int MaxDepth = 10;

		private NativeArray<int> agents;

		private NativeArray<int> childPointers;

		private NativeArray<float3> boundingBoxBuffer;

		private NativeArray<int> agentCountBuffer;

		private NativeArray<float3> agentPositions;

		private NativeArray<float> agentRadii;

		private NativeArray<float> maxSpeeds;

		private NativeArray<float> maxRadius;

		private NativeArray<float> nodeAreas;

		private MovementPlane movementPlane;

		private const int LeafNodeBit = 1073741824;

		private const int BitPackingShift = 15;

		private const int BitPackingMask = 32767;

		private const int MaxAgents = 32767;

		private static readonly byte[] ChildLookup;

		public Rect bounds
		{
			get
			{
				if (!boundingBoxBuffer.IsCreated)
				{
					return default(Rect);
				}
				return Rect.MinMaxRect(boundingBoxBuffer[0].x, boundingBoxBuffer[0].y, boundingBoxBuffer[1].x, boundingBoxBuffer[1].y);
			}
		}

		static RVOQuadtreeBurst()
		{
			ChildLookup = new byte[256];
			for (int i = 0; i < 256; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (((i >> j) & 1) != 0)
					{
						ChildLookup[i] = (byte)j;
						break;
					}
				}
			}
		}

		private static int InnerNodeCountUpperBound(int numAgents, MovementPlane movementPlane)
		{
			return (((movementPlane == MovementPlane.Arbitrary) ? 8 : 4) * 10 * numAgents + 16 - 1) / 16;
		}

		public void Dispose()
		{
			agents.Dispose();
			childPointers.Dispose();
			boundingBoxBuffer.Dispose();
			agentCountBuffer.Dispose();
			maxSpeeds.Dispose();
			maxRadius.Dispose();
			nodeAreas.Dispose();
			agentPositions.Dispose();
			agentRadii.Dispose();
		}

		private void Reserve(int minSize)
		{
			if (!boundingBoxBuffer.IsCreated)
			{
				boundingBoxBuffer = new NativeArray<float3>(4, Allocator.Persistent);
				agentCountBuffer = new NativeArray<int>(1, Allocator.Persistent);
			}
			int num = math.ceilpow2(minSize);
			Memory.Realloc(ref agents, num, Allocator.Persistent);
			Memory.Realloc(ref agentPositions, num, Allocator.Persistent);
			Memory.Realloc(ref agentRadii, num, Allocator.Persistent);
			Memory.Realloc(ref childPointers, InnerNodeCountUpperBound(num, movementPlane), Allocator.Persistent);
			Memory.Realloc(ref maxSpeeds, childPointers.Length, Allocator.Persistent);
			Memory.Realloc(ref nodeAreas, childPointers.Length, Allocator.Persistent);
			Memory.Realloc(ref maxRadius, childPointers.Length, Allocator.Persistent);
		}

		public JobBuild BuildJob(NativeArray<float3> agentPositions, NativeArray<AgentIndex> agentVersions, NativeArray<float> agentSpeeds, NativeArray<float> agentRadii, int numAgents, MovementPlane movementPlane)
		{
			if (numAgents >= 32767)
			{
				throw new Exception("Too many agents. Cannot have more than " + 32767);
			}
			Reserve(numAgents);
			this.movementPlane = movementPlane;
			return new JobBuild
			{
				agents = agents,
				agentVersions = agentVersions,
				agentPositions = agentPositions,
				agentSpeeds = agentSpeeds,
				agentRadii = agentRadii,
				outMaxSpeeds = maxSpeeds,
				outMaxRadius = maxRadius,
				outArea = nodeAreas,
				outAgentRadii = this.agentRadii,
				outAgentPositions = this.agentPositions,
				outBoundingBox = boundingBoxBuffer,
				outAgentCount = agentCountBuffer,
				outChildPointers = childPointers,
				numAgents = numAgents,
				movementPlane = movementPlane
			};
		}

		public void QueryKNearest(QuadtreeQuery query)
		{
			if (agents.IsCreated)
			{
				float num = float.PositiveInfinity;
				for (int i = 0; i < query.maxCount; i++)
				{
					query.result[query.outputStartIndex + i] = -1;
				}
				for (int j = 0; j < query.maxCount; j++)
				{
					query.resultDistances[j] = float.PositiveInfinity;
				}
				QueryRec(ref query, 0, boundingBoxBuffer[0], boundingBoxBuffer[1], ref num);
			}
		}

		private void QueryRec(ref QuadtreeQuery query, int treeNodeIndex, float3 nodeMin, float3 nodeMax, ref float maxRadius)
		{
			float num = math.min(math.max((maxSpeeds[treeNodeIndex] + query.speed) * query.timeHorizon, query.agentRadius) + query.agentRadius, maxRadius);
			float3 position = query.position;
			if ((childPointers[treeNodeIndex] & 0x40000000) != 0)
			{
				int maxCount = query.maxCount;
				int num2 = childPointers[treeNodeIndex] & 0x7FFF;
				int num3 = (childPointers[treeNodeIndex] >> 15) & 0x7FFF;
				NativeArray<int> result = query.result;
				NativeArray<float> resultDistances = query.resultDistances;
				for (int i = num2; i < num3; i++)
				{
					int num4 = agents[i];
					float num5 = math.lengthsq(position - agentPositions[num4]);
					if (!(num5 < num * num))
					{
						continue;
					}
					for (int j = 0; j < maxCount; j++)
					{
						if (num5 < resultDistances[j])
						{
							for (int num6 = maxCount - 1; num6 > j; num6--)
							{
								result[query.outputStartIndex + num6] = result[query.outputStartIndex + num6 - 1];
								resultDistances[num6] = resultDistances[num6 - 1];
							}
							result[query.outputStartIndex + j] = num4;
							resultDistances[j] = num5;
							if (j == maxCount - 1)
							{
								maxRadius = math.min(maxRadius, math.sqrt(num5));
								num = math.min(num, maxRadius);
							}
							break;
						}
					}
				}
				return;
			}
			int num7 = childPointers[treeNodeIndex];
			float3 float5 = (nodeMin + nodeMax) * 0.5f;
			if (movementPlane == MovementPlane.Arbitrary)
			{
				int num8 = ((!(position.x < float5.x)) ? 4 : 0) | ((!(position.y < float5.y)) ? 2 : 0) | ((!(position.z < float5.z)) ? 1 : 0);
				bool3 c = new bool3((num8 & 4) != 0, (num8 & 2) != 0, (num8 & 1) != 0);
				float3 nodeMin2 = math.select(nodeMin, float5, c);
				float3 nodeMax2 = math.select(float5, nodeMax, c);
				QueryRec(ref query, num7 + num8, nodeMin2, nodeMax2, ref maxRadius);
				num = math.min(num, maxRadius);
				bool3 c2 = position - num < float5;
				bool3 c3 = position + num > float5;
				int3 obj = math.select(new int3(240, 204, 170), new int3(255, 255, 255), c2);
				int3 int5 = math.select(new int3(15, 51, 85), new int3(255, 255, 255), c3);
				int3 int6 = obj & int5;
				int num9 = int6.x & int6.y & int6.z;
				num9 &= ~(1 << num8);
				while (num9 != 0)
				{
					byte b = ChildLookup[num9];
					bool3 c4 = new bool3((b & 4) != 0, (b & 2) != 0, (b & 1) != 0);
					float3 nodeMin3 = math.select(nodeMin, float5, c4);
					float3 nodeMax3 = math.select(float5, nodeMax, c4);
					QueryRec(ref query, num7 + b, nodeMin3, nodeMax3, ref maxRadius);
					num = math.min(num, maxRadius);
					num9 &= ~(1 << (int)b);
				}
			}
			else if (movementPlane == MovementPlane.XY)
			{
				int num10 = ((!(position.x < float5.x)) ? 2 : 0) | ((!(position.y < float5.y)) ? 1 : 0);
				bool3 c5 = new bool3((num10 & 2) != 0, (num10 & 1) != 0, z: false);
				float3 nodeMin4 = math.select(nodeMin, float5, c5);
				float3 nodeMax4 = math.select(float5, nodeMax, c5);
				QueryRec(ref query, num7 + num10, nodeMin4, nodeMax4, ref maxRadius);
				num = math.min(num, maxRadius);
				bool2 bool5 = position.xy - num < float5.xy;
				bool2 bool6 = position.xy + num > float5.xy;
				bool4 bool7 = new bool4(bool5.x & bool5.y, bool5.x & bool6.y, bool6.x & bool5.y, bool6.x & bool6.y);
				int num11 = (bool7.x ? 1 : 0) | (bool7.y ? 2 : 0) | (bool7.z ? 4 : 0) | (bool7.w ? 8 : 0);
				num11 &= ~(1 << num10);
				while (num11 != 0)
				{
					byte b2 = ChildLookup[num11];
					bool3 c6 = new bool3((b2 & 2) != 0, (b2 & 1) != 0, z: false);
					float3 nodeMin5 = math.select(nodeMin, float5, c6);
					float3 nodeMax5 = math.select(float5, nodeMax, c6);
					QueryRec(ref query, num7 + b2, nodeMin5, nodeMax5, ref maxRadius);
					num = math.min(num, maxRadius);
					num11 &= ~(1 << (int)b2);
				}
			}
			else
			{
				int num12 = ((!(position.x < float5.x)) ? 2 : 0) | ((!(position.z < float5.z)) ? 1 : 0);
				bool3 c7 = new bool3((num12 & 2) != 0, y: false, (num12 & 1) != 0);
				float3 nodeMin6 = math.select(nodeMin, float5, c7);
				float3 nodeMax6 = math.select(float5, nodeMax, c7);
				QueryRec(ref query, num7 + num12, nodeMin6, nodeMax6, ref maxRadius);
				num = math.min(num, maxRadius);
				bool2 bool8 = position.xz - num < float5.xz;
				bool2 bool9 = position.xz + num > float5.xz;
				bool4 bool10 = new bool4(bool8.x & bool8.y, bool8.x & bool9.y, bool9.x & bool8.y, bool9.x & bool9.y);
				int num13 = (bool10.x ? 1 : 0) | (bool10.y ? 2 : 0) | (bool10.z ? 4 : 0) | (bool10.w ? 8 : 0);
				num13 &= ~(1 << num12);
				while (num13 != 0)
				{
					byte b3 = ChildLookup[num13];
					bool3 c8 = new bool3((b3 & 2) != 0, y: false, (b3 & 1) != 0);
					float3 nodeMin7 = math.select(nodeMin, float5, c8);
					float3 nodeMax7 = math.select(float5, nodeMax, c8);
					QueryRec(ref query, num7 + b3, nodeMin7, nodeMax7, ref maxRadius);
					num = math.min(num, maxRadius);
					num13 &= ~(1 << (int)b3);
				}
			}
		}

		public float QueryArea(float3 position, float radius)
		{
			if (!agents.IsCreated || agentCountBuffer[0] == 0)
			{
				return 0f;
			}
			return MathF.PI * QueryAreaRec(0, position, radius, boundingBoxBuffer[0], boundingBoxBuffer[1]);
		}

		private float QueryAreaRec(int treeNodeIndex, float3 p, float radius, float3 nodeMin, float3 nodeMax)
		{
			float3 float5 = (nodeMin + nodeMax) * 0.5f;
			float num = math.length(nodeMax - float5);
			float num2 = math.lengthsq(float5 - p);
			float num3 = maxRadius[treeNodeIndex];
			float num4 = radius - (num + num3);
			if (num4 > 0f && num2 < num4 * num4)
			{
				return nodeAreas[treeNodeIndex];
			}
			if (num2 > (radius + (num + num3)) * (radius + (num + num3)))
			{
				return 0f;
			}
			if ((childPointers[treeNodeIndex] & 0x40000000) != 0)
			{
				int num5 = childPointers[treeNodeIndex] & 0x7FFF;
				int num6 = (childPointers[treeNodeIndex] >> 15) & 0x7FFF;
				float num7 = 0f;
				float num8 = 0f;
				for (int i = num5; i < num6; i++)
				{
					int index = agents[i];
					num7 += agentRadii[index] * agentRadii[index];
					float num9 = math.lengthsq(p - agentPositions[index]);
					float num10 = agentRadii[index];
					if (num9 < (radius + num10) * (radius + num10))
					{
						float num11 = radius - num10;
						float num12 = ((num9 < num11 * num11) ? 1f : (1f - (math.sqrt(num9) - num11) / (2f * num10)));
						num8 += num10 * num10 * num12;
					}
				}
				return num8;
			}
			float num13 = 0f;
			int num14 = childPointers[treeNodeIndex];
			float num15 = radius + num3;
			if (movementPlane == MovementPlane.Arbitrary)
			{
				bool3 bool5 = p - num15 < float5;
				bool3 bool6 = p + num15 > float5;
				if (bool5[0])
				{
					if (bool5[1])
					{
						if (bool5[2])
						{
							num13 += QueryAreaRec(num14, p, radius, new float3(nodeMin.x, nodeMin.y, nodeMin.z), new float3(float5.x, float5.y, float5.z));
						}
						if (bool6[2])
						{
							num13 += QueryAreaRec(num14 + 1, p, radius, new float3(nodeMin.x, nodeMin.y, float5.z), new float3(float5.x, float5.y, nodeMax.z));
						}
					}
					if (bool6[1])
					{
						if (bool5[2])
						{
							num13 += QueryAreaRec(num14 + 2, p, radius, new float3(nodeMin.x, float5.y, nodeMin.z), new float3(float5.x, nodeMax.y, float5.z));
						}
						if (bool6[2])
						{
							num13 += QueryAreaRec(num14 + 3, p, radius, new float3(nodeMin.x, float5.y, float5.z), new float3(float5.x, nodeMax.y, nodeMax.z));
						}
					}
				}
				if (bool6[0])
				{
					if (bool5[1])
					{
						if (bool5[2])
						{
							num13 += QueryAreaRec(num14 + 4, p, radius, new float3(float5.x, nodeMin.y, nodeMin.z), new float3(nodeMax.x, float5.y, float5.z));
						}
						if (bool6[2])
						{
							num13 += QueryAreaRec(num14 + 5, p, radius, new float3(float5.x, nodeMin.y, float5.z), new float3(nodeMax.x, float5.y, nodeMax.z));
						}
					}
					if (bool6[1])
					{
						if (bool5[2])
						{
							num13 += QueryAreaRec(num14 + 6, p, radius, new float3(float5.x, float5.y, nodeMin.z), new float3(nodeMax.x, nodeMax.y, float5.z));
						}
						if (bool6[2])
						{
							num13 += QueryAreaRec(num14 + 7, p, radius, new float3(float5.x, float5.y, float5.z), new float3(nodeMax.x, nodeMax.y, nodeMax.z));
						}
					}
				}
			}
			else if (movementPlane == MovementPlane.XY)
			{
				bool2 bool7 = (p - num15).xy < float5.xy;
				bool2 bool8 = (p + num15).xy > float5.xy;
				if (bool7[0])
				{
					if (bool7[1])
					{
						num13 += QueryAreaRec(num14, p, radius, new float3(nodeMin.x, nodeMin.y, nodeMin.z), new float3(float5.x, float5.y, nodeMax.z));
					}
					if (bool8[1])
					{
						num13 += QueryAreaRec(num14 + 1, p, radius, new float3(nodeMin.x, float5.y, nodeMin.z), new float3(float5.x, nodeMax.y, nodeMax.z));
					}
				}
				if (bool8[0])
				{
					if (bool7[1])
					{
						num13 += QueryAreaRec(num14 + 2, p, radius, new float3(float5.x, nodeMin.y, nodeMin.z), new float3(nodeMax.x, float5.y, nodeMax.z));
					}
					if (bool8[1])
					{
						num13 += QueryAreaRec(num14 + 3, p, radius, new float3(float5.x, float5.y, nodeMin.z), new float3(nodeMax.x, nodeMax.y, nodeMax.z));
					}
				}
			}
			else
			{
				bool2 bool9 = (p - num15).xz < float5.xz;
				bool2 bool10 = (p + num15).xz > float5.xz;
				if (bool9[0])
				{
					if (bool9[1])
					{
						num13 += QueryAreaRec(num14, p, radius, new float3(nodeMin.x, nodeMin.y, nodeMin.z), new float3(float5.x, nodeMax.y, float5.z));
					}
					if (bool10[1])
					{
						num13 += QueryAreaRec(num14 + 1, p, radius, new float3(nodeMin.x, nodeMin.y, float5.z), new float3(float5.x, nodeMax.y, nodeMax.z));
					}
				}
				if (bool10[0])
				{
					if (bool9[1])
					{
						num13 += QueryAreaRec(num14 + 2, p, radius, new float3(float5.x, nodeMin.y, nodeMin.z), new float3(nodeMax.x, nodeMax.y, float5.z));
					}
					if (bool10[1])
					{
						num13 += QueryAreaRec(num14 + 3, p, radius, new float3(float5.x, nodeMin.y, float5.z), new float3(nodeMax.x, nodeMax.y, nodeMax.z));
					}
				}
			}
			return num13;
		}

		public void DebugDraw(CommandBuilder draw)
		{
			if (!agentCountBuffer.IsCreated)
			{
				return;
			}
			int num = agentCountBuffer[0];
			if (num != 0)
			{
				DebugDraw(0, boundingBoxBuffer[0], boundingBoxBuffer[1], draw);
				for (int i = 0; i < num; i++)
				{
					draw.Cross(agentPositions[agents[i]], 0.5f, Palette.Colorbrewer.Set1.Red);
				}
			}
		}

		private void DebugDraw(int nodeIndex, float3 nodeMin, float3 nodeMax, CommandBuilder draw)
		{
			float3 float5 = (nodeMin + nodeMax) * 0.5f;
			draw.WireBox(float5, nodeMax - nodeMin, Palette.Colorbrewer.Set1.Orange);
			if ((childPointers[nodeIndex] & 0x40000000) != 0)
			{
				int num = childPointers[nodeIndex] & 0x7FFF;
				int num2 = (childPointers[nodeIndex] >> 15) & 0x7FFF;
				for (int i = num; i < num2; i++)
				{
					draw.Line(float5, agentPositions[agents[i]], Color.black);
				}
				return;
			}
			int num3 = childPointers[nodeIndex];
			if (movementPlane == MovementPlane.Arbitrary)
			{
				DebugDraw(num3, new float3(nodeMin.x, nodeMin.y, nodeMin.z), new float3(float5.x, float5.y, float5.z), draw);
				DebugDraw(num3 + 1, new float3(nodeMin.x, nodeMin.y, float5.z), new float3(float5.x, float5.y, nodeMax.z), draw);
				DebugDraw(num3 + 2, new float3(nodeMin.x, float5.y, nodeMin.z), new float3(float5.x, nodeMax.y, float5.z), draw);
				DebugDraw(num3 + 3, new float3(nodeMin.x, float5.y, float5.z), new float3(float5.x, nodeMax.y, nodeMax.z), draw);
				DebugDraw(num3 + 4, new float3(float5.x, nodeMin.y, nodeMin.z), new float3(nodeMax.x, float5.y, float5.z), draw);
				DebugDraw(num3 + 5, new float3(float5.x, nodeMin.y, float5.z), new float3(nodeMax.x, float5.y, nodeMax.z), draw);
				DebugDraw(num3 + 6, new float3(float5.x, float5.y, nodeMin.z), new float3(nodeMax.x, nodeMax.y, float5.z), draw);
				DebugDraw(num3 + 7, new float3(float5.x, float5.y, float5.z), new float3(nodeMax.x, nodeMax.y, nodeMax.z), draw);
			}
			else if (movementPlane == MovementPlane.XY)
			{
				DebugDraw(num3, new float3(nodeMin.x, nodeMin.y, nodeMin.z), new float3(float5.x, float5.y, nodeMax.z), draw);
				DebugDraw(num3 + 1, new float3(nodeMin.x, float5.y, nodeMin.z), new float3(float5.x, nodeMax.y, nodeMax.z), draw);
				DebugDraw(num3 + 2, new float3(float5.x, nodeMin.y, nodeMin.z), new float3(nodeMax.x, float5.y, nodeMax.z), draw);
				DebugDraw(num3 + 3, new float3(float5.x, float5.y, nodeMin.z), new float3(nodeMax.x, nodeMax.y, nodeMax.z), draw);
			}
			else
			{
				DebugDraw(num3, new float3(nodeMin.x, nodeMin.y, nodeMin.z), new float3(float5.x, nodeMax.y, float5.z), draw);
				DebugDraw(num3 + 1, new float3(nodeMin.x, nodeMin.y, float5.z), new float3(float5.x, nodeMax.y, nodeMax.z), draw);
				DebugDraw(num3 + 2, new float3(float5.x, nodeMin.y, nodeMin.z), new float3(nodeMax.x, nodeMax.y, float5.z), draw);
				DebugDraw(num3 + 3, new float3(float5.x, nodeMin.y, float5.z), new float3(nodeMax.x, nodeMax.y, nodeMax.z), draw);
			}
		}
	}
}
