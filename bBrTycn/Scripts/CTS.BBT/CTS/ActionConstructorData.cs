using System;
using System.Reflection;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class ActionConstructorData
	{
		[field: SerializeField]
		public ActionConstructor Constructor { get; private set; }

		[field: SerializeField]
		public string Name { get; private set; }

		public bool HasConstructor => Constructor != null;

		public bool HasSerializedFields
		{
			get
			{
				if (!HasConstructor)
				{
					return false;
				}
				FieldInfo[] fields = Constructor.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.IsPublic)
					{
						return true;
					}
					if (fieldInfo.GetCustomAttribute<SerializeField>() != null)
					{
						return true;
					}
				}
				return false;
			}
		}

		public static string FormatTypeName(Type type)
		{
			string name = type.Name;
			name = name.Replace("AgentAction", "");
			name = name.Replace("CustomerAction", "");
			name = name.Replace("WorkerAction", "");
			name = name.Replace("Constructor", "");
			if (name.StartsWith("Action"))
			{
				name = name.Remove(0, 6);
			}
			return name.AddSpacesBeforeCapitals();
		}

		public static bool IsTypeValid(Type type)
		{
			if (type.IsAbstract)
			{
				return false;
			}
			return typeof(ActionConstructor).IsAssignableFrom(type);
		}
	}
}
