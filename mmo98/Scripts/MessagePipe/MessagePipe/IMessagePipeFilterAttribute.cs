using System;

namespace MessagePipe
{
	public interface IMessagePipeFilterAttribute
	{
		Type Type { get; }

		int Order { get; }
	}
}
