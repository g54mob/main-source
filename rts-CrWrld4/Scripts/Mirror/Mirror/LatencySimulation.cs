using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public class LatencySimulation : Transport
	{
		public Transport wrap;

		public float latencySpikeMultiplier;

		public float latencySpikeSpeedMultiplier;

		public float reliableLatency;

		public float unreliableLoss;

		public float unreliableLatency;

		public float unreliableScramble;

		private List<QueuedMessage> reliableClientToServer;

		private List<QueuedMessage> reliableServerToClient;

		private List<QueuedMessage> unreliableClientToServer;

		private List<QueuedMessage> unreliableServerToClient;

		private System.Random random;

		public void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		protected virtual float Noise(float time)
		{
			return 0f;
		}

		private float SimulateLatency(int channeldId)
		{
			return 0f;
		}

		private void SimulateSend(int connectionId, int channelId, ArraySegment<byte> segment, float latency, List<QueuedMessage> reliableQueue, List<QueuedMessage> unreliableQueue)
		{
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

		public override void ClientEarlyUpdate()
		{
		}

		public override void ServerEarlyUpdate()
		{
		}

		public override void ClientLateUpdate()
		{
		}

		public override void ServerLateUpdate()
		{
		}

		public override int GetMaxBatchSize(int channelId)
		{
			return 0;
		}

		public override int GetMaxPacketSize(int channelId = 0)
		{
			return 0;
		}

		public override void Shutdown()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
