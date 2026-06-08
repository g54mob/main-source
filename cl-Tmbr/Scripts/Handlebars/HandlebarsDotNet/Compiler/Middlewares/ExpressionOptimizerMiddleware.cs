using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.Compiler.Middlewares
{
	internal class ExpressionOptimizerMiddleware : IExpressionMiddleware
	{
		private class OptimizationVisitor : ExpressionVisitor, IDisposable
		{
			private readonly Dictionary<object, ConstantExpression> _constantExpressions = new Dictionary<object, ConstantExpression>();

			protected override Expression VisitBlock(BlockExpression node)
			{
				if (node.Variables.Count == 0 && node.Expressions.Count == 1 && node.Expressions[0] is BlockExpression node2)
				{
					return VisitBlock(node2);
				}
				return base.VisitBlock(node);
			}

			protected override Expression VisitUnary(UnaryExpression node)
			{
				if (node.NodeType == ExpressionType.Convert && node.Operand.Type == node.Type)
				{
					return node.Operand;
				}
				return base.VisitUnary(node);
			}

			protected override Expression VisitConstant(ConstantExpression node)
			{
				if (node.Value != null && _constantExpressions.TryGetValue(node.Value, out var value))
				{
					return value;
				}
				if (node.Value != null)
				{
					_constantExpressions.Add(node.Value, node);
				}
				return node;
			}

			public void Dispose()
			{
				_constantExpressions.Clear();
			}
		}

		public Expression<T> Invoke<T>(Expression<T> expression) where T : Delegate
		{
			DisposableContainer<OptimizationVisitor, InternalObjectPool<OptimizationVisitor, GenericObjectPool<OptimizationVisitor>.Policy>> disposableContainer = GenericObjectPool<OptimizationVisitor>.Shared.Use();
			try
			{
				using OptimizationVisitor optimizationVisitor = disposableContainer.Value;
				return (Expression<T>)optimizationVisitor.Visit(expression);
			}
			finally
			{
				((IDisposable)disposableContainer/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
