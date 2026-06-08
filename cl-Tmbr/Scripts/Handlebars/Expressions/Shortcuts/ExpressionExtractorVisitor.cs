using System;
using System.Linq.Expressions;

namespace Expressions.Shortcuts
{
	internal class ExpressionExtractorVisitor : ExpressionVisitor
	{
		public override Expression Visit(Expression node)
		{
			if (node is LambdaExpression lambdaExpression)
			{
				return ExpressionUtils.ProcessCall(lambdaExpression.Body);
			}
			return base.Visit(node);
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			return ConvertToExpression(Expression.Lambda(node).Compile().DynamicInvoke(), Visit) ?? Expression.Empty();
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			if (node.Expression is ConstantExpression { Value: var value })
			{
				object obj = value.GetType().GetField(node.Member.Name)?.GetValue(value);
				if (obj is ExpressionContainer)
				{
					return ConvertToExpression(obj, Visit) ?? Expression.Empty();
				}
				if (obj?.GetType() == node.Type)
				{
					return ConvertToExpression(obj, Visit) ?? Expression.Empty();
				}
				return Visit(Expression.Convert(Expression.Constant(obj), node.Type)) ?? Expression.Empty();
			}
			return base.VisitMember(node);
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
			ExpressionType nodeType = node.NodeType;
			if ((uint)(nodeType - 10) <= 1u)
			{
				if (!typeof(ExpressionContainer).IsAssignableFrom(node.Operand.Type))
				{
					if (!(node.Type == node.Operand.Type))
					{
						return node;
					}
					return node.Update(ConvertToExpression(node.Operand, Visit) ?? Expression.Empty());
				}
				Expression expression = ConvertToExpression(node.Operand, Visit) ?? Expression.Empty();
				if (expression.Type == typeof(void))
				{
					return expression;
				}
				if (typeof(ExpressionContainer).IsAssignableFrom(node.Type))
				{
					return expression;
				}
				if (!(expression.Type != node.Type))
				{
					return expression;
				}
				return Expression.Convert(expression, node.Type);
			}
			return node.Update(ConvertToExpression(node.Operand, Visit) ?? Expression.Empty());
		}

		private static Expression ConvertToExpression(object value, Func<Expression, Expression> visit = null)
		{
			if (value is ExpressionContainer expressionContainer)
			{
				return expressionContainer.Expression;
			}
			if (value is Expression arg)
			{
				return visit?.Invoke(arg);
			}
			return Expression.Constant(value);
		}
	}
}
