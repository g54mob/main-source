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
	[HelpURL("https://curvyeditor.com/doclink/curvyspline")]
	[AddComponentMenu("Curvy/Curvy Spline")]
	[ExecuteAlways]
	public class CurvySpline : DTVersionedMonoBehaviour
	{
		private class ControlPointsSynchronizer
		{
			public enum SynchronizationRequest
			{
				None = 0,
				SplineToHierarchy = 1,
				HierarchyToSpline = 2
			}

			[NotNull]
			private readonly CurvySpline spline;

			private bool processing;

			public SynchronizationRequest CurrentRequest { get; private set; }

			public ControlPointsSynchronizer([NotNull] CurvySpline spline)
			{
			}

			[System.Diagnostics.Conditional("UNITY_EDITOR")]
			public void RequestSplineToHierarchy()
			{
			}

			public void RequestHierarchyToSpline()
			{
			}

			public void ProcessRequests()
			{
			}

			public void CancelRequests()
			{
			}

			private void SynchronizeHierarchyToSpline()
			{
			}

			[System.Diagnostics.Conditional("UNITY_EDITOR")]
			private void SynchronizeSplineToHierarchy()
			{
			}

			[System.Diagnostics.Conditional("CURVY_DEBUG")]
			private static void DebugLog(string message)
			{
			}

			[System.Diagnostics.Conditional("CURVY_SANITY_CHECKS")]
			private static void LogIgnoredRequest()
			{
			}

			[System.Diagnostics.Conditional("CURVY_SANITY_CHECKS")]
			private void AssertIsNotProcessing()
			{
			}
		}

		private class DirtinessManager : IDisposable
		{
			private bool dirtyCurve;

			private bool dirtyOrientation;

			private bool allControlPointsAreDirty;

			private readonly HashSet<CurvySplineSegment> dirtyControlPointsMinimalSet;

			[NotNull]
			private CurvySpline spline;

			private bool processingDirtyControlPoints;

			private readonly ThreadPoolWorker<CurvySplineSegment> threadWorker;

			private readonly List<CurvySplineSegment> persistedSegmentsList;

			private readonly OrientationGroup persistedOrientationGroup;

			private readonly Action<CurvySplineSegment, int, int> refreshOrientationStaticAction;

			private bool DirtyCurve
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			private bool DirtyOrientation
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool AllControlPointsAreDirty
			{
				get
				{
					return false;
				}
				private set
				{
				}
			}

			public bool Dirty => false;

			public DirtinessManager([NotNull] CurvySpline spline)
			{
			}

			public void SetDirtyAll(SplineDirtyingType dirtyingType, bool dirtyConnectedControlPoints)
			{
			}

			public void SetDirty(CurvySplineSegment controlPoint, SplineDirtyingType dirtyingType, CurvySplineSegment previousControlPoint, CurvySplineSegment nextControlPoint, bool ignoreConnectionOfInputControlPoint)
			{
			}

			public void ClearMinimalSet()
			{
			}

			public void RemoveFromMinimalSet(CurvySplineSegment item)
			{
			}

			[MustUseReturnValue]
			public bool ProcessDirtyControlPoints()
			{
				return false;
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}

			private void ProcessDirtyOrientation(List<CurvySplineSegment> dirtyCpsExtendedList)
			{
			}

			private void ProcessDirtyDynamicOrientation(List<CurvySplineSegment> dirtyCpsExtendedList)
			{
			}

			private void ProcessDirtyCurve(List<CurvySplineSegment> dirtyCpsExtendedList)
			{
			}

			private void SetDirtyingFlagsAndInvalidateSplineCurveCachesIfNeeded(SplineDirtyingType dirtyingType)
			{
			}

			private void FillDirtyCpsExtendedList(List<CurvySplineSegment> dirtyCpsExtendedList)
			{
			}

			private void AddToMinimalSetAndSetDirtyingFlagsAndInvalidateSplineCurveCachesIfNeeded(CurvySplineSegment controlPoint, SplineDirtyingType dirtyingType)
			{
			}

			private void ValidateConnectedSplines()
			{
			}

			private void SynchronizeSplinesWithNullCps([NotNull] List<CurvySplineSegment> controlPoints)
			{
			}

			private static void SynchronizeUninitializedSplines([NotNull] List<CurvySplineSegment> connectedCPs)
			{
			}

			[System.Diagnostics.Conditional("CURVY_SANITY_CHECKS")]
			private void DoSanityChecks()
			{
			}
		}

		private class OrientationGroup
		{
			[NotNull]
			[ItemNotNull]
			private readonly List<CurvySplineSegment> segments;

			private SegmentGroupMetrics currentMetrics;

			[NotNull]
			private float[] accumulatedSwirlAngles;

			[NotNull]
			private readonly List<int> accumulatedCacheSizes;

			[NotNull]
			public List<CurvySplineSegment> Segments => null;

			public void SetupOrientationGroup(short anchorIndex, [ItemNotNull][NotNull] List<CurvySplineSegment> splineControlPoints, [NotNull] short[] orientationAnchorIndices)
			{
			}

			public void UpdateOrientation()
			{
			}

			private void ApplySwirlAndSmoothing()
			{
			}

			private void ApplyParallelTransport()
			{
			}

			private float GetOrientationGap()
			{
				return 0f;
			}

			[NotNull]
			private float[] GetAccumulatedSwirlAngles()
			{
				return null;
			}
		}

		private class RelationshipCache
		{
			[NotNull]
			private readonly CurvySpline spline;

			[NotNull]
			private readonly object lockObject;

			[CanBeNull]
			private CurvySplineSegment firstSegment;

			[CanBeNull]
			private CurvySplineSegment lastSegment;

			[CanBeNull]
			private CurvySplineSegment firstVisibleControlPoint;

			[CanBeNull]
			private CurvySplineSegment lastVisibleControlPoint;

			[CanBeNull]
			public CurvySplineSegment FirstVisibleControlPoint => null;

			[CanBeNull]
			public CurvySplineSegment LastVisibleControlPoint => null;

			[CanBeNull]
			public CurvySplineSegment FirstSegment => null;

			[CanBeNull]
			public CurvySplineSegment LastSegment => null;

			public bool IsValid { get; private set; }

			public RelationshipCache([NotNull] CurvySpline spline)
			{
			}

			public void Invalidate()
			{
			}

			public void EnsureIsValid()
			{
			}

			private void RebuildAndFixNonCoherentControlPoints()
			{
			}
		}

		private class SanityChecker
		{
			[NotNull]
			private readonly CurvySpline spline;

			private int sanityErrorLogsThisFrame;

			private int sanityWaringLogsThisFrame;

			public SanityChecker([NotNull] CurvySpline spline)
			{
			}

			[System.Diagnostics.Conditional("CURVY_SANITY_CHECKS")]
			public void OnUpdate()
			{
			}

			[System.Diagnostics.Conditional("CURVY_SANITY_CHECKS")]
			public void Check()
			{
			}
		}

		private struct SegmentGroupMetrics : IEquatable<SegmentGroupMetrics>
		{
			public int CacheSize;

			public int SegmentCount;

			public float Length;

			public void Increment([NotNull] CurvySplineSegment segment)
			{
			}

			public bool Equals(SegmentGroupMetrics other)
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

			public static bool operator ==(SegmentGroupMetrics left, SegmentGroupMetrics right)
			{
				return false;
			}

			public static bool operator !=(SegmentGroupMetrics left, SegmentGroupMetrics right)
			{
				return false;
			}
		}

		private class ControlPointNamer
		{
			[NotNull]
			private readonly CurvySpline spline;

			private bool requestRename;

			[ItemNotNull]
			[NotNull]
			private static readonly string[] ControlPointNames;

			public ControlPointNamer([NotNull] CurvySpline curvySpline)
			{
			}

			[System.Diagnostics.Conditional("UNITY_EDITOR")]
			public void RequestRename()
			{
			}

			[System.Diagnostics.Conditional("UNITY_EDITOR")]
			public void ProcessRequests()
			{
			}

			[System.Diagnostics.Conditional("UNITY_EDITOR")]
			public void CancelRequests()
			{
			}

			private static void RenameControlPoints([NotNull] List<CurvySplineSegment> splineControlPoints)
			{
			}

			[NotNull]
			private static string GetControlPointName(short controlPointIndex)
			{
				return null;
			}

			[NotNull]
			[ItemNotNull]
			private static string[] GetControlPointNames()
			{
				return null;
			}

			[NotNull]
			private static string MakeControlPointName(short controlPointIndex)
			{
				return null;
			}
		}

		[Obsolete("Use FluffyUnderware.Curvy.AssetInformation instead")]
		public const string VERSION = "8.5.0";

		[Obsolete("Use FluffyUnderware.Curvy.AssetInformation instead")]
		public const string APIVERSION = "850";

		[Obsolete("Use FluffyUnderware.Curvy.AssetInformation instead")]
		public const string WEBROOT = "https://curvyeditor.com/";

		[Obsolete("Use FluffyUnderware.Curvy.AssetInformation instead")]
		public const string DOCLINK = "https://curvyeditor.com/doclink/";

		[HideInInspector]
		public bool ShowGizmos;

		[HideInInspector]
		[SerializeField]
		[NotNull]
		private List<CurvySplineSegment> ControlPoints;

		[Section("General", true, false, 100, HelpURL = "https://curvyeditor.com/doclink/curvyspline_general")]
		[FormerlySerializedAs("Interpolation")]
		[SerializeField]
		[Tooltip("Interpolation Method")]
		private CurvyInterpolation m_Interpolation;

		[SerializeField]
		[Tooltip("Restrict Control Points to a local 2D plane")]
		private bool m_RestrictTo2D;

		[FieldAction("CBCheck2DPlanar", ActionAttribute.ActionEnum.Callback)]
		[Tooltip("The local 2D plane to restrict the spline's control points to")]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private CurvyPlane restricted2DPlane;

		[FormerlySerializedAs("Closed")]
		[SerializeField]
		private bool m_Closed;

		[FieldCondition("CanHaveManualEndCp", Action = ActionAttribute.ActionEnum.Enable)]
		[Tooltip("Handle End Control Points automatically?")]
		[SerializeField]
		[FormerlySerializedAs("AutoEndTangents")]
		private bool m_AutoEndTangents;

		[Tooltip("Orientation Flow")]
		[SerializeField]
		[FormerlySerializedAs("Orientation")]
		private CurvyOrientation m_Orientation;

		[Section("Global Bezier Options", true, false, 100, HelpURL = "https://curvyeditor.com/doclink/curvyspline_bezier")]
		[GroupCondition("m_Interpolation", CurvyInterpolation.Bezier, false)]
		[SerializeField]
		[RangeEx(0f, 1f, "Default Distance %", "Handle length by distance to neighbours")]
		private float m_AutoHandleDistance;

		[Section("Global TCB Options", true, false, 100, HelpURL = "https://curvyeditor.com/doclink/curvyspline_tcb")]
		[GroupAction("TCBOptionsGUI", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Below)]
		[GroupCondition("m_Interpolation", CurvyInterpolation.TCB, false)]
		[FormerlySerializedAs("Tension")]
		[SerializeField]
		private float m_Tension;

		[FormerlySerializedAs("Continuity")]
		[SerializeField]
		private float m_Continuity;

		[SerializeField]
		[FormerlySerializedAs("Bias")]
		private float m_Bias;

		[SerializeField]
		[RangeEx(2f, "MaxBSplineDegree", "Degree", "The degree of the piecewise polynomial functions.\nIs in the range [2; control points count - 1]")]
		[GroupCondition("m_Interpolation", CurvyInterpolation.BSpline, false)]
		[Section("B-Spline Options", true, false, 100, HelpURL = "https://curvyeditor.com/doclink/curvyspline_bspline")]
		private int bSplineDegree;

		[Label("Clamped", "Make the curve pass through the first and last control points by increasing the multiplicity of the first and last knots.\n\nIn technical terms, when this parameter is true, the knot vector is [0, 0, ...,0, 1, 2, ..., N-1, N, N, ..., N]. When false, it is [0, 1, 2, ..., N-1, N]")]
		[SerializeField]
		[FieldCondition("CanBeClamped", Action = ActionAttribute.ActionEnum.Enable)]
		private bool isBSplineClamped;

		[SerializeField]
		[Label("Color", "Gizmo color")]
		[FieldAction("ShowGizmoGUI", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Above)]
		[Section("Advanced Settings", true, false, 100, HelpURL = "https://curvyeditor.com/doclink/curvyspline_advanced")]
		private Color m_GizmoColor;

		[SerializeField]
		[FieldAction("CheckGizmoColor", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Above)]
		[FieldAction("CheckGizmoSelectionColor", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Below)]
		[Label("Active Color", "Selected Gizmo color")]
		private Color m_GizmoSelectionColor;

		[SerializeField]
		[RangeEx(1f, 100f, null, null)]
		[Tooltip("Defines how densely the cached points are. When the value is 100, the number of cached points per world distance unit is equal to the spline's MaxPointsPerUnit")]
		[FormerlySerializedAs("Granularity")]
		private int m_CacheDensity;

		[Tooltip("The maximum number of sampling points per world distance unit. Sampling is used in caching or shape extrusion for example")]
		[SerializeField]
		private float m_MaxPointsPerUnit;

		[SerializeField]
		[Tooltip("Use a GameObject pool at runtime")]
		private bool m_UsePooling;

		[SerializeField]
		[Tooltip("Use threading where applicable. Threading is is currently not supported when targetting WebGL and Universal Windows Platform")]
		private bool m_UseThreading;

		[FormerlySerializedAs("AutoRefresh")]
		[SerializeField]
		[Tooltip("Refresh when Control Point position change?")]
		private bool m_CheckTransform;

		[SerializeField]
		private CurvyUpdateMethod m_UpdateIn;

		[SerializeField]
		[Group("Events", Expanded = false, Sort = 1000, HelpURL = "https://curvyeditor.com/doclink/curvyspline_events")]
		protected CurvySplineEvent onInitialized;

		[Group("Events", Sort = 1000)]
		[SerializeField]
		protected CurvySplineEvent m_OnRefresh;

		[SerializeField]
		[Group("Events", Sort = 1000)]
		protected CurvySplineEvent m_OnAfterControlPointChanges;

		[SerializeField]
		[Group("Events", Sort = 1000)]
		protected CurvyControlPointEvent m_OnBeforeControlPointAdd;

		[SerializeField]
		[Group("Events", Sort = 1000)]
		protected CurvyControlPointEvent m_OnAfterControlPointAdd;

		[Group("Events", Sort = 1000)]
		[SerializeField]
		protected CurvyControlPointEvent m_OnBeforeControlPointDelete;

		private Action<CurvySpline> onGlobalCoordinatesChanged;

		private bool mIsInitialized;

		private bool isStarted;

		private bool sendOnRefreshEventNextUpdate;

		private readonly List<CurvySplineSegment> mSegments;

		private readonly DirtinessManager dirtinessManager;

		private readonly RelationshipCache relationshipCache;

		[NotNull]
		private readonly SanityChecker sanityChecker;

		[NotNull]
		private readonly ControlPointsSynchronizer cpsSynchronizer;

		[NotNull]
		private readonly ControlPointNamer controlPointNamer;

		[CanBeNull]
		private TransformMonitor transformMonitor;

		private Transform cachedTransform;

		private ReadOnlyCollection<CurvySplineSegment> readOnlyControlPoints;

		private short[] cachedShortsArray;

		private float[] controlPointsDistances;

		private readonly Action<CurvySplineSegment, int, int> refreshCurveAction;

		private float length;

		private int mCacheSize;

		private Bounds? mBounds;

		private readonly CurvySplineEventArgs defaultSplineEventArgs;

		private readonly CurvyControlPointEventArgs defaultAddAfterEventArgs;

		private readonly CurvyControlPointEventArgs defaultDeleteEventArgs;

		private const short CachedControlPointsNameCount = 250;

		private const float MinimalMaxPointsPerUnit = 0.0001f;

		private const float MaxSegmentCacheSize = 1000000f;

		private const string InvalidCPErrorMessage = "[Curvy] Method called with a control point '{0}' that is not part of the current spline '{1}'";

		private const int MinBSplineDegree = 2;

		public CurvyInterpolation Interpolation
		{
			get
			{
				return default(CurvyInterpolation);
			}
			set
			{
			}
		}

		public bool RestrictTo2D
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CurvyPlane Restricted2DPlane
		{
			get
			{
				return default(CurvyPlane);
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

		public bool Closed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AutoEndTangents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CurvyOrientation Orientation
		{
			get
			{
				return default(CurvyOrientation);
			}
			set
			{
			}
		}

		public CurvyUpdateMethod UpdateIn
		{
			get
			{
				return default(CurvyUpdateMethod);
			}
			set
			{
			}
		}

		public Color GizmoColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color GizmoSelectionColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public int CacheDensity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float MaxPointsPerUnit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool UsePooling
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseThreading
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CheckTransform
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Tension
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Continuity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Bias
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int BSplineDegree
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsBSplineClamped
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsInitialized => false;

		public Bounds Bounds => default(Bounds);

		public int Count => 0;

		public int ControlPointCount => 0;

		public int CacheSize => 0;

		public float Length => 0f;

		public bool Dirty => false;

		public CurvySplineSegment this[int idx] => null;

		public ReadOnlyCollection<CurvySplineSegment> ControlPointsList => null;

		[CanBeNull]
		public CurvySplineSegment FirstVisibleControlPoint => null;

		[CanBeNull]
		public CurvySplineSegment LastVisibleControlPoint => null;

		[CanBeNull]
		public CurvySplineSegment FirstSegment => null;

		[CanBeNull]
		public CurvySplineSegment LastSegment => null;

		public bool GlobalCoordinatesChangedThisFrame => false;

		[CanBeNull]
		public Action<CurvySpline> OnGlobalCoordinatesChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvySplineEvent OnRefresh
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvySplineEvent OnInitialized
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvySplineEvent OnAfterControlPointChanges
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvyControlPointEvent OnBeforeControlPointAdd
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvyControlPointEvent OnAfterControlPointAdd
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvyControlPointEvent OnBeforeControlPointDelete
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[NotNull]
		private TransformMonitor TransformMonitor => null;

		private List<CurvySplineSegment> Segments => null;

		private int MaxBSplineDegree => 0;

		public static CurvySpline Create()
		{
			return null;
		}

		public static CurvySpline Create(CurvySpline takeOptionsFrom)
		{
			return null;
		}

		public static int CalculateCacheSize(int density, float segmentLength, float maxPointsPerUnit)
		{
			return 0;
		}

		public static float CalculateSamplingPointsPerUnit(int density, float maxPointsPerUnit)
		{
			return 0f;
		}

		public static Vector3 Bezier(Vector3 T0, Vector3 P0, Vector3 P1, Vector3 T1, float f)
		{
			return default(Vector3);
		}

		public static Vector3 BezierTangent(Vector3 T0, Vector3 P0, Vector3 P1, Vector3 T1, float f)
		{
			return default(Vector3);
		}

		public static Vector3 CatmullRom(Vector3 T0, Vector3 P0, Vector3 P1, Vector3 T1, float f)
		{
			return default(Vector3);
		}

		public static Vector3 TCB(Vector3 T0, Vector3 P0, Vector3 P1, Vector3 T1, float f, float FT0, float FC0, float FB0, float FT1, float FC1, float FB1)
		{
			return default(Vector3);
		}

		public static CurvySplineSegment GetFollowUpHeadingControlPoint([NotNull] CurvySplineSegment followUp, ConnectionHeadingEnum headingDirection)
		{
			return null;
		}

		public Vector3 Interpolate(float tf, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 InterpolateFast(float tf, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 InterpolateByDistance(float distance, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 InterpolateByDistanceFast(float distance, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangent(float tf, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangent(float tf, Vector3 position, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangentFast(float tf, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangentByDistance(float distance, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Vector3 GetTangentByDistanceFast(float distance, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public void InterpolateAndGetTangent(float tf, out Vector3 position, out Vector3 tangent, Space space = Space.Self)
		{
			position = default(Vector3);
			tangent = default(Vector3);
		}

		public void InterpolateAndGetTangentFast(float tf, out Vector3 position, out Vector3 tangent, Space space = Space.Self)
		{
			position = default(Vector3);
			tangent = default(Vector3);
		}

		public Vector3 GetOrientationUpFast(float tf, Space space = Space.Self)
		{
			return default(Vector3);
		}

		public Quaternion GetOrientationFast(float tf, bool inverse = false, Space space = Space.Self)
		{
			return default(Quaternion);
		}

		public T GetMetadata<T>(float tf) where T : CurvyMetadataBase
		{
			return null;
		}

		public U GetInterpolatedMetadata<T, U>(float tf) where T : CurvyInterpolatableMetadataBase<U>
		{
			return default(U);
		}

		public float TFToDistance(float tf, CurvyClamping clamping = CurvyClamping.Clamp)
		{
			return 0f;
		}

		public CurvySplineSegment TFToSegment(float tf, out float localF, out bool isOnSegmentStart, out bool isOnSegmentEnd, CurvyClamping clamping)
		{
			localF = default(float);
			isOnSegmentStart = default(bool);
			isOnSegmentEnd = default(bool);
			return null;
		}

		public CurvySplineSegment TFToSegment(float tf, out float localF, CurvyClamping clamping)
		{
			localF = default(float);
			return null;
		}

		public CurvySplineSegment TFToSegment(float tf, CurvyClamping clamping)
		{
			return null;
		}

		public CurvySplineSegment TFToSegment(float tf)
		{
			return null;
		}

		public CurvySplineSegment TFToSegment(float tf, out float localF)
		{
			localF = default(float);
			return null;
		}

		public float SegmentToTF(CurvySplineSegment segment)
		{
			return 0f;
		}

		public float SegmentToTF(CurvySplineSegment segment, float localF)
		{
			return 0f;
		}

		public float DistanceToTF(float distance, CurvyClamping clamping = CurvyClamping.Clamp)
		{
			return 0f;
		}

		public CurvySplineSegment DistanceToSegment(float distance, CurvyClamping clamping = CurvyClamping.Clamp)
		{
			return null;
		}

		public CurvySplineSegment DistanceToSegment(float distance, out float localDistance, CurvyClamping clamping = CurvyClamping.Clamp)
		{
			localDistance = default(float);
			return null;
		}

		public CurvySplineSegment DistanceToSegment(float distance, out float localDistance, out bool isOnSegmentStart, out bool isOnSegmentEnd, CurvyClamping clamping = CurvyClamping.Clamp)
		{
			localDistance = default(float);
			isOnSegmentStart = default(bool);
			isOnSegmentEnd = default(bool);
			return null;
		}

		public float ClampDistance(float distance, CurvyClamping clamping)
		{
			return 0f;
		}

		public float ClampDistance(float distance, CurvyClamping clamping, float min, float max)
		{
			return 0f;
		}

		public float ClampDistance(float distance, ref int dir, CurvyClamping clamping)
		{
			return 0f;
		}

		public float ClampDistance(float distance, ref int dir, CurvyClamping clamping, float min, float max)
		{
			return 0f;
		}

		public CurvySplineSegment Add()
		{
			return null;
		}

		public CurvySplineSegment[] Add(int controlPointsCount)
		{
			return null;
		}

		public CurvySplineSegment Add(Vector3 controlPointPosition, Space space)
		{
			return null;
		}

		public CurvySplineSegment[] Add(params Vector3[] controlPointsLocalPositions)
		{
			return null;
		}

		public CurvySplineSegment[] Add(Vector3[] controlPointsPositions, Space space)
		{
			return null;
		}

		public CurvySplineSegment InsertBefore(CurvySplineSegment controlPoint, bool skipRefreshingAndEvents = false)
		{
			return null;
		}

		public CurvySplineSegment InsertBefore([CanBeNull] CurvySplineSegment controlPoint, Vector3 position, bool skipRefreshingAndEvents = false, Space space = Space.World)
		{
			return null;
		}

		public CurvySplineSegment InsertAfter(CurvySplineSegment controlPoint, bool skipRefreshingAndEvents = false)
		{
			return null;
		}

		public CurvySplineSegment InsertAfter([CanBeNull] CurvySplineSegment controlPoint, Vector3 position, bool skipRefreshingAndEvents = false, Space space = Space.World)
		{
			return null;
		}

		public void Clear(bool isUndoable = true)
		{
		}

		public void Delete(CurvySplineSegment controlPoint, bool skipRefreshingAndEvents = false)
		{
		}

		public void Delete(CurvySplineSegment controlPoint, bool skipRefreshingAndEvents, bool isUndoableDeletion)
		{
		}

		public SubArray<Vector3> GetPositionsCache(Space space)
		{
			return default(SubArray<Vector3>);
		}

		[UsedImplicitly]
		[Obsolete("Use GetPositionsCache instead")]
		public Vector3[] GetApproximation(Space space = Space.Self)
		{
			return null;
		}

		public Vector3[] GetApproximation(float fromTF, float toTF, bool includeEndPoint = true, Space space = Space.Self)
		{
			return null;
		}

		public SubArray<Vector3> GetTangentsCache(Space space)
		{
			return default(SubArray<Vector3>);
		}

		[Obsolete("Use GetTangentsCache instead")]
		[UsedImplicitly]
		public Vector3[] GetApproximationT(Space space = Space.Self)
		{
			return null;
		}

		public SubArray<Vector3> GetNormalsCache(Space space)
		{
			return default(SubArray<Vector3>);
		}

		[Obsolete("Use GetNormalsCache instead")]
		[UsedImplicitly]
		public Vector3[] GetApproximationUpVectors(Space space = Space.Self)
		{
			return null;
		}

		public Vector3 GetNearestPoint(Vector3 position, Space space)
		{
			return default(Vector3);
		}

		public float GetNearestPointTF(Vector3 localPosition)
		{
			return 0f;
		}

		public float GetNearestPointTF(Vector3 position, Space space)
		{
			return 0f;
		}

		public float GetNearestPointTF(Vector3 localPosition, out Vector3 nearestPoint)
		{
			nearestPoint = default(Vector3);
			return 0f;
		}

		public float GetNearestPointTF(Vector3 position, out Vector3 nearestPoint, Space space)
		{
			nearestPoint = default(Vector3);
			return 0f;
		}

		public float GetNearestPointTF(Vector3 position, int searchStartSegmentIndex = 0, int searchEndSegmentIndex = -1, Space space = Space.Self)
		{
			return 0f;
		}

		public float GetNearestPointTF(Vector3 position, out Vector3 nearestPoint, int searchStartSegmentIndex = 0, int searchEndSegmentIndex = -1, Space space = Space.Self)
		{
			nearestPoint = default(Vector3);
			return 0f;
		}

		public float GetNearestPointTF(Vector3 position, out Vector3 nearestPoint, [CanBeNull] out CurvySplineSegment nearestSegment, out float nearestPointLocalF, int searchStartSegmentIndex = 0, int searchEndSegmentIndex = -1, Space space = Space.Self)
		{
			nearestPoint = default(Vector3);
			nearestSegment = null;
			nearestPointLocalF = default(float);
			return 0f;
		}

		public void Refresh()
		{
		}

		public void SetDirtyAll()
		{
		}

		public void SetDirtyAll(SplineDirtyingType dirtyingType, bool dirtyConnectedControlPoints)
		{
		}

		public void SetDirty(CurvySplineSegment dirtyControlPoint, SplineDirtyingType dirtyingType)
		{
		}

		public void SetDirtyPartial(CurvySplineSegment dirtyControlPoint, SplineDirtyingType dirtyingType)
		{
		}

		public Vector3 ToWorldPosition(Vector3 localPosition)
		{
			return default(Vector3);
		}

		public Vector3 ToWorldDirection(Vector3 localDirection)
		{
			return default(Vector3);
		}

		public Vector3 ToLocalPosition(Vector3 worldPosition)
		{
			return default(Vector3);
		}

		public Vector3 ToLocalDirection(Vector3 localDirection)
		{
			return default(Vector3);
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		public void ApplyControlPointsNames()
		{
		}

		public void SyncSplineFromHierarchy()
		{
		}

		[Obsolete]
		[UsedImplicitly]
		public bool IsPlanar(out int ignoreAxis)
		{
			ignoreAxis = default(int);
			return false;
		}

		public bool IsPlanar(out bool isYZ, out bool isXZ, out bool isXY)
		{
			isYZ = default(bool);
			isXZ = default(bool);
			isXY = default(bool);
			return false;
		}

		public bool IsPlanar(CurvyPlane plane)
		{
			return false;
		}

		public void MakePlanar(CurvyPlane plane)
		{
		}

		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		[UsedImplicitly]
		public void MakePlanar(int axis)
		{
		}

		public void Subdivide(CurvySplineSegment fromCP = null, CurvySplineSegment toCP = null)
		{
		}

		public void Simplify(CurvySplineSegment fromCP = null, CurvySplineSegment toCP = null)
		{
		}

		public void Equalize(CurvySplineSegment fromCP = null, CurvySplineSegment toCP = null)
		{
		}

		public void Normalize()
		{
		}

		public Vector3 SetPivot(float xRel = 0f, float yRel = 0f, float zRel = 0f, bool preview = false)
		{
			return default(Vector3);
		}

		public void Flip()
		{
		}

		public void MoveControlPoints(int startIndex, int count, CurvySplineSegment destCP)
		{
		}

		public void JoinWith(CurvySplineSegment destCP)
		{
		}

		public CurvySpline Split(CurvySplineSegment controlPoint)
		{
			return null;
		}

		public void SetFirstControlPoint(CurvySplineSegment controlPoint)
		{
		}

		public bool IsControlPointAnOrientationAnchor(CurvySplineSegment controlPoint)
		{
			return false;
		}

		public bool CanControlPointHaveFollowUp([NotNull] CurvySplineSegment controlPoint)
		{
			return false;
		}

		public short GetControlPointIndex([NotNull] CurvySplineSegment controlPoint)
		{
			return 0;
		}

		public short GetSegmentIndex([NotNull] CurvySplineSegment segment)
		{
			return 0;
		}

		[CanBeNull]
		public CurvySplineSegment GetNextControlPoint([NotNull] CurvySplineSegment controlPoint)
		{
			return null;
		}

		[CanBeNull]
		public short GetNextControlPointIndex([NotNull] CurvySplineSegment controlPoint)
		{
			return 0;
		}

		[CanBeNull]
		public CurvySplineSegment GetNextControlPointUsingFollowUp([NotNull] CurvySplineSegment controlPoint)
		{
			return null;
		}

		[CanBeNull]
		public CurvySplineSegment GetPreviousControlPoint([NotNull] CurvySplineSegment controlPoint)
		{
			return null;
		}

		[CanBeNull]
		public short GetPreviousControlPointIndex([NotNull] CurvySplineSegment controlPoint)
		{
			return 0;
		}

		[CanBeNull]
		public CurvySplineSegment GetPreviousControlPointUsingFollowUp([NotNull] CurvySplineSegment controlPoint)
		{
			return null;
		}

		[CanBeNull]
		public CurvySplineSegment GetNextSegment([NotNull] CurvySplineSegment segment)
		{
			return null;
		}

		[CanBeNull]
		public CurvySplineSegment GetPreviousSegment([NotNull] CurvySplineSegment segment)
		{
			return null;
		}

		public bool IsControlPointASegment([NotNull] CurvySplineSegment controlPoint)
		{
			return false;
		}

		public bool IsControlPointVisible([NotNull] CurvySplineSegment controlPoint)
		{
			return false;
		}

		[Obsolete("No more used, will be removed. If you need this method, you can use IsControlPointAnOrientationAnchor while traversing the spline's control points to find the needed information.")]
		[UsedImplicitly]
		public short GetControlPointOrientationAnchorIndex([NotNull] CurvySplineSegment controlPoint)
		{
			return 0;
		}

		public void SetFromString(string fieldAndValue)
		{
		}

		protected override void OnValidate()
		{
		}

		[UsedImplicitly]
		private void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		public void Start()
		{
		}

		protected override void OnDisable()
		{
		}

		[UsedImplicitly]
		private void OnDestroy()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		[UsedImplicitly]
		private void LateUpdate()
		{
		}

		[UsedImplicitly]
		private void FixedUpdate()
		{
		}

		[MustUseReturnValue]
		private bool Initialize()
		{
			return false;
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		private void HookEditorUpdate()
		{
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		private void UnhookEditorUpdate()
		{
		}

		private void DoUpdate()
		{
		}

		private void ClearBounds()
		{
		}

		private bool CanHaveManualEndCp()
		{
			return false;
		}

		private bool CanBeClamped()
		{
			return false;
		}

		private void ReverseControlPoints()
		{
		}

		private static short GetNextControlPointIndex(short controlPointIndex, bool isSplineClosed, int controlPointsCount)
		{
			return 0;
		}

		private static short GetPreviousControlPointIndex(short controlPointIndex, bool isSplineClosed, int controlPointsCount)
		{
			return 0;
		}

		private static bool IsControlPointASegment(int controlPointIndex, int controlPointCount, bool isClosed, bool notAutoEndTangentsAndIsCatmullRomOrTCB, bool isBSpline, int bSplineDegree)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsControlPointAnOrientationAnchor(bool isVisible, bool isSerializedOrientationAnchor, bool isFirstVisibleControlPoint, bool isLastVisibleControlPoint)
		{
			return false;
		}

		private void AddControlPoint([NotNull] CurvySplineSegment item, bool invalidateAndDirty, bool requestSplineToHierarchySynchronization)
		{
		}

		private void InsertControlPoint(int index, CurvySplineSegment item)
		{
		}

		private void RemoveControlPoint(CurvySplineSegment item)
		{
		}

		private void ClearControlPoints(bool invalidateAndDirty, bool requestSplineToHierarchySynchronization)
		{
		}

		[UsedImplicitly]
		[Obsolete]
		internal void InvalidateControlPointsRelationshipCacheINTERNAL()
		{
		}

		[UsedImplicitly]
		private void UpdateControlPointDistances()
		{
		}

		private void EnforceTangentContinuity()
		{
		}

		private void PrepareThreadCompatibleData()
		{
		}

		private short[] GetOrientationAnchorIndices()
		{
			return null;
		}

		private void InvalidateAccumulators()
		{
		}

		internal void NotifyMetaDataModification()
		{
		}

		private void DisposeOfControlPoint(CurvySplineSegment controlPoint, bool isUndoable)
		{
		}

		private bool ShouldUseControlPointPooling(out CurvyGlobalManager curvyGlobalManager)
		{
			curvyGlobalManager = null;
			return false;
		}

		private CurvySplineSegment InsertAt([CanBeNull] CurvySplineSegment beforeEventCP, Vector3 position, int insertionIndex, CurvyControlPointEventArgs.ModeEnum insertionMode, bool skipRefreshingAndEvents, Space space)
		{
			return null;
		}

		[NotNull]
		private CurvySplineSegment AcquireNewControlPoint()
		{
			return null;
		}

		private SubArray<Vector3> GetSegmentApproximationsInSpace([NotNull] Func<CurvySplineSegment, SubArray<Vector3>> approximationGetter, Space space)
		{
			return default(SubArray<Vector3>);
		}

		private SubArray<Vector3> ConcatenateSegmentApproximations([NotNull] Func<CurvySplineSegment, SubArray<Vector3>> approximationGetter)
		{
			return default(SubArray<Vector3>);
		}

		private void TransformToWorldSpace(SubArray<Vector3> localSpaceVectors)
		{
		}

		private void PushChildCPsToPool([NotNull] ComponentPool controlPointPool)
		{
		}

		private CurvySplineEventArgs OnRefreshEvent(CurvySplineEventArgs e)
		{
			return null;
		}

		private CurvyControlPointEventArgs OnBeforeControlPointAddEvent(CurvyControlPointEventArgs e)
		{
			return null;
		}

		private CurvyControlPointEventArgs OnAfterControlPointAddEvent(CurvyControlPointEventArgs e)
		{
			return null;
		}

		private CurvyControlPointEventArgs OnBeforeControlPointDeleteEvent(CurvyControlPointEventArgs e)
		{
			return null;
		}

		private CurvySplineEventArgs OnAfterControlPointChangesEvent(CurvySplineEventArgs e)
		{
			return null;
		}

		protected override void ResetOnEnable()
		{
		}
	}
}
