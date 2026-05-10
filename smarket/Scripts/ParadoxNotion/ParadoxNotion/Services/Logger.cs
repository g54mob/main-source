using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ParadoxNotion.Services
{
	public static class Logger
	{
		public struct Message
		{
			private WeakReference<object> _contextRef;

			public LogType type;

			public string text;

			public string tag;

			public object context
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public bool IsValid()
			{
				return false;
			}
		}

		public delegate bool LogHandler(Message message);

		private static List<LogHandler> subscribers;

		public static bool enabled;

		public static void AddListener(LogHandler callback)
		{
		}

		public static void RemoveListener(LogHandler callback)
		{
		}

		[Conditional("DEVELOPMENT_BUILD")]
		[Conditional("UNITY_EDITOR")]
		public static void Log(object message, string tag = null, object context = null)
		{
		}

		[Conditional("DEVELOPMENT_BUILD")]
		[Conditional("UNITY_EDITOR")]
		public static void LogWarning(object message, string tag = null, object context = null)
		{
		}

		[Conditional("DEVELOPMENT_BUILD")]
		[Conditional("UNITY_EDITOR")]
		public static void LogError(object message, string tag = null, object context = null)
		{
		}

		public static void LogException(Exception exception, string tag = null, object context = null)
		{
		}

		private static void Internal_Log(LogType type, object message, string tag, object context)
		{
		}

		private static void ForwardToUnity(LogType type, object message, string tag, object context)
		{
		}
	}
}
