using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class ReflectionHelper
	{
		public static T GetValueFromMethodOrField<T>(object parentObject, string propertyName)
		{
			MethodInfo method = parentObject.GetType().GetMethod(propertyName);
			if (method != null)
			{
				if (method.ReturnType == typeof(T))
				{
					return (T)method.Invoke(parentObject, null);
				}
				throw new Exception("Method or Field " + propertyName + " missing on " + parentObject);
			}
			return (T)parentObject.GetType().GetField(propertyName).GetValue(parentObject);
		}

		public static T GetCopyOf<T>(this Component comp, T other) where T : Component
		{
			Type type = comp.GetType();
			if (type != other.GetType())
			{
				return null;
			}
			BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			PropertyInfo[] properties = type.GetProperties(bindingAttr);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!propertyInfo.CanWrite)
				{
					continue;
				}
				bool flag = false;
				foreach (CustomAttributeData item in (IEnumerable)propertyInfo.CustomAttributes)
				{
					if (item.AttributeType == typeof(ObsoleteAttribute))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					try
					{
						propertyInfo.SetValue(comp, propertyInfo.GetValue(other, null), null);
					}
					catch
					{
					}
				}
			}
			FieldInfo[] fields = type.GetFields(bindingAttr);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(comp, fieldInfo.GetValue(other));
			}
			return comp as T;
		}

		public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
		{
			return go.AddComponent<T>().GetCopyOf(toAdd);
		}
	}
}
