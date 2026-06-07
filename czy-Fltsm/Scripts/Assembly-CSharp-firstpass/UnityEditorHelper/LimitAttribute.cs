using System;
using UnityEngine;

namespace UnityEditorHelper
{
	public class LimitAttribute : PropertyAttribute
	{
		public enum Mode
		{
			LimitLower = 0,
			LimitUpper = 1,
			LimitBoth = 2
		}

		private readonly Mode _limitMode;

		private readonly int _lowerLimit;

		private readonly int _upperLimit;

		public LimitAttribute(int lowerLimit)
			: this(Mode.LimitLower, lowerLimit, int.MaxValue)
		{
		}

		public LimitAttribute(int lowerLimit, int upperLimit)
			: this(Mode.LimitLower, lowerLimit, upperLimit)
		{
		}

		private LimitAttribute(Mode mode, int lowerLimit, int upperLimit)
		{
			_limitMode = mode;
			_lowerLimit = lowerLimit;
			_upperLimit = upperLimit;
		}

		public int Limit(int value)
		{
			return _limitMode switch
			{
				Mode.LimitLower => Mathf.Clamp(value, _lowerLimit, int.MaxValue), 
				Mode.LimitUpper => Mathf.Clamp(value, int.MinValue, _upperLimit), 
				Mode.LimitBoth => Mathf.Clamp(value, _lowerLimit, _upperLimit), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
