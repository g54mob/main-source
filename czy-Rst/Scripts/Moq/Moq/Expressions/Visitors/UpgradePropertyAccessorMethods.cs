using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Moq.Expressions.Visitors
{
	internal sealed class UpgradePropertyAccessorMethods : ExpressionVisitor
	{
		public static readonly ExpressionVisitor Rewriter = new UpgradePropertyAccessorMethods();

		private UpgradePropertyAccessorMethods()
		{
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			Expression expression = ((node.Object != null) ? Visit(node.Object) : null);
			ReadOnlyCollection<Expression> readOnlyCollection = Visit(node.Arguments);
			if (node.Method.IsSpecialName)
			{
				if (node.Method.IsGetAccessor())
				{
					string name = node.Method.Name.Substring(4);
					if (node.Arguments.Count == 0)
					{
						PropertyInfo property = node.Method.DeclaringType.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						return Expression.MakeMemberAccess(expression, property);
					}
					ParameterTypes parameterTypes = node.Method.GetParameterTypes();
					Type[] types = parameterTypes.ToArray();
					PropertyInfo property2 = node.Method.DeclaringType.GetProperty(name, node.Method.ReturnType, types);
					return Expression.MakeIndex(expression, property2, readOnlyCollection);
				}
				if (node.Method.IsSetAccessor())
				{
					string name2 = node.Method.Name.Substring(4);
					int count = node.Arguments.Count;
					if (count == 1)
					{
						PropertyInfo property3 = node.Method.DeclaringType.GetProperty(name2, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						Expression right = node.Arguments[0];
						return Expression.Assign(Expression.MakeMemberAccess(expression, property3), right);
					}
					ParameterTypes parameterTypes2 = node.Method.GetParameterTypes();
					Type[] types2 = parameterTypes2.Take(parameterTypes2.Count - 1).ToArray();
					PropertyInfo property4 = node.Method.DeclaringType.GetProperty(name2, parameterTypes2.Last(), types2);
					IEnumerable<Expression> arguments = readOnlyCollection.Take(count - 1);
					Expression right2 = readOnlyCollection.Last();
					return Expression.Assign(Expression.MakeIndex(expression, property4, arguments), right2);
				}
			}
			if (expression == node.Object && readOnlyCollection == node.Arguments)
			{
				return node;
			}
			return Expression.Call(expression, node.Method, readOnlyCollection);
		}
	}
}
