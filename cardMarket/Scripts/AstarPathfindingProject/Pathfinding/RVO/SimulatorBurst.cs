using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.ECS.RVO;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	public class SimulatorBurst
	{
		private struct Agent : IAgent
		{
			public SimulatorBurst simulator;

			public AgentIndex agentIndex;

			public int AgentIndex => agentIndex.Index;

			public Vector3 Position
			{
				get
				{
					return simulator.simulationData.position[AgentIndex];
				}
				set
				{
					simulator.simulationData.position[AgentIndex] = value;
				}
			}

			public bool Locked
			{
				get
				{
					return simulator.simulationData.locked[AgentIndex];
				}
				set
				{
					simulator.simulationData.locked[AgentIndex] = value;
				}
			}

			public float Radius
			{
				get
				{
					return simulator.simulationData.radius[AgentIndex];
				}
				set
				{
					simulator.simulationData.radius[AgentIndex] = value;
				}
			}

			public float Height
			{
				get
				{
					return simulator.simulationData.height[AgentIndex];
				}
				set
				{
					simulator.simulationData.height[AgentIndex] = value;
				}
			}

			public float AgentTimeHorizon
			{
				get
				{
					return simulator.simulationData.agentTimeHorizon[AgentIndex];
				}
				set
				{
					simulator.simulationData.agentTimeHorizon[AgentIndex] = value;
				}
			}

			public float ObstacleTimeHorizon
			{
				get
				{
					return simulator.simulationData.obstacleTimeHorizon[AgentIndex];
				}
				set
				{
					simulator.simulationData.obstacleTimeHorizon[AgentIndex] = value;
				}
			}

			public int MaxNeighbours
			{
				get
				{
					return simulator.simulationData.maxNeighbours[AgentIndex];
				}
				set
				{
					simulator.simulationData.maxNeighbours[AgentIndex] = value;
				}
			}

			public RVOLayer Layer
			{
				get
				{
					return simulator.simulationData.layer[AgentIndex];
				}
				set
				{
					simulator.simulationData.layer[AgentIndex] = value;
				}
			}

			public RVOLayer CollidesWith
			{
				get
				{
					return simulator.simulationData.collidesWith[AgentIndex];
				}
				set
				{
					simulator.simulationData.collidesWith[AgentIndex] = value;
				}
			}

			public float FlowFollowingStrength
			{
				get
				{
					return simulator.simulationData.flowFollowingStrength[AgentIndex];
				}
				set
				{
					simulator.simulationData.flowFollowingStrength[AgentIndex] = value;
				}
			}

			public AgentDebugFlags DebugFlags
			{
				get
				{
					return simulator.simulationData.debugFlags[AgentIndex];
				}
				set
				{
					simulator.simulationData.debugFlags[AgentIndex] = value;
				}
			}

			public float Priority
			{
				get
				{
					return simulator.simulationData.priority[AgentIndex];
				}
				set
				{
					simulator.simulationData.priority[AgentIndex] = value;
				}
			}

			public int HierarchicalNodeIndex
			{
				get
				{
					return simulator.simulationData.hierarchicalNodeIndex[AgentIndex];
				}
				set
				{
					simulator.simulationData.hierarchicalNodeIndex[AgentIndex] = value;
				}
			}

			public SimpleMovementPlane MovementPlane
			{
				get
				{
					return new SimpleMovementPlane(simulator.simulationData.movementPlane[AgentIndex].rotation);
				}
				set
				{
					simulator.simulationData.movementPlane[AgentIndex] = new NativeMovementPlane(value);
				}
			}

			public Action PreCalculationCallback
			{
				set
				{
					simulator.agentPreCalculationCallbacks[AgentIndex] = value;
				}
			}

			public Action DestroyedCallback
			{
				set
				{
					simulator.agentDestroyCallbacks[AgentIndex] = value;
				}
			}

			public Vector3 CalculatedTargetPoint
			{
				get
				{
					simulator.BlockUntilSimulationStepDone();
					return simulator.outputData.targetPoint[AgentIndex];
				}
			}

			public float CalculatedSpeed
			{
				get
				{
					simulator.BlockUntilSimulationStepDone();
					return simulator.outputData.speed[AgentIndex];
				}
			}

			public ReachedEndOfPath CalculatedEffectivelyReachedDestination
			{
				get
				{
					simulator.BlockUntilSimulationStepDone();
					return simulator.outputData.effectivelyReachedDestination[AgentIndex];
				}
			}

			public int NeighbourCount
			{
				get
				{
					simulator.BlockUntilSimulationStepDone();
					return simulator.outputData.numNeighbours[AgentIndex];
				}
			}

			public bool AvoidingAnyAgents
			{
				get
				{
					simulator.BlockUntilSimulationStepDone();
					return simulator.outputData.blockedByAgents[AgentIndex * 7] != -1;
				}
			}

			public void SetObstacleQuery(GraphNode sourceNode)
			{
				HierarchicalNodeIndex = ((sourceNode != null && !sourceNode.Destroyed && sourceNode.Walkable) ? sourceNode.HierarchicalNodeIndex : (-1));
			}

			public void SetTarget(Vector3 targetPoint, float desiredSpeed, float maxSpeed, Vector3 endOfPath)
			{
				simulator.simulationData.SetTarget(AgentIndex, targetPoint, desiredSpeed, maxSpeed, endOfPath);
			}

			public void SetCollisionNormal(Vector3 normal)
			{
				simulator.simulationData.collisionNormal[AgentIndex] = normal;
			}

			public void ForceSetVelocity(Vector3 velocity)
			{
				simulator.simulationData.targetPoint[AgentIndex] = simulator.simulationData.position[AgentIndex] + (float3)velocity * 1000f;
				simulator.simulationData.desiredSpeed[AgentIndex] = velocity.magnitude;
				simulator.simulationData.allowedVelocityDeviationAngles[AgentIndex] = float2.zero;
				simulator.simulationData.manuallyControlled[AgentIndex] = true;
			}
		}

		public struct ObstacleData
		{
			public SlabAllocator<ObstacleVertexGroup> obstacleVertexGroups;

			public SlabAllocator<float3> obstacleVertices;

			public NativeList<UnmanagedObstacle> obstacles;

			public void Init(Allocator allocator)
			{
				if (!obstacles.IsCreated)
				{
					obstacles = new NativeList<UnmanagedObstacle>(0, allocator);
				}
				if (!obstacleVertexGroups.IsCreated)
				{
					obstacleVertexGroups = new SlabAllocator<ObstacleVertexGroup>(4, allocator);
				}
				if (!obstacleVertices.IsCreated)
				{
					obstacleVertices = new SlabAllocator<float3>(16, allocator);
				}
			}

			public void Dispose()
			{
				if (obstacleVertexGroups.IsCreated)
				{
					obstacleVertexGroups.Dispose();
					obstacleVertices.Dispose();
					obstacles.Dispose();
				}
			}
		}

		public struct AgentData
		{
			public NativeArray<AgentIndex> version;

			public NativeArray<float> radius;

			public NativeArray<float> height;

			public NativeArray<float> desiredSpeed;

			public NativeArray<float> maxSpeed;

			public NativeArray<float> agentTimeHorizon;

			public NativeArray<float> obstacleTimeHorizon;

			public NativeArray<bool> locked;

			public NativeArray<int> maxNeighbours;

			public NativeArray<RVOLayer> layer;

			public NativeArray<RVOLayer> collidesWith;

			public NativeArray<float> flowFollowingStrength;

			public NativeArray<float3> position;

			public NativeArray<float3> collisionNormal;

			public NativeArray<bool> manuallyControlled;

			public NativeArray<float> priority;

			public NativeArray<AgentDebugFlags> debugFlags;

			public NativeArray<float3> targetPoint;

			public NativeArray<float2> allowedVelocityDeviationAngles;

			public NativeArray<NativeMovementPlane> movementPlane;

			public NativeArray<float3> endOfPath;

			public NativeArray<int> agentObstacleMapping;

			public NativeArray<int> hierarchicalNodeIndex;

			public void Realloc(int size, Allocator allocator)
			{
				Memory.Realloc(ref version, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref radius, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref height, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref desiredSpeed, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref maxSpeed, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref agentTimeHorizon, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref obstacleTimeHorizon, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref locked, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref maxNeighbours, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref layer, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref collidesWith, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref flowFollowingStrength, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref position, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref collisionNormal, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref manuallyControlled, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref priority, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref debugFlags, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref targetPoint, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref movementPlane, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref allowedVelocityDeviationAngles, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref endOfPath, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref agentObstacleMapping, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref hierarchicalNodeIndex, size, allocator, NativeArrayOptions.UninitializedMemory);
			}

			public void SetTarget(int agentIndex, float3 targetPoint, float desiredSpeed, float maxSpeed, float3 endOfPath)
			{
				maxSpeed = math.max(maxSpeed, 0f);
				desiredSpeed = math.clamp(desiredSpeed, 0f, maxSpeed);
				this.targetPoint[agentIndex] = targetPoint;
				this.desiredSpeed[agentIndex] = desiredSpeed;
				this.maxSpeed[agentIndex] = maxSpeed;
				this.endOfPath[agentIndex] = endOfPath;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool HasDebugFlag(int agentIndex, AgentDebugFlags flag)
			{
				return Hint.Unlikely((debugFlags[agentIndex] & flag) != 0);
			}

			public void Dispose()
			{
				version.Dispose();
				radius.Dispose();
				height.Dispose();
				desiredSpeed.Dispose();
				maxSpeed.Dispose();
				agentTimeHorizon.Dispose();
				obstacleTimeHorizon.Dispose();
				locked.Dispose();
				maxNeighbours.Dispose();
				layer.Dispose();
				collidesWith.Dispose();
				flowFollowingStrength.Dispose();
				position.Dispose();
				collisionNormal.Dispose();
				manuallyControlled.Dispose();
				priority.Dispose();
				debugFlags.Dispose();
				targetPoint.Dispose();
				movementPlane.Dispose();
				allowedVelocityDeviationAngles.Dispose();
				endOfPath.Dispose();
				agentObstacleMapping.Dispose();
				hierarchicalNodeIndex.Dispose();
			}
		}

		public struct AgentOutputData
		{
			public NativeArray<float3> targetPoint;

			public NativeArray<float> speed;

			public NativeArray<int> numNeighbours;

			[NativeDisableParallelForRestriction]
			public NativeArray<int> blockedByAgents;

			public NativeArray<ReachedEndOfPath> effectivelyReachedDestination;

			public NativeArray<float> forwardClearance;

			public void Realloc(int size, Allocator allocator)
			{
				Memory.Realloc(ref targetPoint, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref speed, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref numNeighbours, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref blockedByAgents, size * 7, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref effectivelyReachedDestination, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref forwardClearance, size, allocator, NativeArrayOptions.UninitializedMemory);
			}

			public void Move(int fromIndex, int toIndex)
			{
				targetPoint[toIndex] = targetPoint[fromIndex];
				speed[toIndex] = speed[fromIndex];
				numNeighbours[toIndex] = numNeighbours[fromIndex];
				effectivelyReachedDestination[toIndex] = effectivelyReachedDestination[fromIndex];
				for (int i = 0; i < 7; i++)
				{
					blockedByAgents[toIndex * 7 + i] = blockedByAgents[fromIndex * 7 + i];
				}
				forwardClearance[toIndex] = forwardClearance[fromIndex];
			}

			public void Dispose()
			{
				targetPoint.Dispose();
				speed.Dispose();
				numNeighbours.Dispose();
				blockedByAgents.Dispose();
				effectivelyReachedDestination.Dispose();
				forwardClearance.Dispose();
			}
		}

		public struct HorizonAgentData
		{
			public NativeArray<int> horizonSide;

			public NativeArray<float> horizonMinAngle;

			public NativeArray<float> horizonMaxAngle;

			public void Realloc(int size, Allocator allocator)
			{
				Memory.Realloc(ref horizonSide, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref horizonMinAngle, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref horizonMaxAngle, size, allocator, NativeArrayOptions.UninitializedMemory);
			}

			public void Move(int fromIndex, int toIndex)
			{
				horizonSide[toIndex] = horizonSide[fromIndex];
			}

			public void Dispose()
			{
				horizonSide.Dispose();
				horizonMinAngle.Dispose();
				horizonMaxAngle.Dispose();
			}
		}

		public struct TemporaryAgentData
		{
			public NativeArray<float2> desiredTargetPointInVelocitySpace;

			public NativeArray<float3> desiredVelocity;

			public NativeArray<float3> currentVelocity;

			public NativeArray<float2> collisionVelocityOffsets;

			public NativeArray<int> neighbours;

			public void Realloc(int size, Allocator allocator)
			{
				Memory.Realloc(ref desiredTargetPointInVelocitySpace, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref desiredVelocity, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref currentVelocity, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref collisionVelocityOffsets, size, allocator, NativeArrayOptions.UninitializedMemory);
				Memory.Realloc(ref neighbours, size * 50, allocator, NativeArrayOptions.UninitializedMemory);
			}

			public void Dispose()
			{
				desiredTargetPointInVelocitySpace.Dispose();
				desiredVelocity.Dispose();
				currentVelocity.Dispose();
				neighbours.Dispose();
				collisionVelocityOffsets.Dispose();
			}
		}

		private float desiredDeltaTime = 0.05f;

		private int numAgents;

		private RedrawScope debugDrawingScope;

		public RVOQuadtreeBurst quadtree;

		public bool drawQuadtree;

		private Action[] agentPreCalculationCallbacks = new Action[0];

		private Action[] agentDestroyCallbacks = new Action[0];

		private Stack<int> freeAgentIndices = new Stack<int>();

		private TemporaryAgentData temporaryAgentData;

		private HorizonAgentData horizonAgentData;

		public ObstacleData obstacleData;

		public AgentData simulationData;

		public AgentOutputData outputData;

		public const int MaxNeighbourCount = 50;

		public const int MaxBlockingAgentCount = 7;

		public const int MaxObstacleVertices = 256;

		public readonly MovementPlane movementPlane;

		public float DesiredDeltaTime
		{
			get
			{
				return desiredDeltaTime;
			}
			set
			{
				desiredDeltaTime = Math.Max(value, 0f);
			}
		}

		public float SymmetryBreakingBias { get; set; }

		public bool HardCollisions { get; set; }

		public bool UseNavmeshAsObstacle { get; set; }

		public Rect AgentBounds
		{
			get
			{
				lastJob.Complete();
				return quadtree.bounds;
			}
		}

		public int AgentCount => numAgents;

		public MovementPlane MovementPlane => movementPlane;

		public JobHandle lastJob { get; private set; }

		public void BlockUntilSimulationStepDone()
		{
			lastJob.Complete();
		}

		public SimulatorBurst(MovementPlane movementPlane)
		{
			DesiredDeltaTime = 1f;
			this.movementPlane = movementPlane;
			obstacleData.Init(Allocator.Persistent);
			AllocateAgentSpace();
			Unity.Jobs.IJobExtensions.Run(quadtree.BuildJob(simulationData.position, simulationData.version, simulationData.desiredSpeed, simulationData.radius, 0, movementPlane));
		}

		public void ClearAgents()
		{
			BlockUntilSimulationStepDone();
			for (int i = 0; i < agentDestroyCallbacks.Length; i++)
			{
				agentDestroyCallbacks[i]?.Invoke();
			}
			numAgents = 0;
		}

		public void OnDestroy()
		{
			debugDrawingScope.Dispose();
			BlockUntilSimulationStepDone();
			ClearAgents();
			obstacleData.Dispose();
			simulationData.Dispose();
			temporaryAgentData.Dispose();
			outputData.Dispose();
			quadtree.Dispose();
			horizonAgentData.Dispose();
		}

		private void AllocateAgentSpace()
		{
			if (numAgents > agentPreCalculationCallbacks.Length || agentPreCalculationCallbacks.Length == 0)
			{
				int length = simulationData.version.Length;
				int num = Mathf.Max(64, Mathf.Max(numAgents, agentPreCalculationCallbacks.Length * 2));
				simulationData.Realloc(num, Allocator.Persistent);
				temporaryAgentData.Realloc(num, Allocator.Persistent);
				outputData.Realloc(num, Allocator.Persistent);
				horizonAgentData.Realloc(num, Allocator.Persistent);
				Memory.Realloc(ref agentPreCalculationCallbacks, num);
				Memory.Realloc(ref agentDestroyCallbacks, num);
				for (int i = length; i < num; i++)
				{
					simulationData.version[i] = new AgentIndex(0, i);
				}
			}
		}

		[Obsolete("Use AddAgent(Vector3) instead")]
		public IAgent AddAgent(Vector2 position, float elevationCoordinate)
		{
			if (movementPlane == MovementPlane.XY)
			{
				return AddAgent(new Vector3(position.x, position.y, elevationCoordinate));
			}
			return AddAgent(new Vector3(position.x, elevationCoordinate, position.y));
		}

		public IAgent AddAgent(Vector3 position)
		{
			AgentIndex agentIndex = AddAgentBurst(position);
			return new Agent
			{
				simulator = this,
				agentIndex = agentIndex
			};
		}

		public AgentIndex AddAgentBurst(float3 position)
		{
			BlockUntilSimulationStepDone();
			int num;
			if (freeAgentIndices.Count > 0)
			{
				num = freeAgentIndices.Pop();
			}
			else
			{
				num = numAgents++;
				AllocateAgentSpace();
			}
			AgentIndex agentIndex = simulationData.version[num].WithIncrementedVersion();
			simulationData.version[num] = agentIndex;
			simulationData.radius[num] = 5f;
			simulationData.height[num] = 5f;
			simulationData.desiredSpeed[num] = 0f;
			simulationData.maxSpeed[num] = 1f;
			simulationData.agentTimeHorizon[num] = 2f;
			simulationData.obstacleTimeHorizon[num] = 2f;
			simulationData.locked[num] = false;
			simulationData.maxNeighbours[num] = 10;
			simulationData.layer[num] = RVOLayer.DefaultAgent;
			simulationData.collidesWith[num] = (RVOLayer)(-1);
			simulationData.flowFollowingStrength[num] = 0f;
			simulationData.position[num] = position;
			simulationData.collisionNormal[num] = float3.zero;
			simulationData.manuallyControlled[num] = false;
			simulationData.priority[num] = 0.5f;
			simulationData.debugFlags[num] = AgentDebugFlags.Nothing;
			simulationData.targetPoint[num] = position;
			ref NativeArray<NativeMovementPlane> reference = ref simulationData.movementPlane;
			int index = num;
			SimpleMovementPlane obj = ((movementPlane == MovementPlane.XY) ? SimpleMovementPlane.XYPlane : SimpleMovementPlane.XZPlane);
			reference[index] = new NativeMovementPlane(obj.rotation);
			simulationData.allowedVelocityDeviationAngles[num] = float2.zero;
			simulationData.endOfPath[num] = float3.zero;
			simulationData.agentObstacleMapping[num] = -1;
			simulationData.hierarchicalNodeIndex[num] = -1;
			outputData.speed[num] = 0f;
			outputData.numNeighbours[num] = 0;
			outputData.targetPoint[num] = position;
			outputData.blockedByAgents[num * 7] = -1;
			outputData.effectivelyReachedDestination[num] = ReachedEndOfPath.NotReached;
			horizonAgentData.horizonSide[num] = 0;
			agentPreCalculationCallbacks[num] = null;
			agentDestroyCallbacks[num] = null;
			return agentIndex;
		}

		[Obsolete("Use AddAgent(Vector3) instead")]
		public IAgent AddAgent(IAgent agent)
		{
			throw new NotImplementedException("Use AddAgent(position) instead. Agents are not persistent after being removed.");
		}

		public void RemoveAgent(IAgent agent)
		{
			if (agent == null)
			{
				throw new ArgumentNullException("agent");
			}
			RemoveAgent(((Agent)(object)agent).agentIndex);
		}

		public bool AgentExists(AgentIndex agent)
		{
			BlockUntilSimulationStepDone();
			if (!simulationData.version.IsCreated)
			{
				return false;
			}
			int index = agent.Index;
			if (index >= simulationData.version.Length)
			{
				return false;
			}
			if (agent.Version != simulationData.version[index].Version)
			{
				return false;
			}
			return true;
		}

		public void RemoveAgent(AgentIndex agent)
		{
			BlockUntilSimulationStepDone();
			if (!AgentExists(agent))
			{
				throw new InvalidOperationException("Trying to remove agent which does not exist");
			}
			int index = agent.Index;
			simulationData.version[index] = simulationData.version[index].WithIncrementedVersion().WithDeleted();
			agentPreCalculationCallbacks[index] = null;
			try
			{
				if (agentDestroyCallbacks[index] != null)
				{
					agentDestroyCallbacks[index]();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			agentDestroyCallbacks[index] = null;
			freeAgentIndices.Push(index);
		}

		private void PreCalculation(JobHandle dependency)
		{
			bool flag = false;
			for (int i = 0; i < numAgents; i++)
			{
				Action action = agentPreCalculationCallbacks[i];
				if (action != null)
				{
					if (!flag)
					{
						dependency.Complete();
						flag = true;
					}
					action();
				}
			}
		}

		public JobHandle Update(JobHandle dependency, float dt, bool drawGizmos, Allocator allocator)
		{
			if (false)
			{
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobRVO<XYMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobRVO<XZMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobRVO<ArbitraryMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobRVOCalculateNeighbours<XYMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobRVOCalculateNeighbours<XZMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobRVOCalculateNeighbours<ArbitraryMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobHardCollisions<XYMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobHardCollisions<XZMovementPlane>), 0, 0);
				JobParallelForBatchedExtensions.ScheduleBatch(default(JobHardCollisions<ArbitraryMovementPlane>), 0, 0);
				Unity.Jobs.IJobExtensions.Schedule(default(JobDestinationReached<XYMovementPlane>));
				Unity.Jobs.IJobExtensions.Schedule(default(JobDestinationReached<XZMovementPlane>));
				Unity.Jobs.IJobExtensions.Schedule(default(JobDestinationReached<ArbitraryMovementPlane>));
			}
			if (movementPlane == MovementPlane.XY)
			{
				return UpdateInternal<XYMovementPlane>(dependency, dt, drawGizmos, allocator);
			}
			if (movementPlane == MovementPlane.XZ)
			{
				return UpdateInternal<XZMovementPlane>(dependency, dt, drawGizmos, allocator);
			}
			return UpdateInternal<ArbitraryMovementPlane>(dependency, dt, drawGizmos, allocator);
		}

		public void LockSimulationDataReadOnly(JobHandle dependencies)
		{
			lastJob = JobHandle.CombineDependencies(lastJob, dependencies);
		}

		private JobHandle UpdateInternal<T>(JobHandle dependency, float deltaTime, bool drawGizmos, Allocator allocator) where T : struct, IMovementPlaneWrapper
		{
			deltaTime = math.max(deltaTime, 0.0005f);
			BlockUntilSimulationStepDone();
			PreCalculation(dependency);
			JobHandle jobHandle = Unity.Jobs.IJobExtensions.Schedule(quadtree.BuildJob(simulationData.position, simulationData.version, outputData.speed, simulationData.radius, numAgents, movementPlane), dependency);
			JobHandle job = Unity.Jobs.IJobExtensions.Schedule(new JobRVOPreprocess
			{
				agentData = simulationData,
				previousOutput = outputData,
				temporaryAgentData = temporaryAgentData,
				startIndex = 0,
				endIndex = numAgents
			}, dependency);
			int minIndicesPerJobCount = math.max(numAgents / 64, 8);
			JobHandle job2 = JobParallelForBatchedExtensions.ScheduleBatch(new JobRVOCalculateNeighbours<T>
			{
				agentData = simulationData,
				quadtree = quadtree,
				outNeighbours = temporaryAgentData.neighbours,
				output = outputData
			}, numAgents, minIndicesPerJobCount, JobHandle.CombineDependencies(job, jobHandle));
			JobHandle.ScheduleBatchedJobs();
			JobHandle dependsOn = JobHandle.CombineDependencies(job, job2);
			debugDrawingScope.Rewind();
			CommandBuilder builder = DrawingManager.GetBuilder(debugDrawingScope);
			JobHandle dependsOn2 = JobParallelForBatchedExtensions.ScheduleBatch(new JobHorizonAvoidancePhase1
			{
				agentData = simulationData,
				neighbours = temporaryAgentData.neighbours,
				desiredTargetPointInVelocitySpace = temporaryAgentData.desiredTargetPointInVelocitySpace,
				horizonAgentData = horizonAgentData,
				draw = builder
			}, numAgents, minIndicesPerJobCount, dependsOn);
			JobHandle job3 = JobParallelForBatchedExtensions.ScheduleBatch(new JobHorizonAvoidancePhase2
			{
				neighbours = temporaryAgentData.neighbours,
				versions = simulationData.version,
				desiredVelocity = temporaryAgentData.desiredVelocity,
				desiredTargetPointInVelocitySpace = temporaryAgentData.desiredTargetPointInVelocitySpace,
				horizonAgentData = horizonAgentData,
				movementPlane = simulationData.movementPlane
			}, numAgents, minIndicesPerJobCount, dependsOn2);
			JobHandle job4 = JobParallelForBatchedExtensions.ScheduleBatch(new JobHardCollisions<T>
			{
				agentData = simulationData,
				neighbours = temporaryAgentData.neighbours,
				collisionVelocityOffsets = temporaryAgentData.collisionVelocityOffsets,
				deltaTime = deltaTime,
				enabled = HardCollisions
			}, numAgents, minIndicesPerJobCount, dependsOn);
			bool num = AstarPath.active != null;
			NavmeshEdges.NavmeshBorderData navmeshEdgeData;
			RWLock.CombinedReadLockAsync readLock;
			if (num)
			{
				navmeshEdgeData = AstarPath.active.GetNavmeshBorderData(out readLock);
			}
			else
			{
				navmeshEdgeData = NavmeshEdges.NavmeshBorderData.CreateEmpty(allocator);
				readLock = default(RWLock.CombinedReadLockAsync);
			}
			JobHandle jobHandle2 = JobParallelForBatchedExtensions.ScheduleBatch(new JobRVO<T>
			{
				agentData = simulationData,
				temporaryAgentData = temporaryAgentData,
				navmeshEdgeData = navmeshEdgeData,
				output = outputData,
				deltaTime = deltaTime,
				symmetryBreakingBias = Mathf.Max(0f, SymmetryBreakingBias),
				draw = builder,
				useNavmeshAsObstacle = UseNavmeshAsObstacle,
				priorityMultiplier = 1f
			}, dependsOn: JobHandle.CombineDependencies(job3, job4, readLock.dependency), arrayLength: numAgents, minIndicesPerJobCount: minIndicesPerJobCount);
			if (num)
			{
				readLock.UnlockAfter(jobHandle2);
			}
			else
			{
				navmeshEdgeData.DisposeEmpty(jobHandle2);
			}
			JobHandle jobHandle3 = Unity.Jobs.IJobExtensions.Schedule(new JobDestinationReached<T>
			{
				agentData = simulationData,
				obstacleData = obstacleData,
				temporaryAgentData = temporaryAgentData,
				output = outputData,
				draw = builder,
				numAgents = numAgents
			}, jobHandle2);
			JobHandle job5 = Unity.Jobs.IJobExtensions.Schedule(simulationData.collisionNormal.MemSet(float3.zero), jobHandle3);
			JobHandle job6 = Unity.Jobs.IJobExtensions.Schedule(simulationData.manuallyControlled.MemSet(value: false), jobHandle3);
			JobHandle job7 = Unity.Jobs.IJobExtensions.Schedule(simulationData.hierarchicalNodeIndex.MemSet(-1), jobHandle3);
			dependency = JobHandle.CombineDependencies(jobHandle3, job5, job6);
			dependency = JobHandle.CombineDependencies(dependency, job7);
			if (drawQuadtree && drawGizmos)
			{
				dependency = JobHandle.CombineDependencies(dependency, Unity.Jobs.IJobExtensions.Schedule(new RVOQuadtreeBurst.DebugDrawJob
				{
					draw = builder,
					quadtree = quadtree
				}, jobHandle));
			}
			builder.DisposeAfter(dependency);
			lastJob = dependency;
			return dependency;
		}
	}
}
