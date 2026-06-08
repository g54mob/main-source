using System;
using System.Collections;
using System.Linq;

namespace Moq.Matchers
{
	internal class ConstantMatcher : IMatcher
	{
		private object constantValue;

		public ConstantMatcher(object constantValue)
		{
			this.constantValue = constantValue;
		}

		public bool Matches(object argument, Type parameterType)
		{
			if (object.Equals(argument, constantValue))
			{
				return true;
			}
			if (constantValue is IEnumerable && argument is IEnumerable enumerable && !(constantValue is IMocked) && !(argument is IMocked))
			{
				return MatchesEnumerable(enumerable);
			}
			return false;
		}

		public void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
		}

		private bool MatchesEnumerable(IEnumerable enumerable)
		{
			IEnumerable source = (IEnumerable)constantValue;
			return source.Cast<object>().SequenceEqual(enumerable.Cast<object>());
		}
	}
}
