using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	internal class CVarEnumReferenceAsset : CVarReference<Enum>
	{
		[SerializeField]
		private CVarEnum_Internal _value;

		public Type GetEnumType()
		{
			return _value.GetEnumType();
		}

		public void SetEnumType(Type type)
		{
			if (_value == null)
			{
				_value = new CVarEnum_Internal();
			}
			_value.SetEnumType(type);
		}

		public override Enum GetCurrentValue()
		{
			return _value.GetValue();
		}

		public override void SetCurrentValue(Enum newValue)
		{
			_value.SetCurrentValue(Convert.ToInt32(newValue));
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
