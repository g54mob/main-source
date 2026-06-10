using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Crops
{
	[Serializable]
	[FVSerializableKey("CropfieldInstance", "")]
	public class CropfieldInstance : WorldObject
	{
		public const int MinSowDateDefault = 1;

		public const int MaxSowDateDefault = 31;

		[SerializeField]
		private string cultivablePlantID;

		[SerializeField]
		private List<Vec3Int> gridPositions = new List<Vec3Int>();

		[SerializeField]
		private BuildingSubCategoryUI buildingSubcategoryUI;

		[SerializeField]
		private SerializableDictionaryVec3IntPlantInstance crops = new SerializableDictionaryVec3IntPlantInstance();

		[SerializeField]
		private Vec3Int start;

		[SerializeField]
		private Vec3Int end;

		[SerializeField]
		private Vec3Int offset;

		[SerializeField]
		private int harvestPhase;

		[SerializeField]
		private int cutPhase;

		[SerializeField]
		private bool dontSow;

		[SerializeField]
		private ZonePriority priority;

		[SerializeField]
		private int minSowDate;

		[SerializeField]
		private int maxSowDate;

		[NonSerialized]
		private List<Vec3Int> worldPositions = new List<Vec3Int>();

		private HashSet<Vec3Int> reserved = new HashSet<Vec3Int>();

		private PlantMapResource cultivablePlant;

		[NonSerialized]
		private Cropfield blueprint;

		[NonSerialized]
		private Vec3Int[,] area;

		public override bool BlueprintExists => Blueprint != null;

		public int HarvestPhase => harvestPhase;

		public int CutPhase => cutPhase;

		public Vec3Int Offset => offset;

		public int CropsCount => Crops.Count;

		public List<Vec3Int> WorldPositions => worldPositions;

		public ZonePriority Priority => priority;

		public Vec3Int[,] Area
		{
			get
			{
				if (area == null)
				{
					area = RecalculateArea();
				}
				return area;
			}
			private set
			{
				area = value;
			}
		}

		public Vec3Int Start
		{
			get
			{
				return start;
			}
			set
			{
				start = value;
			}
		}

		public Vec3Int End
		{
			get
			{
				return end;
			}
			set
			{
				end = value;
			}
		}

		public Cropfield Blueprint
		{
			get
			{
				if (blueprint == null)
				{
					blueprint = Repository<CropfieldRepository, Cropfield>.Instance.GetByID(blueprintId);
				}
				return blueprint;
			}
		}

		public PlantMapResource CultivablePlant
		{
			get
			{
				if (cultivablePlant == null)
				{
					cultivablePlant = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(cultivablePlantID);
				}
				return cultivablePlant;
			}
		}

		public override List<Vec3Int> Positions => gridPositions;

		public HashSet<Vec3Int> Reserved
		{
			get
			{
				if (reserved == null)
				{
					reserved = new HashSet<Vec3Int>();
				}
				return reserved;
			}
		}

		public BuildingSubCategoryUI BuildingSubcategoryUI => buildingSubcategoryUI;

		public bool DontSow => dontSow;

		public Dictionary<Vec3Int, PlantMapResourceInstance> Crops => crops.Dictionary;

		public int MinSowDate => minSowDate;

		public int MaxSowDate => maxSowDate;

		public CropfieldInstance(Cropfield model, Vector3 worldPosition, Vec3Int[,] area, Vec3Int start, Vec3Int end)
			: base(WorldObjectType.Cropfield, worldPosition, Vec3Int.one)
		{
			blueprintId = model.GetID();
			blueprint = model;
			cultivablePlant = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(blueprint.DefaultPlant.GetID());
			cultivablePlantID = cultivablePlant.GetID();
			buildingSubcategoryUI = model.BuildingSubCategoryUI;
			this.start = start;
			this.end = end;
			UpdateArea(area, newObjectCreated: true);
			harvestPhase = blueprint.DefaultPlant.HarvestPhase;
			cutPhase = Blueprint.DefaultPlant.CutPhase;
			MonoSingleton<FloraController>.Instance.HarvestFinishedEvent += OnHarvestFinished;
			MonoSingleton<FloraController>.Instance.CuttingFinishedEvent += OnCuttingFinished;
			MonoSingleton<FloraController>.Instance.DestroyResourceEvent += OnPlantChangeLifePhase;
			minSowDate = 1;
			maxSowDate = 31;
		}

		public CropfieldInstance()
		{
		}

		public void OnLoaded()
		{
			blueprint = Repository<CropfieldRepository, Cropfield>.Instance.GetByID(base.BlueprintId);
			MonoSingleton<FloraController>.Instance.HarvestFinishedEvent += OnHarvestFinished;
			MonoSingleton<FloraController>.Instance.CuttingFinishedEvent += OnCuttingFinished;
			MonoSingleton<FloraController>.Instance.DestroyResourceEvent += OnPlantChangeLifePhase;
			RemoveDeadCrops();
			CalculateReachability();
		}

		public void RefreshPlantsAfterLoading()
		{
			MonoSingleton<CropsController>.Instance.CropfieldCutPhaseChanged(this);
			MonoSingleton<CropsController>.Instance.CropfieldHarvestPhaseChanged(this);
		}

		public override SelectableObject GetView()
		{
			return MonoSingleton<CropsManager>.Instance.GetView(this);
		}

		public void SetHarvestPhase(int harvestPhase)
		{
			this.harvestPhase = harvestPhase;
			MonoSingleton<CropsController>.Instance.CropfieldHarvestPhaseChanged(this);
		}

		public void SetCutPhase(int cutPhase)
		{
			this.cutPhase = cutPhase;
			MonoSingleton<CropsController>.Instance.CropfieldCutPhaseChanged(this);
		}

		public SimpleResourceCount GetSeedsOrder()
		{
			int unreservedCount = GetUnreservedCount();
			int allowedCount = MonoSingleton<ResourcePileTracker>.Instance.GetCount(Blueprint.SeedBlueprint).AllowedCount;
			if (unreservedCount <= 0 || allowedCount <= 0)
			{
				return default(SimpleResourceCount);
			}
			if (unreservedCount <= allowedCount)
			{
				return new SimpleResourceCount(Blueprint.SeedBlueprint, unreservedCount);
			}
			return new SimpleResourceCount(Blueprint.SeedBlueprint, allowedCount);
		}

		public void SetPriority(ZonePriority priority)
		{
			this.priority = priority;
			foreach (PlantMapResourceInstance value in Crops.Values)
			{
				value?.SetPriority(priority);
			}
		}

		public void DestroySingleCrop(Vec3Int gridPosition)
		{
			gridPosition.y *= World.MapBlockHeight;
			if (Crops.ContainsKey(gridPosition))
			{
				MonoSingleton<FloraController>.Instance.DestroyResource(Crops[gridPosition]);
				Crops.Remove(gridPosition);
			}
		}

		public bool IsExpandValid(Vec3Int[,] area)
		{
			List<Vec3Int> list = new List<Vec3Int>();
			for (int i = 0; i < area.GetLength(0); i++)
			{
				for (int j = 0; j < area.GetLength(1); j++)
				{
					if (!area[i, j].Equals(Vec3Int.zero))
					{
						list.Add(area[i, j]);
					}
				}
			}
			foreach (Vec3Int gridPosition in gridPositions)
			{
				if (list.Contains(gridPosition))
				{
					return true;
				}
			}
			return false;
		}

		public void UpdateArea(Vec3Int[,] area, bool newObjectCreated = false)
		{
			Area = area;
			gridPositions.Clear();
			for (int i = 0; i < area.GetLength(0); i++)
			{
				for (int j = 0; j < area.GetLength(1); j++)
				{
					if (!new Vec3Int(area[i, j].x, area[i, j].y * World.MapBlockHeight, area[i, j].z).Equals(Vec3Int.zero))
					{
						Vec3Int item = area[i, j];
						if (!gridPositions.Contains(item))
						{
							gridPositions.Add(item);
						}
					}
				}
			}
			if (!newObjectCreated)
			{
				VillageManager.ActiveVillage.Map.OnWorldObjectSizeChanged(this);
			}
		}

		public void UpdateDomesticPlants()
		{
			foreach (Vec3Int item in Crops.Keys.ToList())
			{
				if (!gridPositions.Contains(item) && Crops.ContainsKey(item))
				{
					Crops[item].SetHarvestPhase(-1);
					Crops[item].SetCutPhase(-1);
					Crops[item].SetDomestic(domestic: false);
					if (!Crops[item].PlayerOrder)
					{
						Crops[item].SetCurrentOrder(OrderType.None);
					}
					Crops.Remove(item);
				}
			}
		}

		public List<Vec3Int> AvailableGridspaces()
		{
			List<Vec3Int> list = new List<Vec3Int>();
			foreach (Vec3Int gridPosition in gridPositions)
			{
				if (!PlantingBocked(gridPosition) && !Reserved.Contains(gridPosition))
				{
					if (!Crops.ContainsKey(gridPosition))
					{
						list.Add(gridPosition);
					}
					else if (Crops[gridPosition] == null)
					{
						list.Add(gridPosition);
					}
				}
			}
			return list;
		}

		public void SetPlant(PlantMapResource plant)
		{
			cultivablePlantID = plant.GetID();
			cultivablePlant = plant;
		}

		public bool ContainsGridspace(Vec3Int gridspace)
		{
			return gridPositions.Contains(gridspace);
		}

		public bool HasFreeSpace()
		{
			for (int num = gridPositions.Count - 1; num >= 0; num--)
			{
				Vec3Int vec3Int = gridPositions[num];
				if (!PlantingBocked(vec3Int) && !Reserved.Contains(vec3Int))
				{
					if (!Crops.ContainsKey(vec3Int))
					{
						return true;
					}
					if (Crops[vec3Int] == null)
					{
						return true;
					}
				}
			}
			return false;
		}

		public int GetFreeSpace()
		{
			int num = 0;
			foreach (Vec3Int gridPosition in gridPositions)
			{
				if (!PlantingBocked(gridPosition))
				{
					if (!Crops.ContainsKey(gridPosition))
					{
						num++;
					}
					else if (Crops[gridPosition] == null)
					{
						num++;
					}
				}
			}
			return num;
		}

		public bool HasPlant(Vec3Int gridPosition)
		{
			Vec3Int key = gridPosition;
			key.y *= World.MapBlockHeight;
			return Crops.ContainsKey(key);
		}

		public bool IsOccupied(Vec3Int gridPos)
		{
			return Reserved.Contains(gridPos);
		}

		public void SetOccupied(Vec3Int gridPos)
		{
			Reserved.Add(gridPos);
		}

		public void RemoveOccupied(Vec3Int gridPos)
		{
			Reserved.Remove(gridPos);
		}

		public int GetUnreservedCount()
		{
			return GetFreeSpace() - Reserved.Count;
		}

		public void PlantCrop(Vec3Int gridPos)
		{
			if (!gridPositions.Contains(gridPos) || (Crops.ContainsKey(gridPos) && Crops[gridPos] != null))
			{
				return;
			}
			PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(cultivablePlantID);
			PlantMapResourceInstance plantMapResourceInstance = new PlantMapResourceInstance(byID, byID.PrefabIDs.PickRandom(), GridUtils.GetWorldPosition(gridPos), domestic: true);
			Crops.Add(gridPos, plantMapResourceInstance);
			MonoSingleton<PlantResourceManager>.Instance.SpawnPlantMapResourceInstance(plantMapResourceInstance);
			using (ProfilerSampleJanitor.Begin("Set Plant State"))
			{
				plantMapResourceInstance.SetHarvestPhase(harvestPhase);
				plantMapResourceInstance.SetCutPhase(cutPhase);
				plantMapResourceInstance.SetPriority(priority);
			}
			using (ProfilerSampleJanitor.Begin("FloraController.SpawnCrop"))
			{
				MonoSingleton<FloraController>.Instance.SpawnCrop(plantMapResourceInstance);
			}
			if (MonoSingleton<PlantResourceManager>.Instance.ForceHarvestPhase)
			{
				using (ProfilerSampleJanitor.Begin("ForceHarvestPhase"))
				{
					plantMapResourceInstance.ForceHarvestPhase();
				}
			}
			if (!MonoSingleton<PlantResourceManager>.Instance.ForceCutPhase)
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("ForceCutPhase"))
			{
				plantMapResourceInstance.ForceCutPhase();
			}
		}

		public void CropCreatedOverExistingPlant(PlantMapResourceInstance plantMapResourceInstance)
		{
			if (!(Blueprint.DefaultPlant != plantMapResourceInstance.Blueprint))
			{
				Vec3Int key = plantMapResourceInstance.GridDataPosition;
				if (!Crops.ContainsKey(key))
				{
					Crops.Add(key, plantMapResourceInstance);
				}
			}
		}

		public void StartNextPhaseDebug()
		{
			Vec3Int[] array = Crops.Keys.ToArray();
			foreach (Vec3Int key in array)
			{
				Crops[key].StartNextPhaseDebug();
			}
		}

		public override void ReInstantiate()
		{
			base.ReInstantiate();
			Vec3Int[] array = Crops.Keys.ToArray();
			foreach (Vec3Int key in array)
			{
				Crops[key].SetPriority(priority);
			}
		}

		public override int GetMaxReservers()
		{
			return GetFreeSpace();
		}

		public override void Dispose()
		{
			MonoSingleton<CropsController>.Instance.CropfieldDestroyed(this);
			MonoSingleton<FloraController>.Instance.HarvestFinishedEvent -= OnHarvestFinished;
			MonoSingleton<FloraController>.Instance.CuttingFinishedEvent -= OnCuttingFinished;
			MonoSingleton<FloraController>.Instance.DestroyResourceEvent -= OnPlantChangeLifePhase;
			Vec3Int[] array = Crops.Keys.ToArray();
			foreach (Vec3Int key in array)
			{
				if (!Crops[key].PlayerOrder)
				{
					Crops[key].SetCurrentOrder(OrderType.None);
				}
			}
			MonoSingleton<CropsManager>.Instance.Destroy(this);
			base.Dispose();
			crops?.Dictionary.Clear();
			crops = null;
			cultivablePlant = null;
		}

		public override float GetBeautyInput()
		{
			return 0f;
		}

		public void ChangeCropType(Cropfield model)
		{
			if (!(Blueprint == model))
			{
				blueprintId = model.GetID();
				blueprint = model;
				cultivablePlant = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(blueprint.DefaultPlant.GetID());
				cultivablePlantID = cultivablePlant.GetID();
				harvestPhase = blueprint.DefaultPlant.HarvestPhase;
				MonoSingleton<CropsController>.Instance.CropfieldPlantTypeChanged(this);
				MonoSingleton<CropsManager>.Instance.CropPlantTypeChanged(this);
			}
		}

		public void SetDontSow(bool dontSow)
		{
			this.dontSow = dontSow;
		}

		public void SetSowRange(int minSowDate, int maxSowDate)
		{
			this.minSowDate = minSowDate;
			this.maxSowDate = maxSowDate;
		}

		private Vec3Int[,] RecalculateArea()
		{
			Vec3Int other = gridPositions[0];
			Vec3Int other2 = gridPositions[0];
			foreach (Vec3Int gridPosition in gridPositions)
			{
				other = gridPosition.Min(other);
				other2 = gridPosition.Max(other2);
			}
			int num = other2.x - other.x + 1;
			int num2 = other2.z - other.z + 1;
			Vec3Int[,] array = new Vec3Int[num, num2];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array[i, j] = new Vec3Int(other.x + i, other.y, other.z + j);
				}
			}
			return array;
		}

		private void RemoveDeadCrops()
		{
			if (crops?.Dictionary == null)
			{
				Log.Error("Something is not right in CropfieldInstance.RemoveDeadCrops", "C:\\GIT\\dev\\Assets\\Scripts\\Crops\\CropfieldInstance.cs");
				return;
			}
			foreach (Vec3Int item in crops.Dictionary.Keys.ToList())
			{
				if (crops.Dictionary[item] == null || crops.Dictionary[item].CurrentPhase == -1)
				{
					crops.Dictionary.Remove(item);
				}
			}
		}

		private void OnHarvestFinished(PlantMapResourceInstance instance)
		{
			if (instance.Blueprint.DestroyOnHarvest)
			{
				UpdateWhenPlantIsCut(instance);
			}
		}

		private void OnCuttingFinished(PlantMapResourceInstance instance)
		{
			UpdateWhenPlantIsCut(instance);
		}

		private void OnPlantChangeLifePhase(PlantMapResourceInstance plant)
		{
			if (plant.CurrentPhase == -1)
			{
				UpdateWhenPlantIsCut(plant);
			}
		}

		private void UpdateWhenPlantIsCut(PlantMapResourceInstance instance)
		{
			Vec3Int key = instance.GridDataPosition;
			if (Crops.ContainsKey(key))
			{
				Crops.Remove(key);
			}
		}

		private bool PlantingBocked(Vec3Int gridPosition)
		{
			MapNode node = base.Map.GetNode(gridPosition);
			if ((node.DataType & GridDataType.BuildingFinished) == 0 && (node.DataType & GridDataType.PlantMapResource) == 0)
			{
				return node.Map.FireSimLogic.GetFireData(node.Index) > 0f;
			}
			return true;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("cultivablePlantID", cultivablePlantID);
			serializer.Write("gridPositions", gridPositions);
			serializer.WriteEnum("buildingSubcategoryUI", buildingSubcategoryUI);
			serializer.Write("crops", crops);
			serializer.Write("start", start);
			serializer.Write("end", end);
			serializer.Write("offset", offset);
			serializer.Write("harvestPhase", harvestPhase);
			serializer.Write("cutPhase", cutPhase);
			serializer.Write("dontSow", dontSow);
			serializer.WriteEnum("priority", priority);
			serializer.Write("minSowDate", minSowDate);
			serializer.Write("maxSowDate", maxSowDate);
		}

		public CropfieldInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			cultivablePlantID = deserializer.ReadString("cultivablePlantID");
			gridPositions = deserializer.ReadObjectList<Vec3Int>("gridPositions");
			buildingSubcategoryUI = deserializer.ReadEnum("buildingSubcategoryUI", BuildingSubCategoryUI.None);
			crops = deserializer.ReadObject<SerializableDictionaryVec3IntPlantInstance>("crops");
			start = deserializer.ReadVec3Int("start");
			end = deserializer.ReadVec3Int("end");
			offset = deserializer.ReadVec3Int("offset");
			harvestPhase = deserializer.ReadInt("harvestPhase");
			cutPhase = deserializer.ReadInt("cutPhase");
			dontSow = deserializer.ReadBool("dontSow");
			priority = deserializer.ReadEnum("priority", ZonePriority.None);
			minSowDate = deserializer.ReadInt("minSowDate");
			if (minSowDate == 0)
			{
				minSowDate = 1;
			}
			maxSowDate = deserializer.ReadInt("maxSowDate");
			if (maxSowDate == 0)
			{
				maxSowDate = 31;
			}
		}
	}
}
