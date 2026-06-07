using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.ECS.RVO;
using Pathfinding.Sync;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.RVO
{
	public class SimulatorBurst
	{
		public struct AgentNeighbourLookup
		{
			[ReadOnly]
			[NativeDisableParallelForRestriction]
			private NativeArray<int> neighbours;

			public AgentNeighbourLookup(NativeArray<int> neighbours)
			{
				this.neighbours = default(NativeArray<int>);
			}

			public UnsafeSpan<int> GetNeighbours(int agentIndex)
			{
				return default(UnsafeSpan<int>);
			}
		}

		private struct Agent : IAgent
		{
			public SimulatorBurst simulator;

			public AgentIndex agentIndex;

			public int AgentIndex => 0;

			public Vector3 Position
			{
				get
				{
					return default(Vector3);
				}
				set
				{
				}
			}

			public bool Locked
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float Radius
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float Height
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float AgentTimeHorizon
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float ObstacleTimeHorizon
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public int MaxNeighbours
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public RVOLayer Layer
			{
				get
				{
					return default(RVOLayer);
				}
				set
				{
				}
			}

			public RVOLayer CollidesWith
			{
				get
				{
					return default(RVOLayer);
				}
				set
				{
				}
			}

			public float FlowFollowingStrength
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public AgentDebugFlags DebugFlags
			{
				get
				{
					return default(AgentDebugFlags);
				}
				set
				{
				}
			}

			public float Priority
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public int HierarchicalNodeIndex
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public SimpleMovementPlane MovementPlane
			{
				get
				{
					return default(SimpleMovementPlane);
				}
				set
				{
				}
			}

			public Action PreCalculationCallback
			{
				set
				{
				}
			}

			public Action DestroyedCallback
			{
				set
				{
				}
			}

			public Vector3 CalculatedTargetPoint => default(Vector3);

			public float CalculatedSpeed => 0f;

			public ReachedEndOfPath CalculatedEffectivelyReachedDestination => default(ReachedEndOfPath);

			public int NeighbourCount => 0;

			public bool AvoidingAnyAgents => false;

			public void SetObstacleQuery(GraphNode sourceNode)
			{
			}

			public void SetTarget(Vector3 targetPoint, float desiredSpeed, float maxSpeed, Vector3 endOfPath)
			{
			}

			public void SetCollisionNormal(Vector3 normal)
			{
			}

			public void ForceSetVelocity(Vector3 velocity)
			{
			}
		}

		public struct ObstacleData
		{
			public SlabAllocator<ObstacleVertexGroup> obstacleVertexGroups;

			public SlabAllocator<float3> obstacleVertices;

			public NativeList<UnmanagedObstacle> obstacles;

			public void Init(Allocator allocator)
			{
			}

			public void Dispose()
			{
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
			}

			public void SetTarget(int agentIndex, float3 targetPoint, float desiredSpeed, float maxSpeed, float3 endOfPath)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool HasDebugFlag(int agentIndex, AgentDebugFlags flag)
			{
				return false;
			}

			public void Dispose()
			{
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
			}

			public void Move(int fromIndex, int toIndex)
			{
			}

			public void Dispose()
			{
			}
		}

		public struct HorizonAgentData
		{
			public NativeArray<int> horizonSide;

			public NativeArray<float> horizonMinAngle;

			public NativeArray<float> horizonMaxAngle;

			public void Realloc(int size, Allocator allocator)
			{
			}

			public void Move(int fromIndex, int toIndex)
			{
			}

			public void Dispose()
			{
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
			}

			public void Dispose()
			{
			}
		}

		private float desiredDeltaTime;

		private int numAgents;

		private RedrawScope debugDrawingScope;

		public RVOQuadtreeBurst quadtree;

		public bool drawQuadtree;

		private Action[] agentPreCalculationCallbacks;

		private Action[] agentDestroyCallbacks;

		private Stack<int> freeAgentIndices;

		private TemporaryAgentData temporaryAgentData;

		private HorizonAgentData horizonAgentData;

		public AgentData simulationData;

		public AgentOutputData outputData;

		public const int MaxNeighbourCount = 50;

		public const int MaxBlockingAgentCount = 7;

		public const int MaxObstacleVertices = 256;

		public readonly MovementPlane movementPlane;

		private RWLock rwLock;

		public float DesiredDeltaTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SymmetryBreakingBias { get; set; }

		public bool HardCollisions { get; set; }

		public bool UseNavmeshAsObstacle { get; set; }

		public Rect AgentBounds => default(Rect);

		public int AgentCount => 0;

		public MovementPlane MovementPlane => default(MovementPlane);

		public bool anyAgentsInSimulation => false;

		public AgentNeighbourLookup GetAgentNeighbourLookup()
		{
			return default(AgentNeighbourLookup);
		}

		public void BlockUntilSimulationStepDone()
		{
		}

		public SimulatorBurst(MovementPlane movementPlane)
		{
		}

		public void ClearAgents()
		{
		}

		public void OnDestroy()
		{
		}

		private void AllocateAgentSpace()
		{
		}

		public IAgent AddAgent(Vector3 position)
		{
			return null;
		}

		public AgentIndex AddAgentBurst(float3 position)
		{
			return default(AgentIndex);
		}

		[Obsolete("Use AddAgent(Vector3) instead", true)]
		public IAgent AddAgent(IAgent agent)
		{
			return null;
		}

		public void RemoveAgent(IAgent agent)
		{
		}

		public void RemoveAgent(AgentIndex agent, bool okIfMissing = false)
		{
		}

		private void PreCalculation(JobHandle dependency)
		{
		}

		public JobHandle Update(JobHandle dependency, float dt, bool drawGizmos, Allocator allocator)
		{
			return default(JobHandle);
		}

		public RWLock.ReadLockAsync LockSimulationDataReadOnly()
		{
			return default(RWLock.ReadLockAsync);
		}

		public RWLock.WriteLockAsync LockSimulationDataReadWrite()
		{
			return default(RWLock.WriteLockAsync);
		}

		private JobHandle UpdateInternal<T>(JobHandle dependency, float deltaTime, bool drawGizmos, Allocator allocator) where T : struct, IMovementPlaneWrapper
		{
			return default(JobHandle);
		}
	}
}
