using System;
using System.Numerics;

namespace BCnEncoder.Shared
{
	internal struct ColorRgb555 : IEquatable<ColorRgb555>
	{
		private const ushort ModeMask = 32768;

		private const int ModeShift = 15;

		private const ushort RedMask = 31744;

		private const int RedShift = 10;

		private const ushort GreenMask = 992;

		private const int GreenShift = 5;

		private const ushort BlueMask = 31;

		public ushort data;

		public byte Mode
		{
			readonly get
			{
				return (byte)((data & 0x8000) >> 15);
			}
			set
			{
				byte b = value;
				data = (ushort)(data & -32769);
				data = (ushort)(data | (b << 15));
			}
		}

		public byte R
		{
			readonly get
			{
				int num = (data & 0x7C00) >> 10;
				return (byte)((num << 3) | (num >> 2));
			}
			set
			{
				int num = value >> 3;
				data = (ushort)(data & -31745);
				data = (ushort)(data | (num << 10));
			}
		}

		public byte G
		{
			readonly get
			{
				int num = (data & 0x3E0) >> 5;
				return (byte)((num << 3) | (num >> 2));
			}
			set
			{
				int num = value >> 3;
				data = (ushort)(data & -993);
				data = (ushort)(data | (num << 5));
			}
		}

		public byte B
		{
			readonly get
			{
				int num = data & 0x1F;
				return (byte)((num << 3) | (num >> 2));
			}
			set
			{
				int num = value >> 3;
				data = (ushort)(data & -32);
				data = (ushort)(data | num);
			}
		}

		public int RawR
		{
			readonly get
			{
				return (data & 0x7C00) >> 10;
			}
			set
			{
				if (value > 31)
				{
					value = 31;
				}
				if (value < 0)
				{
					value = 0;
				}
				data = (ushort)(data & -31745);
				data = (ushort)(data | (value << 10));
			}
		}

		public int RawG
		{
			readonly get
			{
				return (data & 0x3E0) >> 5;
			}
			set
			{
				if (value > 31)
				{
					value = 31;
				}
				if (value < 0)
				{
					value = 0;
				}
				data = (ushort)(data & -993);
				data = (ushort)(data | (value << 5));
			}
		}

		public int RawB
		{
			readonly get
			{
				return data & 0x1F;
			}
			set
			{
				if (value > 31)
				{
					value = 31;
				}
				if (value < 0)
				{
					value = 0;
				}
				data = (ushort)(data & -32);
				data = (ushort)(data | value);
			}
		}

		public bool Equals(ColorRgb555 other)
		{
			return data == other.data;
		}

		public override bool Equals(object obj)
		{
			if (obj is ColorRgb555 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return data.GetHashCode();
		}

		public static bool operator ==(ColorRgb555 left, ColorRgb555 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ColorRgb555 left, ColorRgb555 right)
		{
			return !left.Equals(right);
		}

		public ColorRgb555(byte r, byte g, byte b)
		{
			data = 0;
			R = r;
			G = g;
			B = b;
		}

		public ColorRgb555(Vector3 colorVector)
		{
			data = 0;
			R = ByteHelper.ClampToByte(colorVector.X * 255f);
			G = ByteHelper.ClampToByte(colorVector.Y * 255f);
			B = ByteHelper.ClampToByte(colorVector.Z * 255f);
		}

		public ColorRgb555(ColorRgb24 color)
		{
			data = 0;
			R = color.r;
			G = color.g;
			B = color.b;
		}

		public readonly ColorRgb24 ToColorRgb24()
		{
			return new ColorRgb24(R, G, B);
		}

		public override string ToString()
		{
			return $"r : {R} g : {G} b : {B}";
		}

		public ColorRgba32 ToColorRgba32()
		{
			return new ColorRgba32(R, G, B, byte.MaxValue);
		}
	}
}
