using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public static class NetworkClient
	{
		private static readonly Dictionary<int, NetworkMessageDelegate> handlers;

		public static bool ready;

		internal static ConnectState connectState;

		internal static Action OnConnectedEvent;

		internal static Action OnDisconnectedEvent;

		public static readonly Dictionary<Guid, GameObject> prefabs;

		internal static readonly Dictionary<Guid, SpawnHandlerDelegate> spawnHandlers;

		internal static readonly Dictionary<Guid, UnSpawnDelegate> unspawnHandlers;

		private static bool isSpawnFinished;

		internal static readonly Dictionary<ulong, NetworkIdentity> spawnableObjects;

		private static readonly List<uint> removeFromSpawned;

		public static NetworkConnection connection { get; internal set; }

		[Obsolete]
		public static NetworkConnection readyConnection => null;

		public static NetworkIdentity localPlayer { get; internal set; }

		public static string serverIp => null;

		public static bool active => false;

		public static bool isConnecting => false;

		public static bool isConnected => false;

		public static bool isLocalClient => false;

		private static void AddTransportHandlers()
		{
		}

		internal static void RegisterSystemHandlers(bool hostMode)
		{
		}

		public static void Connect(string address)
		{
		}

		public static void Connect(Uri uri)
		{
		}

		public static void ConnectHost()
		{
		}

		public static void ConnectLocalServer()
		{
		}

		public static void Disconnect()
		{
		}

		public static void DisconnectLocalServer()
		{
		}

		private static void OnConnected()
		{
		}

		internal static void OnDataReceived(ArraySegment<byte> data, int channelId)
		{
		}

		private static void OnDisconnected()
		{
		}

		private static void OnError(Exception exception)
		{
		}

		public static void Send<T>(T message, int channelId = 0) where T : struct, NetworkMessage
		{
		}

		[Obsolete]
		public static void RegisterHandler<T>(Action<NetworkConnection, T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		public static void RegisterHandler<T>(Action<T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		public static void ReplaceHandler<T>(Action<NetworkConnection, T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		public static void ReplaceHandler<T>(Action<T> handler, bool requireAuthentication = true) where T : struct, NetworkMessage
		{
		}

		public static bool UnregisterHandler<T>() where T : struct, NetworkMessage
		{
			return false;
		}

		public static bool GetPrefab(Guid assetId, out GameObject prefab)
		{
			prefab = null;
			return false;
		}

		private static void RegisterPrefabIdentity(NetworkIdentity prefab)
		{
		}

		public static void RegisterPrefab(GameObject prefab, Guid newAssetId)
		{
		}

		public static void RegisterPrefab(GameObject prefab)
		{
		}

		public static void RegisterPrefab(GameObject prefab, Guid newAssetId, SpawnDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		public static void RegisterPrefab(GameObject prefab, SpawnDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		public static void RegisterPrefab(GameObject prefab, Guid newAssetId, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		public static void RegisterPrefab(GameObject prefab, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		public static void UnregisterPrefab(GameObject prefab)
		{
		}

		public static void RegisterSpawnHandler(Guid assetId, SpawnDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		public static void RegisterSpawnHandler(Guid assetId, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler)
		{
		}

		public static void UnregisterSpawnHandler(Guid assetId)
		{
		}

		public static void ClearSpawners()
		{
		}

		internal static bool InvokeUnSpawnHandler(Guid assetId, GameObject obj)
		{
			return false;
		}

		public static bool Ready()
		{
			return false;
		}

		[Obsolete]
		public static bool Ready(NetworkConnection conn)
		{
			return false;
		}

		internal static void InternalAddPlayer(NetworkIdentity identity)
		{
		}

		public static bool AddPlayer()
		{
			return false;
		}

		[Obsolete]
		public static bool AddPlayer(NetworkConnection readyConn)
		{
			return false;
		}

		internal static void ApplySpawnPayload(NetworkIdentity identity, SpawnMessage message)
		{
		}

		internal static bool FindOrSpawnObject(SpawnMessage message, out NetworkIdentity identity)
		{
			identity = null;
			return false;
		}

		private static NetworkIdentity GetExistingObject(uint netid)
		{
			return null;
		}

		private static NetworkIdentity SpawnPrefab(SpawnMessage message)
		{
			return null;
		}

		private static NetworkIdentity SpawnSceneObject(SpawnMessage message)
		{
			return null;
		}

		private static NetworkIdentity GetAndRemoveSceneObject(ulong sceneId)
		{
			return null;
		}

		private static bool ConsiderForSpawning(NetworkIdentity identity)
		{
			return false;
		}

		public static void PrepareToSpawnSceneObjects()
		{
		}

		internal static void OnObjectSpawnStarted(ObjectSpawnStartedMessage _)
		{
		}

		internal static void OnObjectSpawnFinished(ObjectSpawnFinishedMessage _)
		{
		}

		private static void ClearNullFromSpawned()
		{
		}

		private static void OnHostClientObjectDestroy(ObjectDestroyMessage message)
		{
		}

		private static void OnHostClientObjectHide(ObjectHideMessage message)
		{
		}

		internal static void OnHostClientSpawn(SpawnMessage message)
		{
		}

		private static void OnUpdateVarsMessage(UpdateVarsMessage message)
		{
		}

		private static void OnRPCMessage(RpcMessage message)
		{
		}

		private static void OnObjectHide(ObjectHideMessage message)
		{
		}

		internal static void OnObjectDestroy(ObjectDestroyMessage message)
		{
		}

		internal static void OnSpawn(SpawnMessage message)
		{
		}

		internal static void CheckForLocalPlayer(NetworkIdentity identity)
		{
		}

		private static void DestroyObject(uint netId)
		{
		}

		internal static void NetworkEarlyUpdate()
		{
		}

		internal static void NetworkLateUpdate()
		{
		}

		[Obsolete]
		public static void Update()
		{
		}

		public static void DestroyAllClientObjects()
		{
		}

		public static void Shutdown()
		{
		}
	}
}
