using System;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[RequireComponent(typeof(Seeker))]
	public abstract class AIBase : VersionedMonoBehaviour
	{
		public float radius;

		public float height;

		public bool canMove;

		[FormerlySerializedAs("speed")]
		public float maxSpeed;

		public Vector3 gravity;

		public LayerMask groundMask;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("centerOffset")]
		private float centerOffsetCompatibility;

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

		private Vector3 accumulatedMovementDelta;

		protected Vector2 velocity2D;

		protected float verticalVelocity;

		protected Seeker seeker;

		protected Transform tr;

		protected Rigidbody rigid;

		protected Rigidbody2D rigid2D;

		protected CharacterController controller;

		public IMovementPlane movementPlane;

		[NonSerialized]
		public bool updatePosition;

		[NonSerialized]
		public bool updateRotation;

		public AutoRepathPolicy autoRepath;

		protected float lastDeltaTime;

		protected int prevFrame;

		protected Vector3 prevPosition1;

		protected Vector3 prevPosition2;

		protected Vector2 lastDeltaPosition;

		protected bool waitingForPathCalculation;

		[FormerlySerializedAs("target")]
		[SerializeField]
		[HideInInspector]
		private Transform targetCompatibility;

		private bool startHasRun;

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

		[Obsolete("Use the height property instead (2x this value)")]
		public float centerOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("Use orientation instead")]
		public bool rotationIn2D
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

		protected bool usingGravity { get; set; }

		[Obsolete("Use the destination property or the AIDestinationSetter component instead")]
		public Transform target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 destination { get; set; }

		public Vector3 velocity => default(Vector3);

		public Vector3 desiredVelocity => default(Vector3);

		public bool isStopped { get; set; }

		public Action onSearchPath { get; set; }

		protected virtual bool shouldRecalculatePath => false;

		public virtual void FindComponents()
		{
		}

		protected virtual void OnEnable()
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

		protected virtual void Update()
		{
		}

		protected virtual void FixedUpdate()
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

		public void SetPath(Path path)
		{
		}

		protected void ApplyGravity(float deltaTime)
		{
		}

		protected Vector2 CalculateDeltaToMoveThisFrame(Vector2 position, float distanceToEndOfPath, float deltaTime)
		{
			return default(Vector2);
		}

		public Quaternion SimulateRotationTowards(Vector3 direction, float maxDegrees)
		{
			return default(Quaternion);
		}

		protected Quaternion SimulateRotationTowards(Vector2 direction, float maxDegrees)
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

		protected virtual void OnDrawGizmos()
		{
		}

		protected override void Reset()
		{
		}

		private void ResetShape()
		{
		}

		protected override int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 0;
		}
	}
}
