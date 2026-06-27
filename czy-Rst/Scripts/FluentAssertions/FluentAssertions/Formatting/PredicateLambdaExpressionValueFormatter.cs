using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentAssertions.Formatting
{
	public class PredicateLambdaExpressionValueFormatter : IValueFormatter
	{
		private sealed class ParameterDetector : ExpressionVisitor
		{
			public bool HasParameters { get; private set; }

			public override Expression Visit(Expression node)
			{
				if (!HasParameters)
				{
					return base.Visit(node);
				}
				return node;
			}

			protected override Expression VisitParameter(ParameterExpression node)
			{
				HasParameters = true;
				return node;
			}
		}

		private sealed class ConstantSubExpressionReductionVisitor : ExpressionVisitor
		{
			public override Expression Visit(Expression node)
			{
				if (node == null)
				{
					return null;
				}
				if (node is ConstantExpression)
				{
					return node;
				}
				if (!HasLiftedOperator(node) && ExpressionIsConstant(node))
				{
					return Expression.Constant(Expression.Lambda(node).Compile().DynamicInvoke());
				}
				return base.Visit(node);
			}

			private static bool HasLiftedOperator(Expression expression)
			{
				if (expression is BinaryExpression binaryExpression)
				{
					if (binaryExpression.IsLifted)
					{
						goto IL_0026;
					}
				}
				else if (expression is UnaryExpression { IsLifted: not false })
				{
					goto IL_0026;
				}
				return false;
				IL_0026:
				return true;
			}

			private static bool ExpressionIsConstant(Expression expression)
			{
				if ((expression is NewExpression || expression is MemberInitExpression) ? true : false)
				{
					return false;
				}
				ParameterDetector parameterDetector = new ParameterDetector();
				parameterDetector.Visit(expression);
				return !parameterDetector.HasParameters;
			}
		}

		private sealed class AndOperatorChainExtractor : ExpressionVisitor
		{
			public List<Expression> AndChain { get; } = new List<Expression>();

			public override Expression Visit(Expression node)
			{
				if (node.NodeType == ExpressionType.AndAlso)
				{
					BinaryExpression binaryExpression = (BinaryExpression)node;
					Visit(binaryExpression.Left);
					Visit(binaryExpression.Right);
				}
				else
				{
					AndChain.Add(node);
				}
				return null;
			}
		}

		public bool CanHandle(object value)
		{
			return value is LambdaExpression;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			Expression expression = ReduceConstantSubExpressions(((LambdaExpression)value).Body);
			if (expression is BinaryExpression binaryExpression && expression.NodeType == ExpressionType.AndAlso)
			{
				List<Expression> source = ExtractChainOfExpressionsJoinedWithAndOperator(binaryExpression);
				formattedGraph.AddFragment(string.Join(" AndAlso ", source.Select((Expression e) => e.ToString())));
			}
			else
			{
				formattedGraph.AddFragment(expression.ToString());
			}
		}

		private static Expression ReduceConstantSubExpressions(Expression expression)
		{
			try
			{
				return new ConstantSubExpressionReductionVisitor().Visit(expression);
			}
			catch (InvalidOperationException)
			{
				return expression;
			}
		}

		private static List<Expression> ExtractChainOfExpressionsJoinedWithAndOperator(BinaryExpression binaryExpression)
		{
			AndOperatorChainExtractor andOperatorChainExtractor = new AndOperatorChainExtractor();
			andOperatorChainExtractor.Visit(binaryExpression);
			return andOperatorChainExtractor.AndChain;
		}
	}
}
