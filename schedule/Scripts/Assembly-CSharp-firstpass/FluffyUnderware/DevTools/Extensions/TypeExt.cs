using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluffyUnderware.DevTools.Extensions
{
	public static class TypeExt
	{
		public static Type[] GetLoadedTypes()
		{
			return null;
		}

		public static IEnumerable<Assembly> GetLoadedAssemblies()
		{
			return null;
		}

		public static Dictionary<U, Type> GetAllTypesWithAttribute<U>(this Type type)
		{
			return null;
		}

		public static List<FieldInfo> GetFieldsWithAttribute<T>(this Type type, bool includeInherited = false, bool includePrivate = false) where T : Attribute
		{
			return null;
		}

		public static T GetCustomAttribute<T>(this Type type) where T : Attribute
		{
			return null;
		}

		public static MethodInfo MethodByName(this Type type, string name, bool includeInherited = false, bool includePrivate = false)
		{
			return null;
		}

		public static FieldInfo FieldByName(this Type type, string name, bool includeInherited = false, bool includePrivate = false)
		{
			return null;
		}

		public static PropertyInfo PropertyByName(this Type type, string name, bool includeInherited = false, bool includePrivate = false)
		{
			return null;
		}

		public static FieldInfo[] GetAllFields(this Type type, bool includeInherited = false, bool includePrivate = false)
		{
			return null;
		}

		public static PropertyInfo[] GetAllProperties(this Type type, bool includeInherited = false, bool includePrivate = false)
		{
			return null;
		}

		public static bool IsFrameworkType(this Type type)
		{
			return false;
		}

		public static bool IsArrayOrList(this Type type)
		{
			return false;
		}

		public static Type GetEnumerableType(this Type t)
		{
			return null;
		}

		private static Type FindIEnumerable(Type seqType)
		{
			return null;
		}

		private static MethodInfo GetMethodIncludingBaseClasses(this Type type, string name, BindingFlags bindingFlags)
		{
			return null;
		}

		private static FieldInfo GetFieldIncludingBaseClasses(this Type type, string name, BindingFlags bindingFlags)
		{
			return null;
		}

		private static PropertyInfo GetPropertyIncludingBaseClasses(this Type type, string name, BindingFlags bindingFlags)
		{
			return null;
		}

		public static bool Matches(this Type type, params Type[] types)
		{
			return false;
		}
	}
}
