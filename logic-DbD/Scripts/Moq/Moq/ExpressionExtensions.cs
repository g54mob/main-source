using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Moq.Async;
using Moq.Properties;
using Moq.Protected;

namespace Moq
{
	internal static class ExpressionExtensions
	{
		internal static Expression ConvertIfNeeded(this Expression expression, Type type)
		{
			if (expression.Type == type)
			{
				return expression;
			}
			if (!expression.Type.IsValueType && !type.IsValueType && type.IsAssignableFrom(expression.Type))
			{
				return expression;
			}
			return Expression.Convert(expression, type);
		}

		internal static Delegate CompileUsingExpressionCompiler(this LambdaExpression expression)
		{
			return ExpressionCompiler.Instance.Compile(expression);
		}

		internal static TDelegate CompileUsingExpressionCompiler<TDelegate>(this Expression<TDelegate> expression) where TDelegate : Delegate
		{
			return ExpressionCompiler.Instance.Compile(expression);
		}

		public static bool IsMatch(this Expression expression, out Match match)
		{
			if (expression is MatchExpression matchExpression)
			{
				match = matchExpression.Match;
				return true;
			}
			using MatcherObserver matcherObserver = MatcherObserver.Activate();
			Expression.Lambda<Action>(expression, Array.Empty<ParameterExpression>()).CompileUsingExpressionCompiler()();
			return matcherObserver.TryGetLastMatch(out match);
		}

		public static bool CanSplit(this Expression e)
		{
			switch (e.NodeType)
			{
			case ExpressionType.Assign:
			case ExpressionType.AddAssign:
			case ExpressionType.SubtractAssign:
			{
				BinaryExpression binaryExpression = (BinaryExpression)e;
				return binaryExpression.Left.CanSplit();
			}
			case ExpressionType.Call:
			case ExpressionType.Index:
				return true;
			case ExpressionType.Invoke:
			{
				InvocationExpression invocationExpression = (InvocationExpression)e;
				return typeof(Delegate).IsAssignableFrom(invocationExpression.Expression.Type);
			}
			case ExpressionType.MemberAccess:
			{
				MemberExpression memberExpression = (MemberExpression)e;
				return memberExpression.Member is PropertyInfo;
			}
			default:
				return false;
			}
		}

		internal static Stack<MethodExpectation> Split(this LambdaExpression expression, bool allowNonOverridableLastProperty = false)
		{
			Stack<MethodExpectation> stack = new Stack<MethodExpectation>();
			Expression r = expression.Body;
			while (r.CanSplit())
			{
				Split(r, out r, out var p, assignment: false, allowNonOverridableLastProperty && stack.Count == 0);
				stack.Push(p);
			}
			if (stack.Count > 0 && r is ParameterExpression)
			{
				return stack;
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpression, r.ToStringFixed()));
			static bool IsResult(MemberInfo member, out IAwaitableFactory awaitableFactory)
			{
				Type declaringType = member.DeclaringType;
				awaitableFactory = AwaitableFactory.TryGet(declaringType);
				Type type = ((!(member is PropertyInfo propertyInfo)) ? null : propertyInfo.PropertyType);
				Type objA = type;
				if (awaitableFactory != null)
				{
					return object.Equals(objA, awaitableFactory.ResultType);
				}
				return false;
			}
			static void Split(Expression e, out Expression reference, out MethodExpectation reference2, bool assignment = false, bool allowNonOverridable = false)
			{
				switch (e.NodeType)
				{
				case ExpressionType.Assign:
				case ExpressionType.AddAssign:
				case ExpressionType.SubtractAssign:
				{
					BinaryExpression binaryExpression = (BinaryExpression)e;
					Split(binaryExpression.Left, out reference, out var p2, assignment: true);
					ParameterExpression parameterExpression3 = Expression.Parameter(reference.Type, (reference is ParameterExpression parameterExpression4) ? parameterExpression4.Name : "...");
					Expression[] array = new Expression[p2.Method.GetParameters().Length];
					for (int num = 0; num < array.Length - 1; num++)
					{
						array[num] = p2.Arguments[num];
					}
					array[^1] = binaryExpression.Right;
					reference2 = new MethodExpectation(Expression.Lambda(Expression.MakeBinary(e.NodeType, p2.Expression.Body, binaryExpression.Right), parameterExpression3), p2.Method, array);
					break;
				}
				case ExpressionType.Call:
				{
					MethodCallExpression methodCallExpression = (MethodCallExpression)e;
					if (methodCallExpression.Method.IsGenericMethod)
					{
						Type[] genericArguments = methodCallExpression.Method.GetGenericArguments();
						foreach (Type type in genericArguments)
						{
							if (type.IsOrContainsTypeMatcher())
							{
								type.SubstituteTypeMatchers(type);
							}
						}
					}
					if (!methodCallExpression.Method.IsStatic)
					{
						reference = methodCallExpression.Object;
						ParameterExpression parameterExpression9 = Expression.Parameter(reference.Type, (reference is ParameterExpression parameterExpression10) ? parameterExpression10.Name : "...");
						MethodInfo method3 = methodCallExpression.Method;
						ReadOnlyCollection<Expression> arguments3 = methodCallExpression.Arguments;
						reference2 = new MethodExpectation(Expression.Lambda(Expression.Call(parameterExpression9, method3, arguments3), parameterExpression9), method3, arguments3);
					}
					else
					{
						reference = methodCallExpression.Arguments[0];
						ParameterExpression parameterExpression11 = Expression.Parameter(reference.Type, (reference is ParameterExpression parameterExpression12) ? parameterExpression12.Name : "...");
						MethodInfo method4 = methodCallExpression.Method;
						Expression[] array2 = methodCallExpression.Arguments.ToArray();
						array2[0] = parameterExpression11;
						reference2 = new MethodExpectation(Expression.Lambda(Expression.Call(method4, array2), parameterExpression11), method4, array2);
					}
					break;
				}
				case ExpressionType.Index:
				{
					IndexExpression indexExpression = (IndexExpression)e;
					reference = indexExpression.Object;
					ParameterExpression parameterExpression7 = Expression.Parameter(reference.Type, (reference is ParameterExpression parameterExpression8) ? parameterExpression8.Name : "...");
					PropertyInfo propertyInfo2 = indexExpression.Indexer;
					ReadOnlyCollection<Expression> arguments2 = indexExpression.Arguments;
					MethodInfo method2;
					MethodInfo setter2;
					PropertyInfo setterProperty2;
					if (!assignment && propertyInfo2.CanRead(out MethodInfo getter2, out PropertyInfo getterProperty2))
					{
						method2 = getter2;
						propertyInfo2 = getterProperty2;
					}
					else if (propertyInfo2.CanWrite(out setter2, out setterProperty2))
					{
						method2 = setter2;
						propertyInfo2 = setterProperty2;
					}
					else
					{
						method2 = null;
					}
					reference2 = new MethodExpectation(Expression.Lambda(Expression.MakeIndex(parameterExpression7, propertyInfo2, arguments2), parameterExpression7), method2, arguments2, exactGenericTypeArguments: false, assignment, allowNonOverridable);
					break;
				}
				case ExpressionType.Invoke:
				{
					InvocationExpression invocationExpression = (InvocationExpression)e;
					reference = invocationExpression.Expression;
					ParameterExpression parameterExpression5 = Expression.Parameter(reference.Type, (reference is ParameterExpression parameterExpression6) ? parameterExpression6.Name : "...");
					ReadOnlyCollection<Expression> arguments = invocationExpression.Arguments;
					reference2 = new MethodExpectation(Expression.Lambda(Expression.Invoke(parameterExpression5, arguments), parameterExpression5), reference.Type.GetMethod("Invoke", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), arguments);
					break;
				}
				case ExpressionType.MemberAccess:
				{
					MemberExpression memberAccessExpression = (MemberExpression)e;
					if (IsResult(memberAccessExpression.Member, out var awaitableFactory))
					{
						Split(memberAccessExpression.Expression, out reference, out reference2);
						reference2.AddResultExpression((Expression awaitable) => Expression.MakeMemberAccess(awaitable, memberAccessExpression.Member), awaitableFactory);
					}
					else
					{
						reference = memberAccessExpression.Expression;
						ParameterExpression parameterExpression = Expression.Parameter(reference.Type, (reference is ParameterExpression parameterExpression2) ? parameterExpression2.Name : "...");
						PropertyInfo propertyInfo = memberAccessExpression.GetReboundProperty();
						MethodInfo method;
						MethodInfo setter;
						PropertyInfo setterProperty;
						if (!assignment && propertyInfo.CanRead(out MethodInfo getter, out PropertyInfo getterProperty))
						{
							method = getter;
							propertyInfo = getterProperty;
						}
						else if (propertyInfo.CanWrite(out setter, out setterProperty))
						{
							method = setter;
							propertyInfo = setterProperty;
						}
						else
						{
							method = null;
						}
						reference2 = new MethodExpectation(Expression.Lambda(Expression.MakeMemberAccess(parameterExpression, propertyInfo), parameterExpression), method, null, exactGenericTypeArguments: false, assignment, allowNonOverridable);
					}
					break;
				}
				default:
					throw new InvalidOperationException();
				}
			}
		}

		internal static PropertyInfo GetReboundProperty(this MemberExpression expression)
		{
			PropertyInfo property = (PropertyInfo)expression.Member;
			if (property.DeclaringType != expression.Expression.Type)
			{
				ParameterTypes parameterTypes = new ParameterTypes(property.GetIndexParameters());
				PropertyInfo propertyInfo = expression.Expression.Type.GetMember(property.Name, MemberTypes.Property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Cast<PropertyInfo>().SingleOrDefault((PropertyInfo p) => p.PropertyType == property.PropertyType && new ParameterTypes(p.GetIndexParameters()).CompareTo(parameterTypes, exact: true, considerTypeMatchers: false));
				if (propertyInfo != null && ((propertyInfo.CanRead(out MethodInfo getter) && getter.GetBaseDefinition() == property.GetGetMethod(nonPublic: true)) || (propertyInfo.CanWrite(out MethodInfo setter) && setter.GetBaseDefinition() == property.GetSetMethod(nonPublic: true))))
				{
					return propertyInfo;
				}
			}
			return property;
		}

		public static PropertyInfo ToPropertyInfo(this LambdaExpression expression)
		{
			if (expression.Body is MemberExpression expression2)
			{
				return expression2.GetReboundProperty();
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.SetupNotProperty, expression.ToStringFixed()));
		}

		public static bool IsProperty(this LambdaExpression expression)
		{
			if (expression.Body is MemberExpression memberExpression)
			{
				return memberExpression.Member is PropertyInfo;
			}
			return false;
		}

		public static bool IsPropertyIndexer(this LambdaExpression expression)
		{
			if (!(expression.Body is IndexExpression))
			{
				if (expression.Body is MethodCallExpression methodCallExpression)
				{
					return methodCallExpression.Method.IsSpecialName;
				}
				return false;
			}
			return true;
		}

		public static Expression<Action<TMock>> AssignItIsAny<TMock, T>(this Expression<Func<TMock, T>> expression)
		{
			return Expression.Lambda<Action<TMock>>(Expression.Assign(expression.Body, ItExpr.IsAny<T>()), new ParameterExpression[1] { expression.Parameters[0] });
		}

		public static Expression PartialEval(this Expression expression)
		{
			return Evaluator.PartialEval(expression);
		}

		public static Expression PartialMatcherAwareEval(this Expression expression)
		{
			return Evaluator.PartialEval(expression, PartialMatcherAwareEval_ShouldEvaluate);
		}

		private static bool PartialMatcherAwareEval_ShouldEvaluate(Expression expression)
		{
			Match match;
			return expression.NodeType switch
			{
				ExpressionType.Quote => false, 
				ExpressionType.Parameter => false, 
				ExpressionType.Extension => !(expression is MatchExpression), 
				ExpressionType.Call => !((MethodCallExpression)expression).Method.IsDefined(typeof(MatcherAttribute), inherit: true) && !expression.IsMatch(out match), 
				ExpressionType.MemberAccess => !expression.IsMatch(out match), 
				_ => true, 
			};
		}

		public static string ToStringFixed(this Expression expression)
		{
			return new StringBuilder().AppendExpression(expression).ToString();
		}

		public static Expression Apply(this Expression expression, ExpressionVisitor visitor)
		{
			return visitor.Visit(expression);
		}
	}
}
