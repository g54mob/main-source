using System.Collections.Generic;
using Pathfinding.Drawing;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.RVO
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Default)]
	public struct JobRVO<MovementPlaneWrapper> : IJobParallelForBatched where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		private struct SortByKey : IComparer<int>
		{
			public UnsafeSpan<float> keys;

			public int Compare(int x, int y)
			{
				return keys[x].CompareTo(keys[y]);
			}
		}

		private struct ORCALine
		{
			public float2 point;

			public float2 direction;

			public void DrawAsHalfPlane(CommandBuilder draw, float halfPlaneLength, float halfPlaneWidth, Color color)
			{
				float2 float5 = new float2(direction.y, 0f - direction.x);
				draw.xy.Line(point - direction * 10f, point + direction * 10f, color);
				float2 xy = point + float5 * halfPlaneWidth * 0.5f;
				draw.SolidBox(new float3(xy, 0f), quaternion.RotateZ(math.atan2(direction.y, direction.x)), new float3(halfPlaneLength, halfPlaneWidth, 0.01f), new Color(0f, 0f, 0f, 0.5f));
			}

			public ORCALine(float2 position, float2 relativePosition, float2 velocity, float2 otherVelocity, float combinedRadius, float timeStep, float invTimeHorizon)
			{
				float2 float5 = velocity - otherVelocity;
				float num = combinedRadius * combinedRadius;
				float num2 = math.lengthsq(relativePosition);
				if (num2 > num)
				{
					combinedRadius *= 1.001f;
					float2 float6 = float5 - invTimeHorizon * relativePosition;
					float num3 = math.lengthsq(float6);
					float num4 = math.dot(float6, relativePosition);
					if (num4 < 0f && num4 * num4 > num * num3)
					{
						float num5 = math.sqrt(num3);
						float2 float7 = float6 / num5;
						direction = new float2(float7.y, 0f - float7.x);
						float2 float8 = (combinedRadius * invTimeHorizon - num5) * float7;
						point = velocity + 0.5f * float8;
						return;
					}
					float num6 = math.sqrt(num2 - num);
					if (JobRVO<MovementPlaneWrapper>.det(relativePosition, float6) > 0f)
					{
						direction = (relativePosition * num6 + new float2(0f - relativePosition.y, relativePosition.x) * combinedRadius) / num2;
					}
					else
					{
						direction = (-relativePosition * num6 + new float2(0f - relativePosition.y, relativePosition.x) * combinedRadius) / num2;
					}
					float2 float9 = math.dot(float5, direction) * direction - float5;
					point = velocity + 0.5f * float9;
				}
				else
				{
					float num7 = math.rcp(timeStep);
					float num8 = math.sqrt(num2);
					float2 float10 = math.select(0, relativePosition / num8, num8 > 1.1754944E-38f) * (num8 - combinedRadius - 0.001f) * 0.3f * num7;
					direction = math.normalizesafe(new float2(float10.y, 0f - float10.x));
					point = math.lerp(velocity, otherVelocity, 0.5f) + float10 * 0.5f;
				}
			}
		}

		private struct LinearProgram2Output
		{
			public float2 velocity;

			public int firstFailedLineIndex;
		}

		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public SimulatorBurst.TemporaryAgentData temporaryAgentData;

		[ReadOnly]
		public NavmeshEdges.NavmeshBorderData navmeshEdgeData;

		[WriteOnly]
		public SimulatorBurst.AgentOutputData output;

		public float deltaTime;

		public float symmetryBreakingBias;

		public float priorityMultiplier;

		public bool useNavmeshAsObstacle;

		private const int MaxObstacleCount = 50;

		public CommandBuilder draw;

		private static readonly ProfilerMarker MarkerConvertObstacles1 = new ProfilerMarker("RVOConvertObstacles1");

		private static readonly ProfilerMarker MarkerConvertObstacles2 = new ProfilerMarker("RVOConvertObstacles2");

		public bool allowBoundsChecks => true;

		public void Execute(int startIndex, int batchSize)
		{
			ExecuteORCA(startIndex, batchSize);
		}

		private static void InsertionSort<T, U>(UnsafeSpan<T> data, U comparer) where T : unmanaged where U : IComparer<T>
		{
			for (int i = 1; i < data.Length; i++)
			{
				T val = data[i];
				int num = i - 1;
				while (num >= 0 && comparer.Compare(data[num], val) > 0)
				{
					data[num + 1] = data[num];
					num--;
				}
				data[num + 1] = val;
			}
		}

		private void GenerateObstacleVOs(int agentIndex, NativeList<int> adjacentObstacleIdsScratch, NativeArray<int2> adjacentObstacleVerticesScratch, NativeArray<float> segmentDistancesScratch, NativeArray<int> sortedVerticesScratch, NativeArray<ORCALine> orcaLines, NativeArray<int> orcaLineToAgent, [NoAlias] ref int numLines, [NoAlias] in MovementPlaneWrapper movementPlane, float2 optimalVelocity)
		{
			if (!useNavmeshAsObstacle)
			{
				return;
			}
			float elevation;
			float2 float5 = movementPlane.ToPlane(agentData.position[agentIndex], out elevation);
			float num = agentData.height[agentIndex];
			float num2 = agentData.radius[agentIndex];
			float num3 = num2 * 0.01f;
			float num4 = math.rcp(agentData.obstacleTimeHorizon[agentIndex]);
			Aliasing.ExpectNotAliased(in agentData.collisionNormal, in agentData.position);
			int num5 = agentData.hierarchicalNodeIndex[agentIndex];
			if (num5 == -1)
			{
				return;
			}
			float3 float6 = (num3 + num2 + agentData.obstacleTimeHorizon[agentIndex] * agentData.maxSpeed[agentIndex]) * new float3(2f, 0f, 2f);
			float6.y = agentData.height[agentIndex] * 2f;
			Bounds bounds = new Bounds(new Vector3(float5.x, elevation, float5.y), float6);
			float num6 = math.lengthsq(bounds.extents);
			adjacentObstacleIdsScratch.Clear();
			Bounds bounds2 = movementPlane.ToWorld(bounds);
			navmeshEdgeData.GetObstaclesInRange(num5, bounds2, adjacentObstacleIdsScratch);
			for (int i = 0; i < adjacentObstacleIdsScratch.Length; i++)
			{
				int index = adjacentObstacleIdsScratch[i];
				UnmanagedObstacle unmanagedObstacle = navmeshEdgeData.obstacleData.obstacles[index];
				UnsafeSpan<float3> span = navmeshEdgeData.obstacleData.obstacleVertices.GetSpan(unmanagedObstacle.verticesAllocation);
				UnsafeSpan<ObstacleVertexGroup> span2 = navmeshEdgeData.obstacleData.obstacleVertexGroups.GetSpan(unmanagedObstacle.groupsAllocation);
				int num7 = 0;
				int num8 = 0;
				for (int j = 0; j < span2.Length; j++)
				{
					ObstacleVertexGroup obstacleVertexGroup = span2[j];
					if (!math.all((obstacleVertexGroup.boundsMx >= bounds2.min) & (obstacleVertexGroup.boundsMn <= bounds2.max)))
					{
						num7 += obstacleVertexGroup.vertexCount;
						continue;
					}
					int num9 = num7;
					int num10 = num7 + obstacleVertexGroup.vertexCount - 1;
					if (num10 >= adjacentObstacleVerticesScratch.Length)
					{
						break;
					}
					for (int k = num9; k < num9 + obstacleVertexGroup.vertexCount; k++)
					{
						adjacentObstacleVerticesScratch[k] = new int2(k - 1, k + 1);
					}
					adjacentObstacleVerticesScratch[num9] = new int2((obstacleVertexGroup.type == ObstacleType.Loop) ? num10 : num9, adjacentObstacleVerticesScratch[num9].y);
					adjacentObstacleVerticesScratch[num10] = new int2(adjacentObstacleVerticesScratch[num10].x, (obstacleVertexGroup.type == ObstacleType.Loop) ? num9 : num10);
					for (int l = 0; l < obstacleVertexGroup.vertexCount; l++)
					{
						float3 p = span[l + num7];
						int y = adjacentObstacleVerticesScratch[l + num9].y;
						float2 float7 = movementPlane.ToPlane(p) - float5;
						float2 float8 = movementPlane.ToPlane(span[y]) - float5 - float7;
						float num11 = ClosestPointOnSegment(float7, float8 / math.lengthsq(float8), float2.zero, 0f, 1f);
						float num12 = (segmentDistancesScratch[l + num9] = math.lengthsq(float7 + float8 * num11));
						if (num12 <= num6 && num8 < sortedVerticesScratch.Length)
						{
							sortedVerticesScratch[num8] = l + num9;
							num8++;
						}
					}
					num7 += obstacleVertexGroup.vertexCount;
				}
				InsertionSort(sortedVerticesScratch.AsUnsafeSpan().Slice(0, num8), new SortByKey
				{
					keys = segmentDistancesScratch.AsUnsafeSpan().Slice(0, num7)
				});
				for (int m = 0; m < num8 && numLines < 50; m++)
				{
					int num14 = sortedVerticesScratch[m];
					if (segmentDistancesScratch[num14] > 0.25f * float6.x * float6.x)
					{
						break;
					}
					int x = adjacentObstacleVerticesScratch[num14].x;
					int y2 = adjacentObstacleVerticesScratch[num14].y;
					if (y2 == num14)
					{
						continue;
					}
					int y3 = adjacentObstacleVerticesScratch[y2].y;
					float3 p2 = span[x];
					float3 p3 = span[num14];
					float3 p4 = span[y2];
					float3 p5 = span[y3];
					float2 float9 = movementPlane.ToPlane(p2) - float5;
					float elevation2;
					float2 float10 = movementPlane.ToPlane(p3, out elevation2) - float5;
					float elevation3;
					float2 float11 = movementPlane.ToPlane(p4, out elevation3) - float5;
					float2 float12 = movementPlane.ToPlane(p5) - float5;
					if (math.max(elevation2, elevation3) + num < elevation || math.min(elevation2, elevation3) > elevation + num)
					{
						continue;
					}
					float num15 = math.length(float11 - float10);
					if (num15 < 0.0001f)
					{
						continue;
					}
					float2 float13 = (float11 - float10) * math.rcp(num15);
					if (det(float13, -float10) > num3)
					{
						continue;
					}
					bool flag = false;
					for (int n = 0; n < numLines; n++)
					{
						ORCALine oRCALine = orcaLines[n];
						if (det(num4 * float10 - oRCALine.point, oRCALine.direction) - num4 * num3 >= -0.0001f && det(num4 * float11 - oRCALine.point, oRCALine.direction) - num4 * num3 >= -0.0001f)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
					float2 zero = float2.zero;
					float num16 = math.dot(zero - float10, float13);
					float2 float14 = float10 + num16 * float13;
					float num17 = math.lengthsq(float14 - zero);
					float num18 = math.lengthsq(float10 + math.clamp(num16, 0f, num15) * float13);
					bool flag2 = leftOrColinear(float10 - float9, float13);
					bool flag3 = leftOrColinear(float13, float12 - float11);
					if (num18 < num3 * num3)
					{
						if (num16 < 0f)
						{
							if (flag2)
							{
								orcaLineToAgent[numLines] = -1;
								orcaLines[numLines++] = new ORCALine
								{
									point = -float10 * 0.1f,
									direction = math.normalizesafe(rot90(float10))
								};
							}
						}
						else if (num16 > num15)
						{
							if (flag3 && leftOrColinear(float11, float12 - float11))
							{
								orcaLineToAgent[numLines] = -1;
								orcaLines[numLines++] = new ORCALine
								{
									point = -float11 * 0.1f,
									direction = math.normalizesafe(rot90(float11))
								};
							}
						}
						else
						{
							orcaLineToAgent[numLines] = -1;
							orcaLines[numLines++] = new ORCALine
							{
								point = -float14 * 0.1f,
								direction = -float13
							};
						}
						continue;
					}
					float2 float16;
					float2 float17;
					if ((num16 < 0f || num16 > 1f) && num17 <= num3 * num3)
					{
						if (num16 < 0f)
						{
							if (!flag2)
							{
								continue;
							}
							float12 = float11;
							float11 = float10;
							flag3 = flag2;
						}
						else
						{
							if (!flag3)
							{
								continue;
							}
							float9 = float10;
							float10 = float11;
							flag2 = flag3;
						}
						float num19 = math.lengthsq(float10);
						float num20 = math.sqrt(num19 - num3 * num3);
						float2 float15 = new float2(0f - float10.y, float10.x);
						float16 = (float10 * num20 + float15 * num3) / num19;
						float17 = (float10 * num20 - float15 * num3) / num19;
					}
					else
					{
						if (flag2)
						{
							float num21 = math.lengthsq(float10);
							float num22 = math.sqrt(num21 - num3 * num3);
							float2 float18 = new float2(0f - float10.y, float10.x);
							float16 = (float10 * num22 + float18 * num3) / num21;
						}
						else
						{
							float16 = -float13;
						}
						if (flag3)
						{
							float num23 = math.lengthsq(float11);
							float num24 = math.sqrt(num23 - num3 * num3);
							float2 float19 = new float2(0f - float11.y, float11.x);
							float17 = (float11 * num24 - float19 * num3) / num23;
						}
						else
						{
							float17 = float13;
						}
					}
					bool flag4 = false;
					bool flag5 = false;
					if (flag2 && left(float16, float9 - float10))
					{
						float16 = float9 - float10;
						flag4 = true;
					}
					if (flag3 && right(float17, float12 - float11))
					{
						float17 = float12 - float11;
						flag5 = true;
					}
					float2 float20 = num4 * float10;
					float2 float21 = num4 * float11;
					float2 float22 = float21 - float20;
					float num25 = math.lengthsq(float22);
					float num26 = ((num25 <= 1E-05f) ? 0.5f : (math.dot(optimalVelocity - float20, float22) / num25));
					float num27 = math.dot(optimalVelocity - float20, float16);
					float num28 = math.dot(optimalVelocity - float21, float17);
					if ((num26 < 0f && num27 < 0f) || (num26 > 1f && num28 < 0f) || (num25 <= 1E-05f && num27 < 0f && num28 < 0f))
					{
						float2 float23 = ((num26 <= 0.5f) ? float20 : float21);
						float2 float24 = math.normalizesafe(optimalVelocity - float23);
						orcaLineToAgent[numLines] = -1;
						orcaLines[numLines++] = new ORCALine
						{
							point = float23 + num3 * num4 * float24,
							direction = new float2(float24.y, 0f - float24.x)
						};
						continue;
					}
					float num29 = ((num26 > 1f || num26 < 0f || num25 < 0.0001f) ? float.PositiveInfinity : math.lengthsq(optimalVelocity - (float20 + num26 * float22)));
					float num30 = ((num27 < 0f) ? float.PositiveInfinity : math.lengthsq(optimalVelocity - (float20 + num27 * float16)));
					float num31 = ((num28 < 0f) ? float.PositiveInfinity : math.lengthsq(optimalVelocity - (float21 + num28 * float17)));
					int num32 = 0;
					float num33 = num29;
					if (num30 < num33)
					{
						num33 = num30;
						num32 = 1;
					}
					if (num31 < num33)
					{
						num33 = num31;
						num32 = 2;
					}
					switch (num32)
					{
					case 0:
						orcaLineToAgent[numLines] = -1;
						orcaLines[numLines++] = new ORCALine
						{
							point = float20 + num3 * num4 * new float2(float13.y, 0f - float13.x),
							direction = -float13
						};
						break;
					case 1:
						if (!flag4)
						{
							orcaLineToAgent[numLines] = -1;
							orcaLines[numLines++] = new ORCALine
							{
								point = float20 + num3 * num4 * new float2(0f - float16.y, float16.x),
								direction = float16
							};
						}
						break;
					case 2:
						if (!flag5)
						{
							orcaLineToAgent[numLines] = -1;
							orcaLines[numLines++] = new ORCALine
							{
								point = float21 + num3 * num4 * new float2(float17.y, 0f - float17.x),
								direction = -float17
							};
						}
						break;
					}
				}
			}
		}

		public void ExecuteORCA(int startIndex, int batchSize)
		{
			int num = startIndex + batchSize;
			NativeArray<ORCALine> nativeArray = new NativeArray<ORCALine>(100, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<ORCALine> scratchBuffer = new NativeArray<ORCALine>(100, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<float> segmentDistancesScratch = new NativeArray<float>(256, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<int> sortedVerticesScratch = new NativeArray<int>(256, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<int2> adjacentObstacleVerticesScratch = new NativeArray<int2>(1024, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeArray<int> orcaLineToAgent = new NativeArray<int>(100, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			NativeList<int> adjacentObstacleIdsScratch = new NativeList<int>(16, Allocator.Temp);
			for (int i = startIndex; i < num; i++)
			{
				if (!agentData.version[i].Valid)
				{
					continue;
				}
				if (agentData.manuallyControlled[i])
				{
					output.speed[i] = agentData.desiredSpeed[i];
					output.targetPoint[i] = agentData.targetPoint[i];
					output.blockedByAgents[i * 7] = -1;
					continue;
				}
				float3 float5 = agentData.position[i];
				if (agentData.locked[i])
				{
					output.speed[i] = 0f;
					output.targetPoint[i] = float5;
					output.blockedByAgents[i * 7] = -1;
					continue;
				}
				MovementPlaneWrapper movementPlane = default(MovementPlaneWrapper);
				movementPlane.Set(agentData.movementPlane[i]);
				float2 float6 = movementPlane.ToPlane(temporaryAgentData.currentVelocity[i]);
				int numLines = 0;
				GenerateObstacleVOs(i, adjacentObstacleIdsScratch, adjacentObstacleVerticesScratch, segmentDistancesScratch, sortedVerticesScratch, nativeArray, orcaLineToAgent, ref numLines, in movementPlane, float6);
				int num2 = numLines;
				NativeSlice<int> neighbours = temporaryAgentData.neighbours.Slice(i * 50, 50);
				float num3 = agentData.agentTimeHorizon[i];
				float num4 = math.rcp(num3);
				float num5 = agentData.priority[i];
				float2 position = movementPlane.ToPlane(float5);
				float num6 = agentData.radius[i];
				for (int j = 0; j < neighbours.Length; j++)
				{
					int num7 = neighbours[j];
					if (num7 == -1)
					{
						break;
					}
					float3 float7 = agentData.position[num7];
					float2 float8 = movementPlane.ToPlane(float7 - float5);
					float num8 = num6 + agentData.radius[num7];
					float num9 = agentData.priority[num7] * priorityMultiplier;
					float2 float9 = movementPlane.ToPlane(math.lerp(s: math.clamp(2f * ((!agentData.locked[num7] && !agentData.manuallyControlled[num7]) ? ((!(num9 > 1E-05f) && !(num5 > 1E-05f)) ? 0.5f : (num9 / (num5 + num9))) : 1f) - 1f, 0f, 1f), x: temporaryAgentData.currentVelocity[num7], y: temporaryAgentData.desiredVelocity[num7]));
					if (agentData.flowFollowingStrength[num7] > 0f)
					{
						float num10 = agentData.flowFollowingStrength[num7] * agentData.flowFollowingStrength[i];
						float2 float10 = math.normalizesafe(float8);
						float9 -= float10 * (num10 * math.min(0f, math.dot(float9, float10)));
					}
					float num11 = math.length(float8);
					float num12 = math.max(0f, num11 - num8) / math.max(num8, agentData.desiredSpeed[i] + agentData.desiredSpeed[num7]);
					float num13 = math.clamp((num12 * num4 - 0.5f) * 2f, 0f, 1f);
					num8 *= 1f - num13;
					float invTimeHorizon = 1f / math.max(0.1f * num3, num3 * math.clamp(math.sqrt(2f * num12), 0f, 1f));
					nativeArray[numLines] = new ORCALine(position, float8, float6, float9, num8, 0.1f, invTimeHorizon);
					orcaLineToAgent[numLines] = num7;
					numLines++;
				}
				float2 float11 = math.normalizesafe(movementPlane.ToPlane(agentData.collisionNormal[i]));
				if (math.any(float11 != 0f))
				{
					nativeArray[numLines] = new ORCALine
					{
						point = float2.zero,
						direction = new float2(float11.y, 0f - float11.x)
					};
					orcaLineToAgent[numLines] = -1;
					numLines++;
				}
				float2 desiredVelocity = movementPlane.ToPlane(temporaryAgentData.desiredVelocity[i]);
				float2 targetPointInVelocitySpace = temporaryAgentData.desiredTargetPointInVelocitySpace[i];
				float maxBiasRadians = symmetryBreakingBias * (1f - agentData.flowFollowingStrength[i]);
				if (!BiasDesiredVelocity(nativeArray.AsUnsafeSpan().Slice(num2, numLines - num2), ref desiredVelocity, ref targetPointInVelocitySpace, maxBiasRadians) && !(DistanceInsideVOs(nativeArray.AsUnsafeSpan().Slice(0, numLines), desiredVelocity) > 0f) && math.all(math.abs(temporaryAgentData.collisionVelocityOffsets[i]) < 0.001f))
				{
					output.targetPoint[i] = float5 + movementPlane.ToWorld(targetPointInVelocitySpace);
					output.speed[i] = agentData.desiredSpeed[i];
					output.blockedByAgents[i * 7] = -1;
					output.forwardClearance[i] = float.PositiveInfinity;
					continue;
				}
				float num14 = agentData.maxSpeed[i];
				float2 float12 = agentData.allowedVelocityDeviationAngles[i];
				LinearProgram2Output linearProgram2Output;
				if (math.all(float12 == 0f))
				{
					linearProgram2Output = LinearProgram2D(nativeArray, numLines, num14, desiredVelocity, directionOpt: false);
				}
				else
				{
					math.sincos(float12, out var s, out var c);
					float2 float13 = desiredVelocity.x * c - desiredVelocity.y * s;
					float2 float14 = desiredVelocity.x * s + desiredVelocity.y * c;
					float2 float15 = new float2(float13.x, float14.x);
					float2 float16 = new float2(float13.y, float14.y);
					float2 float17 = desiredVelocity - float15;
					float num15 = math.length(float17);
					float17 = math.select(float2.zero, float17 * math.rcp(num15), num15 > 1.1754944E-38f);
					float2 float18 = desiredVelocity - float16;
					float num16 = math.length(float18);
					float18 = math.select(float2.zero, float18 * math.rcp(num16), num16 > 1.1754944E-38f);
					LinearProgram2Output linearProgram2Output2 = LinearProgram2DSegment(nativeArray, numLines, num14, float15, float17, 0f, num15, 1f);
					LinearProgram2Output linearProgram2Output3 = LinearProgram2DSegment(nativeArray, numLines, num14, float16, float18, 0f, num16, 1f);
					linearProgram2Output = ((linearProgram2Output2.firstFailedLineIndex < linearProgram2Output3.firstFailedLineIndex) ? linearProgram2Output2 : ((linearProgram2Output3.firstFailedLineIndex >= linearProgram2Output2.firstFailedLineIndex) ? ((math.lengthsq(linearProgram2Output2.velocity - desiredVelocity) < math.lengthsq(linearProgram2Output3.velocity - desiredVelocity)) ? linearProgram2Output2 : linearProgram2Output3) : linearProgram2Output3));
				}
				float2 result;
				if (linearProgram2Output.firstFailedLineIndex < numLines)
				{
					result = linearProgram2Output.velocity;
					LinearProgram3D(nativeArray, numLines, num2, linearProgram2Output.firstFailedLineIndex, num14, ref result, scratchBuffer);
				}
				else
				{
					result = linearProgram2Output.velocity;
				}
				int num17 = 0;
				for (int k = 0; k < numLines; k++)
				{
					if (num17 >= 7)
					{
						break;
					}
					if (orcaLineToAgent[k] != -1 && det(nativeArray[k].direction, nativeArray[k].point - result) >= -0.001f)
					{
						output.blockedByAgents[i * 7 + num17] = orcaLineToAgent[k];
						num17++;
					}
				}
				if (num17 < 7)
				{
					output.blockedByAgents[i * 7 + num17] = -1;
				}
				if (math.any(temporaryAgentData.collisionVelocityOffsets[i] != 0f))
				{
					result += temporaryAgentData.collisionVelocityOffsets[i];
					result = LinearProgram2D(nativeArray, num2, num14, result, directionOpt: false).velocity;
				}
				output.targetPoint[i] = float5 + movementPlane.ToWorld(result);
				output.speed[i] = math.min(math.length(result), num14);
				float2 float19 = math.normalizesafe(movementPlane.ToPlane(agentData.targetPoint[i] - float5));
				float num18 = CalculateForwardClearance(neighbours, movementPlane, float5, num6, float19);
				output.forwardClearance[i] = num18;
				if (agentData.HasDebugFlag(i, AgentDebugFlags.ForwardClearance) && num18 < float.PositiveInfinity)
				{
					draw.PushLineWidth(2f);
					draw.Ray(float5, movementPlane.ToWorld(float19) * num18, Color.red);
					draw.PopLineWidth();
				}
			}
		}

		private float CalculateForwardClearance(NativeSlice<int> neighbours, MovementPlaneWrapper movementPlane, float3 position, float radius, float2 targetDir)
		{
			float num = float.PositiveInfinity;
			for (int i = 0; i < neighbours.Length; i++)
			{
				int num2 = neighbours[i];
				if (num2 == -1)
				{
					break;
				}
				float3 float5 = agentData.position[num2];
				float num3 = radius + agentData.radius[num2];
				float2 x = movementPlane.ToPlane(float5 - position);
				float num4 = math.dot(math.normalizesafe(x), targetDir);
				if (!(num4 < 0f))
				{
					float num5 = math.lengthsq(x);
					float num6 = math.sqrt(num5) * num4;
					float num7 = num3 * num3 - (num5 - num6 * num6);
					if (!(num7 < 0f))
					{
						float y = num6 - math.sqrt(num7);
						num = math.min(num, y);
					}
				}
			}
			return num;
		}

		private static bool leftOrColinear(float2 vector1, float2 vector2)
		{
			return det(vector1, vector2) >= 0f;
		}

		private static bool left(float2 vector1, float2 vector2)
		{
			return det(vector1, vector2) > 0f;
		}

		private static bool rightOrColinear(float2 vector1, float2 vector2)
		{
			return det(vector1, vector2) <= 0f;
		}

		private static bool right(float2 vector1, float2 vector2)
		{
			return det(vector1, vector2) < 0f;
		}

		private static float det(float2 vector1, float2 vector2)
		{
			return vector1.x * vector2.y - vector1.y * vector2.x;
		}

		private static float2 rot90(float2 v)
		{
			return new float2(0f - v.y, v.x);
		}

		private static float DistanceInsideVOs(UnsafeSpan<ORCALine> lines, float2 velocity)
		{
			float num = 0f;
			for (int i = 0; i < lines.Length; i++)
			{
				float y = det(lines[i].direction, lines[i].point - velocity);
				num = math.max(num, y);
			}
			return num;
		}

		private static bool BiasDesiredVelocity(UnsafeSpan<ORCALine> lines, ref float2 desiredVelocity, ref float2 targetPointInVelocitySpace, float maxBiasRadians)
		{
			float num = DistanceInsideVOs(lines, desiredVelocity);
			if (num == 0f)
			{
				return false;
			}
			float num2 = math.length(desiredVelocity);
			if (num2 >= 0.001f)
			{
				float num3 = math.min(maxBiasRadians, num / num2);
				desiredVelocity += new float2(desiredVelocity.y, 0f - desiredVelocity.x) * num3;
				targetPointInVelocitySpace += new float2(targetPointInVelocitySpace.y, 0f - targetPointInVelocitySpace.x) * num3;
			}
			return true;
		}

		private static bool ClipLine(ORCALine line, ORCALine clipper, ref float tLeft, ref float tRight)
		{
			float num = det(line.direction, clipper.direction);
			float num2 = det(clipper.direction, line.point - clipper.point);
			if (math.abs(num) < 0.0001f)
			{
				return false;
			}
			float y = num2 / num;
			if (num >= 0f)
			{
				tRight = math.min(tRight, y);
			}
			else
			{
				tLeft = math.max(tLeft, y);
			}
			return true;
		}

		private static bool ClipBoundary(NativeArray<ORCALine> lines, int lineIndex, float radius, out float tLeft, out float tRight)
		{
			ORCALine oRCALine = lines[lineIndex];
			if (!VectorMath.LineCircleIntersectionFactors(oRCALine.point, oRCALine.direction, radius, out tLeft, out tRight))
			{
				return false;
			}
			for (int i = 0; i < lineIndex; i++)
			{
				float num = det(oRCALine.direction, lines[i].direction);
				float num2 = det(lines[i].direction, oRCALine.point - lines[i].point);
				if (math.abs(num) < 0.0001f)
				{
					if (num2 < 0f)
					{
						return false;
					}
					continue;
				}
				float y = num2 / num;
				if (num >= 0f)
				{
					tRight = math.min(tRight, y);
				}
				else
				{
					tLeft = math.max(tLeft, y);
				}
				if (tLeft > tRight)
				{
					return false;
				}
			}
			return true;
		}

		private static bool LinearProgram1D(NativeArray<ORCALine> lines, int lineIndex, float radius, float2 optimalVelocity, bool directionOpt, ref float2 result)
		{
			if (!ClipBoundary(lines, lineIndex, radius, out var tLeft, out var tRight))
			{
				return false;
			}
			ORCALine oRCALine = lines[lineIndex];
			if (directionOpt)
			{
				if (math.dot(optimalVelocity, oRCALine.direction) > 0f)
				{
					result = oRCALine.point + tRight * oRCALine.direction;
				}
				else
				{
					result = oRCALine.point + tLeft * oRCALine.direction;
				}
			}
			else
			{
				float x = math.dot(oRCALine.direction, optimalVelocity - oRCALine.point);
				result = oRCALine.point + math.clamp(x, tLeft, tRight) * oRCALine.direction;
			}
			return true;
		}

		private static LinearProgram2Output LinearProgram2D(NativeArray<ORCALine> lines, int numLines, float radius, float2 optimalVelocity, bool directionOpt)
		{
			float2 result = (directionOpt ? (optimalVelocity * radius) : ((!(math.lengthsq(optimalVelocity) > radius * radius)) ? optimalVelocity : (math.normalize(optimalVelocity) * radius)));
			for (int i = 0; i < numLines; i++)
			{
				if (det(lines[i].direction, lines[i].point - result) > 0f)
				{
					float2 velocity = result;
					if (!LinearProgram1D(lines, i, radius, optimalVelocity, directionOpt, ref result))
					{
						return new LinearProgram2Output
						{
							velocity = velocity,
							firstFailedLineIndex = i
						};
					}
				}
			}
			return new LinearProgram2Output
			{
				velocity = result,
				firstFailedLineIndex = numLines
			};
		}

		private static float ClosestPointOnSegment(float2 a, float2 dir, float2 p, float t0, float t1)
		{
			return math.clamp(math.dot(p - a, dir), t0, t1);
		}

		private static float2 ClosestSegmentSegmentPointNonIntersecting(ORCALine a, ORCALine b, float ta1, float ta2, float tb1, float tb2)
		{
			float2 float5 = a.point + a.direction * ta1;
			float2 float6 = a.point + a.direction * ta2;
			float2 float7 = b.point + b.direction * tb1;
			float2 float8 = b.point + b.direction * tb2;
			float num = ClosestPointOnSegment(a.point, a.direction, float7, ta1, ta2);
			float num2 = ClosestPointOnSegment(a.point, a.direction, float8, ta1, ta2);
			float num3 = ClosestPointOnSegment(b.point, b.direction, float5, tb1, tb2);
			float num4 = ClosestPointOnSegment(b.point, b.direction, float6, tb1, tb2);
			float2 float9 = a.point + a.direction * num;
			float2 float10 = a.point + a.direction * num2;
			float2 float11 = b.point + b.direction * num3;
			float2 obj = b.point + b.direction * num4;
			float num5 = math.lengthsq(float9 - float7);
			float num6 = math.lengthsq(float10 - float8);
			float num7 = math.lengthsq(float11 - float5);
			float num8 = math.lengthsq(obj - float6);
			float2 result = float9;
			float num9 = num5;
			if (num6 < num9)
			{
				result = float10;
				num9 = num6;
			}
			if (num7 < num9)
			{
				result = float5;
				num9 = num7;
			}
			if (num8 < num9)
			{
				result = float6;
				num9 = num8;
			}
			return result;
		}

		private static LinearProgram2Output LinearProgram2DCollapsedSegment(NativeArray<ORCALine> lines, int numLines, int startLine, float radius, float2 currentResult, float2 optimalVelocityStart, float2 optimalVelocityDir, float optimalTLeft, float optimalTRight)
		{
			for (int i = startLine; i < numLines; i++)
			{
				if (det(lines[i].direction, lines[i].point - currentResult) > 0f)
				{
					if (!ClipBoundary(lines, i, radius, out var tLeft, out var tRight))
					{
						return new LinearProgram2Output
						{
							velocity = currentResult,
							firstFailedLineIndex = i
						};
					}
					currentResult = ClosestSegmentSegmentPointNonIntersecting(lines[i], new ORCALine
					{
						point = optimalVelocityStart,
						direction = optimalVelocityDir
					}, tLeft, tRight, optimalTLeft, optimalTRight);
				}
			}
			return new LinearProgram2Output
			{
				velocity = currentResult,
				firstFailedLineIndex = numLines
			};
		}

		private static LinearProgram2Output LinearProgram2DSegment(NativeArray<ORCALine> lines, int numLines, float radius, float2 optimalVelocityStart, float2 optimalVelocityDir, float optimalTLeft, float optimalTRight, float optimalT)
		{
			float t;
			float t2;
			bool num = VectorMath.LineCircleIntersectionFactors(optimalVelocityStart, optimalVelocityDir, radius, out t, out t2);
			t = math.max(t, optimalTLeft);
			t2 = math.min(t2, optimalTRight);
			if (!(num && t <= t2))
			{
				float num2 = math.clamp(math.dot(-optimalVelocityStart, optimalVelocityDir), optimalTLeft, optimalTRight);
				float2 currentResult = math.normalizesafe(optimalVelocityStart + optimalVelocityDir * num2) * radius;
				return LinearProgram2DCollapsedSegment(lines, numLines, 0, radius, currentResult, optimalVelocityStart, optimalVelocityDir, optimalTLeft, optimalTRight);
			}
			for (int i = 0; i < numLines; i++)
			{
				ORCALine oRCALine = lines[i];
				bool flag = det(oRCALine.direction, oRCALine.point - (optimalVelocityStart + optimalVelocityDir * t)) > 0f;
				bool flag2 = det(oRCALine.direction, oRCALine.point - (optimalVelocityStart + optimalVelocityDir * t2)) > 0f;
				if (!(flag || flag2))
				{
					continue;
				}
				if (!ClipBoundary(lines, i, radius, out var tLeft, out var tRight))
				{
					return new LinearProgram2Output
					{
						velocity = optimalVelocityStart + optimalVelocityDir * math.clamp(optimalT, t, t2),
						firstFailedLineIndex = i
					};
				}
				if (flag && flag2)
				{
					if (!(math.abs(det(oRCALine.direction, optimalVelocityDir)) < 0.001f))
					{
						float2 currentResult2 = ClosestSegmentSegmentPointNonIntersecting(oRCALine, new ORCALine
						{
							point = optimalVelocityStart,
							direction = optimalVelocityDir
						}, tLeft, tRight, optimalTLeft, optimalTRight);
						return LinearProgram2DCollapsedSegment(lines, numLines, i + 1, radius, currentResult2, optimalVelocityStart, optimalVelocityDir, optimalTLeft, optimalTRight);
					}
					float num3 = ClosestPointOnSegment(oRCALine.point, oRCALine.direction, optimalVelocityStart + optimalVelocityDir * t, tLeft, tRight);
					float num4 = ClosestPointOnSegment(oRCALine.point, oRCALine.direction, optimalVelocityStart + optimalVelocityDir * t2, tLeft, tRight);
					float num5 = ClosestPointOnSegment(oRCALine.point, oRCALine.direction, optimalVelocityStart + optimalVelocityDir * optimalT, tLeft, tRight);
					optimalVelocityStart = oRCALine.point;
					optimalVelocityDir = oRCALine.direction;
					t = num3;
					t2 = num4;
					optimalT = num5;
				}
				else
				{
					ClipLine(new ORCALine
					{
						point = optimalVelocityStart,
						direction = optimalVelocityDir
					}, oRCALine, ref t, ref t2);
				}
			}
			float num6 = math.clamp(optimalT, t, t2);
			return new LinearProgram2Output
			{
				velocity = optimalVelocityStart + optimalVelocityDir * num6,
				firstFailedLineIndex = numLines
			};
		}

		private static void LinearProgram3D(NativeArray<ORCALine> lines, int numLines, int numFixedLines, int beginLine, float radius, ref float2 result, NativeArray<ORCALine> scratchBuffer)
		{
			float num = 0f;
			NativeArray<ORCALine> nativeArray = scratchBuffer;
			NativeArray<ORCALine>.Copy(lines, nativeArray, numFixedLines);
			for (int i = beginLine; i < numLines; i++)
			{
				if (!(det(lines[i].direction, lines[i].point - result) > num))
				{
					continue;
				}
				int num2 = numFixedLines;
				for (int j = numFixedLines; j < i; j++)
				{
					float num3 = det(lines[i].direction, lines[j].direction);
					if (math.abs(num3) < 0.001f)
					{
						if (!(math.dot(lines[i].direction, lines[j].direction) > 0f))
						{
							nativeArray[num2] = new ORCALine
							{
								point = 0.5f * (lines[i].point + lines[j].point),
								direction = math.normalize(lines[j].direction - lines[i].direction)
							};
							num2++;
						}
					}
					else
					{
						nativeArray[num2] = new ORCALine
						{
							point = lines[i].point + det(lines[j].direction, lines[i].point - lines[j].point) / num3 * lines[i].direction,
							direction = math.normalize(lines[j].direction - lines[i].direction)
						};
						num2++;
					}
				}
				LinearProgram2Output linearProgram2Output = LinearProgram2D(nativeArray, num2, radius, new float2(0f - lines[i].direction.y, lines[i].direction.x), directionOpt: true);
				if (linearProgram2Output.firstFailedLineIndex >= num2)
				{
					result = linearProgram2Output.velocity;
				}
				num = det(lines[i].direction, lines[i].point - result);
			}
		}

		private static void DrawVO(CommandBuilder draw, float2 circleCenter, float radius, float2 origin, Color color)
		{
		}
	}
}
