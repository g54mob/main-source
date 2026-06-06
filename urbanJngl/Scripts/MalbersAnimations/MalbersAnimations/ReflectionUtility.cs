using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace MalbersAnimations
{
	public static class ReflectionUtility
	{
		public static FieldInfo GetFieldViaPath(this Type type, string path)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			Type type2 = type;
			FieldInfo field = type2.GetField(path, bindingAttr);
			string[] array = path.Split('.');
			for (int i = 0; i < array.Length; i++)
			{
				field = type2.GetField(array[i], bindingAttr);
				if (field == null)
				{
					continue;
				}
				if (field.FieldType.IsArray)
				{
					type2 = field.FieldType.GetElementType();
					i += 2;
					continue;
				}
				if (field.FieldType.IsGenericType)
				{
					type2 = field.FieldType.GetGenericArguments()[0];
					i += 2;
					continue;
				}
				if (field != null)
				{
					type2 = field.FieldType;
					continue;
				}
				return null;
			}
			return field;
		}

		public static List<Type> GetAllTypes<T>()
		{
			Type typeFromHandle = typeof(T);
			Type[] types = typeFromHandle.Assembly.GetTypes();
			List<Type> list = new List<Type>();
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].IsSubclassOf(typeFromHandle) && !types[i].IsAbstract)
				{
					list.Add(types[i]);
				}
			}
			return list;
		}

		public static List<Type> GetAllTypes(Type type)
		{
			Type[] types = type.Assembly.GetTypes();
			List<Type> list = new List<Type>();
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].IsSubclassOf(type) && !types[i].IsAbstract)
				{
					list.Add(types[i]);
				}
			}
			return list;
		}

		public static Type[] GetTypesByName(string className)
		{
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Type[] types = assemblies[i].GetTypes();
				for (int j = 0; j < types.Length; j++)
				{
					if (types[j].Name == className)
					{
						list.Add(types[j]);
					}
				}
			}
			return list.ToArray();
		}

		public static Type GetTypeByName(string className)
		{
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly x) => x.GetTypes()).FirstOrDefault((Type t) => t.Name == className);
		}

		public static IEnumerable<FieldInfo> GetAllFields(object target, Func<FieldInfo, bool> predicate)
		{
			if (target == null)
			{
				Debug.LogError("The target object is null. Check for missing scripts.");
				yield break;
			}
			List<Type> types = GetSelfAndBaseTypes(target);
			for (int i = types.Count - 1; i >= 0; i--)
			{
				IEnumerable<FieldInfo> enumerable = types[i].GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(predicate);
				foreach (FieldInfo item in enumerable)
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<PropertyInfo> GetAllProperties(object target, Func<PropertyInfo, bool> predicate)
		{
			if (target == null)
			{
				Debug.LogError("The target object is null. Check for missing scripts.");
				yield break;
			}
			List<Type> types = GetSelfAndBaseTypes(target);
			for (int i = types.Count - 1; i >= 0; i--)
			{
				IEnumerable<PropertyInfo> enumerable = types[i].GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(predicate);
				foreach (PropertyInfo item in enumerable)
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<MethodInfo> GetAllMethods(object target, Func<MethodInfo, bool> predicate)
		{
			if (target == null)
			{
				Debug.LogError("The target object is null. Check for missing scripts.");
				yield break;
			}
			List<Type> types = GetSelfAndBaseTypes(target);
			for (int i = types.Count - 1; i >= 0; i--)
			{
				IEnumerable<MethodInfo> enumerable = types[i].GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(predicate);
				foreach (MethodInfo item in enumerable)
				{
					yield return item;
				}
			}
		}

		public static FieldInfo GetField(object target, string fieldName)
		{
			return GetAllFields(target, (FieldInfo f) => f.Name.Equals(fieldName, StringComparison.Ordinal)).FirstOrDefault();
		}

		public static PropertyInfo GetProperty(object target, string propertyName)
		{
			return GetAllProperties(target, (PropertyInfo p) => p.Name.Equals(propertyName, StringComparison.Ordinal)).FirstOrDefault();
		}

		public static MethodInfo GetMethod(object target, string methodName)
		{
			return GetAllMethods(target, (MethodInfo m) => m.Name.Equals(methodName, StringComparison.Ordinal)).FirstOrDefault();
		}

		public static Type GetListElementType(Type listType)
		{
			if (listType.IsGenericType)
			{
				return listType.GetGenericArguments()[0];
			}
			return listType.GetElementType();
		}

		private static List<Type> GetSelfAndBaseTypes(object target)
		{
			List<Type> list = new List<Type> { target.GetType() };
			while (list.Last().BaseType != null)
			{
				list.Add(list.Last().BaseType);
			}
			return list;
		}
	}
}
