using System;

namespace Moq.Behaviors
{
	internal sealed class ThrowComputedException : Behavior
	{
		private readonly Func<IInvocation, Exception> exceptionFactory;

		public ThrowComputedException(Func<IInvocation, Exception> exceptionFactory)
		{
			this.exceptionFactory = exceptionFactory;
		}

		public override void Execute(Invocation invocation)
		{
			throw exceptionFactory(invocation);
		}
	}
}
