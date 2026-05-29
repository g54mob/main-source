using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Authenticating;
using FishNet.Component.ColliderRollback;
using FishNet.Connection;
using FishNet.Documenting;
using FishNet.Managing.Client;
using FishNet.Managing.Debugging;
using FishNet.Managing.Logging;
using FishNet.Managing.Object;
using FishNet.Managing.Observing;
using FishNet.Managing.Predicting;
using FishNet.Managing.Scened;
using FishNet.Managing.Server;
using FishNet.Managing.Statistic;
using FishNet.Managing.Timing;
using FishNet.Managing.Transporting;
using FishNet.Object;
using FishNet.Utility.Performance;
using UnityEngine;

namespace FishNet.Managing
{
	[DefaultExecutionOrder(-32768)]
	[DisallowMultipleComponent]
	[AddComponentMenu("FishNet/Manager/NetworkManager")]
	public sealed class NetworkManager : MonoBehaviour
	{
		public enum HostIterationOrder
		{
			ServerFirst = 0,
			ClientFirst = 1
		}

		public enum PersistenceType
		{
			DestroyNewest = 0,
			DestroyOldest = 1,
			AllowMultiple = 2
		}

		private static List<NetworkManager> _instances;

		public static bool FastEnterPlayMode;

		internal static ushort StartingRpcLinkIndex;

		[SerializeField]
		[Tooltip("True to refresh the DefaultPrefabObjects collection whenever the editor enters play mode. This is an attempt to alleviate the DefaultPrefabObjects scriptable object not refreshing when using multiple editor applications such as ParrelSync.")]
		private bool _refreshDefaultPrefabs;

		[SerializeField]
		[Tooltip("True to have your application run while in the background.")]
		private bool _runInBackground;

		[Tooltip("True to make this instance DontDestroyOnLoad. This is typical if you only want one NetworkManager.")]
		[SerializeField]
		private bool _dontDestroyOnLoad;

		[SerializeField]
		[Tooltip("Object pool to use for this NetworkManager. Value may be null.")]
		private ObjectPool _objectPool;

		[SerializeField]
		[Tooltip("How to persist when other NetworkManagers are introduced.")]
		private PersistenceType _persistence;

		private bool _canPersist;

		internal const ushort MAXIMUM_FRAMERATE = 500;

		[SerializeField]
		[Tooltip("Logging configuration to use. When empty default logging settings will be used.")]
		private LoggingConfiguration _logging;

		private const string ERROR_LOGGING_PREFIX = "Error - ";

		private const string WARNING_LOGGING_PREFIX = "Warning - ";

		private const string COMMON_LOGGING_PREFIX = "Log - ";

		[Tooltip("Collection to use for spawnable objects.")]
		[SerializeField]
		private PrefabObjects _spawnablePrefabs;

		private Dictionary<ushort, PrefabObjects> _runtimeSpawnablePrefabs;

		private Dictionary<string, List<Action<UnityEngine.Component>>> _pendingInvokes;

		private Dictionary<string, UnityEngine.Component> _registeredComponents;

		public bool Initialized { get; private set; }

		public static IReadOnlyCollection<NetworkManager> Instances => null;

		public bool IsServer => false;

		public bool IsServerOnly => false;

		public bool IsClient => false;

		public bool IsClientOnly => false;

		public bool IsHost => false;

		public bool IsOffline => false;

		internal PredictionManager PredictionManager { get; private set; }

		public ServerManager ServerManager { get; private set; }

		public ClientManager ClientManager { get; private set; }

		public TransportManager TransportManager { get; private set; }

		public TimeManager TimeManager { get; private set; }

		public SceneManager SceneManager { get; private set; }

		public ObserverManager ObserverManager { get; private set; }

		[Obsolete("Use ServerManager.GetAuthenticator or ServerManager.SetAuthenticator instead.")]
		public Authenticator Authenticator => null;

		public DebugManager DebugManager { get; private set; }

		public StatisticsManager StatisticsManager { get; private set; }

		[APIExclude]
		public static NetworkConnection EmptyConnection { get; private set; }

		public ObjectPool ObjectPool => null;

		public RollbackManager RollbackManager { get; private set; }

		public PrefabObjects SpawnablePrefabs
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IReadOnlyDictionary<ushort, PrefabObjects> RuntimeSpawnablePrefabs => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeComponents()
		{
		}

		internal void UpdateFramerate()
		{
		}

		private void TimeManager_OnLateUpdate()
		{
		}

		private bool CanInitialize()
		{
			return false;
		}

		private bool ValidateSpawnablePrefabs(bool print)
		{
			return false;
		}

		private void SetDontDestroyOnLoad()
		{
		}

		private void SetRunInBackground()
		{
		}

		private T GetOrCreateComponent<T>(T presetValue = null) where T : UnityEngine.Component
		{
			return null;
		}

		internal void ClearClientsCollection(Dictionary<int, NetworkConnection> clients, int transportIndex = -1)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NetworkObject GetPooledInstantiated(NetworkObject prefab, bool asServer)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NetworkObject GetPooledInstantiated(NetworkObject prefab, Vector3 position, Quaternion rotation, bool asServer)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use GetPooledInstantiated(NetworkObject,bool).")]
		public NetworkObject GetPooledInstantiated(NetworkObject prefab, ushort collectionId, bool asServer)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public NetworkObject GetPooledInstantiated(GameObject prefab, bool asServer)
		{
			return null;
		}

		[Obsolete("Use GetPooledInstantiated(GameObject, bool).")]
		public NetworkObject GetPooledInstantiated(GameObject prefab, ushort collectionId, bool asServer)
		{
			return null;
		}

		public NetworkObject GetPooledInstantiated(GameObject prefab, Vector3 position, Quaternion rotation, bool asServer)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use GetPooledInstantiated(int, ushort, bool).")]
		public NetworkObject GetPooledInstantiated(int prefabId, bool asServer)
		{
			return null;
		}

		public NetworkObject GetPooledInstantiated(int prefabId, ushort collectionId, bool asServer)
		{
			return null;
		}

		public NetworkObject GetPooledInstantiated(int prefabId, ushort collectionId, Vector3 position, Quaternion rotation, bool asServer)
		{
			return null;
		}

		[Obsolete("Use StorePooledInstantiated(NetworkObject, bool)")]
		public void StorePooledInstantiated(NetworkObject instantiated, int prefabId, bool asServer)
		{
		}

		public void StorePooledInstantiated(NetworkObject instantiated, bool asServer)
		{
		}

		public void CacheObjects(NetworkObject prefab, int count, bool asServer)
		{
		}

		private void InitializeLogging()
		{
		}

		[APIExclude]
		public static bool StaticCanLog(LoggingType loggingType)
		{
			return false;
		}

		public bool CanLog(LoggingType loggingType)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public static void StaticLog(string value)
		{
		}

		public void Log(string value)
		{
		}

		public void Log(LoggingType loggingType, string value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public static void StaticLogWarning(string value)
		{
		}

		public void LogWarning(string value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public static void StaticLogError(string value)
		{
		}

		public void LogError(string value)
		{
		}

		public PrefabObjects GetPrefabObjects<T>(ushort spawnableCollectionId, bool createIfMissing) where T : PrefabObjects
		{
			return null;
		}

		public bool RemoveSpawnableCollection(ushort spawnableCollectionId)
		{
			return false;
		}

		public int GetPrefabIndex(GameObject prefab, bool asServer)
		{
			return 0;
		}

		public NetworkObject GetPrefab(int prefabId, bool asServer)
		{
			return null;
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

		[Obsolete("Use GetInstance() or TryGetInstance(T).")]
		public T GetInstance<T>(bool warn = true) where T : UnityEngine.Component
		{
			return null;
		}

		public bool TryGetInstance<T>(out T result) where T : UnityEngine.Component
		{
			result = null;
			return false;
		}

		public void RegisterInstance<T>(T component, bool replace = true) where T : UnityEngine.Component
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryRegisterInstance<T>(T component) where T : UnityEngine.Component
		{
			return false;
		}

		public void UnregisterInstance<T>() where T : UnityEngine.Component
		{
		}

		private void RemoveNullPendingDelegates()
		{
		}

		private string GetInstanceName<T>()
		{
			return null;
		}
	}
}
