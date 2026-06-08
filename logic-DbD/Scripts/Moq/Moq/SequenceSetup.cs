using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Moq
{
	internal sealed class SequenceSetup : SetupWithOutParameterSupport
	{
		private ConcurrentQueue<Behavior> behaviors;

		public SequenceSetup(Expression originalExpression, Mock mock, MethodExpectation expectation)
			: base(originalExpression, mock, expectation)
		{
			behaviors = new ConcurrentQueue<Behavior>();
		}

		public void AddBehavior(Behavior behavior)
		{
			behaviors.Enqueue(behavior);
		}

		protected override void ExecuteCore(Invocation invocation)
		{
			if (behaviors.TryDequeue(out Behavior result))
			{
				result.Execute(invocation);
				return;
			}
			Type returnType = invocation.Method.ReturnType;
			if (returnType != typeof(void))
			{
				invocation.ReturnValue = returnType.GetDefaultValue();
			}
		}
	}
}
