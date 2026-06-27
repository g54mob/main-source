using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Async;
using Moq.Expressions.Visitors;
using Moq.Internals;
using Moq.Properties;
using TypeNameFormatter;

namespace Moq
{
	internal sealed class ActionObserver : ExpressionReconstructor
	{
		private sealed class Recorder : IInterceptor
		{
			private readonly MatcherObserver matcherObserver;

			private int creationTimestamp;

			private Invocation invocation;

			private int invocationTimestamp;

			private object returnValue;

			public Invocation Invocation => invocation;

			public IEnumerable<Match> Matches => matcherObserver.GetMatchesBetween(creationTimestamp, invocationTimestamp);

			public Recorder Next => (Awaitable.TryGetResultRecursive(returnValue) as IProxy)?.Interceptor as Recorder;

			public Recorder(MatcherObserver matcherObserver)
			{
				this.matcherObserver = matcherObserver;
				creationTimestamp = this.matcherObserver.GetNextTimestamp();
			}

			public void Intercept(Invocation invocation)
			{
				Type returnType = invocation.Method.ReturnType;
				this.invocation = invocation;
				invocationTimestamp = matcherObserver.GetNextTimestamp();
				if (returnType == typeof(void))
				{
					returnValue = null;
				}
				else
				{
					IAwaitableFactory awaitableFactory = AwaitableFactory.TryGet(returnType);
					Recorder recorder;
					if (awaitableFactory != null)
					{
						IProxy result = CreateProxy(awaitableFactory.ResultType, null, matcherObserver, out recorder);
						returnValue = awaitableFactory.CreateCompleted(result);
					}
					else
					{
						if (!returnType.IsMockable())
						{
							throw new NotSupportedException(Resources.LastMemberHasNonInterceptableReturnType);
						}
						returnValue = CreateProxy(returnType, null, matcherObserver, out recorder);
					}
				}
				if (returnType != typeof(void))
				{
					invocation.ReturnValue = returnValue;
				}
			}
		}

		public override Expression<Action<T>> ReconstructExpression<T>(Action<T> action, object[] ctorArgs = null)
		{
			using (MatcherObserver matcherObserver = MatcherObserver.Activate())
			{
				Recorder recorder;
				T obj = (T)CreateProxy(typeof(T), ctorArgs, matcherObserver, out recorder);
				Exception ex = null;
				try
				{
					action(obj);
				}
				catch (Exception ex2)
				{
					ex = ex2;
				}
				string name = action.GetMethodInfo().GetParameters()[^1].Name;
				ParameterExpression parameterExpression = Expression.Parameter(typeof(T), name);
				Expression expression = parameterExpression;
				Recorder recorder2 = recorder;
				while (recorder2 != null)
				{
					Invocation invocation = recorder2.Invocation;
					if (invocation != null)
					{
						Type declaringType = invocation.Method.DeclaringType;
						if (!declaringType.IsAssignableFrom(expression.Type))
						{
							IAwaitableFactory awaitableFactory = AwaitableFactory.TryGet(expression.Type);
							if (awaitableFactory != null && awaitableFactory.ResultType.IsAssignableFrom(declaringType))
							{
								expression = awaitableFactory.CreateResultExpression(expression);
							}
						}
						expression = Expression.Call(expression, invocation.Method, GetArgumentExpressions(invocation, recorder2.Matches.ToArray()));
						recorder2 = recorder2.Next;
						continue;
					}
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpressionWithHint, name + " => " + expression.ToStringFixed() + "...", Resources.NextMemberNonInterceptable));
				}
				if (ex == null)
				{
					return Expression.Lambda<Action<T>>(expression.Apply(UpgradePropertyAccessorMethods.Rewriter), new ParameterExpression[1] { parameterExpression });
				}
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpressionWithHint, name + " => " + expression.ToStringFixed() + "...", ex.Message));
			}
			static Expression[] GetArgumentExpressions(Invocation invocation2, Match[] matches)
			{
				ParameterTypes parameterTypes = invocation2.Method.GetParameterTypes();
				int count = parameterTypes.Count;
				Expression[] expressions = new Expression[count];
				for (int i = 0; i < count; i++)
				{
					expressions[i] = Expression.Constant(invocation2.Arguments[i], parameterTypes[i]);
				}
				if (matches.Length != 0)
				{
					int num = 0;
					int num2 = 0;
					while (num < matches.Length && num2 < expressions.Length)
					{
						Type type = matches[num].RenderExpression.Type;
						object obj2 = type.GetDefaultValue();
						try
						{
							obj2 = Convert.ChangeType(obj2, parameterTypes[num2]);
						}
						catch
						{
						}
						if (object.Equals(invocation2.Arguments[num2], obj2) && parameterTypes[num2].IsAssignableFrom(obj2?.GetType() ?? type))
						{
							if (num < matches.Length - 1 && num2 >= expressions.Length - 1 && !CanDistribute(num + 1, num2 + 1))
							{
								break;
							}
							expressions[num2] = new MatchExpression(matches[num]);
							num++;
						}
						num2++;
					}
					if (num < matches.Length)
					{
						throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.MatcherAssignmentFailedDuringExpressionReconstruction, matches.Length, invocation2.Method.DeclaringType.GetFormattedName() + "." + invocation2.Method.Name));
					}
				}
				for (int j = 0; j < expressions.Length; j++)
				{
					Expression expression2 = expressions[j];
					Type type2 = parameterTypes[j];
					if (!(expression2.Type == type2))
					{
						if (Nullable.GetUnderlyingType(type2) != null && Nullable.GetUnderlyingType(expression2.Type) == null)
						{
							expressions[j] = Expression.Convert(expression2, type2);
						}
						else if (expression2.Type.IsValueType && !type2.IsValueType)
						{
							expressions[j] = Expression.Convert(expression2, type2);
						}
						else if (expression2.Type != type2 && !type2.IsAssignableFrom(expression2.Type))
						{
							expressions[j] = Expression.Convert(expression2, type2);
						}
					}
				}
				return expressions;
				bool CanDistribute(int msi, int asi)
				{
					Match match = matches[msi];
					Type type3 = match.RenderExpression.Type;
					for (int k = asi; k < expressions.Length; k++)
					{
						if (parameterTypes[k].IsAssignableFrom(type3) && CanDistribute(msi + 1, k + 1))
						{
							return true;
						}
					}
					return false;
				}
			}
		}

		private static IProxy CreateProxy(Type type, object[] ctorArgs, MatcherObserver matcherObserver, out Recorder recorder)
		{
			recorder = new Recorder(matcherObserver);
			return (IProxy)ProxyFactory.Instance.CreateProxy(type, recorder, Type.EmptyTypes, ctorArgs ?? new object[0]);
		}
	}
}
