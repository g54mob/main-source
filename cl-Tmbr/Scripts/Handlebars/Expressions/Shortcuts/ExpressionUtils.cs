using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Expressions.Shortcuts
{
	internal static class ExpressionUtils
	{
		private static readonly ExpressionExtractorVisitor ExtractorVisitor = new ExpressionExtractorVisitor();

		internal static IEnumerable<Expression> ReplaceParameters(IEnumerable<Expression> expressions, IList<Expression> newValues)
		{
			if (newValues.Count == 0)
			{
				return expressions;
			}
			return PerformReplacement();
			IEnumerable<Expression> PerformReplacement()
			{
				ParameterReplacerVisitor visitor = new ParameterReplacerVisitor(newValues);
				return from expression in expressions
					where expression != null
					select visitor.Visit(expression);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Expression ReplaceParameters(Expression expression, params Expression[] newValues)
		{
			return new ParameterReplacerVisitor(newValues).Visit(expression);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Expression ProcessPropertyLambda(Expression instance, LambdaExpression propertyLambda)
		{
			MemberExpression obj = (propertyLambda.Body as MemberExpression) ?? throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a property.");
			if (obj.Member as PropertyInfo == null)
			{
				throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.");
			}
			return ReplaceParameters(ExtractArgument(obj), instance);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Expression ProcessFieldLambda(Expression instance, LambdaExpression propertyLambda)
		{
			MemberExpression obj = (propertyLambda.Body as MemberExpression) ?? throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a field.");
			if (obj.Member as FieldInfo == null)
			{
				throw new ArgumentException($"Expression '{propertyLambda}' refers to a property, not a field.");
			}
			return ReplaceParameters(ExtractArgument(obj), instance);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Expression ProcessMemberLambda(Expression instance, LambdaExpression propertyLambda)
		{
			return ReplaceParameters(ExtractArgument((propertyLambda.Body as MemberExpression) ?? throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a field.")), instance);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Expression ProcessCallLambda(LambdaExpression propertyLambda, Expression instance = null)
		{
			return ProcessCall(propertyLambda.Body, instance);
		}

		internal static Expression ProcessCall(Expression propertyLambda, Expression instance = null)
		{
			if (!(propertyLambda is NewExpression newExpression))
			{
				if (!(propertyLambda is MethodCallExpression { Method: var method } methodCallExpression))
				{
					if (propertyLambda is InvocationExpression invocationExpression)
					{
						return invocationExpression.Update(invocationExpression.Expression, ExtractArguments(invocationExpression.Arguments));
					}
					return ReplaceParameters(ExtractArgument(propertyLambda), instance);
				}
				Expression[] newValues = ((instance == null) ? new Expression[0] : new Expression[1] { instance });
				instance = ReplaceParameters(new Expression[1] { methodCallExpression.Object }, newValues).SingleOrDefault();
				IEnumerable<Expression> arguments = methodCallExpression.Arguments;
				arguments = ReplaceParameters(arguments, newValues).Select(ExtractArgument);
				return Expression.Call(method.IsStatic ? null : Expression.Convert(instance, method.DeclaringType), method, arguments);
			}
			return Expression.New(newExpression.Constructor, ExtractArguments(newExpression.Arguments));
		}

		private static IReadOnlyCollection<Expression> ExtractArguments(IReadOnlyCollection<Expression> expressions)
		{
			Expression[] array = new Expression[expressions.Count];
			if (expressions is IList<Expression> list)
			{
				for (int i = 0; i < list.Count; i++)
				{
					array[i] = ExtractArgument(list[i]);
				}
				return array;
			}
			int num = 0;
			foreach (Expression expression in expressions)
			{
				array[num++] = ExtractArgument(expression);
			}
			return array;
		}

		private static Expression ExtractArgument(Expression expr)
		{
			return ExtractorVisitor.Visit(expr);
		}
	}
}
