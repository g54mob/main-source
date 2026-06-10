using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI.Utilities;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Water;
using Raid.Config;

namespace NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider
{
	public class SiegeTraversalProvider : PathTraversalProvider
	{
		private const uint UNWALKABLE_PENALTY = 999999u;

		private SiegePathfinderPenaltyModifiers penaltyModifiers;

		public static string LogPath => "Siege";

		public SiegeTraversalProvider(PathfindingPenalty penalty, SiegePathfinderPenaltyModifiers penaltyModifiers)
			: base(penalty)
		{
			this.penaltyModifiers = penaltyModifiers;
		}

		public override bool CanStandOnNode(MapNode node)
		{
			return true;
		}

		public override uint GetTraversalCost(MapNode start, MapNode destination)
		{
			uint num = 0u;
			if (destination.HasFirePresence())
			{
				return 999999u;
			}
			num += CalculateWaterPenalty(start, destination);
			if (IsSiegeWalkable(start, destination))
			{
				num += 1000;
				if (base.PenaltyModel != null)
				{
					num += (uint)((float)(int)destination.GetPenalty(base.PenaltyModel) * 0.1f);
				}
				return num;
			}
			if (IsDiagonal(start, destination))
			{
				return 999999u;
			}
			if (start.Position.y != destination.Position.y && !IsBuildLadder(start, destination))
			{
				return 999999u;
			}
			if (IsDoorBreak(start, destination))
			{
				uint num2 = (uint)destination.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.AnyDoor, destination.Position, (BaseBuildingInstance x) => x.ConstructionPhase != ConstructionPhase.Blueprint).Stats.GetStat(StatType.Health).Current;
				num += num2 * SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.BreakDoorPenalty.Multiply(penaltyModifiers.BreakDoorPenaltyModifier);
			}
			else if (IsWallBreak(start, destination))
			{
				uint num3 = (uint)destination.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.Wall | BuildingType.Roof | BuildingType.Window, destination.Position, (BaseBuildingInstance x) => x.ConstructionPhase != ConstructionPhase.Blueprint).Stats.GetStat(StatType.Health).Current;
				num += num3 * SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.BreakWallPenalty.Multiply(penaltyModifiers.BreakWallPenaltyModifier);
			}
			else if (IsAirGap(start, destination))
			{
				num += SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.BuildFloorPenalty.Multiply(penaltyModifiers.BuildFloorPenaltyModifier);
			}
			else if (IsWaterStepUpAttackPlank(start, destination))
			{
				num += SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.BuildFloorAirBridgePenalty.Multiply(penaltyModifiers.BuildFloorPenaltyModifier);
			}
			else if (IsAirBridge(start, destination))
			{
				num += SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.BuildFloorAirBridgePenalty.Multiply(penaltyModifiers.BuildFloorAirBridgePenaltyModifier);
			}
			else if (IsWallMine(start, destination))
			{
				num += SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.MineWallPenalty.Multiply(penaltyModifiers.MineWallPenaltyModifier);
			}
			else if (IsBuildLadder(start, destination))
			{
				num += SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.BuildLadderPenalty.Multiply(penaltyModifiers.BuildLadderPenaltyModifier);
			}
			else if (!start.IsWalkable && start.GetNodeBelow() != null && start.GetNodeBelow().IsVoxelAir() && destination.IsWalkable)
			{
				num += 2000;
			}
			else if (start.GetNodeAbove() == null || start.GetNodeAbove().IsVoxelAir() || !destination.IsVoxelAir() || !IsSameHeight(start, destination) || IsDiagonal(start, destination))
			{
				num = ((!start.IsVoxelAir() && destination.IsWalkable) ? (num + 2000) : (((!start.IsVoxelWall() && !start.DataType.HasFlag(GridDataType.Roof)) || !IsSameHeight(start, destination) || IsDiagonal(start, destination)) ? (num + 999999) : (num + 2000)));
			}
			else
			{
				num += 2000;
				if (destination.IsLayerRamp() && !MapRampLogic.CanEnterRampFromNode(start, destination))
				{
					num += 999999;
				}
			}
			return num;
		}

		private uint CalculateWaterPenalty(MapNode start, MapNode destination)
		{
			if (!start.IsWater && !destination.IsWater)
			{
				return 0u;
			}
			WaterManager waterManager = destination.Map.WaterManager;
			if (!waterManager.CanWalkInside(start) && destination.Position.y == start.Position.y && !destination.IsWater)
			{
				return 999999u;
			}
			if (destination.IsWater && waterManager.CanDrown(destination))
			{
				return 999999u;
			}
			return SingletonModel<SiegePathfinderSettings, SiegePathfinderSettingsData>.I.WaterPenalty.Multiply(penaltyModifiers.WaterPenaltyModifier);
		}

		public static bool IsFloorBreak(MapNode start, MapNode destination)
		{
			if (start.Position.y == destination.Position.y)
			{
				return false;
			}
			if (start.IsVoxelDoor() || destination.IsVoxelDoor() || start.IsVoxelWall() || destination.IsVoxelDoor())
			{
				return false;
			}
			if (start.IsVoxelFloor())
			{
				return destination.IsVoxelFloor();
			}
			return false;
		}

		public static bool IsBuildLadder(MapNode start, MapNode destination)
		{
			if (start.Position.x != destination.Position.x || start.Position.z != destination.Position.z)
			{
				return false;
			}
			if (start.IsWater && start.WaterLevel.HasFlag(WaterDepthLevel.High))
			{
				return false;
			}
			if (start.Tag.HasFlag(MapNodeTags.Ladder) && destination.Tag.HasFlag(MapNodeTags.Ladder))
			{
				return false;
			}
			if (start.IsLayerRamp() && destination.IsWalkable && start.AnyConnection((MapNode node) => node == destination))
			{
				return false;
			}
			if ((start.IsLayerRamp() && !start.Tag.HasFlag(MapNodeTags.Ladder)) || (destination.IsLayerRamp() && !destination.Tag.HasFlag(MapNodeTags.Ladder)))
			{
				return false;
			}
			if (!start.IsVoxelAir())
			{
				return false;
			}
			if (!destination.IsVoxelAir())
			{
				return false;
			}
			if (start.Position.y > destination.Position.y)
			{
				if (!start.Map.BuildingsManagerMain.CanPlaceEnemyBuilding(Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID("stick_ladder"), destination.Position, 0))
				{
					return false;
				}
				if (start.IsVoxelFloor() || !start.IsVoxelAir())
				{
					return false;
				}
			}
			if (start.Position.y < destination.Position.y)
			{
				if (!start.Map.BuildingsManagerMain.CanPlaceEnemyBuilding(Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID("stick_ladder"), start.Position, 0))
				{
					return false;
				}
				if (destination.IsVoxelFloor() || !destination.IsVoxelAir())
				{
					return false;
				}
			}
			if (start.IsLayerRamp())
			{
				if (start.Tag.HasFlag(MapNodeTags.Ladder) && destination.Position.y != start.Position.y)
				{
					return true;
				}
				return false;
			}
			if (destination.IsLayerRamp())
			{
				return false;
			}
			return start.Position.y != destination.Position.y;
		}

		public static bool IsAirGap(MapNode start, MapNode destination)
		{
			if (start.Position.y != destination.Position.y)
			{
				return false;
			}
			if (start.IsSlopeOrStairs() || destination.IsSlopeOrStairs())
			{
				return false;
			}
			if (!start.Map.BuildingsManagerMain.CanPlaceEnemyBuilding(Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID("wicker_mesh_floor"), destination.Position, 0))
			{
				return false;
			}
			if (!start.IsWalkable || destination.IsWalkable || !destination.IsVoxelAir() || destination.IsVoxelWall() || destination.DataType.HasFlag(GridDataType.Roof))
			{
				if (!start.IsWalkable && start.IsVoxelAir() && !start.IsVoxelWall() && !start.DataType.HasFlag(GridDataType.Roof))
				{
					return destination.IsVoxelWall();
				}
				return false;
			}
			return true;
		}

		public static bool IsAirBridge(MapNode start, MapNode destination)
		{
			if (start.Position.y != destination.Position.y)
			{
				return false;
			}
			if (!start.Map.BuildingsManagerMain.CanPlaceEnemyBuilding(Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID("wicker_mesh_floor"), destination.Position, 0))
			{
				return false;
			}
			if (!start.IsWalkable && start.IsVoxelAir() && !start.IsVoxelWall() && !start.DataType.HasFlag(GridDataType.Roof) && !destination.IsWalkable && destination.IsVoxelAir() && !destination.IsVoxelWall())
			{
				return !destination.DataType.HasFlag(GridDataType.Roof);
			}
			return false;
		}

		public static bool IsWaterStepUpAttackPlank(MapNode start, MapNode destination)
		{
			if (!start.IsVoxelAir() || start.WaterLevel != WaterDepthLevel.High || start.Position.y != destination.Position.y - 1)
			{
				return false;
			}
			if ((destination.BuildingType & (CommanderAIFilters.BuildingTypesToSpreadAttack | BuildingType.AnyDoor)) == 0)
			{
				return false;
			}
			if (!start.Map.BuildingsManagerMain.CanPlaceEnemyBuilding(Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByID("wicker_mesh_floor"), start.Position + Vec3Int.up, 0))
			{
				return false;
			}
			if (!start.DataType.HasFlag(GridDataType.Roof))
			{
				return !destination.DataType.HasFlag(GridDataType.Roof);
			}
			return false;
		}

		public static bool IsWallBreak(MapNode start, MapNode destination)
		{
			if (start.Position.y != destination.Position.y)
			{
				return false;
			}
			if (destination.IsWalkable)
			{
				return false;
			}
			if (!destination.BuildingType.HasFlag(BuildingType.Roof) && !destination.BuildingType.HasFlag(BuildingType.Wall) && !destination.BuildingType.HasFlag(BuildingType.Window))
			{
				return false;
			}
			return destination.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.Wall | BuildingType.Roof | BuildingType.Window, destination.Position, (BaseBuildingInstance x) => x.ConstructionPhase != ConstructionPhase.Blueprint) != null;
		}

		public static bool IsDoorBreak(MapNode start, MapNode destination)
		{
			if (start.Position.y != destination.Position.y)
			{
				return false;
			}
			if (!destination.Tag.HasFlag(MapNodeTags.DoorWorkerWalkable) && !destination.Tag.HasFlag(MapNodeTags.DoorCompletelyLocked) && !destination.Tag.HasFlag(MapNodeTags.BarnDoor))
			{
				return false;
			}
			return true;
		}

		public static bool IsWallMine(MapNode start, MapNode destination)
		{
			if (start.DataType.HasFlag(GridDataType.Slope))
			{
				return false;
			}
			if (start.Position.y != destination.Position.y)
			{
				return false;
			}
			return !destination.IsVoxelAir();
		}

		public static bool IsSiegeWalkable(MapNode start, MapNode destination)
		{
			if (start.Position == destination.Position)
			{
				return true;
			}
			if (start.IsLayerRamp() && destination.IsLayerRamp())
			{
				return true;
			}
			if (start.ConnectionsSafeSearch((MapNode node) => node == destination) == null || !start.IsWalkable || !destination.IsWalkable)
			{
				return false;
			}
			if (IsDoorBreak(start, destination) || IsWallBreak(start, destination) || IsWallMine(start, destination) || IsAirGap(start, destination) || IsAirBridge(start, destination) || IsBuildLadder(destination, start) || IsWaterStepUpAttackPlank(start, destination))
			{
				return false;
			}
			return true;
		}

		private bool IsSameHeight(MapNode start, MapNode destination)
		{
			return start.Position.y == destination.Position.y;
		}

		private bool IsDiagonal(MapNode start, MapNode destination)
		{
			if (start.Position.x != destination.Position.x)
			{
				return start.Position.z != destination.Position.z;
			}
			return false;
		}
	}
}
