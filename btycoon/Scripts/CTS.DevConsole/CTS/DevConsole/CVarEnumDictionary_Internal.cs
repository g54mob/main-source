using System;
using System.Collections.Generic;
using CTS.DevConsole.Variables;
using UnityEngine;

namespace CTS.DevConsole
{
	[Serializable]
	internal class CVarEnumDictionary_Internal : CVarDictionary<int, EnumKeyValuePair>
	{
		[SerializeField]
		private string _keyTypeName;

		[SerializeField]
		private string _valueTypeName;

		private Type _keyType;

		private Type _valueType;

		public void SetTypes(Type keyType, Type valueType)
		{
			if (!typeof(Enum).IsAssignableFrom(keyType))
			{
				throw new Exception("Invalid type");
			}
			if (!typeof(ConsoleVarValue).IsAssignableFrom(valueType))
			{
				throw new Exception("Invalid value type");
			}
			_keyType = keyType;
			_keyTypeName = keyType.AssemblyQualifiedName;
			_valueType = valueType;
			_valueTypeName = valueType.AssemblyQualifiedName;
		}

		public Type GetKeyType()
		{
			return _keyType;
		}

		public Type GetValueType()
		{
			return _valueType;
		}

		protected override EnumKeyValuePair CreateNewPair(int key, ConsoleVarValue value)
		{
			return new EnumKeyValuePair(key, value, _keyType);
		}

		protected override bool TryParseKey(string arg, out int outKey)
		{
			if (Enum.TryParse(_keyType, arg, ignoreCase: true, out var result))
			{
				int num = Convert.ToInt32(result);
				outKey = num;
				return true;
			}
			outKey = 0;
			return false;
		}

		internal override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport report, string arg, int selfArgIndex, int realArgIndex)
		{
			return selfArgIndex switch
			{
				1 => ConsoleCommand.CheckEnumTypeArgument(ref report, arg, realArgIndex, _keyType), 
				2 => _exampleValue.CheckArgumentValidity(ref report, arg, realArgIndex - 1, realArgIndex), 
				_ => EValidity.Invalid, 
			};
		}

		public override void OnBeforeSerialize()
		{
			if ((object)_valueType == null)
			{
				_valueType = Type.GetType(_valueTypeName);
			}
			if (_exampleValue == null)
			{
				_exampleValue = (ConsoleVarValue)Activator.CreateInstance(_valueType, nonPublic: true);
			}
			List<ConsoleVarValue> list = new List<ConsoleVarValue>();
			for (int i = 0; i < _list.Count; i++)
			{
				EnumKeyValuePair value = _list[i];
				if (value.Value == null || list.Contains(value.Value))
				{
					value.Value = (ConsoleVarValue)Activator.CreateInstance(_valueType, nonPublic: true);
					list.Add(value.Value);
				}
				else
				{
					list.Add(value.Value);
				}
				_list[i] = value;
			}
			base.OnBeforeSerialize();
		}

		public override void OnAfterDeserialize()
		{
			base.OnAfterDeserialize();
			_keyType = Type.GetType(_keyTypeName);
			_valueType = Type.GetType(_valueTypeName);
			for (int i = 0; i < _list.Count; i++)
			{
				EnumKeyValuePair value = _list[i];
				value.SetType(_keyType);
				_list[i] = value;
			}
		}
	}
}
