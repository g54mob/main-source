using System;

namespace Os.Utils
{
	[Serializable]
	public struct ByteFloat
	{
		public byte value;

		public const byte max = byte.MaxValue;

		public const int factor = 256;

		public const byte half = 127;

		public float f
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ByteFloat(float value)
		{
			this.value = 0;
		}

		public static float ByteToFloat(byte b)
		{
			return 0f;
		}

		public static byte FloatToByte(float f)
		{
			return 0;
		}

		public static explicit operator float(ByteFloat b)
		{
			return 0f;
		}

		public static explicit operator ByteFloat(float f)
		{
			return default(ByteFloat);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(ByteFloat a, ByteFloat b)
		{
			return false;
		}

		public static bool operator !=(ByteFloat a, ByteFloat b)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
