using System;
using System.Numerics;

namespace BCnEncoder.Shared
{
	internal struct ColorRgb565 : IEquatable<ColorRgb565>
	{
		private const ushort RedMask = 63488;

		private const int RedShift = 11;

		private const ushort GreenMask = 2016;

		private const int GreenShift = 5;

		private const ushort BlueMask = 31;

		public ushort data;

		public byte R
		{
			readonly get
			{
				int num = (data & 0xF800) >> 11;
				return (byte)((num << 3) | (num >> 2));
			}
			set
			{
				int num = value >> 3;
				data = (ushort)(data & -63489);
				data = (ushort)(data | (num << 11));
			}
		}

		public byte G
		{
			readonly get
			{
				int num = (data & 0x7E0) >> 5;
				return (byte)((num << 2) | (num >> 4));
			}
			set
			{
				int num = value >> 2;
				data = (ushort)(data & -2017);
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
				return (data & 0xF800) >> 11;
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
				data = (ushort)(data & -63489);
				data = (ushort)(data | (value << 11));
			}
		}

		public int RawG
		{
			readonly get
			{
				return (data & 0x7E0) >> 5;
			}
			set
			{
				if (value > 63)
				{
					value = 63;
				}
				if (value < 0)
				{
					value = 0;
				}
				data = (ushort)(data & -2017);
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

		public bool Equals(ColorRgb565 other)
		{
			return data == other.data;
		}

		public override bool Equals(object obj)
		{
			if (obj is ColorRgb565 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return data.GetHashCode();
		}

		public static bool operator ==(ColorRgb565 left, ColorRgb565 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ColorRgb565 left, ColorRgb565 right)
		{
			return !left.Equals(right);
		}

		public ColorRgb565(byte r, byte g, byte b)
		{
			data = 0;
			R = r;
			G = g;
			B = b;
		}

		public ColorRgb565(Vector3 colorVector)
		{
			data = 0;
			R = ByteHelper.ClampToByte(colorVector.X * 255f);
			G = ByteHelper.ClampToByte(colorVector.Y * 255f);
			B = ByteHelper.ClampToByte(colorVector.Z * 255f);
		}

		public ColorRgb565(ColorRgb24 color)
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
