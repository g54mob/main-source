using System;
using UnityEngine;

namespace Restory.Utils
{
	public static class RoundingExtensions
	{
		public static int RoundToIntCustom(this float incomingValue, FloatToIntRoundingMode roundingMode)
		{
			return roundingMode switch
			{
				FloatToIntRoundingMode.HighestOfSmallerOrEqualInteger => Mathf.FloorToInt(incomingValue), 
				FloatToIntRoundingMode.NearestInteger => Mathf.RoundToInt(incomingValue), 
				FloatToIntRoundingMode.SmallestOfHigherOrEqualInteger => Mathf.CeilToInt(incomingValue), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
