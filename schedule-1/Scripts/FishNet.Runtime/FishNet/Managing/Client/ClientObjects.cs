using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Documenting;
using FishNet.Managing.Object;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Client
{
	public class ClientObjects : ManagedObjects
	{
		internal List<NetworkObject> LocalClientSpawned;

		private ClientObjectCache _objectCache;

		private Dictionary<ushort, RpcLink> _rpcLinks;

		internal ClientObjects(NetworkManager networkManager)
		{
		}

		internal void OnServerConnectionState(ServerConnectionStateArgs args)
		{
		}

		internal void OnClientConnectionState(ClientConnectionStateArgs args)
		{
		}

		[APIExclude]
		protected internal override void SceneManager_sceneLoaded(Scene s, LoadSceneMode arg1)
		{
		}

		internal override void AddToSpawned(NetworkObject nob, bool asServer)
		{
		}

		protected override void RemoveFromSpawned(NetworkObject nob, bool unexpectedlyDestroyed, bool asServer)
		{
		}

		internal void PredictedSpawn(NetworkObject networkObject, NetworkConnection ownerConnection)
		{
		}

		public void WriteSpawn(NetworkObject nob, Writer writer)
		{
		}

		internal void PredictedDespawn(NetworkObject networkObject)
		{
		}

		public void WriteDepawn(NetworkObject nob, Writer writer)
		{
		}

		internal void RegisterAndDespawnSceneObjects()
		{
		}

		private void RegisterAndDespawnSceneObjects(Scene s)
		{
		}

		internal override void NetworkObjectUnexpectedlyDestroyed(NetworkObject nob, bool asServer)
		{
		}

		internal void ParseOwnershipChange(PooledReader reader)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void ParseSyncType(PooledReader reader, bool isSyncObject, Channel channel)
		{
		}

		internal void ParsePredictedSpawnResult(Reader reader)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void ParseReconcileRpc(PooledReader reader, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void ParseObserversRpc(PooledReader reader, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void ParseTargetRpc(PooledReader reader, Channel channel)
		{
		}

		internal void CacheSpawn(PooledReader reader)
		{
		}

		internal void CacheDespawn(PooledReader reader)
		{
		}

		internal void IterateObjectCache()
		{
		}

		internal NetworkObject GetNestedNetworkObject(CachedNetworkObject cnob)
		{
			return null;
		}

		internal void ApplyRpcLinks(NetworkObject nob, Reader reader)
		{
		}

		internal NetworkObject GetInstantiatedNetworkObject(CachedNetworkObject cnob)
		{
			return null;
		}

		internal NetworkObject GetSpawnedNetworkObject(CachedNetworkObject cnob)
		{
			return null;
		}

		private void ReadSceneObject(PooledReader reader, out ulong sceneId)
		{
			sceneId = default(ulong);
		}

		private void ReadSpawnedObject(PooledReader reader, out int? parentObjectId, out byte? parentComponentIndex, out int? prefabId)
		{
			parentObjectId = null;
			parentComponentIndex = null;
			prefabId = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void ParseRpcLink(PooledReader reader, ushort index, Channel channel)
		{
		}

		internal void SetRpcLink(ushort linkIndex, RpcLink link)
		{
		}

		internal void RemoveLinkIndexes(List<ushort> values)
		{
		}
	}
}
