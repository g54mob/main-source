using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Utf8Json.Internal.Emit
{
	internal static class ExpressionUtility
	{
		private static MethodInfo GetMethodInfoCore(LambdaExpression expression)
		{
			return null;
		}

		public static MethodInfo GetMethodInfo<T>(Expression<Func<T>> expression)
		{
			return null;
		}

		public static MethodInfo GetMethodInfo(Expression<Action> expression)
		{
			return null;
		}

		public static MethodInfo GetMethodInfo<T, TR>(Expression<Func<T, TR>> expression)
		{
			return null;
		}

		public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
		{
			return null;
		}

		public static MethodInfo GetMethodInfo<TArg1, TArg2>(Expression<Action<TArg1, TArg2>> expression)
		{
			return null;
		}

		public static MethodInfo GetMethodInfo<T, TArg1, TR>(Expression<Func<T, TArg1, TR>> expression)
		{
			return null;
		}

		private static MemberInfo GetMemberInfoCore<T>(Expression<T> source)
		{
			return null;
		}

		public static PropertyInfo GetPropertyInfo<T, TR>(Expression<Func<T, TR>> expression)
		{
			return null;
		}

		public static FieldInfo GetFieldInfo<T, TR>(Expression<Func<T, TR>> expression)
		{
			return null;
		}
	}
}
