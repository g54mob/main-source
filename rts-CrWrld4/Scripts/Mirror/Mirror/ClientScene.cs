using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public static class ClientScene
	{
		[Obsolete]
		public static NetworkIdentity localPlayer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public static bool ready
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete]
		public static NetworkConnection readyConnection
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public static Dictionary<Guid, GameObject> prefabs => null;

		[Obsolete]
		public static bool AddPlayer(NetworkConnection readyConn)
		{
			return false;
		}

		[Obsolete]
		public static bool Ready(NetworkConnection conn)
		{
			return false;
		}

		[Obsolete]
		public static void PrepareToSpawnSceneObjects()
		{
		}

		[Obsolete]
		public static bool GetPrefab(Guid assetId, out GameObject prefab)
		{
			prefab = null;
			return false;
		}

		[Obsolete]
		public static void RegisterPrefab(GameObject prefab, Guid newAssetId)
		{
		}

		[Obsolete]
		public static void RegisterPrefab(GameObject prefab)
		{
		}

		[Obsolete]
		public static void RegisterPrefab(GameObject prefab, Guid newAssetId, SpawnDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		[Obsolete]
		public static void RegisterPrefab(GameObject prefab, SpawnDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		[Obsolete]
		public static void RegisterPrefab(GameObject prefab, Guid newAssetId, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		[Obsolete]
		public static void RegisterPrefab(GameObject prefab, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		[Obsolete]
		public static void UnregisterPrefab(GameObject prefab)
		{
		}

		[Obsolete]
		public static void RegisterSpawnHandler(Guid assetId, SpawnDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		[Obsolete]
		public static void RegisterSpawnHandler(Guid assetId, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		[Obsolete]
		public static void UnregisterSpawnHandler(Guid assetId)
		{
		}

		[Obsolete]
		public static void ClearSpawners()
		{
		}

		[Obsolete]
		public static void DestroyAllClientObjects()
		{
		}
	}
}
