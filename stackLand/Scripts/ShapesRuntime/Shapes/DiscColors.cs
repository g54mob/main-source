using UnityEngine;

namespace Shapes
{
	public struct DiscColors
	{
		public Color innerStart;

		public Color outerStart;

		public Color innerEnd;

		public Color outerEnd;

		internal DiscColors(Color innerStart, Color outerStart, Color innerEnd, Color outerEnd)
		{
			this.innerStart = innerStart;
			this.outerStart = outerStart;
			this.innerEnd = innerEnd;
			this.outerEnd = outerEnd;
		}

		public static DiscColors Flat(Color color)
		{
			return new DiscColors(color, color, color, color);
		}

		public static DiscColors Radial(Color inner, Color outer)
		{
			return new DiscColors(inner, outer, inner, outer);
		}

		public static DiscColors Angular(Color start, Color end)
		{
			return new DiscColors(start, start, end, end);
		}

		public static DiscColors Bilinear(Color innerStart, Color outerStart, Color innerEnd, Color outerEnd)
		{
			return new DiscColors(innerStart, outerStart, innerEnd, outerEnd);
		}

		public static implicit operator DiscColors(Color flatColor)
		{
			return Flat(flatColor);
		}
	}
}
