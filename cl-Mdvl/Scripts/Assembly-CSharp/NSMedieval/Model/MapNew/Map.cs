using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	[FVSerializableKey("Map", "")]
	public class Map : NSEipix.Base.Model, IFVSerializable
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private bool isDevOnly;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private int flatHeight;

		[SerializeField]
		private float globalWaterHeight;

		[SerializeField]
		private string defaultVoxelType = string.Empty;

		[SerializeField]
		private float minPlantsPercent = 100f;

		[SerializeField]
		private float minFishPercentage = 100f;

		[SerializeField]
		private List<VoxelTypeDistribution> voxelTypeDistribution;

		[SerializeField]
		private List<MapGenerationStep2> mapGenerationSteps;

		[SerializeField]
		private uint initialPenalty;

		[SerializeField]
		private List<AnimalPlacement> animals = new List<AnimalPlacement>();

		[SerializeField]
		private List<Season> seasonOverrides;

		[SerializeField]
		private float riverCreationChance = 0.95f;

		[SerializeField]
		private FloatRange riverStartWidth = new FloatRange(1.5f, 2f);

		[SerializeField]
		private FloatRange riverEndWidth = new FloatRange(2f, 3.5f);

		[SerializeField]
		private FloatRange riverIslandAmount = new FloatRange(0f, 0.7f);

		[SerializeField]
		private FloatRange riverTerrainInfluence = new FloatRange(0.06f, 0.3f);

		[SerializeField]
		private FloatRange riverCurveNoiseAmount = new FloatRange(0.05f, 0.3f);

		[SerializeField]
		private bool waterFlowInOutEnabled = true;

		[NonSerialized]
		private bool seasonOverridesInitialized;

		[NonSerialized]
		private Dictionary<string, Season> seasonOverridesCache;

		[NonSerialized]
		private bool plantsByVoxelTypesCacheInitialized;

		[NonSerialized]
		private Dictionary<VoxelType, HashSet<string>> plantsByVoxelTypesCache;

		[NonSerialized]
		private Dictionary<Vec3Int, Dictionary<WaterDepthLevel, List<PlantMapResource>>> plantsDistributionCache;

		public Dictionary<VoxelType, HashSet<string>> PlantsByVoxelTypesCache
		{
			get
			{
				if (!plantsByVoxelTypesCacheInitialized)
				{
					plantsByVoxelTypesCacheInitialized = true;
					plantsByVoxelTypesCache = new Dictionary<VoxelType, HashSet<string>>();
					foreach (MapGenerationStep2 mapGenerationStep in mapGenerationSteps)
					{
						List<MapPropType> list = mapGenerationStep.Props?.PropsToPlace;
						if (list == null)
						{
							continue;
						}
						foreach (MapPropType item in list)
						{
							if (item.ResourceType != MapPropResourceType.Plant)
							{
								continue;
							}
							foreach (VoxelType placeOnlyOnVoxel in mapGenerationStep.Props.PlaceOnlyOnVoxels)
							{
								if (!plantsByVoxelTypesCache.ContainsKey(placeOnlyOnVoxel))
								{
									plantsByVoxelTypesCache.Add(placeOnlyOnVoxel, new HashSet<string>());
								}
								plantsByVoxelTypesCache[placeOnlyOnVoxel].Add(item.Model);
							}
						}
					}
				}
				return plantsByVoxelTypesCache;
			}
		}

		public int FlatHeight => flatHeight;

		public float GlobalWaterHeight => globalWaterHeight;

		public string DefaultVoxelType => defaultVoxelType;

		public float MinPlantsPercent => minPlantsPercent;

		public float MinFishPercentage => minFishPercentage;

		public List<VoxelTypeDistribution> VoxelTypeDistribution => voxelTypeDistribution;

		public List<MapGenerationStep2> MapGenerationSteps => mapGenerationSteps;

		public uint InitialPenalty => initialPenalty;

		public List<AnimalPlacement> Animals => animals;

		public LocKeys[] LocKeys => locKeys;

		public float RiverCreationChance => riverCreationChance;

		public FloatRange RiverStartWidth => riverStartWidth;

		public FloatRange RiverEndWidth => riverEndWidth;

		public FloatRange RiverIslandAmount => riverIslandAmount;

		public FloatRange RiverTerrainInfluence => riverTerrainInfluence;

		public FloatRange RiverCurveNoiseAmount => riverCurveNoiseAmount;

		public bool WaterFlowInOutEnabled => waterFlowInOutEnabled;

		public bool IsDevOnly => isDevOnly;

		public Map()
		{
		}

		public override string GetID()
		{
			return id;
		}

		public Season GetSeasonOverride(Season season)
		{
			TryInitSeasons();
			if (!seasonOverridesCache.ContainsKey(season.Name))
			{
				return null;
			}
			return seasonOverridesCache[season.Name];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TryInitSeasons()
		{
			if (seasonOverridesInitialized)
			{
				return;
			}
			seasonOverridesInitialized = true;
			seasonOverridesCache = new Dictionary<string, Season>();
			if (seasonOverrides == null)
			{
				return;
			}
			foreach (Season seasonOverride in seasonOverrides)
			{
				seasonOverridesCache.Add(seasonOverride.Name, seasonOverride);
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("locKeys", locKeys);
			serializer.Write("flatHeight", flatHeight);
			serializer.Write("defaultVoxelType", defaultVoxelType);
			serializer.Write("minPlantsPercent", minPlantsPercent);
			serializer.Write("voxelTypeDistribution", voxelTypeDistribution);
			serializer.Write("mapGenerationSteps", mapGenerationSteps);
			serializer.Write("initialPenalty", initialPenalty);
			serializer.Write("animals", animals);
			serializer.Write("seasonOverrides", seasonOverrides);
		}

		public Map(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			locKeys = deserializer.ReadObjectArray<LocKeys>("locKeys");
			flatHeight = deserializer.ReadInt("flatHeight");
			defaultVoxelType = deserializer.ReadString("defaultVoxelType");
			minPlantsPercent = deserializer.ReadFloat("minPlantsPercent");
			voxelTypeDistribution = deserializer.ReadObjectList<VoxelTypeDistribution>("voxelTypeDistribution");
			mapGenerationSteps = deserializer.ReadObjectList<MapGenerationStep2>("mapGenerationSteps");
			initialPenalty = deserializer.ReadUInt("initialPenalty");
			animals = deserializer.ReadObjectList<AnimalPlacement>("animals");
			seasonOverrides = deserializer.ReadObjectList<Season>("seasonOverrides");
		}

		public void GetPlantsDistribution(Vec3Int mapSize, WaterDepthLevel inputWaterDepth, out IReadOnlyList<PlantMapResource> outputPlantsList)
		{
			if (plantsDistributionCache == null)
			{
				plantsDistributionCache = new Dictionary<Vec3Int, Dictionary<WaterDepthLevel, List<PlantMapResource>>>();
			}
			if (!plantsDistributionCache.ContainsKey(mapSize))
			{
				PooledDictionary<PlantMapResource, float> janitor = DictionaryPool<PlantMapResource, float>.GetJanitor();
				try
				{
					foreach (MapGenerationStep2 mapGenerationStep in mapGenerationSteps)
					{
						using PooledHashSet<PlantMapResource> pooledHashSet = HashSetPool<PlantMapResource>.GetJanitor();
						foreach (MapPropType item in mapGenerationStep.Props.PropsToPlace)
						{
							if (item.ResourceType == MapPropResourceType.Plant)
							{
								PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(item.Model);
								if (byID != null)
								{
									pooledHashSet.Add(byID);
								}
							}
						}
						if (pooledHashSet.Count == 0)
						{
							continue;
						}
						float num = (mapGenerationStep.ScaleXRange.Min + mapGenerationStep.ScaleXRange.Max) / 2f;
						float num2 = (mapGenerationStep.ScaleYRange.Min + mapGenerationStep.ScaleYRange.Max) / 2f;
						float num3 = mapGenerationStep.Size.x * num;
						float num4 = mapGenerationStep.Size.y * num2;
						float num5 = mapSize.x;
						float num6 = mapSize.z;
						if (mapGenerationStep.DontScaleWithMap)
						{
							int num7 = 0;
							foreach (string brushID in mapGenerationStep.BrushIDs)
							{
								Texture2D texture2D = AssetUtils.GetTexture2D(brushID);
								if (texture2D != null)
								{
									num5 += (float)texture2D.width;
									num6 += (float)texture2D.height;
									num7++;
								}
							}
							if (num7 > 0)
							{
								num5 /= (float)num7;
								num6 /= (float)num7;
							}
						}
						float num8 = num * num3 * num2 * num4 * num5 * num6;
						foreach (PlantMapResource item2 in pooledHashSet)
						{
							if (!janitor.TryAdd(item2, num8))
							{
								janitor[item2] += num8;
							}
						}
					}
					float num9 = janitor.Values.Sum();
					int num10 = 100;
					PlantMapResource[] array = janitor.Keys.ToArray();
					foreach (PlantMapResource key in array)
					{
						janitor[key] = janitor[key] / num9 * (float)num10;
					}
					Dictionary<WaterDepthLevel, List<PlantMapResource>> dictionary = new Dictionary<WaterDepthLevel, List<PlantMapResource>>();
					WaterDepthLevel[] waterDepthLevel = EnumValues.WaterDepthLevel;
					foreach (WaterDepthLevel waterDepthLevel2 in waterDepthLevel)
					{
						List<PlantMapResource> list = new List<PlantMapResource>(num10);
						foreach (PlantMapResource key2 in janitor.Keys)
						{
							if ((key2.WaterDepthLevel == waterDepthLevel2 && waterDepthLevel2 == WaterDepthLevel.None) || (key2.WaterDepthLevel != WaterDepthLevel.None && key2.WaterDepthLevel >= waterDepthLevel2))
							{
								for (int j = 0; (float)j < janitor[key2]; j++)
								{
									list.Add(key2);
								}
							}
						}
						dictionary.Add(waterDepthLevel2, list);
					}
					plantsDistributionCache.Add(mapSize, dictionary);
				}
				finally
				{
					((IDisposable)janitor/*cast due to .constrained prefix*/).Dispose();
				}
			}
			if (!plantsDistributionCache[mapSize].ContainsKey(inputWaterDepth))
			{
				outputPlantsList = null;
			}
			else
			{
				outputPlantsList = plantsDistributionCache[mapSize][inputWaterDepth];
			}
		}
	}
}
