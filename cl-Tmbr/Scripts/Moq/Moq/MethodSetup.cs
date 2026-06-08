using System.Linq.Expressions;
using System.Reflection;

namespace Moq
{
	internal abstract class MethodSetup : Setup
	{
		public MethodInfo Method => ((MethodExpectation)base.Expectation).Method;

		protected MethodSetup(Expression originalExpression, Mock mock, MethodExpectation expectation)
			: base(originalExpression, mock, expectation)
		{
		}
	}
}
