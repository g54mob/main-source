using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Rhizomatic.Utility
{
	public static class AwaiterExtensions
	{
		public static TaskAwaiter<int> GetAwaiter(this YieldInstruction yieldInstruction)
		{
			return default(TaskAwaiter<int>);
		}

		public static TaskAwaiter<int> GetAwaiter(this CustomYieldInstruction yieldInstruction)
		{
			return default(TaskAwaiter<int>);
		}

		public static TaskAwaiter<T> GetAwaiter<T>(this Promise<T> promise)
		{
			return default(TaskAwaiter<T>);
		}

		public static TaskAwaiter<int> CreateAwaiter(UnityAction<UnityAction> action)
		{
			return default(TaskAwaiter<int>);
		}
	}
}
