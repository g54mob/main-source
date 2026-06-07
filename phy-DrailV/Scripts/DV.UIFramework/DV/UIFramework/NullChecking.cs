using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DV.UIFramework
{
	public static class NullChecking
	{
		public static List<NullReferenceError> FindNullReferencesOn(Component component)
		{
			List<NullReferenceError> list = new List<NullReferenceError>();
			if (component == null)
			{
				Debug.LogError("Component is null");
				return list;
			}
			foreach (FieldInfo item in GetFieldsWithAttributeFromType<NullCheckAttribute>(component.GetType(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				object value = item.GetValue(component);
				if (value == null || value.Equals(null))
				{
					list.Add(new NullReferenceError(item, component));
				}
			}
			return list;
		}

		private static List<FieldInfo> GetFieldsWithAttributeFromType<T>(Type classToInspect, BindingFlags reflectionFlags = BindingFlags.Default)
		{
			List<FieldInfo> list = new List<FieldInfo>();
			FieldInfo[] array = ((reflectionFlags != BindingFlags.Default) ? classToInspect.GetFields(reflectionFlags) : classToInspect.GetFields());
			FieldInfo[] array2 = array;
			foreach (FieldInfo fieldInfo in array2)
			{
				Attribute[] customAttributes = Attribute.GetCustomAttributes(fieldInfo);
				for (int j = 0; j < customAttributes.Length; j++)
				{
					if (customAttributes[j].GetType() == typeof(T))
					{
						list.Add(fieldInfo);
						break;
					}
				}
			}
			return list;
		}

		public static void NullCheck<T>(T obj, string objName, UnityEngine.Object context, [CallerMemberName] string caller = "")
		{
			if (obj == null)
			{
				Debug.LogError(typeof(T).Name + " '<b>" + objName + "</b>' in " + context.GetType().Name + "." + caller + " is null", context);
			}
		}
	}
}
