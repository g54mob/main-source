using System;

namespace MessagePipe
{
	internal static class HandlingSubscribeDisposedPolicyExtensions
	{
		public static IDisposable Handle(this HandlingSubscribeDisposedPolicy policy, string name)
		{
			if (policy == HandlingSubscribeDisposedPolicy.Throw)
			{
				throw new ObjectDisposedException(name);
			}
			return DisposableBag.Empty;
		}
	}
}
