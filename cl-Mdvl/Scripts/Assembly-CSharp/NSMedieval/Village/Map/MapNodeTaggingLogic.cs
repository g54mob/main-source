using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Water;

namespace NSMedieval.Village.Map
{
	public static class MapNodeTaggingLogic
	{
		private static VillageMap Map => VillageManager.ActiveVillage.Map;

		internal static MapNodeTags CalculateNodeTagsRefactored(MapNode node)
		{
			MapNodeTags mapNodeTags = MapNodeTags.None;
			if (node.ReachedMaxFire)
			{
				mapNodeTags |= MapNodeTags.MaxFlame;
			}
			if (node.IsFire)
			{
				mapNodeTags |= MapNodeTags.Fire;
			}
			if ((node.DataType & GridDataType.Drawbridge) != GridDataType.None)
			{
				mapNodeTags |= MapNodeTags.DrawbridgePlatform;
			}
			if (node.IsVoxelAir())
			{
				WaterDepthLevel waterLevelAsDepth = node.Map.WaterManager.GetWaterLevelAsDepth(node.Index);
				if ((waterLevelAsDepth & WaterDepthLevel.Low) != 0)
				{
					mapNodeTags |= MapNodeTags.WaterLevelLow;
				}
				else if ((waterLevelAsDepth & WaterDepthLevel.Medium) != 0)
				{
					mapNodeTags |= MapNodeTags.WaterLevelMedium;
				}
				else if ((waterLevelAsDepth & WaterDepthLevel.High) != 0)
				{
					mapNodeTags |= MapNodeTags.WaterLevelHigh;
				}
				if (node.Map.WaterManager.GetWaterDepth(node.Index) > 1f && (node.Map.WaterManager.GetWaterDepthLevel(node.Index) & WaterDepthLevel.High) != 0)
				{
					mapNodeTags |= MapNodeTags.WaterDepthHigh;
				}
			}
			MapNode nodeBelow = node.GetNodeBelow();
			if (nodeBelow != null && nodeBelow.CheckBuildingType(BuildingType.Ladder))
			{
				mapNodeTags |= MapNodeTags.Ladder;
			}
			if (node.HasWorldObjects())
			{
				foreach (WorldObject worldObject in node.WorldObjects)
				{
					BaseBuildingInstance baseBuildingInstance = (((worldObject.GridDataType & GridDataType.BuildingFinished) != GridDataType.None) ? ((BaseBuildingInstance)worldObject) : null);
					if (baseBuildingInstance != null)
					{
						if (baseBuildingInstance.BuildingType == BuildingType.Door)
						{
							if (baseBuildingInstance.LockState == LockState.Locked)
							{
								mapNodeTags |= MapNodeTags.DoorCompletelyLocked;
							}
							else if (baseBuildingInstance.LockState == LockState.Unlocked)
							{
								mapNodeTags = ((!baseBuildingInstance.OwnedByPlayer()) ? (mapNodeTags | MapNodeTags.EnemyDoorClosed) : (mapNodeTags | MapNodeTags.DoorWorkerWalkable));
							}
							else if (baseBuildingInstance.LockState == LockState.AlwaysOpen || baseBuildingInstance.LockState == LockState.ForcedOpen)
							{
								mapNodeTags |= MapNodeTags.DoorAlwaysOpen;
							}
							if (baseBuildingInstance.Blueprint.WaterFlowThroughFloor)
							{
								mapNodeTags |= MapNodeTags.FlowThrough;
							}
						}
						if (baseBuildingInstance.Blueprint.IsVerticalFireBlocker)
						{
							mapNodeTags |= MapNodeTags.VerticalFireBlocker;
						}
						if ((baseBuildingInstance.BuildingType & BuildingType.Ladder) != 0)
						{
							mapNodeTags |= MapNodeTags.Ladder;
						}
						else if ((baseBuildingInstance.BuildingType & BuildingType.Wall) != 0)
						{
							mapNodeTags |= MapNodeTags.Wall;
						}
						else if (baseBuildingInstance.BuildingType == BuildingType.Floor)
						{
							mapNodeTags |= MapNodeTags.Floor;
							if (baseBuildingInstance.Blueprint.PassthroughFloor)
							{
								mapNodeTags |= MapNodeTags.FloorPassthrough;
							}
							if (baseBuildingInstance.Blueprint.WaterFlowThroughFloor)
							{
								mapNodeTags |= MapNodeTags.FlowThrough;
							}
						}
						if ((baseBuildingInstance.BuildingType & BuildingType.Window) != 0)
						{
							mapNodeTags |= MapNodeTags.Wall;
							if (baseBuildingInstance.LockState == LockState.AlwaysOpen)
							{
								mapNodeTags |= MapNodeTags.OpenWindow;
							}
						}
					}
					BaseBuildingInstance baseBuildingInstance2 = (((worldObject.GridDataType & GridDataType.FurnitureGate) != GridDataType.None) ? ((BaseBuildingInstance)worldObject) : null);
					if (baseBuildingInstance2 != null && baseBuildingInstance2.Blueprint.BuildingType == BuildingType.FenceGate && baseBuildingInstance2.ConstructionPhase == ConstructionPhase.Finished && (node.DataType & GridDataType.Drawbridge) == 0)
					{
						if (baseBuildingInstance2.LockState == LockState.Locked)
						{
							mapNodeTags |= MapNodeTags.DoorCompletelyLocked;
						}
						else if (baseBuildingInstance2.LockState == LockState.Unlocked)
						{
							mapNodeTags |= MapNodeTags.ClosedFenceGate;
						}
						else if (baseBuildingInstance2.LockState == LockState.AlwaysOpen)
						{
							mapNodeTags |= MapNodeTags.DoorAlwaysOpen;
						}
						if (baseBuildingInstance2.Blueprint.WaterFlowThroughFloor)
						{
							mapNodeTags |= MapNodeTags.FlowThrough;
						}
					}
					if ((worldObject.GridDataType & GridDataType.BeamFinished) != GridDataType.None)
					{
						mapNodeTags |= MapNodeTags.Beam;
					}
					if (baseBuildingInstance != null && baseBuildingInstance.Blueprint.BuildingType == BuildingType.BarnDoor)
					{
						if (baseBuildingInstance.LockState == LockState.AlwaysOpen)
						{
							mapNodeTags |= MapNodeTags.DoorAlwaysOpen;
						}
						mapNodeTags |= MapNodeTags.BarnDoor;
					}
					if (worldObject is BaseBuildingInstance { ConstructionPhase: var constructionPhase } baseBuildingInstance3 && (constructionPhase == ConstructionPhase.Finished || constructionPhase == ConstructionPhase.Foundation))
					{
						if (baseBuildingInstance3.BuildingType == BuildingType.PenMarker)
						{
							mapNodeTags |= MapNodeTags.PenMarker;
						}
						if (baseBuildingInstance3.BuildingType == BuildingType.Fence)
						{
							mapNodeTags |= MapNodeTags.Fence;
						}
					}
					if (worldObject is BaseBuildingInstance baseBuildingInstance4 && baseBuildingInstance4.Blueprint != null && baseBuildingInstance4.Blueprint.IdleTargetForbidden)
					{
						mapNodeTags |= MapNodeTags.IdleTargetForbidden;
					}
					if ((worldObject.GridDataType & GridDataType.PlantMapResource) != GridDataType.None && worldObject is PlantMapResourceInstance plantMapResourceInstance && plantMapResourceInstance.Blueprint != null && plantMapResourceInstance.Blueprint.IdleTargetForbidden)
					{
						mapNodeTags |= MapNodeTags.IdleTargetForbidden;
					}
				}
			}
			if (node.CreaturesCount > 0 && (node.Tag & MapNodeTags.Ladder) == 0)
			{
				foreach (CreatureBase item in node.Map.CreaturesOnNodes[node.Index])
				{
					if (!item.HasDisposed && !item.HasFainted && item is HumanoidInstance humanoidInstance && !CombatAiUtils.IsAgentDefeated(humanoidInstance))
					{
						if (humanoidInstance.WorkerBehaviour != null)
						{
							mapNodeTags |= MapNodeTags.Worker;
						}
						if (humanoidInstance.IsEnemy())
						{
							mapNodeTags |= MapNodeTags.Enemy;
						}
					}
				}
			}
			return mapNodeTags;
		}

		internal static MapNodeTags CalculateNodeTags(MapNode node)
		{
			return CalculateNodeTagsRefactored(node);
		}
	}
}
