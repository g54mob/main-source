using System;
using MessagePipe.Internal;

namespace MessagePipe
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	[Preserve]
	public class AsyncRequestHandlerFilterAttribute : Attribute, IMessagePipeFilterAttribute
	{
		public Type Type { get; }

		public int Order { get; set; }

		[Preserve]
		public AsyncRequestHandlerFilterAttribute(Type type)
		{
			if (!typeof(IAsyncRequestHandlerFilter).IsAssignableFrom(type))
			{
				throw new ArgumentException(type.FullName + " is not AsyncRequestHandlerFilter.");
			}
			Type = type;
		}
	}
}
