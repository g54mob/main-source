using System;
using System.Collections.Generic;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Managing.Transporting
{
	[Serializable]
	public class LatencySimulator
	{
		private struct Message
		{
			public readonly int ConnectionId;

			public readonly byte[] Data;

			public readonly int Length;

			public readonly float SendTime;

			public Message(int connectionId, ArraySegment<byte> segment, float latency)
			{
				ConnectionId = 0;
				Data = null;
				Length = 0;
				SendTime = 0f;
			}

			public ArraySegment<byte> GetSegment()
			{
				return default(ArraySegment<byte>);
			}
		}

		[Header("Settings")]
		[Tooltip("True if latency simulator is enabled.")]
		[SerializeField]
		private bool _enabled;

		[Tooltip("True to add latency on clientHost as well.")]
		[SerializeField]
		private bool _simulateHost;

		[Range(0f, 60000f)]
		[Tooltip("Milliseconds to add between packets. When acting as host this value will be doubled. Added latency will be a minimum of tick rate.")]
		[SerializeField]
		private long _latency;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Percentage of unreliable packets which should arrive out of order.")]
		[Header("Unreliable")]
		private double _outOfOrder;

		[Tooltip("Percentage of packets which should drop.")]
		[Range(0f, 1f)]
		[SerializeField]
		private double _packetLoss;

		private Transport _transport;

		private List<Message> _toServerReliable;

		private List<Message> _toServerUnreliable;

		private List<Message> _toClientReliable;

		private List<Message> _toClientUnreliable;

		private NetworkManager _networkManager;

		private readonly System.Random _random;

		internal bool CanSimulate => false;

		public bool GetEnabled()
		{
			return false;
		}

		public void SetEnabled(bool value)
		{
		}

		public long GetLatency()
		{
			return 0L;
		}

		public void SetLatency(long value)
		{
		}

		public double GetOutOfOrder()
		{
			return 0.0;
		}

		public void SetOutOfOrder(double value)
		{
		}

		public double GetPacketLost()
		{
			return 0.0;
		}

		public void SetPacketLoss(double value)
		{
		}

		public void Initialize(NetworkManager manager, Transport transport)
		{
		}

		public void Reset()
		{
		}

		public void RemovePendingForConnection(int connectionId)
		{
		}

		private float GetLatencyAsFloat()
		{
			return 0f;
		}

		public void AddOutgoing(byte channelId, ArraySegment<byte> segment, bool toServer = true, int connectionId = -1)
		{
		}

		public void IterateOutgoing(bool toServer)
		{
		}

		private bool DropPacket()
		{
			return false;
		}

		private bool OutOfOrderPacket(Channel c)
		{
			return false;
		}
	}
}
