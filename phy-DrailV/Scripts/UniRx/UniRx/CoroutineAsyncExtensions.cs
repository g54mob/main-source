using UnityEngine;

namespace UniRx
{
	public static class CoroutineAsyncExtensions
	{
		public static CoroutineAsyncBridge GetAwaiter(this Coroutine coroutine)
		{
			return CoroutineAsyncBridge.Start(coroutine);
		}
	}
}
