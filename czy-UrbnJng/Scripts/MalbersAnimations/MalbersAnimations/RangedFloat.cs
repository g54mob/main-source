using System;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public struct RangedFloat
	{
		public float minValue;

		public float maxValue;

		public float Min
		{
			get
			{
				return minValue;
			}
			set
			{
				minValue = value;
			}
		}

		public float Max
		{
			get
			{
				return maxValue;
			}
			set
			{
				maxValue = value;
			}
		}

		public readonly float Difference => maxValue - minValue;

		public readonly float RandomValue => UnityEngine.Random.Range(minValue, maxValue);

		public RangedFloat(float minValue, float maxValue)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
		}

		public readonly bool IsInRange(float value)
		{
			if (value >= minValue)
			{
				return value <= maxValue;
			}
			return false;
		}
	}
}
