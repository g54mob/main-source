using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Matchers;
using Moq.Properties;
using TypeNameFormatter;

namespace Moq
{
	internal static class MatcherFactory
	{
		public static Pair<IMatcher[], Expression[]> CreateMatchers(IReadOnlyList<Expression> arguments, ParameterInfo[] parameters)
		{
			int num = parameters.Length;
			Expression[] array = new Expression[num];
			IMatcher[] array2 = new IMatcher[num];
			for (int i = 0; i < num; i++)
			{
				IMatcher[] array3 = array2;
				int num2 = i;
				int num3 = i;
				CreateMatcher(arguments[i], parameters[i]).Deconstruct(out IMatcher item, out Expression item2);
				array3[num2] = item;
				array[num3] = item2;
			}
			return new Pair<IMatcher[], Expression[]>(array2, array);
		}

		public static Pair<IMatcher, Expression> CreateMatcher(Expression argument, ParameterInfo parameter)
		{
			if (parameter.ParameterType.IsByRef)
			{
				if ((parameter.Attributes & (ParameterAttributes.In | ParameterAttributes.Out)) == ParameterAttributes.Out)
				{
					return new Pair<IMatcher, Expression>(AnyMatcher.Instance, argument);
				}
				if (argument is MemberExpression { Member: var member } && member.Name == "IsAny")
				{
					Type declaringType = member.DeclaringType;
					if (declaringType.IsGenericType)
					{
						Type genericTypeDefinition = declaringType.GetGenericTypeDefinition();
						if (genericTypeDefinition == typeof(It.Ref<>))
						{
							return new Pair<IMatcher, Expression>(AnyMatcher.Instance, argument);
						}
					}
				}
				if (argument.PartialEval() is ConstantExpression constantExpression)
				{
					return new Pair<IMatcher, Expression>(new RefMatcher(constantExpression.Value), constantExpression);
				}
				throw new NotSupportedException(Resources.RefExpressionMustBeConstantValue);
			}
			if (parameter.IsDefined(typeof(ParamArrayAttribute), inherit: true) && argument.NodeType == ExpressionType.NewArrayInit)
			{
				NewArrayExpression newArrayExpression = (NewArrayExpression)argument;
				Type elementType = newArrayExpression.Type.GetElementType();
				int count = newArrayExpression.Expressions.Count;
				IMatcher[] array = new IMatcher[count];
				Expression[] array2 = new Expression[count];
				for (int i = 0; i < count; i++)
				{
					IMatcher[] array3 = array;
					int num = i;
					int num2 = i;
					CreateMatcher(newArrayExpression.Expressions[i]).Deconstruct(out IMatcher item, out Expression item2);
					array3[num] = item;
					array2[num2] = item2;
					array2[i] = array2[i].ConvertIfNeeded(elementType);
				}
				return new Pair<IMatcher, Expression>(new ParamArrayMatcher(array), Expression.NewArrayInit(elementType, array2));
			}
			if (argument.NodeType == ExpressionType.Convert)
			{
				UnaryExpression unaryExpression = (UnaryExpression)argument;
				if (unaryExpression.Method?.Name == "op_Implicit" && unaryExpression.Operand.IsMatch(out Match match))
				{
					Type type = ((!match.GetType().IsGenericType) ? unaryExpression.Operand.Type : match.GetType().GenericTypeArguments[0]);
					if (!type.IsAssignableFrom(parameter.ParameterType))
					{
						throw new ArgumentException(string.Format(Resources.ArgumentMatcherWillNeverMatch, unaryExpression.Operand.ToStringFixed(), unaryExpression.Operand.Type.GetFormattedName(), parameter.ParameterType.GetFormattedName()));
					}
				}
			}
			return CreateMatcher(argument);
		}

		public static Pair<IMatcher, Expression> CreateMatcher(Expression expression)
		{
			Expression expression2 = expression;
			while (expression.NodeType == ExpressionType.Convert)
			{
				expression = ((UnaryExpression)expression).Operand;
			}
			if (expression is MatchExpression matchExpression)
			{
				return new Pair<IMatcher, Expression>(matchExpression.Match, matchExpression);
			}
			Match match2;
			if (expression is MethodCallExpression methodCallExpression)
			{
				if (expression.IsMatch(out Match match))
				{
					return new Pair<IMatcher, Expression>(match, expression);
				}
				if (methodCallExpression.Method.IsDefined(typeof(MatcherAttribute), inherit: true))
				{
					return new Pair<IMatcher, Expression>(new MatcherAttributeMatcher(methodCallExpression), methodCallExpression);
				}
				MethodInfo method = methodCallExpression.Method;
				if (!method.IsGetAccessor())
				{
					return new Pair<IMatcher, Expression>(new LazyEvalMatcher(expression2), expression2);
				}
			}
			else if ((expression is MemberExpression || expression is IndexExpression) && expression.IsMatch(out match2))
			{
				return new Pair<IMatcher, Expression>(match2, expression);
			}
			Expression expression3 = expression2.PartialEval();
			if (expression3.NodeType == ExpressionType.Constant)
			{
				return new Pair<IMatcher, Expression>(new ConstantMatcher(((ConstantExpression)expression3).Value), expression3);
			}
			if (expression3.NodeType == ExpressionType.Quote)
			{
				return new Pair<IMatcher, Expression>(new ExpressionMatcher(((UnaryExpression)expression).Operand), expression3);
			}
			throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedExpression, expression2));
		}
	}
}
