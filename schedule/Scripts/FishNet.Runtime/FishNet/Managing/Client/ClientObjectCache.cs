using System;
using System.Collections.Generic;
using FishNet.Managing.Object;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Managing.Client
{
	internal class ClientObjectCache
	{
		public enum CacheSearchType
		{
			Any = 0,
			Spawning = 1,
			Despawning = 2
		}

		internal Dictionary<int, NetworkObject> IteratedSpawningObjects;

		internal HashSet<int> ReadSpawningObjects;

		private List<CachedNetworkObject> _cachedObjects;

		private HashSet<NetworkObject> _iteratedSpawns;

		private HashSet<int> _conflictingDespawns;

		private ClientObjects _clientObjects;

		private NetworkManager _networkManager;

		private bool _loggedSameTickWarning;

		private bool _initializeOrderChanged;

		public ClientObjectCache(ClientObjects cobs, NetworkManager networkManager)
		{
		}

		public NetworkObject GetInCached(int objectId, CacheSearchType searchType)
		{
			return null;
		}

		public void AddSpawn(NetworkManager manager, ushort collectionId, int objectId, sbyte initializeOrder, int ownerId, SpawnType ost, byte componentIndex, int rootObjectId, int? parentObjectId, byte? parentComponentIndex, int? prefabId, Vector3? localPosition, Quaternion? localRotation, Vector3? localScale, ulong sceneId, string sceneName, string objectName, ArraySegment<byte> rpcLinks, ArraySegment<byte> syncValues)
		{
		}

		public void AddDespawn(int objectId, DespawnType despawnType)
		{
		}

		public void Iterate()
		{
		}

		private void IterateDespawn(CachedNetworkObject cnob)
		{
		}

		internal NetworkObject GetSpawnedObject(int objectId)
		{
			return null;
		}

		public void Reset()
		{
		}
	}
}
