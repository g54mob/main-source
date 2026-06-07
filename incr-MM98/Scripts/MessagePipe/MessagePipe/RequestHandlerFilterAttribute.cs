using System;
using MessagePipe.Internal;

namespace MessagePipe
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	[Preserve]
	public class RequestHandlerFilterAttribute : Attribute, IMessagePipeFilterAttribute
	{
		public Type Type { get; }

		public int Order { get; set; }

		[Preserve]
		public RequestHandlerFilterAttribute(Type type)
		{
			if (!typeof(IRequestHandlerFilter).IsAssignableFrom(type))
			{
				throw new ArgumentException(type.FullName + " is not RequestHandlerFilter.");
			}
			Type = type;
		}
	}
}
