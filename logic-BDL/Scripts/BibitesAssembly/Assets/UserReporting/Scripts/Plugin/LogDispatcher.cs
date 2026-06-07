using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UserReporting.Scripts.Plugin
{
	public static class LogDispatcher
	{
		private static List<WeakReference> listeners;

		static LogDispatcher()
		{
			listeners = new List<WeakReference>();
			Application.logMessageReceivedThreaded += delegate(string logString, string stackTrace, LogType logType)
			{
				lock (listeners)
				{
					int num = 0;
					while (num < listeners.Count)
					{
						if (listeners[num].Target is ILogListener logListener)
						{
							logListener.ReceiveLogMessage(logString, stackTrace, logType);
							num++;
						}
						else
						{
							listeners.RemoveAt(num);
						}
					}
				}
			};
		}

		public static void Register(ILogListener logListener)
		{
			lock (listeners)
			{
				listeners.Add(new WeakReference(logListener));
			}
		}
	}
}
