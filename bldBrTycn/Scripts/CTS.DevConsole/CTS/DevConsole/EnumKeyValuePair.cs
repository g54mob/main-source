using System;
using CTS.DevConsole.Variables;
using UnityEngine;

namespace CTS.DevConsole
{
	[Serializable]
	internal struct EnumKeyValuePair : IKeyValue<int>, ISerializationCallbackReceiver
	{
		[SerializeField]
		private int _key;

		[SerializeReference]
		[CVarDictionary]
		private ConsoleVarValue _value;

		[SerializeField]
		private string _keyTypeName;

		private Type _keyType;

		public int Key
		{
			get
			{
				return _key;
			}
			set
			{
				_key = value;
			}
		}

		public ConsoleVarValue Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public void SetType(Type type)
		{
			_keyType = type;
			_keyTypeName = type.AssemblyQualifiedName;
		}

		public EnumKeyValuePair(int key, ConsoleVarValue value, Type keyType)
		{
			_key = key;
			_value = value;
			_keyTypeName = keyType.AssemblyQualifiedName;
			_keyType = keyType;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			_keyType = Type.GetType(_keyTypeName);
		}
	}
}
