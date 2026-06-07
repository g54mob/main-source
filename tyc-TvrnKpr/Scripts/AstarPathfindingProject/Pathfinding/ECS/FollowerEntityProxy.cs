using System;
using System.Collections.Generic;
using Pathfinding.ECS.RVO;
using Pathfinding.PID;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS
{
	public struct FollowerEntityProxy : IAstarAI
	{
		private class EntityDoesNotExistException : Exception
		{
		}

		private static NativeList<float3> nextCornersScratch;

		private static NativeArray<int> indicesScratch;

		internal static EntityAccess<DestinationPoint> destinationPointAccessRW;

		internal static EntityAccess<DestinationPoint> destinationPointAccessRO;

		internal static EntityAccess<AgentMovementPlane> movementPlaneAccessRW;

		internal static EntityAccess<AgentMovementPlane> movementPlaneAccessRO;

		internal static EntityAccess<MovementState> movementStateAccessRW;

		internal static EntityAccess<MovementState> movementStateAccessRO;

		internal static EntityAccess<MovementStatistics> movementOutputAccessRW;

		internal static EntityAccess<ResolvedMovement> resolvedMovementAccessRO;

		internal static EntityAccess<ResolvedMovement> resolvedMovementAccessRW;

		internal static EntityAccess<MovementControl> movementControlAccessRO;

		internal static EntityAccess<MovementControl> movementControlAccessRW;

		internal static EntityAccess<MovementStatistics> movementStatisticsAccessRW;

		internal static EntityAccess<MovementStatistics> movementStatisticsAccessRO;

		internal static ManagedEntityAccess<ManagedState> managedStateAccessRO;

		internal static ManagedEntityAccess<ManagedState> managedStateAccessRW;

		internal static ManagedEntityAccess<ManagedSettings> managedSettingsAccessRO;

		internal static ManagedEntityAccess<ManagedSettings> managedSettingsAccessRW;

		internal static EntityAccess<AutoRepathPolicy> autoRepathPolicyRW;

		internal static EntityAccess<LocalTransform> localTransformAccessRO;

		internal static EntityAccess<LocalTransform> localTransformAccessRW;

		internal static EntityAccess<AgentCylinderShape> agentCylinderShapeAccessRO;

		internal static EntityAccess<AgentCylinderShape> agentCylinderShapeAccessRW;

		internal static EntityAccess<MovementSettings> movementSettingsAccessRO;

		internal static EntityAccess<MovementSettings> movementSettingsAccessRW;

		internal static EntityAccess<AgentOffMeshLinkTraversal> agentOffMeshLinkTraversalRO;

		internal static EntityAccess<ReadyToTraverseOffMeshLink> readyToTraverseOffMeshLinkRW;

		internal static EntityAccess<RVOAgent> rvoSettingsAccessRO;

		internal static EntityAccess<RVOAgent> rvoSettingsAccessRW;

		internal static EntityStorageCache entityStorageCache;

		public Entity entity
		{
			[IgnoredByDeepProfiler]
			get;
			private set; }

		public World world
		{
			[IgnoredByDeepProfiler]
			get;
			private set; }

		public bool entityExists => false;

		internal bool likelyHasReasonableComponents => false;

		public float radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ref PathRequestSettings pathfindingSettings
		{
			get
			{
				throw null;
			}
		}

		public RVOAgent rvoSettings
		{
			get
			{
				return default(RVOAgent);
			}
			set
			{
			}
		}

		public Vector3 position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool isTraversingOffMeshLink => false;

		public OffMeshLinks.OffMeshLinkTracer offMeshLink => default(OffMeshLinks.OffMeshLinkTracer);

		public IOffMeshLinkHandler onTraverseOffMeshLink
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GraphNode currentNode => null;

		public GraphHitInfo nearestNavmeshBorder => default(GraphHitInfo);

		public Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public MovementPlaneSource movementPlaneSource
		{
			get
			{
				return default(MovementPlaneSource);
			}
			set
			{
			}
		}

		public LayerMask groundMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public PIDMovement.DebugFlags debugFlags
		{
			get
			{
				return default(PIDMovement.DebugFlags);
			}
			set
			{
			}
		}

		public float maxSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float rotationSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxRotationSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 velocity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 desiredVelocity => default(Vector3);

		public Vector3 desiredVelocityWithoutLocalAvoidance
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float remainingDistance => 0f;

		public float stopDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float positionSmoothing
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float rotationSmoothing
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool reachedDestination => false;

		public bool reachedEndOfPath => false;

		public bool reachedCrowdedEndOfPath => false;

		public Vector3 endOfPath => default(Vector3);

		public Vector3 destination
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 destinationFacingDirection => default(Vector3);

		public AutoRepathPolicy autoRepath
		{
			get
			{
				return default(AutoRepathPolicy);
			}
			set
			{
			}
		}

		[Obsolete("This has been superseded by autoRepath.mode")]
		public bool canSearch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool simulateMovement
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public NativeMovementPlane movementPlane => default(NativeMovementPlane);

		public bool enableGravity
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool enableLocalAvoidance => false;

		public bool localAvoidanceTemporarilyDisabled => false;

		public bool updatePosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool updateRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public OrientationMode orientation
		{
			get
			{
				return default(OrientationMode);
			}
			set
			{
			}
		}

		public bool hasPath => false;

		public bool pathPending => false;

		public bool isStopped
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MovementSettings movementSettings
		{
			get
			{
				return default(MovementSettings);
			}
			set
			{
			}
		}

		public Vector3 steeringTarget => default(Vector3);

		public ManagedMovementOverrides movementOverrides => default(ManagedMovementOverrides);

		Action IAstarAI.onSearchPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private static void InitScratchData()
		{
		}

		private static void DisposeScratchData()
		{
		}

		public FollowerEntityProxy(World world, Entity entity)
		{
			this.entity = default(Entity);
			this.world = null;
		}

		private void AssertEntityExists()
		{
		}

		public void SetDestination(float3 destination, float3 facingDirection = default(float3))
		{
		}

		void IAstarAI.FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation)
		{
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			stale = default(bool);
		}

		public void GetRemainingPath(List<Vector3> buffer, List<PathPartWithLinkInfo> partsBuffer, out bool stale)
		{
			stale = default(bool);
		}

		public void Move(Vector3 deltaPosition)
		{
		}

		void IAstarAI.MovementUpdate(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			nextPosition = default(Vector3);
			nextRotation = default(Quaternion);
		}

		public void SearchPath()
		{
		}

		internal void CancelCurrentPathRequest()
		{
		}

		internal void ClearPath()
		{
		}

		internal static void ToggleComponent<T>(World world, Entity entity, bool enabled, bool mustExist) where T : struct, IComponentData
		{
		}

		internal static void ToggleComponentEnabled<T>(World world, Entity entity, bool enabled, bool mustExist) where T : struct, IComponentData, IEnableableComponent
		{
		}

		internal static void ResetControl(ref ResolvedMovement resolvedMovement, ref MovementControl controlOutput, ref AgentMovementPlane movementPlane, float3 position, quaternion rotation, float3 endOfPath)
		{
		}

		public void SetPath(Path path, bool updateDestinationFromPath = true)
		{
		}

		public void Teleport(Vector3 newPosition, bool clearPath = true)
		{
		}

		public void Destroy()
		{
		}
	}
}
