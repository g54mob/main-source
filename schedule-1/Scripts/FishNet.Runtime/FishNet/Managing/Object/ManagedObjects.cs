using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Component.Observing;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Object
{
	public abstract class ManagedObjects
	{
		public Dictionary<int, NetworkObject> Spawned;

		protected Dictionary<ulong, NetworkObject> SceneObjects_Internal;

		private HashGrid _hashGrid;

		protected NetworkManager NetworkManager { get; private set; }

		public IReadOnlyDictionary<ulong, NetworkObject> SceneObjects => null;

		protected internal virtual int GetNextNetworkObjectId(bool errorCheck = true)
		{
			return 0;
		}

		protected virtual void Initialize(NetworkManager manager)
		{
		}

		internal void SubscribeToSceneLoaded(bool subscribe)
		{
		}

		protected internal virtual void SceneManager_sceneLoaded(Scene s, LoadSceneMode arg1)
		{
		}

		internal virtual void NetworkObjectUnexpectedlyDestroyed(NetworkObject nob, bool asServer)
		{
		}

		protected virtual void RemoveFromSpawned(NetworkObject nob, bool unexpectedlyDestroyed, bool asServer)
		{
		}

		internal virtual void Despawn(NetworkObject nob, DespawnType despawnType, bool asServer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void UpdateNetworkBehavioursForSceneObject(NetworkObject nob, bool asServer)
		{
		}

		public static void InitializePrefab(NetworkObject prefab, int index, ushort? collectionId = null)
		{
		}

		internal virtual void DespawnWithoutSynchronization(bool asServer)
		{
		}

		internal virtual void DespawnWithoutSynchronization(NetworkObject nob, bool asServer, DespawnType despawnType, bool removeFromSpawned)
		{
		}

		internal virtual void AddToSpawned(NetworkObject nob, bool asServer)
		{
		}

		protected internal void AddToSceneObjects(NetworkObject nob)
		{
		}

		protected internal void RemoveFromSceneObjects(NetworkObject nob)
		{
		}

		protected internal void RemoveFromSceneObjects(ulong sceneId)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected internal NetworkObject GetSpawnedNetworkObject(int objectId)
		{
			return null;
		}

		protected internal void SkipDataLength(ushort packetId, PooledReader reader, int dataLength, int rpcLinkObjectId = -1)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void ParseReplicateRpc(PooledReader reader, NetworkConnection conn, Channel channel)
		{
		}

		protected void ReadTransformProperties(Reader reader, out Vector3? localPosition, out Quaternion? localRotation, out Vector3? localScale)
		{
			localPosition = null;
			localRotation = null;
			localScale = null;
		}

		internal void WriteSpawn_Server(NetworkObject nob, NetworkConnection connection, Writer writer)
		{
		}

		protected void WriteChangedTransformProperties(NetworkObject nob, bool sceneObject, bool nested, Writer headerWriter)
		{
		}

		protected void WriteDespawn(NetworkObject nob, DespawnType despawnType, Writer everyoneWriter)
		{
		}

		internal void GetTransformProperties(Vector3? readPos, Quaternion? readRot, Vector3? readScale, Transform defaultTransform, out Vector3 pos, out Quaternion rot, out Vector3 scale)
		{
			pos = default(Vector3);
			rot = default(Quaternion);
			scale = default(Vector3);
		}

		internal NetworkObject GetSceneNetworkObject(ulong sceneId)
		{
			return null;
		}

		protected bool CanPredictedSpawn(NetworkObject nob, NetworkConnection spawner, NetworkConnection owner, bool asServer, Reader reader = null)
		{
			return false;
		}

		protected bool CanPredictedDespawn(NetworkObject nob, NetworkConnection despawner, bool asServer, Reader reader = null)
		{
			return false;
		}
	}
}
