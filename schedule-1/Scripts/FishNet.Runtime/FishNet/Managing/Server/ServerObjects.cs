using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Managing.Object;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Server
{
	public class ServerObjects : ManagedObjects
	{
		internal Dictionary<int, uint> RecentlyDespawnedIds;

		private Queue<int> _objectIdCache;

		private List<NetworkBehaviour> _dirtySyncVarBehaviours;

		private List<NetworkBehaviour> _dirtySyncObjectBehaviours;

		private Dictionary<int, NetworkObject> _pendingDestroy;

		private List<(int, Scene)> _loadedScenes;

		private List<NetworkObject> _spawnCache;

		private bool _scenesLoading;

		private List<NetworkObject> _observerChangedObjectsCache;

		private List<NetworkObject> _timedNetworkObservers;

		private int _nextTimedObserversIndex;

		private PooledWriter _writer;

		private uint _cleanRecentlyDespawnedMaxTicks => 0u;

		public event Action<NetworkConnection> OnPreDestroyClientObjects
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

		internal Queue<int> GetObjectIdCache()
		{
			return null;
		}

		internal ServerObjects(NetworkManager networkManager)
		{
		}

		private void TimeManager_OnUpdate()
		{
		}

		internal void WriteDirtySyncTypes()
		{
		}

		internal void SetDirtySyncType(NetworkBehaviour nb, bool isSyncObject)
		{
		}

		internal void OnServerConnectionState(ServerConnectionStateArgs args)
		{
		}

		internal void ClientDisconnected(NetworkConnection connection)
		{
		}

		private void BuildObjectIdCache()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CacheObjectId(NetworkObject nob)
		{
		}

		internal void CacheObjectId(int id)
		{
		}

		protected internal override int GetNextNetworkObjectId(bool errorCheck = true)
		{
			return 0;
		}

		private void SceneManager_OnLoadStart(SceneLoadStartEventArgs obj)
		{
		}

		private void SceneManager_OnActiveSceneSet()
		{
		}

		internal void IterateLoadedScenes(bool ignoreFrameRestriction)
		{
		}

		protected internal override void SceneManager_sceneLoaded(Scene s, LoadSceneMode arg1)
		{
		}

		protected internal void SetupSceneObjects()
		{
		}

		private void SetupSceneObjects(Scene s)
		{
		}

		private void SetupWithoutSynchronization(NetworkObject nob, NetworkConnection ownerConnection = null, int? objectId = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Spawn(NetworkObject networkObject, NetworkConnection ownerConnection = null, Scene scene = default(Scene))
		{
		}

		private void SpawnWithoutChecks(NetworkObject networkObject, NetworkConnection ownerConnection = null, int? objectId = null)
		{
		}

		internal void ReadPredictedSpawn(PooledReader reader, NetworkConnection conn)
		{
		}

		private void CleanRecentlyDespawned()
		{
		}

		public bool RecentlyDespawned(int objectId, uint ticks)
		{
			return false;
		}

		internal void AddToPending(NetworkObject nob)
		{
		}

		internal bool RemoveFromPending(int objectId)
		{
			return false;
		}

		internal NetworkObject GetFromPending(int objectId)
		{
			return null;
		}

		internal void DestroyPending()
		{
		}

		internal override void Despawn(NetworkObject networkObject, DespawnType despawnType, bool asServer)
		{
		}

		internal override void NetworkObjectUnexpectedlyDestroyed(NetworkObject nob, bool asServer)
		{
		}

		private void FinalizeDespawn(NetworkObject nob, DespawnType despawnType)
		{
		}

		private void WriteDespawnAndSend(NetworkObject nob, DespawnType despawnType)
		{
		}

		internal void ReadPredictedDespawn(Reader reader, NetworkConnection conn)
		{
		}

		private void Observers_OnUpdate()
		{
		}

		private void UpdateTimedObservers()
		{
		}

		public void AddTimedNetworkObserver(NetworkObject networkObject)
		{
		}

		public void RemoveTimedNetworkObserver(NetworkObject networkObject)
		{
		}

		private List<NetworkConnection> RetrieveAuthenticatedConnections()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private List<NetworkObject> RetrieveOrderedSpawnedObjects()
		{
			return null;
		}

		private void OrderRootByInitializationOrder(NetworkObject nob, List<NetworkObject> cache, ref bool initializationOrderChanged)
		{
		}

		private void OrderNestedByInitializationOrder(List<NetworkObject> cache)
		{
		}

		private void RemoveFromObserversWithoutSynchronization(NetworkConnection connection)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(NetworkObject nob, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(NetworkConnection connection, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use RebuildObservers IList variant instead.")]
		public void RebuildObservers(IEnumerable<NetworkObject> nobs, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use RebuildObservers IList variant instead.")]
		public void RebuildObservers(IEnumerable<NetworkConnection> connections, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use RebuildObservers IList variant instead.")]
		public void RebuildObservers(IEnumerable<NetworkObject> nobs, NetworkConnection conn, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use RebuildObservers IList variant instead.")]
		public void RebuildObservers(NetworkObject networkObject, IEnumerable<NetworkConnection> connections, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("Use RebuildObservers IList variant instead.")]
		public void RebuildObservers(IEnumerable<NetworkObject> nobs, IEnumerable<NetworkConnection> conns, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(IList<NetworkObject> nobs, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(IList<NetworkConnection> connections, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(IList<NetworkObject> nobs, NetworkConnection conn, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(NetworkObject networkObject, IList<NetworkConnection> connections, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(IList<NetworkObject> nobs, IList<NetworkConnection> conns, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RebuildObservers(NetworkObject nob, NetworkConnection conn, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void RebuildObservers(NetworkObject nob, NetworkConnection conn, List<NetworkObject> addedNobs, bool timedOnly = false)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void ParseServerRpc(PooledReader reader, NetworkConnection conn, Channel channel)
		{
		}
	}
}
