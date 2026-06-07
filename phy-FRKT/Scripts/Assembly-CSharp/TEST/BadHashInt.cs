using System;

namespace TEST
{
	internal struct BadHashInt : IEquatable<BadHashInt>
	{
		public int Value;

		public BadHashInt(int v)
		{
			Value = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(BadHashInt other)
		{
			return false;
		}
	}
}
