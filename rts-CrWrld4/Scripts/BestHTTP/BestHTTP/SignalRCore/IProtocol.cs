using System;
using System.Collections.Generic;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SignalRCore.Messages;

namespace BestHTTP.SignalRCore
{
	public interface IProtocol
	{
		string Name { get; }

		TransferModes Type { get; }

		IEncoder Encoder { get; }

		HubConnection Connection { get; set; }

		void ParseMessages(BufferSegment segment, ref List<Message> messages);

		BufferSegment EncodeMessage(Message message);

		object[] GetRealArguments(Type[] argTypes, object[] arguments);

		object ConvertTo(Type toType, object obj);
	}
}
