using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace FluffyUnderware.Curvy
{
	[ExecuteAlways]
	[HelpURL("https://curvyeditor.com/doclink/curvysplinesegment")]
	public class CurvySplineSegment : DTVersionedMonoBehaviour, IPoolable
	{
		private class Approximations
		{
			public SubArray<Vector3> Positions;

			public SubArray<Vector3> Tangents;

			public SubArray<Vector3> Ups;

			public SubArray<float> Distances;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void ResizePositions(int size)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void ResizeTangents(int size)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void ResizeUps(int size)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void ResizeDistances(int size)
			{
			}

			public void Clear()
			{
			}

			private void Initialize()
			{
			}

			private void Free()
			{
			}
		}

		private static class ApproximationsSetter
		{
			public static void SetPositionsToPoint([NotNull] Approximations approximations, Vector3 currentPosition)
			{
			}

			public static void SetPositionsToLinear([NotNull] Approximations approximations, int elementCount, Vector3 startPosition, Vector3 endPosition)
			{
			}

			public static void SetPositionsToCatmullRom([NotNull] Approximations approximations, int elementCount, Vector3 startPosition, Vector3 endPosition, Vector3 preSegmentPosition, Vector3 postSegmentPosition)
			{
			}

			public static void SetPositionsToTCB([NotNull] Approximations approximations, int elementCount, TcbParameters tcbParameters, Vector3 startPosition, Vector3 endPosition, Vector3 preSegmentPosition, Vector3 postSegmentPosition)
			{
			}

			public static void SetPositionsToBezier([NotNull] Approximations approximations, int elementCount, Vector3 startPosition, Vector3 startTangent, Vector3 endPosition, Vector3 endTangent)
			{
			}

			public static void SetPositionsToBSpline([NotNull] Approximations approximations, int elementCount, SubArray<Vector3> splineP0Array, BSplineApproximationParameters bSplineParameters)
			{
			}

			public static void SetOrientationToNone([NotNull] Approximations approximations, int elementCount)
			{
			}

			public static void SetOrientationToStatic([NotNull] Approximations approximations, int elementCount, Vector3 startUp, Vector3 endUp)
			{
			}

			public static void SetOrientationToDynamic([NotNull] Approximations approximations, int elementCount, Vector3 startUp)
			{
			}

			public static float SetPointTangentsAndDistances([NotNull] Approximations approximations, Vector3 previousPosition, Vector3 currentPosition, Vector3 nextPosition, Quaternion currentRotation)
			{
				return 0f;
			}

			public static float SetSegmentTangentsAnDistances([NotNull] Approximations approximations, int elementCount)
			{
				return 0f;
			}
		}

		private struct BSplineApproximationParameters : IEquatable<BSplineApproximationParameters>
		{
			public int Degree { get; }

			public bool IsClamped { get; }

			public bool IsClosed { get; }

			public float StartTf { get; }

			public float EndTf { get; }

			[NotNull]
			public ReadOnlyCollection<CurvySplineSegment> ControlPoints { get; }

			public int SegmentsCount { get; }

			public BSplineApproximationParameters([NotNull] CurvySplineSegment segment)
			{
				Degree = 0;
				IsClamped = false;
				IsClosed = false;
				StartTf = 0f;
				EndTf = 0f;
				ControlPoints = null;
				SegmentsCount = 0;
			}

			public bool Equals(BSplineApproximationParameters other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public static bool operator ==(BSplineApproximationParameters left, BSplineApproximationParameters right)
			{
				return false;
			}

			public static bool operator !=(BSplineApproximationParameters left, BSplineApproximationParameters right)
			{
				return false;
			}
		}

		internal readonly struct ControlPointExtrinsicProperties : IEquatable<ControlPointExtrinsicProperties>
		{
			private readonly bool isVisible;

			private readonly float tf;

			private readonly short segmentIndex;

			private readonly short controlPointIndex;

			private readonly short nextControlPointIndex;

			private readonly short previousControlPointIndex;

			private readonly bool previousControlPointIsSegment;

			private readonly bool nextControlPointIsSegment;

			private readonly bool canHaveFollowUp;

			internal bool IsVisible => false;

			internal float TF => 0f;

			internal short SegmentIndex => 0;

			internal short ControlPointIndex => 0;

			internal short NextControlPointIndex => 0;

			internal short PreviousControlPointIndex => 0;

			internal bool PreviousControlPointIsSegment => false;

			internal bool NextControlPointIsSegment => false;

			internal bool CanHaveFollowUp => false;

			internal bool IsSegment => false;

			[UsedImplicitly]
			[Obsolete("Use CurvySpline.GetControlPointOrientationAnchorIndex() instead")]
			internal short OrientationAnchorIndex => 0;

			[UsedImplicitly]
			[Obsolete("Use the other constructor")]
			internal ControlPointExtrinsicProperties(bool isVisible, float tf, short segmentIndex, short controlPointIndex, short previousControlPointIndex, short nextControlPointIndex, bool previousControlPointIsSegment, bool nextControlPointIsSegment, bool canHaveFollowUp, short orientationAnchorIndex)
			{
				this.isVisible = false;
				this.tf = 0f;
				this.segmentIndex = 0;
				this.controlPointIndex = 0;
				this.nextControlPointIndex = 0;
				this.previousControlPointIndex = 0;
				this.previousControlPointIsSegment = false;
				this.nextControlPointIsSegment = false;
				this.canHaveFollowUp = false;
			}

			internal ControlPointExtrinsicProperties(bool isVisible, float tf, short segmentIndex, short controlPointIndex, short previousControlPointIndex, short nextControlPointIndex, bool previousControlPointIsSegment, bool nextControlPointIsSegment, bool canHaveFollowUp)
			{
				this.isVisible = false;
				this.tf = 0f;
				this.segmentIndex = 0;
				this.controlPointIndex = 0;
				this.nextControlPointIndex = 0;
				this.previousControlPointIndex = 0;
				this.previousControlPointIsSegment = false;
				this.nextControlPointIsSegment = false;
				this.canHaveFollowUp = false;
			}

			public bool Equals(ControlPointExtrinsicProperties other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public static bool operator ==(ControlPointExtrinsicProperties left, ControlPointExtrinsicProperties right)
			{
				return false;
			}

			public static bool operator !=(ControlPointExtrinsicProperties left, ControlPointExtrinsicProperties right)
			{
				return false;
			}
		}

		private class ThreadSafeData
		{
			public Vector3 ThreadSafeLocalPosition;

			public Vector3 ThreadSafeNextCpLocalPosition;

			public Vector3 ThreadSafePreviousCpLocalPosition;

			public Quaternion ThreadSafeLocalRotation;

			internal void Set(bool useFollowUp, CurvySplineSegment curvySplineSegment, out CurvySplineSegment nextCP)
			{
				nextCP = null;
			}
		}

		public static readonly Color GizmoTangentColor;

		[Group("General")]
		[SerializeField]
		[FieldAction("CBBakeOrientation", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Below)]
		[Label("Bake Orientation", "Automatically apply orientation to CP transforms?")]
		private bool m_AutoBakeOrientation;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("Check to use this transform's rotation")]
		[Group("General")]
		private bool m_OrientationAnchor;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Group("General")]
		[Label("Swirl", "Add Swirl to orientation?")]
		private CurvyOrientationSwirl m_Swirl;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Label("Turns", "Number of swirl turns")]
		[Group("General")]
		[SerializeField]
		private float m_SwirlTurns;

		[Section("Bezier Options", true, false, 100, Sort = 1, HelpURL = "https://curvyeditor.com/doclink/curvysplinesegment_bezier")]
		[GroupCondition("Interpolation", CurvyInterpolation.Bezier, false)]
		[SerializeField]
		private bool m_AutoHandles;

		[RangeEx(0f, 1f, "Distance %", "Handle length by distance to neighbours")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private float m_AutoHandleDistance;

		[SerializeField]
		[VectorEx(null, null, Precision = 3, Options = (AttributeOptionsFlags)1152, Color = "#FFFF00")]
		[FormerlySerializedAs("HandleIn")]
		private Vector3 m_HandleIn;

		[FormerlySerializedAs("HandleOut")]
		[SerializeField]
		[VectorEx(null, null, Precision = 3, Options = (AttributeOptionsFlags)1152, Color = "#00FF00")]
		private Vector3 m_HandleOut;

		[Section("TCB Options", true, false, 100, Sort = 1, HelpURL = "https://curvyeditor.com/doclink/curvysplinesegment_tcb")]
		[GroupCondition("Interpolation", CurvyInterpolation.TCB, false)]
		[GroupAction("TCBOptionsGUI", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Below)]
		[Label("Local Tension", "Override Spline Tension?")]
		[SerializeField]
		[FormerlySerializedAs("OverrideGlobalTension")]
		private bool m_OverrideGlobalTension;

		[Label("Local Continuity", "Override Spline Continuity?")]
		[SerializeField]
		[FormerlySerializedAs("OverrideGlobalContinuity")]
		private bool m_OverrideGlobalContinuity;

		[Label("Local Bias", "Override Spline Bias?")]
		[SerializeField]
		[FormerlySerializedAs("OverrideGlobalBias")]
		private bool m_OverrideGlobalBias;

		[Tooltip("Synchronize Start and End Values")]
		[FormerlySerializedAs("SynchronizeTCB")]
		[SerializeField]
		private bool m_SynchronizeTCB;

		[Label("Tension", null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[FormerlySerializedAs("StartTension")]
		private float m_StartTension;

		[Label("Tension (End)", null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[FormerlySerializedAs("EndTension")]
		private float m_EndTension;

		[Label("Continuity", null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[FormerlySerializedAs("StartContinuity")]
		private float m_StartContinuity;

		[SerializeField]
		[Label("Continuity (End)", null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FormerlySerializedAs("EndContinuity")]
		private float m_EndContinuity;

		[FormerlySerializedAs("StartBias")]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Label("Bias", null)]
		private float m_StartBias;

		[Label("Bias (End)", null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[FormerlySerializedAs("EndBias")]
		private float m_EndBias;

		[SerializeField]
		[HideInInspector]
		private CurvySplineSegment m_FollowUp;

		[HideInInspector]
		[SerializeField]
		private ConnectionHeadingEnum m_FollowUpHeading;

		[SerializeField]
		[HideInInspector]
		private bool m_ConnectionSyncPosition;

		[SerializeField]
		[HideInInspector]
		private bool m_ConnectionSyncRotation;

		[HideInInspector]
		[SerializeField]
		private CurvyConnection m_Connection;

		private Transform cachedTransform;

		[CanBeNull]
		private CurvySplineSegment cachedNextControlPoint;

		[CanBeNull]
		private ThreadSafeData threadSafeData;

		private CurvySpline mSpline;

		private Bounds? mBounds;

		private readonly HashSet<CurvyMetadataBase> mMetadata;

		private Vector3? lastProcessedLocalPosition;

		private Quaternion? lastProcessedLocalRotation;

		private float distance;

		private float length;

		private SubArray<Vector3> bSplineP0Array;

		private ControlPointExtrinsicProperties extrinsicProperties;

		[NotNull]
		private readonly Approximations approximations;

		[UsedImplicitly]
		[Obsolete("Use GetPositionsApproximation instead")]
		public Vector3[] Approximation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use GetDistancesApproximation instead")]
		[UsedImplicitly]
		public float[] ApproximationDistances
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use GetUpsApproximation instead")]
		[UsedImplicitly]
		public Vector3[] ApproximationUp
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use GetTangentsApproximation instead")]
		public Vector3[] ApproximationT
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool AutoBakeOrientation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SerializedOrientationAnchor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CurvyOrientationSwirl Swirl
		{
			get
			{
				return default(CurvyOrientationSwirl);
			}
			set
			{
			}
		}

		public float SwirlTurns
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 HandleIn
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 HandleOut
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 HandleInPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 HandleOutPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool AutoHandles
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float AutoHandleDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool SynchronizeTCB
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool OverrideGlobalTension
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool OverrideGlobalContinuity
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool OverrideGlobalBias
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float StartTension
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float StartContinuity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float StartBias
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float EndTension
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float EndContinuity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float EndBias
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TcbParameters EffectiveTcbParameters => default(TcbParameters);

		[CanBeNull]
		public CurvySplineSegment FollowUp
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public ConnectionHeadingEnum FollowUpHeading
		{
			get
			{
				return default(ConnectionHeadingEnum);
			}
			set
			{
			}
		}

		public bool ConnectionSyncPosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ConnectionSyncRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CurvyConnection Connection
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public SubArray<Vector3> PositionsApproximation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(SubArray<Vector3>);
			}
		}

		public SubArray<Vector3> TangentsApproximation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(SubArray<Vector3>);
			}
		}

		public SubArray<Vector3> UpsApproximation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(SubArray<Vector3>);
			}
		}

		public SubArray<float> DistancesApproximation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return default(SubArray<float>);
			}
		}

		public int CacheSize => 0;

		public Bounds Bounds => default(Bounds);

		public float Length
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float Distance
		{
			get
			{
				return 0f;
			}
			internal set
			{
			}
		}

		public float TF
		{
			get
			{
				return 0f;
			}
			[Obsolete("Setting a TF value is not allowed anymore")]
			[UsedImplicitly]
			internal set
			{
			}
		}

		public bool IsFirstControlPoint => false;

		public bool IsLastControlPoint => false;

		public HashSet<CurvyMetadataBase> Metadata => null;

		[CanBeNull]
		public CurvySpline Spline => null;

		public bool HasUnprocessedLocalPosition => false;

		public bool HasUnprocessedLocalOrientation => false;

		[UsedImplicitly]
		[Obsolete("Use OrientationInfluencesSpline instead")]
		public bool OrientatinInfluencesSpline => false;

		public bool OrientationInfluencesSpline => false;

		private CurvyInterpolation Interpolation => default(CurvyInterpolation);

		private bool IsDynamicOrientation => false;

		private bool IsOrientationAnchorEditable => false;

		private bool CanHaveSwirl => false;

		private SubArray<Vector3> BSplineP0Array => default(SubArray<Vector3>);

		private bool CanTouchItsSpline => false;

		public void SetBezierHandleIn(Vector3 position, Space space = Space.Self, CurvyBezierModeEnum mode = CurvyBezierModeEnum.None)
		{
		}

		public void SetBezierHandleOut(Vector3 position, Space space = Space.Self, CurvyBezierModeEnum mode = CurvyBezierModeEnum.None)
		{
		}

		public void SetBezierHandles(float distanceFrag = -1f, bool setIn = true, bool setOut = true, bool noDirtying = false)
		{
		}

		public void SetBezierHandles(float distanceFrag, Vector3 p, Vector3 n, bool setIn = true, bool setOut = true, bool noDirtying = false)
		{
		}

		public void SetFollowUp(CurvySplineSegment target, ConnectionHeadingEnum heading = ConnectionHeadingEnum.Auto)
		{
		}

		public void ResetConnectionUnrelatedProperties()
		{
		}

		public void Disconnect()
		{
		}

		public void Disconnect(bool destroyEmptyConnection)
		{
		}

		public Vector3 Interpolate(float localF, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 InterpolateFast(float localF, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangent(float localF, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangent(float localF, Vector3 position, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangentFast(float localF, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public void InterpolateAndGetTangent(float localF, out Vector3 position, out Vector3 tangent, Space space = Space.Self)
		{
			position = default(Vector3);
			tangent = default(Vector3);
		}

		public void InterpolateAndGetTangentFast(float localF, out Vector3 position, out Vector3 tangent, Space space = Space.Self)
		{
			position = default(Vector3);
			tangent = default(Vector3);
		}

		public Vector3 GetOrientationUpFast(float localF, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Quaternion GetOrientationFast(float localF, bool inverse = false, Space space = Space.Self)
		{
			return default(Quaternion);
		}

		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		[UsedImplicitly]
		public void ReloadMetaData()
		{
		}

		public void RegisterMetaData(CurvyMetadataBase metaData)
		{
		}

		public void UnregisterMetaData(CurvyMetadataBase metaData)
		{
		}

		public T GetMetadata<T>(bool autoCreate = false) where T : CurvyMetadataBase
		{
			return null;
		}

		public U GetInterpolatedMetadata<T, U>(float f) where T : CurvyInterpolatableMetadataBase<U>
		{
			return default(U);
		}

		[UsedImplicitly]
		[Obsolete]
		public void DeleteMetadata()
		{
		}

		public float GetNearestPointF(Vector3 position, Space space = Space.Self)
		{
			return 0f;
		}

		public float DistanceToLocalF(float localDistance)
		{
			return 0f;
		}

		public float LocalFToDistance(float localF)
		{
			return 0f;
		}

		public float LocalFToTF(float localF)
		{
			return 0f;
		}

		public override string ToString()
		{
			return null;
		}

		public void BakeOrientationToTransform()
		{
		}

		public int getApproximationIndexINTERNAL(float localF, out float frag)
		{
			frag = default(float);
			return 0;
		}

		public void LinkToSpline(CurvySpline spline)
		{
		}

		[Obsolete("Use the other overload instead")]
		[UsedImplicitly]
		public void UnlinkFromSpline()
		{
		}

		public void UnlinkFromSpline(CurvySpline spline)
		{
		}

		public void SetLocalPosition(Vector3 newPosition)
		{
		}

		public void SetPosition(Vector3 value)
		{
		}

		public void SetLocalRotation(Quaternion value)
		{
		}

		public void SetRotation(Quaternion value)
		{
		}

		public static bool CanFollowUpHeadToStart([NotNull] CurvySplineSegment followUp)
		{
			return false;
		}

		public static bool CanFollowUpHeadToEnd([NotNull] CurvySplineSegment followUp)
		{
			return false;
		}

		public static Vector3 BSpline([NotNull] ReadOnlyCollection<CurvySplineSegment> controlPoints, float tf, bool isClamped, bool isClosed, int degree, [NotNull] Vector3[] p0Array)
		{
			return default(Vector3);
		}

		public void OnBeforePush()
		{
		}

		public void OnAfterPop()
		{
		}

		[UsedImplicitly]
		private void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		[UsedImplicitly]
		private void OnDestroy()
		{
		}

		protected override void OnValidate()
		{
		}

		[UsedImplicitly]
		[Obsolete("Use ResetConnectionUnrelatedProperties instead")]
		public new void Reset()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void GetBSplineP0s([NotNull] ReadOnlyCollection<CurvySplineSegment> controlPoints, int controlPointsCount, int degree, int k, [NotNull] Vector3[] pArray)
		{
		}

		internal void SetExtrinsicPropertiesINTERNAL(ControlPointExtrinsicProperties value)
		{
		}

		internal ref ControlPointExtrinsicProperties GetExtrinsicPropertiesINTERNAL()
		{
			throw null;
		}

		private void DoInitialValidations()
		{
		}

		private void CheckAgainstMetaDataDuplication()
		{
		}

		private bool SetConnection(CurvyConnection newConnection)
		{
			return false;
		}

		private static ConnectionHeadingEnum GetValidateConnectionHeading(ConnectionHeadingEnum connectionHeading, [CanBeNull] CurvySplineSegment followUp)
		{
			return default(ConnectionHeadingEnum);
		}

		private bool SetAutoHandles(bool newValue)
		{
			return false;
		}

		internal void PrepareThreadCompatibleDataINTERNAL(bool useFollowUp)
		{
		}

		internal void refreshCurveINTERNAL()
		{
		}

		private int GetSegmentCacheSize()
		{
			return 0;
		}

		internal void refreshOrientationNoneINTERNAL()
		{
		}

		internal void refreshOrientationStaticINTERNAL()
		{
		}

		internal void refreshOrientationDynamicINTERNAL(Vector3 initialUp)
		{
		}

		[UsedImplicitly]
		private void UpdateLasProcessedLocalPosition()
		{
		}

		[UsedImplicitly]
		private void UpdateLasProcessedLocalRotation()
		{
		}

		internal void ClearBoundsINTERNAL()
		{
		}

		internal Vector3 getOrthoUp0INTERNAL()
		{
			return default(Vector3);
		}

		private Vector3 getOrthoUp1INTERNAL()
		{
			return default(Vector3);
		}

		internal void UnsetFollowUpWithoutDirtyingINTERNAL()
		{
		}

		[System.Diagnostics.Conditional("CURVY_SANITY_CHECKS")]
		private void DoSanityChecks()
		{
		}

		[UsedImplicitly]
		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		private void UpdateSelectionIfNeeded()
		{
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		private static void ForceHierarchyDrawing()
		{
		}

		protected override void ResetOnEnable()
		{
		}
	}
}
