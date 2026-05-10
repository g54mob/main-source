using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Broadcast;
using FishNet.Component.ColliderRollback;
using FishNet.Component.Observing;
using FishNet.Component.Ownership;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Client;
using FishNet.Managing.Observing;
using FishNet.Managing.Predicting;
using FishNet.Managing.Scened;
using FishNet.Managing.Server;
using FishNet.Managing.Timing;
using FishNet.Managing.Transporting;
using FishNet.Observing;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Object
{
	[DisallowMultipleComponent]
	public class NetworkObject : MonoBehaviour
	{
		public delegate void HostVisibilityUpdatedDelegate(bool prevVisible, bool nextVisible);

		[NonSerialized]
		internal bool ActiveDuringEdit;

		[HideInInspector]
		[SerializeField]
		private NetworkBehaviour[] _networkBehaviours;

		[HideInInspector]
		[SerializeField]
		internal TransformProperties SerializedTransformProperties;

		[NonSerialized]
		internal NetworkObjectState State;

		[SerializeField]
		[Tooltip("True if the object will always initialize as a networked object. When false the object will not automatically initialize over the network. Using Spawn() on an object will always set that instance as networked.")]
		private bool _isNetworked;

		[SerializeField]
		[Tooltip("True to make this object global, and added to the DontDestroyOnLoad scene. This value may only be set for instantiated objects, and can be changed if done immediately after instantiating.")]
		private bool _isGlobal;

		[Tooltip("Order to initialize this object's callbacks when spawned with other NetworkObjects in the same tick. Default value is 0, negative values will execute callbacks first.")]
		[SerializeField]
		private sbyte _initializeOrder;

		[Tooltip("How to handle this object when it despawns. Scene objects are never destroyed when despawning.")]
		[SerializeField]
		private DespawnType _defaultDespawnType;

		private bool _disabledNetworkBehavioursInitialized;

		public const int UNSET_OBJECTID_VALUE = 65535;

		public const int UNSET_PREFABID_VALUE = 65535;

		[HideInInspector]
		public NetworkObserver NetworkObserver;

		[HideInInspector]
		public HashSet<NetworkConnection> Observers;

		internal GridEntry HashGridEntry;

		private bool _networkObserverInitiliazed;

		[NonSerialized]
		private Renderer[] _renderers;

		private bool _renderersPopulated;

		private bool _lastClientHostVisibility;

		private HashGrid _hashGrid;

		private float _nextHashGridUpdateTime;

		private bool _isStatic;

		private Vector2Int _hashGridPosition;

		private NetworkConnection _owner;

		[SerializeField]
		[HideInInspector]
		private uint _scenePathHash;

		private List<ushort> _rpcLinkIndexes;

		[field: HideInInspector]
		[field: SerializeField]
		public bool IsNested { get; private set; }

		public NetworkConnection PredictedSpawner { get; private set; }

		public bool IsSceneObject => false;

		[field: HideInInspector]
		[field: SerializeField]
		public byte ComponentIndex { get; private set; }

		public int ObjectId { get; private set; }

		internal bool IsDeinitializing { get; private set; }

		[field: SerializeField]
		[field: HideInInspector]
		public PredictedSpawn PredictedSpawn { get; private set; }

		public NetworkBehaviour[] NetworkBehaviours
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		[field: SerializeField]
		[field: HideInInspector]
		public NetworkObject ParentNetworkObject { get; private set; }

		[field: SerializeField]
		[field: HideInInspector]
		public List<NetworkObject> ChildNetworkObjects { get; private set; }

		[HideInInspector]
		public NetworkObject RuntimeParentNetworkObject { get; private set; }

		[HideInInspector]
		internal NetworkObject CurrentParentNetworkObject => null;

		public Transform RuntimeParentTransform { get; private set; }

		[HideInInspector]
		public List<NetworkObject> RuntimeChildNetworkObjects { get; private set; }

		public bool IsNetworked
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool IsGlobal
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		internal bool AllowPredictedSpawning => false;

		internal bool AllowPredictedDespawning => false;

		internal bool AllowPredictedSyncTypes => false;

		public bool IsClientInitialized { get; private set; }

		[Obsolete("Use IsClientInitialized.")]
		public bool ClientInitialized => false;

		public bool IsClient => false;

		public bool IsClientOnly => false;

		public bool IsServerInitialized { get; private set; }

		public bool IsServer => false;

		public bool IsServerOnly => false;

		public bool IsHost => false;

		public bool IsOffline => false;

		public bool IsOwner => false;

		public NetworkConnection Owner
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public int OwnerId => 0;

		public bool IsSpawned => false;

		public NetworkConnection LocalConnection => null;

		public NetworkManager NetworkManager { get; private set; }

		public ServerManager ServerManager { get; private set; }

		public ClientManager ClientManager { get; private set; }

		public ObserverManager ObserverManager { get; private set; }

		public TransportManager TransportManager { get; private set; }

		public TimeManager TimeManager { get; private set; }

		public FishNet.Managing.Scened.SceneManager SceneManager { get; private set; }

		public PredictionManager PredictionManager { get; private set; }

		public RollbackManager RollbackManager { get; private set; }

		[field: HideInInspector]
		[field: SerializeField]
		public ushort PrefabId { get; internal set; }

		[field: SerializeField]
		[field: HideInInspector]
		public ushort SpawnableCollectionId { get; internal set; }

		[field: SerializeField]
		[field: HideInInspector]
		internal ulong SceneId { get; private set; }

		[field: SerializeField]
		[field: HideInInspector]
		public ulong AssetPathHash { get; private set; }

		public event HostVisibilityUpdatedDelegate OnHostVisibilityUpdated
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

		public event Action<NetworkObject> OnObserversActive
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

		public void Broadcast<T>(T message, bool requireAuthenticated = true, Channel channel = Channel.Reliable) where T : struct, IBroadcast
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InitializeCallbacks(bool asServer, bool invokeSyncTypeCallbacks)
		{
		}

		internal void InvokeOnStartSyncTypeCallbacks(bool asServer)
		{
		}

		internal void InvokeOnStopSyncTypeCallbacks(bool asServer)
		{
		}

		internal void OnSpawnServer(NetworkConnection conn)
		{
		}

		internal void InvokeOnServerDespawn(NetworkConnection conn)
		{
		}

		internal void InvokeStopCallbacks(bool asServer)
		{
		}

		private void InvokeOwnership(NetworkConnection prevOwner, bool asServer)
		{
		}

		public void SetIsNetworked(bool value)
		{
		}

		public void SetIsGlobal(bool value)
		{
		}

		public sbyte GetInitializeOrder()
		{
			return 0;
		}

		public DespawnType GetDefaultDespawnType()
		{
			return default(DespawnType);
		}

		public void SetDefaultDespawnType(DespawnType despawnType)
		{
		}

		public override string ToString()
		{
			return null;
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public void PrintNOBs()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeNetworkBehavioursIfDisabled()
		{
		}

		private void SetChildGlobalState()
		{
		}

		private void SetChildDespawnedState()
		{
		}

		internal void TryStartDeactivation()
		{
		}

		internal void SetInitializedStatus(bool isInitialized, bool asServer)
		{
		}

		private void SetDeinitializedStatus()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Preinitialize_Internal(NetworkManager networkManager, int objectId, NetworkConnection owner, bool asServer)
		{
		}

		public void SetParent(NetworkBehaviour nb)
		{
		}

		public void SetParent(NetworkObject nob)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UnsetParent()
		{
		}

		private void UpdateParent(NetworkObject nob, NetworkBehaviour nb)
		{
		}

		private bool InvalidParent(NetworkObject nob)
		{
			return false;
		}

		internal T AddAndSerialize<T>() where T : NetworkBehaviour
		{
			return null;
		}

		internal void UpdateNetworkBehaviours(NetworkObject parentNob, ref byte componentIndex)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Initialize(bool asServer, bool invokeSyncTypeCallbacks)
		{
		}

		internal void Deinitialize(bool asServer)
		{
		}

		[Obsolete("This is no longer used. Remove any calls to this method.")]
		public void ResetForObjectPool()
		{
		}

		public void ResetState()
		{
		}

		public void RemoveOwnership()
		{
		}

		public void GiveOwnership(NetworkConnection newOwner)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void GiveOwnership(NetworkConnection newOwner, bool asServer)
		{
		}

		internal void InitializePredictedObject_Server(NetworkManager manager, NetworkConnection predictedSpawner)
		{
		}

		internal void PreinitializePredictedObject_Client(NetworkManager manager, int objectId, NetworkConnection owner, NetworkConnection predictedSpawner)
		{
		}

		internal void DeinitializePredictedObject_Client()
		{
		}

		private void SetOwner(NetworkConnection owner)
		{
		}

		internal ChangedTransformProperties GetTransformChanges(TransformProperties stp)
		{
			return default(ChangedTransformProperties);
		}

		internal ChangedTransformProperties GetTransformChanges(GameObject prefab)
		{
			return default(ChangedTransformProperties);
		}

		internal void UpdateForNetworkObject(bool force)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UpdateRenderers(bool updateVisibility = true)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetRenderersVisible(bool visible, bool force = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateRenderers_Internal(bool updateVisibility)
		{
		}

		private void UpdateRenderVisibility(bool visible)
		{
		}

		private void AddDefaultNetworkObserverConditions()
		{
		}

		internal bool RemoveObserver(NetworkConnection connection)
		{
			return false;
		}

		internal ObserverStateChange RebuildObservers(NetworkConnection connection, bool timedOnly)
		{
			return default(ObserverStateChange);
		}

		private void TryInvokeOnObserversActive(int startCount)
		{
		}

		public NetworkBehaviour GetNetworkBehaviour(byte componentIndex, bool error)
		{
			return null;
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

		public void SetLocalOwnership(NetworkConnection caller)
		{
		}

		public void RegisterInvokeOnInstance<T>(Action<UnityEngine.Component> handler) where T : UnityEngine.Component
		{
		}

		public void UnregisterInvokeOnInstance<T>(Action<UnityEngine.Component> handler) where T : UnityEngine.Component
		{
		}

		public bool HasInstance<T>() where T : UnityEngine.Component
		{
			return false;
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

		public bool TryGetInstance<T>(out T component) where T : UnityEngine.Component
		{
			component = null;
			return false;
		}

		public void UnregisterInstance<T>() where T : UnityEngine.Component
		{
		}

		public void SetAssetPathHash(ulong value)
		{
		}

		internal void ClearRuntimeSceneObject()
		{
		}

		internal void SetRpcLinkIndexes(List<ushort> values)
		{
		}

		internal void RemoveClientRpcLinkIndexes()
		{
		}

		internal void WriteDirtySyncTypes()
		{
		}
	}
}
