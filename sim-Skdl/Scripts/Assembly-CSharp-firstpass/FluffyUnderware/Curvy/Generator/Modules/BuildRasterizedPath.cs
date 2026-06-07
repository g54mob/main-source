using System;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cgbuildrasterizedpath")]
	[ModuleInfo("Build/Rasterize Path", ModuleName = "Rasterize Path", Description = "Rasterizes a virtual path")]
	public class BuildRasterizedPath : CGModule, IPathProvider
	{
		private const int MinResolution = 1;

		private const int MaxResolution = 100;

		private const float MinAngleThreshold = 0.1f;

		private const float MaxAngleThreshold = 120f;

		private const int DefaultResolution = 50;

		private const int DefaultAngleThreshold = 10;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path", RequestDataOnly = true)]
		public CGModuleInputSlot InPath;

		[OutputSlotInfo(typeof(CGPath), Name = "Path", DisplayName = "Rasterized Path")]
		[HideInInspector]
		public CGModuleOutputSlot OutPath;

		[SerializeField]
		[FloatRegion(UseSlider = true, RegionOptionsPropertyName = "RangeOptions", Precision = 4)]
		private FloatRegion m_Range;

		[SerializeField]
		[RangeEx(1f, 100f, "Resolution", "Defines how densely the path spline's sampling points are. When the value is 100, the number of sampling points per world distance unit is equal to the spline's Max Points Per Unit")]
		private int m_Resolution;

		[SerializeField]
		private bool m_Optimize;

		[RangeEx(0.1f, 120f, null, null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private float m_AngleTreshold;

		[SerializeField]
		[Section("Backward Compatibility", false, false, 100)]
		[Tooltip("Curvy versions prior to 8.0.0 had a bug in the computation of the rasterization range for closed splines. Enable this value to keep that bugged behaviour if your project depends on it")]
		private bool useBuggedRange;

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

		[CanBeNull]
		public CGPath Path => null;

		public bool PathIsClosed => false;

		public bool UseBuggedRange
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool ClampPath => false;

		private RegionOptions<float> RangeOptions => default(RegionOptions<float>);

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}

		public override void Refresh()
		{
		}
	}
}
