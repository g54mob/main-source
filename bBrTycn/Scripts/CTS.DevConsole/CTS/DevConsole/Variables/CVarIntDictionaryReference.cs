using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	internal class CVarIntDictionaryReference : CVarReference<Dictionary<int, ConsoleVarValue>>
	{
		[SerializeField]
		private CVarIntDictionary_Internal _value;

		public Type GetValueType()
		{
			return _value.GetValueType();
		}

		public void SetValueType(Type type)
		{
			if (_value == null)
			{
				_value = new CVarIntDictionary_Internal();
			}
			_value.SetValueType(type);
		}

		internal override ConsoleVar GetVariable()
		{
			return _value;
		}

		public override Dictionary<int, ConsoleVarValue> GetCurrentValue()
		{
			return _value.GetCurrentValue();
		}

		public override void SetCurrentValue(Dictionary<int, ConsoleVarValue> newValue)
		{
			throw new NotImplementedException();
		}

		public override void ResetDefaultValue()
		{
			_value.SetDefaultValues();
		}
	}
	[Serializable]
	public class CVarIntDictionaryReference<TValue> : ISerializationCallbackReceiver where TValue : ConsoleVarValue
	{
		[SerializeField]
		private CVarIntDictionaryReference _dictionaryValue;

		[SerializeField]
		private string _genericType;

		public TValue this[int index] => (TValue)_dictionaryValue.GetCurrentValue()[index];

		public CVarIntDictionaryReference()
		{
			_genericType = GetType().GenericTypeArguments[0].AssemblyQualifiedName;
		}

		public bool TryGetValue(int key, out TValue outValue)
		{
			if (_dictionaryValue.GetCurrentValue().TryGetValue(key, out var value) && value is TValue val)
			{
				outValue = val;
				return true;
			}
			outValue = null;
			return false;
		}

		public void OnBeforeSerialize()
		{
			_genericType = GetType().GenericTypeArguments[0].AssemblyQualifiedName;
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
