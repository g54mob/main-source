using System;
using UnityEngine;

namespace PajamaLlama.UI.Formatting
{
	[Serializable]
	public struct ColorRange
	{
		private enum RangeType
		{
			Range = 0,
			SmallerThen = 1,
			SmallerThenOrEqual = 2,
			LargerThen = 3,
			LargerThenOrEqual = 4,
			Any = 16
		}

		[SerializeField]
		private RangeType _rangeType;

		public int from;

		[ConditionalEnumHide("_rangeType", 0, false)]
		public int to;

		public Color Color;

		public bool IsInRange(int value)
		{
			switch (_rangeType)
			{
			case RangeType.Range:
				if (from <= value)
				{
					return value <= to;
				}
				return false;
			case RangeType.SmallerThen:
				return value < from;
			case RangeType.SmallerThenOrEqual:
				return value <= from;
			case RangeType.LargerThen:
				return from < value;
			case RangeType.LargerThenOrEqual:
				return from <= value;
			case RangeType.Any:
				return true;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
