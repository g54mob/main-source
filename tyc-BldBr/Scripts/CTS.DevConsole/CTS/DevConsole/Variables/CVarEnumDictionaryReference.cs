using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	internal class CVarEnumDictionaryReference : CVarReference<Dictionary<int, ConsoleVarValue>>
	{
		[SerializeField]
		private CVarEnumDictionary_Internal _value;

		public Type GetKeyType()
		{
			return _value.GetKeyType();
		}

		public Type GetValueType()
		{
			return _value.GetValueType();
		}

		public void SetTypes(Type keyType, Type valueType)
		{
			if (_value == null)
			{
				_value = new CVarEnumDictionary_Internal();
			}
			_value.SetTypes(keyType, valueType);
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
	public class CVarEnumDictionaryReference<TKey, TValue> : ISerializationCallbackReceiver where TKey : unmanaged, Enum where TValue : ConsoleVarValue
	{
		[SerializeField]
		private CVarEnumDictionaryReference _dictionaryValue;

		[SerializeField]
		private string _keyType;

		[SerializeField]
		private string _valueType;

		public TValue this[TKey key]
		{
			get
			{
				int key2 = Convert.ToInt32(key);
				return (TValue)_dictionaryValue.GetCurrentValue()[key2];
			}
		}

		public CVarEnumDictionaryReference()
		{
			Type[] genericTypeArguments = GetType().GenericTypeArguments;
			_keyType = genericTypeArguments[0].AssemblyQualifiedName;
			_valueType = genericTypeArguments[1].AssemblyQualifiedName;
		}

		public bool TryGetValue(TKey key, out TValue outValue)
		{
			int key2 = Convert.ToInt32(key);
			if (_dictionaryValue.GetCurrentValue().TryGetValue(key2, out var value) && value is TValue val)
			{
				outValue = val;
				return true;
			}
			outValue = null;
			return false;
		}

		public void OnBeforeSerialize()
		{
			Type[] genericTypeArguments = GetType().GenericTypeArguments;
			_keyType = genericTypeArguments[0].AssemblyQualifiedName;
			_valueType = genericTypeArguments[1].AssemblyQualifiedName;
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
