using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	internal class CVarIntDictionary_Internal : CVarDictionary<int, CVarIntDictionary_Internal.IntKeyValuePair>
	{
		[Serializable]
		protected internal struct IntKeyValuePair : IKeyValue<int>
		{
			[SerializeField]
			private int _key;

			[SerializeReference]
			[CVarDictionary]
			private ConsoleVarValue _value;

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

			public IntKeyValuePair(int key, ConsoleVarValue value)
			{
				_key = key;
				_value = value;
			}
		}

		[SerializeField]
		private string _valueTypeName;

		private Type _valueType;

		public void SetValueType(Type type)
		{
			if (!typeof(ConsoleVarValue).IsAssignableFrom(type))
			{
				throw new Exception("Invalid type");
			}
			_valueType = type;
			_valueTypeName = type.AssemblyQualifiedName;
		}

		public Type GetValueType()
		{
			return _valueType;
		}

		protected override IntKeyValuePair CreateNewPair(int key, ConsoleVarValue value)
		{
			return new IntKeyValuePair(key, value);
		}

		protected override bool TryParseKey(string arg, out int outKey)
		{
			return int.TryParse(arg, out outKey);
		}

		internal override EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport report, string arg, int selfArgIndex, int realArgIndex)
		{
			return selfArgIndex switch
			{
				1 => ConsoleCommand.CheckBasicTypeArgument(ref report, null, arg, realArgIndex, ConsoleCommand.EArgType.Int, isLastArg: true), 
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
				IntKeyValuePair value = _list[i];
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
			_valueType = Type.GetType(_valueTypeName);
		}
	}
}
