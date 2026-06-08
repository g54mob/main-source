using System;
using System.Collections.Generic;
using System.IO;
using MLAPI.Exceptions;
using MLAPI.Hashing;
using MLAPI.Logging;
using MLAPI.Messaging;
using MLAPI.SceneManagement;
using MLAPI.Security;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;
using UnityEngine;

namespace MLAPI.Spawning
{
	public static class SpawnManager
	{
		public delegate NetworkedObject SpawnHandlerDelegate(Vector3 position, Quaternion rotation);

		public delegate void DestroyHandlerDelegate(NetworkedObject networkedObject);

		public static readonly Dictionary<ulong, NetworkedObject> SpawnedObjects = new Dictionary<ulong, NetworkedObject>();

		internal static readonly Dictionary<ulong, NetworkedObject> pendingSoftSyncObjects = new Dictionary<ulong, NetworkedObject>();

		public static readonly List<NetworkedObject> SpawnedObjectsList = new List<NetworkedObject>();

		internal static readonly Dictionary<ulong, SpawnHandlerDelegate> customSpawnHandlers = new Dictionary<ulong, SpawnHandlerDelegate>();

		internal static readonly Dictionary<ulong, DestroyHandlerDelegate> customDestroyHandlers = new Dictionary<ulong, DestroyHandlerDelegate>();

		internal static readonly Queue<ReleasedNetworkId> releasedNetworkObjectIds = new Queue<ReleasedNetworkId>();

		private static ulong networkObjectIdCounter;

		public static void RegisterSpawnHandler(ulong prefabHash, SpawnHandlerDelegate handler)
		{
			if (customSpawnHandlers.ContainsKey(prefabHash))
			{
				customSpawnHandlers[prefabHash] = handler;
			}
			else
			{
				customSpawnHandlers.Add(prefabHash, handler);
			}
		}

		public static void RegisterCustomDestroyHandler(ulong prefabHash, DestroyHandlerDelegate handler)
		{
			if (customDestroyHandlers.ContainsKey(prefabHash))
			{
				customDestroyHandlers[prefabHash] = handler;
			}
			else
			{
				customDestroyHandlers.Add(prefabHash, handler);
			}
		}

		public static void RemoveCustomSpawnHandler(ulong prefabHash)
		{
			customSpawnHandlers.Remove(prefabHash);
		}

		public static void RemoveCustomDestroyHandler(ulong prefabHash)
		{
			customDestroyHandlers.Remove(prefabHash);
		}

		internal static ulong GetNetworkObjectId()
		{
			if (releasedNetworkObjectIds.Count > 0 && NetworkingManager.Singleton.NetworkConfig.RecycleNetworkIds && Time.unscaledTime - releasedNetworkObjectIds.Peek().ReleaseTime >= NetworkingManager.Singleton.NetworkConfig.NetworkIdRecycleDelay)
			{
				return releasedNetworkObjectIds.Dequeue().NetworkId;
			}
			networkObjectIdCounter++;
			return networkObjectIdCounter;
		}

		public static int GetNetworkedPrefabIndexOfHash(ulong hash)
		{
			for (int i = 0; i < NetworkingManager.Singleton.NetworkConfig.NetworkedPrefabs.Count; i++)
			{
				if (NetworkingManager.Singleton.NetworkConfig.NetworkedPrefabs[i].Hash == hash)
				{
					return i;
				}
			}
			return -1;
		}

		public static ulong GetPrefabHashFromIndex(int index)
		{
			return NetworkingManager.Singleton.NetworkConfig.NetworkedPrefabs[index].Hash;
		}

		public static ulong GetPrefabHashFromGenerator(string generator)
		{
			return generator.GetStableHash64();
		}

		public static NetworkedObject GetLocalPlayerObject()
		{
			if (!NetworkingManager.Singleton.ConnectedClients.ContainsKey(NetworkingManager.Singleton.LocalClientId))
			{
				return null;
			}
			return NetworkingManager.Singleton.ConnectedClients[NetworkingManager.Singleton.LocalClientId].PlayerObject;
		}

		public static NetworkedObject GetPlayerObject(ulong clientId)
		{
			if (!NetworkingManager.Singleton.ConnectedClients.ContainsKey(clientId))
			{
				return null;
			}
			return NetworkingManager.Singleton.ConnectedClients[clientId].PlayerObject;
		}

		internal static void RemoveOwnership(NetworkedObject netObject)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only the server can change ownership");
			}
			if (!netObject.IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			for (int num = NetworkingManager.Singleton.ConnectedClients[netObject.OwnerClientId].OwnedObjects.Count - 1; num > -1; num--)
			{
				if (NetworkingManager.Singleton.ConnectedClients[netObject.OwnerClientId].OwnedObjects[num] == netObject)
				{
					NetworkingManager.Singleton.ConnectedClients[netObject.OwnerClientId].OwnedObjects.RemoveAt(num);
				}
			}
			netObject._ownerClientId = null;
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt64Packed(netObject.NetworkId);
			pooledBitWriter.WriteUInt64Packed(netObject.OwnerClientId);
			InternalMessageSender.Send(9, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, netObject);
		}

		internal static void ChangeOwnership(NetworkedObject netObject, ulong clientId)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only the server can change ownership");
			}
			if (!netObject.IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			if (NetworkingManager.Singleton.ConnectedClients.ContainsKey(netObject.OwnerClientId))
			{
				for (int num = NetworkingManager.Singleton.ConnectedClients[netObject.OwnerClientId].OwnedObjects.Count - 1; num >= 0; num--)
				{
					if (NetworkingManager.Singleton.ConnectedClients[netObject.OwnerClientId].OwnedObjects[num] == netObject)
					{
						NetworkingManager.Singleton.ConnectedClients[netObject.OwnerClientId].OwnedObjects.RemoveAt(num);
					}
				}
			}
			NetworkingManager.Singleton.ConnectedClients[clientId].OwnedObjects.Add(netObject);
			netObject.OwnerClientId = clientId;
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt64Packed(netObject.NetworkId);
			pooledBitWriter.WriteUInt64Packed(clientId);
			InternalMessageSender.Send(9, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, netObject);
		}

		internal static NetworkedObject CreateLocalNetworkedObject(bool softCreate, ulong instanceId, ulong prefabHash, ulong? parentNetworkId, Vector3? position, Quaternion? rotation)
		{
			NetworkedObject networkedObject = null;
			if (parentNetworkId.HasValue && SpawnedObjects.ContainsKey(parentNetworkId.Value))
			{
				networkedObject = SpawnedObjects[parentNetworkId.Value];
			}
			else if (parentNetworkId.HasValue && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("Cannot find parent. Parent objects always have to be spawned and replicated BEFORE the child");
			}
			if (!NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement || NetworkingManager.Singleton.NetworkConfig.UsePrefabSync || !softCreate)
			{
				if (customSpawnHandlers.ContainsKey(prefabHash))
				{
					NetworkedObject networkedObject2 = customSpawnHandlers[prefabHash](position.GetValueOrDefault(Vector3.zero), rotation.GetValueOrDefault(Quaternion.identity));
					if (networkedObject != null)
					{
						networkedObject2.transform.SetParent(networkedObject.transform, worldPositionStays: true);
					}
					if (NetworkSceneManager.isSpawnedObjectsPendingInDontDestroyOnLoad)
					{
						UnityEngine.Object.DontDestroyOnLoad(networkedObject2.gameObject);
					}
					return networkedObject2;
				}
				int networkedPrefabIndexOfHash = GetNetworkedPrefabIndexOfHash(prefabHash);
				if (networkedPrefabIndexOfHash < 0)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
					{
						NetworkLog.LogError("Failed to create object locally. [PrefabHash=" + prefabHash + "]. Hash could not be found. Is the prefab registered?");
					}
					return null;
				}
				GameObject prefab = NetworkingManager.Singleton.NetworkConfig.NetworkedPrefabs[networkedPrefabIndexOfHash].Prefab;
				NetworkedObject component = ((!position.HasValue && !rotation.HasValue) ? UnityEngine.Object.Instantiate(prefab) : UnityEngine.Object.Instantiate(prefab, position.GetValueOrDefault(Vector3.zero), rotation.GetValueOrDefault(Quaternion.identity))).GetComponent<NetworkedObject>();
				if (networkedObject != null)
				{
					component.transform.SetParent(networkedObject.transform, worldPositionStays: true);
				}
				if (NetworkSceneManager.isSpawnedObjectsPendingInDontDestroyOnLoad)
				{
					UnityEngine.Object.DontDestroyOnLoad(component.gameObject);
				}
				return component;
			}
			if (!pendingSoftSyncObjects.ContainsKey(instanceId))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Cannot find pending soft sync object. Is the projects the same?");
				}
				return null;
			}
			NetworkedObject networkedObject3 = pendingSoftSyncObjects[instanceId];
			pendingSoftSyncObjects.Remove(instanceId);
			if (networkedObject != null)
			{
				networkedObject3.transform.SetParent(networkedObject.transform, worldPositionStays: true);
			}
			return networkedObject3;
		}

		internal static void SpawnNetworkedObjectLocally(NetworkedObject netObject, ulong networkId, bool sceneObject, bool playerObject, ulong? ownerClientId, Stream dataStream, bool readPayload, int payloadLength, bool readNetworkedVar, bool destroyWithScene)
		{
			if (netObject == null)
			{
				throw new ArgumentNullException("netObject", "Cannot spawn null object");
			}
			if (netObject.IsSpawned)
			{
				throw new SpawnStateException("Object is already spawned");
			}
			if (readNetworkedVar && NetworkingManager.Singleton.NetworkConfig.EnableNetworkedVar)
			{
				netObject.SetNetworkedVarData(dataStream);
				netObject.SetSyncedVarData(dataStream);
			}
			netObject.IsSpawned = true;
			netObject.IsSceneObject = sceneObject;
			netObject.NetworkId = networkId;
			netObject.DestroyWithScene = sceneObject || destroyWithScene;
			netObject._ownerClientId = ownerClientId;
			netObject.IsPlayerObject = playerObject;
			SpawnedObjects.Add(netObject.NetworkId, netObject);
			SpawnedObjectsList.Add(netObject);
			if (ownerClientId.HasValue)
			{
				if (NetworkingManager.Singleton.IsServer)
				{
					if (playerObject)
					{
						NetworkingManager.Singleton.ConnectedClients[ownerClientId.Value].PlayerObject = netObject;
					}
					else
					{
						NetworkingManager.Singleton.ConnectedClients[ownerClientId.Value].OwnedObjects.Add(netObject);
					}
				}
				else if (playerObject && ownerClientId.Value == NetworkingManager.Singleton.LocalClientId)
				{
					NetworkingManager.Singleton.ConnectedClients[ownerClientId.Value].PlayerObject = netObject;
				}
			}
			if (NetworkingManager.Singleton.IsServer)
			{
				for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
				{
					if (netObject.CheckObjectVisibility == null || netObject.CheckObjectVisibility(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
					{
						netObject.observers.Add(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId);
					}
				}
			}
			netObject.ResetNetworkedStartInvoked();
			if (readPayload)
			{
				using (PooledBitStream pooledBitStream = PooledBitStream.Get())
				{
					pooledBitStream.CopyUnreadFrom(dataStream, payloadLength);
					dataStream.Position += payloadLength;
					pooledBitStream.Position = 0L;
					netObject.InvokeBehaviourNetworkSpawn(pooledBitStream);
					return;
				}
			}
			netObject.InvokeBehaviourNetworkSpawn(null);
		}

		internal static void SendSpawnCallForObject(ulong clientId, NetworkedObject netObject, Stream payload)
		{
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			WriteSpawnCallForObject(pooledBitStream, clientId, netObject, payload);
			InternalMessageSender.Send(clientId, 5, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
		}

		internal static void WriteSpawnCallForObject(BitStream stream, ulong clientId, NetworkedObject netObject, Stream payload)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteBool(netObject.IsPlayerObject);
			pooledBitWriter.WriteUInt64Packed(netObject.NetworkId);
			pooledBitWriter.WriteUInt64Packed(netObject.OwnerClientId);
			NetworkedObject networkedObject = null;
			if (!netObject.AlwaysReplicateAsRoot && netObject.transform.parent != null)
			{
				networkedObject = netObject.transform.parent.GetComponent<NetworkedObject>();
			}
			if (networkedObject == null)
			{
				pooledBitWriter.WriteBool(value: false);
			}
			else
			{
				pooledBitWriter.WriteBool(value: true);
				pooledBitWriter.WriteUInt64Packed(networkedObject.NetworkId);
			}
			if (!NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement || NetworkingManager.Singleton.NetworkConfig.UsePrefabSync)
			{
				pooledBitWriter.WriteUInt64Packed(netObject.PrefabHash);
			}
			else
			{
				pooledBitWriter.WriteBool(!netObject.IsSceneObject.HasValue || netObject.IsSceneObject.Value);
				if (!netObject.IsSceneObject.HasValue || netObject.IsSceneObject.Value)
				{
					pooledBitWriter.WriteUInt64Packed(netObject.NetworkedInstanceId);
				}
				else
				{
					pooledBitWriter.WriteUInt64Packed(netObject.PrefabHash);
				}
			}
			if (netObject.IncludeTransformWhenSpawning == null || netObject.IncludeTransformWhenSpawning(clientId))
			{
				pooledBitWriter.WriteBool(value: true);
				pooledBitWriter.WriteSinglePacked(netObject.transform.position.x);
				pooledBitWriter.WriteSinglePacked(netObject.transform.position.y);
				pooledBitWriter.WriteSinglePacked(netObject.transform.position.z);
				pooledBitWriter.WriteSinglePacked(netObject.transform.rotation.eulerAngles.x);
				pooledBitWriter.WriteSinglePacked(netObject.transform.rotation.eulerAngles.y);
				pooledBitWriter.WriteSinglePacked(netObject.transform.rotation.eulerAngles.z);
			}
			else
			{
				pooledBitWriter.WriteBool(value: false);
			}
			pooledBitWriter.WriteBool(payload != null);
			if (payload != null)
			{
				pooledBitWriter.WriteInt32Packed((int)payload.Length);
			}
			if (NetworkingManager.Singleton.NetworkConfig.EnableNetworkedVar)
			{
				netObject.WriteNetworkedVarData(stream, clientId);
				netObject.WriteSyncedVarData(stream, clientId);
			}
			if (payload != null)
			{
				stream.CopyFrom(payload);
			}
		}

		internal static void UnSpawnObject(NetworkedObject netObject)
		{
			if (!netObject.IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only server unspawn objects");
			}
			OnDestroyObject(netObject.NetworkId, destroyGameObject: false);
		}

		internal static void ServerResetShudownStateForSceneObjects()
		{
			for (int i = 0; i < SpawnedObjectsList.Count; i++)
			{
				if ((SpawnedObjectsList[i].IsSceneObject.HasValue && SpawnedObjectsList[i].IsSceneObject == true) || SpawnedObjectsList[i].DestroyWithScene)
				{
					SpawnedObjectsList[i].IsSpawned = false;
					SpawnedObjectsList[i].DestroyWithScene = false;
					SpawnedObjectsList[i].IsSceneObject = null;
				}
			}
		}

		internal static void ServerDestroySpawnedSceneObjects()
		{
			for (int num = SpawnedObjectsList.Count - 1; num >= 0; num--)
			{
				if ((SpawnedObjectsList[num].IsSceneObject.HasValue && SpawnedObjectsList[num].IsSceneObject == true) || SpawnedObjectsList[num].DestroyWithScene)
				{
					if (customDestroyHandlers.ContainsKey(SpawnedObjectsList[num].PrefabHash))
					{
						customDestroyHandlers[SpawnedObjectsList[num].PrefabHash](SpawnedObjectsList[num]);
						OnDestroyObject(SpawnedObjectsList[num].NetworkId, destroyGameObject: false);
					}
					else
					{
						UnityEngine.Object.Destroy(SpawnedObjectsList[num].gameObject);
					}
				}
			}
		}

		internal static void DestroyNonSceneObjects()
		{
			NetworkedObject[] array = UnityEngine.Object.FindObjectsOfType<NetworkedObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].IsSceneObject.HasValue && !array[i].IsSceneObject.Value)
				{
					if (customDestroyHandlers.ContainsKey(array[i].PrefabHash))
					{
						customDestroyHandlers[array[i].PrefabHash](array[i]);
						OnDestroyObject(array[i].NetworkId, destroyGameObject: false);
					}
					else
					{
						UnityEngine.Object.Destroy(array[i].gameObject);
					}
				}
			}
		}

		internal static void DestroySceneObjects()
		{
			NetworkedObject[] array = UnityEngine.Object.FindObjectsOfType<NetworkedObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsSceneObject.HasValue || array[i].IsSceneObject.Value)
				{
					if (customDestroyHandlers.ContainsKey(array[i].PrefabHash))
					{
						customDestroyHandlers[array[i].PrefabHash](array[i]);
						OnDestroyObject(array[i].NetworkId, destroyGameObject: false);
					}
					else
					{
						UnityEngine.Object.Destroy(array[i].gameObject);
					}
				}
			}
		}

		internal static void ServerSpawnSceneObjectsOnStartSweep()
		{
			NetworkedObject[] array = UnityEngine.Object.FindObjectsOfType<NetworkedObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsSceneObject.HasValue)
				{
					SpawnNetworkedObjectLocally(array[i], GetNetworkObjectId(), sceneObject: true, playerObject: false, null, null, readPayload: false, 0, readNetworkedVar: false, destroyWithScene: true);
				}
			}
		}

		internal static void ClientCollectSoftSyncSceneObjectSweep(NetworkedObject[] networkedObjects)
		{
			if (networkedObjects == null)
			{
				networkedObjects = UnityEngine.Object.FindObjectsOfType<NetworkedObject>();
			}
			for (int i = 0; i < networkedObjects.Length; i++)
			{
				if (!networkedObjects[i].IsSceneObject.HasValue)
				{
					pendingSoftSyncObjects.Add(networkedObjects[i].NetworkedInstanceId, networkedObjects[i]);
				}
			}
		}

		internal static void OnDestroyObject(ulong networkId, bool destroyGameObject)
		{
			if (NetworkingManager.Singleton == null || !SpawnedObjects.ContainsKey(networkId))
			{
				return;
			}
			if (!SpawnedObjects[networkId].IsOwnedByServer && !SpawnedObjects[networkId].IsPlayerObject && NetworkingManager.Singleton.ConnectedClients.ContainsKey(SpawnedObjects[networkId].OwnerClientId))
			{
				for (int num = NetworkingManager.Singleton.ConnectedClients[SpawnedObjects[networkId].OwnerClientId].OwnedObjects.Count - 1; num > -1; num--)
				{
					if (NetworkingManager.Singleton.ConnectedClients[SpawnedObjects[networkId].OwnerClientId].OwnedObjects[num].NetworkId == networkId)
					{
						NetworkingManager.Singleton.ConnectedClients[SpawnedObjects[networkId].OwnerClientId].OwnedObjects.RemoveAt(num);
					}
				}
			}
			SpawnedObjects[networkId].IsSpawned = false;
			if (NetworkingManager.Singleton != null && NetworkingManager.Singleton.IsServer)
			{
				if (NetworkingManager.Singleton.NetworkConfig.RecycleNetworkIds)
				{
					releasedNetworkObjectIds.Enqueue(new ReleasedNetworkId
					{
						NetworkId = networkId,
						ReleaseTime = Time.unscaledTime
					});
				}
				if (SpawnedObjects[networkId] != null)
				{
					using PooledBitStream pooledBitStream = PooledBitStream.Get();
					using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
					pooledBitWriter.WriteUInt64Packed(networkId);
					InternalMessageSender.Send(6, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, SpawnedObjects[networkId]);
				}
			}
			GameObject gameObject = SpawnedObjects[networkId].gameObject;
			if (destroyGameObject && gameObject != null)
			{
				if (customDestroyHandlers.ContainsKey(SpawnedObjects[networkId].PrefabHash))
				{
					customDestroyHandlers[SpawnedObjects[networkId].PrefabHash](SpawnedObjects[networkId]);
					OnDestroyObject(networkId, destroyGameObject: false);
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			SpawnedObjects.Remove(networkId);
			for (int num2 = SpawnedObjectsList.Count - 1; num2 > -1; num2--)
			{
				if (SpawnedObjectsList[num2].NetworkId == networkId)
				{
					SpawnedObjectsList.RemoveAt(num2);
				}
			}
		}
	}
}
