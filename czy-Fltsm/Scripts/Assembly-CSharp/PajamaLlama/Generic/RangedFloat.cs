using System;
using UnityEngine;

namespace PajamaLlama.Generic
{
	[Serializable]
	public struct RangedFloat
	{
		public float Minimum;

		public float Maximum;

		public RangedFloat(float minimum, float maximum)
		{
			Minimum = minimum;
			Maximum = maximum;
		}

		public float Evaluate(float percentage)
		{
			return Mathf.Lerp(Minimum, Maximum, percentage);
		}

		public bool ReturnContainsValue(float value)
		{
			if (Minimum <= value)
			{
				return value <= Maximum;
			}
			return false;
		}

		public float ReturnRandom()
		{
			return UnityEngine.Random.Range(Minimum, Maximum);
		}
	}
}
