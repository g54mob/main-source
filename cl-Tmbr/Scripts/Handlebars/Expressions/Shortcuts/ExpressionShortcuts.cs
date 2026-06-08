using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Expressions.Shortcuts
{
	internal static class ExpressionShortcuts
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Property<T, TV>(this ExpressionContainer<T> instance, Expression<Func<T, TV>> propertyAccessor)
		{
			return Property(instance.Expression, propertyAccessor);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Field<T, TV>(this ExpressionContainer<T> instance, Expression<Func<T, TV>> propertyAccessor)
		{
			return Field(instance.Expression, propertyAccessor);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Member<T, TV>(this ExpressionContainer<T> instance, Expression<Func<T, TV>> propertyAccessor)
		{
			return Member(instance.Expression, propertyAccessor);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Call<T>(this ExpressionContainer<T> instance, Expression<Action<T>> invocationExpression)
		{
			return new ExpressionContainer(ExpressionUtils.ProcessCallLambda(invocationExpression, instance));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Call<T, TV>(this ExpressionContainer<T> instance, Expression<Func<T, TV>> invocationExpression)
		{
			return Arg<TV>(ExpressionUtils.ProcessCallLambda(invocationExpression, instance));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Code<T, TV>(this ExpressionContainer<T> instance, Func<T, TV> code)
		{
			return Call(() => code((T)instance));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Code<T>(this ExpressionContainer<T> instance, Action<T> code)
		{
			return Call(() => code((T)instance));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Using<T>(this ExpressionContainer<T> instance, Action<ExpressionContainer<T>, BlockBuilder> blockBody) where T : IDisposable
		{
			return Try().Body(delegate(BlockBuilder block)
			{
				blockBody(instance, block);
			}).Finally(instance.Call((T o) => o.Dispose()));
		}

		public static IEnumerable<Expression> Return<T>(this ExpressionContainer<T> instance)
		{
			LabelTarget target = Expression.Label(typeof(T));
			GotoExpression gotoExpression = Expression.Return(target, instance, typeof(T));
			LabelExpression labelExpression = Expression.Label(target, Null<T>());
			return new Expression[2] { gotoExpression, labelExpression };
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Assign<T>(this ExpressionContainer<T> target, ExpressionContainer<T> value)
		{
			return new ExpressionContainer(Expression.Assign(target, value));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Assign<T>(this ExpressionContainer<T> target, T value)
		{
			return new ExpressionContainer(Expression.Assign(target, Expression.Constant(value, typeof(T))));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Assign<T>(this ExpressionContainer<T> target, Expression value)
		{
			return new ExpressionContainer(Expression.Assign(target, value));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Expression TernaryAssign<T>(this ExpressionContainer<T> target, ExpressionContainer<bool> condition, ExpressionContainer<T> ifTrue, ExpressionContainer<T> ifFalse)
		{
			return Expression.IfThenElse(condition.Expression, Expression.Assign(target, ifTrue), Expression.Assign(target, ifFalse));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Arg<T>(Expression expression)
		{
			if (expression != null)
			{
				return new ExpressionContainer<T>(expression);
			}
			return Null<T>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Arg<T>(T value)
		{
			if (value != null)
			{
				return new ExpressionContainer<T>(Expression.Constant(value, typeof(T)));
			}
			return Null<T>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Arg<T>(Expression<T> expression)
		{
			if (expression != null)
			{
				return new ExpressionContainer<T>(expression);
			}
			return Null<T>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Cast<T>(Expression expression)
		{
			if (expression != null)
			{
				return new ExpressionContainer<T>(Expression.Convert(expression, typeof(T)));
			}
			return Null<T>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Var<T>(string name = null)
		{
			return new ExpressionContainer<T>(Expression.Variable(typeof(T), name ?? typeof(T).Name));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Parameter<T>(string name = null)
		{
			return new ExpressionContainer<T>(Expression.Parameter(typeof(T), name ?? typeof(T).Name));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Property<T, TV>(Expression instance, Expression<Func<T, TV>> propertyLambda)
		{
			return Arg<TV>(ExpressionUtils.ProcessPropertyLambda(instance, propertyLambda));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Property<TV>(Expression instance, string propertyName)
		{
			return Arg<TV>(Expression.Property(instance, propertyName));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Field<T, TV>(Expression instance, Expression<Func<T, TV>> propertyLambda)
		{
			return Arg<TV>(ExpressionUtils.ProcessFieldLambda(instance, propertyLambda));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Field<TV>(Expression instance, string propertyName)
		{
			return Arg<TV>(Expression.Field(instance, propertyName));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Member<T, TV>(Expression instance, Expression<Func<T, TV>> propertyLambda)
		{
			return Arg<TV>(ExpressionUtils.ProcessMemberLambda(instance, propertyLambda));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<TV> Member<TV>(Expression instance, string propertyName)
		{
			return Arg<TV>(Expression.PropertyOrField(instance, propertyName));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T[]> Array<T>(IEnumerable<Expression> items)
		{
			return Arg<T[]>(Expression.NewArrayInit(typeof(T), items));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Call(Expression<Action> invocationExpression)
		{
			return new ExpressionContainer(ExpressionUtils.ProcessCallLambda(invocationExpression));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Call<T>(Expression<Func<T>> invocationExpression)
		{
			return Arg<T>(ExpressionUtils.ProcessCallLambda(invocationExpression));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> New<T>(Expression<Func<T>> invocationExpression)
		{
			return Arg<T>(ExpressionUtils.ProcessCallLambda(invocationExpression));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> New<T>() where T : new()
		{
			return Arg<T>(Expression.New(typeof(T).GetConstructor(new Type[0])));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static BlockBuilder Block(Type returnType = null)
		{
			return new BlockBuilder(returnType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Null<T>()
		{
			return Arg<T>(Null(typeof(T)));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Null(Type type)
		{
			return new ExpressionContainer(Expression.Convert(Expression.Constant(null), type));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TryCatchFinallyBuilder Try()
		{
			return new TryCatchFinallyBuilder();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer<T> Code<T>(Func<T> code)
		{
			return Call(() => code());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExpressionContainer Code(Action code)
		{
			return Call(() => code());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SwitchBuilder<T> Switch<T>(ExpressionContainer<T> value)
		{
			return new SwitchBuilder<T>(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ConditionBuilder Condition(Type resultType = null)
		{
			return new ConditionBuilder(resultType);
		}
	}
}
