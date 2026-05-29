using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	internal class CVarEnum_Internal : ConsoleVarValue<int>
	{
		[SerializeField]
		private string _enumName;

		private Type _enumType;

		internal void SetEnumType(Type type)
		{
			_enumType = type;
			_enumName = type.AssemblyQualifiedName;
		}

		internal Type GetEnumType()
		{
			return _enumType;
		}

		internal Enum GetValue()
		{
			return (Enum)Enum.ToObject(_enumType, _currentValue);
		}

		public override string ToString()
		{
			return _currentValue.ToString();
		}

		internal override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport report, string arg, int selfArgIndex, int realArgIndex)
		{
			if (selfArgIndex == 1)
			{
				EValidity correctTypeValidity = ConsoleCommand.CheckEnumTypeArgument(ref report, arg, realArgIndex, _enumType);
				return ConsoleVarValue.CheckArgumentForDefault(ref report, arg, realArgIndex, correctTypeValidity);
			}
			return EValidity.Invalid;
		}

		internal override string CurrentValueToString()
		{
			return Enum.ToObject(_enumType, _currentValue).ToString();
		}

		internal override bool TryParse(string arg, out int outValue)
		{
			if (Enum.TryParse(_enumType, arg, ignoreCase: true, out var result))
			{
				outValue = Convert.ToInt32(result);
				return true;
			}
			outValue = 0;
			return false;
		}

		public override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();
			_enumType = Type.GetType(_enumName);
		}
	}
}
