using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.GameEventSystem;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class CropBlightManager : MonoSingleton<CropBlightManager>
	{
		[SerializeField]
		private GameObject blightPrefab;

		private const int SpreadIntervalMinutes = 20;

		private const int DecreaseHealthIntervalMinutes = 3;

		private static readonly FloatRange HealthDamageRange = new FloatRange(0.3f, 0.4f);

		private readonly Dictionary<Vec3Int, GameObject> usedObjects = new Dictionary<Vec3Int, GameObject>();

		private readonly List<GameObject> unusedObjects = new List<GameObject>();

		private InterpolatedValueList blightSpotsByRaidPoints;

		private WorldDate dateAndTime;

		private List<Vec3Int> shuffledNeighbors;

		private static HashSet<Vec3Int> CropBlightPositions => VillageManager.ActiveVillage.Map.CropBlightPositions.Set;

		private WorldDate DateAndTime
		{
			get
			{
				if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || GlobalSaveController.CurrentVillageData == null)
				{
					return null;
				}
				return dateAndTime ?? (dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime);
			}
		}

		public static bool IsCropBlightPossible()
		{
			foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.PlantMapResource))
			{
				if (worldObject is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.Blueprint != null && plantMapResourceInstance.Blueprint.CanHaveBlight)
				{
					return true;
				}
			}
			return false;
		}

		public void StartBlight()
		{
			float raidPoints = MonoSingleton<BaseWealth>.Instance.GetRaidPoints();
			int num = (int)blightSpotsByRaidPoints.GetMultiplierInterpolated((int)raidPoints);
			List<PlantMapResourceInstance> list = new List<PlantMapResourceInstance>();
			foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.PlantMapResource))
			{
				if (worldObject is PlantMapResourceInstance plantMapResourceInstance && !(plantMapResourceInstance.Blueprint == null) && plantMapResourceInstance.Blueprint.CanHaveBlight && !HasPlantBlight(plantMapResourceInstance) && !usedObjects.ContainsKey(plantMapResourceInstance.GridDataPosition))
				{
					list.Add(plantMapResourceInstance);
				}
			}
			if (list.Count == 0)
			{
				Log.Info("No plants to start blight.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CropBlightManager.cs");
				return;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				PlantMapResourceInstance plantMapResourceInstance2 = list.PickRandom();
				list.Remove(plantMapResourceInstance2);
				AddBlight(plantMapResourceInstance2.GridDataPosition);
				if (list.Count == 0 || num2++ >= num)
				{
					break;
				}
			}
		}

		public bool HasPlantBlight(PlantMapResourceInstance plant)
		{
			return CropBlightPositions.Contains(plant.GridDataPosition);
		}

		public bool IsBlightAt(Vec3Int gridPosition)
		{
			return CropBlightPositions.Contains(gridPosition);
		}

		public static bool IsBlightActive()
		{
			return CropBlightPositions.Any();
		}

		private void Start()
		{
			blightSpotsByRaidPoints = Repository<CropBlightSpotsByRaidPointsData, InterpolatedValueList>.Instance.GetData<InterpolatedValueList>();
			MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent += OnTimeUpdate;
			MonoSingleton<FloraController>.Instance.DestroyResourceEvent += OnPlantRemove;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.TimeUpdateEvent -= OnTimeUpdate;
			}
			if (MonoSingleton<FloraController>.IsInstantiated())
			{
				MonoSingleton<FloraController>.Instance.DestroyResourceEvent -= OnPlantRemove;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			base.OnDestroy();
		}

		private void OnGameLoaded(bool isLoadedFromSave)
		{
			if (!isLoadedFromSave)
			{
				return;
			}
			foreach (Vec3Int cropBlightPosition in CropBlightPositions)
			{
				InstantiateBlightGameObject(cropBlightPosition);
			}
		}

		private void OnTimeUpdate()
		{
			if (DateAndTime.MinutesTotal % 3 == 0L)
			{
				DecreaseHealth();
			}
			if (DateAndTime.MinutesTotal % 20 == 0L)
			{
				SpreadBlight();
			}
		}

		private void OnPlantRemove(PlantMapResourceInstance plant)
		{
			if (plant != null)
			{
				RemoveBlight(plant.GridDataPosition);
			}
		}

		private void SpreadBlight()
		{
			if (CropBlightPositions.Count == 0)
			{
				return;
			}
			if (shuffledNeighbors == null)
			{
				shuffledNeighbors = new List<Vec3Int>(MapNodeUtils.NeighborsXZ);
			}
			shuffledNeighbors.ShuffleInPlace();
			VillageMap map = VillageManager.ActiveVillage.Map;
			foreach (Vec3Int item in CropBlightPositions.Shuffle())
			{
				Vec3Int a = item;
				foreach (Vec3Int shuffledNeighbor in shuffledNeighbors)
				{
					Vec3Int vec3Int = a + shuffledNeighbor;
					if (!GridDataIndexTools.InRange(vec3Int) || CropBlightPositions.Contains(vec3Int))
					{
						continue;
					}
					MapNode node = map.GetNode(vec3Int);
					if (node != null && node.CheckIsDataType(GridDataType.PlantMapResource))
					{
						PlantMapResourceInstance plantMapResourceInstance = (PlantMapResourceInstance)node.GetWorldObject(GridDataType.PlantMapResource);
						if (plantMapResourceInstance != null && !(plantMapResourceInstance.Blueprint == null) && plantMapResourceInstance.Blueprint.CanHaveBlight)
						{
							AddBlight(vec3Int);
							return;
						}
					}
				}
			}
		}

		private void DecreaseHealth()
		{
			if (CropBlightPositions.Count == 0)
			{
				return;
			}
			foreach (Vec3Int item in CropBlightPositions.Shuffle())
			{
				if (VillageManager.ActiveVillage.Map.GetNode(item).GetWorldObject(GridDataType.PlantMapResource) is PlantMapResourceInstance plantMapResourceInstance)
				{
					StatInstance stat = plantMapResourceInstance.GetStat(StatType.Health);
					float num = HealthDamageRange.Random();
					float current2 = plantMapResourceInstance.GetStatValue(StatType.Health) - num;
					stat.SetCurrent(current2);
					if (stat.IsAtMinimum())
					{
						plantMapResourceInstance.SetLastPhase();
					}
				}
			}
		}

		private void AddBlight(Vec3Int gridPosition)
		{
			CropBlightPositions.Add(gridPosition);
			InstantiateBlightGameObject(gridPosition);
			MonoSingleton<CropBlightController>.Instance.BlightAddedToGridPosition(gridPosition);
			if (CropBlightPositions.Count == 1)
			{
				MonoSingleton<CropBlightController>.Instance.BlightStarted();
			}
		}

		private void RemoveBlight(Vec3Int gridPosition)
		{
			if (CropBlightPositions.Contains(gridPosition))
			{
				CropBlightPositions.Remove(gridPosition);
				GameObject gameObject = usedObjects[gridPosition];
				if (gameObject != null)
				{
					DeactivateBlightGameObject(gameObject);
				}
				MonoSingleton<CropBlightController>.Instance.BlightRemovedFromGridPosition(gridPosition);
				if (CropBlightPositions.Count == 0)
				{
					MonoSingleton<CropBlightController>.Instance.BlightEnded();
				}
			}
		}

		private GameObject InstantiateBlightGameObject(Vec3Int gridPosition)
		{
			if (usedObjects.ContainsKey(gridPosition))
			{
				return null;
			}
			GameObject gameObject;
			if (unusedObjects.Count > 0)
			{
				gameObject = unusedObjects[0];
				unusedObjects.RemoveAt(0);
			}
			else
			{
				gameObject = Object.Instantiate(MonoRepository<PrefabRepository, NSMedieval.Model.KeyGameObjectPair>.Instance.GetByID("Blight").Value, base.transform, worldPositionStays: true);
			}
			gameObject.transform.position = GridUtils.GetWorldPosition(gridPosition);
			gameObject.SetActive(value: true);
			usedObjects.Add(gridPosition, gameObject);
			return gameObject;
		}

		private void DeactivateBlightGameObject(GameObject gameObject)
		{
			usedObjects.RemoveAll((KeyValuePair<Vec3Int, GameObject> kvp) => kvp.Value == null || gameObject.Equals(kvp.Value));
			unusedObjects.Add(gameObject);
			gameObject.SetActive(value: false);
		}
	}
}
