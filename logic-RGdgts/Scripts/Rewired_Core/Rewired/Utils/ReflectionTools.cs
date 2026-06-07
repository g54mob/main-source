using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rewired.Utils
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	public static class ReflectionTools
	{
		[Flags]
		public enum BindingFlags
		{
			IgnoreCase = 1,
			DeclaredOnly = 2,
			Instance = 4,
			Static = 8,
			Public = 0x10,
			NonPublic = 0x20,
			FlattenHierarchy = 0x40
		}

		public static bool IsValueType(Type type)
		{
			return false;
		}

		public static bool IsEnum(Type type)
		{
			return false;
		}

		public static Type GetUnderlyingEnumType(Type enumType)
		{
			return null;
		}

		public static bool IsClass(Type type)
		{
			return false;
		}

		public static bool IsPrimitive(Type type)
		{
			return false;
		}

		public static bool IsArray(Type type)
		{
			return false;
		}

		public static bool DoesTypeImplement(Type type, Type baseOrInterfaceType)
		{
			return false;
		}

		public static bool IsGenericType(Type type)
		{
			return false;
		}

		public static Type[] GetGenericArguments(Type type)
		{
			return null;
		}

		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			return null;
		}

		public static IEnumerable<FieldInfo> GetFields(Type type, BindingFlags bindingFlags)
		{
			return null;
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			return null;
		}

		public static IEnumerable<PropertyInfo> GetProperties(Type type, BindingFlags bindingFlags)
		{
			return null;
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type)
		{
			return null;
		}

		public static IEnumerable<MethodInfo> GetMethods(Type type, BindingFlags bindingFlags)
		{
			return null;
		}

		public static bool IsDefined(Type type, Type attributeType, bool inherit)
		{
			return false;
		}

		public static T GetAttribute<T>(Type type, bool inherit) where T : Attribute
		{
			return null;
		}

		internal static bool IsAssemblyLoaded(string assemblyName, bool useShortName, bool ignoreCase)
		{
			return false;
		}

		internal static Type GetTypeInUnityEditorAssembly(string classPath, bool ignoreCase = false)
		{
			return null;
		}

		internal static Type GetTypeInUnityBuildAssembly(string classPath, bool ignoreCase = false)
		{
			return null;
		}

		private static Type aPWgcuDRXtlxffXaiWLsuXDtwHbec(string P_0, bool P_1, bool P_2 = false)
		{
			return null;
		}

		internal static Type GetTypeInAssembly(string classPath, string assemblyName, bool ignoreCase = false)
		{
			return null;
		}

		public static TRet GetPrivateField<T, TRet>(T obj, string name)
		{
			return default(TRet);
		}

		public static TRet GetPrivateProperty<T, TRet>(T obj, string name)
		{
			return default(TRet);
		}

		public static void SetPrivateField<T>(T obj, string name, object value)
		{
		}

		public static void SetPrivateProperty<T>(T obj, string name, object value)
		{
		}

		public static TRet CallPrivateMethod<T, TRet>(T obj, string name, params object[] param)
		{
			return default(TRet);
		}

		public static MethodInfo GetMethodInfo(Delegate @delegate)
		{
			return null;
		}
	}
}
