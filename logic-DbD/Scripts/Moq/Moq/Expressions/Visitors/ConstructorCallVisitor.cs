using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Properties;

namespace Moq.Expressions.Visitors
{
	internal class ConstructorCallVisitor : ExpressionVisitor
	{
		private ConstructorInfo constructor;

		private object[] arguments;

		public static object[] ExtractArgumentValues(LambdaExpression newExpression)
		{
			if (newExpression == null)
			{
				throw new ArgumentNullException("newExpression");
			}
			ConstructorCallVisitor constructorCallVisitor = new ConstructorCallVisitor();
			constructorCallVisitor.Visit(newExpression);
			if (constructorCallVisitor.constructor == null)
			{
				throw new NotSupportedException(Resources.NoConstructorCallFound);
			}
			return constructorCallVisitor.arguments;
		}

		public override Expression Visit(Expression node)
		{
			ExpressionType nodeType = node.NodeType;
			if (nodeType == ExpressionType.Lambda || nodeType == ExpressionType.New || nodeType == ExpressionType.Quote)
			{
				return base.Visit(node);
			}
			throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpression, node.ToStringFixed()));
		}

		protected override Expression VisitNew(NewExpression node)
		{
			if (node != null)
			{
				constructor = node.Constructor;
				Expression<Func<object[]>> expression = Expression.Lambda<Func<object[]>>(Expression.NewArrayInit(typeof(object), node.Arguments.Select((Expression a) => Expression.Convert(a, typeof(object)))), Array.Empty<ParameterExpression>());
				arguments = ExpressionCompiler.Instance.Compile(expression)();
			}
			return node;
		}
	}
}
