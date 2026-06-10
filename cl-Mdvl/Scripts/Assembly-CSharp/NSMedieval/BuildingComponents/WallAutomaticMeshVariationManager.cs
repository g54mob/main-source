using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Terrain;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class WallAutomaticMeshVariationManager : AutomaticMeshVariationManagerBase
	{
		private const string WallDefaultVariation = "default";

		private const string WallSingleVariation = "round";

		private const string WallCornerVariation = "corner_02";

		private const string WallEdgeVariation = "edge_02";

		private const string WallCornerBlockVariation = "corner_01";

		private const string WallEdgeBlockVariation = "edge_01";

		private readonly Dictionary<NInfo, MeshVariationRules> woodWallRules = new Dictionary<NInfo, MeshVariationRules>();

		private readonly Dictionary<NInfo, MeshVariationRules> limestoneAndClayWallRules = new Dictionary<NInfo, MeshVariationRules>();

		private readonly Dictionary<NInfo, MeshVariationRules> blockAndBrickWallRules = new Dictionary<NInfo, MeshVariationRules>();

		private readonly Dictionary<string, Dictionary<NInfo, MeshVariationRules>> wallRulesPerWallType = new Dictionary<string, Dictionary<NInfo, MeshVariationRules>>();

		protected override BuildingType BuildingType => BuildingType.Wall;

		public WallAutomaticMeshVariationManager(VillageMap map)
			: base(map)
		{
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
		}

		protected override MeshVariationRules GetMeshVariationRules(BaseBuildingInstance building, NInfo neighboursInfo)
		{
			if (!wallRulesPerWallType.TryGetValue(building.BlueprintId, out var value))
			{
				return default(MeshVariationRules);
			}
			if (value.TryGetValue(neighboursInfo, out var value2))
			{
				return value2;
			}
			return default(MeshVariationRules);
		}

		public override void Dispose()
		{
			woodWallRules.Clear();
			limestoneAndClayWallRules.Clear();
			blockAndBrickWallRules.Clear();
			if (MonoSingleton<GroundController>.IsInstantiated())
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
			}
			base.Dispose();
		}

		protected override void InitializeRules()
		{
			wallRulesPerWallType.Add("wood_wall_element", woodWallRules);
			wallRulesPerWallType.Add("clay_wall_element", limestoneAndClayWallRules);
			wallRulesPerWallType.Add("limestone_wall_element", limestoneAndClayWallRules);
			wallRulesPerWallType.Add("limestone_block_wall_element", blockAndBrickWallRules);
			wallRulesPerWallType.Add("clay_brick_wall_element", blockAndBrickWallRules);
			InitializeWoodWallRules();
			InitializeLimestoneAndClayWallRules();
			InitializeBlockAndBrickWallRules();
		}

		protected override NInfo GetBuildingNeighboursFlags(Vec3Int centerPos, BaseBuildingInstance baseBuildingInstance, BuildingsManagerMain buildingsManager)
		{
			NInfo result = NInfo.None;
			GroundManager groundManager = MonoSingleton<GroundManager>.Instance;
			AddToFlag(NInfo.West, centerPos + Vec3Int.left);
			AddToFlag(NInfo.North, centerPos + Vec3Int.forward);
			AddToFlag(NInfo.East, centerPos + Vec3Int.right);
			AddToFlag(NInfo.South, centerPos + Vec3Int.back);
			return result;
			void AddToFlag(NInfo location, Vec3Int position)
			{
				if (buildingsManager.GetBuildingInstance(position, BuildingType) != null)
				{
					result |= location;
				}
				else if (buildingsManager.GetBuildingInstance(position, BuildingType.Voxel) != null)
				{
					result |= location;
				}
				else if (groundManager.GroundExists(position))
				{
					result |= location;
				}
			}
		}

		private void OnGroundDestroyed(List<Vec3Int> destroyedGround)
		{
			foreach (Vec3Int item in destroyedGround)
			{
				RefreshNeighbors(item);
			}
		}

		private void InitializeWoodWallRules()
		{
			woodWallRules.Add(NInfo.North | NInfo.South, new MeshVariationRules(90, "default"));
			woodWallRules.Add(NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
		}

		private void InitializeLimestoneAndClayWallRules()
		{
			limestoneAndClayWallRules.Add(NInfo.None, new MeshVariationRules(0, "round"));
			limestoneAndClayWallRules.Add(NInfo.North, new MeshVariationRules(270, "edge_02"));
			limestoneAndClayWallRules.Add(NInfo.East, new MeshVariationRules(0, "edge_02"));
			limestoneAndClayWallRules.Add(NInfo.South, new MeshVariationRules(90, "edge_02"));
			limestoneAndClayWallRules.Add(NInfo.West, new MeshVariationRules(180, "edge_02"));
			limestoneAndClayWallRules.Add(NInfo.North | NInfo.South, new MeshVariationRules(0, "default"));
			limestoneAndClayWallRules.Add(NInfo.West | NInfo.East, new MeshVariationRules(90, "default"));
			limestoneAndClayWallRules.Add(NInfo.North | NInfo.East, new MeshVariationRules(270, "corner_02"));
			limestoneAndClayWallRules.Add(NInfo.South | NInfo.East, new MeshVariationRules(0, "corner_02"));
			limestoneAndClayWallRules.Add(NInfo.South | NInfo.West, new MeshVariationRules(90, "corner_02"));
			limestoneAndClayWallRules.Add(NInfo.North | NInfo.West, new MeshVariationRules(180, "corner_02"));
			limestoneAndClayWallRules.Add(NInfo.North | NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
			limestoneAndClayWallRules.Add(NInfo.North | NInfo.South | NInfo.East, new MeshVariationRules(0, "default"));
			limestoneAndClayWallRules.Add(NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
			limestoneAndClayWallRules.Add(NInfo.North | NInfo.South | NInfo.West, new MeshVariationRules(0, "default"));
			limestoneAndClayWallRules.Add(NInfo.North | NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
		}

		private void InitializeBlockAndBrickWallRules()
		{
			blockAndBrickWallRules.Add(NInfo.None, new MeshVariationRules(0, "round"));
			blockAndBrickWallRules.Add(NInfo.North, new MeshVariationRules(270, "edge_01"));
			blockAndBrickWallRules.Add(NInfo.East, new MeshVariationRules(0, "edge_01"));
			blockAndBrickWallRules.Add(NInfo.South, new MeshVariationRules(90, "edge_01"));
			blockAndBrickWallRules.Add(NInfo.West, new MeshVariationRules(180, "edge_01"));
			blockAndBrickWallRules.Add(NInfo.North | NInfo.South, new MeshVariationRules(0, "default"));
			blockAndBrickWallRules.Add(NInfo.West | NInfo.East, new MeshVariationRules(90, "default"));
			blockAndBrickWallRules.Add(NInfo.North | NInfo.East, new MeshVariationRules(270, "corner_01"));
			blockAndBrickWallRules.Add(NInfo.South | NInfo.East, new MeshVariationRules(0, "corner_01"));
			blockAndBrickWallRules.Add(NInfo.South | NInfo.West, new MeshVariationRules(90, "corner_01"));
			blockAndBrickWallRules.Add(NInfo.North | NInfo.West, new MeshVariationRules(180, "corner_01"));
			blockAndBrickWallRules.Add(NInfo.North | NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
			blockAndBrickWallRules.Add(NInfo.North | NInfo.South | NInfo.East, new MeshVariationRules(0, "default"));
			blockAndBrickWallRules.Add(NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
			blockAndBrickWallRules.Add(NInfo.North | NInfo.South | NInfo.West, new MeshVariationRules(0, "default"));
			blockAndBrickWallRules.Add(NInfo.North | NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
		}
	}
}
