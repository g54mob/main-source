using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FluentAssertions.Common
{
	internal static class MethodInfoExtensions
	{
		private static readonly Lazy<int> ImplementationOptionsMask = new Lazy<int>(() => Enum.GetValues(typeof(MethodImplOptions)).Cast<int>().Sum((int x) => x));

		internal static bool IsAsync(this MethodInfo methodInfo)
		{
			return methodInfo.IsDecoratedWith<AsyncStateMachineAttribute>();
		}

		internal static IEnumerable<TAttribute> GetMatchingAttributes<TAttribute>(this MemberInfo memberInfo, Expression<Func<TAttribute, bool>> isMatchingAttributePredicate) where TAttribute : Attribute
		{
			List<TAttribute> list = memberInfo.GetCustomAttributes<TAttribute>().ToList();
			if (typeof(TAttribute) == typeof(MethodImplAttribute) && memberInfo is MethodBase methodBase)
			{
				var (flag, methodImplAttribute) = RecreateMethodImplAttribute(methodBase);
				if (flag)
				{
					list.Add(methodImplAttribute as TAttribute);
				}
			}
			return list.Where(isMatchingAttributePredicate.Compile());
		}

		internal static bool IsNonVirtual(this MethodInfo method)
		{
			if (method.IsVirtual)
			{
				return method.IsFinal;
			}
			return true;
		}

		private static (bool success, MethodImplAttribute attribute) RecreateMethodImplAttribute(MethodBase methodBase)
		{
			MethodImplOptions methodImplOptions = (MethodImplOptions)((int)methodBase.MethodImplementationFlags & ImplementationOptionsMask.Value);
			if (methodImplOptions != 0)
			{
				return (success: true, attribute: new MethodImplAttribute(methodImplOptions));
			}
			return (success: false, attribute: null);
		}
	}
}
