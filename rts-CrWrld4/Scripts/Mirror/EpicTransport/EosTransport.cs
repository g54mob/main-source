using System;
using System.Collections;
using Epic.OnlineServices;
using Epic.OnlineServices.P2P;
using Mirror;
using UnityEngine;

namespace EpicTransport
{
	public class EosTransport : Transport
	{
		private const string EPIC_SCHEME = "epic";

		private Client client;

		private Server server;

		private Common activeNode;

		[SerializeField]
		public PacketReliability[] Channels;

		public int timeout;

		public int maxFragments;

		public float ignoreCachedMessagesAtStartUpInSeconds;

		private float ignoreCachedMessagesTimer;

		public RelayControl relayControl;

		public ProductUserId productUserId;

		private int packetId;

		private void Awake()
		{
		}

		public override void ClientEarlyUpdate()
		{
		}

		public override void ClientLateUpdate()
		{
		}

		public override void ServerEarlyUpdate()
		{
		}

		public override void ServerLateUpdate()
		{
		}

		public override bool ClientConnected()
		{
			return false;
		}

		public override void ClientConnect(string address)
		{
		}

		public override void ClientConnect(Uri uri)
		{
		}

		public override void ClientSend(int channelId, ArraySegment<byte> segment)
		{
		}

		public override void ClientDisconnect()
		{
		}

		public bool ClientActive()
		{
			return false;
		}

		public override bool ServerActive()
		{
			return false;
		}

		public override void ServerStart()
		{
		}

		public override Uri ServerUri()
		{
			return null;
		}

		public override void ServerSend(int connectionId, int channelId, ArraySegment<byte> segment)
		{
		}

		public override bool ServerDisconnect(int connectionId)
		{
			return false;
		}

		public override string ServerGetClientAddress(int connectionId)
		{
			return null;
		}

		public override void ServerStop()
		{
		}

		private void Send(int channelId, ArraySegment<byte> segment, int connectionId = int.MinValue)
		{
		}

		private Packet[] GetPacketArray(int channelId, ArraySegment<byte> segment)
		{
			return null;
		}

		public override void Shutdown()
		{
		}

		public int GetMaxSinglePacketSize(int channelId)
		{
			return 0;
		}

		public override int GetMaxPacketSize(int channelId)
		{
			return 0;
		}

		public override int GetMaxBatchSize(int channelId)
		{
			return 0;
		}

		public override bool Available()
		{
			return false;
		}

		private IEnumerator FetchEpicAccountId()
		{
			return null;
		}

		private IEnumerator ChangeRelayStatus()
		{
			return null;
		}

		public void ResetIgnoreMessagesAtStartUpTimer()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
