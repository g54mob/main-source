using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Expressions.Shortcuts;

namespace HandlebarsDotNet.Compiler.Middlewares
{
	internal class ClosureExpressionMiddleware : IExpressionMiddleware
	{
		private class ClosureVisitor : ExpressionVisitor
		{
			private readonly Dictionary<Expression, Expression> _expressions;

			public ClosureVisitor(KeyValuePair<ParameterExpression, Dictionary<Expression, Expression>> closureDefinition)
			{
				_expressions = closureDefinition.Value;
			}

			protected override Expression VisitConstant(ConstantExpression node)
			{
				object value = node.Value;
				if (value == null || value is string)
				{
					return node;
				}
				if (node.Type.GetTypeInfo().IsValueType)
				{
					return node;
				}
				if (_expressions.TryGetValue(node, out var value2))
				{
					if (node.Type != value2.Type)
					{
						return Expression.Convert(value2, node.Type);
					}
					return value2;
				}
				return base.VisitConstant(node);
			}
		}

		private class ClosureCollectorVisitor : ExpressionVisitor
		{
			private readonly List<ConstantExpression> _expressions;

			public ClosureCollectorVisitor(List<ConstantExpression> expressions)
			{
				_expressions = expressions;
			}

			protected override Expression VisitLambda<T>(Expression<T> node)
			{
				Expression expression = Visit(node.Body);
				if (expression == null)
				{
					throw new InvalidOperationException("Cannot create closure");
				}
				return node.Update(expression, node.Parameters);
			}

			protected override Expression VisitConstant(ConstantExpression node)
			{
				object value = node.Value;
				if (value == null || value is string)
				{
					return node;
				}
				if (node.Type.GetTypeInfo().IsValueType)
				{
					return node;
				}
				_expressions.Add(node);
				return node;
			}

			protected override Expression VisitMember(MemberExpression node)
			{
				if (!(node.Expression is ConstantExpression constantExpression))
				{
					return base.VisitMember(node);
				}
				MemberInfo member = node.Member;
				if (!(member is PropertyInfo propertyInfo))
				{
					if (member is FieldInfo fieldInfo)
					{
						object value = fieldInfo.GetValue(constantExpression.Value);
						return VisitConstant(Expression.Constant(value, fieldInfo.FieldType));
					}
					Expression expression = VisitConstant(constantExpression);
					return node.Update(expression);
				}
				object value2 = propertyInfo.GetValue(constantExpression.Value);
				return VisitConstant(Expression.Constant(value2, propertyInfo.PropertyType));
			}
		}

		public Expression<T> Invoke<T>(Expression<T> expression) where T : Delegate
		{
			List<ConstantExpression> list = new List<ConstantExpression>();
			expression = (Expression<T>)new ClosureCollectorVisitor(list).Visit(expression);
			if (list.Count == 0)
			{
				return expression;
			}
			KeyValuePair<ParameterExpression, Dictionary<Expression, Expression>> closureDefinition;
			Closure closure;
			using (ClosureBuilder closureBuilder = ClosureBuilder.Create())
			{
				for (int i = 0; i < list.Count; i++)
				{
					ConstantExpression constantExpression = list[i];
					closureBuilder.Add(constantExpression);
				}
				closureDefinition = closureBuilder.Build(out closure);
			}
			expression = (Expression<T>)new ClosureVisitor(closureDefinition).Visit(expression);
			BlockBuilder blockBuilder = ExpressionShortcuts.Block().Parameter(closureDefinition.Key).Line(Expression.Assign(closureDefinition.Key, ExpressionShortcuts.Arg(closure)));
			if (expression.Body is BlockExpression { Variables: var variables } blockExpression)
			{
				for (int j = 0; j < blockExpression.Variables.Count; j++)
				{
					blockBuilder.Parameter(variables[j]);
				}
				blockBuilder.Lines(blockExpression.Expressions);
			}
			else
			{
				blockBuilder.Line(expression.Body);
			}
			return blockBuilder.Lambda<T>(expression.Parameters);
		}
	}
}
