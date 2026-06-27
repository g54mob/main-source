using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentAssertions.Common
{
	internal static class ExpressionExtensions
	{
		public static PropertyInfo GetPropertyInfo<T, TValue>(this Expression<Func<T, TValue>> expression)
		{
			Guard.ThrowIfArgumentIsNull(expression, "expression", "Expected a property expression, but found <null>.");
			return (AttemptToGetMemberInfoFromExpression(expression) as PropertyInfo) ?? throw new ArgumentException($"Cannot use <{expression.Body}> when a property expression is expected.", "expression");
		}

		private static MemberInfo AttemptToGetMemberInfoFromExpression<T, TValue>(Expression<Func<T, TValue>> expression)
		{
			return (((expression.Body as UnaryExpression)?.Operand ?? expression.Body) as MemberExpression)?.Member;
		}

		public static IEnumerable<MemberPath> GetMemberPaths<TDeclaringType, TPropertyType>(this Expression<Func<TDeclaringType, TPropertyType>> expression)
		{
			Guard.ThrowIfArgumentIsNull(expression, "expression", "Expected an expression, but found <null>.");
			string text = null;
			List<string> list = new List<string>();
			List<Type> list2 = new List<Type>();
			Expression expression2 = expression;
			while (expression2 != null)
			{
				switch (expression2.NodeType)
				{
				case ExpressionType.Lambda:
					expression2 = ((LambdaExpression)expression2).Body;
					break;
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
					expression2 = ((UnaryExpression)expression2).Operand;
					break;
				case ExpressionType.MemberAccess:
				{
					MemberExpression memberExpression = (MemberExpression)expression2;
					expression2 = memberExpression.Expression;
					text = memberExpression.Member.Name + "." + text;
					list2.Add(memberExpression.Member.DeclaringType);
					break;
				}
				case ExpressionType.ArrayIndex:
				{
					BinaryExpression obj = (BinaryExpression)expression2;
					ConstantExpression constantExpression2 = (ConstantExpression)obj.Right;
					expression2 = obj.Left;
					text = $"[{constantExpression2.Value}].{text}";
					break;
				}
				case ExpressionType.Parameter:
					expression2 = null;
					break;
				case ExpressionType.Call:
				{
					MethodCallExpression methodCallExpression = (MethodCallExpression)expression2;
					if (methodCallExpression != null)
					{
						MethodInfo method = methodCallExpression.Method;
						if ((object)method != null && method.Name == "get_Item")
						{
							ReadOnlyCollection<Expression> arguments = methodCallExpression.Arguments;
							if (arguments != null && arguments.Count == 1 && arguments[0] is ConstantExpression constantExpression)
							{
								expression2 = methodCallExpression.Object;
								text = $"[{constantExpression.Value}].{text}";
								break;
							}
						}
					}
					throw new ArgumentException(GetUnsupportedExpressionMessage(expression.Body), "expression");
				}
				case ExpressionType.New:
					foreach (Expression argument in ((NewExpression)expression2).Arguments)
					{
						string text2 = argument.ToString();
						string text3 = text2;
						int num = SystemExtensions.IndexOf(text2, '.', StringComparison.Ordinal);
						list.Add(text3.Substring(num, text3.Length - num));
						list2.Add(((MemberExpression)argument).Member.DeclaringType);
					}
					expression2 = null;
					break;
				default:
					throw new ArgumentException(GetUnsupportedExpressionMessage(expression.Body), "expression");
				}
			}
			Type declaringType = list2.FirstOrDefault() ?? typeof(TDeclaringType);
			if (text == null)
			{
				return list.Select((string selector) => GetNewInstance<TDeclaringType>(declaringType, selector)).ToList();
			}
			return new _003C_003Ez__ReadOnlySingleElementList<MemberPath>(GetNewInstance<TDeclaringType>(declaringType, text));
		}

		private static MemberPath GetNewInstance<TReflectedType>(Type declaringType, string dottedPath)
		{
			return new MemberPath(typeof(TReflectedType), declaringType, SystemExtensions.Replace(dottedPath.Trim(new char[1] { '.' }), ".[", "[", StringComparison.Ordinal));
		}

		public static MemberPath GetMemberPath<TDeclaringType, TPropertyType>(this Expression<Func<TDeclaringType, TPropertyType>> expression)
		{
			return expression.GetMemberPaths().FirstOrDefault() ?? new MemberPath("");
		}

		public static void ValidateMemberPath<TDeclaringType, TPropertyType>(this Expression<Func<TDeclaringType, TPropertyType>> expression)
		{
			Guard.ThrowIfArgumentIsNull(expression, "expression", "Expected an expression, but found <null>.");
			Expression expression2 = expression;
			while (expression2 != null)
			{
				switch (expression2.NodeType)
				{
				case ExpressionType.Lambda:
					expression2 = ((LambdaExpression)expression2).Body;
					break;
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
					expression2 = ((UnaryExpression)expression2).Operand;
					break;
				case ExpressionType.MemberAccess:
					expression2 = ((MemberExpression)expression2).Expression;
					break;
				case ExpressionType.ArrayIndex:
					expression2 = ((BinaryExpression)expression2).Left;
					break;
				case ExpressionType.Parameter:
					expression2 = null;
					break;
				case ExpressionType.Call:
				{
					MethodCallExpression methodCallExpression = (MethodCallExpression)expression2;
					if (methodCallExpression != null)
					{
						MethodInfo method = methodCallExpression.Method;
						if ((object)method != null && method.Name == "get_Item")
						{
							ReadOnlyCollection<Expression> arguments = methodCallExpression.Arguments;
							if (arguments != null && arguments.Count == 1 && arguments[0] is ConstantExpression)
							{
								expression2 = methodCallExpression.Object;
								break;
							}
						}
					}
					throw new ArgumentException(GetUnsupportedExpressionMessage(expression.Body), "expression");
				}
				default:
					throw new ArgumentException(GetUnsupportedExpressionMessage(expression.Body), "expression");
				}
			}
		}

		private static string GetUnsupportedExpressionMessage(Expression expression)
		{
			return $"Expression <{expression}> cannot be used to select a member.";
		}
	}
}
