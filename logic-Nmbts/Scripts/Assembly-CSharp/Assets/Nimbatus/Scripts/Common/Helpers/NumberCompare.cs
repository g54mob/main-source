using System;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class NumberCompare
	{
		public static bool Compare(int baseValue, EIntegerCompareType compareType, int compareValue)
		{
			switch (compareType)
			{
			case EIntegerCompareType.Equal:
				return baseValue == compareValue;
			case EIntegerCompareType.Greater:
				return baseValue > compareValue;
			case EIntegerCompareType.Less:
				return baseValue < compareValue;
			case EIntegerCompareType.Not:
				return baseValue != compareValue;
			case EIntegerCompareType.GreaterOrEqual:
				return baseValue >= compareValue;
			case EIntegerCompareType.LessOrEqual:
				return baseValue <= compareValue;
			default:
				throw new NotImplementedException();
			}
		}

		public static bool Compare(float baseValue, EIntegerCompareType compareType, float compareValue)
		{
			switch (compareType)
			{
			case EIntegerCompareType.Equal:
				return Math.Abs(baseValue - compareValue) < 0.001f;
			case EIntegerCompareType.Greater:
				return baseValue > compareValue;
			case EIntegerCompareType.Less:
				return baseValue < compareValue;
			case EIntegerCompareType.Not:
				return Math.Abs(baseValue - compareValue) > 0.001f;
			case EIntegerCompareType.GreaterOrEqual:
				return baseValue >= compareValue;
			case EIntegerCompareType.LessOrEqual:
				return baseValue <= compareValue;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
