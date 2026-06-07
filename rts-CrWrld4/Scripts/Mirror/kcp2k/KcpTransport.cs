using System;
using Mirror;
using UnityEngine;

namespace kcp2k
{
	[DisallowMultipleComponent]
	public class KcpTransport : Transport
	{
		public const string Scheme = "kcp";

		public ushort Port;

		public bool NoDelay;

		public uint Interval;

		public int FastResend;

		public bool CongestionWindow;

		public uint SendWindowSize;

		public uint ReceiveWindowSize;

		private KcpServer server;

		private KcpClient client;

		public bool debugLog;

		public bool statisticsGUI;

		public bool statisticsLog;

		private void Awake()
		{
		}

		public override bool Available()
		{
			return false;
		}

		public override bool ClientConnected()
		{
			return false;
		}

		public override void ClientConnect(string address)
		{
		}

		public override void ClientSend(int channelId, ArraySegment<byte> segment)
		{
		}

		public override void ClientDisconnect()
		{
		}

		public override void ClientEarlyUpdate()
		{
		}

		public override void ClientLateUpdate()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
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

		public override void ServerStart()
		{
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

		public override void ServerEarlyUpdate()
		{
		}

		public override void ServerLateUpdate()
		{
		}

		public override void Shutdown()
		{
		}

		public override int GetMaxPacketSize(int channelId = 0)
		{
			return 0;
		}

		public override int GetMaxBatchSize(int channelId)
		{
			return 0;
		}

		public int GetAverageMaxSendRate()
		{
			return 0;
		}

		public int GetAverageMaxReceiveRate()
		{
			return 0;
		}

		private int GetTotalSendQueue()
		{
			return 0;
		}

		private int GetTotalReceiveQueue()
		{
			return 0;
		}

		private int GetTotalSendBuffer()
		{
			return 0;
		}

		private int GetTotalReceiveBuffer()
		{
			return 0;
		}

		public static string PrettyBytes(long bytes)
		{
			return null;
		}

		private void OnGUI()
		{
		}

		private void OnLogStatistics()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
