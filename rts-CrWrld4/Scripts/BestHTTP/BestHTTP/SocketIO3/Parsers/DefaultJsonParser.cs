using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SocketIO3.Events;

namespace BestHTTP.SocketIO3.Parsers
{
	[Il2CppEagerStaticClassConstruction]
	public sealed class DefaultJsonParser : IParser
	{
		private IncomingPacket PacketWithAttachment;

		private StringBuilder builder;

		static DefaultJsonParser()
		{
		}

		private int ToInt(char ch)
		{
			return 0;
		}

		public IncomingPacket Parse(SocketManager manager, string from)
		{
			return default(IncomingPacket);
		}

		public IncomingPacket MergeAttachements(SocketManager manager, IncomingPacket packet)
		{
			return default(IncomingPacket);
		}

		private (string, object[]) ReadData(SocketManager manager, IncomingPacket packet, string payload)
		{
			return default((string, object[]));
		}

		private object[] ReadParameters(Socket socket, Subscription subscription, List<object> array, int startIdx)
		{
			return null;
		}

		public object ConvertTo(Type toType, object obj)
		{
			return null;
		}

		private object[] ReadParameters(Socket socket, Subscription subscription, TextReader reader)
		{
			return null;
		}

		public IncomingPacket Parse(SocketManager manager, BufferSegment data, TransportEventTypes transportEvent = TransportEventTypes.Unknown)
		{
			return default(IncomingPacket);
		}

		public OutgoingPacket CreateOutgoing(TransportEventTypes transportEvent, string payload)
		{
			return default(OutgoingPacket);
		}

		public OutgoingPacket CreateOutgoing(Socket socket, SocketIOEventTypes socketIOEvent, int id, string name, object arg)
		{
			return default(OutgoingPacket);
		}

		private int GetBinaryCount(object[] args)
		{
			return 0;
		}

		public OutgoingPacket CreateOutgoing(Socket socket, SocketIOEventTypes socketIOEvent, int id, string name, object[] args)
		{
			return default(OutgoingPacket);
		}

		private List<byte[]> CreatePlaceholders(object[] args)
		{
			return null;
		}
	}
}
