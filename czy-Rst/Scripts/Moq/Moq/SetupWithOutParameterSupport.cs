using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Moq.Properties;

namespace Moq
{
	internal abstract class SetupWithOutParameterSupport : MethodSetup
	{
		private readonly List<KeyValuePair<int, object>> outValues;

		protected SetupWithOutParameterSupport(Expression originalExpression, Mock mock, MethodExpectation expectation)
			: base(originalExpression, mock, expectation)
		{
			outValues = GetOutValues(expectation.Arguments, expectation.Method.GetParameters());
		}

		public sealed override void SetOutParameters(Invocation invocation)
		{
			if (outValues == null)
			{
				return;
			}
			foreach (KeyValuePair<int, object> outValue in outValues)
			{
				invocation.Arguments[outValue.Key] = outValue.Value;
			}
		}

		private static List<KeyValuePair<int, object>> GetOutValues(IReadOnlyList<Expression> arguments, ParameterInfo[] parameters)
		{
			List<KeyValuePair<int, object>> list = null;
			int i = 0;
			for (int num = parameters.Length; i < num; i++)
			{
				ParameterInfo parameterInfo = parameters[i];
				if (parameterInfo.ParameterType.IsByRef && (parameterInfo.Attributes & (ParameterAttributes.In | ParameterAttributes.Out)) == ParameterAttributes.Out)
				{
					if (!(arguments[i].PartialEval() is ConstantExpression constantExpression))
					{
						throw new NotSupportedException(Resources.OutExpressionMustBeConstantValue);
					}
					if (list == null)
					{
						list = new List<KeyValuePair<int, object>>();
					}
					list.Add(new KeyValuePair<int, object>(i, constantExpression.Value));
				}
			}
			return list;
		}
	}
}
