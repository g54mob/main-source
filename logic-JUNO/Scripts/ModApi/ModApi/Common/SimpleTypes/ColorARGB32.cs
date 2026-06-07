using System.Runtime.InteropServices;
using UnityEngine;

namespace ModApi.Common.SimpleTypes
{
	[StructLayout(LayoutKind.Explicit)]
	public struct ColorARGB32
	{
		[FieldOffset(0)]
		public byte a;

		[FieldOffset(1)]
		public byte r;

		[FieldOffset(2)]
		public byte g;

		[FieldOffset(3)]
		public byte b;

		public ColorARGB32(byte a, byte r, byte g, byte b)
		{
			this.a = a;
			this.r = r;
			this.g = g;
			this.b = b;
		}

		public static implicit operator Color32(ColorARGB32 color)
		{
			return new Color32(color.r, color.g, color.b, color.a);
		}

		public static implicit operator ColorARGB32(Color32 color)
		{
			return new ColorARGB32(color.a, color.r, color.g, color.b);
		}

		public static implicit operator ColorARGB32(ColorRGB24 color)
		{
			return new ColorARGB32(color.r, color.g, color.b, byte.MaxValue);
		}

		public override string ToString()
		{
			return $"RGBA({r}, {g}, {b}, {a})";
		}

		public string ToString(string format)
		{
			return $"RGBA({r.ToString(format)}, {g.ToString(format)}, {b.ToString(format)}, {a.ToString(format)})";
		}
	}
}
