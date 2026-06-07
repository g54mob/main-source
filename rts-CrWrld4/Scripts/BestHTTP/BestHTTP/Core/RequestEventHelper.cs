using System;
using System.Collections.Concurrent;

namespace BestHTTP.Core
{
	public static class RequestEventHelper
	{
		private static ConcurrentQueue<RequestEventInfo> requestEventQueue;

		public static Action<RequestEventInfo> OnEvent;

		public static void EnqueueRequestEvent(RequestEventInfo @event)
		{
		}

		internal static void Clear()
		{
		}

		internal static void ProcessQueue()
		{
		}

		private static bool AbortRequestWhenTimedOut(DateTime now, object context)
		{
			return false;
		}

		internal static void HandleRequestStateChange(RequestEventInfo @event)
		{
		}
	}
}
