using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public abstract class AutomaticMeshVariationManagerBase
	{
		protected static readonly NInfo[] NeighbourSides = new NInfo[4]
		{
			NInfo.North,
			NInfo.East,
			NInfo.South,
			NInfo.West
		};

		protected static readonly Dictionary<NInfo, Vec3Int> FlagToVec3Int = new Dictionary<NInfo, Vec3Int>
		{
			{
				NInfo.North,
				Vec3Int.forward
			},
			{
				NInfo.East,
				Vec3Int.right
			},
			{
				NInfo.West,
				Vec3Int.left
			},
			{
				NInfo.South,
				Vec3Int.back
			}
		};

		protected BuildingsManagerMain buildingsManagerMain;

		private VillageMap map;

		protected abstract BuildingType BuildingType { get; }

		protected AutomaticMeshVariationManagerBase(VillageMap map)
		{
			this.map = map;
			buildingsManagerMain = this.map.BuildingsManagerMain;
			InitializeRules();
		}

		protected abstract void InitializeRules();

		protected abstract NInfo GetBuildingNeighboursFlags(Vec3Int centerPos, BaseBuildingInstance baseBuildingInstance, BuildingsManagerMain buildingsManager);

		protected abstract MeshVariationRules GetMeshVariationRules(BaseBuildingInstance building, NInfo neighboursInfo);

		public virtual void Dispose()
		{
			map = null;
			buildingsManagerMain = null;
		}

		public virtual void Run(IEnumerable<BaseBuildingInstance> buildings)
		{
			foreach (BaseBuildingInstance building in buildings)
			{
				RefreshMeshVariations(building);
			}
		}

		public void RefreshNeighbors(Vec3Int position)
		{
			using PooledDictionary<NInfo, BaseBuildingInstance> pooledDictionary = GetNeighboursMap(position, BuildingType, buildingsManagerMain);
			if (pooledDictionary.Count != 0)
			{
				Run(pooledDictionary.Values);
			}
		}

		public void RefreshMeshVariations(BaseBuildingInstance building)
		{
			TryToRefreshMeshVariation(building);
			NInfo[] neighbourSides = NeighbourSides;
			foreach (NInfo key in neighbourSides)
			{
				if (FlagToVec3Int.TryGetValue(key, out var value))
				{
					BaseBuildingInstance building2 = buildingsManagerMain.GetBuilding(building.GridDataPosition + value, (BaseBuildingInstance x) => x.BuildingType == BuildingType && x != building);
					if (building2 != null)
					{
						TryToRefreshMeshVariation(building2);
					}
				}
			}
		}

		protected void TryToRefreshMeshVariation(BaseBuildingInstance buildingInstance)
		{
			NInfo buildingNeighboursFlags = GetBuildingNeighboursFlags(buildingInstance.GridDataPosition, buildingInstance, buildingsManagerMain);
			MeshVariationRules meshVariationRules = GetMeshVariationRules(buildingInstance, buildingNeighboursFlags);
			if (!string.IsNullOrEmpty(meshVariationRules.VariationId))
			{
				LoadAndRotateBuildingMeshVariation(buildingInstance, meshVariationRules);
			}
		}

		[MustDisposeResource]
		protected PooledDictionary<NInfo, BaseBuildingInstance> GetNeighboursMap(Vec3Int centerPos, BuildingType buildingType, BuildingsManagerMain buildingsManager)
		{
			PooledDictionary<NInfo, BaseBuildingInstance> neighboursMap = DictionaryPool<NInfo, BaseBuildingInstance>.GetJanitor();
			AddToDictionary(NInfo.West, centerPos + Vec3Int.left);
			AddToDictionary(NInfo.North, centerPos + Vec3Int.forward);
			AddToDictionary(NInfo.East, centerPos + Vec3Int.right);
			AddToDictionary(NInfo.South, centerPos + Vec3Int.back);
			return neighboursMap;
			void AddToDictionary(NInfo location, Vec3Int position)
			{
				BaseBuildingInstance buildingInstance = buildingsManager.GetBuildingInstance(position, buildingType);
				if (buildingInstance != null)
				{
					neighboursMap.Add(location, buildingInstance);
				}
			}
		}

		protected virtual bool LoadAndRotateBuildingMeshVariation(BaseBuildingInstance targetBuilding, MeshVariationRules rules)
		{
			if (!targetBuilding.AutomaticMeshVariationLoading)
			{
				return false;
			}
			float num = rules.Angle;
			string variationId = rules.VariationId;
			bool result = false;
			if (num >= 0f)
			{
				while (!Mathf.Approximately(targetBuilding.AdjustedAngle, num))
				{
					targetBuilding.AddToMeshRotation(90f, updateView: false);
					result = true;
				}
			}
			targetBuilding.ForceMeshVariationRotatedUpdateView();
			if (targetBuilding.CurrentMeshVariation != variationId)
			{
				result = true;
			}
			MeshVariation variation = targetBuilding.Blueprint.VariationLists[0].Variations.FirstOrDefault((MeshVariation x) => x.Name == variationId);
			targetBuilding.ApplyMeshVariation(variation);
			return result;
		}
	}
}
