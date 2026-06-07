using System;
using System.Linq.Expressions;

namespace MiscUtil.Linq
{
	public static class ExpressionUtil
	{
		public static Func<TArg1, TResult> CreateExpression<TArg1, TResult>(Func<Expression, UnaryExpression> body)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg1), "inp");
			try
			{
				return Expression.Lambda<Func<TArg1, TResult>>(body(parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
			}
			catch (Exception ex)
			{
				string msg = ex.Message;
				return delegate
				{
					throw new InvalidOperationException(msg);
				};
			}
		}

		public static Func<TArg1, TArg2, TResult> CreateExpression<TArg1, TArg2, TResult>(Func<Expression, Expression, BinaryExpression> body)
		{
			return CreateExpression<TArg1, TArg2, TResult>(body, castArgsToResultOnFailure: false);
		}

		public static Func<TArg1, TArg2, TResult> CreateExpression<TArg1, TArg2, TResult>(Func<Expression, Expression, BinaryExpression> body, bool castArgsToResultOnFailure)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg1), "lhs");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TArg2), "rhs");
			try
			{
				try
				{
					return Expression.Lambda<Func<TArg1, TArg2, TResult>>(body(parameterExpression, parameterExpression2), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
				}
				catch (InvalidOperationException)
				{
					if (castArgsToResultOnFailure && ((object)typeof(TArg1) != typeof(TResult) || (object)typeof(TArg2) != typeof(TResult)))
					{
						Expression arg = (((object)typeof(TArg1) == typeof(TResult)) ? ((Expression)parameterExpression) : ((Expression)Expression.Convert(parameterExpression, typeof(TResult))));
						Expression arg2 = (((object)typeof(TArg2) == typeof(TResult)) ? ((Expression)parameterExpression2) : ((Expression)Expression.Convert(parameterExpression2, typeof(TResult))));
						return Expression.Lambda<Func<TArg1, TArg2, TResult>>(body(arg, arg2), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
					}
					throw;
				}
			}
			catch (Exception ex2)
			{
				string msg = ex2.Message;
				return delegate
				{
					throw new InvalidOperationException(msg);
				};
			}
		}
	}
}
