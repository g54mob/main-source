using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using MLAPI.Connection;
using MLAPI.Logging;
using MLAPI.Messaging.Buffering;
using MLAPI.SceneManagement;
using MLAPI.Security;
using MLAPI.Serialization;
using MLAPI.Serialization.Pooled;
using MLAPI.Spawning;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MLAPI.Messaging
{
	internal static class InternalMessageHandler
	{
		internal static void HandleHailRequest(ulong clientId, Stream stream)
		{
			X509Certificate2 x509Certificate = null;
			byte[] array = null;
			using (PooledBitReader pooledBitReader = PooledBitReader.Get(stream))
			{
				if (NetworkingManager.Singleton.NetworkConfig.EnableEncryption)
				{
					if (NetworkingManager.Singleton.NetworkConfig.SignKeyExchange)
					{
						x509Certificate = new X509Certificate2(pooledBitReader.ReadByteArray(null, -1L));
						if (CryptographyHelper.VerifyCertificate(x509Certificate, NetworkingManager.Singleton.ConnectedHostname))
						{
							if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
							{
								NetworkLog.LogWarning("Invalid certificate. Disconnecting");
							}
							NetworkingManager.Singleton.StopClient();
							return;
						}
						NetworkingManager.Singleton.NetworkConfig.ServerX509Certificate = x509Certificate;
					}
					array = pooledBitReader.ReadByteArray(null, -1L);
					if (NetworkingManager.Singleton.NetworkConfig.SignKeyExchange)
					{
						int num = pooledBitReader.ReadByte();
						byte[] array2 = pooledBitReader.ReadByteArray(null, -1L);
						switch (num)
						{
						case 0:
							if (x509Certificate.PublicKey.Key is RSACryptoServiceProvider rSACryptoServiceProvider)
							{
								using (SHA256Managed halg = new SHA256Managed())
								{
									if (!rSACryptoServiceProvider.VerifyData(array, halg, array2))
									{
										if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
										{
											NetworkLog.LogWarning("Invalid RSA signature. Disconnecting");
										}
										NetworkingManager.Singleton.StopClient();
										return;
									}
								}
								break;
							}
							if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
							{
								NetworkLog.LogWarning("No RSA key found in certificate. Disconnecting");
							}
							NetworkingManager.Singleton.StopClient();
							return;
						case 1:
							if (x509Certificate.PublicKey.Key is DSACryptoServiceProvider dSACryptoServiceProvider)
							{
								using (SHA256Managed sHA256Managed = new SHA256Managed())
								{
									if (!dSACryptoServiceProvider.VerifyData(sHA256Managed.ComputeHash(array), array2))
									{
										if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
										{
											NetworkLog.LogWarning("Invalid DSA signature. Disconnecting");
										}
										NetworkingManager.Singleton.StopClient();
										return;
									}
								}
								break;
							}
							if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
							{
								NetworkLog.LogWarning("No DSA key found in certificate. Disconnecting");
							}
							NetworkingManager.Singleton.StopClient();
							return;
						default:
							if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
							{
								NetworkLog.LogWarning("Invalid signature type. Disconnecting");
							}
							NetworkingManager.Singleton.StopClient();
							return;
						}
					}
				}
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
			{
				if (NetworkingManager.Singleton.NetworkConfig.EnableEncryption)
				{
					EllipticDiffieHellman ellipticDiffieHellman = new EllipticDiffieHellman(EllipticDiffieHellman.DEFAULT_CURVE, EllipticDiffieHellman.DEFAULT_GENERATOR, EllipticDiffieHellman.DEFAULT_ORDER);
					NetworkingManager.Singleton.clientAesKey = ellipticDiffieHellman.GetSharedSecret(array);
					byte[] publicKey = ellipticDiffieHellman.GetPublicKey();
					pooledBitWriter.WriteByteArray(publicKey, -1L);
				}
			}
			InternalMessageSender.Send(NetworkingManager.Singleton.ServerClientId, 1, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
		}

		internal static void HandleHailResponse(ulong clientId, Stream stream)
		{
			if (!NetworkingManager.Singleton.PendingClients.ContainsKey(clientId) || NetworkingManager.Singleton.PendingClients[clientId].ConnectionState != PendingClient.State.PendingHail || !NetworkingManager.Singleton.NetworkConfig.EnableEncryption)
			{
				return;
			}
			using (PooledBitReader pooledBitReader = PooledBitReader.Get(stream))
			{
				if (NetworkingManager.Singleton.PendingClients[clientId].KeyExchange != null)
				{
					byte[] pK = pooledBitReader.ReadByteArray(null, -1L);
					NetworkingManager.Singleton.PendingClients[clientId].AesKey = NetworkingManager.Singleton.PendingClients[clientId].KeyExchange.GetSharedSecret(pK);
				}
			}
			NetworkingManager.Singleton.PendingClients[clientId].ConnectionState = PendingClient.State.PendingConnection;
			NetworkingManager.Singleton.PendingClients[clientId].KeyExchange = null;
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
			{
				pooledBitWriter.WriteInt64Packed(DateTime.Now.Ticks);
			}
			InternalMessageSender.Send(clientId, 2, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
		}

		internal static void HandleGreetings(ulong clientId, Stream stream)
		{
			NetworkingManager.Singleton.SendConnectionRequest();
		}

		internal static void HandleConnectionRequest(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong hash = pooledBitReader.ReadUInt64Packed();
			if (!NetworkingManager.Singleton.NetworkConfig.CompareConfig(hash))
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("NetworkConfiguration mismatch. The configuration between the server and client does not match");
				}
				NetworkingManager.Singleton.DisconnectClient(clientId);
			}
			else if (NetworkingManager.Singleton.NetworkConfig.ConnectionApproval)
			{
				byte[] payload = pooledBitReader.ReadByteArray(null, -1L);
				NetworkingManager.Singleton.InvokeConnectionApproval(payload, clientId, delegate(bool createPlayerObject, ulong? playerPrefabHash, bool approved, Vector3? position, Quaternion? rotation)
				{
					NetworkingManager.Singleton.HandleApproval(clientId, createPlayerObject, playerPrefabHash, approved, position, rotation);
				});
			}
			else
			{
				NetworkingManager.Singleton.HandleApproval(clientId, NetworkingManager.Singleton.NetworkConfig.CreatePlayerPrefab, null, approved: true, null, null);
			}
		}

		internal static void HandleConnectionApproved(ulong clientId, Stream stream, float receiveTime)
		{
			using (PooledBitReader pooledBitReader = PooledBitReader.Get(stream))
			{
				NetworkingManager.Singleton.LocalClientId = pooledBitReader.ReadUInt64Packed();
				uint sceneIndex = 0u;
				Guid switchSceneGuid = default(Guid);
				if (NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement)
				{
					sceneIndex = pooledBitReader.ReadUInt32Packed();
					switchSceneGuid = new Guid(pooledBitReader.ReadByteArray(null, -1L));
				}
				bool flag = NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement && NetworkSceneManager.HasSceneMismatch(sceneIndex);
				float netTime = pooledBitReader.ReadSinglePacked();
				NetworkingManager.Singleton.UpdateNetworkTime(clientId, netTime, receiveTime, warp: true);
				NetworkingManager.Singleton.ConnectedClients.Add(NetworkingManager.Singleton.LocalClientId, new NetworkedClient
				{
					ClientId = NetworkingManager.Singleton.LocalClientId
				});
				UnityAction<Scene, Scene> onSceneLoaded;
				BitStream continuationStream;
				if (flag)
				{
					onSceneLoaded = null;
					continuationStream = new BitStream();
					continuationStream.CopyUnreadFrom(stream);
					continuationStream.Position = 0L;
					onSceneLoaded = delegate
					{
						OnSceneLoadComplete();
					};
					SceneManager.activeSceneChanged += onSceneLoaded;
					NetworkSceneManager.OnFirstSceneSwitchSync(sceneIndex, switchSceneGuid);
				}
				else
				{
					DelayedSpawnAction(stream);
				}
				void OnSceneLoadComplete()
				{
					SceneManager.activeSceneChanged -= onSceneLoaded;
					NetworkSceneManager.isSpawnedObjectsPendingInDontDestroyOnLoad = false;
					DelayedSpawnAction(continuationStream);
				}
			}
			static void DelayedSpawnAction(Stream stream2)
			{
				using PooledBitReader pooledBitReader2 = PooledBitReader.Get(stream2);
				if (!NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement || NetworkingManager.Singleton.NetworkConfig.UsePrefabSync)
				{
					SpawnManager.DestroySceneObjects();
				}
				else
				{
					SpawnManager.ClientCollectSoftSyncSceneObjectSweep(null);
				}
				uint num = pooledBitReader2.ReadUInt32Packed();
				for (int i = 0; i < num; i++)
				{
					bool playerObject = pooledBitReader2.ReadBool();
					ulong networkId = pooledBitReader2.ReadUInt64Packed();
					ulong value = pooledBitReader2.ReadUInt64Packed();
					bool flag2 = pooledBitReader2.ReadBool();
					ulong? parentNetworkId = null;
					if (flag2)
					{
						parentNetworkId = pooledBitReader2.ReadUInt64Packed();
					}
					bool flag3;
					ulong instanceId;
					ulong prefabHash;
					if (!NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement || NetworkingManager.Singleton.NetworkConfig.UsePrefabSync)
					{
						flag3 = false;
						instanceId = 0uL;
						prefabHash = pooledBitReader2.ReadUInt64Packed();
					}
					else
					{
						flag3 = pooledBitReader2.ReadBool();
						if (flag3)
						{
							instanceId = pooledBitReader2.ReadUInt64Packed();
							prefabHash = 0uL;
						}
						else
						{
							prefabHash = pooledBitReader2.ReadUInt64Packed();
							instanceId = 0uL;
						}
					}
					Vector3? position = null;
					Quaternion? rotation = null;
					if (pooledBitReader2.ReadBool())
					{
						position = new Vector3(pooledBitReader2.ReadSinglePacked(), pooledBitReader2.ReadSinglePacked(), pooledBitReader2.ReadSinglePacked());
						rotation = Quaternion.Euler(pooledBitReader2.ReadSinglePacked(), pooledBitReader2.ReadSinglePacked(), pooledBitReader2.ReadSinglePacked());
					}
					NetworkedObject netObject = SpawnManager.CreateLocalNetworkedObject(flag3, instanceId, prefabHash, parentNetworkId, position, rotation);
					SpawnManager.SpawnNetworkedObjectLocally(netObject, networkId, flag3, playerObject, value, stream2, readPayload: false, 0, readNetworkedVar: true, destroyWithScene: false);
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
				if (SpawnManager.pendingSoftSyncObjects.Count > 0)
				{
					List<NetworkedObject> list = new List<NetworkedObject>();
					foreach (KeyValuePair<ulong, NetworkedObject> pendingSoftSyncObject in SpawnManager.pendingSoftSyncObjects)
					{
						list.Add(pendingSoftSyncObject.Value);
					}
					for (int j = 0; j < list.Count; j++)
					{
						UnityEngine.Object.Destroy(list[j].gameObject);
					}
				}
				NetworkingManager.Singleton.IsConnectedClient = true;
				NetworkingManager.Singleton.InvokeOnClientConnectedCallback(NetworkingManager.Singleton.LocalClientId);
			}
		}

		internal static void HandleAddObject(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			bool playerObject = pooledBitReader.ReadBool();
			ulong networkId = pooledBitReader.ReadUInt64Packed();
			ulong value = pooledBitReader.ReadUInt64Packed();
			bool flag = pooledBitReader.ReadBool();
			ulong? parentNetworkId = null;
			if (flag)
			{
				parentNetworkId = pooledBitReader.ReadUInt64Packed();
			}
			bool flag2;
			ulong instanceId;
			ulong prefabHash;
			if (!NetworkingManager.Singleton.NetworkConfig.EnableSceneManagement || NetworkingManager.Singleton.NetworkConfig.UsePrefabSync)
			{
				flag2 = false;
				instanceId = 0uL;
				prefabHash = pooledBitReader.ReadUInt64Packed();
			}
			else
			{
				flag2 = pooledBitReader.ReadBool();
				if (flag2)
				{
					instanceId = pooledBitReader.ReadUInt64Packed();
					prefabHash = 0uL;
				}
				else
				{
					prefabHash = pooledBitReader.ReadUInt64Packed();
					instanceId = 0uL;
				}
			}
			Vector3? position = null;
			Quaternion? rotation = null;
			if (pooledBitReader.ReadBool())
			{
				position = new Vector3(pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked());
				rotation = Quaternion.Euler(pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked(), pooledBitReader.ReadSinglePacked());
			}
			bool flag3 = pooledBitReader.ReadBool();
			int payloadLength = (flag3 ? pooledBitReader.ReadInt32Packed() : 0);
			NetworkedObject netObject = SpawnManager.CreateLocalNetworkedObject(flag2, instanceId, prefabHash, parentNetworkId, position, rotation);
			SpawnManager.SpawnNetworkedObjectLocally(netObject, networkId, flag2, playerObject, value, stream, flag3, payloadLength, readNetworkedVar: true, destroyWithScene: false);
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

		internal static void HandleDestroyObject(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong networkId = pooledBitReader.ReadUInt64Packed();
			SpawnManager.OnDestroyObject(networkId, destroyGameObject: true);
		}

		internal static void HandleSwitchScene(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			uint sceneIndex = pooledBitReader.ReadUInt32Packed();
			Guid switchSceneGuid = new Guid(pooledBitReader.ReadByteArray(null, -1L));
			BitStream bitStream = new BitStream();
			bitStream.CopyUnreadFrom(stream);
			bitStream.Position = 0L;
			NetworkSceneManager.OnSceneSwitch(sceneIndex, switchSceneGuid, bitStream);
		}

		internal static void HandleClientSwitchSceneCompleted(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			NetworkSceneManager.OnClientSwitchSceneCompleted(clientId, new Guid(pooledBitReader.ReadByteArray(null, -1L)));
		}

		internal static void HandleChangeOwner(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong key = pooledBitReader.ReadUInt64Packed();
			ulong num = pooledBitReader.ReadUInt64Packed();
			if (SpawnManager.SpawnedObjects[key].OwnerClientId == NetworkingManager.Singleton.LocalClientId)
			{
				SpawnManager.SpawnedObjects[key].InvokeBehaviourOnLostOwnership();
			}
			if (num == NetworkingManager.Singleton.LocalClientId)
			{
				SpawnManager.SpawnedObjects[key].InvokeBehaviourOnGainedOwnership();
			}
			SpawnManager.SpawnedObjects[key].OwnerClientId = num;
		}

		internal static void HandleAddObjects(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ushort num = pooledBitReader.ReadUInt16Packed();
			for (int i = 0; i < num; i++)
			{
				HandleAddObject(clientId, stream);
			}
		}

		internal static void HandleDestroyObjects(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ushort num = pooledBitReader.ReadUInt16Packed();
			for (int i = 0; i < num; i++)
			{
				HandleDestroyObject(clientId, stream);
			}
		}

		internal static void HandleTimeSync(ulong clientId, Stream stream, float receiveTime)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			float netTime = pooledBitReader.ReadSinglePacked();
			NetworkingManager.Singleton.UpdateNetworkTime(clientId, netTime, receiveTime);
		}

		internal static void HandleNetworkedVarDelta(ulong clientId, Stream stream, Action<ulong, PreBufferPreset> bufferCallback, PreBufferPreset bufferPreset)
		{
			if (!NetworkingManager.Singleton.NetworkConfig.EnableNetworkedVar)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("NetworkedVar delta received but EnableNetworkedVar is false");
				}
				return;
			}
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			ushort num2 = pooledBitReader.ReadUInt16Packed();
			if (SpawnManager.SpawnedObjects.ContainsKey(num))
			{
				NetworkedBehaviour behaviourAtOrderIndex = SpawnManager.SpawnedObjects[num].GetBehaviourAtOrderIndex(num2);
				if (behaviourAtOrderIndex == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("NetworkedVarDelta message received for a non existant behaviour. NetworkId: " + num + ", behaviourIndex: " + num2);
					}
				}
				else
				{
					NetworkedBehaviour.HandleNetworkedVarDeltas(behaviourAtOrderIndex.networkedVarFields, stream, clientId, behaviourAtOrderIndex);
				}
			}
			else if (NetworkingManager.Singleton.IsServer || !NetworkingManager.Singleton.NetworkConfig.EnableMessageBuffering)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("NetworkedVarDelta message received for a non existant object with id: " + num + ". This delta was lost.");
				}
			}
			else
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("NetworkedVarDelta message received for a non existant object with id: " + num + ". This delta will be buffered and might be recovered.");
				}
				bufferCallback(num, bufferPreset);
			}
		}

		internal static void HandleNetworkedVarUpdate(ulong clientId, Stream stream, Action<ulong, PreBufferPreset> bufferCallback, PreBufferPreset bufferPreset)
		{
			if (!NetworkingManager.Singleton.NetworkConfig.EnableNetworkedVar)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("NetworkedVar update received but EnableNetworkedVar is false");
				}
				return;
			}
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			ushort num2 = pooledBitReader.ReadUInt16Packed();
			if (SpawnManager.SpawnedObjects.ContainsKey(num))
			{
				NetworkedBehaviour behaviourAtOrderIndex = SpawnManager.SpawnedObjects[num].GetBehaviourAtOrderIndex(num2);
				if (behaviourAtOrderIndex == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("NetworkedVarUpdate message received for a non existant behaviour. NetworkId: " + num + ", behaviourIndex: " + num2);
					}
				}
				else
				{
					NetworkedBehaviour.HandleNetworkedVarUpdate(behaviourAtOrderIndex.networkedVarFields, stream, clientId, behaviourAtOrderIndex);
				}
			}
			else if (NetworkingManager.Singleton.IsServer || !NetworkingManager.Singleton.NetworkConfig.EnableMessageBuffering)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("NetworkedVarUpdate message received for a non existant object with id: " + num + ". This delta was lost.");
				}
			}
			else
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("NetworkedVarUpdate message received for a non existant object with id: " + num + ". This delta will be buffered and might be recovered.");
				}
				bufferCallback(num, bufferPreset);
			}
		}

		internal static void HandleSyncedVar(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			ushort index = pooledBitReader.ReadUInt16Packed();
			if (SpawnManager.SpawnedObjects.ContainsKey(num))
			{
				NetworkedBehaviour behaviourAtOrderIndex = SpawnManager.SpawnedObjects[num].GetBehaviourAtOrderIndex(index);
				if (behaviourAtOrderIndex == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("SyncedVar message received for a non existant behaviour");
					}
				}
				else
				{
					NetworkedBehaviour.HandleSyncedVarValue(behaviourAtOrderIndex.syncedVars, stream, clientId, behaviourAtOrderIndex);
				}
			}
			else if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("SyncedVar message received for a non existant object with id: " + num);
			}
		}

		internal static void HandleServerRPC(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			ushort num2 = pooledBitReader.ReadUInt16Packed();
			ulong hash = pooledBitReader.ReadUInt64Packed();
			if (SpawnManager.SpawnedObjects.ContainsKey(num))
			{
				NetworkedBehaviour behaviourAtOrderIndex = SpawnManager.SpawnedObjects[num].GetBehaviourAtOrderIndex(num2);
				if (behaviourAtOrderIndex == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("ServerRPC message received for a non existant behaviour. NetworkId: " + num + ", behaviourIndex: " + num2);
					}
				}
				else
				{
					behaviourAtOrderIndex.OnRemoteServerRPC(hash, clientId, stream);
				}
			}
			else if ((NetworkingManager.Singleton.IsServer || !NetworkingManager.Singleton.NetworkConfig.EnableMessageBuffering) && NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("ServerRPC message received for a non existant object with id: " + num + ". This message is lost.");
			}
		}

		internal static void HandleServerRPCRequest(ulong clientId, Stream stream, string channelName, SecuritySendFlags security)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			ushort num2 = pooledBitReader.ReadUInt16Packed();
			ulong hash = pooledBitReader.ReadUInt64Packed();
			ulong value = pooledBitReader.ReadUInt64Packed();
			if (SpawnManager.SpawnedObjects.ContainsKey(num))
			{
				NetworkedBehaviour behaviourAtOrderIndex = SpawnManager.SpawnedObjects[num].GetBehaviourAtOrderIndex(num2);
				if (!(behaviourAtOrderIndex == null))
				{
					object value2 = behaviourAtOrderIndex.OnRemoteServerRPC(hash, clientId, stream);
					using PooledBitStream pooledBitStream = PooledBitStream.Get();
					using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
					{
						pooledBitWriter.WriteUInt64Packed(value);
						pooledBitWriter.WriteObjectPacked(value2);
					}
					InternalMessageSender.Send(clientId, 16, channelName, pooledBitStream, security, SpawnManager.SpawnedObjects[num]);
					return;
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ServerRPCRequest message received for a non existant behaviour. NetworkId: " + num + ", behaviourIndex: " + num2);
				}
			}
			else if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("ServerRPCRequest message received for a non existant object with id: " + num + ". This message is lost.");
			}
		}

		internal static void HandleServerRPCResponse(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			if (ResponseMessageManager.ContainsKey(num))
			{
				RpcResponseBase byKey = ResponseMessageManager.GetByKey(num);
				ResponseMessageManager.Remove(num);
				byKey.IsDone = true;
				byKey.Result = pooledBitReader.ReadObjectPacked(byKey.Type);
				byKey.IsSuccessful = true;
			}
			else if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
			{
				NetworkLog.LogWarning("ServerRPCResponse message received for a non existant responseId: " + num + ". This response is lost.");
			}
		}

		internal static void HandleClientRPC(ulong clientId, Stream stream, Action<ulong, PreBufferPreset> bufferCallback, PreBufferPreset bufferPreset)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			ushort num2 = pooledBitReader.ReadUInt16Packed();
			ulong hash = pooledBitReader.ReadUInt64Packed();
			if (SpawnManager.SpawnedObjects.ContainsKey(num))
			{
				NetworkedBehaviour behaviourAtOrderIndex = SpawnManager.SpawnedObjects[num].GetBehaviourAtOrderIndex(num2);
				if (behaviourAtOrderIndex == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("ClientRPC message received for a non existant behaviour. NetworkId: " + num + ", behaviourIndex: " + num2);
					}
				}
				else
				{
					behaviourAtOrderIndex.OnRemoteClientRPC(hash, clientId, stream);
				}
			}
			else if (NetworkingManager.Singleton.IsServer || !NetworkingManager.Singleton.NetworkConfig.EnableMessageBuffering)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ClientRPC message received for a non existant object with id: " + num + ". This message is lost.");
				}
			}
			else
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ClientRPC message received for a non existant object with id: " + num + ". This message will be buffered and might be recovered.");
				}
				bufferCallback(num, bufferPreset);
			}
		}

		internal static void HandleClientRPCRequest(ulong clientId, Stream stream, string channelName, SecuritySendFlags security, Action<ulong, PreBufferPreset> bufferCallback, PreBufferPreset bufferPreset)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong num = pooledBitReader.ReadUInt64Packed();
			ushort num2 = pooledBitReader.ReadUInt16Packed();
			ulong hash = pooledBitReader.ReadUInt64Packed();
			ulong value = pooledBitReader.ReadUInt64Packed();
			if (SpawnManager.SpawnedObjects.ContainsKey(num))
			{
				NetworkedBehaviour behaviourAtOrderIndex = SpawnManager.SpawnedObjects[num].GetBehaviourAtOrderIndex(num2);
				if (!(behaviourAtOrderIndex == null))
				{
					object value2 = behaviourAtOrderIndex.OnRemoteClientRPC(hash, clientId, stream);
					using PooledBitStream pooledBitStream = PooledBitStream.Get();
					using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
					{
						pooledBitWriter.WriteUInt64Packed(value);
						pooledBitWriter.WriteObjectPacked(value2);
					}
					InternalMessageSender.Send(clientId, 19, channelName, pooledBitStream, security, null);
					return;
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ClientRPCRequest message received for a non existant behaviour. NetworkId: " + num + ", behaviourIndex: " + num2);
				}
			}
			else if (NetworkingManager.Singleton.IsServer || !NetworkingManager.Singleton.NetworkConfig.EnableMessageBuffering)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ClientRPCRequest message received for a non existant object with id: " + num + ". This message is lost.");
				}
			}
			else
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("ClientRPCRequest message received for a non existant object with id: " + num + ". This message will be buffered and might be recovered.");
				}
				bufferCallback(num, bufferPreset);
			}
		}

		internal static void HandleClientRPCResponse(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong key = pooledBitReader.ReadUInt64Packed();
			if (ResponseMessageManager.ContainsKey(key))
			{
				RpcResponseBase byKey = ResponseMessageManager.GetByKey(key);
				if (byKey.ClientId == clientId)
				{
					ResponseMessageManager.Remove(key);
					byKey.IsDone = true;
					byKey.Result = pooledBitReader.ReadObjectPacked(byKey.Type);
					byKey.IsSuccessful = true;
				}
			}
		}

		internal static void HandleUnnamedMessage(ulong clientId, Stream stream)
		{
			CustomMessagingManager.InvokeUnnamedMessage(clientId, stream);
		}

		internal static void HandleNamedMessage(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ulong hash = pooledBitReader.ReadUInt64Packed();
			CustomMessagingManager.InvokeNamedMessage(hash, clientId, stream);
		}

		internal static void HandleNetworkLog(ulong clientId, Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			NetworkLog.LogType logType = (NetworkLog.LogType)pooledBitReader.ReadByte();
			string message = pooledBitReader.ReadStringPacked().ToString();
			switch (logType)
			{
			case NetworkLog.LogType.Info:
				NetworkLog.LogInfoServerLocal(message, clientId);
				break;
			case NetworkLog.LogType.Warning:
				NetworkLog.LogWarningServerLocal(message, clientId);
				break;
			case NetworkLog.LogType.Error:
				NetworkLog.LogErrorServerLocal(message, clientId);
				break;
			}
		}
	}
}
