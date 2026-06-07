using Assets.Scripts.Flight;
using GPUInstancerPro.TerrainModule;
using UnityEngine;

namespace Assets.Scripts.Environment.Vegetation
{
	public class TerrainVegetationScript : MonoBehaviour
	{
		private readonly TreeInstance[] _noTrees = new TreeInstance[0];

		[HideInInspector]
		private GPUITerrainBuiltin _gpuInstancerTerrain;

		[SerializeField]
		private GPUITreeManager[] _gpuInstancerTerrainManagers;

		[HideInInspector]
		private UnityEngine.Terrain _terrain;

		private TreeInstance[] _treeInstances;

		private TreeInstance[] _treeInstancesOriginal;

		public UnityEngine.Terrain Terrain => _terrain;

		public TreeInstance[] TreeInstances
		{
			get
			{
				return _treeInstances;
			}
			set
			{
				_treeInstances = value;
				_gpuInstancerTerrain.SetTreeInstances(value);
				FlightSceneScript.Instance.TreeColliderManager.RebuildTreeData(this);
				ClearInternalTreeInstances();
			}
		}

		public TreeInstance[] TreeInstancesOriginal => _treeInstancesOriginal;

		public void ClearInternalTreeInstances()
		{
			_terrain.terrainData.treeInstances = _noTrees;
			_terrain.Flush();
		}

		protected void Awake()
		{
			_terrain = GetComponent<UnityEngine.Terrain>();
			_gpuInstancerTerrain = GetComponent<GPUITerrainBuiltin>();
			if (Game.Instance.Device.IsUnityEditor)
			{
				_terrain.terrainData = Object.Instantiate(_terrain.terrainData);
			}
			_treeInstancesOriginal = _terrain.terrainData.treeInstances;
			_treeInstances = _treeInstancesOriginal;
		}

		protected virtual void OnDestroy()
		{
			_terrain.terrainData.treeInstances = _treeInstancesOriginal;
			_terrain.Flush();
		}

		protected virtual void OnDisable()
		{
			FlightSceneScript.Instance?.TreeColliderManager.UnregisterTerrain(this);
			if (_gpuInstancerTerrainManagers != null)
			{
				GPUITreeManager[] gpuInstancerTerrainManagers = _gpuInstancerTerrainManagers;
				for (int i = 0; i < gpuInstancerTerrainManagers.Length; i++)
				{
					gpuInstancerTerrainManagers[i].RemoveTerrain(_terrain);
				}
			}
		}

		protected virtual void OnEnable()
		{
			FlightSceneScript.Instance?.TreeColliderManager.RegisterTerrain(this);
			if (_gpuInstancerTerrainManagers != null)
			{
				GPUITreeManager[] gpuInstancerTerrainManagers = _gpuInstancerTerrainManagers;
				for (int i = 0; i < gpuInstancerTerrainManagers.Length; i++)
				{
					gpuInstancerTerrainManagers[i].AddTerrain(_terrain);
				}
			}
		}
	}
}
