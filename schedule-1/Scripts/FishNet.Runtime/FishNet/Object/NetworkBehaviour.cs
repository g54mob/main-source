using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Component.ColliderRollback;
using FishNet.Connection;
using FishNet.Documenting;
using FishNet.Managing;
using FishNet.Managing.Client;
using FishNet.Managing.Logging;
using FishNet.Managing.Observing;
using FishNet.Managing.Predicting;
using FishNet.Managing.Scened;
using FishNet.Managing.Server;
using FishNet.Managing.Timing;
using FishNet.Managing.Transporting;
using FishNet.Object.Delegating;
using FishNet.Object.Prediction;
using FishNet.Object.Prediction.Delegating;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Observing;
using FishNet.Serializing;
using FishNet.Serializing.Helping;
using FishNet.Transporting;
using FishNet.Utility.Performance;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Object
{
	public abstract class NetworkBehaviour : MonoBehaviour
	{
		private struct BufferedRpc
		{
			public PooledWriter Writer;

			public Channel Channel;

			public DataOrderType OrderType;

			public BufferedRpc(PooledWriter writer, Channel channel, DataOrderType orderType)
			{
				Writer = null;
				Channel = default(Channel);
				OrderType = default(DataOrderType);
			}
		}

		private class SyncTypeWriter
		{
			public ReadPermission ReadPermission;

			public PooledWriter[] Writers { get; private set; }

			public SyncTypeWriter(ReadPermission readPermission)
			{
			}

			public void Reset()
			{
			}
		}

		private bool _onStartNetworkCalled;

		private bool _onStopNetworkCalled;

		[HideInInspector]
		[SerializeField]
		private byte _componentIndexCache;

		private TransportManager _transportManagerCache;

		[SerializeField]
		[HideInInspector]
		private NetworkObject _networkObjectCache;

		private bool _initializedOnceServer;

		private bool _initializedOnceClient;

		internal bool ClientHasReconcileData;

		private uint _lastReplicateTick;

		private readonly Dictionary<uint, ReplicateRpcDelegate> _replicateRpcDelegates;

		private readonly Dictionary<uint, ReconcileRpcDelegate> _reconcileRpcDelegates;

		private bool _predictionInitialized;

		private Rigidbody _predictionRigidbody;

		private Rigidbody2D _predictionRigidbody2d;

		private Vector3 _lastMayChangePosition;

		private Quaternion _lastMayChangeRotation;

		private Vector3 _lastMayChangeScale;

		private int _remainingResends;

		private uint _lastSentReplicateTick;

		private uint _lastReceivedReplicateTick;

		private uint _lastReceivedReconcileTick;

		private uint _lastReconcileTick;

		private Dictionary<uint, RpcLinkType> _rpcLinks;

		private readonly Dictionary<uint, ServerRpcDelegate> _serverRpcDelegates;

		private readonly Dictionary<uint, ClientRpcDelegate> _observersRpcDelegates;

		private readonly Dictionary<uint, ClientRpcDelegate> _targetRpcDelegates;

		private uint _rpcMethodCount;

		private byte _rpcHashSize;

		private Dictionary<uint, BufferedRpc> _bufferedRpcs;

		private HashSet<NetworkConnection> _networkConnectionCache;

		private const int MAXIMUM_RPC_HEADER_SIZE = 10;

		private SyncTypeWriter[] _syncTypeWriters;

		private Dictionary<uint, SyncBase> _syncVars;

		internal bool SyncVarDirty;

		private Dictionary<uint, SyncBase> _syncObjects;

		internal bool SyncObjectDirty;

		private static ReadPermission[] _readPermissions;

		private List<SyncVarReadDelegate> _syncVarReadDelegates;

		[APIExclude]
		public bool OnStartServerCalled { get; private set; }

		[APIExclude]
		public bool OnStartClientCalled { get; private set; }

		public bool IsSpawned => false;

		public byte ComponentIndex
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public NetworkObject NetworkObject => null;

		public bool IsReconciling { get; internal set; }

		public bool IsDeinitializing => false;

		public NetworkManager NetworkManager => null;

		public ServerManager ServerManager => null;

		public ClientManager ClientManager => null;

		public ObserverManager ObserverManager => null;

		public TransportManager TransportManager => null;

		public TimeManager TimeManager => null;

		public FishNet.Managing.Scened.SceneManager SceneManager => null;

		public PredictionManager PredictionManager => null;

		public RollbackManager RollbackManager => null;

		public NetworkObserver NetworkObserver => null;

		public bool IsClientInitialized => false;

		public bool IsClient => false;

		public bool IsClientOnly => false;

		public bool IsServerInitialized => false;

		public bool IsServer => false;

		public bool IsServerOnly => false;

		public bool IsHost => false;

		public bool IsOffline => false;

		public bool IsNetworked => false;

		public HashSet<NetworkConnection> Observers => null;

		public bool IsOwner => false;

		public NetworkConnection Owner => null;

		public int OwnerId => 0;

		public int ObjectId => 0;

		public NetworkConnection LocalConnection => null;

		internal void InvokeSyncTypeOnStartCallbacks(bool asServer)
		{
		}

		internal void InvokeSyncTypeOnStopCallbacks(bool asServer)
		{
		}

		internal void InvokeOnNetwork(bool start)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnStartNetwork_Internal()
		{
		}

		public virtual void OnStartNetwork()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnStopNetwork_Internal()
		{
		}

		public virtual void OnStopNetwork()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnStartServer_Internal()
		{
		}

		public virtual void OnStartServer()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnStopServer_Internal()
		{
		}

		public virtual void OnStopServer()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnOwnershipServer_Internal(NetworkConnection prevOwner)
		{
		}

		public virtual void OnOwnershipServer(NetworkConnection prevOwner)
		{
		}

		public virtual void OnSpawnServer(NetworkConnection connection)
		{
		}

		public virtual void OnDespawnServer(NetworkConnection connection)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnStartClient_Internal()
		{
		}

		public virtual void OnStartClient()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnStopClient_Internal()
		{
		}

		public virtual void OnStopClient()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnOwnershipClient_Internal(NetworkConnection prevOwner)
		{
		}

		public virtual void OnOwnershipClient(NetworkConnection prevOwner)
		{
		}

		public override string ToString()
		{
			return null;
		}

		internal void Preinitialize_Internal(NetworkObject nob, bool asServer)
		{
		}

		internal void Deinitialize(bool asServer)
		{
		}

		internal void SerializeComponents(NetworkObject nob, byte componentIndex)
		{
		}

		internal void InitializeIfDisabled()
		{
		}

		[APIExclude]
		[CodegenMakePublic]
		public virtual void NetworkInitializeIfDisabled()
		{
		}

		protected virtual void Reset()
		{
		}

		protected virtual void OnValidate()
		{
		}

		internal void ResetState()
		{
		}

		private NetworkObject TryAddNetworkObject()
		{
			return null;
		}

		public bool CanLog(LoggingType loggingType)
		{
			return false;
		}

		public uint GetLastReconcileTick()
		{
			return 0u;
		}

		internal void SetLastReconcileTick(uint value, bool updateGlobals = true)
		{
		}

		public uint GetLastReplicateTick()
		{
			return 0u;
		}

		private void SetLastReplicateTick(uint value, bool updateGlobals = true)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenMakePublic]
		public void RegisterReplicateRpc(uint hash, ReplicateRpcDelegate del)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenMakePublic]
		public void RegisterReconcileRpc(uint hash, ReconcileRpcDelegate del)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnReplicateRpc(uint? methodHash, PooledReader reader, NetworkConnection sendingClient, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnReconcileRpc(uint? methodHash, PooledReader reader, Channel channel)
		{
		}

		public void ClearReplicateCache(bool asServer)
		{
		}

		public void ClearReplicateCache()
		{
		}

		[CodegenMakePublic]
		public virtual void ClearReplicateCache_Virtual(bool asServer)
		{
		}

		private void ResetLastPredictionTicks()
		{
		}

		private void Owner_SendReplicateRpc<T>(uint hash, List<T> replicates, Channel channel) where T : IReplicateData
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Server_SendReconcileRpc<T>(uint hash, T reconcileData, Channel channel)
		{
		}

		protected internal bool PredictedTransformMayChange()
		{
			return false;
		}

		[CodegenMakePublic]
		public bool Replicate_ExitEarly_A(bool asServer, bool replaying, bool allowServerControl)
		{
			return false;
		}

		[CodegenMakePublic]
		public void Replicate_NonOwner<T>(ReplicateUserLogicDelegate<T> del, BasicQueue<T> q, T serverControlData, bool allowServerControl, Channel channel) where T : IReplicateData
		{
		}

		[CodegenMakePublic]
		public void Replicate_Owner<T>(ReplicateUserLogicDelegate<T> del, uint methodHash, List<T> replicates, T data, Channel channel) where T : IReplicateData
		{
		}

		[CodegenMakePublic]
		public void Replicate_Reader<T>(PooledReader reader, NetworkConnection sender, T[] arrBuffer, BasicQueue<T> replicates, Channel channel) where T : IReplicateData
		{
		}

		private void Replicate_HandleReceivedReplicate<T>(int receivedReplicatesCount, T[] arrBuffer, BasicQueue<T> replicates, Channel channel) where T : IReplicateData
		{
		}

		[CodegenMakePublic]
		public bool Reconcile_ExitEarly_A(bool asServer, out Channel channel)
		{
			channel = default(Channel);
			return false;
		}

		[CodegenMakePublic]
		public void Reconcile_Server<T>(uint methodHash, T data, Channel channel) where T : IReconcileData
		{
		}

		[CodegenMakePublic]
		public void Reconcile_Client<T, T2>(ReconcileUserLogicDelegate<T> reconcileDel, ReplicateUserLogicDelegate<T2> replicateULDel, List<T2> replicates, T data, Channel channel) where T : IReconcileData where T2 : IReplicateData
		{
		}

		public void Reconcile_Reader<T>(PooledReader reader, ref T data, Channel channel) where T : IReconcileData
		{
		}

		public bool OwnerMatches(NetworkConnection connection)
		{
			return false;
		}

		public void Despawn(GameObject go, DespawnType? despawnType = null)
		{
		}

		public void Despawn(NetworkObject nob, DespawnType? despawnType = null)
		{
		}

		public void Despawn(DespawnType? despawnType = null)
		{
		}

		public void Spawn(GameObject go, NetworkConnection ownerConnection = null, Scene scene = default(Scene))
		{
		}

		public void Spawn(NetworkObject nob, NetworkConnection ownerConnection = null, Scene scene = default(Scene))
		{
		}

		private bool IsNetworkObjectNull(bool warn)
		{
			return false;
		}

		public void RemoveOwnership()
		{
		}

		public void GiveOwnership(NetworkConnection newOwner)
		{
		}

		public void RegisterInvokeOnInstance<T>(Action<UnityEngine.Component> handler) where T : UnityEngine.Component
		{
		}

		public void UnregisterInvokeOnInstance<T>(Action<UnityEngine.Component> handler) where T : UnityEngine.Component
		{
		}

		public T GetInstance<T>() where T : UnityEngine.Component
		{
			return null;
		}

		public void RegisterInstance<T>(T component, bool replace = true) where T : UnityEngine.Component
		{
		}

		public bool TryRegisterInstance<T>(T component) where T : UnityEngine.Component
		{
			return false;
		}

		public void UnregisterInstance<T>() where T : UnityEngine.Component
		{
		}

		private void InitializeRpcLinks()
		{
		}

		private int GetEstimatedRpcHeaderLength()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private PooledWriter CreateLinkedRpc(RpcLinkType link, PooledWriter methodWriter, Channel channel)
		{
			return null;
		}

		private void ReturnRpcLinks()
		{
		}

		internal void WriteRpcLinks(Writer writer)
		{
		}

		internal void SendBufferedRpcs(NetworkConnection conn)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenMakePublic]
		[APIExclude]
		public void RegisterServerRpc(uint hash, ServerRpcDelegate del)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		[CodegenMakePublic]
		public void RegisterObserversRpc(uint hash, ClientRpcDelegate del)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenMakePublic]
		[APIExclude]
		public void RegisterTargetRpc(uint hash, ClientRpcDelegate del)
		{
		}

		private void IncreaseRpcMethodCount()
		{
		}

		public void ClearBuffedRpcs()
		{
		}

		private uint ReadRpcHash(PooledReader reader)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnServerRpc(PooledReader reader, NetworkConnection sendingClient, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnObserversRpc(uint? methodHash, PooledReader reader, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void OnTargetRpc(uint? methodHash, PooledReader reader, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenMakePublic]
		public void SendServerRpc(uint hash, PooledWriter methodWriter, Channel channel, DataOrderType orderType)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		[CodegenMakePublic]
		public void SendObserversRpc(uint hash, PooledWriter methodWriter, Channel channel, DataOrderType orderType, bool bufferLast, bool excludeServer, bool excludeOwner)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[CodegenMakePublic]
		public void SendTargetRpc(uint hash, PooledWriter methodWriter, Channel channel, DataOrderType orderType, NetworkConnection target, bool excludeServer, bool validateTarget = true)
		{
		}

		private void SetNetworkConnectionCache(bool addClientHost, bool addOwner)
		{
		}

		private bool IsSpawnedWithWarning()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private PooledWriter CreateRpc(uint hash, PooledWriter methodWriter, PacketId packetId, Channel channel)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void WriteRpcHash(uint hash, PooledWriter writer)
		{
		}

		[CodegenMakePublic]
		public void RegisterSyncVarRead(SyncVarReadDelegate del)
		{
		}

		internal void RegisterSyncType(SyncBase sb, uint index)
		{
		}

		internal bool DirtySyncType(bool isSyncObject)
		{
			return false;
		}

		private void InitializeOnceSyncTypes(bool asServer)
		{
		}

		internal void OnSyncType(PooledReader reader, int length, bool isSyncObject, bool asServer = false)
		{
		}

		internal bool WriteDirtySyncTypes(bool isSyncObject, bool ignoreInterval = false)
		{
			return false;
		}

		internal void SyncTypes_ResetState()
		{
		}

		[CodegenMakePublic]
		public virtual void ResetSyncVarFields()
		{
		}

		internal void WriteSyncTypesForSpawn(PooledWriter writer, NetworkConnection conn)
		{
		}

		[Obsolete("This method does not function.")]
		protected void DirtySyncType(object syncType)
		{
		}
	}
}
