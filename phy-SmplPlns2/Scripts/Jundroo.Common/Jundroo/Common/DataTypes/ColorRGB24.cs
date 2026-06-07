using System.Runtime.InteropServices;
using UnityEngine;

namespace Jundroo.Common.DataTypes
{
	[StructLayout(LayoutKind.Explicit)]
	public struct ColorRGB24
	{
		[FieldOffset(0)]
		public byte r;

		[FieldOffset(1)]
		public byte g;

		[FieldOffset(2)]
		public byte b;

		public ColorRGB24(byte r, byte g, byte b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
		}

		public static explicit operator ColorRGB24(Color32 color)
		{
			return new ColorRGB24(color.r, color.g, color.b);
		}

		public static explicit operator ColorRGB24(ColorARGB32 color)
		{
			return new ColorRGB24(color.r, color.g, color.b);
		}

		public static implicit operator Color32(ColorRGB24 color)
		{
			return new Color32(color.r, color.g, color.b, byte.MaxValue);
		}

		public static ColorRGB24 Lerp(ColorRGB24 a, ColorRGB24 b, float t)
		{
			t = Mathf.Clamp01(t);
			return new ColorRGB24((byte)((float)(int)a.r + (float)(b.r - a.r) * t), (byte)((float)(int)a.g + (float)(b.g - a.g) * t), (byte)((float)(int)a.b + (float)(b.b - a.b) * t));
		}

		public static ColorRGB24 LerpUnclamped(ColorRGB24 a, ColorRGB24 b, float t)
		{
			return new ColorRGB24((byte)((float)(int)a.r + (float)(b.r - a.r) * t), (byte)((float)(int)a.g + (float)(b.g - a.g) * t), (byte)((float)(int)a.b + (float)(b.b - a.b) * t));
		}

		public override string ToString()
		{
			return $"RGB({r}, {g}, {b})";
		}

		public string ToString(string format)
		{
			return $"RGB({r.ToString(format)}, {g.ToString(format)}, {b.ToString(format)})";
		}
	}
}
