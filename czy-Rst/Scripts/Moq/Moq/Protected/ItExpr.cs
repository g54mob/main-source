using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Moq.Protected
{
	public static class ItExpr
	{
		public static class Ref<TValue>
		{
			public static Expression IsAny
			{
				get
				{
					Expression<Func<TValue>> expression = () => It.Ref<TValue>.IsAny;
					return expression.Body;
				}
			}
		}

		public static Expression IsNull<TValue>()
		{
			Expression<Func<TValue>> expression = () => It.Is((TValue v) => object.Equals(v, default(TValue)));
			return expression.Body;
		}

		public static Expression IsAny<TValue>()
		{
			Expression<Func<TValue>> expression = () => It.IsAny<TValue>();
			return expression.Body;
		}

		public static Expression Is<TValue>(Expression<Func<TValue, bool>> match)
		{
			Expression<Func<TValue>> expression = () => It.Is((Expression<Func<TValue, bool>>)null);
			return Expression.Call(((MethodCallExpression)expression.Body).Method, match);
		}

		public static Expression IsInRange<TValue>(TValue from, TValue to, Range rangeKind) where TValue : IComparable
		{
			Expression<Func<TValue>> expression = () => It.IsInRange(from, to, rangeKind);
			return expression.Body;
		}

		public static Expression IsRegex(string regex)
		{
			Expression<Func<string>> expression = () => It.IsRegex(regex);
			return expression.Body;
		}

		public static Expression IsRegex(string regex, RegexOptions options)
		{
			Expression<Func<string>> expression = () => It.IsRegex(regex, options);
			return expression.Body;
		}
	}
}
