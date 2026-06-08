using System;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Expressions.Visitors;

namespace Moq
{
	internal sealed class MatchFactory : Match
	{
		private readonly Func<object, Type, bool> condition;

		private static readonly MethodInfo canCastMethod = typeof(MatchFactory).GetMethod("CanCast", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic);

		internal MatchFactory(Func<object, Type, bool> condition, LambdaExpression renderExpression)
		{
			this.condition = condition;
			base.RenderExpression = renderExpression.Body.Apply(EvaluateCaptures.Rewriter);
		}

		internal override bool Matches(object argument, Type parameterType)
		{
			Predicate<object> predicate = (Predicate<object>)Delegate.CreateDelegate(typeof(Predicate<object>), canCastMethod.MakeGenericMethod(parameterType));
			if (predicate(argument))
			{
				return condition(argument, parameterType);
			}
			return false;
		}

		internal override void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
		}

		private static bool CanCast<T>(object value)
		{
			if (value != null)
			{
				return value is T;
			}
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsValueType)
			{
				if (typeFromHandle.IsGenericType)
				{
					return typeFromHandle.GetGenericTypeDefinition() == typeof(Nullable<>);
				}
				return false;
			}
			return true;
		}
	}
}
