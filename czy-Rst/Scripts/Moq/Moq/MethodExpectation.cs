using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Async;
using Moq.Expressions.Visitors;

namespace Moq
{
	internal sealed class MethodExpectation : Expectation
	{
		private static readonly Expression[] noArguments = new Expression[0];

		private static readonly IMatcher[] noArgumentMatchers = new IMatcher[0];

		private LambdaExpression expression;

		public readonly MethodInfo Method;

		public readonly IReadOnlyList<Expression> Arguments;

		private readonly IMatcher[] argumentMatchers;

		private IAwaitableFactory awaitableFactory;

		private MethodInfo methodImplementation;

		private Expression[] partiallyEvaluatedArguments;

		private readonly bool exactGenericTypeArguments;

		public override LambdaExpression Expression => expression;

		public static MethodExpectation CreateFrom(Invocation invocation)
		{
			MethodInfo method = invocation.Method;
			ParameterTypes parameterTypes = method.GetParameterTypes();
			int count = parameterTypes.Count;
			Expression[] array = new Expression[count];
			for (int i = 0; i < count; i++)
			{
				Type type = parameterTypes[i];
				if (type.IsByRef)
				{
					type = type.GetElementType();
				}
				array[i] = System.Linq.Expressions.Expression.Constant(invocation.Arguments[i], type);
			}
			ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(method.DeclaringType, "mock");
			LambdaExpression lambdaExpression = System.Linq.Expressions.Expression.Lambda(System.Linq.Expressions.Expression.Call(parameterExpression, method, array).Apply(UpgradePropertyAccessorMethods.Rewriter), parameterExpression);
			if (lambdaExpression.IsProperty())
			{
				PropertyInfo property = lambdaExpression.ToPropertyInfo();
				Guard.CanRead(property);
			}
			return new MethodExpectation(lambdaExpression, method, array, exactGenericTypeArguments: true);
		}

		public MethodExpectation(LambdaExpression expression, MethodInfo method, IReadOnlyList<Expression> arguments = null, bool exactGenericTypeArguments = false, bool skipMatcherInitialization = false, bool allowNonOverridable = false)
		{
			if (!allowNonOverridable)
			{
				Guard.IsOverridable(method, expression);
				Guard.IsVisibleToProxyFactory(method);
			}
			this.expression = expression;
			Method = method;
			if (arguments != null && !skipMatcherInitialization)
			{
				MatcherFactory.CreateMatchers(arguments, method.GetParameters()).Deconstruct(out IMatcher[] item, out Expression[] item2);
				IReadOnlyList<Expression> arguments2 = item2;
				argumentMatchers = item;
				Arguments = arguments2;
			}
			else
			{
				argumentMatchers = noArgumentMatchers;
				Arguments = arguments ?? noArguments;
			}
			this.exactGenericTypeArguments = exactGenericTypeArguments;
		}

		public void AddResultExpression(Func<Expression, Expression> add, IAwaitableFactory awaitableFactory)
		{
			expression = System.Linq.Expressions.Expression.Lambda(add(Expression.Body), Expression.Parameters);
			this.awaitableFactory = awaitableFactory;
		}

		public override bool HasResultExpression(out IAwaitableFactory awaitableFactory)
		{
			return (awaitableFactory = this.awaitableFactory) != null;
		}

		public void Deconstruct(out LambdaExpression expression, out MethodInfo method, out IReadOnlyList<Expression> arguments)
		{
			expression = Expression;
			method = Method;
			arguments = Arguments;
		}

		public override bool IsMatch(Invocation invocation)
		{
			if (invocation.Method != Method && !IsOverride(invocation))
			{
				return false;
			}
			object[] arguments = invocation.Arguments;
			ParameterTypes parameterTypes = invocation.Method.GetParameterTypes();
			int i = 0;
			for (int num = argumentMatchers.Length; i < num; i++)
			{
				if (!argumentMatchers[i].Matches(arguments[i], parameterTypes[i]))
				{
					return false;
				}
			}
			return true;
		}

		public override void SetupEvaluatedSuccessfully(Invocation invocation)
		{
			object[] arguments = invocation.Arguments;
			ParameterTypes parameterTypes = invocation.Method.GetParameterTypes();
			int i = 0;
			for (int num = argumentMatchers.Length; i < num; i++)
			{
				argumentMatchers[i].SetupEvaluatedSuccessfully(arguments[i], parameterTypes[i]);
			}
		}

		private bool IsOverride(Invocation invocation)
		{
			MethodInfo method = Method;
			MethodInfo method2 = invocation.Method;
			Type proxyType = invocation.ProxyType;
			if (methodImplementation == null)
			{
				methodImplementation = method.GetImplementingMethod(proxyType);
			}
			if (invocation.MethodImplementation != methodImplementation)
			{
				return false;
			}
			if ((method.IsGenericMethod || method2.IsGenericMethod) && !method.GetGenericArguments().CompareTo(method2.GetGenericArguments(), exactGenericTypeArguments, considerTypeMatchers: true))
			{
				return false;
			}
			return true;
		}

		public override bool Equals(Expectation obj)
		{
			if (!(obj is MethodExpectation methodExpectation))
			{
				return false;
			}
			if (Method != methodExpectation.Method)
			{
				return false;
			}
			if (Arguments.Count != methodExpectation.Arguments.Count)
			{
				return false;
			}
			if (partiallyEvaluatedArguments == null)
			{
				partiallyEvaluatedArguments = PartiallyEvaluateArguments(Arguments);
			}
			if (methodExpectation.partiallyEvaluatedArguments == null)
			{
				methodExpectation.partiallyEvaluatedArguments = PartiallyEvaluateArguments(methodExpectation.Arguments);
			}
			ParameterInfo parameterInfo = Method.GetParameters().LastOrDefault();
			bool flag = parameterInfo != null && parameterInfo.ParameterType.IsArray && parameterInfo.IsDefined(typeof(ParamArrayAttribute));
			int i = 0;
			for (int num = partiallyEvaluatedArguments.Length - 1; i <= num; i++)
			{
				if (i == num && flag && Arguments[num] is NewArrayExpression newArrayExpression && methodExpectation.Arguments[num] is NewArrayExpression newArrayExpression2 && newArrayExpression.Expressions.Count == newArrayExpression2.Expressions.Count)
				{
					int j = 0;
					for (int count = newArrayExpression.Expressions.Count; j < count; j++)
					{
						if (!ExpressionComparer.Default.Equals(newArrayExpression.Expressions[j], newArrayExpression2.Expressions[j]))
						{
							return false;
						}
					}
				}
				else if (!ExpressionComparer.Default.Equals(partiallyEvaluatedArguments[i], methodExpectation.partiallyEvaluatedArguments[i]))
				{
					return false;
				}
			}
			return true;
		}

		private static Expression[] PartiallyEvaluateArguments(IReadOnlyList<Expression> arguments)
		{
			if (arguments.Count == 0)
			{
				return noArguments;
			}
			Expression[] array = new Expression[arguments.Count];
			int i = 0;
			for (int count = arguments.Count; i < count; i++)
			{
				array[i] = arguments[i].PartialMatcherAwareEval();
			}
			return array;
		}

		public override int GetHashCode()
		{
			return Method.GetHashCode();
		}
	}
}
