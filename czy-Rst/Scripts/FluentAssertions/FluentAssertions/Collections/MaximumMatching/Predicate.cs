using System;
using System.Linq.Expressions;
using FluentAssertions.Formatting;

namespace FluentAssertions.Collections.MaximumMatching
{
	internal class Predicate<TValue>
	{
		private readonly Func<TValue, bool> compiledExpression;

		public int Index { get; }

		public Expression<Func<TValue, bool>> Expression { get; }

		public Predicate(Expression<Func<TValue, bool>> expression, int index)
		{
			Index = index;
			Expression = expression;
			compiledExpression = expression.Compile();
		}

		public bool Matches(TValue element)
		{
			return compiledExpression(element);
		}

		public override string ToString()
		{
			return $"Index: {Index}, Expression: {Formatter.ToString(Expression)}";
		}
	}
}
