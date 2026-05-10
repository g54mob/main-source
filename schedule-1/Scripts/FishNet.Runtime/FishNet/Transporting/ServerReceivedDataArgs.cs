using System;

namespace FishNet.Transporting
{
	public struct ServerReceivedDataArgs
	{
		public ArraySegment<byte> Data;

		public Channel Channel;

		public int ConnectionId;

		public int TransportIndex;

		public Action FinalizeMethod;

		public ServerReceivedDataArgs(ArraySegment<byte> data, Channel channel, int connectionId, int transportIndex)
		{
			Data = default(ArraySegment<byte>);
			Channel = default(Channel);
			ConnectionId = 0;
			TransportIndex = 0;
			FinalizeMethod = null;
		}

		public ServerReceivedDataArgs(ArraySegment<byte> data, Channel channel, int connectionId, int transportIndex, Action finalizeMethod)
		{
			Data = default(ArraySegment<byte>);
			Channel = default(Channel);
			ConnectionId = 0;
			TransportIndex = 0;
			FinalizeMethod = null;
		}
	}
}
