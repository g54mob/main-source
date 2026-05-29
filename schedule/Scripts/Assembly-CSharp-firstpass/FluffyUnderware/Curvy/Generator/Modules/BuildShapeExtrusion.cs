using System;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Build/Shape Extrusion", ModuleName = "Shape Extrusion", Description = "Simple Shape Extrusion")]
	[HelpURL("https://curvyeditor.com/doclink/cgbuildshapeextrusion")]
	public class BuildShapeExtrusion : ScalingModule, IPathProvider
	{
		public enum CrossShiftModeEnum
		{
			None = 0,
			ByOrientation = 1,
			Custom = 2
		}

		[UsedImplicitly]
		[Obsolete("Use FluffyUnderware.Curvy.Generator.Modules.ScaleMode instead")]
		public enum ScaleModeEnum
		{
			Simple = 0,
			Advanced = 1
		}

		public struct Statistics : IEquatable<Statistics>
		{
			public int PathSampleCount
			{
				get; [UsedImplicitly]
				[Obsolete]
				set;
			}

			public int CrossSampleCount
			{
				get; [Obsolete]
				[UsedImplicitly]
				set;
			}

			public int MaterialGroupsCount
			{
				get; [UsedImplicitly]
				[Obsolete]
				set;
			}

			public void Set(int pathSamples, int crossSamples, int crossGroups)
			{
			}

			public bool Equals(Statistics other)
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

			public static bool operator ==(Statistics left, Statistics right)
			{
				return false;
			}

			public static bool operator !=(Statistics left, Statistics right)
			{
				return false;
			}
		}

		private const int MinResolution = 1;

		private const int MaxResolution = 100;

		private const float MinAngleThreshold = 0.1f;

		private const float MaxAngleThreshold = 120f;

		private const int MinShiftValue = 0;

		private const int MaxShiftValue = 1;

		private const int MinHollowInset = 0;

		private const int MaxHollowInset = 1;

		[InputSlotInfo(new Type[] { typeof(CGPath) }, RequestDataOnly = true)]
		[HideInInspector]
		public CGModuleInputSlot InPath;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGShape) }, Array = true, ArrayType = SlotInfo.SlotArrayType.Hidden, RequestDataOnly = true)]
		public CGModuleInputSlot InCross;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGVolume))]
		public CGModuleOutputSlot OutVolume;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGVolume))]
		public CGModuleOutputSlot OutVolumeHollow;

		[Tab("Path")]
		[FloatRegion(UseSlider = true, RegionOptionsPropertyName = "RangeOptions", Precision = 4)]
		[SerializeField]
		private FloatRegion m_Range;

		[SerializeField]
		[RangeEx(1f, 100f, "Resolution", "Defines how densely the path spline's sampling points are. When the value is 100, the number of sampling points per world distance unit is equal to the spline's Max Points Per Unit")]
		private int m_Resolution;

		[SerializeField]
		private bool m_Optimize;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[RangeEx(0.1f, 120f, null, null, Tooltip = "Max angle")]
		private float m_AngleThreshold;

		[FieldAction("CBEditCrossButton", ActionAttribute.ActionEnum.Callback, Position = ActionAttribute.ActionPositionEnum.Above)]
		[FloatRegion(UseSlider = true, RegionOptionsPropertyName = "CrossRangeOptions", Precision = 4)]
		[SerializeField]
		[Tab("Cross")]
		private FloatRegion m_CrossRange;

		[SerializeField]
		[RangeEx(1f, 100f, "Resolution", null, Tooltip = "Defines how densely the cross spline's sampling points are. When the value is 100, the number of sampling points per world distance unit is equal to the spline's Max Points Per Unit")]
		private int m_CrossResolution;

		[Label("Optimize", null)]
		[SerializeField]
		private bool m_CrossOptimize;

		[SerializeField]
		[RangeEx(0.1f, 120f, "Angle Threshold", null, Tooltip = "Max angle")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private float m_CrossAngleThreshold;

		[SerializeField]
		[Tooltip("If enabled, vertices are guaranteed to be created for all the Cross shape's Control Points.")]
		[Label("Include CPs", null)]
		private bool m_CrossIncludeControlpoints;

		[UsedImplicitly]
		[HideInInspector]
		[Label("Hard Edges", null)]
		[SerializeField]
		[Obsolete("This option is now always assumed to be true")]
		private bool m_CrossHardEdges;

		[Obsolete("This option is now always assumed to be true")]
		[Label("Materials", null)]
		[HideInInspector]
		[SerializeField]
		[UsedImplicitly]
		private bool m_CrossMaterials;

		[Obsolete("This option is now always assumed to be true")]
		[UsedImplicitly]
		[HideInInspector]
		[Label("Extended UV", null)]
		[SerializeField]
		private bool m_CrossExtendedUV;

		[SerializeField]
		[Label("Shift", null, Tooltip = "Defines a shift to be applied on the output volume's cross.\r\nThis shift is used when interpolating values (position, normal, ...) along the volume's surface.")]
		private CrossShiftModeEnum m_CrossShiftMode;

		[SerializeField]
		[RangeEx(0f, 1f, "Value", "Shift By", Slider = true)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private float m_CrossShiftValue;

		[Label("Reverse Normal", "Reverse Vertex Normals?")]
		[SerializeField]
		private bool m_CrossReverseNormals;

		[Tab("Hollow", Sort = 102)]
		[RangeEx(0f, 1f, null, null, Slider = true, Label = "Inset")]
		[SerializeField]
		private float m_HollowInset;

		[SerializeField]
		[Label("Reverse Normal", "Reverse Vertex Normals?")]
		private bool m_HollowReverseNormals;

		public float From
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float To
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Length
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int Resolution
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Optimize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float AngleThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CrossFrom
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CrossTo
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CrossLength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int CrossResolution
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool CrossOptimize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float CrossAngleThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool CrossIncludeControlPoints
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("This option is now always assumed to be true")]
		[UsedImplicitly]
		public bool CrossHardEdges
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("This option is now always assumed to be true")]
		[UsedImplicitly]
		public bool CrossMaterials
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("This option is now always assumed to be true")]
		[UsedImplicitly]
		public bool CrossExtendedUV
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CrossShiftModeEnum CrossShiftMode
		{
			get
			{
				return default(CrossShiftModeEnum);
			}
			set
			{
			}
		}

		public float CrossShiftValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool CrossReverseNormals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use parent class ScalingModule's ScaleMode instead")]
		[UsedImplicitly]
		public new ScaleModeEnum ScaleMode
		{
			get
			{
				return default(ScaleModeEnum);
			}
			set
			{
			}
		}

		public float HollowInset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool HollowReverseNormals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IExternalInput Cross => null;

		[Obsolete]
		[UsedImplicitly]
		public Vector3 CrossPosition
		{
			get
			{
				return default(Vector3);
			}
			protected set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete]
		public Quaternion CrossRotation
		{
			get
			{
				return default(Quaternion);
			}
			protected set
			{
			}
		}

		public bool PathIsClosed => false;

		public Statistics ExtrusionStatistics
		{
			get; [Obsolete]
			[UsedImplicitly]
			set;
		}

		private bool ClampPath => false;

		private bool ClampCross => false;

		private RegionOptions<float> RangeOptions => default(RegionOptions<float>);

		private RegionOptions<float> CrossRangeOptions => default(RegionOptions<float>);

		[Obsolete("Use ExtrusionStatistics instead")]
		[UsedImplicitly]
		public int PathSamples
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use ExtrusionStatistics instead")]
		public int CrossSamples
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		[Obsolete("Use ExtrusionStatistics instead")]
		[UsedImplicitly]
		public int CrossGroups
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}

		public override void Refresh()
		{
		}

		[Obsolete("Use parent class ScalingModule's GetScale instead")]
		[UsedImplicitly]
		public new Vector3 GetScale(float relativeDistance)
		{
			return default(Vector3);
		}

		protected override void ResetOnEnable()
		{
		}
	}
}
