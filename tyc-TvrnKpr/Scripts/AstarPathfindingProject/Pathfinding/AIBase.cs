using System;
using Pathfinding.RVO;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[RequireComponent(typeof(Seeker))]
	public abstract class AIBase : VersionedMonoBehaviour
	{
		public float radius;

		public float height;

		[FormerlySerializedAs("canMove")]
		public bool simulateMovement;

		[FormerlySerializedAs("speed")]
		public float maxSpeed;

		public Vector3 gravity;

		public LayerMask groundMask;

		public float endReachedDistance;

		public CloseToDestinationMode whenCloseToDestination;

		public RVODestinationCrowdedBehavior rvoDensityBehavior;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("repathRate")]
		private float repathRateCompatibility;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("canSearch")]
		[FormerlySerializedAs("repeatedlySearchPaths")]
		private bool canSearchCompability;

		[FormerlySerializedAs("rotationIn2D")]
		public OrientationMode orientation;

		public bool enableRotation;

		protected Vector3 simulatedPosition;

		protected Quaternion simulatedRotation;

		protected Vector3 accumulatedMovementDelta;

		protected Vector2 velocity2D;

		protected float verticalVelocity;

		protected Seeker seeker;

		protected Transform tr;

		protected Rigidbody rigid;

		protected Rigidbody2D rigid2D;

		protected CharacterController controller;

		protected RVOController rvoController;

		public SimpleMovementPlane movementPlane;

		public AutoRepathPolicy autoRepath;

		protected float lastDeltaTime;

		protected Vector3 prevPosition1;

		protected Vector3 prevPosition2;

		protected Vector2 lastDeltaPosition;

		protected bool waitingForPathCalculation;

		protected float lastRepath;

		protected bool startHasRun;

		private Vector3 destinationBackingField;

		protected OnPathDelegate onPathComplete;

		protected RaycastHit lastRaycastHit;

		public static readonly Color ShapeGizmoColor;

		public float repathRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		public Vector3 position => default(Vector3);

		public virtual Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public bool updatePosition { get; set; }

		public bool updateRotation { get; set; }

		protected bool usingGravity { get; set; }

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

		public Vector3 velocity => default(Vector3);

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

		public abstract Vector3 endOfPath { get; }

		public abstract bool reachedDestination { get; }

		public bool isStopped { get; set; }

		public Action onSearchPath { get; set; }

		protected virtual bool shouldRecalculatePath => false;

		public virtual void FindComponents()
		{
		}

		protected virtual void OnEnable()
		{
		}

		private static void OnUpdate(AIBase[] components, int count, TransformAccessArray transforms, BatchedEvents.Event ev)
		{
		}

		protected virtual void OnUpdate(float dt)
		{
		}

		protected virtual void Start()
		{
		}

		private void Init()
		{
		}

		public virtual void Teleport(Vector3 newPosition, bool clearPath = true)
		{
		}

		protected void CancelCurrentPathRequest()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public void MovementUpdate(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			nextPosition = default(Vector3);
			nextRotation = default(Quaternion);
		}

		protected abstract void MovementUpdateInternal(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation);

		protected virtual void CalculatePathRequestEndpoints(out Vector3 start, out Vector3 end)
		{
			start = default(Vector3);
			end = default(Vector3);
		}

		public virtual void SearchPath()
		{
		}

		public virtual Vector3 GetFeetPosition()
		{
			return default(Vector3);
		}

		protected abstract void OnPathComplete(Path newPath);

		protected abstract void ClearPath();

		public void SetPath(Path path, bool updateDestinationFromPath = true)
		{
		}

		protected virtual void ApplyGravity(float deltaTime)
		{
		}

		protected Vector2 CalculateDeltaToMoveThisFrame(Vector3 position, float distanceToEndOfPath, float deltaTime)
		{
			return default(Vector2);
		}

		public Quaternion SimulateRotationTowards(Vector3 direction, float maxDegrees)
		{
			return default(Quaternion);
		}

		protected Quaternion SimulateRotationTowards(Vector2 direction, float maxDegreesMainAxis, float maxDegreesOffAxis = 1f / 0f)
		{
			return default(Quaternion);
		}

		public virtual void Move(Vector3 deltaPosition)
		{
		}

		public virtual void FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation)
		{
		}

		private void FinalizeRotation(Quaternion nextRotation)
		{
		}

		private void FinalizePosition(Vector3 nextPosition)
		{
		}

		protected void UpdateVelocity()
		{
		}

		protected virtual Vector3 ClampToNavmesh(Vector3 position, out bool positionChanged)
		{
			positionChanged = default(bool);
			return default(Vector3);
		}

		protected Vector3 RaycastPosition(Vector3 position, float lastElevation)
		{
			return default(Vector3);
		}

		protected virtual void OnDrawGizmosSelected()
		{
		}

		public override void DrawGizmos()
		{
		}

		protected override void Reset()
		{
		}

		private void ResetShape()
		{
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
