using System;

namespace FluffyUnderware.DevTools
{
	[Serializable]
	public struct IntRegion : IEquatable<IntRegion>
	{
		public int From;

		public int To;

		public bool SimpleValue;

		public static IntRegion ZeroOne => default(IntRegion);

		public bool Positive => false;

		public int Low
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int High
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Random => 0;

		public int Length => 0;

		public int LengthPositive => 0;

		public IntRegion(int value)
		{
			From = 0;
			To = 0;
			SimpleValue = false;
		}

		public IntRegion(int A, int B)
		{
			From = 0;
			To = 0;
			SimpleValue = false;
		}

		public void MakePositive()
		{
		}

		public void Clamp(int low, int high)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(IntRegion other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static IntRegion operator +(IntRegion a, IntRegion b)
		{
			return default(IntRegion);
		}

		public static IntRegion operator -(IntRegion a, IntRegion b)
		{
			return default(IntRegion);
		}

		public static IntRegion operator -(IntRegion a)
		{
			return default(IntRegion);
		}

		public static IntRegion operator *(IntRegion a, int v)
		{
			return default(IntRegion);
		}

		public static IntRegion operator *(int v, IntRegion a)
		{
			return default(IntRegion);
		}

		public static IntRegion operator /(IntRegion a, int v)
		{
			return default(IntRegion);
		}

		public static bool operator ==(IntRegion lhs, IntRegion rhs)
		{
			return false;
		}

		public static bool operator !=(IntRegion lhs, IntRegion rhs)
		{
			return false;
		}
	}
}
