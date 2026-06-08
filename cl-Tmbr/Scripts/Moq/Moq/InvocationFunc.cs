using System;

namespace Moq
{
	public readonly struct InvocationFunc
	{
		internal readonly Func<IInvocation, object> Func;

		public InvocationFunc(Func<IInvocation, object> func)
		{
			Func = func;
		}
	}
}
