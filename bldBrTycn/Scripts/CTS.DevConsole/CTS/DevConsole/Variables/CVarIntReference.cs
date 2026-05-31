using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public class CVarIntReference : CVarReference<int>
	{
		[SerializeField]
		private CVarInt _value;

		public static implicit operator int(CVarIntReference var)
		{
			return var._value;
		}

		public override int GetCurrentValue()
		{
			return _value;
		}

		public override void SetCurrentValue(int newValue)
		{
			throw new NotImplementedException();
		}

		public override void ResetDefaultValue()
		{
			throw new NotImplementedException();
		}

		internal override ConsoleVar GetVariable()
		{
			return _value;
		}
	}
}
