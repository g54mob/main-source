using System.Collections.Generic;
using System.Linq.Expressions;

namespace Moq
{
	internal sealed class InnerMockSetup : SetupWithOutParameterSupport
	{
		private readonly object returnValue;

		public override IEnumerable<Mock> InnerMocks
		{
			get
			{
				yield return Setup.TryGetInnerMockFrom(returnValue);
			}
		}

		public InnerMockSetup(Expression originalExpression, Mock mock, MethodExpectation expectation, object returnValue)
			: base(originalExpression, mock, expectation)
		{
			this.returnValue = returnValue;
			MarkAsVerifiable();
		}

		protected override void ExecuteCore(Invocation invocation)
		{
			invocation.ReturnValue = returnValue;
		}

		protected override void ResetCore()
		{
			foreach (Mock innerMock in InnerMocks)
			{
				innerMock.MutableSetups.Reset();
			}
		}

		protected override void VerifySelf()
		{
		}
	}
}
