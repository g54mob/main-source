using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Managing.Object
{
	[APIExclude]
	[CreateAssetMenu(fileName = "New SinglePrefabObjects", menuName = "FishNet/Spawnable Prefabs/Single Prefab Objects")]
	public class SinglePrefabObjects : PrefabObjects
	{
		[SerializeField]
		[Tooltip("Prefabs which may be spawned.")]
		private List<NetworkObject> _prefabs;

		public IReadOnlyList<NetworkObject> Prefabs => null;

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

		public override void AddObject(NetworkObject networkObject, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(List<NetworkObject> networkObjects, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(NetworkObject[] networkObjects, bool checkForDuplicates = false)
		{
		}

		private void AddUniqueNetworkObject(NetworkObject nob)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void InitializePrefabRange(int startIndex)
		{
		}

		public override void AddObject(DualPrefab dualPrefab, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(List<DualPrefab> dualPrefab, bool checkForDuplicates = false)
		{
		}

		public override void AddObjects(DualPrefab[] dualPrefab, bool checkForDuplicates = false)
		{
		}
	}
}
