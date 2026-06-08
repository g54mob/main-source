using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Moq
{
	internal sealed class StubbedPropertySetup : Setup
	{
		private sealed class PropertyAccessorExpectation : Expectation
		{
			private readonly LambdaExpression expression;

			private readonly MethodInfo getter;

			private readonly MethodInfo setter;

			public override LambdaExpression Expression => expression;

			public PropertyAccessorExpectation(LambdaExpression expression, MethodInfo getter, MethodInfo setter)
			{
				this.expression = expression;
				this.getter = getter;
				this.setter = setter;
			}

			public override bool Equals(Expectation obj)
			{
				if (obj is PropertyAccessorExpectation propertyAccessorExpectation && propertyAccessorExpectation.getter == getter)
				{
					return propertyAccessorExpectation.setter == setter;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (getter?.GetHashCode() ?? 0) + 103 * (setter?.GetHashCode() ?? 0);
			}

			public override bool IsMatch(Invocation invocation)
			{
				string name = invocation.Method.Name;
				if (!(name == getter.Name))
				{
					return name == setter.Name;
				}
				return true;
			}
		}

		private object value;

		public override IEnumerable<Mock> InnerMocks
		{
			get
			{
				Mock mock = Setup.TryGetInnerMockFrom(value);
				if (mock != null)
				{
					yield return mock;
				}
			}
		}

		public StubbedPropertySetup(Mock mock, LambdaExpression expression, MethodInfo getter, MethodInfo setter, object initialValue)
			: base(null, mock, new PropertyAccessorExpectation(expression, getter, setter))
		{
			value = initialValue;
			MarkAsVerifiable();
		}

		protected override void ExecuteCore(Invocation invocation)
		{
			if (invocation.Method.ReturnType == typeof(void))
			{
				value = invocation.Arguments[0];
			}
			else
			{
				invocation.ReturnValue = value;
			}
		}

		public override string ToString()
		{
			return base.ToString() + " (stubbed)";
		}

		protected override void VerifySelf()
		{
		}
	}
}
