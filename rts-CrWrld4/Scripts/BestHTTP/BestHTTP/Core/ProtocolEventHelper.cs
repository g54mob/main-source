using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BestHTTP.Core
{
	public static class ProtocolEventHelper
	{
		private static ConcurrentQueue<ProtocolEventInfo> protocolEvents;

		private static List<IProtocol> ActiveProtocols;

		public static Action<ProtocolEventInfo> OnEvent;

		public static void EnqueueProtocolEvent(ProtocolEventInfo @event)
		{
		}

		internal static void Clear()
		{
		}

		internal static void ProcessQueue()
		{
		}

		internal static void AddProtocol(IProtocol protocol)
		{
		}

		internal static void CancelActiveProtocols()
		{
		}
	}
}
