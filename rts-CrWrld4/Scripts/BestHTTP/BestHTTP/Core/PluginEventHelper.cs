using System;
using System.Collections.Concurrent;

namespace BestHTTP.Core
{
	public static class PluginEventHelper
	{
		private static ConcurrentQueue<PluginEventInfo> pluginEvents;

		public static Action<PluginEventInfo> OnEvent;

		public static void EnqueuePluginEvent(PluginEventInfo @event)
		{
		}

		internal static void Clear()
		{
		}

		internal static void ProcessQueue()
		{
		}
	}
}
