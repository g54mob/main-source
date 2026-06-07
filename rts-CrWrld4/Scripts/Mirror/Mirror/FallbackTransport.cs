using System;
using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public class FallbackTransport : Transport
	{
		public Transport[] transports;

		private Transport available;

		public void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private Transport GetAvailableTransport()
		{
			return null;
		}

		public override bool Available()
		{
			return false;
		}

		public override void ClientConnect(string address)
		{
		}

		public override void ClientConnect(Uri uri)
		{
		}

		public override bool ClientConnected()
		{
			return false;
		}

		public override void ClientDisconnect()
		{
		}

		public override void ClientSend(int channelId, ArraySegment<byte> segment)
		{
		}

		public override Uri ServerUri()
		{
			return null;
		}

		public override bool ServerActive()
		{
			return false;
		}

		public override string ServerGetClientAddress(int connectionId)
		{
			return null;
		}

		public override bool ServerDisconnect(int connectionId)
		{
			return false;
		}

		public override void ServerSend(int connectionId, int channelId, ArraySegment<byte> segment)
		{
		}

		public override void ServerStart()
		{
		}

		public override void ServerStop()
		{
		}

		public override void Shutdown()
		{
		}

		public override int GetMaxPacketSize(int channelId = 0)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
