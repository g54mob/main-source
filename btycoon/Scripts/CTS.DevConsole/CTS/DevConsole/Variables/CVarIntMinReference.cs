using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public class CVarIntMinReference : CVarReference<int>
	{
		[SerializeField]
		private CVarIntMin _value;

		public static implicit operator int(CVarIntMinReference var)
		{
			return var._value;
		}

		public override int GetCurrentValue()
		{
			return _value;
		}

		public override void SetCurrentValue(int newValue)
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
