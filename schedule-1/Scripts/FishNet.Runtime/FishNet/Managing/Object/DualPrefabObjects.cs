using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Managing.Object
{
	[APIExclude]
	[CreateAssetMenu(fileName = "New DualPrefabObjects", menuName = "FishNet/Spawnable Prefabs/Dual Prefab Objects")]
	public class DualPrefabObjects : PrefabObjects
	{
		[Tooltip("Prefabs which may be spawned.")]
		[SerializeField]
		private List<DualPrefab> _prefabs;

		public IReadOnlyCollection<DualPrefab> Prefabs => null;

		public override void Clear()
		{
		}

		public override int GetObjectCount()
		{
			return 0;
		}

		public override NetworkObject GetObject(bool asServer, int id)
		{
			return null;
		}

		public override void RemoveNull()
		{
		}

		public override void AddObject(DualPrefab dualPrefab, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(List<DualPrefab> dualPrefabs, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(DualPrefab[] dualPrefabs, bool checkForDuplicates = false)
		{
		}

		private void AddUniqueNetworkObjects(DualPrefab dp)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void InitializePrefabRange(int startIndex)
		{
		}

		public override void AddObject(NetworkObject networkObject, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(List<NetworkObject> networkObjects, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(NetworkObject[] networkObjects, bool checkForDuplicates = false)
		{
		}
	}
}
