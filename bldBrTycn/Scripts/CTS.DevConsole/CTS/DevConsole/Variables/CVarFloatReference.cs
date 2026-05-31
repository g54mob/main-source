using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public class CVarFloatReference : CVarReference<float>
	{
		[SerializeField]
		internal CVarFloat _value;

		public static implicit operator float(CVarFloatReference cvar)
		{
			return cvar._value;
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
