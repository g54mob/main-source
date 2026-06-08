using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Moq.Properties;

namespace Moq.Linq
{
	internal class MockSetupsBuilder : ExpressionVisitor
	{
		private sealed class ReplaceMockObjectWithParameter : ExpressionVisitor
		{
			private Expression mockObject;

			private ParameterExpression mockObjectParameter;

			public Expression MockObject => mockObject;

			public ParameterExpression MockObjectParameter => mockObjectParameter;

			protected override Expression VisitMember(MemberExpression node)
			{
				if (node.Expression is ParameterExpression parameterExpression && parameterExpression.Type.IsDefined(typeof(CompilerGeneratedAttribute)) && parameterExpression.Type.Name.Contains("f__AnonymousType"))
				{
					mockObject = node;
					mockObjectParameter = Expression.Parameter(node.Type, parameterExpression.Name);
					return mockObjectParameter;
				}
				return base.VisitMember(node);
			}

			protected override Expression VisitParameter(ParameterExpression node)
			{
				mockObject = node;
				mockObjectParameter = Expression.Parameter(node.Type, node.Name);
				return mockObjectParameter;
			}

			protected override Expression VisitUnary(UnaryExpression node)
			{
				if (node.NodeType != ExpressionType.Quote)
				{
					return base.VisitUnary(node);
				}
				return node;
			}
		}

		private static readonly string[] queryableMethods = new string[3] { "First", "Where", "FirstOrDefault" };

		private static readonly string[] unsupportedMethods = new string[6] { "All", "Any", "Last", "LastOrDefault", "Single", "SingleOrDefault" };

		private int stackIndex;

		private int quoteDepth;

		protected override Expression VisitBinary(BinaryExpression node)
		{
			if (stackIndex > 0)
			{
				if (node.NodeType != ExpressionType.Equal && node.NodeType != ExpressionType.AndAlso)
				{
					throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.LinqBinaryOperatorNotSupported, node.ToStringFixed()));
				}
				if (node.NodeType == ExpressionType.Equal)
				{
					if (node.Left.NodeType == ExpressionType.Constant)
					{
						return ConvertToSetup(node.Right, node.Left) ?? base.VisitBinary(node);
					}
					return ConvertToSetup(node.Left, node.Right) ?? base.VisitBinary(node);
				}
			}
			return base.VisitBinary(node);
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			if (stackIndex > 0 && node.Type == typeof(bool))
			{
				return ConvertToSetupReturns(node, Expression.Constant(true));
			}
			return base.VisitMember(node);
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			if (node.Method.DeclaringType == typeof(Queryable) && queryableMethods.Contains<string>(node.Method.Name))
			{
				stackIndex++;
				Expression result = base.VisitMethodCall(node);
				stackIndex--;
				return result;
			}
			if (unsupportedMethods.Contains<string>(node.Method.Name))
			{
				throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.LinqMethodNotSupported, node.Method.Name));
			}
			if (stackIndex > 0 && node.Type == typeof(bool))
			{
				return ConvertToSetupReturns(node, Expression.Constant(true));
			}
			return base.VisitMethodCall(node);
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
			if (stackIndex > 0 && node.NodeType == ExpressionType.Not)
			{
				return ConvertToSetup(node.Operand, Expression.Constant(false)) ?? base.VisitUnary(node);
			}
			if (node.NodeType == ExpressionType.Quote)
			{
				quoteDepth++;
				Expression result = ((quoteDepth > 1) ? node : base.VisitUnary(node));
				quoteDepth--;
				return result;
			}
			return base.VisitUnary(node);
		}

		private static Expression ConvertToSetup(Expression left, Expression right)
		{
			switch (left.NodeType)
			{
			case ExpressionType.Call:
			case ExpressionType.Invoke:
			case ExpressionType.MemberAccess:
				return ConvertToSetupReturns(left, right);
			case ExpressionType.Convert:
			{
				UnaryExpression unaryExpression = (UnaryExpression)left;
				return ConvertToSetup(unaryExpression.Operand, Expression.Convert(right, unaryExpression.Operand.Type));
			}
			default:
				return null;
			}
		}

		private static Expression ConvertToSetupReturns(Expression left, Expression right)
		{
			ReplaceMockObjectWithParameter replaceMockObjectWithParameter = new ReplaceMockObjectWithParameter();
			Expression body = replaceMockObjectWithParameter.Visit(left);
			return Expression.Call(Mock.SetupReturnsMethod, Expression.Call(Mock.GetMethod.MakeGenericMethod(replaceMockObjectWithParameter.MockObject.Type), replaceMockObjectWithParameter.MockObject), Expression.Lambda(body, replaceMockObjectWithParameter.MockObjectParameter), Expression.Convert(right, typeof(object)));
		}
	}
}
