using System;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Bytes20 : IEquatable<Bytes20>
	{
		public long value0;

		public long value1;

		public int value2;

		public Bytes20(byte[] P_0)
		{
			value0 = 0L;
			value1 = 0L;
			value2 = 0;
		}

		public byte[] GetBytes()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(Bytes20 other)
		{
			return false;
		}

		public static bool operator ==(Bytes20 a, Bytes20 b)
		{
			return false;
		}

		public static bool operator !=(Bytes20 a, Bytes20 b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
