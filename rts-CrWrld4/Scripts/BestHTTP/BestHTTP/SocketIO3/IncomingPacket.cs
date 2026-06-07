using System.Collections.Generic;
using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.SocketIO3
{
	public struct IncomingPacket
	{
		public static readonly IncomingPacket Empty;

		public TransportEventTypes TransportEvent { get; private set; }

		public SocketIOEventTypes SocketIOEvent { get; private set; }

		public int Id { get; private set; }

		public string Namespace { get; private set; }

		public int AttachementCount { get; set; }

		public List<BufferSegment> Attachements { get; set; }

		public string EventName { get; set; }

		public object[] DecodedArgs { get; set; }

		public object DecodedArg { get; set; }

		public IncomingPacket(TransportEventTypes transportEvent, SocketIOEventTypes packetType, string nsp, int id)
		{
			TransportEvent = default(TransportEventTypes);
			SocketIOEvent = default(SocketIOEventTypes);
			Id = 0;
			Namespace = null;
			AttachementCount = 0;
			Attachements = null;
			EventName = null;
			DecodedArgs = null;
			DecodedArg = null;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(IncomingPacket packet)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static string GenerateAcknowledgementNameFromId(int id)
		{
			return null;
		}
	}
}
