using System;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Expressions.Visitors;

namespace Moq
{
	public abstract class Match : IMatcher
	{
		internal Expression RenderExpression { get; set; }

		internal static TValue Matcher<TValue>()
		{
			return default(TValue);
		}

		internal abstract bool Matches(object argument, Type parameterType);

		internal abstract void SetupEvaluatedSuccessfully(object argument, Type parameterType);

		bool IMatcher.Matches(object argument, Type parameterType)
		{
			return Matches(argument, parameterType);
		}

		void IMatcher.SetupEvaluatedSuccessfully(object value, Type parameterType)
		{
			SetupEvaluatedSuccessfully(value, parameterType);
		}

		public static T Create<T>(Predicate<T> condition)
		{
			Register(new Match<T>(condition, () => Matcher<T>()));
			return default(T);
		}

		public static T Create<T>(Predicate<T> condition, Expression<Func<T>> renderExpression)
		{
			Register(new Match<T>(condition, renderExpression));
			return default(T);
		}

		public static T Create<T>(Func<object, Type, bool> condition, Expression<Func<T>> renderExpression)
		{
			Guard.NotNull(condition, "condition");
			Guard.NotNull(renderExpression, "renderExpression");
			Register(new MatchFactory(condition, renderExpression));
			return default(T);
		}

		internal static void Register(Match match)
		{
			if (MatcherObserver.IsActive(out MatcherObserver observer))
			{
				observer.OnMatch(match);
			}
		}
	}
	public class Match<T> : Match, IEquatable<Match<T>>
	{
		internal Predicate<T> Condition { get; set; }

		internal Action<T> Success { get; set; }

		internal Match(Predicate<T> condition, Expression<Func<T>> renderExpression, Action<T> success = null)
		{
			Condition = condition;
			base.RenderExpression = renderExpression.Body.Apply(EvaluateCaptures.Rewriter);
			Success = success;
		}

		internal override bool Matches(object argument, Type parameterType)
		{
			if (CanCast(argument))
			{
				return Condition((T)argument);
			}
			return false;
		}

		internal override void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
			Success?.Invoke((T)argument);
		}

		private static bool CanCast(object value)
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

		public override bool Equals(object obj)
		{
			if (obj is Match<T> other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(Match<T> other)
		{
			if ((Delegate)Condition == (Delegate)other.Condition)
			{
				return true;
			}
			if (Condition.GetMethodInfo() != other.Condition.GetMethodInfo())
			{
				return false;
			}
			if (!(base.RenderExpression is MethodCallExpression methodCallExpression) || !(methodCallExpression.Method.DeclaringType == typeof(Match)))
			{
				return ExpressionComparer.Default.Equals(base.RenderExpression, other.RenderExpression);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
