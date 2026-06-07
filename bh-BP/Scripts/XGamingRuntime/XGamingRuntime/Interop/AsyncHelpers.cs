namespace XGamingRuntime.Interop
{
	public class AsyncHelpers
	{
		public static XAsyncBlockPtr WrapAsyncBlock(XTaskQueueHandle queue, XAsyncCompletionRoutine callback)
		{
			return default(XAsyncBlockPtr);
		}

		internal static void CleanupAsyncBlock(XAsyncBlockPtr block)
		{
		}

		[MonoPInvokeCallback]
		private static void AsyncBlockCallback(XAsyncBlockPtr block)
		{
		}
	}
}
