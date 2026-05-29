using System;
using System.Collections.Generic;
using FishNet.Transporting.Yak.Client;

namespace FishNet.Transporting.Yak.Server
{
	public class ServerSocket : CommonSocket
	{
		private Queue<LocalPacket> _incoming;

		private ClientSocket _client;

		internal RemoteConnectionState GetConnectionState(int connectionId)
		{
			return default(RemoteConnectionState);
		}

		internal override void Initialize(Transport t, CommonSocket socket)
		{
		}

		internal bool StartConnection()
		{
			return false;
		}

		protected override void SetLocalConnectionState(LocalConnectionState connectionState, bool server)
		{
		}

		internal bool StopConnection()
		{
			return false;
		}

		internal bool StopConnection(int connectionId)
		{
			return false;
		}

		internal void IterateIncoming()
		{
		}

		internal void SendToClient(byte channelId, ArraySegment<byte> segment, int connectionId)
		{
		}

		internal void OnLocalClientConnectionState(LocalConnectionState state)
		{
		}

		internal void ReceivedFromLocalClient(LocalPacket packet)
		{
		}
	}
}
