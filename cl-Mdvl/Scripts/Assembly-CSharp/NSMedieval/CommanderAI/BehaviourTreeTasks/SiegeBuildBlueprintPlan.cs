using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Siege")]
	[Description("Takes current and previous path nodes, places blueprints that could be required for traversal. Returns success if target is set to blueprint.")]
	public class SiegeBuildBlueprintPlan : CommanderAIBTActionBase
	{
		public BBParameter<MapNode> currentNode;

		public BBParameter<MapNode> previousNode;

		public BBParameter<List<MapNode>> siegePath;

		public BBParameter<BaseBuildingInstance> target;

		private BaseBuildingInstance buildingBlueprint;

		private float timeStart;

		protected override void OnStart()
		{
			buildingBlueprint = null;
			MapNode mapNode = null;
			if (siegePath.value.Count >= 2)
			{
				List<MapNode> value = siegePath.value;
				mapNode = value[value.Count - 2];
			}
			if (currentNode.isNoneOrNull || previousNode.isNoneOrNull)
			{
				EndAction(success: false);
				return;
			}
			MapNode value2 = previousNode.value;
			MapNode value3 = currentNode.value;
			BaseBuildingInstance baseBuildingInstance = null;
			bool flag = false;
			if (SiegeTraversalProvider.IsAirGap(value2, value3) && SiegeTraversalProvider.IsBuildLadder(value3, mapNode))
			{
				BuildingsManagerMain buildingsManagerMain = mapNode.Map.BuildingsManagerMain;
				if (buildingsManagerMain.BuildingExists(mapNode.Position) || buildingsManagerMain.BuildingExists(value3.Position))
				{
					Log.Info($"There already is a blueprint at {mapNode.Position} or {value3.Position}!", SiegeTraversalProvider.LogPath);
					EndAction(success: true);
					return;
				}
				Log.Info("Planting ladder blueprint!", SiegeTraversalProvider.LogPath);
				if (mapNode.Position.y < value3.Position.y)
				{
					int yAngle = FindLadderAngle(mapNode);
					baseBuildingInstance = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding("stick_ladder", mapNode.Position, yAngle);
					flag = true;
				}
			}
			else if (SiegeTraversalProvider.IsBuildLadder(value2, value3))
			{
				int num = 0;
				if (value3.Position.y < value2.Position.y && !value3.Map.BuildingsManagerMain.BuildingExists(value3.Position, (BaseBuildingInstance x) => x.BuildingType != BuildingType.Floor))
				{
					Log.Info("Planting ladder blueprint!", SiegeTraversalProvider.LogPath);
					num = FindLadderAngle(value3);
					baseBuildingInstance = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding("stick_ladder", value3.Position, num);
					flag = true;
				}
				else
				{
					if (value3.Position.y <= value2.Position.y || value2.Map.BuildingsManagerMain.BuildingExists(value2.Position, (BaseBuildingInstance x) => x.BuildingType != BuildingType.Floor))
					{
						Log.Info($"There already is a blueprint at {value2.Position} or {value3.Position}!", SiegeTraversalProvider.LogPath);
						EndAction(success: true);
						return;
					}
					Log.Info("Planting ladder blueprint!", SiegeTraversalProvider.LogPath);
					num = FindLadderAngle(value2);
					baseBuildingInstance = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding("stick_ladder", value2.Position, num);
					flag = true;
				}
			}
			else if (SiegeTraversalProvider.IsWaterStepUpAttackPlank(value2, value3))
			{
				if (value3.GetWorldObject(GridDataType.BuildingBlueprint | GridDataType.OthersBlueprint) is BaseBuildingInstance)
				{
					Log.Info($"There already is a blueprint at {value3.Position}!", SiegeTraversalProvider.LogPath);
					EndAction(success: true);
					return;
				}
				baseBuildingInstance = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding("wicker_mesh_floor", value2.Position + Vec3Int.up, 0);
				flag = true;
				if (baseBuildingInstance != null)
				{
					Log.Info($"Planting floor blueprint (water step up plank) at {baseBuildingInstance.GetGridPosition()}!", SiegeTraversalProvider.LogPath);
					Log.Info($"Current position: {currentNode.value.Position}, Previous position: {previousNode.value.Position}!", SiegeTraversalProvider.LogPath);
				}
			}
			else if (SiegeTraversalProvider.IsAirBridge(value2, value3) || SiegeTraversalProvider.IsAirGap(value2, value3))
			{
				if (value3.GetWorldObject(GridDataType.BuildingBlueprint | GridDataType.OthersBlueprint) is BaseBuildingInstance)
				{
					Log.Info($"There already is a blueprint at {value3.Position}!", SiegeTraversalProvider.LogPath);
					EndAction(success: true);
					return;
				}
				if (!value2.IsVoxelFloor() && !value2.IsLadder())
				{
					BaseBuildingInstance baseBuildingInstance2 = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding("wicker_mesh_floor", value2.Position, 0);
					if (baseBuildingInstance2 != null)
					{
						baseBuildingInstance2.AutoConstructSequence();
						Log.Info($"Created support floor at {value2.Position}!", SiegeTraversalProvider.LogPath);
					}
					else
					{
						Log.Info($"Failed to create support floor at {value2.Position}!", SiegeTraversalProvider.LogPath);
					}
				}
				baseBuildingInstance = MonoSingleton<BuildingPlacementManager>.Instance.SpawnEnemyBuilding("wicker_mesh_floor", value3.Position, 0);
				flag = true;
				if (baseBuildingInstance != null)
				{
					Log.Info($"Planting floor blueprint at {baseBuildingInstance.GetGridPosition()}!", SiegeTraversalProvider.LogPath);
					Log.Info($"Current position: {currentNode.value.Position}, Previous position: {previousNode.value.Position}!", SiegeTraversalProvider.LogPath);
				}
			}
			if (baseBuildingInstance == null)
			{
				if (flag)
				{
					Log.Info("Failed! No target building to build! Removing node from path!", SiegeTraversalProvider.LogPath);
					siegePath.value.RemoveAt(siegePath.value.Count - 1);
					previousNode.SetValue(currentNode.value);
				}
				EndAction(success: false);
			}
			else
			{
				buildingBlueprint = baseBuildingInstance;
				timeStart = Time.time;
			}
		}

		protected override void OnTick()
		{
			if (buildingBlueprint != null)
			{
				if (Time.time - timeStart > 2f)
				{
					Log.Trace($"Building reachability timed out, plan action FAIL ({buildingBlueprint})", SiegeTraversalProvider.LogPath);
					buildingBlueprint = null;
					EndAction(success: false);
				}
				else if (!buildingBlueprint.IsReachabilityUpdateInProgress)
				{
					Log.Trace($"Building reachability calclulated, plan action SUCCESS ({buildingBlueprint})", SiegeTraversalProvider.LogPath);
					target.SetValue(buildingBlueprint);
					buildingBlueprint = null;
					EndAction(success: true);
				}
			}
		}

		protected override void OnStop(bool interrupted)
		{
			base.OnStop(interrupted);
			buildingBlueprint = null;
		}

		private int FindLadderAngle(MapNode nodeWhereLadderStarts)
		{
			foreach (MapNode item in nodeWhereLadderStarts.IterateNeighboursXZ())
			{
				if ((item.Position.x == nodeWhereLadderStarts.Position.x || item.Position.z == nodeWhereLadderStarts.Position.z) && (item.IsVoxelWall() || !item.IsVoxelAir()))
				{
					Vec3Int lhs = item.Position - nodeWhereLadderStarts.Position;
					if (lhs == Vec3Int.forward)
					{
						return 0;
					}
					if (lhs == Vec3Int.right)
					{
						return 90;
					}
					if (lhs == Vec3Int.back)
					{
						return 180;
					}
					if (lhs == Vec3Int.left)
					{
						return 270;
					}
					Log.Error("LADDER ANGLES GOT WRONG!!! AAAAAA!!!!", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\SiegeBuildBlueprintPlan.cs");
					return 0;
				}
			}
			return 0;
		}
	}
}
