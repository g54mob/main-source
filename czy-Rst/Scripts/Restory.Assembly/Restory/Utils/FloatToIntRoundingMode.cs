using System;

namespace Restory.Utils
{
	[Serializable]
	public enum FloatToIntRoundingMode
	{
		HighestOfSmallerOrEqualInteger = 0,
		NearestInteger = 10,
		SmallestOfHigherOrEqualInteger = 20
	}
}
