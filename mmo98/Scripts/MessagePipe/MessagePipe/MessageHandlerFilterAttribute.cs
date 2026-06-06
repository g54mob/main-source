using System;
using MessagePipe.Internal;

namespace MessagePipe
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	[Preserve]
	public class MessageHandlerFilterAttribute : Attribute, IMessagePipeFilterAttribute
	{
		public Type Type { get; }

		public int Order { get; set; }

		[Preserve]
		public MessageHandlerFilterAttribute(Type type)
		{
			if (!typeof(IMessageHandlerFilter).IsAssignableFrom(type))
			{
				throw new ArgumentException(type.FullName + " is not MessageHandlerFilter.");
			}
			Type = type;
		}
	}
}
