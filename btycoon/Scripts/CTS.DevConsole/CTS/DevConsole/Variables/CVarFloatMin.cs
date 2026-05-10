using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public class CVarFloatMin : CVarFloat
	{
		[Serializable]
		public struct FixedValues
		{
			public float _minimumValue;
		}

		[SerializeField]
		private FixedValues _fixedValues;

		internal CVarFloatMin()
		{
		}

		public override void SetCurrentValue(float newValue)
		{
			newValue = Math.Max(_fixedValues._minimumValue, newValue);
			base.SetCurrentValue(newValue);
		}

		public override void CopyFrom(ConsoleVarValue other)
		{
			if (other is CVarFloatMin cVarFloatMin)
			{
				_fixedValues = cVarFloatMin._fixedValues;
			}
		}

		public override void OnBeforeSerialize()
		{
			_defaultValue = Math.Max(_fixedValues._minimumValue, _defaultValue);
			base.OnBeforeSerialize();
		}
	}
}
