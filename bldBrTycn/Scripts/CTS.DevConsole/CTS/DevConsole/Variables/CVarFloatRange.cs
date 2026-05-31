using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public class CVarFloatRange : CVarFloat
	{
		[Serializable]
		public struct FixedValues
		{
			public Vector2 _range;
		}

		[SerializeField]
		private FixedValues _fixedValues;

		internal CVarFloatRange()
		{
		}

		public override void SetCurrentValue(float newValue)
		{
			newValue = Math.Clamp(newValue, _fixedValues._range.x, _fixedValues._range.y);
			base.SetCurrentValue(newValue);
		}

		public override void CopyFrom(ConsoleVarValue other)
		{
			if (other is CVarFloatRange cVarFloatRange)
			{
				_fixedValues = cVarFloatRange._fixedValues;
			}
		}

		public override void OnBeforeSerialize()
		{
			_defaultValue = Math.Clamp(_defaultValue, _fixedValues._range.x, _fixedValues._range.y);
			base.OnBeforeSerialize();
		}
	}
}
