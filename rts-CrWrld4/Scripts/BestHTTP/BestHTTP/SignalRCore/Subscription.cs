using System;
using System.Collections.Generic;

namespace BestHTTP.SignalRCore
{
	internal sealed class Subscription
	{
		public List<CallbackDescriptor> callbacks;

		public void Add(Type[] paramTypes, Action<object[]> callback)
		{
		}

		public void Remove(Action<object[]> callback)
		{
		}
	}
}
