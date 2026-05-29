using System;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace FluffyUnderware.Curvy.Controllers
{
	[ExecuteAlways]
	public abstract class CurvyController : DTVersionedMonoBehaviour, ISerializationCallbackReceiver
	{
		public enum CurvyControllerState
		{
			Stopped = 0,
			Playing = 1,
			Paused = 2
		}

		public enum MoveModeEnum
		{
			Relative = 0,
			AbsolutePrecise = 1
		}

		protected class OrientationDamper
		{
			[NotNull]
			private readonly CurvyController controller;

			[Obsolete]
			[UsedImplicitly]
			public Vector3 DirectionDampingVelocity;

			[UsedImplicitly]
			[Obsolete]
			public Vector3 UpDampingVelocity;

			public OrientationDamper([NotNull] CurvyController controller)
			{
			}

			public Quaternion Damp(Quaternion sourceOrientation, Vector3 targetForward, Vector3 targetUp, float deltaTime)
			{
				return default(Quaternion);
			}

			private Vector3 DampenVector(Vector3 current, Vector3 target, float deltaTime, float dampingTime, ref Vector3 velocity)
			{
				return default(Vector3);
			}

			public void Reset()
			{
			}
		}

		[Section("General", true, false, 100, Sort = 0, HelpURL = "https://curvyeditor.com/doclink/curvycontroller_general")]
		[Label(Tooltip = "Determines when to update")]
		public CurvyUpdateMethod UpdateIn;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("The component controlled by the controller")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private TargetComponent targetComponent;

		[Section("Position", true, false, 100, Sort = 100, HelpURL = "https://curvyeditor.com/doclink/curvycontroller_position")]
		[SerializeField]
		private CurvyPositionMode m_PositionMode;

		[RangeEx(0f, "maxPosition", null, null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FormerlySerializedAs("m_InitialPosition")]
		[SerializeField]
		protected float m_Position;

		[Section("Motion", true, false, 100, Sort = 200, HelpURL = "https://curvyeditor.com/doclink/curvycontroller_move")]
		[SerializeField]
		private MoveModeEnum m_MoveMode;

		[Positive]
		[SerializeField]
		private float m_Speed;

		[SerializeField]
		private MovementDirection m_Direction;

		[SerializeField]
		private CurvyClamping m_Clamping;

		[Tooltip("Defines what motions are to be frozen")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[Label("Constraints", null)]
		private MotionConstraints motionConstraints;

		[Tooltip("Start playing automatically when entering play mode")]
		[SerializeField]
		private bool m_PlayAutomatically;

		[Label("Source", "Source Vector")]
		[Section("Orientation", true, false, 100, Sort = 300, HelpURL = "https://curvyeditor.com/doclink/curvycontroller_orientation")]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private OrientationModeEnum m_OrientationMode;

		[Label("Lock Rotation", "When set, the controller will enforce the rotation to not change")]
		[SerializeField]
		private bool m_LockRotation;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Label("Target", "Target Vector3")]
		private OrientationAxisEnum m_OrientationAxis;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[Tooltip("Should the orientation ignore the movement direction?")]
		private bool m_IgnoreDirection;

		[FluffyUnderware.DevTools.Min(0f, "Direction Damping Time", "If non zero, the direction vector (forward) of the controlled object will not be updated instantly, but using a damping effect that will last the specified amount of time.")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private float m_DampingDirection;

		[FluffyUnderware.DevTools.Min(0f, "Up Damping Time", "If non zero, the up vector of the controlled object will not be updated instantly, but using a damping effect that will last the specified amount of time.")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private float m_DampingUp;

		[SerializeField]
		[Section("Offset", true, false, 100, Sort = 400, HelpURL = "https://curvyeditor.com/doclink/curvycontroller_orientation")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[RangeEx(-180f, 180f, null, null)]
		private float m_OffsetAngle;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private float m_OffsetRadius;

		[Label("Compensate Offset", "Adjusts speed to match the change of travel distance due to offset")]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private bool m_OffsetCompensation;

		[Section("Events", true, false, 100, Sort = 500)]
		[SerializeField]
		protected ControllerEvent onInitialized;

		protected const string ControllerNotReadyMessage = "The controller is not yet ready";

		protected CurvyControllerState State;

		protected float PrePlayPosition;

		protected MovementDirection PrePlayDirection;

		protected Quaternion LockedRotation;

		public ControllerEvent OnInitialized => null;

		public TargetComponent TargetComponent
		{
			get
			{
				return default(TargetComponent);
			}
			set
			{
			}
		}

		public CurvyPositionMode PositionMode
		{
			get
			{
				return default(CurvyPositionMode);
			}
			set
			{
			}
		}

		public MoveModeEnum MoveMode
		{
			get
			{
				return default(MoveModeEnum);
			}
			set
			{
			}
		}

		public bool PlayAutomatically
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CurvyClamping Clamping
		{
			get
			{
				return default(CurvyClamping);
			}
			set
			{
			}
		}

		public MotionConstraints MotionConstraints
		{
			get
			{
				return default(MotionConstraints);
			}
			set
			{
			}
		}

		public OrientationModeEnum OrientationMode
		{
			get
			{
				return default(OrientationModeEnum);
			}
			set
			{
			}
		}

		public bool LockRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public OrientationAxisEnum OrientationAxis
		{
			get
			{
				return default(OrientationAxisEnum);
			}
			set
			{
			}
		}

		public float DirectionDampingTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float UpDampingTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IgnoreDirection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float OffsetAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float OffsetRadius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool OffsetCompensation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Speed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RelativePosition
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AbsolutePosition
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Position
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MovementDirection MovementDirection
		{
			get
			{
				return default(MovementDirection);
			}
			set
			{
			}
		}

		public CurvyControllerState PlayState => default(CurvyControllerState);

		public abstract bool IsReady { get; }

		protected virtual bool ShouldDisablePositionSlider => false;

		[NotNull]
		protected OrientationDamper Damper { get; }

		public virtual Transform Transform => null;

		public virtual Rigidbody Rigidbody
		{
			[CanBeNull]
			get
			{
				return null;
			}
		}

		public virtual Rigidbody2D Rigidbody2D
		{
			[CanBeNull]
			get
			{
				return null;
			}
		}

		protected virtual bool ShowOrientationSection => false;

		protected virtual bool ShowOffsetSection => false;

		public abstract float Length { get; }

		protected bool isInitialized { get; private set; }

		protected float TimeSinceLastUpdate => 0f;

		protected bool UseOffset => false;

		private float maxPosition => 0f;

		private bool IsNeededRigidbodyMissing => false;

		private bool IsNeeded2DRigidbodyMissing => false;

		private bool IsNeededRigidbodyNotKinematic => false;

		private bool IsNeeded2DRigidbodyNotKinematic => false;

		private bool AreConstraintsConflicting => false;

		[UsedImplicitly]
		[Obsolete]
		protected Vector3 DirectionDampingVelocity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[Obsolete]
		[UsedImplicitly]
		protected Vector3 UpDampingVelocity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		[UsedImplicitly]
		protected virtual void Start()
		{
		}

		protected override void OnDisable()
		{
		}

		[UsedImplicitly]
		protected virtual void Update()
		{
		}

		[UsedImplicitly]
		protected virtual void LateUpdate()
		{
		}

		[UsedImplicitly]
		protected virtual void FixedUpdate()
		{
		}

		protected override void OnValidate()
		{
		}

		protected virtual void InitializedApplyDeltaTime(float deltaTime)
		{
		}

		protected virtual void ComputeTargetPositionAndRotation(out Vector3 targetPosition, out Vector3 targetUp, out Vector3 targetForward)
		{
			targetPosition = default(Vector3);
			targetUp = default(Vector3);
			targetForward = default(Vector3);
		}

		protected virtual void Initialize()
		{
		}

		protected virtual void Deinitialize()
		{
		}

		protected virtual void BindEvents()
		{
		}

		protected virtual void UnbindEvents()
		{
		}

		protected virtual void SavePrePlayState()
		{
		}

		protected virtual void RestorePrePlayState()
		{
		}

		protected virtual void ResetPrePlayState()
		{
		}

		protected virtual void GetPositionAndRotation(out Vector3 position, out Quaternion rotation)
		{
			position = default(Vector3);
			rotation = default(Quaternion);
		}

		protected virtual void SetPositionAndRotation(Vector3 position, Quaternion rotation)
		{
		}

		protected virtual void UserAfterInit()
		{
		}

		protected virtual void UserAfterUpdate()
		{
		}

		protected abstract void Advance(float speed, float deltaTime);

		protected abstract void SimulateAdvance(ref float tf, ref MovementDirection direction, float speed, float deltaTime);

		protected abstract float AbsoluteToRelative(float worldUnitDistance);

		protected abstract float RelativeToAbsolute(float relativeDistance);

		protected abstract Vector3 GetInterpolatedSourcePosition(float tf);

		protected abstract void GetInterpolatedSourcePosition(float tf, out Vector3 interpolatedPosition, out Vector3 tangent, out Vector3 up);

		protected abstract Vector3 GetOrientation(float tf);

		protected abstract Vector3 GetTangent(float tf);

		public CurvyController()
		{
		}

		public void Play()
		{
		}

		public void Stop()
		{
		}

		public void Pause()
		{
		}

		public void Refresh()
		{
		}

		public void ApplyDeltaTime(float deltaTime)
		{
		}

		public void TeleportTo(float newPosition)
		{
		}

		public void TeleportBy(float distance, MovementDirection direction)
		{
		}

		public void SetFromString(string fieldAndValue)
		{
		}

		protected static Vector3 ApplyOffset(Vector3 position, Vector3 tangent, Vector3 up, float offsetAngle, float offsetRadius)
		{
			return default(Vector3);
		}

		protected static float GetClampedPosition(float position, CurvyPositionMode positionMode, CurvyClamping clampingMode, float length)
		{
			return 0f;
		}

		protected float GetMaxPosition(CurvyPositionMode positionMode)
		{
			return 0f;
		}

		protected float ComputeOffsetCompensatedSpeed(float deltaTime)
		{
			return 0f;
		}

		private void GetOrientationNoneUpAndForward(out Vector3 targetUp, out Vector3 targetForward)
		{
			targetUp = default(Vector3);
			targetForward = default(Vector3);
		}

		public void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
		}
	}
}
