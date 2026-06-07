using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks
{
	public static class TaskTracker
	{
		private static List<KeyValuePair<IUniTaskSource, (string formattedType, int trackingId, DateTime addTime, string stackTrace)>> listPool;

		private static readonly WeakDictionary<IUniTaskSource, (string formattedType, int trackingId, DateTime addTime, string stackTrace)> tracking;

		private static bool dirty;

		[Conditional("UNITY_EDITOR")]
		public static void TrackActiveTask(IUniTaskSource task, int skipFrame)
		{
		}

		[Conditional("UNITY_EDITOR")]
		public static void RemoveTracking(IUniTaskSource task)
		{
		}

		public static bool CheckAndResetDirty()
		{
			return false;
		}

		public static void ForEachActiveTask(Action<int, string, UniTaskStatus, DateTime, string> action)
		{
		}

		private static void TypeBeautify(Type type, StringBuilder sb)
		{
		}
	}
}
