using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public class GPUITreeChopper : GPUIInputHandler
	{
		public GPUITerrain gpuiTerrain;

		public GPUITreeManager treeManager;

		private TerrainData _terrainData;

		private TerrainCollider _terrainCollider;

		private Collider _chopperCollider;

		private Bounds _removalBounds = new Bounds(Vector3.zero, Vector3.one * 0.1f);

		private TreeInstance[] _treeCache;

		private TreePrototype[] _treePrototypes;

		private TreeInstance[] _currentTreeInstances;

		private void OnEnable()
		{
			if (gpuiTerrain == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Terrain is not assigned!");
				return;
			}
			if (treeManager == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Tree Manager is not assigned!");
				return;
			}
			_terrainData = gpuiTerrain.GetComponent<Terrain>().terrainData;
			_terrainCollider = gpuiTerrain.GetComponent<TerrainCollider>();
			_treeCache = _terrainData.treeInstances;
			_currentTreeInstances = _treeCache;
			_treePrototypes = _terrainData.treePrototypes;
			_chopperCollider = GetComponent<Collider>();
			OnTriggerEnter(_terrainCollider);
		}

		private void Update()
		{
			if (GetKeyDown(KeyCode.Alpha1))
			{
				ResetTrees();
			}
		}

		private void OnDisable()
		{
			if (_terrainData != null)
			{
				_terrainData.treeInstances = _treeCache;
			}
		}

		private void ResetTrees()
		{
			GPUITerrainAPI.SetTreeInstances(gpuiTerrain, _treeCache);
			_currentTreeInstances = _treeCache;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!(other == _terrainCollider))
			{
				return;
			}
			Vector3 position = gpuiTerrain.GetPosition();
			int num = _currentTreeInstances.Length;
			Bounds bounds = _chopperCollider.bounds;
			for (int i = 0; i < num; i++)
			{
				Vector3 vector = Vector3.Scale(_currentTreeInstances[i].position, _terrainData.size) + position;
				if (bounds.Contains(vector))
				{
					_removalBounds.center = vector;
					RemoveTreeFromTerrain(i);
					num--;
				}
			}
		}

		private void RemoveTreeFromTerrain(int treeIndex)
		{
			Debug.Log(GPUIConstants.LOG_PREFIX + "Removing tree at index: " + treeIndex + ", position: " + _removalBounds.center.ToString());
			TreeInstance treeInstance = _currentTreeInstances[treeIndex];
			_currentTreeInstances = _currentTreeInstances.RemoveAtAndReturn(treeIndex);
			GPUITerrainAPI.SetTreeInstances(gpuiTerrain, _currentTreeInstances);
			GenerateCutTree(_treePrototypes[treeInstance.prototypeIndex].prefab, _removalBounds.center, Quaternion.Euler(0f, treeInstance.rotation * 57.29578f, 0f));
		}

		private void GenerateCutTree(GameObject treePrefab, Vector3 position, Quaternion rotation)
		{
			GameObject obj = Object.Instantiate(treePrefab, position, rotation);
			obj.AddComponent<GPUIObjectDestroyer>().timeToDestroy = 2f;
			if (obj.TryGetComponent<Collider>(out var component))
			{
				Object.Destroy(component);
			}
			obj.AddComponent<Rigidbody>().AddForce(base.transform.forward * 5f, ForceMode.Impulse);
		}
	}
}
