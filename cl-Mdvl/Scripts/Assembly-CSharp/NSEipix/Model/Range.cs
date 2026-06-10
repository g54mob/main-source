using System;
using UnityEngine;

namespace NSEipix.Model
{
	[Serializable]
	public abstract class Range<T> where T : IComparable<T>
	{
		[SerializeField]
		private T min;

		[SerializeField]
		private T max;

		public T Min
		{
			get
			{
				return min;
			}
			set
			{
				min = value;
			}
		}

		public T Max
		{
			get
			{
				return max;
			}
			set
			{
				max = value;
			}
		}

		public Range(T min, T max)
		{
			this.min = min;
			this.max = max;
		}

		public bool InRange(T value)
		{
			T other = Min;
			if (value.CompareTo(other) >= 0)
			{
				T other2 = Max;
				return value.CompareTo(other2) <= 0;
			}
			return false;
		}

		public T Clamp(T value)
		{
			T other = Min;
			if (value.CompareTo(other) >= 0)
			{
				T other2 = Max;
				if (value.CompareTo(other2) <= 0)
				{
					return value;
				}
				return Max;
			}
			return min;
		}

		public abstract T Random();

		public bool EqualsMinMax(Range<T> other)
		{
			ref T reference = ref min;
			object obj = other.min;
			if (reference.Equals(obj))
			{
				ref T reference2 = ref max;
				object obj2 = other.max;
				return reference2.Equals(obj2);
			}
			return false;
		}

		public override string ToString()
		{
			return $"Range[{min}, {max}]";
		}
	}
}
