using System.Collections.Generic;

namespace NSubstitute.Core.Arguments
{
	public class EqualsArgumentMatcher : IArgumentMatcher
	{
		private readonly object? _value;

		public EqualsArgumentMatcher(object? value)
		{
			_value = value;
		}

		public override string ToString()
		{
			return ArgumentFormatter.Default.Format(_value, highlight: false);
		}

		public bool IsSatisfiedBy(object? argument)
		{
			return EqualityComparer<object>.Default.Equals(_value, argument);
		}
	}
}
