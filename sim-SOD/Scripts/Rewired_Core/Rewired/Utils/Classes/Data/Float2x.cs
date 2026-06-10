using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct Float2x : IEquatable<Float2x>
	{
		public const int Length = 2;

		public float a;

		public float b;

		private static Func<Float2x, Float2x, Float2x> _additionDelegate;

		private static Func<Float2x, Float2x, Float2x> _subtractionDelegate;

		private static Func<Float2x, Float2x, Float2x> _multiplicationDelegate;

		private static Func<Float2x, Float2x, Float2x> _divisionDelegate;

		public float this[int index]
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static Float2x Zero => default(Float2x);

		public Float2x(float a, float b)
		{
			this.a = 0f;
			this.b = 0f;
		}

		public Float2x Clone()
		{
			return default(Float2x);
		}

		public static Float2x Clone(Float2x obj)
		{
			return default(Float2x);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(Float2x other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public static Float2x Add(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Float2x Subtract(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Float2x Multiply(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Float2x Divide(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Func<Float2x, Float2x, Float2x> GetAdditionDelegate()
		{
			return null;
		}

		public static Func<Float2x, Float2x, Float2x> GetSubtractionDelegate()
		{
			return null;
		}

		public static Func<Float2x, Float2x, Float2x> GetMultiplicationDelegate()
		{
			return null;
		}

		public static Func<Float2x, Float2x, Float2x> GetDivisionDelegate()
		{
			return null;
		}

		public static implicit operator Float2x(Vector2 obj)
		{
			return default(Float2x);
		}

		public static implicit operator Vector2(Float2x obj)
		{
			return default(Vector2);
		}

		public static Float2x operator +(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Float2x operator -(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Float2x operator *(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Float2x operator /(Float2x value1, Float2x value2)
		{
			return default(Float2x);
		}

		public static Float2x operator +(Float2x value1, float value2)
		{
			return default(Float2x);
		}

		public static Float2x operator -(Float2x value1, float value2)
		{
			return default(Float2x);
		}

		public static Float2x operator *(Float2x value1, float value2)
		{
			return default(Float2x);
		}

		public static Float2x operator /(Float2x value1, float value2)
		{
			return default(Float2x);
		}
	}
}
