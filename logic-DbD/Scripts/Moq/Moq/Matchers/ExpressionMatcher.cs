using System;
using System.Linq.Expressions;

namespace Moq.Matchers
{
	internal class ExpressionMatcher : IMatcher
	{
		private Expression expression;

		public ExpressionMatcher(Expression expression)
		{
			this.expression = expression;
		}

		public bool Matches(object argument, Type parameterType)
		{
			if (argument is Expression y)
			{
				return ExpressionComparer.Default.Equals(expression, y);
			}
			return false;
		}

		public void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
		}
	}
}
