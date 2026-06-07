using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using MiscUtil.Extensions;

namespace MiscUtil.Linq.Extensions
{
	public static class TypeExt
	{
		private static ConstructorInfo GetConstructor(Type type, params Type[] argumentTypes)
		{
			type.ThrowIfNull("type");
			argumentTypes.ThrowIfNull("argumentTypes");
			ConstructorInfo constructor = type.GetConstructor(argumentTypes);
			if ((object)constructor == null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(type.Name).Append(" has no ctor(");
				for (int i = 0; i < argumentTypes.Length; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(argumentTypes[i].Name);
				}
				stringBuilder.Append(')');
				throw new InvalidOperationException(stringBuilder.ToString());
			}
			return constructor;
		}

		public static Func<TResult> Ctor<TResult>(this Type type)
		{
			ConstructorInfo constructor = GetConstructor(type, Type.EmptyTypes);
			return Expression.Lambda<Func<TResult>>(Expression.New(constructor), new ParameterExpression[0]).Compile();
		}

		public static Func<TArg1, TResult> Ctor<TArg1, TResult>(this Type type)
		{
			ConstructorInfo constructor = GetConstructor(type, typeof(TArg1));
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg1), "arg1");
			return Expression.Lambda<Func<TArg1, TResult>>(Expression.New(constructor, parameterExpression), new ParameterExpression[1] { parameterExpression }).Compile();
		}

		public static Func<TArg1, TArg2, TResult> Ctor<TArg1, TArg2, TResult>(this Type type)
		{
			ConstructorInfo constructor = GetConstructor(type, typeof(TArg1), typeof(TArg2));
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg1), "arg1");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TArg2), "arg2");
			return Expression.Lambda<Func<TArg1, TArg2, TResult>>(Expression.New(constructor, parameterExpression, parameterExpression2), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
		}

		public static Func<TArg1, TArg2, TArg3, TResult> Ctor<TArg1, TArg2, TArg3, TResult>(this Type type)
		{
			ConstructorInfo constructor = GetConstructor(type, typeof(TArg1), typeof(TArg2), typeof(TArg3));
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg1), "arg1");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TArg2), "arg2");
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(TArg3), "arg3");
			return Expression.Lambda<Func<TArg1, TArg2, TArg3, TResult>>(Expression.New(constructor, parameterExpression, parameterExpression2, parameterExpression3), new ParameterExpression[3] { parameterExpression, parameterExpression2, parameterExpression3 }).Compile();
		}

		public static Func<TArg1, TArg2, TArg3, TArg4, TResult> Ctor<TArg1, TArg2, TArg3, TArg4, TResult>(this Type type)
		{
			ConstructorInfo constructor = GetConstructor(type, typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TArg1), "arg1");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TArg2), "arg2");
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(TArg3), "arg3");
			ParameterExpression parameterExpression4 = Expression.Parameter(typeof(TArg4), "arg4");
			return Expression.Lambda<Func<TArg1, TArg2, TArg3, TArg4, TResult>>(Expression.New(constructor, parameterExpression, parameterExpression2, parameterExpression3, parameterExpression4), new ParameterExpression[4] { parameterExpression, parameterExpression2, parameterExpression3, parameterExpression4 }).Compile();
		}
	}
}
