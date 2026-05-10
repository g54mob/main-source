using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Broadcast;
using FishNet.Component.Observing;
using FishNet.Documenting;
using FishNet.Managing;
using FishNet.Managing.Logging;
using FishNet.Managing.Server;
using FishNet.Managing.Timing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using GameKit.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Connection
{
	public class NetworkConnection : IEquatable<NetworkConnection>
	{
		public class LevelOfDetailData : IResettable
		{
			public byte CurrentLevelOfDetail;

			public byte PreviousLevelOfDetail;

			internal void Update(byte lodLevel)
			{
			}

			public void ResetState()
			{
			}

			public void InitializeState()
			{
			}
		}

		private List<PacketBundle> _toClientBundles;

		private bool _serverDirtied;

		private bool _loadedStartScenesAsServer;

		private bool _loadedStartScenesAsClient;

		internal Queue<int> PredictedObjectIds;

		public int ClientId;

		public HashSet<NetworkObject> Objects;

		public object CustomData;

		internal uint ServerConnectionTick;

		public EstimatedTick PacketTick;

		public EstimatedTick LocalTick;

		public const int UNSET_CLIENTID_VALUE = -1;

		public Dictionary<NetworkObject, LevelOfDetailData> LevelOfDetails;

		internal int AllowedForcedLodUpdates;

		internal uint LastLevelOfDetailUpdate;

		internal int LevelOfDetailInfractions;

		internal GridEntry HashGridEntry;

		private HashGrid _hashGrid;

		private float _nextHashGridUpdateTime;

		private Vector2Int _hashGridPosition;

		private uint _lastPingTick;

		private uint _requiredPingTicks;

		private const byte EXCESSIVE_PING_LIMIT = 10;

		private MovingAverage _replicateQueueAverage;

		private uint _lastAverageQueueAddTick;

		public NetworkManager NetworkManager { get; private set; }

		public int TransportIndex { get; internal set; }

		public bool Authenticated { get; private set; }

		public bool IsActive => false;

		public bool IsValid => false;

		public NetworkObject FirstObject { get; private set; }

		public HashSet<Scene> Scenes { get; private set; }

		public bool Disconnecting { get; private set; }

		internal uint DisconnectingTick { get; private set; }

		[Obsolete("Use LocalTick instead.")]
		public uint Tick => 0u;

		public uint LocalReplicateTick { get; internal set; }

		public bool IsHost => false;

		public bool IsLocalClient => false;

		public event Action<NetworkConnection, bool> OnLoadedStartScenes
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

		public event Action<NetworkObject> OnObjectAdded
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

		public event Action<NetworkObject> OnObjectRemoved
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

		private void InitializeBuffer()
		{
		}

		public void Broadcast<T>(T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		internal void SendToClient(byte channel, ArraySegment<byte> segment, bool forceNewBuffer = false, DataOrderType orderType = DataOrderType.Default)
		{
		}

		internal bool GetPacketBundle(int channel, out PacketBundle packetBundle)
		{
			packetBundle = null;
			return false;
		}

		private void ServerDirty()
		{
		}

		internal void ResetServerDirty()
		{
		}

		public bool LoadedStartScenes()
		{
			return false;
		}

		public bool LoadedStartScenes(bool asServer)
		{
			return false;
		}

		public void SetFirstObject(NetworkObject nob)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NetworkConnection nc)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(NetworkConnection a, NetworkConnection b)
		{
			return false;
		}

		public static bool operator !=(NetworkConnection a, NetworkConnection b)
		{
			return false;
		}

		[APIExclude]
		public NetworkConnection()
		{
		}

		[APIExclude]
		public NetworkConnection(NetworkManager manager, int clientId, int transportIndex, bool asServer)
		{
		}

		internal void Dispose()
		{
		}

		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Initialize(NetworkManager nm, int clientId, int transportIndex, bool asServer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Deinitialize()
		{
		}

		internal void SetDisconnecting(bool value)
		{
		}

		public void Disconnect(bool immediately)
		{
		}

		internal bool SetLoadedStartScenes(bool asServer)
		{
			return false;
		}

		internal void ConnectionAuthenticated()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void AddObject(NetworkObject nob)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void RemoveObject(NetworkObject nob)
		{
		}

		private void ClearObjects()
		{
		}

		private void SetFirstObject()
		{
		}

		internal bool AddToScene(Scene scene)
		{
			return false;
		}

		internal bool RemoveFromScene(Scene scene)
		{
			return false;
		}

		internal bool IsLateForLevelOfDetail(uint expectedInterval)
		{
			return false;
		}

		private void ResetStates_Lod()
		{
		}

		private void Observers_FirstObjectChanged()
		{
		}

		private void Observers_Initialize(NetworkManager nm)
		{
		}

		internal void UpdateHashGridPositions(bool force)
		{
		}

		private void Observers_Reset()
		{
		}

		private void InitializePing()
		{
		}

		private void ResetPingPong()
		{
		}

		internal bool CanPingPong()
		{
			return false;
		}

		internal void Prediction_Initialize(NetworkManager manager, bool asServer)
		{
		}

		internal void AddAverageQueueCount(ushort value, uint tick)
		{
		}

		internal ushort GetAndResetAverageQueueCount()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Prediction_Reset()
		{
		}

		public string GetAddress()
		{
			return null;
		}

		public void Kick(KickReason kickReason, LoggingType loggingType = LoggingType.Common, string log = "")
		{
		}

		public void Kick(Reader reader, KickReason kickReason, LoggingType loggingType = LoggingType.Common, string log = "")
		{
		}
	}
}
