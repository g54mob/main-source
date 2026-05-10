using System;
using FishNet.Managing.Object;
using FishNet.Object;
using FishNet.Serializing;
using GameKit.Utilities;
using UnityEngine;
using UnityEngine.Scripting;

namespace FishNet.Managing.Client
{
	[Preserve]
	internal class CachedNetworkObject : IResettable
	{
		public enum ActionType
		{
			Unset = 0,
			Spawn = 1,
			Despawn = 2
		}

		public ushort CollectionId;

		public int ObjectId;

		public sbyte InitializeOrder;

		public int OwnerId;

		public SpawnType SpawnType;

		public DespawnType DespawnType;

		public byte ComponentIndex;

		public int RootObjectId;

		public int? ParentObjectId;

		public byte? ParentComponentIndex;

		public int? PrefabId;

		public Vector3? LocalPosition;

		public Quaternion? LocalRotation;

		public Vector3? LocalScale;

		public ulong SceneId;

		public ArraySegment<byte> RpcLinks;

		public ArraySegment<byte> SyncValues;

		public NetworkObject NetworkObject;

		public bool IsNested => false;

		public bool IsSceneObject => false;

		public bool HasParent => false;

		public bool ParentIsNetworkBehaviour => false;

		public ActionType Action { get; private set; }

		public PooledReader RpcLinkReader { get; private set; }

		public PooledReader SyncValuesReader { get; private set; }

		public void InitializeSpawn(NetworkManager manager, ushort collectionId, int objectId, sbyte initializeOrder, int ownerId, SpawnType objectSpawnType, byte componentIndex, int rootObjectId, int? parentObjectId, byte? parentComponentIndex, int? prefabId, Vector3? localPosition, Quaternion? localRotation, Vector3? localScale, ulong sceneId, string sceneName, string objectName, ArraySegment<byte> rpcLinks, ArraySegment<byte> syncValues)
		{
		}

		public void InitializeDespawn(int objectId, DespawnType despawnType)
		{
		}

		public void ResetState()
		{
		}

		public void InitializeState()
		{
		}

		~CachedNetworkObject()
		{
		}
	}
}
