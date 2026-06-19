using System.Threading;
using UnityEngine;

namespace Loxodon.Framework.Binding
{
	public class UISynchronizationContext
	{
		private static int threadId;

		private static SynchronizationContext context;

		public static bool InThread => threadId == Thread.CurrentThread.ManagedThreadId;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnInitialize()
		{
			context = SynchronizationContext.Current;
			threadId = Thread.CurrentThread.ManagedThreadId;
		}

		public static void Post(SendOrPostCallback callback, object state)
		{
			if (threadId == Thread.CurrentThread.ManagedThreadId)
			{
				callback(state);
			}
			else
			{
				context.Post(callback, state);
			}
		}

		public static void Send(SendOrPostCallback callback, object state)
		{
			if (threadId == Thread.CurrentThread.ManagedThreadId)
			{
				callback(state);
			}
			else
			{
				context.Send(callback, state);
			}
		}
	}
}
