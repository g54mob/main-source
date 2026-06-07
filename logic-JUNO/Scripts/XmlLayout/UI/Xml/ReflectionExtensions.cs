using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UI.Xml
{
	public static class ReflectionExtensions
	{
		private static Dictionary<MemberInfo, Type> memberTypeCache = new Dictionary<MemberInfo, Type>();

		public static Type GetMemberDataType(this MemberInfo memberInfo)
		{
			if (memberTypeCache.ContainsKey(memberInfo))
			{
				return memberTypeCache[memberInfo];
			}
			FieldInfo field = memberInfo.DeclaringType.GetField(memberInfo.Name);
			if (field != null)
			{
				memberTypeCache.Add(memberInfo, field.FieldType);
				return field.FieldType;
			}
			PropertyInfo property = memberInfo.DeclaringType.GetProperty(memberInfo.Name);
			if (property != null)
			{
				memberTypeCache.Add(memberInfo, property.PropertyType);
				return property.PropertyType;
			}
			return null;
		}

		public static void SetMemberValue(this MemberInfo memberInfo, object o, object newValue)
		{
			FieldInfo field = memberInfo.DeclaringType.GetField(memberInfo.Name);
			if (field != null)
			{
				field.SetValue(o, newValue);
				return;
			}
			PropertyInfo property = memberInfo.DeclaringType.GetProperty(memberInfo.Name);
			if (property != null)
			{
				property.SetValue(o, newValue, null);
				return;
			}
			Debug.LogWarningFormat("[XmlLayout][Warning] Member '{0}' not found for SetValue().", memberInfo.Name);
		}

		public static object GetMemberValue(this MemberInfo memberInfo, object o)
		{
			FieldInfo field = memberInfo.DeclaringType.GetField(memberInfo.Name);
			if (field != null)
			{
				return field.GetValue(o);
			}
			PropertyInfo property = memberInfo.DeclaringType.GetProperty(memberInfo.Name);
			if (property != null)
			{
				return property.GetValue(o, XmlLayoutUtilities.BindingFlags, null, null, null);
			}
			Debug.LogWarningFormat("[XmlLayout][Warning] Member '{0}' not found for GetValue().", memberInfo.Name);
			return null;
		}

		public static bool IsAutoProperty(this PropertyInfo prop)
		{
			if (!prop.CanWrite || !prop.CanRead)
			{
				return false;
			}
			return prop.DeclaringType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Any((FieldInfo f) => f.Name.Contains("<" + prop.Name + ">"));
		}
	}
}
