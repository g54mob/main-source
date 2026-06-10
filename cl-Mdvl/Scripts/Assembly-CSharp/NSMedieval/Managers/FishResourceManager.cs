using System;
using System.Collections.Generic;
using System.Linq;
using Controller;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Managers
{
	public class FishResourceManager : MapResourceManager<FishResourceManager, FishMapResourceInstance, FishMapResourceView>
	{
		private VillageMap villageMap;

		private System.Random random = new System.Random();

		private VillageMap VillageMap => villageMap ?? (villageMap = VillageManager.ActiveVillage.Map);

		public static bool CanSpawnFishAtPos(Vec3Int posToSpawn)
		{
			return (VillageManager.ActiveVillage.Map.GetNode(posToSpawn).WaterLevel & (WaterDepthLevel.Low | WaterDepthLevel.Medium | WaterDepthLevel.High)) != 0;
		}

		public void KillAllFish()
		{
			FishMapResourceInstance[] array = base.ResourcesInstanceViewDictionary.Keys.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Dispose();
			}
		}

		public FishMapResourceView GetView(FishMapResourceInstance instance)
		{
			return base.ResourcesInstanceViewDictionary.GetValueOrDefault(instance);
		}

		private void Start()
		{
			MonoSingleton<FishResourceController>.Instance.DestroyResourceEvent += base.OnDestroyResource;
			MonoSingleton<FishResourceController>.Instance.ReinstanceResourceEvent += base.OnReinstanceResource;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent += OnBuildingFinished;
		}

		private void OnMapLoaded(bool wasLoadedFromSave)
		{
			VillageManager.ActiveVillage.Map.WaterManager.WaterLevelChangedEvent += OnWaterLevelChanged;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<FishResourceController>.IsInstantiated())
			{
				MonoSingleton<FishResourceController>.Instance.DestroyResourceEvent -= base.OnDestroyResource;
				MonoSingleton<FishResourceController>.Instance.ReinstanceResourceEvent -= base.OnReinstanceResource;
			}
			if (MonoSingleton<VillageManager>.IsInstantiated())
			{
				VillageManager.ActiveVillage.Map.WaterManager.WaterLevelChangedEvent -= OnWaterLevelChanged;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.AfterConstructionCompletedEvent -= OnBuildingFinished;
			}
			base.OnDestroy();
		}

		public void SpawnFishMapResource(string modelId, Vector3 position, string prefabId)
		{
			FishMapResourceInstance resourceInstace = CreateInstance(modelId, prefabId, position);
			InstantiateResource(resourceInstace);
		}

		protected override FishMapResourceInstance CreateInstance(string modelId, string prefabId, Vector3 position)
		{
			FishMapResource byID = Repository<FishMapResourceRepository, FishMapResource>.Instance.GetByID(modelId);
			int daysUntilDeath = byID.Lifespan + random.Next(byID.LifespanRandomRange.Min, byID.LifespanRandomRange.Max);
			position = GetSurfaceNode(position.ToGridVec3Int()).WorldPosition;
			return new FishMapResourceInstance(byID, prefabId, position, daysUntilDeath);
		}

		protected override GridDataType GetGridTypeData()
		{
			return GridDataType.FishMapResource;
		}

		protected override void OnResourceDestroyed(FishMapResourceInstance resourceInstance)
		{
			VillageManager.ActiveVillage.Map.RemoveFromWorld(resourceInstance);
		}

		protected override void ResourceInstantiated(FishMapResourceInstance resourceInstance)
		{
		}

		protected override void ResourceInstantiated(FishMapResourceInstance resourceInstance, FishMapResourceView resourceView)
		{
			resourceView.OnInstantiated();
			AdjustPositionBasedOnWaterDepthLevel(resourceInstance, resourceView, resourceInstance.GetNode().WaterLevel);
		}

		private void OnWaterLevelChanged(HashSet<int> nodeIndexes, HashSet<int> nodeNeighborsIndices)
		{
			foreach (int nodeIndex in nodeIndexes)
			{
				OnWaterLevelChanged(nodeIndex);
			}
		}

		private void OnWaterLevelChanged(int nodeIndex)
		{
			if (nodeIndex < 0 || nodeIndex >= VillageMap.GridSpaceData.Length)
			{
				return;
			}
			MapNode mapNode = VillageMap.GridSpaceData[nodeIndex];
			if (mapNode != null)
			{
				Vec3Int position = mapNode.Position;
				if (base.PositionInstanceDictionary.ContainsKey(position) && base.PositionInstanceDictionary.TryGetValue(position, out var value) && base.ResourcesInstanceViewDictionary.TryGetValue(value, out var value2))
				{
					WaterDepthLevel waterLevel = mapNode.WaterLevel;
					AdjustPositionBasedOnWaterDepthLevel(value, value2, waterLevel);
				}
			}
		}

		private void AdjustPositionBasedOnWaterDepthLevel(FishMapResourceInstance fishMapResourceInstance, FishMapResourceView fishMapResourceView, WaterDepthLevel waterDepthLevel)
		{
			switch (waterDepthLevel)
			{
			case WaterDepthLevel.None:
				fishMapResourceInstance.WaterDepleted();
				break;
			case WaterDepthLevel.Low:
			{
				Vector3 position = fishMapResourceInstance.WorldPosition + Vector3.up * ((float)World.MapBlockHeight * 0.2f);
				fishMapResourceView.transform.position = position;
				break;
			}
			case WaterDepthLevel.Medium:
			{
				Vector3 position = fishMapResourceInstance.WorldPosition + Vector3.up * ((float)World.MapBlockHeight * 0.56f);
				fishMapResourceView.transform.position = position;
				break;
			}
			case WaterDepthLevel.High:
			{
				Vector3 position = fishMapResourceInstance.WorldPosition + Vector3.up * World.MapBlockHeight;
				fishMapResourceView.transform.position = position;
				break;
			}
			}
		}

		private MapNode GetSurfaceNode(Vec3Int gridPos)
		{
			MapNode result;
			MapNode nodeAbove = (result = VillageManager.ActiveVillage.Map.GetNode(gridPos)).GetNodeAbove();
			while (nodeAbove != null && nodeAbove.WaterDepthLevel != WaterDepthLevel.None)
			{
				result = nodeAbove;
				nodeAbove = nodeAbove.GetNodeAbove();
			}
			return result;
		}

		private void OnBuildingFinished(BaseBuildingInstance building)
		{
			if (building.Blueprint.PlaceableBellowOthers || building.BuildingType == BuildingType.Rug)
			{
				return;
			}
			foreach (Vec3Int position in building.Positions)
			{
				if (base.PositionInstanceDictionary.TryGetValue(position, out var value))
				{
					HandleTeleportation(value);
				}
			}
		}

		private void HandleTeleportation(FishMapResourceInstance fishToTeleport)
		{
			if (fishToTeleport == null || fishToTeleport.HasDisposed)
			{
				return;
			}
			MapNode startingNode = fishToTeleport.GetNode();
			Vec3Int fishSpawnPosition = Vec3Int.zero;
			MapNodeUtils.ForEachConnectedInRadius(startingNode, 0f, 10f, delegate(MapNode node)
			{
				if (startingNode.Position.y == node.Position.y && CanSpawnFishAtPos(startingNode.Position) && node.DataType == GridDataType.None && !base.PositionInstanceDictionary.ContainsKey(node.Position))
				{
					fishSpawnPosition = node.Position;
					return false;
				}
				return true;
			});
			if (fishSpawnPosition == Vec3Int.zero)
			{
				fishToTeleport.Dispose();
				return;
			}
			FishMapResource blueprint = fishToTeleport.Blueprint;
			FishMapResourceInstance fishMapResourceInstance = CreateInstance(blueprint.GetID(), blueprint.PrefabIDs.PickRandom(), fishSpawnPosition.ToVector3World());
			fishMapResourceInstance.SetCloneData(fishToTeleport);
			InstantiateResource(fishMapResourceInstance);
			fishToTeleport.Dispose();
		}
	}
}
