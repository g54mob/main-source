using UnityEngine;

namespace DV
{
	public static class FloatRounding
	{
		public static float To1Decimal(this float numberToRound)
		{
			return Mathf.Round(numberToRound * 10f) / 10f;
		}

		public static float To2Decimals(this float numberToRound)
		{
			return Mathf.Round(numberToRound * 100f) / 100f;
		}
	}
}
