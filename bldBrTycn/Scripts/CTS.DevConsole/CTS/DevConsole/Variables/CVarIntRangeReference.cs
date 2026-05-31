using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public class CVarIntRangeReference : CVarReference<int>
	{
		[SerializeField]
		private CVarIntRange _value;

		public static implicit operator int(CVarIntRangeReference var)
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
