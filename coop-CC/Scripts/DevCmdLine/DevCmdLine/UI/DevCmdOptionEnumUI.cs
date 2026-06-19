using System;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DevCmdLine.UI
{
	internal class DevCmdOptionEnumUI : DevCmdOptionUIBase
	{
		public string entryLabel;

		[Tooltip("Use {0} to indicate where the enum name will be placed.")]
		public string cmdFormat;

		public string enumType;

		private string[] _enumValues;

		private static Type[] _enumTypes;

		public override bool TryGetInitial(out string optionStr, out bool isEnd)
		{
			optionStr = entryLabel;
			isEnd = false;
			if (_enumValues == null)
			{
				Type type = Type.GetType(enumType);
				if (type == null)
				{
					Debug.LogWarning("Could not find type! (" + enumType + ")");
					_enumValues = new string[0];
					return false;
				}
				if (!type.IsEnum)
				{
					Debug.LogWarning("Type is not an enum! (" + enumType + ")");
					_enumValues = new string[0];
					return false;
				}
				_enumValues = Enum.GetNames(type);
			}
			return true;
		}

		public override List<DevCmdSubOption> Selected(List<object> contexts)
		{
			List<DevCmdSubOption> list = new List<DevCmdSubOption>();
			for (int i = 0; i < _enumValues.Length; i++)
			{
				list.Add(new DevCmdSubOption
				{
					text = _enumValues[i],
					context = _enumValues[i],
					isEnd = true
				});
			}
			return list;
		}

		public override string ConstructCmd(List<object> contexts)
		{
			return string.Format(cmdFormat, contexts[0]);
		}

		private ValueDropdownList<string> ValueDropDownGetTypes()
		{
			if (_enumTypes == null)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				List<Type> list = new List<Type>();
				Assembly[] array = assemblies;
				for (int i = 0; i < array.Length; i++)
				{
					Type[] types = array[i].GetTypes();
					foreach (Type type in types)
					{
						if (type.IsEnum && type.GetCustomAttribute<HideInInspector>() == null)
						{
							list.Add(type);
						}
					}
				}
				list.Sort((Type x, Type y) => string.CompareOrdinal(x.FullName, y.FullName));
				_enumTypes = list.ToArray();
			}
			ValueDropdownList<string> valueDropdownList = new ValueDropdownList<string>();
			for (int num = 0; num < _enumTypes.Length; num++)
			{
				Type type2 = _enumTypes[num];
				valueDropdownList.Add(type2.FullName, type2.AssemblyQualifiedName);
			}
			return valueDropdownList;
		}

		private bool ValidateType(string typeName, ref string errorMessage)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				return true;
			}
			Type type = Type.GetType(typeName);
			if (type == null)
			{
				errorMessage = "Invalid type name! (" + typeName + ")";
				return false;
			}
			if (!type.IsValueType)
			{
				errorMessage = "Type is not a struct! (" + typeName + ")";
				return false;
			}
			if (type.GetCustomAttribute<HideInInspector>() != null)
			{
				errorMessage = "Type is marked with HideInInspector! (" + typeName + ")";
				return false;
			}
			return true;
		}
	}
}
