using System;
using FluffyUnderware.Curvy.Pools;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[RequireComponent(typeof(ArrayPoolsSettings))]
	[ExecuteInEditMode]
	[RequireComponent(typeof(PoolManager))]
	[HelpURL("https://curvyeditor.com/doclink/curvyglobalmanager")]
	public class CurvyGlobalManager : DTSingleton<CurvyGlobalManager>
	{
		public static readonly Color DefaultDefaultGizmoColor;

		public static readonly Color DefaultDefaultGizmoSelectionColor;

		public static readonly Color DefaultGizmoOrientationColor;

		public static bool HideManager;

		public static bool SaveGeneratorOutputs;

		public static float SceneViewResolution;

		public static Color DefaultGizmoColor;

		public static Color DefaultGizmoSelectionColor;

		public static CurvyInterpolation DefaultInterpolation;

		public static float GizmoControlPointSize;

		public static float GizmoOrientationLength;

		public static Color GizmoOrientationColor;

		public static int SplineLayer;

		public static CurvySplineGizmos Gizmos;

		private PoolManager poolManager;

		private ComponentPool controlPointPool;

		private ArrayPoolsSettings arrayPoolsSettings;

		public static bool ShowCurveGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowConnectionsGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowApproximationGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowTangentsGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowOrientationGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowTFsGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowRelativeDistancesGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowLabelsGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowMetadataGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowBoundsGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool ShowOrientationAnchorsGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PoolManager PoolManager => null;

		public ComponentPool ControlPointPool => null;

		public ArrayPoolsSettings ArrayPoolsSettings => null;

		public CurvyConnection[] Connections => null;

		[UsedImplicitly]
		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		public CurvyConnection[] GetContainingConnections(params CurvySpline[] splines)
		{
			return null;
		}

		public override void Awake()
		{
		}

		[UsedImplicitly]
		private void Start()
		{
		}

		[UsedImplicitly]
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitializeOnLoad()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		[UsedImplicitly]
		private static void LoadRuntimeSettings()
		{
		}

		public static void SaveRuntimeSettings()
		{
		}

		public override void MergeDoubleLoaded(IDTSingleton newInstance)
		{
		}
	}
}
