using System;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[RequireComponent(typeof(Seeker))]
	[AddComponentMenu("Pathfinding/AI/AILerp (2D,3D)")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_lerp.php")]
	public class AILerp : VersionedMonoBehaviour, IAstarAI
	{
		public AutoRepathPolicy autoRepath;

		public bool canMove;

		public float speed;

		[FormerlySerializedAs("rotationIn2D")]
		public OrientationMode orientation;

		public bool enableRotation;

		public float rotationSpeed;

		public bool interpolatePathSwitches;

		public float switchPathInterpolationSpeed;

		[NonSerialized]
		public bool updatePosition;

		[NonSerialized]
		public bool updateRotation;

		protected Seeker seeker;

		protected Transform tr;

		protected ABPath path;

		protected bool canSearchAgain;

		protected Vector3 previousMovementOrigin;

		protected Vector3 previousMovementDirection;

		protected float pathSwitchInterpolationTime;

		protected PathInterpolator interpolator;

		private bool startHasRun;

		private Vector3 previousPosition1;

		private Vector3 previousPosition2;

		private Vector3 simulatedPosition;

		private Quaternion simulatedRotation;

		[FormerlySerializedAs("target")]
		[SerializeField]
		[HideInInspector]
		private Transform targetCompatibility;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("repathRate")]
		private float repathRateCompatibility;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("canSearch")]
		private bool canSearchCompability;

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

		public bool reachedEndOfPath { get; private set; }

		public bool reachedDestination => false;

		public Vector3 destination { get; set; }

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

		float IAstarAI.radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float IAstarAI.height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		float IAstarAI.maxSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		bool IAstarAI.canSearch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IAstarAI.canMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector3 velocity => default(Vector3);

		Vector3 IAstarAI.desiredVelocity => default(Vector3);

		Vector3 IAstarAI.steeringTarget => default(Vector3);

		public float remainingDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool hasPath => false;

		public bool pathPending => false;

		public bool isStopped { get; set; }

		public Action onSearchPath { get; set; }

		protected virtual bool shouldRecalculatePath => false;

		void IAstarAI.Move(Vector3 deltaPosition)
		{
		}

		protected AILerp()
		{
		}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnEnable()
		{
		}

		private void Init()
		{
		}

		public void OnDisable()
		{
		}

		public void GetRemainingPath(List<Vector3> buffer, out bool stale)
		{
			stale = default(bool);
		}

		public void Teleport(Vector3 position, bool clearPath = true)
		{
		}

		[Obsolete("Use SearchPath instead")]
		public virtual void ForceSearchPath()
		{
		}

		public virtual void SearchPath()
		{
		}

		public virtual void OnTargetReached()
		{
		}

		protected virtual void OnPathComplete(Path _p)
		{
		}

		protected virtual void ClearPath()
		{
		}

		public void SetPath(Path path)
		{
		}

		protected virtual void ConfigurePathSwitchInterpolation()
		{
		}

		public virtual Vector3 GetFeetPosition()
		{
			return default(Vector3);
		}

		protected virtual void ConfigureNewPath()
		{
		}

		protected virtual void Update()
		{
		}

		public void MovementUpdate(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			nextPosition = default(Vector3);
			nextRotation = default(Quaternion);
		}

		public void FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation)
		{
		}

		private Quaternion SimulateRotationTowards(Vector3 direction, float deltaTime)
		{
			return default(Quaternion);
		}

		protected virtual Vector3 CalculateNextPosition(out Vector3 direction, float deltaTime)
		{
			direction = default(Vector3);
			return default(Vector3);
		}

		protected override int OnUpgradeSerializedData(int version, bool unityThread)
		{
			return 0;
		}

		public virtual void OnDrawGizmos()
		{
		}
	}
}
