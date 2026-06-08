using System;

namespace Moq.Behaviors
{
	internal sealed class Callback : Behavior
	{
		private readonly Action<IInvocation> callback;

		public Callback(Action<IInvocation> callback)
		{
			this.callback = callback;
		}

		public override void Execute(Invocation invocation)
		{
			callback(invocation);
		}
	}
}
