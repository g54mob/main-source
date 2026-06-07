using System;
using System.Collections.Generic;

namespace BestHTTP.SocketIO3.Events
{
	public sealed class Subscription
	{
		public List<CallbackDescriptor> callbacks;

		public void Add(Type[] paramTypes, Action<object[]> callback, bool once)
		{
		}

		public void Remove(Action<object[]> callback)
		{
		}
	}
}
