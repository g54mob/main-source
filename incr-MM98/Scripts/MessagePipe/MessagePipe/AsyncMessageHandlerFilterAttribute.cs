using System;
using MessagePipe.Internal;

namespace MessagePipe
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	[Preserve]
	public class AsyncMessageHandlerFilterAttribute : Attribute, IMessagePipeFilterAttribute
	{
		public Type Type { get; }

		public int Order { get; set; }

		[Preserve]
		public AsyncMessageHandlerFilterAttribute(Type type)
		{
			if (!typeof(IAsyncMessageHandlerFilter).IsAssignableFrom(type))
			{
				throw new ArgumentException(type.FullName + " is not AsyncMessageHandlerFilter.");
			}
			Type = type;
		}
	}
}
