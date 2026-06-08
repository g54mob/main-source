using System;

namespace Moq.Behaviors
{
	internal sealed class ThrowException : Behavior
	{
		private readonly Exception exception;

		public ThrowException(Exception exception)
		{
			this.exception = exception;
		}

		public override void Execute(Invocation invocation)
		{
			throw exception;
		}
	}
}
