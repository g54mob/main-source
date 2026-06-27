using System;
using UnityEngine;

namespace Helpers.Ranges
{
	[Serializable]
	public struct FloatRange : IRange<float>
	{
		[SerializeField]
		private float min;

		[SerializeField]
		private float max;

		public float Min
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

		public float Max
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

		public float Magnitude => Mathf.Abs(max - min);

		public FloatRange(float aMin, float aMax)
		{
			if (aMin > aMax)
			{
				float num = aMax;
				aMax = aMin;
				aMin = num;
			}
			min = aMin;
			max = aMax;
		}

		public float Clamp(float targetValue)
		{
			return Mathf.Clamp(targetValue, Min, Max);
		}

		public float To01(float value)
		{
			return Mathf.Clamp01((value - min) / Magnitude);
		}

		public float From01ToRange(float value)
		{
			return value * Magnitude + min;
		}

		public float From01RoundedWithDecimalsToRange(float value, int decimalPlaces)
		{
			return (float)(decimal.Round((decimal)value, decimalPlaces) * (decimal)Magnitude) + min;
		}

		public float GetRandom()
		{
			return UnityEngine.Random.Range(Min, Max);
		}

		public bool Contains(float targetValue)
		{
			if (min <= targetValue)
			{
				return targetValue <= max;
			}
			return false;
		}
	}
}
