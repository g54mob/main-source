using System;
using System.Linq.Expressions;

namespace Moq.Matchers
{
	internal class LazyEvalMatcher : IMatcher
	{
		private Expression expression;

		public LazyEvalMatcher(Expression expression)
		{
			this.expression = expression;
		}

		public bool Matches(object argument, Type parameterType)
		{
			Expression expression = Evaluator.PartialEval(this.expression);
			if (expression is ConstantExpression constantExpression)
			{
				return new ConstantMatcher(constantExpression.Value).Matches(argument, parameterType);
			}
			return false;
		}

		public void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
		}
	}
}
