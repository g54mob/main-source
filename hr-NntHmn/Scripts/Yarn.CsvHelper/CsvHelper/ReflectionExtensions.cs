using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CsvHelper
{
	public static class ReflectionExtensions
	{
		public static Type MemberType(this MemberInfo member)
		{
			return null;
		}

		public static MemberExpression GetMemberExpression(this MemberInfo member, Expression expression)
		{
			return null;
		}

		public static bool IsAnonymous(this Type type)
		{
			return false;
		}

		public static bool HasParameterlessConstructor(this Type type)
		{
			return false;
		}

		public static bool HasConstructor(this Type type)
		{
			return false;
		}

		public static ConstructorInfo GetConstructorWithMostParameters(this Type type)
		{
			return null;
		}

		public static bool IsUserDefinedStruct(this Type type)
		{
			return false;
		}
	}
}
