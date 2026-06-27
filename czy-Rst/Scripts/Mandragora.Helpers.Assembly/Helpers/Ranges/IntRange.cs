using System;
using UnityEngine;

namespace Helpers.Ranges
{
	[Serializable]
	public struct IntRange : IRange<int>
	{
		[SerializeField]
		private int min;

		[SerializeField]
		private int max;

		public int Min
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

		public int Max
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

		public int Magnitude => Mathf.Abs(max - min);

		public IntRange(int aMin, int aMax)
		{
			if (aMin > aMax)
			{
				int num = aMax;
				aMax = aMin;
				aMin = num;
			}
			min = aMin;
			max = aMax;
		}

		public int Clamp(int targetValue)
		{
			return Mathf.Clamp(targetValue, Min, Max);
		}

		public int GetRandom()
		{
			return UnityEngine.Random.Range(Min, Max + 1);
		}

		public bool Contains(int targetValue)
		{
			if (min <= targetValue)
			{
				return targetValue <= max;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (24 * 33 + min.GetHashCode()) * 33 + max.GetHashCode();
		}
	}
}
