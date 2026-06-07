using System;
using BestHTTP.SignalRCore.Messages;

namespace BestHTTP.SignalRCore
{
	internal struct InvocationDefinition
	{
		public Action<Message> callback;

		public Type returnType;
	}
}
