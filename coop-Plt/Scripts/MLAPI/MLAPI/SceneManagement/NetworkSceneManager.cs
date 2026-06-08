using System;
using System.Collections.Generic;
using System.IO;
using MLAPI.Exceptions;
using MLAPI.Logging;
using MLAPI.Messaging;
using MLAPI.Messaging.Buffering;
using MLAPI.Security;
using MLAPI.Serialization.Pooled;
using MLAPI.Spawning;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MLAPI.SceneManagement
{
	public static class NetworkSceneManager
	{
		public delegate void SceneSwitchedDelegate();

		public delegate void SceneSwitchStartedDelegate(AsyncOperation operation);

		internal static readonly HashSet<string> registeredSceneNames = new HashSet<string>();

		internal static readonly Dictionary<string, uint> sceneNameToIndex = new Dictionary<string, uint>();

		internal static readonly Dictionary<uint, string> sceneIndexToString = new Dictionary<uint, string>();

		internal static readonly Dictionary<Guid, SceneSwitchProgress> sceneSwitchProgresses = new Dictionary<Guid, SceneSwitchProgress>();

		private static Scene lastScene;

		private static string nextSceneName;

		private static bool isSwitching = false;

		internal static uint currentSceneIndex = 0u;

		internal static Guid currentSceneSwitchProgressGuid = default(Guid);

		internal static bool isSpawnedObjectsPendingInDontDestroyOnLoad = false;

		internal static uint CurrentActiveSceneIndex { get; private set; } = 0u;

		public static event SceneSwitchedDelegate OnSceneSwitched;

		public static event SceneSwitchStartedDelegate OnSceneSwitchStarted;

		internal static void SetCurrentSceneIndex()
		{
			if (!sceneNameToIndex.ContainsKey(SceneManager.GetActiveScene().name))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("The current scene (" + SceneManager.GetActiveScene().name + ") is not regisered as a network scene.");
				}
			}
			else
			{
				currentSceneIndex = sceneNameToIndex[SceneManager.GetActiveScene().name];
				CurrentActiveSceneIndex = currentSceneIndex;
			}
		}

		public static void AddRuntimeSceneName(string sceneName, uint index)
		{
			if (!NetworkingManager.Singleton.NetworkConfig.AllowRuntimeSceneChanges)
			{
				throw new NetworkConfigurationException("Cannot change the scene configuration when AllowRuntimeSceneChanges is false");
			}
			registeredSceneNames.Add(sceneName);
			sceneIndexToString.Add(index, sceneName);
			sceneNameToIndex.Add(sceneName, index);
		}

		public static SceneSwitchProgress SwitchScene(string sceneName)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only server can start a scene switch");
			}
			if (isSwitching)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Scene switch already in progress");
				}
				return null;
			}
			if (!registeredSceneNames.Contains(sceneName))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("The scene " + sceneName + " is not registered as a switchable scene.");
				}
				return null;
			}
			SpawnManager.ServerDestroySpawnedSceneObjects();
			isSwitching = true;
			lastScene = SceneManager.GetActiveScene();
			SceneSwitchProgress switchSceneProgress = new SceneSwitchProgress();
			sceneSwitchProgresses.Add(switchSceneProgress.guid, switchSceneProgress);
			currentSceneSwitchProgressGuid = switchSceneProgress.guid;
			MoveObjectsToDontDestroyOnLoad();
			isSpawnedObjectsPendingInDontDestroyOnLoad = true;
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
			nextSceneName = sceneName;
			asyncOperation.completed += delegate
			{
				OnSceneLoaded(switchSceneProgress.guid, null);
			};
			switchSceneProgress.SetSceneLoadOperation(asyncOperation);
			if (NetworkSceneManager.OnSceneSwitchStarted != null)
			{
				NetworkSceneManager.OnSceneSwitchStarted(asyncOperation);
			}
			return switchSceneProgress;
		}

		internal static void OnSceneSwitch(uint sceneIndex, Guid switchSceneGuid, Stream objectStream)
		{
			if (!sceneIndexToString.ContainsKey(sceneIndex) || !registeredSceneNames.Contains(sceneIndexToString[sceneIndex]))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Server requested a scene switch to a non registered scene");
				}
				return;
			}
			lastScene = SceneManager.GetActiveScene();
			MoveObjectsToDontDestroyOnLoad();
			isSpawnedObjectsPendingInDontDestroyOnLoad = true;
			string sceneName = sceneIndexToString[sceneIndex];
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
			nextSceneName = sceneName;
			asyncOperation.completed += delegate
			{
				OnSceneLoaded(switchSceneGuid, objectStream);
			};
			if (NetworkSceneManager.OnSceneSwitchStarted != null)
			{
				NetworkSceneManager.OnSceneSwitchStarted(asyncOperation);
			}
		}

		internal static void OnFirstSceneSwitchSync(uint sceneIndex, Guid switchSceneGuid)
		{
			if (!sceneIndexToString.ContainsKey(sceneIndex) || !registeredSceneNames.Contains(sceneIndexToString[sceneIndex]))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("Server requested a scene switch to a non registered scene");
				}
			}
			else
			{
				if (SceneManager.GetActiveScene().name == sceneIndexToString[sceneIndex])
				{
					return;
				}
				lastScene = SceneManager.GetActiveScene();
				string text = (nextSceneName = sceneIndexToString[sceneIndex]);
				CurrentActiveSceneIndex = sceneNameToIndex[text];
				isSpawnedObjectsPendingInDontDestroyOnLoad = true;
				SceneManager.LoadScene(text);
				using (PooledBitStream pooledBitStream = PooledBitStream.Get())
				{
					using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
					pooledBitWriter.WriteByteArray(switchSceneGuid.ToByteArray(), -1L);
					InternalMessageSender.Send(NetworkingManager.Singleton.ServerClientId, 8, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
				}
				isSwitching = false;
			}
		}

		private static void OnSceneLoaded(Guid switchSceneGuid, Stream objectStream)
		{
			CurrentActiveSceneIndex = sceneNameToIndex[nextSceneName];
			Scene sceneByName = SceneManager.GetSceneByName(nextSceneName);
			SceneManager.SetActiveScene(sceneByName);
			MoveObjectsToScene(sceneByName);
			isSpawnedObjectsPendingInDontDestroyOnLoad = false;
			currentSceneIndex = CurrentActiveSceneIndex;
			if (NetworkingManager.Singleton.IsServer)
			{
				OnSceneUnloadServer(switchSceneGuid);
			}
			else
			{
				OnSceneUnloadClient(switchSceneGuid, objectStream);
			}
		}

		private static void OnSceneUnloadServer(Guid switchSceneGuid)
		{
			List<NetworkedObject> list = new List<NetworkedObject>();
			NetworkedObject[] array = UnityEngine.Object.FindObjectsOfType<NetworkedObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].IsSceneObject.HasValue)
				{
					SpawnManager.SpawnNetworkedObjectLocally(array[i], SpawnManager.GetNetworkObjectId(), sceneObject: true, playerObject: false, null, null, readPayload: false, 0, readNetworkedVar: false, destroyWithScene: true);
					list.Add(array[i]);
				}
			}
			for (int j = 0; j < NetworkingManager.Singleton.ConnectedClientsList.Count; j++)
			{
				if (NetworkingManager.Singleton.ConnectedClientsList[j].ClientId == NetworkingManager.Singleton.ServerClientId)
				{
					continue;
				}
				using PooledBitStream pooledBitStream = PooledBitStream.Get();
				using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
				{
					pooledBitWriter.WriteUInt32Packed(CurrentActiveSceneIndex);
					pooledBitWriter.WriteByteArray(switchSceneGuid.ToByteArray(), -1L);
					uint num = 0u;
					for (int k = 0; k < list.Count; k++)
					{
						if (list[k].observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[j].ClientId))
						{
							num++;
						}
					}
					pooledBitWriter.WriteUInt32Packed(num);
					for (int l = 0; l < list.Count; l++)
					{
						if (list[l].observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[j].ClientId))
						{
							pooledBitWriter.WriteBool(list[l].IsPlayerObject);
							pooledBitWriter.WriteUInt64Packed(list[l].NetworkId);
							pooledBitWriter.WriteUInt64Packed(list[l].OwnerClientId);
							NetworkedObject networkedObject = null;
							if (!list[l].AlwaysReplicateAsRoot && list[l].transform.parent != null)
							{
								networkedObject = list[l].transform.parent.GetComponent<NetworkedObject>();
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
								pooledBitWriter.WriteUInt64Packed(list[l].PrefabHash);
								pooledBitWriter.WriteSinglePacked(list[l].transform.position.x);
								pooledBitWriter.WriteSinglePacked(list[l].transform.position.y);
								pooledBitWriter.WriteSinglePacked(list[l].transform.position.z);
								pooledBitWriter.WriteSinglePacked(list[l].transform.rotation.eulerAngles.x);
								pooledBitWriter.WriteSinglePacked(list[l].transform.rotation.eulerAngles.y);
								pooledBitWriter.WriteSinglePacked(list[l].transform.rotation.eulerAngles.z);
							}
							else
							{
								pooledBitWriter.WriteUInt64Packed(list[l].NetworkedInstanceId);
							}
							if (NetworkingManager.Singleton.NetworkConfig.EnableNetworkedVar)
							{
								list[l].WriteNetworkedVarData(pooledBitStream, NetworkingManager.Singleton.ConnectedClientsList[j].ClientId);
								list[l].WriteSyncedVarData(pooledBitStream, NetworkingManager.Singleton.ConnectedClientsList[j].ClientId);
							}
						}
					}
				}
				InternalMessageSender.Send(NetworkingManager.Singleton.ConnectedClientsList[j].ClientId, 7, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
			}
			if (NetworkingManager.Singleton.IsHost)
			{
				OnClientSwitchSceneCompleted(NetworkingManager.Singleton.LocalClientId, switchSceneGuid);
			}
			isSwitching = false;
			if (NetworkSceneManager.OnSceneSwitched != null)
			{
				NetworkSceneManager.OnSceneSwitched();
			}
		}

		private static void OnSceneUnloadClient(Guid switchSceneGuid, Stream objectStream)
		{
			if (!NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement || NetworkingManager.Singleton.NetworkConfig.UsePrefabSync)
			{
				SpawnManager.DestroySceneObjects();
				using PooledBitReader pooledBitReader = PooledBitReader.Get(objectStream);
				uint num = pooledBitReader.ReadUInt32Packed();
				for (int i = 0; i < num; i++)
				{
					bool playerObject = pooledBitReader.ReadBool();
					ulong networkId = pooledBitReader.ReadUInt64Packed();
					ulong value = pooledBitReader.ReadUInt64Packed();
					bool flag = pooledBitReader.ReadBool();
					ulong? parentNetworkId = null;
					if (flag)
					{
						parentNetworkId = pooledBitReader.ReadUInt64Packed();
					}
					ulong prefabHash = pooledBitReader.ReadUInt64Packed();
					Vector3? position = null;
					Quaternion? rotation = null;
					if (pooledBitReader.ReadBool())
					{
						position = new Vector3(pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked());
						rotation = Quaternion.Euler(pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked());
					}
					NetworkedObject netObject = SpawnManager.CreateLocalNetworkedObject(softCreate: false, 0uL, prefabHash, parentNetworkId, position, rotation);
					SpawnManager.SpawnNetworkedObjectLocally(netObject, networkId, sceneObject: true, playerObject, value, objectStream, readPayload: false, 0, readNetworkedVar: true, destroyWithScene: false);
					Queue<BufferManager.BufferedMessage> queue = BufferManager.ConsumeBuffersForNetworkId(networkId);
					if (queue != null)
					{
						while (queue.Count > 0)
						{
							BufferManager.BufferedMessage message = queue.Dequeue();
							NetworkingManager.Singleton.HandleIncomingData(message.sender, message.channelName, new ArraySegment<byte>(message.payload.GetBuffer(), (int)message.payload.Position, (int)message.payload.Length), message.receiveTime, allowBuffer: false);
							BufferManager.RecycleConsumedBufferedMessage(message);
						}
					}
				}
			}
			else
			{
				NetworkedObject[] networkedObjects = UnityEngine.Object.FindObjectsOfType<NetworkedObject>();
				SpawnManager.ClientCollectSoftSyncSceneObjectSweep(networkedObjects);
				using PooledBitReader pooledBitReader2 = PooledBitReader.Get(objectStream);
				uint num2 = pooledBitReader2.ReadUInt32Packed();
				for (int j = 0; j < num2; j++)
				{
					bool playerObject2 = pooledBitReader2.ReadBool();
					ulong networkId2 = pooledBitReader2.ReadUInt64Packed();
					ulong value2 = pooledBitReader2.ReadUInt64Packed();
					bool flag2 = pooledBitReader2.ReadBool();
					ulong? parentNetworkId2 = null;
					if (flag2)
					{
						parentNetworkId2 = pooledBitReader2.ReadUInt64Packed();
					}
					ulong instanceId = pooledBitReader2.ReadUInt64Packed();
					NetworkedObject netObject2 = SpawnManager.CreateLocalNetworkedObject(softCreate: true, instanceId, 0uL, parentNetworkId2, null, null);
					SpawnManager.SpawnNetworkedObjectLocally(netObject2, networkId2, sceneObject: true, playerObject2, value2, objectStream, readPayload: false, 0, readNetworkedVar: true, destroyWithScene: false);
					Queue<BufferManager.BufferedMessage> queue2 = BufferManager.ConsumeBuffersForNetworkId(networkId2);
					if (queue2 != null)
					{
						while (queue2.Count > 0)
						{
							BufferManager.BufferedMessage message2 = queue2.Dequeue();
							NetworkingManager.Singleton.HandleIncomingData(message2.sender, message2.channelName, new ArraySegment<byte>(message2.payload.GetBuffer(), (int)message2.payload.Position, (int)message2.payload.Length), message2.receiveTime, allowBuffer: false);
							BufferManager.RecycleConsumedBufferedMessage(message2);
						}
					}
				}
			}
			using (PooledBitStream pooledBitStream = PooledBitStream.Get())
			{
				using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
				pooledBitWriter.WriteByteArray(switchSceneGuid.ToByteArray(), -1L);
				NetworkedObject targetObject = null;
				InternalMessageSender.Send(NetworkingManager.Singleton.ServerClientId, 8, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, targetObject);
			}
			isSwitching = false;
			if (NetworkSceneManager.OnSceneSwitched != null)
			{
				NetworkSceneManager.OnSceneSwitched();
			}
		}

		internal static bool HasSceneMismatch(uint sceneIndex)
		{
			return SceneManager.GetActiveScene().name != sceneIndexToString[sceneIndex];
		}

		internal static void OnClientSwitchSceneCompleted(ulong clientId, Guid switchSceneGuid)
		{
			if (!(switchSceneGuid == Guid.Empty) && sceneSwitchProgresses.ContainsKey(switchSceneGuid))
			{
				sceneSwitchProgresses[switchSceneGuid].AddClientAsDone(clientId);
			}
		}

		internal static void RemoveClientFromSceneSwitchProgresses(ulong clientId)
		{
			foreach (SceneSwitchProgress value in sceneSwitchProgresses.Values)
			{
				value.RemoveClientAsDone(clientId);
			}
		}

		private static void MoveObjectsToDontDestroyOnLoad()
		{
			List<NetworkedObject> spawnedObjectsList = SpawnManager.SpawnedObjectsList;
			for (int i = 0; i < spawnedObjectsList.Count; i++)
			{
				if (spawnedObjectsList[i].gameObject.transform.parent != null)
				{
					spawnedObjectsList[i].gameObject.transform.parent = null;
				}
				UnityEngine.Object.DontDestroyOnLoad(spawnedObjectsList[i].gameObject);
			}
		}

		private static void MoveObjectsToScene(Scene scene)
		{
			List<NetworkedObject> spawnedObjectsList = SpawnManager.SpawnedObjectsList;
			for (int i = 0; i < spawnedObjectsList.Count; i++)
			{
				if (spawnedObjectsList[i].gameObject.transform.parent != null)
				{
					spawnedObjectsList[i].gameObject.transform.parent = null;
				}
				SceneManager.MoveGameObjectToScene(spawnedObjectsList[i].gameObject, scene);
			}
		}
	}
}
