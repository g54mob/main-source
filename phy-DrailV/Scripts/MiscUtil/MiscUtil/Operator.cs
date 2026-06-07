using System;
using System.Linq.Expressions;
using MiscUtil.Linq;

namespace MiscUtil
{
	public static class Operator
	{
		public static bool HasValue<T>(T value)
		{
			return Operator<T>.NullOp.HasValue(value);
		}

		public static bool AddIfNotNull<T>(ref T accumulator, T value)
		{
			return Operator<T>.NullOp.AddIfNotNull(ref accumulator, value);
		}

		public static T Negate<T>(T value)
		{
			return Operator<T>.Negate(value);
		}

		public static T Not<T>(T value)
		{
			return Operator<T>.Not(value);
		}

		public static T Or<T>(T value1, T value2)
		{
			return Operator<T>.Or(value1, value2);
		}

		public static T And<T>(T value1, T value2)
		{
			return Operator<T>.And(value1, value2);
		}

		public static T Xor<T>(T value1, T value2)
		{
			return Operator<T>.Xor(value1, value2);
		}

		public static TTo Convert<TFrom, TTo>(TFrom value)
		{
			return Operator<TFrom, TTo>.Convert(value);
		}

		public static T Add<T>(T value1, T value2)
		{
			return Operator<T>.Add(value1, value2);
		}

		public static TArg1 AddAlternative<TArg1, TArg2>(TArg1 value1, TArg2 value2)
		{
			return Operator<TArg2, TArg1>.Add(value1, value2);
		}

		public static T Subtract<T>(T value1, T value2)
		{
			return Operator<T>.Subtract(value1, value2);
		}

		public static TArg1 SubtractAlternative<TArg1, TArg2>(TArg1 value1, TArg2 value2)
		{
			return Operator<TArg2, TArg1>.Subtract(value1, value2);
		}

		public static T Multiply<T>(T value1, T value2)
		{
			return Operator<T>.Multiply(value1, value2);
		}

		public static TArg1 MultiplyAlternative<TArg1, TArg2>(TArg1 value1, TArg2 value2)
		{
			return Operator<TArg2, TArg1>.Multiply(value1, value2);
		}

		public static T Divide<T>(T value1, T value2)
		{
			return Operator<T>.Divide(value1, value2);
		}

		public static TArg1 DivideAlternative<TArg1, TArg2>(TArg1 value1, TArg2 value2)
		{
			return Operator<TArg2, TArg1>.Divide(value1, value2);
		}

		public static bool Equal<T>(T value1, T value2)
		{
			return Operator<T>.Equal(value1, value2);
		}

		public static bool NotEqual<T>(T value1, T value2)
		{
			return Operator<T>.NotEqual(value1, value2);
		}

		public static bool GreaterThan<T>(T value1, T value2)
		{
			return Operator<T>.GreaterThan(value1, value2);
		}

		public static bool LessThan<T>(T value1, T value2)
		{
			return Operator<T>.LessThan(value1, value2);
		}

		public static bool GreaterThanOrEqual<T>(T value1, T value2)
		{
			return Operator<T>.GreaterThanOrEqual(value1, value2);
		}

		public static bool LessThanOrEqual<T>(T value1, T value2)
		{
			return Operator<T>.LessThanOrEqual(value1, value2);
		}

		public static T DivideInt32<T>(T value, int divisor)
		{
			return Operator<int, T>.Divide(value, divisor);
		}
	}
	public static class Operator<TValue, TResult>
	{
		private static readonly Func<TValue, TResult> convert;

		private static readonly Func<TResult, TValue, TResult> add;

		private static readonly Func<TResult, TValue, TResult> subtract;

		private static readonly Func<TResult, TValue, TResult> multiply;

		private static readonly Func<TResult, TValue, TResult> divide;

		public static Func<TValue, TResult> Convert => convert;

		public static Func<TResult, TValue, TResult> Add => add;

		public static Func<TResult, TValue, TResult> Subtract => subtract;

		public static Func<TResult, TValue, TResult> Multiply => multiply;

		public static Func<TResult, TValue, TResult> Divide => divide;

		static Operator()
		{
			convert = ExpressionUtil.CreateExpression<TValue, TResult>((Expression body) => Expression.Convert(body, typeof(TResult)));
			add = ExpressionUtil.CreateExpression<TResult, TValue, TResult>(Expression.Add, castArgsToResultOnFailure: true);
			subtract = ExpressionUtil.CreateExpression<TResult, TValue, TResult>(Expression.Subtract, castArgsToResultOnFailure: true);
			multiply = ExpressionUtil.CreateExpression<TResult, TValue, TResult>(Expression.Multiply, castArgsToResultOnFailure: true);
			divide = ExpressionUtil.CreateExpression<TResult, TValue, TResult>(Expression.Divide, castArgsToResultOnFailure: true);
		}
	}
	public static class Operator<T>
	{
		private static readonly INullOp<T> nullOp;

		private static readonly T zero;

		private static readonly Func<T, T> negate;

		private static readonly Func<T, T> not;

		private static readonly Func<T, T, T> or;

		private static readonly Func<T, T, T> and;

		private static readonly Func<T, T, T> xor;

		private static readonly Func<T, T, T> add;

		private static readonly Func<T, T, T> subtract;

		private static readonly Func<T, T, T> multiply;

		private static readonly Func<T, T, T> divide;

		private static readonly Func<T, T, bool> equal;

		private static readonly Func<T, T, bool> notEqual;

		private static readonly Func<T, T, bool> greaterThan;

		private static readonly Func<T, T, bool> lessThan;

		private static readonly Func<T, T, bool> greaterThanOrEqual;

		private static readonly Func<T, T, bool> lessThanOrEqual;

		internal static INullOp<T> NullOp => nullOp;

		public static T Zero => zero;

		public static Func<T, T> Negate => negate;

		public static Func<T, T> Not => not;

		public static Func<T, T, T> Or => or;

		public static Func<T, T, T> And => and;

		public static Func<T, T, T> Xor => xor;

		public static Func<T, T, T> Add => add;

		public static Func<T, T, T> Subtract => subtract;

		public static Func<T, T, T> Multiply => multiply;

		public static Func<T, T, T> Divide => divide;

		public static Func<T, T, bool> Equal => equal;

		public static Func<T, T, bool> NotEqual => notEqual;

		public static Func<T, T, bool> GreaterThan => greaterThan;

		public static Func<T, T, bool> LessThan => lessThan;

		public static Func<T, T, bool> GreaterThanOrEqual => greaterThanOrEqual;

		public static Func<T, T, bool> LessThanOrEqual => lessThanOrEqual;

		static Operator()
		{
			add = ExpressionUtil.CreateExpression<T, T, T>(Expression.Add);
			subtract = ExpressionUtil.CreateExpression<T, T, T>(Expression.Subtract);
			divide = ExpressionUtil.CreateExpression<T, T, T>(Expression.Divide);
			multiply = ExpressionUtil.CreateExpression<T, T, T>(Expression.Multiply);
			greaterThan = ExpressionUtil.CreateExpression<T, T, bool>(Expression.GreaterThan);
			greaterThanOrEqual = ExpressionUtil.CreateExpression<T, T, bool>(Expression.GreaterThanOrEqual);
			lessThan = ExpressionUtil.CreateExpression<T, T, bool>(Expression.LessThan);
			lessThanOrEqual = ExpressionUtil.CreateExpression<T, T, bool>(Expression.LessThanOrEqual);
			equal = ExpressionUtil.CreateExpression<T, T, bool>(Expression.Equal);
			notEqual = ExpressionUtil.CreateExpression<T, T, bool>(Expression.NotEqual);
			negate = ExpressionUtil.CreateExpression<T, T>(Expression.Negate);
			and = ExpressionUtil.CreateExpression<T, T, T>(Expression.And);
			or = ExpressionUtil.CreateExpression<T, T, T>(Expression.Or);
			not = ExpressionUtil.CreateExpression<T, T>(Expression.Not);
			xor = ExpressionUtil.CreateExpression<T, T, T>(Expression.ExclusiveOr);
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsValueType && typeFromHandle.IsGenericType && (object)typeFromHandle.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				Type type = typeFromHandle.GetGenericArguments()[0];
				zero = (T)Activator.CreateInstance(type);
				nullOp = (INullOp<T>)Activator.CreateInstance(typeof(StructNullOp<>).MakeGenericType(type));
				return;
			}
			zero = default(T);
			if (typeFromHandle.IsValueType)
			{
				nullOp = (INullOp<T>)Activator.CreateInstance(typeof(StructNullOp<>).MakeGenericType(typeFromHandle));
			}
			else
			{
				nullOp = (INullOp<T>)Activator.CreateInstance(typeof(ClassNullOp<>).MakeGenericType(typeFromHandle));
			}
		}
	}
}
