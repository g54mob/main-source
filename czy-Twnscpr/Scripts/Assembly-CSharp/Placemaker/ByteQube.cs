using System;

namespace Placemaker
{
	[Serializable]
	public struct ByteQube
	{
		public byte v0;

		public byte v1;

		public byte v2;

		public byte v3;

		public byte v4;

		public byte v5;

		public byte v6;

		public byte v7;

		public static readonly ByteQube identity;

		public static readonly ByteQube rotateForward;

		public static readonly ByteQube rotateBackward;

		public static readonly ByteQube mirror;

		public static readonly ByteQube tipForward;

		public static readonly ByteQube tipBackward;

		public static readonly ByteQube upsideDown;

		public const byte uniqueOrientationCount = 48;

		public const byte uprightOrientationCount = 8;

		public int cost => 0;

		public byte Item
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ByteQube(byte v0, byte v1, byte v2, byte v3, byte v4, byte v5, byte v6, byte v7)
		{
			this.v0 = 0;
			this.v1 = 0;
			this.v2 = 0;
			this.v3 = 0;
			this.v4 = 0;
			this.v5 = 0;
			this.v6 = 0;
			this.v7 = 0;
		}

		public ByteQube(byte value)
		{
			v0 = 0;
			v1 = 0;
			v2 = 0;
			v3 = 0;
			v4 = 0;
			v5 = 0;
			v6 = 0;
			v7 = 0;
		}

		public ByteQube GetOriented(ByteQube orientation)
		{
			return default(ByteQube);
		}

		public ByteQube GetOrientedForward(byte orientation)
		{
			return default(ByteQube);
		}

		public ByteQube GetOrientedBackward(byte orientation)
		{
			return default(ByteQube);
		}

		public void GetOptimalOrientation(out ByteQube optimalByteQube, out byte optimalOrientation)
		{
			optimalByteQube = default(ByteQube);
			optimalOrientation = default(byte);
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static int GetWrappedIndex(int corner, int height)
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(ByteQube a, ByteQube b)
		{
			return false;
		}

		public static bool operator !=(ByteQube a, ByteQube b)
		{
			return false;
		}
	}
}
