using System;
using System.Collections.Generic;
using System.Reflection;

namespace VisualDesignCafe.ShaderX
{
	internal class ReflectionHelper
	{
		private static readonly BindingFlags _allBindings;

		private static readonly BindingFlags _staticBindings;

		private static Dictionary<string, MethodInfo> _methodCache;

		private static Dictionary<string, Type> _typeNameCache;

		private static Dictionary<Type, Type[]> _typeCache;

		public static object GetPropertyValue<T>(object obj, string propertyName)
		{
			return null;
		}

		public static object GetPropertyValue<T>(string propertyName)
		{
			return null;
		}

		public static void Invoke<T>(object obj, string methodName, object[] parameters)
		{
		}

		public static void Invoke<T>(string methodName, params object[] parameters)
		{
		}

		public static bool Invoke(string typeName, string methodName, params object[] parameters)
		{
			return false;
		}

		public static bool Invoke<T>(string typeName, string methodName, out T returnValue, params object[] parameters)
		{
			returnValue = default(T);
			return false;
		}

		public static Type[] GetTypesDerivedFrom<T>() where T : class
		{
			return null;
		}

		public static Type GetType(string fullName)
		{
			return null;
		}

		private static bool Invoke(Type type, string methodName, out object returnValue, params object[] parameters)
		{
			returnValue = null;
			return false;
		}
	}
}
