using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Float3x : IEquatable<Float3x>
	{
		public const int Length = 3;

		public float a;

		public float b;

		public float c;

		private static Func<Float3x, Float3x, Float3x> _additionDelegate;

		private static Func<Float3x, Float3x, Float3x> _subtractionDelegate;

		private static Func<Float3x, Float3x, Float3x> _multiplicationDelegate;

		private static Func<Float3x, Float3x, Float3x> _divisionDelegate;

		public float Item
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static Float3x Zero => default(Float3x);

		public Float3x(float P_0, float P_1, float P_2)
		{
			a = 0f;
			b = 0f;
			c = 0f;
		}

		public Float3x Clone()
		{
			return default(Float3x);
		}

		public static Float3x Clone(Float3x obj)
		{
			return default(Float3x);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(Float3x other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public static Float3x Add(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Float3x Subtract(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Float3x Multiply(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Float3x Divide(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Func<Float3x, Float3x, Float3x> GetAdditionDelegate()
		{
			return null;
		}

		public static Func<Float3x, Float3x, Float3x> GetSubtractionDelegate()
		{
			return null;
		}

		public static Func<Float3x, Float3x, Float3x> GetMultiplicationDelegate()
		{
			return null;
		}

		public static Func<Float3x, Float3x, Float3x> GetDivisionDelegate()
		{
			return null;
		}

		public static implicit operator Float3x(Vector3 obj)
		{
			return default(Float3x);
		}

		public static implicit operator Vector3(Float3x obj)
		{
			return default(Vector3);
		}

		public static Float3x operator +(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Float3x operator -(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Float3x operator *(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Float3x operator /(Float3x value1, Float3x value2)
		{
			return default(Float3x);
		}

		public static Float3x operator +(Float3x value1, float value2)
		{
			return default(Float3x);
		}

		public static Float3x operator -(Float3x value1, float value2)
		{
			return default(Float3x);
		}

		public static Float3x operator *(Float3x value1, float value2)
		{
			return default(Float3x);
		}

		public static Float3x operator /(Float3x value1, float value2)
		{
			return default(Float3x);
		}
	}
}
