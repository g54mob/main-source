using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Utility.Performance
{
	public class DefaultObjectPool : ObjectPool
	{
		private List<Dictionary<int, Stack<NetworkObject>>> _cache;

		[Tooltip("True if to use object pooling.")]
		[SerializeField]
		private bool _enabled;

		private Dictionary<int, Transform> _objectParents;

		private const string OBJECTS_PARENT_NAME = "DefaultObjectPool Parent";

		public IReadOnlyCollection<Dictionary<int, Stack<NetworkObject>>> Cache => null;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override NetworkObject RetrieveObject(int prefabId, bool asServer)
		{
			return null;
		}

		public override NetworkObject RetrieveObject(int prefabId, ushort collectionId, Vector3 position, Quaternion rotation, bool asServer)
		{
			return null;
		}

		public override NetworkObject RetrieveObject(int prefabId, ushort collectionId, bool asServer)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void StoreObject(NetworkObject instantiated, bool asServer)
		{
		}

		public override void CacheObjects(NetworkObject prefab, int count, bool asServer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ClearPool()
		{
		}

		public void ClearPool(int collectionId)
		{
		}

		private Transform GetObjectStoreParent(NetworkObject nob)
		{
			return null;
		}

		internal void ObjectsDestroyed(DefaultObjectPoolContainer container)
		{
		}

		private Stack<NetworkObject> GetOrCreateCache(int collectionId, int prefabId)
		{
			return null;
		}
	}
}
