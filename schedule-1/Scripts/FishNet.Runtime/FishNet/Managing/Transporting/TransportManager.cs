using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Managing.Transporting
{
	[AddComponentMenu("FishNet/Manager/TransportManager")]
	[DisallowMultipleComponent]
	public sealed class TransportManager : MonoBehaviour
	{
		private struct DisconnectingClient
		{
			public uint Tick;

			public NetworkConnection Connection;

			public DisconnectingClient(uint tick, NetworkConnection connection)
			{
				Tick = 0u;
				Connection = null;
			}
		}

		[Tooltip("The current Transport being used.")]
		public Transport Transport;

		[Tooltip("Layer used to modify data before it is sent or received.")]
		[SerializeField]
		private IntermediateLayer _intermediateLayer;

		[SerializeField]
		[Tooltip("Latency simulation settings.")]
		private LatencySimulator _latencySimulator;

		private List<NetworkConnection> _dirtyToClients;

		private List<PacketBundle> _toServerBundles;

		private NetworkManager _networkManager;

		private List<DisconnectingClient> _disconnectingClients;

		private int[] _lowestMtu;

		private HashSet<NetworkConnection> _networkConnectionHashSet;

		public const byte PACKET_ID_BYTES = 2;

		public const byte OBJECT_ID_BYTES = 2;

		public const byte COMPONENT_INDEX_BYTES = 1;

		public const byte TICK_BYTES = 4;

		private const byte SPLIT_COUNT_BYTES = 4;

		public const byte SPLIT_INDICATOR_SIZE = 6;

		public const byte CHANNEL_COUNT = 2;

		public bool HasIntermediateLayer => false;

		public LatencySimulator LatencySimulator => null;

		internal event Action OnIterateOutgoingStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal event Action OnIterateOutgoingEnd
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal event Action<bool> OnIterateIncomingStart
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal event Action<bool> OnIterateIncomingEnd
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
		}

		internal void ServerDirty(NetworkConnection conn)
		{
		}

		private void InitializeToServerBundles()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetLowestMTU(byte channel)
		{
			return 0;
		}

		public int GetMTU(byte channel)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetMTU(int transportIndex, byte channel)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetMTU<T>(byte channel) where T : Transport
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ArraySegment<byte> ProcessIntermediateIncoming(ArraySegment<byte> src, bool fromServer)
		{
			return default(ArraySegment<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private ArraySegment<byte> ProcessIntermediateOutgoing(ArraySegment<byte> src, bool toServer)
		{
			return default(ArraySegment<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SendToClient(byte channelId, ArraySegment<byte> segment, NetworkConnection connection, bool splitLargeMessages = true, DataOrderType orderType = DataOrderType.Default)
		{
		}

		private void SendToClient(byte channelId, ArraySegment<byte> segment, NetworkConnection connection, int requiredSplitMessages, int maxSplitMessageSize, DataOrderType orderType = DataOrderType.Default)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SendToClients(byte channelId, ArraySegment<byte> segment, HashSet<NetworkConnection> observers, NetworkConnection excludedConnection = null, bool splitLargeMessages = true, DataOrderType orderType = DataOrderType.Default)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SendToClients(byte channelId, ArraySegment<byte> segment, HashSet<NetworkConnection> observers, HashSet<NetworkConnection> excludedConnections = null, bool splitLargeMessages = true, DataOrderType orderType = DataOrderType.Default)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SendToClients(byte channelId, ArraySegment<byte> segment, HashSet<NetworkConnection> observers, HashSet<NetworkConnection> excludedConnections, int requiredSplitMessages, int maxSplitMessageSize, DataOrderType orderType = DataOrderType.Default)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SendToClients(byte channelId, ArraySegment<byte> segment, bool splitLargeMessages = true)
		{
		}

		private void SendToClients_Internal(byte channelId, ArraySegment<byte> segment, int requiredSplitMessages, int maxSplitMessageSize)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SendToServer(byte channelId, ArraySegment<byte> segment, bool splitLargeMessages = true, DataOrderType orderType = DataOrderType.Default)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SendToServer(byte channelId, ArraySegment<byte> segment, int requiredSplitMessages, int maxSplitMessageSize, DataOrderType orderType)
		{
		}

		private void SetSplitValues(byte channelId, ArraySegment<byte> segment, bool split, out int requiredSplitMessages, out int maxSplitMessageSize)
		{
			requiredSplitMessages = default(int);
			maxSplitMessageSize = default(int);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void CheckSetReliableChannel(int dataLength, ref Channel channel)
		{
		}

		private int GetRequiredMessageCount(byte channelId, int segmentSize, out int maxMessageSize)
		{
			maxMessageSize = default(int);
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool SplitRequired(byte channelId, int segmentSize, out int requiredMessages, out int maxMessageSize)
		{
			requiredMessages = default(int);
			maxMessageSize = default(int);
			return false;
		}

		private void SendSplitData(NetworkConnection conn, ref ArraySegment<byte> segment, int requiredMessages, int maxMessageSize, DataOrderType orderType)
		{
		}

		internal void IterateIncoming(bool server)
		{
		}

		internal void IterateOutgoing(bool toServer)
		{
		}

		public bool IsLocalTransport(int connectionId)
		{
			return false;
		}

		public Transport GetTransport(int index)
		{
			return null;
		}

		public T GetTransport<T>() where T : Transport
		{
			return null;
		}
	}
}
