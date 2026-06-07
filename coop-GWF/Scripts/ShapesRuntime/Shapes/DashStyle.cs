using System;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public struct DashStyle
	{
		public static readonly DashStyle defaultDashStyle = new DashStyle
		{
			type = DashType.Basic,
			space = DashSpace.Relative,
			snap = DashSnapping.Off,
			size = 4f,
			offset = 0f,
			spacing = 4f,
			shapeModifier = 1f
		};

		public static readonly DashStyle defaultDashStyleRing = new DashStyle
		{
			type = DashType.Basic,
			space = DashSpace.FixedCount,
			snap = DashSnapping.Tiling,
			size = 16f,
			offset = 0f,
			spacing = 0.5f,
			shapeModifier = 1f
		};

		public static readonly DashStyle defaultDashStyleLine = new DashStyle
		{
			type = DashType.Basic,
			space = DashSpace.Relative,
			snap = DashSnapping.EndToEnd,
			size = 4f,
			offset = 0f,
			spacing = 4f,
			shapeModifier = 1f
		};

		public DashType type;

		public DashSpace space;

		public DashSnapping snap;

		public float size;

		public float spacing;

		public float offset;

		[Range(-1f, 1f)]
		public float shapeModifier;

		public float UniformSize
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
				spacing = ((space == DashSpace.FixedCount) ? 0.5f : size);
			}
		}

		[Obsolete("Deprecated, please use defaultDashStyle instead (lowercase first letter~)")]
		public static DashStyle DefaultDashStyle
		{
			get
			{
				return defaultDashStyle;
			}
			set
			{
			}
		}

		[Obsolete("Deprecated, please use defaultDashStyleRing instead (lowercase first letter~)")]
		public static DashStyle DefaultDashStyleRing
		{
			get
			{
				return defaultDashStyleRing;
			}
			set
			{
			}
		}

		[Obsolete("Deprecated, please use defaultDashStyleLine instead (lowercase first letter~)")]
		public static DashStyle DefaultDashStyleLine
		{
			get
			{
				return defaultDashStyleLine;
			}
			set
			{
			}
		}

		private float GetNet(float v, float thickness)
		{
			if (space != DashSpace.Relative)
			{
				return v;
			}
			return thickness * v;
		}

		internal float GetNetAbsoluteSize(bool dashed, float thickness)
		{
			if (!dashed)
			{
				return 0f;
			}
			return GetNet(size, thickness);
		}

		internal float GetNetAbsoluteSpacing(bool dashed, float thickness)
		{
			if (!dashed)
			{
				return 0f;
			}
			return GetNet(spacing, thickness);
		}

		public static DashStyle RelativeDashes(DashType type, float size, float spacing, DashSnapping snap = DashSnapping.Off, float offset = 0f, float shapeModifier = 1f)
		{
			return new DashStyle
			{
				space = DashSpace.Relative,
				type = type,
				size = size,
				spacing = spacing,
				snap = snap,
				offset = offset,
				shapeModifier = shapeModifier
			};
		}

		public static DashStyle FixedDashCount(DashType type, float count, float spacingFraction = 0.5f, DashSnapping snap = DashSnapping.Off, float offset = 0f, float shapeModifier = 1f)
		{
			return new DashStyle
			{
				space = DashSpace.FixedCount,
				type = type,
				size = count,
				spacing = spacingFraction,
				snap = snap,
				offset = offset,
				shapeModifier = shapeModifier
			};
		}

		public static DashStyle MeterDashes(DashType type, float size, float spacing, DashSnapping snap = DashSnapping.Off, float offset = 0f, float shapeModifier = 1f)
		{
			return new DashStyle
			{
				space = DashSpace.Meters,
				type = type,
				size = size,
				spacing = spacing,
				snap = snap,
				offset = offset,
				shapeModifier = shapeModifier
			};
		}

		[Obsolete("Deprecated, please use <c>DashStyle.RelativeDashes/FixedCountDashes/MeterDashes</c> instead", true)]
		public DashStyle(float size)
		{
			type = defaultDashStyle.type;
			space = defaultDashStyle.space;
			snap = defaultDashStyle.snap;
			this.size = size;
			spacing = size;
			offset = defaultDashStyle.offset;
			shapeModifier = defaultDashStyle.shapeModifier;
		}

		[Obsolete("Deprecated, please use <c>DashStyle.RelativeDashes/FixedCountDashes/MeterDashes</c> instead", true)]
		public DashStyle(float size, DashType type)
		{
			this.type = type;
			space = defaultDashStyle.space;
			snap = defaultDashStyle.snap;
			this.size = size;
			spacing = size;
			offset = defaultDashStyle.offset;
			shapeModifier = defaultDashStyle.shapeModifier;
		}

		[Obsolete("Deprecated, please use <c>DashStyle.RelativeDashes/FixedCountDashes/MeterDashes</c> instead", true)]
		public DashStyle(float size, float spacing, DashType type)
		{
			this.type = type;
			space = defaultDashStyle.space;
			snap = defaultDashStyle.snap;
			this.size = size;
			this.spacing = spacing;
			offset = defaultDashStyle.offset;
			shapeModifier = defaultDashStyle.shapeModifier;
		}

		[Obsolete("Deprecated, please use <c>DashStyle.RelativeDashes/FixedCountDashes/MeterDashes</c> instead", true)]
		public DashStyle(float size, float spacing)
		{
			type = defaultDashStyle.type;
			space = defaultDashStyle.space;
			snap = defaultDashStyle.snap;
			this.size = size;
			this.spacing = spacing;
			offset = defaultDashStyle.offset;
			shapeModifier = defaultDashStyle.shapeModifier;
		}

		[Obsolete("Deprecated, please use <c>DashStyle.RelativeDashes/FixedCountDashes/MeterDashes</c> instead", true)]
		public DashStyle(float size, float spacing, float offset)
		{
			type = defaultDashStyle.type;
			space = defaultDashStyle.space;
			snap = defaultDashStyle.snap;
			this.size = size;
			this.spacing = spacing;
			this.offset = offset;
			shapeModifier = defaultDashStyle.shapeModifier;
		}
	}
}
