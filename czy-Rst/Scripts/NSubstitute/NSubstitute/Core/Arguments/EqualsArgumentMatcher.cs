using System.Collections.Generic;

namespace NSubstitute.Core.Arguments
{
	public class EqualsArgumentMatcher : IArgumentMatcher
	{
		public EqualsArgumentMatcher(object? value)
		{
			_003Cvalue_003EP = value;
			base._002Ector();
		}

		public override string ToString()
		{
			return ArgumentFormatter.Default.Format(_003Cvalue_003EP, highlight: false);
		}

		public bool IsSatisfiedBy(object? argument)
		{
			return EqualityComparer<object>.Default.Equals(_003Cvalue_003EP, argument);
		}
	}
}
