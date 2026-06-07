using System;
using System.Collections.Generic;

namespace BestHTTP.SocketIO3.Events
{
	public sealed class TypedEventTable
	{
		private Dictionary<string, Subscription> subscriptions;

		private Socket Socket { get; set; }

		public TypedEventTable(Socket socket)
		{
		}

		public Subscription GetSubscription(string name)
		{
			return null;
		}

		public void Register(string methodName, Type[] paramTypes, Action<object[]> callback, bool once = false)
		{
		}

		public void Call(string eventName, object[] args)
		{
		}

		public void Call(IncomingPacket packet)
		{
		}

		public void Unregister(string name)
		{
		}

		public void Clear()
		{
		}
	}
}
