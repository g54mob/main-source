namespace Moq.Async
{
	internal static class Awaitable
	{
		public static object TryGetResultRecursive(object obj)
		{
			if (obj != null)
			{
				IAwaitableFactory awaitableFactory = AwaitableFactory.TryGet(obj.GetType());
				if (awaitableFactory != null && awaitableFactory.TryGetResult(obj, out object result))
				{
					return TryGetResultRecursive(result);
				}
			}
			return obj;
		}
	}
}
