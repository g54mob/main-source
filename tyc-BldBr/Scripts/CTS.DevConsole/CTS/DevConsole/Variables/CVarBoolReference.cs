using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public class CVarBoolReference : CVarReference<bool>
	{
		[SerializeField]
		private CVarBool _value;

		public static implicit operator bool(CVarBoolReference var)
		{
			return var.GetCurrentValue();
		}

		public override bool GetCurrentValue()
		{
			return _value;
		}

		public override void SetCurrentValue(bool newValue)
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
