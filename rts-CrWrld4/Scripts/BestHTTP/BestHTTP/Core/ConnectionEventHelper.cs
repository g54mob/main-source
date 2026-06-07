using System;
using System.Collections.Concurrent;

namespace BestHTTP.Core
{
	public static class ConnectionEventHelper
	{
		private static ConcurrentQueue<ConnectionEventInfo> connectionEventQueue;

		public static Action<ConnectionEventInfo> OnEvent;

		public static void EnqueueConnectionEvent(ConnectionEventInfo @event)
		{
		}

		internal static void Clear()
		{
		}

		internal static void ProcessQueue()
		{
		}

		private static void HandleConnectionStateChange(ConnectionEventInfo @event)
		{
		}
	}
}
