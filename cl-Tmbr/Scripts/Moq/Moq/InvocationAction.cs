using System;

namespace Moq
{
	public readonly struct InvocationAction
	{
		internal readonly Action<IInvocation> Action;

		public InvocationAction(Action<IInvocation> action)
		{
			Action = action;
		}
	}
}
