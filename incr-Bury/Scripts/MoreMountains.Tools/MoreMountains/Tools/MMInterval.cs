using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	[Serializable]
	public struct MMInterval<T> where T : struct, IComparable
	{
		public enum MMIntervalType
		{
			Inclusive = 0,
			Exclusive = 1
		}

		[Tooltip("the lower bound of this interval")]
		public T LowerBound;

		[Tooltip("the upper bound of this interval")]
		public T UpperBound;

		[Tooltip("whether to include or exclude the lower bound in the interval")]
		public MMIntervalType LowerBoundIntervalType;

		[Tooltip("whether to include or exclude the upper bound in the interval")]
		public MMIntervalType UpperBoundIntervalType;

		public MMInterval(T lowerBound, T upperBound, MMIntervalType lowerboundIntervalType = MMIntervalType.Inclusive, MMIntervalType upperboundIntervalType = MMIntervalType.Inclusive)
		{
			this = default(MMInterval<T>);
			T lowerBound2 = lowerBound;
			T val = upperBound;
			if (lowerBound2.CompareTo(val) > 0)
			{
				lowerBound2 = upperBound;
				val = lowerBound;
			}
			LowerBound = lowerBound2;
			UpperBound = val;
			LowerBoundIntervalType = lowerboundIntervalType;
			UpperBoundIntervalType = upperboundIntervalType;
		}

		public bool Contains(T value)
		{
			bool num = ((LowerBoundIntervalType == MMIntervalType.Exclusive) ? (LowerBound.CompareTo(value) < 0) : (LowerBound.CompareTo(value) <= 0));
			bool flag = ((UpperBoundIntervalType == MMIntervalType.Exclusive) ? (UpperBound.CompareTo(value) > 0) : (UpperBound.CompareTo(value) >= 0));
			return num && flag;
		}
	}
}
