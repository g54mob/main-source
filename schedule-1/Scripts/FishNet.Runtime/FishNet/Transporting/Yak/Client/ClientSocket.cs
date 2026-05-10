using System;
using System.Collections.Generic;
using FishNet.Transporting.Yak.Server;

namespace FishNet.Transporting.Yak.Client
{
	public class ClientSocket : CommonSocket
	{
		private ServerSocket _server;

		private Queue<LocalPacket> _incoming;

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

		internal void IterateIncoming()
		{
		}

		internal void ReceivedFromLocalServer(LocalPacket packet)
		{
		}

		internal void SendToServer(byte channelId, ArraySegment<byte> segment)
		{
		}

		internal void OnLocalServerConnectionState(LocalConnectionState state)
		{
		}
	}
}
