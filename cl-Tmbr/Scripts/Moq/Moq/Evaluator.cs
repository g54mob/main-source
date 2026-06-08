using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Moq
{
	internal static class Evaluator
	{
		private class SubtreeEvaluator : ExpressionVisitor
		{
			private HashSet<Expression> candidates;

			internal SubtreeEvaluator(HashSet<Expression> candidates)
			{
				this.candidates = candidates;
			}

			internal Expression Eval(Expression exp)
			{
				return Visit(exp);
			}

			public override Expression Visit(Expression exp)
			{
				if (exp == null)
				{
					return null;
				}
				if (candidates.Contains(exp))
				{
					return Evaluate(exp);
				}
				return base.Visit(exp);
			}

			private static Expression Evaluate(Expression e)
			{
				if (e.NodeType == ExpressionType.Constant)
				{
					return e;
				}
				LambdaExpression expression = Expression.Lambda(e);
				Delegate obj = expression.CompileUsingExpressionCompiler();
				return Expression.Constant(obj.DynamicInvoke(null), e.Type);
			}
		}

		private class Nominator : ExpressionVisitor
		{
			private Func<Expression, bool> fnCanBeEvaluated;

			private HashSet<Expression> candidates;

			private bool cannotBeEvaluated;

			internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
			{
				this.fnCanBeEvaluated = fnCanBeEvaluated;
			}

			internal HashSet<Expression> Nominate(Expression expression)
			{
				candidates = new HashSet<Expression>();
				Visit(expression);
				return candidates;
			}

			public override Expression Visit(Expression expression)
			{
				if (expression != null && expression.NodeType != ExpressionType.Quote)
				{
					bool flag = cannotBeEvaluated;
					cannotBeEvaluated = false;
					base.Visit(expression);
					if (!cannotBeEvaluated)
					{
						bool flag2;
						try
						{
							flag2 = fnCanBeEvaluated(expression);
						}
						catch
						{
							flag2 = false;
						}
						if (flag2)
						{
							candidates.Add(expression);
						}
						else
						{
							cannotBeEvaluated = true;
						}
					}
					cannotBeEvaluated |= flag;
				}
				return expression;
			}
		}

		public static Expression PartialEval(Expression expression, Func<Expression, bool> fnCanBeEvaluated)
		{
			return new SubtreeEvaluator(new Nominator(fnCanBeEvaluated).Nominate(expression)).Eval(expression);
		}

		public static Expression PartialEval(Expression expression)
		{
			return PartialEval(expression, (Expression e) => e.NodeType != ExpressionType.Parameter && !(e is MatchExpression));
		}
	}
}
