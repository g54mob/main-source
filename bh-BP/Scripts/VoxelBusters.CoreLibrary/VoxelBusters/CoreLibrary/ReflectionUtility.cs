using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace VoxelBusters.CoreLibrary
{
	public static class ReflectionUtility
	{
		[Obsolete("Use method GetTypeFromAssemblyCSharp instead.", false)]
		public static Type GetTypeFromCSharpAssembly(string typeName)
		{
			return null;
		}

		[Obsolete("Use method GetTypeFromAssemblyCSharp instead.", false)]
		public static Type GetTypeFromCSharpFirstPassAssembly(string typeName)
		{
			return null;
		}

		public static Type GetTypeFromAssemblyCSharp(string typeName, bool includeFirstPass = false)
		{
			return null;
		}

		public static Type GetType(string assemblyName, string typeName)
		{
			return null;
		}

		public static Assembly FindAssemblyWithName(string assemblyName)
		{
			return null;
		}

		public static Type[] FindAllTypes(Predicate<Type> predicate = null)
		{
			return null;
		}

		public static bool TryGetCustomAttriute(this MethodInfo methodInfo, Type attributeType, out Attribute attribute, bool inherit = false)
		{
			attribute = null;
			return false;
		}

		public static bool TryGetCustomAttriute<TAttribute>(this MethodInfo methodInfo, out TAttribute attribute, bool inherit = false) where TAttribute : Attribute
		{
			attribute = null;
			return false;
		}

		public static object CreateInstance(Type type, bool nonPublic = true)
		{
			return null;
		}

		public static object CreateInstance(Type type, params object[] args)
		{
			return null;
		}

		public static Dictionary<Type, Attribute[]> FindTypesWithAttribute(Type attributeType, bool inherit = false)
		{
			return null;
		}

		public static object InvokeStaticMethod(this Type type, string method, params object[] parameters)
		{
			return null;
		}

		public static T InvokeStaticMethod<T>(this Type type, string method, params object[] parameters)
		{
			return default(T);
		}

		public static void SetPropertyValue(this object obj, string name, object value)
		{
		}

		public static string GetFieldName<TInstance, TProperty>(Expression<Func<TInstance, TProperty>> fieldAccess)
		{
			return null;
		}

		public static FieldInfo GetField(Type type, string fieldName)
		{
			return null;
		}

		public static TAttribute GetAttribute<TAttribute>(FieldInfo field) where TAttribute : Attribute
		{
			return null;
		}

		public static void ConstrainMin<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, float value)
		{
		}

		public static void ConstrainMin<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, int value)
		{
		}

		public static void ConstrainRange<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, float value)
		{
		}

		public static void ConstrainRange<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, int value)
		{
		}

		public static void ConstrainDefault<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, Func<bool> condition = null)
		{
		}

		public static void ConstrainDefault<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, string value)
		{
		}

		private static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
		{
			return null;
		}
	}
}
