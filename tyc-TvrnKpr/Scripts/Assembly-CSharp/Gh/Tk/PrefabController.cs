using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class PrefabController : SingletonMonoBehaviour<PrefabController>
	{
		[SerializeField]
		[HideInInspector]
		private List<GameObject> _prefabs;

		internal Dictionary<string, GameObject> _prefabsByUniqueType;

		private Dictionary<int, string> _hashPrefabId;

		[SerializeField]
		[HideInInspector]
		private List<GameObject> _meshOutlineTemplates;

		private Dictionary<int, GameObject> _highlightTemplatesDict;

		private Dictionary<int, PrefabObjectPool> _highlightObjectPool;

		private bool _disableShadows;

		private static Dictionary<int, Dictionary<string, (GameObject go, List<SnappingPointInfo> info)>> _entityCache;

		public List<GameObject> Prefabs => null;

		public override void Awake()
		{
		}

		private void Start()
		{
		}

		public void CheckAnimationLoopSettings()
		{
		}

		public PrefabObjectPool GetMeshHighlightPool(Mesh mesh)
		{
			return null;
		}

		public PrefabObjectPool GetMeshHighlightPool(int hashCode)
		{
			return null;
		}

		private void PopulatePrefabUniqueTypeDictionary()
		{
		}

		public bool IsPrefabInstance(GameObject gameObject)
		{
			return false;
		}

		public GameObject GetPrefabByUniqueType(string uniqueType, bool generalize = false)
		{
			return null;
		}

		private void EnsurePrefabCache()
		{
		}

		public IEnumerable<GameObject> GetPrefabsWhereUniqueTypeStartsWith(string uniqueType)
		{
			return null;
		}

		public GameObject GetPrefab(string name)
		{
			return null;
		}

		public IEnumerable<GameObject> GetPrefabsStartingWith(string name)
		{
			return null;
		}

		public IEnumerable<GameObject> GetAllPrefabsWithComponent(Type componentType)
		{
			return null;
		}

		public GameObject SpawnObject(string prefabIdentifier)
		{
			return null;
		}

		public GameObject SpawnObject(GameObject prefab)
		{
			return null;
		}

		private void RegisterPrefabs(GameObject[] prefabs)
		{
		}

		private void RegisterPrefab(GameObject newPrefab)
		{
		}

		private void CheckPrefab(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		private void CheckGoxNamedMeshGroups(GameObject prefab)
		{
		}

		private void CheckAnimatorLayers(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		private void CheckAnimatorsAreNotApplyingRootMotion(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		private void CheckLeftOverTransforms(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		public void CheckAnimationParameters()
		{
		}

		public void CheckAnimationEvents()
		{
		}

		private void CheckShadows(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		private void DisableShadows(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		private void CheckCharacterModel(GameObject prefab)
		{
		}

		private void CheckBrokenModelForProps(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		private static void CheckModel(GameObject prefab, PrefabTypeIdentifier identifier, string modelName, bool shouldBeActive)
		{
		}

		private void CheckCraftProcess(GameObject prefab, PrefabTypeIdentifier identifier)
		{
		}

		private void CheckDropTargetsForLarderTiles(GameObject prefab)
		{
		}

		private void CheckIfModelChildPresentForGameObjectX(GameObject prefab)
		{
		}

		private void CheckChildNamesRecursive(GameObject prefab, PrefabTypeIdentifier identifier, string hierarchy)
		{
		}

		private void CheckRigidBodiesAreKinematic(GameObject prefab)
		{
		}

		internal string GetPrefabIdFromHash(int hashCode)
		{
			return null;
		}

		public (GameObject, List<SnappingPointInfo>) GetPrefabAsEntity(int world, string prefabName, Vector3 scale)
		{
			return default((GameObject, List<SnappingPointInfo>));
		}

		public (GameObject, List<SnappingPointInfo>) AddPrefabAsEntityPrefab(int world, GameObject prefab, Vector3 scale)
		{
			return default((GameObject, List<SnappingPointInfo>));
		}

		public static void AddWorld(int world)
		{
		}

		private static (GameObject, List<SnappingPointInfo>)? GetEntityPrefabOrDefault(int world, string name)
		{
			return null;
		}

		private static void AddEntityPrefab(int world, string name, (GameObject go, List<SnappingPointInfo> info) entityInfo)
		{
		}
	}
}
