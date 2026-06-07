using System;
using Pathfinding.Drawing;
using Pathfinding.Jobs;
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
		public float radius = 0.5f;

		public float height = 2f;

		public bool canMove = true;

		[FormerlySerializedAs("speed")]
		public float maxSpeed = 1f;

		public Vector3 gravity = new Vector3(float.NaN, float.NaN, float.NaN);

		public LayerMask groundMask = -1;

		public float endReachedDistance = 0.2f;

		public CloseToDestinationMode whenCloseToDestination;

		public RVODestinationCrowdedBehavior rvoDensityBehavior = new RVODestinationCrowdedBehavior(enabled: true, 0.5f, returnAfterBeingPushedAway: false);

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("centerOffset")]
		private float centerOffsetCompatibility = float.NaN;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("repathRate")]
		private float repathRateCompatibility = float.NaN;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("canSearch")]
		[FormerlySerializedAs("repeatedlySearchPaths")]
		private bool canSearchCompability;

		[FormerlySerializedAs("rotationIn2D")]
		public OrientationMode orientation;

		public bool enableRotation = true;

		protected Vector3 simulatedPosition;

		protected Quaternion simulatedRotation;

		protected Vector3 accumulatedMovementDelta = Vector3.zero;

		protected Vector2 velocity2D;

		protected float verticalVelocity;

		protected Seeker seeker;

		protected Transform tr;

		protected Rigidbody rigid;

		protected Rigidbody2D rigid2D;

		protected CharacterController controller;

		protected RVOController rvoController;

		public SimpleMovementPlane movementPlane = new SimpleMovementPlane(Quaternion.identity);

		[NonSerialized]
		public bool updatePosition = true;

		[NonSerialized]
		public bool updateRotation = true;

		public AutoRepathPolicy autoRepath = new AutoRepathPolicy();

		protected float lastDeltaTime;

		protected Vector3 prevPosition1;

		protected Vector3 prevPosition2;

		protected Vector2 lastDeltaPosition;

		protected bool waitingForPathCalculation;

		protected float lastRepath = float.NegativeInfinity;

		[FormerlySerializedAs("target")]
		[SerializeField]
		[HideInInspector]
		private Transform targetCompatibility;

		protected bool startHasRun;

		private Vector3 destinationBackingField = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

		protected OnPathDelegate onPathComplete;

		protected RaycastHit lastRaycastHit;

		public static readonly Color ShapeGizmoColor = new Color(0.9411765f, 71f / 85f, 0.11764706f);

		public float repathRate
		{
			get
			{
				return autoRepath.period;
			}
			set
			{
				autoRepath.period = value;
			}
		}

		public bool canSearch
		{
			get
			{
				return autoRepath.mode != AutoRepathPolicy.Mode.Never;
			}
			set
			{
				if (value)
				{
					if (autoRepath.mode == AutoRepathPolicy.Mode.Never)
					{
						autoRepath.mode = AutoRepathPolicy.Mode.EveryNSeconds;
					}
				}
				else
				{
					autoRepath.mode = AutoRepathPolicy.Mode.Never;
				}
			}
		}

		[Obsolete("Use the height property instead (2x this value)")]
		public float centerOffset
		{
			get
			{
				return height * 0.5f;
			}
			set
			{
				height = value * 2f;
			}
		}

		[Obsolete("Use orientation instead")]
		public bool rotationIn2D
		{
			get
			{
				return orientation == OrientationMode.YAxisForward;
			}
			set
			{
				orientation = (value ? OrientationMode.YAxisForward : OrientationMode.ZAxisForward);
			}
		}

		public Vector3 position
		{
			get
			{
				if (!updatePosition)
				{
					return simulatedPosition;
				}
				return tr.position;
			}
		}

		public virtual Quaternion rotation
		{
			get
			{
				if (!updateRotation)
				{
					return simulatedRotation;
				}
				return tr.rotation;
			}
			set
			{
				if (updateRotation)
				{
					tr.rotation = value;
				}
				else
				{
					simulatedRotation = value;
				}
			}
		}

		protected bool usingGravity { get; set; }

		[Obsolete("Use the destination property or the AIDestinationSetter component instead")]
		public Transform target
		{
			get
			{
				if (!TryGetComponent<AIDestinationSetter>(out var component))
				{
					return null;
				}
				return component.target;
			}
			set
			{
				targetCompatibility = null;
				if (!TryGetComponent<AIDestinationSetter>(out var component))
				{
					component = base.gameObject.AddComponent<AIDestinationSetter>();
				}
				component.target = value;
				destination = ((value != null) ? value.position : new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity));
			}
		}

		public Vector3 destination
		{
			get
			{
				return destinationBackingField;
			}
			set
			{
				if (rvoDensityBehavior.enabled && !(value == destinationBackingField) && (!float.IsPositiveInfinity(value.x) || !float.IsPositiveInfinity(destinationBackingField.x)))
				{
					destinationBackingField = value;
					rvoDensityBehavior.OnDestinationChanged(value, reachedDestination);
				}
				else
				{
					destinationBackingField = value;
				}
			}
		}

		public Vector3 velocity
		{
			get
			{
				if (!(lastDeltaTime > 1E-06f))
				{
					return Vector3.zero;
				}
				return (prevPosition1 - prevPosition2) / lastDeltaTime;
			}
		}

		public Vector3 desiredVelocity
		{
			get
			{
				if (!(lastDeltaTime > 1E-05f))
				{
					return Vector3.zero;
				}
				return movementPlane.ToWorld(lastDeltaPosition / lastDeltaTime, verticalVelocity);
			}
		}

		public Vector3 desiredVelocityWithoutLocalAvoidance
		{
			get
			{
				return movementPlane.ToWorld(velocity2D, verticalVelocity);
			}
			set
			{
				velocity2D = movementPlane.ToPlane(value, out verticalVelocity);
			}
		}

		public abstract Vector3 endOfPath { get; }

		public abstract bool reachedDestination { get; }

		public bool isStopped { get; set; }

		public Action onSearchPath { get; set; }

		protected virtual bool shouldRecalculatePath
		{
			get
			{
				if (!waitingForPathCalculation)
				{
					return autoRepath.ShouldRecalculatePath(position, radius, destination, Time.time);
				}
				return false;
			}
		}

		public virtual void FindComponents()
		{
			tr = base.transform;
			if (!seeker)
			{
				TryGetComponent<Seeker>(out seeker);
			}
			if (!rvoController)
			{
				TryGetComponent<RVOController>(out rvoController);
			}
			if (!controller)
			{
				TryGetComponent<CharacterController>(out controller);
			}
			if (!rigid)
			{
				TryGetComponent<Rigidbody>(out rigid);
			}
			if (!rigid2D)
			{
				TryGetComponent<Rigidbody2D>(out rigid2D);
			}
		}

		protected virtual void OnEnable()
		{
			FindComponents();
			onPathComplete = OnPathComplete;
			Init();
			bool flag = rigid != null || rigid2D != null;
			BatchedEvents.Add(this, (!flag) ? BatchedEvents.Event.Update : BatchedEvents.Event.FixedUpdate, OnUpdate);
		}

		private static void OnUpdate(AIBase[] components, int count, TransformAccessArray transforms, BatchedEvents.Event ev)
		{
			Physics.SyncTransforms();
			Physics2D.SyncTransforms();
			float num = ((ev == BatchedEvents.Event.FixedUpdate) ? Time.fixedDeltaTime : Time.deltaTime);
			SimulatorBurst simulatorBurst = RVOSimulator.active?.GetSimulator();
			if (simulatorBurst != null)
			{
				int num2 = 0;
				for (int i = 0; i < count; i++)
				{
					num2 += ((components[i].rvoController != null && components[i].rvoController.enabled) ? 1 : 0);
				}
				RVODestinationCrowdedBehavior.JobDensityCheck jobResult = new RVODestinationCrowdedBehavior.JobDensityCheck(num2, num);
				int j = 0;
				int num3 = 0;
				for (; j < count; j++)
				{
					AIBase aIBase = components[j];
					if (aIBase.rvoController != null && aIBase.rvoController.enabled)
					{
						jobResult.Set(num3, aIBase.rvoController.rvoAgent.AgentIndex, aIBase.endOfPath, aIBase.rvoDensityBehavior.densityThreshold, aIBase.rvoDensityBehavior.progressAverage);
						num3++;
					}
				}
				jobResult.ScheduleBatch(num2, num2 / 16, simulatorBurst.lastJob).Complete();
				int k = 0;
				int num4 = 0;
				for (; k < count; k++)
				{
					AIBase aIBase2 = components[k];
					if (aIBase2.rvoController != null && aIBase2.rvoController.enabled)
					{
						aIBase2.rvoDensityBehavior.ReadJobResult(ref jobResult, num4);
						num4++;
					}
				}
				jobResult.Dispose();
			}
			for (int l = 0; l < count; l++)
			{
				components[l].OnUpdate(num);
			}
			if (count > 0 && components[0] is AIPathAlignedToSurface)
			{
				AIPathAlignedToSurface.UpdateMovementPlanes(components as AIPathAlignedToSurface[], count);
			}
			Physics.SyncTransforms();
			Physics2D.SyncTransforms();
		}

		protected virtual void OnUpdate(float dt)
		{
			usingGravity = !(gravity == Vector3.zero) && (!updatePosition || ((rigid == null || rigid.isKinematic) && (rigid2D == null || rigid2D.isKinematic)));
			if (shouldRecalculatePath)
			{
				SearchPath();
			}
			if (canMove)
			{
				MovementUpdate(dt, out var nextPosition, out var nextRotation);
				FinalizeMovement(nextPosition, nextRotation);
			}
		}

		protected virtual void Start()
		{
			startHasRun = true;
			Init();
		}

		private void Init()
		{
			if (startHasRun)
			{
				if (canMove)
				{
					Teleport(position, clearPath: false);
				}
				autoRepath.Reset();
				if (shouldRecalculatePath)
				{
					SearchPath();
				}
			}
		}

		public virtual void Teleport(Vector3 newPosition, bool clearPath = true)
		{
			if (clearPath)
			{
				ClearPath();
			}
			prevPosition1 = (prevPosition2 = (simulatedPosition = newPosition));
			if (updatePosition)
			{
				tr.position = newPosition;
			}
			if (rvoController != null)
			{
				rvoController.Move(Vector3.zero);
			}
			if (clearPath)
			{
				SearchPath();
			}
		}

		protected void CancelCurrentPathRequest()
		{
			waitingForPathCalculation = false;
			if (seeker != null)
			{
				seeker.CancelCurrentPathRequest();
			}
		}

		protected virtual void OnDisable()
		{
			BatchedEvents.Remove(this);
			ClearPath();
			velocity2D = Vector3.zero;
			accumulatedMovementDelta = Vector3.zero;
			verticalVelocity = 0f;
			lastDeltaTime = 0f;
		}

		public void MovementUpdate(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation)
		{
			lastDeltaTime = deltaTime;
			MovementUpdateInternal(deltaTime, out nextPosition, out nextRotation);
		}

		protected abstract void MovementUpdateInternal(float deltaTime, out Vector3 nextPosition, out Quaternion nextRotation);

		protected virtual void CalculatePathRequestEndpoints(out Vector3 start, out Vector3 end)
		{
			start = GetFeetPosition();
			end = destination;
		}

		public virtual void SearchPath()
		{
			if (!float.IsPositiveInfinity(destination.x))
			{
				if (onSearchPath != null)
				{
					onSearchPath();
				}
				CalculatePathRequestEndpoints(out var start, out var end);
				ABPath path = ABPath.Construct(start, end);
				SetPath(path, updateDestinationFromPath: false);
			}
		}

		public virtual Vector3 GetFeetPosition()
		{
			return position;
		}

		protected abstract void OnPathComplete(Path newPath);

		protected abstract void ClearPath();

		public void SetPath(Path path, bool updateDestinationFromPath = true)
		{
			if (updateDestinationFromPath && path is ABPath { endPointKnownBeforeCalculation: not false } aBPath)
			{
				destination = aBPath.originalEndPoint;
			}
			if (path == null)
			{
				CancelCurrentPathRequest();
				ClearPath();
				return;
			}
			if (path.PipelineState == PathState.Created)
			{
				waitingForPathCalculation = true;
				seeker.CancelCurrentPathRequest();
				seeker.StartPath(path, onPathComplete);
				autoRepath.DidRecalculatePath(destination, Time.time);
				return;
			}
			if (path.PipelineState >= PathState.Returning)
			{
				if (seeker.GetCurrentPath() != path)
				{
					seeker.CancelCurrentPathRequest();
				}
				OnPathComplete(path);
				return;
			}
			throw new ArgumentException("You must call the SetPath method with a path that either has been completely calculated or one whose path calculation has not been started at all. It looks like the path calculation for the path you tried to use has been started, but is not yet finished.");
		}

		protected virtual void ApplyGravity(float deltaTime)
		{
			if (usingGravity)
			{
				velocity2D += movementPlane.ToPlane(deltaTime * (float.IsNaN(gravity.x) ? Physics.gravity : gravity), out var elevation);
				verticalVelocity += elevation;
			}
			else
			{
				verticalVelocity = 0f;
			}
		}

		protected Vector2 CalculateDeltaToMoveThisFrame(Vector3 position, float distanceToEndOfPath, float deltaTime)
		{
			if (rvoController != null && rvoController.enabled)
			{
				return movementPlane.ToPlane(rvoController.CalculateMovementDelta(position, deltaTime));
			}
			return Vector2.ClampMagnitude(velocity2D * deltaTime, distanceToEndOfPath);
		}

		public Quaternion SimulateRotationTowards(Vector3 direction, float maxDegrees)
		{
			return SimulateRotationTowards(movementPlane.ToPlane(direction), maxDegrees, maxDegrees);
		}

		protected Quaternion SimulateRotationTowards(Vector2 direction, float maxDegreesMainAxis, float maxDegreesOffAxis = float.PositiveInfinity)
		{
			Quaternion to;
			if (movementPlane.isXY || movementPlane.isXZ)
			{
				if (direction == Vector2.zero)
				{
					return simulatedRotation;
				}
				to = Quaternion.LookRotation(movementPlane.ToWorld(direction), movementPlane.ToWorld(Vector2.zero, 1f));
				maxDegreesOffAxis = maxDegreesMainAxis;
			}
			else
			{
				Vector2 vector = movementPlane.ToPlane(rotation * ((orientation == OrientationMode.YAxisForward) ? Vector3.up : Vector3.forward));
				if (vector == Vector2.zero)
				{
					vector = Vector2.right;
				}
				Vector2 vector2 = VectorMath.ComplexMultiplyConjugate(direction, vector);
				float f = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
				Quaternion quaternion2 = Quaternion.AngleAxis((0f - Mathf.Min(Mathf.Abs(f), maxDegreesMainAxis)) * Mathf.Sign(f), Vector3.up);
				to = Quaternion.LookRotation(movementPlane.ToWorld(vector), movementPlane.ToWorld(Vector2.zero, 1f));
				to *= quaternion2;
			}
			if (orientation == OrientationMode.YAxisForward)
			{
				to *= Quaternion.Euler(90f, 0f, 0f);
			}
			return Quaternion.RotateTowards(simulatedRotation, to, maxDegreesOffAxis);
		}

		public virtual void Move(Vector3 deltaPosition)
		{
			accumulatedMovementDelta += deltaPosition;
		}

		public virtual void FinalizeMovement(Vector3 nextPosition, Quaternion nextRotation)
		{
			if (enableRotation)
			{
				FinalizeRotation(nextRotation);
			}
			FinalizePosition(nextPosition);
		}

		private void FinalizeRotation(Quaternion nextRotation)
		{
			simulatedRotation = nextRotation;
			if (updateRotation)
			{
				if (rigid != null)
				{
					rigid.MoveRotation(nextRotation);
				}
				else if (rigid2D != null)
				{
					rigid2D.MoveRotation(nextRotation.eulerAngles.z);
				}
				else
				{
					tr.rotation = nextRotation;
				}
			}
		}

		private void FinalizePosition(Vector3 nextPosition)
		{
			Vector3 vector = simulatedPosition;
			bool flag = false;
			if (controller != null && controller.enabled && updatePosition)
			{
				tr.position = vector;
				controller.Move(nextPosition - vector + accumulatedMovementDelta);
				vector = tr.position;
				if (controller.isGrounded)
				{
					verticalVelocity = 0f;
				}
			}
			else
			{
				movementPlane.ToPlane(vector, out var elevation);
				vector = nextPosition + accumulatedMovementDelta;
				if (usingGravity)
				{
					vector = RaycastPosition(vector, elevation);
				}
				flag = true;
			}
			bool positionChanged = false;
			vector = ClampToNavmesh(vector, out positionChanged);
			if ((flag || positionChanged) && updatePosition)
			{
				if (rigid != null)
				{
					rigid.MovePosition(vector);
				}
				else if (rigid2D != null)
				{
					rigid2D.MovePosition(vector);
				}
				else
				{
					tr.position = vector;
				}
			}
			accumulatedMovementDelta = Vector3.zero;
			simulatedPosition = vector;
			UpdateVelocity();
		}

		protected void UpdateVelocity()
		{
			prevPosition2 = prevPosition1;
			prevPosition1 = position;
		}

		protected virtual Vector3 ClampToNavmesh(Vector3 position, out bool positionChanged)
		{
			positionChanged = false;
			return position;
		}

		protected Vector3 RaycastPosition(Vector3 position, float lastElevation)
		{
			movementPlane.ToPlane(position, out var elevation);
			float num = tr.localScale.y * height * 0.5f + Mathf.Max(0f, lastElevation - elevation);
			Vector3 vector = movementPlane.ToWorld(Vector2.zero, num);
			if (Physics.Raycast(position + vector, -vector, out lastRaycastHit, num, groundMask, QueryTriggerInteraction.Ignore))
			{
				verticalVelocity *= Math.Max(0f, 1f - 5f * lastDeltaTime);
				return lastRaycastHit.point;
			}
			return position;
		}

		protected virtual void OnDrawGizmosSelected()
		{
			if (Application.isPlaying)
			{
				FindComponents();
			}
		}

		public override void DrawGizmos()
		{
			if (!Application.isPlaying || !base.enabled || tr == null)
			{
				FindComponents();
			}
			Color shapeGizmoColor = ShapeGizmoColor;
			if (rvoController != null && rvoController.locked)
			{
				shapeGizmoColor *= 0.5f;
			}
			if (orientation == OrientationMode.YAxisForward)
			{
				Draw.WireCylinder(position, Vector3.forward, 0f, radius * tr.localScale.x, shapeGizmoColor);
			}
			else
			{
				Draw.WireCylinder(position, rotation * Vector3.up, tr.localScale.y * height, radius * tr.localScale.x, shapeGizmoColor);
			}
			if (!float.IsPositiveInfinity(destination.x) && Application.isPlaying)
			{
				Draw.Circle(destination, movementPlane.rotation * Vector3.up, 0.2f, Color.blue);
			}
			autoRepath.DrawGizmos(Draw.editor, position, radius, new NativeMovementPlane(movementPlane.rotation));
		}

		protected override void Reset()
		{
			ResetShape();
			base.Reset();
		}

		private void ResetShape()
		{
			if (TryGetComponent<CharacterController>(out var component))
			{
				radius = component.radius;
				height = Mathf.Max(radius * 2f, component.height);
			}
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.TryMigrateFromLegacyFormat(out var legacyVersion))
			{
				if (legacyVersion <= 2 || legacyVersion == 5)
				{
					rvoDensityBehavior.enabled = false;
				}
				if (legacyVersion <= 3)
				{
					repathRate = repathRateCompatibility;
					canSearch = canSearchCompability;
				}
			}
			if (unityThread && !float.IsNaN(centerOffsetCompatibility))
			{
				height = centerOffsetCompatibility * 2f;
				ResetShape();
				if (TryGetComponent<RVOController>(out var component))
				{
					radius = component.radiusBackingField;
				}
				centerOffsetCompatibility = float.NaN;
			}
			if (unityThread && targetCompatibility != null)
			{
				target = targetCompatibility;
			}
		}
	}
}
