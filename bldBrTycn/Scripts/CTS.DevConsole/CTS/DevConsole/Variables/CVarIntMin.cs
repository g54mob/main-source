using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public class CVarIntMin : CVarInt
	{
		[Serializable]
		public struct FixedValues
		{
			public int _minimumValue;
		}

		[SerializeField]
		private FixedValues _fixedValues;

		internal CVarIntMin()
		{
		}

		public override void SetCurrentValue(int newValue)
		{
			newValue = Math.Max(_fixedValues._minimumValue, newValue);
			base.SetCurrentValue(newValue);
		}

		public override void CopyFrom(ConsoleVarValue other)
		{
			if (other is CVarIntMin cVarIntMin)
			{
				_fixedValues = cVarIntMin._fixedValues;
			}
		}

		public override void OnBeforeSerialize()
		{
			_defaultValue = Math.Max(_fixedValues._minimumValue, _defaultValue);
			base.OnBeforeSerialize();
		}
	}
}
