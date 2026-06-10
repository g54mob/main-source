using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Dictionary;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class VineView : MonoBehaviour
	{
		[SerializeField]
		private SerializableDictionary<NeighbourLocation, GameObject> neighbourMap;

		private PlantMapResourceInstance plantMapResourceInstance;

		private VillageMap map;

		private BuildingsManagerMain buildingManager;

		private BushView bushView;

		private Vec3Int gridPos;

		private bool initialized;

		private Dictionary<Vec3Int, NeighbourLocation> sameLevelNeighbourLocations;

		private Dictionary<Vec3Int, NeighbourLocation> lowerNeighbourLocations;

		public void RefreshVines()
		{
			if (!initialized)
			{
				plantMapResourceInstance = bushView.ResourceInstance;
				if (plantMapResourceInstance == null || plantMapResourceInstance.HasDisposed)
				{
					return;
				}
				map = plantMapResourceInstance.Map;
				gridPos = plantMapResourceInstance.GridDataPosition;
				plantMapResourceInstance.Map.VinesManager.Cache(gridPos, this);
				buildingManager = map.BuildingsManagerMain;
				lowerNeighbourLocations.Add(gridPos + new Vec3Int(0, -1, 1), NeighbourLocation.DownFront);
				lowerNeighbourLocations.Add(gridPos + new Vec3Int(1, -1, 0), NeighbourLocation.DownRight);
				lowerNeighbourLocations.Add(gridPos + new Vec3Int(0, -1, -1), NeighbourLocation.DownBack);
				lowerNeighbourLocations.Add(gridPos + new Vec3Int(-1, -1, 0), NeighbourLocation.DownLeft);
				sameLevelNeighbourLocations.Add(gridPos + new Vec3Int(0, 0, 1), NeighbourLocation.Front);
				sameLevelNeighbourLocations.Add(gridPos + new Vec3Int(1, 0, 0), NeighbourLocation.Right);
				sameLevelNeighbourLocations.Add(gridPos + new Vec3Int(0, 0, -1), NeighbourLocation.Back);
				sameLevelNeighbourLocations.Add(gridPos + new Vec3Int(-1, 0, 0), NeighbourLocation.Left);
				initialized = true;
			}
			foreach (Vec3Int key in sameLevelNeighbourLocations.Keys)
			{
				BaseBuildingInstance buildingInstance = buildingManager.GetBuildingInstance(key, (BaseBuildingInstance x) => x.BuildingType == BuildingType.Wall && x.ConstructionPhase == ConstructionPhase.Finished);
				if (sameLevelNeighbourLocations.TryGetValue(key, out var value) && neighbourMap.Dictionary.TryGetValue(value, out var value2))
				{
					value2.SetActive(buildingInstance != null || MonoSingleton<GroundManager>.Instance.GroundExists(key));
				}
			}
			foreach (Vec3Int key2 in lowerNeighbourLocations.Keys)
			{
				Vec3Int a = key2;
				Vec3Int vec3Int = a + Vec3Int.up;
				bool flag = buildingManager.GetBuildingInstance(vec3Int) == null && !MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int);
				bool flag2 = MonoSingleton<GroundManager>.Instance.GroundExists(a);
				bool flag3 = buildingManager.WallTypeBuildingExists(a);
				if (lowerNeighbourLocations.TryGetValue(a, out var value3) && neighbourMap.Dictionary.TryGetValue(value3, out var value4))
				{
					value4.SetActive(flag && !flag2 && !flag3);
				}
			}
		}

		private void Awake()
		{
			GameObject[] values = neighbourMap.Values;
			for (int i = 0; i < values.Length; i++)
			{
				values[i].SetActive(value: false);
			}
			bushView = GetComponent<BushView>();
			if (!(bushView == null))
			{
				bushView.PhaseChangedUpdateMeshEvent += OnPhaseChangedUpdateMesh;
				sameLevelNeighbourLocations = new Dictionary<Vec3Int, NeighbourLocation>();
				lowerNeighbourLocations = new Dictionary<Vec3Int, NeighbourLocation>();
				if (MonoSingleton<World>.Instance.IsLoaded)
				{
					MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(RefreshVines);
				}
				else
				{
					MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
				}
			}
		}

		private void OnDestroy()
		{
			map?.VinesManager?.RemoveFromCache(gridPos);
			initialized = false;
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			lowerNeighbourLocations?.Clear();
			sameLevelNeighbourLocations?.Clear();
			lowerNeighbourLocations = null;
			sameLevelNeighbourLocations = null;
			bushView = null;
			buildingManager = null;
			map = null;
		}

		private void OnMapLoaded(bool fromSave)
		{
			RefreshVines();
		}

		private void OnPhaseChangedUpdateMesh(MaterialPropertyBlock materialPropertyBlock)
		{
			GameObject[] values = neighbourMap.Values;
			for (int i = 0; i < values.Length; i++)
			{
				values[i].GetComponent<MeshRenderer>().SetPropertyBlock(materialPropertyBlock);
			}
		}
	}
}
