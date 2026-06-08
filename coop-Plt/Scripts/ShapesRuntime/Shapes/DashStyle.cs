using System;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public class DashStyle
	{
		public DashType type;

		public DashSpace space = DashSpace.Relative;

		public DashSnapping snap;

		public float size = 1f;

		public float offset;

		public float spacing = 1f;

		[Range(-1f, 1f)]
		public float shapeModifier = 1f;

		public static DashStyle DefaultDashStyleRing => new DashStyle(16f)
		{
			spacing = 0.5f,
			snap = DashSnapping.Tiling,
			space = DashSpace.FixedCount
		};

		public static DashStyle DefaultDashStyleLine => new DashStyle(4f);

		public float UniformSize
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
				if (space == DashSpace.FixedCount)
				{
					spacing = 0.5f;
				}
				else
				{
					spacing = size;
				}
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

		public float GetNetAbsoluteSize(bool dashed, float thickness)
		{
			if (!dashed)
			{
				return 0f;
			}
			return GetNet(size, thickness);
		}

		public float GetNetAbsoluteSpacing(bool dashed, float thickness)
		{
			if (!dashed)
			{
				return 0f;
			}
			return GetNet(spacing, thickness);
		}

		public DashStyle()
		{
		}

		public DashStyle(float size)
		{
			this.size = size;
			spacing = size;
		}

		public DashStyle(float size, DashType type)
		{
			this.size = size;
			spacing = size;
			this.type = type;
		}

		public DashStyle(float size, float spacing, DashType type)
		{
			this.size = size;
			this.spacing = spacing;
			this.type = type;
		}

		public DashStyle(float size, float spacing)
		{
			this.size = size;
			this.spacing = spacing;
		}

		public DashStyle(float size, float spacing, float offset)
		{
			this.size = size;
			this.spacing = spacing;
			this.offset = offset;
		}

		public static implicit operator DashStyle(float dashSize)
		{
			return new DashStyle(dashSize);
		}

		public static implicit operator DashStyle(int dashSize)
		{
			return new DashStyle(dashSize);
		}

		public static implicit operator DashStyle((float size, float spacing) t)
		{
			return new DashStyle(t.size, t.spacing);
		}

		public static implicit operator DashStyle((float size, float spacing, float offset) t)
		{
			return new DashStyle(t.size, t.spacing, t.offset);
		}
	}
}
