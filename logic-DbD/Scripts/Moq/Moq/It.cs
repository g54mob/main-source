using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Moq.Properties;

namespace Moq
{
	public static class It
	{
		public static class Ref<TValue>
		{
			public static TValue IsAny;
		}

		[TypeMatcher]
		public sealed class IsAnyType : ITypeMatcher
		{
			bool ITypeMatcher.Matches(Type type)
			{
				return true;
			}
		}

		[TypeMatcher]
		public sealed class IsSubtype<T> : ITypeMatcher
		{
			bool ITypeMatcher.Matches(Type type)
			{
				return typeof(T).IsAssignableFrom(type);
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		[TypeMatcher]
		public readonly struct IsValueType : ITypeMatcher
		{
			bool ITypeMatcher.Matches(Type type)
			{
				return type.IsValueType;
			}
		}

		private static readonly MethodInfo isAnyMethod = typeof(It).GetMethod("IsAny", BindingFlags.Static | BindingFlags.Public);

		public static TValue IsAny<TValue>()
		{
			if (typeof(TValue).IsOrContainsTypeMatcher())
			{
				return Match.Create((object argument, Type parameterType) => argument == null || parameterType.IsAssignableFrom(argument.GetType()), () => IsAny<TValue>());
			}
			return Match.Create((TValue argument) => argument == null || argument != null, () => IsAny<TValue>());
		}

		internal static MethodCallExpression IsAny(Type genericArgument)
		{
			return Expression.Call(isAnyMethod.MakeGenericMethod(genericArgument));
		}

		public static TValue IsNotNull<TValue>()
		{
			if (typeof(TValue).IsOrContainsTypeMatcher())
			{
				return Match.Create((object argument, Type parameterType) => argument != null && parameterType.IsAssignableFrom(argument.GetType()), () => IsNotNull<TValue>());
			}
			return Match.Create((TValue argument) => argument != null, () => IsNotNull<TValue>());
		}

		public static TValue Is<TValue>(Expression<Func<TValue, bool>> match)
		{
			if (typeof(TValue).IsOrContainsTypeMatcher())
			{
				throw new ArgumentException(Resources.UseItIsOtherOverload, "match");
			}
			MethodInfo methodInfo = (MethodInfo)MethodBase.GetCurrentMethod();
			return Match.Create((TValue argument) => match.CompileUsingExpressionCompiler()(argument), Expression.Lambda<Func<TValue>>(Expression.Call(methodInfo.MakeGenericMethod(typeof(TValue)), match), Array.Empty<ParameterExpression>()));
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static TValue Is<TValue>(Expression<Func<object, Type, bool>> match)
		{
			MethodInfo methodInfo = (MethodInfo)MethodBase.GetCurrentMethod();
			return Match.Create((object argument, Type parameterType) => match.CompileUsingExpressionCompiler()(argument, parameterType), Expression.Lambda<Func<TValue>>(Expression.Call(methodInfo.MakeGenericMethod(typeof(TValue)), match), Array.Empty<ParameterExpression>()));
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static TValue Is<TValue>(TValue value, IEqualityComparer<TValue> comparer)
		{
			return Match.Create((TValue actual) => comparer.Equals(actual, value), () => Is(value, comparer));
		}

		public static TValue IsInRange<TValue>(TValue from, TValue to, Range rangeKind) where TValue : IComparable
		{
			return Match.Create(delegate(TValue value)
			{
				if (value == null)
				{
					return false;
				}
				if (rangeKind == Range.Exclusive)
				{
					object obj = from;
					if (value.CompareTo(obj) > 0)
					{
						object obj2 = to;
						return value.CompareTo(obj2) < 0;
					}
					return false;
				}
				object obj3 = from;
				if (value.CompareTo(obj3) >= 0)
				{
					object obj4 = to;
					return value.CompareTo(obj4) <= 0;
				}
				return false;
			}, () => IsInRange(from, to, rangeKind));
		}

		public static TValue IsIn<TValue>(IEnumerable<TValue> items)
		{
			return Match.Create((TValue value) => items.Contains(value), () => IsIn(items));
		}

		public static TValue IsIn<TValue>(IEnumerable<TValue> items, IEqualityComparer<TValue> comparer)
		{
			return Match.Create((TValue value) => items.Contains(value, comparer), () => IsIn(items, comparer));
		}

		public static TValue IsIn<TValue>(params TValue[] items)
		{
			return Match.Create((TValue value) => items.Contains<TValue>(value), () => IsIn(items));
		}

		public static TValue IsNotIn<TValue>(IEnumerable<TValue> items)
		{
			return Match.Create((TValue value) => !items.Contains(value), () => IsNotIn(items));
		}

		public static TValue IsNotIn<TValue>(IEnumerable<TValue> items, IEqualityComparer<TValue> comparer)
		{
			return Match.Create((TValue value) => !items.Contains(value, comparer), () => IsNotIn(items, comparer));
		}

		public static TValue IsNotIn<TValue>(params TValue[] items)
		{
			return Match.Create((TValue value) => !items.Contains<TValue>(value), () => IsNotIn(items));
		}

		public static string IsRegex(string regex)
		{
			Guard.NotNull(regex, "regex");
			Regex re = new Regex(regex);
			return Match.Create((string value) => value != null && re.IsMatch(value), () => IsRegex(regex));
		}

		public static string IsRegex(string regex, RegexOptions options)
		{
			Guard.NotNull(regex, "regex");
			Regex re = new Regex(regex, options);
			return Match.Create((string value) => value != null && re.IsMatch(value), () => IsRegex(regex, options));
		}
	}
}
