using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Moq.Matchers
{
	internal class MatcherAttributeMatcher : IMatcher
	{
		private MethodInfo validatorMethod;

		private MethodCallExpression expression;

		public MatcherAttributeMatcher(MethodCallExpression expression)
		{
			validatorMethod = ResolveValidatorMethod(expression);
			this.expression = expression;
		}

		private static MethodInfo ResolveValidatorMethod(MethodCallExpression call)
		{
			Type[] expectedParametersTypes = new Type[1] { call.Method.ReturnType }.Concat(from p in call.Method.GetParameters()
				select p.ParameterType).ToArray();
			MethodInfo methodInfo = null;
			if (call.Method.IsGenericMethod)
			{
				Type[] genericArgs = call.Method.GetGenericArguments();
				methodInfo = (from m in call.Method.DeclaringType.GetMethods(call.Method.Name)
					where m.IsGenericMethodDefinition && m.GetGenericArguments().Length == call.Method.GetGenericMethodDefinition().GetGenericArguments().Length && expectedParametersTypes.SequenceEqual(from p in m.MakeGenericMethod(genericArgs).GetParameters()
						select p.ParameterType)
					select m.MakeGenericMethod(genericArgs)).FirstOrDefault();
			}
			else
			{
				methodInfo = call.Method.DeclaringType.GetMethod(call.Method.Name, expectedParametersTypes);
			}
			if (methodInfo == null)
			{
				throw new MissingMethodException(string.Format(CultureInfo.CurrentCulture, "public {0}bool {1}({2}) in class {3}.", call.Method.IsStatic ? "static " : string.Empty, call.Method.Name, string.Join(", ", expectedParametersTypes.Select((Type x) => x.Name).ToArray()), call.Method.DeclaringType.ToString()));
			}
			return methodInfo;
		}

		public bool Matches(object argument, Type parameterType)
		{
			IEnumerable<object> second = expression.Arguments.Select((Expression ae) => ((ConstantExpression)ae.PartialEval()).Value);
			object[] parameters = new object[1] { argument }.Concat(second).ToArray();
			object obj = ((expression.Object == null) ? null : (expression.Object.PartialEval() as ConstantExpression).Value);
			return (bool)validatorMethod.Invoke(obj, parameters);
		}

		public void SetupEvaluatedSuccessfully(object argument, Type parameterType)
		{
		}
	}
}
