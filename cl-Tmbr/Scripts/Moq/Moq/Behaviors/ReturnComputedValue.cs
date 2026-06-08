using System;

namespace Moq.Behaviors
{
	internal sealed class ReturnComputedValue : Behavior
	{
		private readonly Func<IInvocation, object> valueFactory;

		public ReturnComputedValue(Func<IInvocation, object> valueFactory)
		{
			this.valueFactory = valueFactory;
		}

		public override void Execute(Invocation invocation)
		{
			invocation.ReturnValue = valueFactory(invocation);
		}
	}
}
