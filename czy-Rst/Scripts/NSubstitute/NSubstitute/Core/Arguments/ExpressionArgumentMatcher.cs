using System;
using System.Linq.Expressions;

namespace NSubstitute.Core.Arguments
{
	public class ExpressionArgumentMatcher<T> : IArgumentMatcher
	{
		private readonly string _predicateDescription;

		private readonly Predicate<T?> _predicate;

		public ExpressionArgumentMatcher(Expression<Predicate<T?>> predicate)
		{
			_predicateDescription = predicate.ToString();
			_predicate = predicate.Compile();
			base._002Ector();
		}

		public bool IsSatisfiedBy(object? argument)
		{
			return _predicate((T)argument);
		}

		public override string ToString()
		{
			return _predicateDescription;
		}
	}
}
