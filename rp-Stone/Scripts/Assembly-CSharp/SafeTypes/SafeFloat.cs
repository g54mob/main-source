using UnityEngine;

namespace SafeTypes
{
	public struct SafeFloat
	{
		private int offset;

		private float value;

		public SafeFloat(float value)
		{
			offset = Random.Range(-100, 100);
			this.value = value + (float)offset;
		}

		public float GetValue()
		{
			return value - (float)offset;
		}

		public void Dispose()
		{
			offset = 0;
			value = 0f;
		}

		public override string ToString()
		{
			return GetValue().ToString();
		}

		public static SafeFloat operator +(SafeFloat f1, SafeFloat f2)
		{
			return new SafeFloat(f1.GetValue() + f2.GetValue());
		}

		public static SafeFloat operator +(SafeFloat f1, int f2)
		{
			return new SafeFloat(f1.GetValue() + (float)f2);
		}

		public static SafeFloat operator +(int f1, SafeFloat f2)
		{
			return new SafeFloat((float)f1 + f2.GetValue());
		}

		public static SafeFloat operator +(SafeFloat f1, float f2)
		{
			return new SafeFloat(f1.GetValue() + f2);
		}

		public static SafeFloat operator +(float f1, SafeFloat f2)
		{
			return new SafeFloat(f1 + f2.GetValue());
		}

		public static SafeFloat operator -(SafeFloat f1, SafeFloat f2)
		{
			return new SafeFloat(f1.GetValue() - f2.GetValue());
		}

		public static SafeFloat operator -(SafeFloat f1, float f2)
		{
			return new SafeFloat(f1.GetValue() - f2);
		}

		public static SafeFloat operator -(float f1, SafeFloat f2)
		{
			return new SafeFloat(f1 - f2.GetValue());
		}

		public static SafeFloat operator *(SafeFloat f1, SafeFloat f2)
		{
			return new SafeFloat(f1.GetValue() * f2.GetValue());
		}

		public static SafeFloat operator *(SafeFloat f1, float f2)
		{
			return new SafeFloat(f1.GetValue() * f2);
		}

		public static SafeFloat operator *(float f1, SafeFloat f2)
		{
			return new SafeFloat(f1 * f2.GetValue());
		}

		public static bool operator >=(SafeFloat f1, SafeFloat f2)
		{
			return f1.GetValue() >= f2.GetValue();
		}

		public static bool operator >(SafeFloat f1, SafeFloat f2)
		{
			return f1.GetValue() > f2.GetValue();
		}

		public static bool operator <=(SafeFloat f1, SafeFloat f2)
		{
			return f1.GetValue() <= f2.GetValue();
		}

		public static bool operator <(SafeFloat f1, SafeFloat f2)
		{
			return f1.GetValue() < f2.GetValue();
		}

		public static bool operator ==(SafeFloat f1, SafeFloat f2)
		{
			return Mathf.Approximately(f1.GetValue(), f2.GetValue());
		}

		public static bool operator !=(SafeFloat f1, SafeFloat f2)
		{
			return !Mathf.Approximately(f1.GetValue(), f2.GetValue());
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			SafeFloat safeFloat = (SafeFloat)obj;
			return Mathf.Approximately(GetValue(), safeFloat.GetValue());
		}

		public override int GetHashCode()
		{
			return GetValue().GetHashCode();
		}
	}
}
