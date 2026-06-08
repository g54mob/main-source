using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Moq
{
	internal sealed class StubbedPropertiesSetup : Setup
	{
		private sealed class PropertyAccessorExpectation : Expectation
		{
			private readonly LambdaExpression expression;

			public override LambdaExpression Expression => expression;

			public PropertyAccessorExpectation(Mock mock)
			{
				Type type = mock.GetType();
				MethodInfo method = type.GetMethod("SetupAllProperties");
				Type type2 = method.ReturnType.GetGenericArguments()[0];
				MethodInfo method2 = Moq.Mock.GetMethod.MakeGenericMethod(type2);
				ParameterExpression parameterExpression = System.Linq.Expressions.Expression.Parameter(type2, "m");
				expression = System.Linq.Expressions.Expression.Lambda(System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Call(method2, parameterExpression), method), parameterExpression);
			}

			public override bool Equals(Expectation other)
			{
				if (other is PropertyAccessorExpectation propertyAccessorExpectation)
				{
					return ExpressionComparer.Default.Equals(expression, propertyAccessorExpectation.expression);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return typeof(PropertyAccessorExpectation).GetHashCode();
			}

			public override bool IsMatch(Invocation invocation)
			{
				return invocation.Method.IsPropertyAccessor();
			}
		}

		private readonly ConcurrentDictionary<string, object> values;

		private readonly DefaultValueProvider defaultValueProvider;

		public DefaultValueProvider DefaultValueProvider => defaultValueProvider;

		public override IEnumerable<Mock> InnerMocks
		{
			get
			{
				foreach (object value in values.Values)
				{
					Mock mock = Setup.TryGetInnerMockFrom(value);
					if (mock != null)
					{
						yield return mock;
					}
				}
			}
		}

		public StubbedPropertiesSetup(Mock mock, DefaultValueProvider defaultValueProvider = null)
			: base(null, mock, new PropertyAccessorExpectation(mock))
		{
			values = new ConcurrentDictionary<string, object>();
			this.defaultValueProvider = defaultValueProvider ?? mock.DefaultValueProvider;
			MarkAsVerifiable();
		}

		public void SetProperty(string propertyName, object value)
		{
			values[propertyName] = value;
		}

		protected override void ExecuteCore(Invocation invocation)
		{
			if (invocation.Method.ReturnType == typeof(void))
			{
				string key = invocation.Method.Name.Substring(4);
				values[key] = invocation.Arguments[0];
				return;
			}
			string key2 = invocation.Method.Name.Substring(4);
			object orAdd = values.GetOrAdd(key2, (string pn) => base.Mock.GetDefaultValue(invocation.Method, out Mock _, defaultValueProvider));
			invocation.ReturnValue = orAdd;
		}

		protected override void VerifySelf()
		{
		}
	}
}
