namespace Noesis
{
	public struct Color
	{
		private float _r;

		private float _g;

		private float _b;

		private float _a;

		public byte A
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte R
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte G
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte B
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float ScA
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScR
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScG
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScB
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private static float FromByte(byte v)
		{
			return 0f;
		}

		private static byte ToByte(float v)
		{
			return 0;
		}

		private static float sRgbToScRgb(float v)
		{
			return 0f;
		}

		private static float ScRgbTosRgb(float v)
		{
			return 0f;
		}

		public static Color FromRgb(byte r, byte g, byte b)
		{
			return default(Color);
		}

		public static Color FromArgb(byte a, byte r, byte g, byte b)
		{
			return default(Color);
		}

		public static Color FromScRgb(float a, float r, float g, float b)
		{
			return default(Color);
		}

		public void Clamp()
		{
		}

		private static float Clamp(float v)
		{
			return 0f;
		}

		public static Color Add(Color l, Color r)
		{
			return default(Color);
		}

		public static Color Subtract(Color l, Color r)
		{
			return default(Color);
		}

		public static Color Multiply(Color c, float k)
		{
			return default(Color);
		}

		public static bool Equals(Color color1, Color color2)
		{
			return false;
		}

		public bool Equals(Color color)
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

		public override string ToString()
		{
			return null;
		}

		public static bool AreClose(Color l, Color r)
		{
			return false;
		}

		private static bool AreClose(float a, float b)
		{
			return false;
		}

		public static Color operator +(Color l, Color r)
		{
			return default(Color);
		}

		public static Color operator -(Color l, Color r)
		{
			return default(Color);
		}

		public static Color operator *(Color color, float coefficient)
		{
			return default(Color);
		}

		public static bool operator ==(Color l, Color r)
		{
			return false;
		}

		public static bool operator !=(Color l, Color r)
		{
			return false;
		}
	}
}
