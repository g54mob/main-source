using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Managers;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Map
{
	public class ResourceSpawner : MonoSingleton<ResourceSpawner>
	{
		[NonSerialized]
		private World world;

		[NonSerialized]
		private VillageMap villageMap;

		public void Start()
		{
			world = MonoSingleton<World>.Instance;
			villageMap = VillageManager.ActiveVillage.Map;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			world = null;
			villageMap = null;
		}

		public void PlaceProp(PropPlacement prop, Vector2Int position)
		{
			if (Vector2.Distance(MonoSingleton<StartPositionManager>.Instance.GetStartPositionCenter(), position) < (float)prop.MinDistanceFromWorkers)
			{
				return;
			}
			MapPropType mapPropType = prop.PropsToPlace[UnityEngine.Random.Range(0, prop.PropsToPlace.Count)];
			int resourcePileAmount = prop.ResourcePileAmount.Random();
			if (prop.PlaceOnlyInWater)
			{
				int heightAt = MonoSingleton<Heightmap>.Instance.GetHeightAt(position);
				if (heightAt == -1)
				{
					return;
				}
				Vec3Int vec3Int = new Vec3Int(position.x, heightAt, position.y);
				if (!VillageManager.ActiveVillage.Map.WaterManager.IsWaterAt(vec3Int))
				{
					return;
				}
				MapNode node = VillageManager.ActiveVillage.Map.GetNode(vec3Int);
				if (node != null && node.WaterLevel != WaterDepthLevel.Low && UnityEngine.Random.Range(0f, 1f) < 0.5f)
				{
					Vec3Int positionCloserToTheCoast = GetPositionCloserToTheCoast(node);
					position = new Vector2Int(positionCloserToTheCoast.x, positionCloserToTheCoast.z);
				}
			}
			PlaceProp(mapPropType, position, resourcePileAmount);
		}

		public Vec3Int GetPositionCloserToTheCoast(MapNode mapNode)
		{
			Vec3Int resultPos = mapNode.Position;
			WaterManager waterManager = VillageManager.ActiveVillage.Map.WaterManager;
			float closestCoastDistance = waterManager.GetCoastDistance(mapNode.Index);
			if (closestCoastDistance < 6f)
			{
				return resultPos;
			}
			float radiusMax;
			float radiusMin;
			if (UnityEngine.Random.Range(0f, 1f) < 0.8f)
			{
				radiusMax = closestCoastDistance - 1f;
				radiusMin = 2.5f;
			}
			else
			{
				radiusMax = closestCoastDistance - 2f;
				radiusMin = 3f;
			}
			WaterSimLogic waterSimLogic = mapNode.Map.WaterManager.WaterSimLogic;
			MapNodeUtils.ForEachConnectedInRadius(mapNode, radiusMin, radiusMax, delegate(MapNode node)
			{
				if (!waterSimLogic.IsWaterAt(node.Index))
				{
					return true;
				}
				if (node.DataType.HasFlag(GridDataType.FishMapResource))
				{
					return true;
				}
				bool skipNode = false;
				MapNodeUtils.ForEachNeighbour(node, delegate(MapNode neighbourNode)
				{
					if (neighbourNode.DataType.HasFlag(GridDataType.FishMapResource))
					{
						skipNode = true;
						return false;
					}
					return true;
				});
				if (skipNode)
				{
					return true;
				}
				float coastDistance = waterManager.GetCoastDistance(node.Index);
				if (coastDistance < 3f)
				{
					return true;
				}
				if (coastDistance < closestCoastDistance)
				{
					closestCoastDistance = coastDistance;
					resultPos = node.Position;
				}
				return true;
			});
			return resultPos;
		}

		public void PlaceProp(MapPropType mapPropType, Vector2Int position, int resourcePileAmount)
		{
			if (MonoSingleton<SlopeManager>.Instance.IsSlopeAt(position))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\ResourceSpawner.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't place prop on slope at ");
					messageBuilder.AppendFormatted(position);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				int heightAt = MonoSingleton<Heightmap>.Instance.GetHeightAt(position);
				if (heightAt != -1 && heightAt < villageMap.Size.y)
				{
					Vec3Int gridPos = new Vec3Int(position.x, heightAt, position.y);
					PlaceProp3d(mapPropType, gridPos, resourcePileAmount);
				}
			}
		}

		public void PlaceProp3d(MapPropType mapPropType, Vec3Int gridPos, int resourcePileAmount, string overridePrefab = null)
		{
			if (villageMap == null)
			{
				villageMap = VillageManager.ActiveVillage.Map;
			}
			int num = ((mapPropType.Phases == null || mapPropType.Phases.Count == 0) ? (-1) : mapPropType.Phases[UnityEngine.Random.Range(0, mapPropType.Phases.Count)]);
			MapPropResourceType resourceType = mapPropType.ResourceType;
			if (resourceType == MapPropResourceType.None)
			{
				Log.Error("propType.ResourceType is None", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\ResourceSpawner.cs");
				return;
			}
			string prefabId = null;
			if (resourceType == MapPropResourceType.Plant)
			{
				PlantMapResource byID = Repository<PlantMapResourceRepository, PlantMapResource>.Instance.GetByID(mapPropType.Model);
				if (byID == null || gridPos.y > MonoSingleton<World>.Instance.SizeY || gridPos.y <= 0)
				{
					return;
				}
				WaterDepthLevel waterLevelAsDepth = villageMap.WaterManager.GetWaterLevelAsDepth(gridPos);
				if (!byID.WaterDepthLevel.HasFlag(waterLevelAsDepth) || !MonoSingleton<FloraRegrowController>.Instance.CanPlantGrowOnVoxelType(byID, villageMap.GetNode(gridPos.x, gridPos.y - 1, gridPos.z).VoxelType))
				{
					return;
				}
				prefabId = byID.PrefabIDs.PickRandom();
			}
			if (resourceType == MapPropResourceType.Static)
			{
				DigMarkerResource byID2 = Repository<DigMarkerResourceRepository, DigMarkerResource>.Instance.GetByID(mapPropType.Model);
				if (byID2 == null)
				{
					return;
				}
				prefabId = byID2.PrefabIDs.PickRandom();
			}
			if (resourceType == MapPropResourceType.Fish)
			{
				FishMapResource byID3 = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(mapPropType.Model);
				if (byID3 == null)
				{
					return;
				}
				prefabId = byID3.PrefabIDs.PickRandom();
			}
			if (overridePrefab != null)
			{
				prefabId = overridePrefab;
			}
			int num2 = gridPos.y * World.MapBlockHeight;
			Vector3 vector = new Vector3(gridPos.x, num2, gridPos.z);
			switch (resourceType)
			{
			case MapPropResourceType.Plant:
				MonoSingleton<PlantResourceManager>.Instance.SpawnPlantMapResource(mapPropType.Model, vector, prefabId, num, domestic: false, randomPhaseHours: true);
				break;
			case MapPropResourceType.Static:
				SpawnStaticResource(mapPropType.Model, vector, prefabId, num);
				break;
			case MapPropResourceType.ResourcePile:
				PlaceResourcePile(mapPropType, vector, resourcePileAmount);
				break;
			case MapPropResourceType.Fish:
				if (FishResourceManager.CanSpawnFishAtPos(GridUtils.GetGridPosition(vector)))
				{
					MonoSingleton<FishResourceManager>.Instance.SpawnFishMapResource(mapPropType.Model, vector, prefabId);
				}
				break;
			}
		}

		private void PlaceResourcePile(MapPropType mapPropType, Vector3 position, int amount)
		{
			if (mapPropType == null)
			{
				Log.Error("MapPropType is null.", "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\ResourceSpawner.cs");
				return;
			}
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(mapPropType.Model);
			if (byID == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\ResourceSpawner.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Resource not found: ");
					messageBuilder.AppendFormatted(mapPropType.Model);
				}
				Log.Error(messageBuilder);
				return;
			}
			ResourcePileView view = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(byID, amount), position);
			if (!(view != null))
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (view != null && view.ResourcePileInstance != null)
				{
					view.ResourcePileInstance.IsForbidden = mapPropType.Forbid;
				}
			});
		}

		private void SpawnStaticResource(string resource, Vector3 position, string prefabId, int phase)
		{
			MonoSingleton<ResourceCommonController>.Instance.CreateResource(resource, position, prefabId);
		}
	}
}
