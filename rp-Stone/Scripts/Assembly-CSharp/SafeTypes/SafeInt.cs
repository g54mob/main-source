using UnityEngine;

namespace SafeTypes
{
	public struct SafeInt
	{
		private int offset;

		private int value;

		public SafeInt(int value)
		{
			offset = Random.Range(-1000000, 1000000);
			this.value = value + offset;
		}

		public int GetValue()
		{
			return value - offset;
		}

		public void Dispose()
		{
			offset = 0;
			value = 0;
		}

		public override string ToString()
		{
			return GetValue().ToString();
		}

		public static SafeInt operator +(SafeInt f1, SafeInt f2)
		{
			return new SafeInt(f1.GetValue() + f2.GetValue());
		}

		public static SafeInt operator -(SafeInt f1, SafeInt f2)
		{
			return new SafeInt(f1.GetValue() - f2.GetValue());
		}

		public static SafeInt operator +(SafeInt f1, int f2)
		{
			return new SafeInt(f1.GetValue() + f2);
		}

		public static SafeInt operator +(int f1, SafeInt f2)
		{
			return new SafeInt(f1 + f2.GetValue());
		}

		public static SafeInt operator *(SafeInt f1, SafeInt f2)
		{
			return new SafeInt(f1.GetValue() * f2.GetValue());
		}

		public static SafeInt operator ++(SafeInt f1)
		{
			return new SafeInt(f1.GetValue() + 1);
		}

		public static SafeInt operator --(SafeInt f1)
		{
			return new SafeInt(f1.GetValue() - 1);
		}

		public static bool operator >=(SafeInt f1, SafeInt f2)
		{
			return f1.GetValue() >= f2.GetValue();
		}

		public static bool operator >(SafeInt f1, SafeInt f2)
		{
			return f1.GetValue() > f2.GetValue();
		}

		public static bool operator <=(SafeInt f1, SafeInt f2)
		{
			return f1.GetValue() <= f2.GetValue();
		}

		public static bool operator <(SafeInt f1, SafeInt f2)
		{
			return f1.GetValue() < f2.GetValue();
		}

		public static bool operator ==(SafeInt f1, SafeInt f2)
		{
			return f1.GetValue() == f2.GetValue();
		}

		public static bool operator !=(SafeInt f1, SafeInt f2)
		{
			return f1.GetValue() != f2.GetValue();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			SafeInt safeInt = (SafeInt)obj;
			return GetValue() == safeInt.GetValue();
		}

		public override int GetHashCode()
		{
			return GetValue().GetHashCode();
		}
	}
}
