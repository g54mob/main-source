using System;
using System.Collections.Concurrent;
using System.Linq;

namespace MessagePipe
{
	public static class AsyncRequestHandlerRegistory
	{
		private static ConcurrentDictionary<(string, string), Type> types = new ConcurrentDictionary<(string, string), Type>();

		public static void Add(Type handlerType)
		{
			foreach (Type item in from x in handlerType.GetInterfaces()
				where x.IsGenericType && x.Name.StartsWith("IAsyncRequestHandlerCore")
				select x)
			{
				Type[] genericArguments = item.GetGenericArguments();
				types[(genericArguments[0].FullName, genericArguments[1].FullName)] = handlerType;
			}
		}

		public static void Add(Type requestType, Type responseType, Type handlerType)
		{
			types[(requestType.FullName, responseType.FullName)] = handlerType;
		}

		public static Type Get(string requestType, string responseType)
		{
			if (types.TryGetValue((requestType, responseType), out var value))
			{
				return value;
			}
			throw new InvalidOperationException("IAsyncHandler<" + requestType + ", " + responseType + "> is not registered.");
		}
	}
}
