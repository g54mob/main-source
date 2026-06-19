using System;
using System.Collections.Generic;
using System.Reflection;

namespace PugMod
{
	public static class ModAPIExtensions
	{
		public static string GetNameChecked(this Type type)
		{
			return type.Name;
		}

		public static string GetNameChecked(this MemberInfo memberInfo)
		{
			return memberInfo.Internal.Name;
		}

		public static bool HasAttributeChecked<T>(this Type type) where T : Attribute
		{
			return type.GetCustomAttribute<T>() != null;
		}

		public static T GetAttributeChecked<T>(this Type type) where T : Attribute
		{
			return type.GetCustomAttribute<T>();
		}

		public static bool HasAttributeChecked<T>(this MemberInfo memberInfo) where T : Attribute
		{
			return memberInfo.Internal.GetCustomAttribute<T>() != null;
		}

		public static T GetAttributeChecked<T>(this MemberInfo memberInfo) where T : Attribute
		{
			return memberInfo.Internal.GetCustomAttribute<T>();
		}

		public static IEnumerable<Attribute> GetCustomAttributesChecked(this Type type)
		{
			return type.GetCustomAttributes();
		}

		public static IEnumerable<Attribute> GetCustomAttributesChecked(this MemberInfo memberInfo)
		{
			return memberInfo.Internal.GetCustomAttributes();
		}

		public static MemberInfo[] GetMembersChecked(this Type type)
		{
			System.Reflection.MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			MemberInfo[] array = new MemberInfo[members.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = members[i];
			}
			return array;
		}

		public static Type GetDeclaringTypeChecked(this MemberInfo memberInfo)
		{
			return memberInfo.Internal.DeclaringType;
		}

		public static object InvokeChecked(this MemberInfo memberInfo, object obj, params object[] parameters)
		{
			return API.Reflection.Invoke(memberInfo, obj, parameters);
		}

		public static object GetValueChecked(this MemberInfo memberInfo, object obj)
		{
			return API.Reflection.GetValue(memberInfo, obj);
		}

		public static void SetValueChecked(this MemberInfo memberInfo, object obj, object value)
		{
			API.Reflection.SetValue(memberInfo, obj, value);
		}
	}
}
