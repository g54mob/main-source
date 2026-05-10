using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public class CVarFloatRangeReference : CVarReference<float>
	{
		[SerializeField]
		internal CVarFloatRange _value;

		public static implicit operator float(CVarFloatRangeReference cvar)
		{
			return cvar.GetCurrentValue();
		}

		public override float GetCurrentValue()
		{
			return _value;
		}

		public override void SetCurrentValue(float newValue)
		{
			_value.SetCurrentValue(newValue);
		}

		public override void ResetDefaultValue()
		{
			_value.SetDefaultValues();
		}

		internal override ConsoleVar GetVariable()
		{
			return _value;
		}
	}
}
