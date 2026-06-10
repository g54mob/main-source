using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks
{
	public static class UniTaskScheduler
	{
		[CompilerGenerated]
		private static Action<Exception> UnobservedTaskException;

		public static bool PropagateOperationCanceledException;

		public static LogType UnobservedExceptionWriteLogType;

		public static bool DispatchUnityMainThread;

		private static readonly SendOrPostCallback handleExceptionInvoke;

		private static void InvokeUnobservedTaskException(object state)
		{
		}

		internal static void PublishUnobservedTaskException(Exception ex)
		{
		}
	}
}
