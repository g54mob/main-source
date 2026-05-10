using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Controllers
{
	[AddComponentMenu("Curvy/Controllers/Spline Controller")]
	[HelpURL("https://curvyeditor.com/doclink/splinecontroller")]
	public class SplineController : CurvyController
	{
		protected class SplineSwitcher
		{
			public float StartTime { get; set; }

			public float Duration { get; set; }

			public CurvySpline Spline { get; set; }

			public float Tf { get; set; }

			public MovementDirection Direction { get; set; }

			public bool IsSwitching { get; set; }

			public float Progress => 0f;

			public void Start([NotNull] CurvySpline spline, float tf, float duration, MovementDirection direction)
			{
			}

			public void Advance(CurvySpline spline, MoveModeEnum moveMode, float distance, CurvyClamping clamping)
			{
			}

			public void Stop()
			{
			}
		}

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[Section("General", true, false, 100, Sort = 0)]
		protected CurvySpline m_Spline;

		[Tooltip("Whether spline's cache data should be used. Set this to true to gain performance if precision is not required.")]
		[SerializeField]
		private bool m_UseCache;

		[Label("At connection, use", "What spline should the controller use when reaching a Connection")]
		[SerializeField]
		[Section("Connections Handling", true, false, 100, Sort = 250, HelpURL = "https://curvyeditor.com/doclink/curvycontroller_connectionshandling")]
		private SplineControllerConnectionBehavior connectionBehavior;

		[Label("Allow direction change", "When true, the controller will modify its direction to best fit the connected spline")]
		[SerializeField]
		private bool allowDirectionChange;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Label("Reject current spline", "Whether the current spline should be excluded from the randomly selected splines")]
		[SerializeField]
		private bool rejectCurrentSpline;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Label("Reject divergent splines", "Whether splines that diverge from the current spline with more than a specific angle should be excluded from the randomly selected splines")]
		[SerializeField]
		private bool rejectTooDivergentSplines;

		[Range(0f, 180f)]
		[SerializeField]
		[Label("Max allowed angle", "Maximum allowed divergence angle in degrees")]
		private float maxAllowedDivergenceAngle;

		[SerializeField]
		[Label("Custom Selector", "A custom logic to select which connected spline to follow. Select a Script inheriting from SplineControllerConnectionBehavior")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private ConnectedControlPointsSelector connectionCustomSelector;

		[Section("Events", false, false, 1000, HelpURL = "https://curvyeditor.com/doclink/splinecontroller_events")]
		[SerializeField]
		[ArrayEx]
		protected List<OnPositionReachedSettings> onPositionReachedList;

		[SerializeField]
		protected CurvySplineMoveEvent m_OnControlPointReached;

		[SerializeField]
		protected CurvySplineMoveEvent m_OnEndReached;

		[SerializeField]
		protected CurvySplineMoveEvent m_OnSwitch;

		protected readonly SplineSwitcher Switcher;

		private CurvySpline prePlaySpline;

		private readonly CurvySplineMoveEventArgs preAllocatedEventArgs;

		private const string InvalidSegmentErrorMessage = "[Curvy] Controller {0} reached segment {1} which is invalid segment because it has a length of 0. Please fix the invalid segment to avoid issues with the controller";

		public virtual CurvySpline Spline
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseCache
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SplineControllerConnectionBehavior ConnectionBehavior
		{
			get
			{
				return default(SplineControllerConnectionBehavior);
			}
			set
			{
			}
		}

		public ConnectedControlPointsSelector ConnectionCustomSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool AllowDirectionChange
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RejectCurrentSpline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RejectTooDivergentSplines
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float MaxAllowedDivergenceAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public List<OnPositionReachedSettings> OnPositionReachedList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvySplineMoveEvent OnControlPointReached
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvySplineMoveEvent OnEndReached
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override float Length => 0f;

		public bool IsSwitching => false;

		public float SwitchProgress => 0f;

		public CurvySplineMoveEvent OnSwitch
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool IsReady => false;

		private bool ShowRandomConnectionOptions => false;

		[Obsolete("Use Switcher instead")]
		[UsedImplicitly]
		protected float SwitchStartTime => 0f;

		[Obsolete("Use Switcher instead")]
		[UsedImplicitly]
		protected float SwitchDuration => 0f;

		[Obsolete("Use Switcher instead")]
		[UsedImplicitly]
		protected CurvySpline SwitchTarget => null;

		[UsedImplicitly]
		[Obsolete("Use Switcher instead")]
		protected float TfOnSwitchTarget => 0f;

		[Obsolete("Use Switcher instead")]
		[UsedImplicitly]
		protected MovementDirection DirectionOnSwitchTarget => default(MovementDirection);

		protected override void OnValidate()
		{
		}

		public virtual void SwitchTo(CurvySpline destinationSpline, float destinationTf, float duration)
		{
		}

		public void FinishCurrentSwitch()
		{
		}

		public void CancelCurrentSwitch()
		{
		}

		public static float GetAngleBetweenConnectedSplines(CurvySplineSegment before, MovementDirection movementMode, CurvySplineSegment after, bool allowMovementModeChange)
		{
			return 0f;
		}

		protected override void SavePrePlayState()
		{
		}

		protected override void RestorePrePlayState()
		{
		}

		protected override void ResetPrePlayState()
		{
		}

		protected override float RelativeToAbsolute(float relativeDistance)
		{
			return 0f;
		}

		protected override float AbsoluteToRelative(float worldUnitDistance)
		{
			return 0f;
		}

		protected override Vector3 GetInterpolatedSourcePosition(float tf)
		{
			return default(Vector3);
		}

		protected override void GetInterpolatedSourcePosition(float tf, out Vector3 interpolatedPosition, out Vector3 tangent, out Vector3 up)
		{
			interpolatedPosition = default(Vector3);
			tangent = default(Vector3);
			up = default(Vector3);
		}

		protected override Vector3 GetTangent(float tf)
		{
			return default(Vector3);
		}

		protected override Vector3 GetOrientation(float tf)
		{
			return default(Vector3);
		}

		protected override void Advance(float speed, float deltaTime)
		{
		}

		protected override void SimulateAdvance(ref float tf, ref MovementDirection direction, float speed, float deltaTime)
		{
		}

		private static void SimulateAdvanceOnSpline(CurvySpline spline, ref float tf, ref MovementDirection direction, float distance, MoveModeEnum moveModeEnum, CurvyClamping curvyClamping)
		{
		}

		protected override void InitializedApplyDeltaTime(float deltaTime)
		{
		}

		protected override void ComputeTargetPositionAndRotation(out Vector3 targetPosition, out Vector3 targetUp, out Vector3 targetForward)
		{
			targetPosition = default(Vector3);
			targetUp = default(Vector3);
			targetForward = default(Vector3);
		}

		protected override void ResetOnEnable()
		{
		}

		private void AdvanceSwitching(float distance)
		{
		}

		private void GetSwitchingPositionAndRotation(Vector3 forwardOnCurrentSpline, Vector3 upOnCurrentSpline, Vector3 positionOnCurrentSpline, out Vector3 interpolatedPosition, out Quaternion interpolatedRotation)
		{
			interpolatedPosition = default(Vector3);
			interpolatedRotation = default(Quaternion);
		}

		private void ComputePositionAndRotationOnSwitchTarget(out Vector3 positionOnSwitchToSpline, out Quaternion rotationOnSwitchToSpline)
		{
			positionOnSwitchToSpline = default(Vector3);
			rotationOnSwitchToSpline = default(Quaternion);
		}

		private static float MovementCompatibleGetPosition(SplineController controller, float clampedPosition, CurvyPositionMode positionMode, out CurvySplineSegment controlPoint, out bool isOnControlPoint)
		{
			controlPoint = null;
			isOnControlPoint = default(bool);
			return 0f;
		}

		private static void MovementCompatibleSetPosition(SplineController controller, CurvyPositionMode positionMode, float specialClampedPosition)
		{
		}

		private void EventAwareMove(float distance)
		{
		}

		private void HandleOnPositionReachedEvents(CurvyPositionMode positionMode, float startPosition, float endPosition, float endPositionUnclamped, out float postEventsEndPosition, float currentDelta, CurvySplineSegment currentCp, ref bool cancelMovement)
		{
			postEventsEndPosition = default(float);
		}

		private float? HandleOnPositionReachedEvent(CurvyPositionMode positionMode, float startPosition, float endPositionUnclamped, float currentDelta, CurvySplineSegment currentCp, ref bool cancelMovement, OnPositionReachedSettings settings, float? postEventEndPosition)
		{
			return null;
		}

		private void HandleReachingNewControlPoint(CurvySplineSegment controlPoint, float controlPointPosition, CurvyPositionMode positionMode, float currentDelta, ref bool cancelMovement, out CurvySplineSegment postEventsControlPoint, out bool postEventsIsControllerOnControlPoint, out float postEventsControlPointPosition)
		{
			postEventsControlPoint = null;
			postEventsIsControllerOnControlPoint = default(bool);
			postEventsControlPointPosition = default(float);
		}

		private void InvokeEventHandler(CurvySplineMoveEvent @event, CurvySplineMoveEventArgs eventArgument, CurvyPositionMode positionMode, ref CurvySplineSegment postEventsControlPoint, ref bool postEventsIsControllerOnControlPoint, ref float postEventPosition)
		{
		}

		private void InvokeEventHandler(CurvySplineMoveEvent @event, CurvySplineMoveEventArgs eventArgument, CurvyPositionMode positionMode, out CurvySplineSegment postEventsControlPoint, out bool? postEventsIsControllerOnControlPoint, out float? postEventPosition)
		{
			postEventsControlPoint = null;
			postEventsIsControllerOnControlPoint = null;
			postEventPosition = null;
		}

		private CurvySplineSegment HandleRandomConnectionBehavior(CurvySplineSegment currentControlPoint, MovementDirection currentDirection, out MovementDirection newDirection, ReadOnlyCollection<CurvySplineSegment> connectedControlPoints)
		{
			newDirection = default(MovementDirection);
			return null;
		}

		private static MovementDirection GetPostConnectionDirection(CurvySplineSegment connectedControlPoint, MovementDirection currentDirection, bool directionChangeAllowed)
		{
			return default(MovementDirection);
		}

		private CurvySplineSegment HandleFollowUpConnectionBehavior(CurvySplineSegment currentControlPoint, MovementDirection currentDirection, out MovementDirection newDirection)
		{
			newDirection = default(MovementDirection);
			return null;
		}

		private static MovementDirection HeadingToDirection(ConnectionHeadingEnum heading, CurvySplineSegment controlPoint, MovementDirection currentDirection)
		{
			return default(MovementDirection);
		}

		private static float GetControlPointPosition(CurvySplineSegment controlPoint, CurvyPositionMode positionMode)
		{
			return 0f;
		}
	}
}
