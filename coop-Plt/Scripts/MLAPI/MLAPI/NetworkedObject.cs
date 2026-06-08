using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using MLAPI.Exceptions;
using MLAPI.Hashing;
using MLAPI.Logging;
using MLAPI.Messaging;
using MLAPI.Security;
using MLAPI.Serialization.Pooled;
using MLAPI.Spawning;
using UnityEngine;

namespace MLAPI
{
	[AddComponentMenu("MLAPI/NetworkedObject", -99)]
	public sealed class NetworkedObject : MonoBehaviour
	{
		public delegate bool VisibilityDelegate(ulong clientId);

		public delegate bool SpawnDelegate(ulong clientId);

		internal ulong? _ownerClientId;

		[HideInInspector]
		[SerializeField]
		public ulong NetworkedInstanceId;

		[HideInInspector]
		[SerializeField]
		public ulong PrefabHash;

		[SerializeField]
		public string PrefabHashGenerator;

		public bool AlwaysReplicateAsRoot;

		public VisibilityDelegate CheckObjectVisibility;

		public SpawnDelegate IncludeTransformWhenSpawning;

		public bool DontDestroyWithOwner;

		internal readonly HashSet<ulong> observers = new HashSet<ulong>();

		private List<NetworkedBehaviour> _childNetworkedBehaviours;

		private static int _lastProcessedObject;

		public ulong NetworkId { get; internal set; }

		public ulong OwnerClientId
		{
			get
			{
				if (!_ownerClientId.HasValue)
				{
					if (!(NetworkingManager.Singleton != null))
					{
						return 0uL;
					}
					return NetworkingManager.Singleton.ServerClientId;
				}
				return _ownerClientId.Value;
			}
			internal set
			{
				if (NetworkingManager.Singleton != null && value == NetworkingManager.Singleton.ServerClientId)
				{
					_ownerClientId = null;
				}
				else
				{
					_ownerClientId = value;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsPlayerObject instead", false)]
		public bool isPlayerObject => IsPlayerObject;

		public bool IsPlayerObject { get; internal set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsLocalPlayer instead", false)]
		public bool isLocalPlayer => IsLocalPlayer;

		public bool IsLocalPlayer
		{
			get
			{
				if (NetworkingManager.Singleton != null && IsPlayerObject)
				{
					return OwnerClientId == NetworkingManager.Singleton.LocalClientId;
				}
				return false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsOwner instead", false)]
		public bool isOwner => IsOwner;

		public bool IsOwner
		{
			get
			{
				if (NetworkingManager.Singleton != null)
				{
					return OwnerClientId == NetworkingManager.Singleton.LocalClientId;
				}
				return false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsOwnedByServer instead", false)]
		public bool isOwnedByServer => IsOwnedByServer;

		public bool IsOwnedByServer
		{
			get
			{
				if (NetworkingManager.Singleton != null)
				{
					return OwnerClientId == NetworkingManager.Singleton.ServerClientId;
				}
				return false;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsSpawned instead", false)]
		public bool isSpawned => IsSpawned;

		public bool IsSpawned { get; internal set; }

		public bool? IsSceneObject { get; internal set; }

		public bool DestroyWithScene { get; internal set; }

		internal List<NetworkedBehaviour> childNetworkedBehaviours
		{
			get
			{
				if (_childNetworkedBehaviours == null)
				{
					_childNetworkedBehaviours = new List<NetworkedBehaviour>();
					NetworkedBehaviour[] componentsInChildren = GetComponentsInChildren<NetworkedBehaviour>(includeInactive: true);
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						if (componentsInChildren[i].NetworkedObject == this)
						{
							_childNetworkedBehaviours.Add(componentsInChildren[i]);
						}
					}
				}
				return _childNetworkedBehaviours;
			}
		}

		private void OnValidate()
		{
			ValidateHash();
		}

		internal void ValidateHash()
		{
			if (string.IsNullOrEmpty(PrefabHashGenerator))
			{
				PrefabHashGenerator = base.gameObject.name;
			}
			PrefabHash = PrefabHashGenerator.GetStableHash64();
		}

		public HashSet<ulong>.Enumerator GetObservers()
		{
			if (!IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			return observers.GetEnumerator();
		}

		public bool IsNetworkVisibleTo(ulong clientId)
		{
			if (!IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			return observers.Contains(clientId);
		}

		public void NetworkShow(ulong clientId, Stream payload = null)
		{
			if (!IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			if (observers.Contains(clientId))
			{
				throw new VisibilityChangeException("The object is already visible");
			}
			observers.Add(clientId);
			SpawnManager.SendSpawnCallForObject(clientId, this, payload);
		}

		public static void NetworkShow(List<NetworkedObject> networkedObjects, ulong clientId, Stream payload = null)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			for (int i = 0; i < networkedObjects.Count; i++)
			{
				if (!networkedObjects[i].IsSpawned)
				{
					throw new SpawnStateException("Object is not spawned");
				}
				if (networkedObjects[i].observers.Contains(clientId))
				{
					throw new VisibilityChangeException("NetworkedObject with NetworkId: " + networkedObjects[i].NetworkId + " is already visible");
				}
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
			{
				pooledBitWriter.WriteUInt16Packed((ushort)networkedObjects.Count);
			}
			for (int j = 0; j < networkedObjects.Count; j++)
			{
				networkedObjects[j].observers.Add(clientId);
				SpawnManager.WriteSpawnCallForObject(pooledBitStream, clientId, networkedObjects[j], payload);
			}
			InternalMessageSender.Send(clientId, 10, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
		}

		public void NetworkHide(ulong clientId)
		{
			if (!IsSpawned)
			{
				throw new SpawnStateException("Object is not spawned");
			}
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			if (!observers.Contains(clientId))
			{
				throw new VisibilityChangeException("The object is already hidden");
			}
			if (clientId == NetworkingManager.Singleton.ServerClientId)
			{
				throw new VisibilityChangeException("Cannot hide an object from the server");
			}
			observers.Remove(clientId);
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream);
			pooledBitWriter.WriteUInt64Packed(NetworkId);
			InternalMessageSender.Send(clientId, 6, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
		}

		public static void NetworkHide(List<NetworkedObject> networkedObjects, ulong clientId)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only server can change visibility");
			}
			if (clientId == NetworkingManager.Singleton.ServerClientId)
			{
				throw new VisibilityChangeException("Cannot hide an object from the server");
			}
			for (int i = 0; i < networkedObjects.Count; i++)
			{
				if (!networkedObjects[i].IsSpawned)
				{
					throw new SpawnStateException("Object is not spawned");
				}
				if (!networkedObjects[i].observers.Contains(clientId))
				{
					throw new VisibilityChangeException("NetworkedObject with NetworkId: " + networkedObjects[i].NetworkId + " is already hidden");
				}
			}
			using PooledBitStream pooledBitStream = PooledBitStream.Get();
			using (PooledBitWriter pooledBitWriter = PooledBitWriter.Get(pooledBitStream))
			{
				pooledBitWriter.WriteUInt16Packed((ushort)networkedObjects.Count);
				for (int j = 0; j < networkedObjects.Count; j++)
				{
					networkedObjects[j].observers.Remove(clientId);
					pooledBitWriter.WriteUInt64Packed(networkedObjects[j].NetworkId);
				}
			}
			InternalMessageSender.Send(clientId, 21, "MLAPI_INTERNAL", pooledBitStream, SecuritySendFlags.None, null);
		}

		private void OnDestroy()
		{
			if (NetworkingManager.Singleton != null)
			{
				SpawnManager.OnDestroyObject(NetworkId, destroyGameObject: false);
			}
		}

		public void Spawn(Stream spawnPayload = null, bool destroyWithScene = false)
		{
			if (!NetworkingManager.Singleton.IsListening)
			{
				throw new NotListeningException("NetworkingManager isn't listening, start a server, client or host before spawning objects.");
			}
			if (spawnPayload != null)
			{
				spawnPayload.Position = 0L;
			}
			SpawnManager.SpawnNetworkedObjectLocally(this, SpawnManager.GetNetworkObjectId(), sceneObject: false, playerObject: false, null, spawnPayload, spawnPayload != null, (int)((spawnPayload != null) ? spawnPayload.Length : 0), readNetworkedVar: false, destroyWithScene);
			for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
			{
				if (observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
				{
					SpawnManager.SendSpawnCallForObject(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, this, spawnPayload);
				}
			}
		}

		public void UnSpawn()
		{
			SpawnManager.UnSpawnObject(this);
		}

		public void SpawnWithOwnership(ulong clientId, Stream spawnPayload = null, bool destroyWithScene = false)
		{
			if (spawnPayload != null)
			{
				spawnPayload.Position = 0L;
			}
			SpawnManager.SpawnNetworkedObjectLocally(this, SpawnManager.GetNetworkObjectId(), sceneObject: false, playerObject: false, clientId, spawnPayload, spawnPayload != null, (int)((spawnPayload != null) ? spawnPayload.Length : 0), readNetworkedVar: false, destroyWithScene);
			for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
			{
				if (observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
				{
					SpawnManager.SendSpawnCallForObject(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, this, spawnPayload);
				}
			}
		}

		public void SpawnAsPlayerObject(ulong clientId, Stream spawnPayload = null, bool destroyWithScene = false)
		{
			if (spawnPayload != null)
			{
				spawnPayload.Position = 0L;
			}
			SpawnManager.SpawnNetworkedObjectLocally(this, SpawnManager.GetNetworkObjectId(), sceneObject: false, playerObject: true, clientId, spawnPayload, spawnPayload != null, (int)((spawnPayload != null) ? spawnPayload.Length : 0), readNetworkedVar: false, destroyWithScene);
			for (int i = 0; i < NetworkingManager.Singleton.ConnectedClientsList.Count; i++)
			{
				if (observers.Contains(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId))
				{
					SpawnManager.SendSpawnCallForObject(NetworkingManager.Singleton.ConnectedClientsList[i].ClientId, this, spawnPayload);
				}
			}
		}

		public void RemoveOwnership()
		{
			SpawnManager.RemoveOwnership(this);
		}

		public void ChangeOwnership(ulong newOwnerClientId)
		{
			SpawnManager.ChangeOwnership(this, newOwnerClientId);
		}

		internal void InvokeBehaviourOnLostOwnership()
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				childNetworkedBehaviours[i].OnLostOwnership();
			}
		}

		internal void InvokeBehaviourOnGainedOwnership()
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				childNetworkedBehaviours[i].OnGainedOwnership();
			}
		}

		internal void ResetNetworkedStartInvoked()
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				childNetworkedBehaviours[i].networkedStartInvoked = false;
			}
		}

		internal void InvokeBehaviourNetworkSpawn(Stream stream)
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				if (!childNetworkedBehaviours[i].networkedStartInvoked)
				{
					if (!childNetworkedBehaviours[i].internalNetworkedStartInvoked)
					{
						childNetworkedBehaviours[i].InternalNetworkStart();
						childNetworkedBehaviours[i].internalNetworkedStartInvoked = true;
					}
					childNetworkedBehaviours[i].NetworkStart(stream);
					childNetworkedBehaviours[i].networkedStartInvoked = true;
				}
			}
		}

		internal static void NetworkedBehaviourUpdate()
		{
			if (SpawnManager.SpawnedObjectsList.Count == 0)
			{
				return;
			}
			int num = ((NetworkingManager.Singleton.NetworkConfig.MaxObjectUpdatesPerTick <= 0) ? SpawnManager.SpawnedObjectsList.Count : Mathf.Max(NetworkingManager.Singleton.NetworkConfig.MaxObjectUpdatesPerTick, SpawnManager.SpawnedObjectsList.Count));
			for (int i = 0; i < num; i++)
			{
				if (_lastProcessedObject >= SpawnManager.SpawnedObjectsList.Count)
				{
					_lastProcessedObject = 0;
				}
				for (int j = 0; j < SpawnManager.SpawnedObjectsList[_lastProcessedObject].childNetworkedBehaviours.Count; j++)
				{
					SpawnManager.SpawnedObjectsList[_lastProcessedObject].childNetworkedBehaviours[j].VarUpdate();
				}
				_lastProcessedObject++;
			}
		}

		internal void WriteSyncedVarData(Stream stream, ulong clientId)
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				childNetworkedBehaviours[i].InitializeVars();
				NetworkedBehaviour.WriteSyncedVarData(childNetworkedBehaviours[i].syncedVars, stream, clientId);
			}
		}

		internal void SetSyncedVarData(Stream stream)
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				childNetworkedBehaviours[i].InitializeVars();
				NetworkedBehaviour.SetSyncedVarData(childNetworkedBehaviours[i].syncedVars, stream);
			}
		}

		internal void WriteNetworkedVarData(Stream stream, ulong clientId)
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				childNetworkedBehaviours[i].InitializeVars();
				NetworkedBehaviour.WriteNetworkedVarData(childNetworkedBehaviours[i].networkedVarFields, stream, clientId);
			}
		}

		internal void SetNetworkedVarData(Stream stream)
		{
			for (int i = 0; i < childNetworkedBehaviours.Count; i++)
			{
				childNetworkedBehaviours[i].InitializeVars();
				NetworkedBehaviour.SetNetworkedVarData(childNetworkedBehaviours[i].networkedVarFields, stream);
			}
		}

		internal ushort GetOrderIndex(NetworkedBehaviour instance)
		{
			for (ushort num = 0; num < childNetworkedBehaviours.Count; num++)
			{
				if (childNetworkedBehaviours[num] == instance)
				{
					return num;
				}
			}
			return 0;
		}

		internal NetworkedBehaviour GetBehaviourAtOrderIndex(ushort index)
		{
			if (index >= childNetworkedBehaviours.Count)
			{
				if (NetworkLog.CurrentLogLevel <= LogLevel.Error)
				{
					NetworkLog.LogError("Behaviour index was out of bounds. Did you mess up the order of your NetworkedBehaviours?");
				}
				return null;
			}
			return childNetworkedBehaviours[index];
		}
	}
}
