using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace CsvHelper
{
	internal static class ReflectionHelper
	{
		private static readonly Dictionary<int, Dictionary<int, Delegate>> funcArgCache;

		private static object locker;

		public static T CreateInstance<T>(params object[] args)
		{
			return default(T);
		}

		public static object CreateInstance(Type type, params object[] args)
		{
			return null;
		}

		public static object CreateInstanceWithoutContractResolver(Type type, params object[] args)
		{
			return null;
		}

		public static PropertyInfo GetDeclaringProperty(Type type, PropertyInfo property, BindingFlags flags)
		{
			return null;
		}

		public static List<PropertyInfo> GetUniqueProperties(Type type, BindingFlags flags, bool overwrite = false)
		{
			return null;
		}

		public static MemberInfo GetMember<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			return null;
		}

		public static Stack<MemberInfo> GetMembers<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			return null;
		}

		private static MemberExpression GetMemberExpression(Expression expression)
		{
			return null;
		}

		private static T Default<T>()
		{
			return default(T);
		}

		private static Delegate CreateInstanceDelegate(Type type, params object[] args)
		{
			return null;
		}
	}
}
