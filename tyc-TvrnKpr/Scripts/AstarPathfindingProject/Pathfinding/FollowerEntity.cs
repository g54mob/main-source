using System;
using System.Collections.Generic;
using Pathfinding.ECS;
using Pathfinding.ECS.RVO;
using Pathfinding.PID;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/AI/Follower Entity (2D,3D)")]
	[UniqueComponent(tag = "ai")]
	[UniqueComponent(tag = "rvo")]
	[DisallowMultipleComponent]
	public sealed class FollowerEntity : VersionedMonoBehaviour, IAstarAI, ISerializationCallbackReceiver
	{
		[Flags]
		private enum FollowerEntityMigrations
		{
			MigratePathfindingSettings = 1,
			MigrateMovementPlaneSource = 2,
			MigrateAutoRepathPolicy = 4,
			MigrateManagedSettings = 8
		}

		[SerializeField]
		private AgentCylinderShape shape;

		[SerializeField]
		private MovementSettings movement;

		[SerializeField]
		private ManagedState managedState;

		[SerializeField]
		private ManagedSettings managedSettings;

		[SerializeField]
		private bool enableLocalAvoidanceBacking;

		[SerializeField]
		private bool enableGravityBacking;

		[SerializeField]
		private RVOAgent rvoSettingsBacking;

		[SerializeField]
		private Pathfinding.ECS.AutoRepathPolicy autoRepathBacking;

		[SerializeField]
		private OrientationMode orientationBacking;

		[SerializeField]
		private MovementPlaneSource movementPlaneSourceBacking;

		[SerializeField]
		private bool syncPosition;

		[SerializeField]
		private bool syncRotation;

		private Transform tr;

		private FollowerEntityProxy proxy;

		private static EntityArchetype archetype;

		private static World archetypeWorld;

		public Entity entity
		{
			[IgnoredByDeepProfiler]
			get
			{
				return default(Entity);
			}
		}

		public World world => null;

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

		public Pathfinding.ECS.AutoRepathPolicy autoRepath
		{
			get
			{
				return default(Pathfinding.ECS.AutoRepathPolicy);
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

		[Obsolete("Renamed to simulateMovement")]
		public bool canMove
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

		public bool enableLocalAvoidance
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public ManagedMovementOverrides movementOverrides => default(ManagedMovementOverrides);

		public bool entityExists => false;

		private void OnEnable()
		{
		}

		public static Entity CreateEntity(float3 position, quaternion rotation, float scale, ref AgentCylinderShape shape, ref MovementSettings movement, ref Pathfinding.ECS.AutoRepathPolicy autoRepath, ManagedState managedState, OrientationMode orientation, MovementPlaneSource movementPlaneSource, bool updatePosition, bool updateRotation, bool enableGravity, bool enableLocalAvoidance, RVOAgent rvoSettings, ManagedSettings managedSettings, PhysicsScene physicsScene)
		{
			return default(Entity);
		}

		internal void RegisterRuntimeBaker(IRuntimeBaker baker)
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
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

		private void CancelCurrentPathRequest()
		{
		}

		public void SetPath(Path path, bool updateDestinationFromPath = true)
		{
		}

		public void Teleport(Vector3 newPosition, bool clearPath = true)
		{
		}

		private void FindComponents()
		{
		}

		public override void DrawGizmos()
		{
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
