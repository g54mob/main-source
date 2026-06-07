using System;
using UnityEngine;

namespace PajamaLlama.Generic
{
	[Serializable]
	public struct RangedInt
	{
		public int Minimum;

		public int Maximum;

		public RangedInt(int minimum, int maximum)
		{
			Minimum = minimum;
			Maximum = maximum;
		}

		public int EvaluateRounded(float percentage)
		{
			return Mathf.RoundToInt(Mathf.Lerp(Minimum, Maximum, percentage));
		}

		public int ReturnSize()
		{
			if (Minimum >= Maximum)
			{
				return Minimum - Maximum;
			}
			return Maximum - Minimum;
		}

		public int ReturnRandom()
		{
			return UnityEngine.Random.Range(Minimum, Maximum);
		}

		public bool ReturnContains(int value)
		{
			if (value >= Minimum)
			{
				return Maximum >= value;
			}
			return false;
		}
	}
}
