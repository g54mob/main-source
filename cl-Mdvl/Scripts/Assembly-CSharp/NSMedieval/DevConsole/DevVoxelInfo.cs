using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;
using UnityEngine.Events;

namespace NSMedieval.DevConsole
{
	public class DevVoxelInfo
	{
		private List<bool> isInfoLine;

		private List<string> buttonText;

		private List<UnityAction> buttonAction;

		private List<string> info;

		private Dictionary<string, int> tmpCounter;

		private Vec3Int currentGridPosition;

		private const string ControlInfo = "Usage:\n Offset Up = {0} + {1}\n Offset Down = {0} + {2}\n Freeze at current voxel = {0} + {3}\n Copy all info to clipboard = {0} + {4}";

		private string controlInfoString;

		private VillageMap villageMap;

		private StringBuilder stringBuilderGrid;

		private StringBuilder stringBuilderWorldData;

		private Dictionary<MapNode, bool> roomDetectionCanGoInDirection;

		public List<string> Info => info;

		public List<bool> IsInfoLine => isInfoLine;

		public List<string> ButtonText => buttonText;

		public List<UnityAction> ButtonAction => buttonAction;

		public Vec3Int CurrentGridPosition => currentGridPosition;

		public VillageMap VillageMap => villageMap ?? (villageMap = VillageManager.ActiveVillage.Map);

		public DevVoxelInfo()
		{
			Init();
		}

		private void Init()
		{
			controlInfoString = string.Format("Usage:\n Offset Up = {0} + {1}\n Offset Down = {0} + {2}\n Freeze at current voxel = {0} + {3}\n Copy all info to clipboard = {0} + {4}", MonoSingleton<DevVoxelInfoController>.Instance.OffsetCtrlKey, MonoSingleton<DevVoxelInfoController>.Instance.OffsetUpKey, MonoSingleton<DevVoxelInfoController>.Instance.OffsetDownKey, MonoSingleton<DevVoxelInfoController>.Instance.ToggleInputKey, MonoSingleton<DevVoxelInfoController>.Instance.CopyAllToClipboardKey);
			stringBuilderGrid = new StringBuilder(4000, 10000);
			stringBuilderWorldData = new StringBuilder(500, 2000);
			roomDetectionCanGoInDirection = new Dictionary<MapNode, bool>();
			isInfoLine = new List<bool>();
			buttonText = new List<string>();
			buttonAction = new List<UnityAction>();
			info = new List<string>();
			tmpCounter = new Dictionary<string, int>();
		}

		private void OnClickCloseDebugInfo()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ParseCommand("voxelInfo");
		}

		public void GatherVoxelInfo(Vec3Int gridPosition, Vector3 raycastHit)
		{
			currentGridPosition = gridPosition;
			bool num = GridDataIndexTools.InRange(gridPosition);
			bool flag = GridDataIndexTools.IsForbiddenEdge(gridPosition);
			info.Clear();
			isInfoLine.Clear();
			buttonText.Clear();
			buttonAction.Clear();
			AddTextLine(string.Empty, isInfoOnlyLine: false, "Click to close", OnClickCloseDebugInfo);
			AddTextLine(controlInfoString, isInfoOnlyLine: true);
			AddTextLine("Raycast hit point: " + raycastHit.ToString());
			HideNodeConnectionsVisual();
			AddTextLine($"World.GetDistanceFromMapEdge({gridPosition.x}, {gridPosition.z}): {World.GetDistanceFromMapEdge(gridPosition.x, gridPosition.z)}");
			if (num)
			{
				MapNode node = VillageManager.ActiveVillage.Map.GetNode(gridPosition);
				if (node == null)
				{
					return;
				}
				stringBuilderGrid.Clear();
				stringBuilderGrid.AppendFormat("Grid:\n Position: {0}\n Data: {1}\n Coverage: {2}\n Is Walkable: {3}\n In buildable zone: {4}", gridPosition.ToString(), node.DataType.ToString(), node.Coverage, node.IsWalkable, flag ? "<color=#ff2211>No</color>" : "<color=#30ff10>Yes</color>");
				stringBuilderGrid.AppendFormat("Beauty: {0}", VillageMap.BeautyManager.GetBeauty(node.Position));
				stringBuilderGrid.AppendFormat("\n Voxel Type: {0}\n Health: {1} {2}", node.VoxelType, node.Health, (node.VoxelType == null) ? string.Empty : ("/ " + node.VoxelType.Health));
				stringBuilderGrid.AppendFormat("\n Dig Amount: {0} {1}", node.DigAmount, (node.VoxelType == null) ? string.Empty : ("/ " + node.VoxelType.DigAmount));
				List<BaseBuildingInstance> list = new List<BaseBuildingInstance>();
				List<string> list2 = new List<string>();
				foreach (WorldObject worldObject in node.WorldObjects)
				{
					if (worldObject is BaseBuildingInstance item)
					{
						list.Add(item);
					}
					list2.Add($"\n{worldObject.Type} <{worldObject.GetType().Name}>");
					foreach (Vec3Int reachablePosition in worldObject.ReachablePositions)
					{
						list2.Add($"  >> reach.pos.: {reachablePosition}");
					}
				}
				stringBuilderGrid.AppendLine("\n BaseBuildableObjects:[");
				foreach (BaseBuildingInstance item2 in list)
				{
					stringBuilderGrid.AppendLine("   " + item2.BuildingType);
				}
				stringBuilderGrid.AppendLine("] \n WorldObjects = [" + string.Join(", ", list2) + "]");
				if (node.VoxelType != null)
				{
					stringBuilderGrid.AppendFormat("\n Diggable: {0}", node.VoxelType.IsDiggable);
					if (node.VoxelType.IsDiggable)
					{
						stringBuilderGrid.AppendFormat(", Dig marker: {0}", node.VoxelType.DigMarker);
					}
				}
				AddTextLine(stringBuilderGrid.ToString());
			}
			AddTextLine($"GroundManager.GroundExists: {MonoSingleton<GroundManager>.Instance.GroundExists(gridPosition)}");
			MapNode node2 = VillageMap.GetNode(gridPosition);
			if (node2 == null)
			{
				AddTextLine("Nearest node pos: none");
			}
			else
			{
				ShowNodeConnectionsVisual(node2);
				AddTextLine($"Nearest node pos: {node2.WorldPosition}");
				AddTextLine($"Has Fire: {node2.IsFire}, Max Fire: {node2.ReachedMaxFire}");
			}
			if (node2?.Region == null)
			{
				AddTextLine("Region: \nID: None");
			}
			else
			{
				stringBuilderGrid.Clear();
				Region region = node2.Region;
				stringBuilderGrid.AppendFormat("Region:\nID: {0}\nNodes CNT: {1}\n", region.UniqueId, region.Nodes.Count);
				stringBuilderGrid.AppendFormat("Connections: {0}\n", region.Connections.Count);
				foreach (Region connection in region.Connections)
				{
					stringBuilderGrid.AppendFormat("    - Region {0}\n", connection.UniqueId);
				}
				stringBuilderGrid.AppendFormat("Attributes: {0}\n", region.Attribute);
				if (region is RegionBridge regionBridge)
				{
					stringBuilderGrid.AppendFormat("Node Tags: {0}\n", regionBridge.Tags);
				}
				foreach (Region connection2 in region.Connections)
				{
					stringBuilderGrid.AppendFormat("{0},", connection2.UniqueId);
				}
				tmpCounter.Clear();
				foreach (WorldObject reachableBuilding in region.ReachableBuildings)
				{
					string text = $"{reachableBuilding.BlueprintId} [{reachableBuilding.Type}]";
					if (reachableBuilding is BaseBuildingInstance baseBuildingInstance)
					{
						text += $" [{baseBuildingInstance.BuildingType}]";
					}
					if (!tmpCounter.ContainsKey(text))
					{
						tmpCounter.Add(text, 1);
					}
					else
					{
						tmpCounter[text]++;
					}
				}
				stringBuilderGrid.Append("\nReachableBuildings:");
				foreach (string key in tmpCounter.Keys)
				{
					stringBuilderGrid.Append($"\n * {key} x {tmpCounter[key]})");
				}
				stringBuilderGrid.Append($"\n GridDataType: {region.GridDataType}");
				AddTextLine(stringBuilderGrid.ToString());
			}
			SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(gridPosition);
			AddTextLine($"SlopeManager.IsSlopeAt: {slopeAtPosition != null}, HasDisposed: {slopeAtPosition?.HasDisposed}");
			StairsComponentInstance componentInstance = villageMap.StairsComponentManager.GetComponentInstance(gridPosition);
			AddTextLine($"StairsAndLaddersManager.GetStairsAt: {componentInstance != null}, HasDisposed: {componentInstance?.HasDisposed}");
			List<DigMarkerResourceInstance> worldObjectsList = VillageManager.ActiveVillage.Map.GetWorldObjectsList<DigMarkerResourceInstance>(GridDataType.DigMarkerResourceToMine);
			IEnumerable<DigMarkerResourceInstance> worldObjectsList2 = VillageManager.ActiveVillage.Map.GetWorldObjectsList<DigMarkerResourceInstance>(GridDataType.DigMarkerResource);
			DigMarkerResourceInstance digMarkerResourceInstance = worldObjectsList.FirstOrDefault((DigMarkerResourceInstance dm) => dm.GridDataPosition.Equals(gridPosition));
			if (digMarkerResourceInstance != null)
			{
				AddTextLine($"DigMarkerResourceInstance: {digMarkerResourceInstance.Blueprint?.GetID()}, HasDisposed: {digMarkerResourceInstance.HasDisposed}");
			}
			digMarkerResourceInstance = worldObjectsList2.FirstOrDefault((DigMarkerResourceInstance dm) => dm.Positions.Contains(gridPosition));
			if (digMarkerResourceInstance != null)
			{
				AddTextLine($"DigMarkerResourceInstance: {digMarkerResourceInstance.Blueprint?.GetID()}, HasDisposed: {digMarkerResourceInstance.HasDisposed}");
			}
			AddTextLine($"Stability: {villageMap.StabilityManager.GetFinishedStability(gridPosition)}");
			AddTextLine($"Blueprint stability: {villageMap.StabilityManager.GetBlueprintStability(gridPosition)}");
			AddTextLine($"Height ({gridPosition.x}, {gridPosition.z}): {MonoSingleton<Heightmap>.Instance.GetHeightAt(gridPosition.x, gridPosition.z)}");
			stringBuilderWorldData.Clear();
			stringBuilderWorldData.Append("WorldData:");
			IEnumerable<WorldObject> enumerable = villageMap.GetNode(gridPosition)?.WorldObjects;
			if (enumerable != null)
			{
				foreach (WorldObject item3 in enumerable)
				{
					string text2;
					if (item3 is SlopeInstance || item3.Map.StairsComponentManager.GetComponentInstance(item3) != null)
					{
						text2 = "SLOPE-GRIDPOS: " + item3.GridDataPosition.ToString() + " A:" + item3.Angle + "ALL: \n ";
						for (int num2 = 0; num2 < item3.Positions.Count; num2++)
						{
							text2 = text2 + num2 + ":" + item3.Positions[num2].ToString() + " ";
						}
					}
					else if (item3 is BaseBuildingInstance baseBuildingInstance2)
					{
						text2 = $"{baseBuildingInstance2.BlueprintId}\n   Thermal Model: {baseBuildingInstance2.ThermalModel}\n   Lock state: {baseBuildingInstance2.LockState}, Combat Cover: {baseBuildingInstance2.GetCover()}";
					}
					else if (item3 is ResourcePileInstance)
					{
						string text3 = ((ResourcePileInstance)item3).GetStoredResource().Amount.ToString();
						text2 = ((ResourcePileInstance)item3).Blueprint.GetID() + " " + text3;
					}
					else
					{
						text2 = ((!(item3 is DigMarkerResourceInstance)) ? ((!(item3 is PlantMapResourceInstance)) ? item3.GetType().Name : ((PlantMapResourceInstance)item3).Blueprint.GetID()) : ((DigMarkerResourceInstance)item3).Blueprint.GetID());
					}
					stringBuilderWorldData.AppendFormat("\n {0}: {1}", item3.GridDataPosition.ToString(), text2);
				}
			}
			if (GridDataIndexTools.InRange(gridPosition))
			{
				stringBuilderWorldData.AppendFormat("\n Grid: ");
				MapNode node3 = VillageMap.GetNode(gridPosition);
				foreach (GridDataType value in Enum.GetValues(typeof(GridDataType)))
				{
					if (node3.DataType.HasFlag(value) && value != GridDataType.None)
					{
						stringBuilderWorldData.AppendFormat("{0}, ", value);
					}
				}
			}
			AddTextLine($"Outside air temp: {GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius}\nGround temp: {MonoSingleton<WeatherManager>.Instance.SoilTemperature}\nLocal temp: {VillageMap.TemperatureManager.GetTemperature(gridPosition)}");
			int input = villageMap.TemperatureManager.GetInputDataPacked(gridPosition);
			int num3 = (input >> 24) & 1;
			int num4 = (input >> 25) & 1;
			int num5 = (input >> 26) & 1;
			int num6 = (input >> 27) & 1;
			int num7 = (input >> 28) & 1;
			int num8 = (input >> 29) & 1;
			int num9 = (input >> 30) & 3;
			bool flag2 = villageMap.TemperatureManager.IsInIndices(GridDataIndexTools.FastTo1DIndexNoCheck(gridPosition));
			TemperatureManager.UnpackData(in input, out var heatingTemperature, out var insulation, out var verticalInsulation);
			AddTextLine($"Temp.bitmask:\nTemp.in: {heatingTemperature}, h.insulation: {insulation}, v.insulation: {verticalInsulation}\nIsWalkable ({num3}), IsGround ({num4} ), IsWall({num5}), IsOutsideAir ({num6}), IsShadowC.H ({num7}), IsShadowC.V ({num8}), Light.Tr ({num9})\nIndex in indices list: {flag2}");
			AddTextLine($"Diffuse light: {villageMap.TemperatureManager.GetDiffuseLight(gridPosition)}\n");
			AddTextLine(stringBuilderWorldData.ToString());
			MapNode mapNode = villageMap.GetNode(gridPosition);
			string text4 = "MapNode node: " + ((mapNode == null) ? "none" : mapNode.Index.ToString());
			if (mapNode != null)
			{
				IPathfindingAgent agentForTraversalSpeed = PlayerVoxelInfo.GetAgentForTraversalSpeed();
				uint penalty = mapNode.GetPenalty(agentForTraversalSpeed.WalkableModel.PathfindingPenalty);
				int num10 = (int)(WalkSpeedMultiplier.GetSpeedMultiplier(agentForTraversalSpeed.WalkableModel.WalkSpeedMultiplierBlueprint, mapNode) * 100f);
				text4 += $"\n Penalty: {penalty} ({agentForTraversalSpeed.WalkableModel.PathfindingPenalty?.GetID()}, Walk speed: {num10}%)\nWalkable: {mapNode.IsWalkable}\n";
				text4 += $"Creatures: {mapNode.CreaturesCount}\n";
				text4 += $"Tag: {mapNode.Tag}\n";
				text4 += $"IsWalkable: {mapNode.IsWalkable}\n";
				text4 += $"Water Level: {mapNode.Map.WaterManager.GetWaterLevel(mapNode.Index)} ({mapNode.WaterLevel})\n ";
				text4 += $"Water Depth: {mapNode.Map.WaterManager.GetWaterDepth(mapNode.Index)} ({mapNode.WaterDepthLevel})\n";
			}
			AddTextLine(text4);
			if (mapNode != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("MapNode:");
				stringBuilder.AppendLine($" * DataType: {mapNode.DataType}");
				stringBuilder.AppendLine($" * Tag: {mapNode.Tag}");
				stringBuilder.AppendLine($" * VoxelType: {mapNode.VoxelType}");
				stringBuilder.AppendLine($" * IsWalkable: {mapNode.IsWalkable}");
				stringBuilder.AppendLine($" * Connections: {mapNode.ConnectionsCount}");
				foreach (MapNode item4 in mapNode.ConnectionsSafe)
				{
					stringBuilder.AppendLine($"    - MapNode {item4.Position}");
				}
				stringBuilder.AppendLine($" * Area: {mapNode.Area}");
				stringBuilder.AppendLine($" * Region: {mapNode.Region?.UniqueId}");
				stringBuilder.AppendLine($" * Health: {mapNode.Health}");
				stringBuilder.AppendLine($" * CreaturesCount: {mapNode.CreaturesCount}");
				AddTextLine(stringBuilder.ToString());
			}
			if (mapNode != null)
			{
				roomDetectionCanGoInDirection.Clear();
				MapNode nodeAbove = mapNode.GetNodeAbove();
				MapNode nodeBelow = mapNode.GetNodeBelow();
				MapNode node4 = mapNode.Map.GetNode(mapNode.Position + Vector3.left);
				MapNode node5 = mapNode.Map.GetNode(mapNode.Position + Vector3.right);
				MapNode node6 = mapNode.Map.GetNode(mapNode.Position + Vector3.forward);
				MapNode node7 = mapNode.Map.GetNode(mapNode.Position + Vector3.back);
				AddTextLine("RoomDet can go:");
				if (node4 != null)
				{
					bool flag3 = NSMedieval.RoomDetection.RoomDetection.CanGoToNeighbor(node4);
					AddTextLine($" * left: {flag3}");
					roomDetectionCanGoInDirection.Add(node4, flag3);
				}
				if (node5 != null)
				{
					bool flag4 = NSMedieval.RoomDetection.RoomDetection.CanGoToNeighbor(node5);
					AddTextLine($" * right: {flag4}");
					roomDetectionCanGoInDirection.Add(node5, flag4);
				}
				if (node6 != null)
				{
					bool flag5 = NSMedieval.RoomDetection.RoomDetection.CanGoToNeighbor(node6);
					AddTextLine($" * forward: {flag5}");
					roomDetectionCanGoInDirection.Add(node6, flag5);
				}
				if (node7 != null)
				{
					bool flag6 = NSMedieval.RoomDetection.RoomDetection.CanGoToNeighbor(node7);
					AddTextLine($" * backward: {flag6}");
					roomDetectionCanGoInDirection.Add(node7, flag6);
				}
				if (nodeAbove != null)
				{
					bool flag7 = NSMedieval.RoomDetection.RoomDetection.CanGoUpToNode(mapNode, nodeAbove);
					AddTextLine($" * up: {flag7}");
					roomDetectionCanGoInDirection.Add(nodeAbove, flag7);
				}
				if (nodeBelow != null)
				{
					bool flag8 = NSMedieval.RoomDetection.RoomDetection.CanGoDown(mapNode, nodeBelow);
					AddTextLine($" * down: {flag8}");
					roomDetectionCanGoInDirection.Add(nodeBelow, flag8);
				}
				ShowRoomDetectionCanGoChecks();
				NSMedieval.RoomDetection.RoomDetection roomDetection = VillageMap.RoomDetection;
				Room room = roomDetection.GetRoom(gridPosition);
				if (room != null)
				{
					BaseBuildingInstance baseBuildingInstance3 = null;
					foreach (BaseBuildingInstance door in room.Doors)
					{
						if (door.GridDataPosition.Equals(gridPosition))
						{
							baseBuildingInstance3 = door;
							break;
						}
					}
					string arg = ((room == null) ? "not found" : $"found, size: {room.AllNodes.Count}, linked doors: {room.Doors.Count()}");
					string arg2 = ((baseBuildingInstance3 == null) ? "not found" : "found");
					int roomsCount = roomDetection.RoomsCount;
					string text5 = $"Room Detection: Total rooms: {roomsCount}\n Room: {arg}\n Door: {arg2}\n";
					AddTextLine(text5);
				}
				RoofComponentInstance componentInstance2 = mapNode.Map.RoofComponentManager.GetComponentInstance(gridPosition);
				if (componentInstance2 != null)
				{
					AddTextLine($"Roof: Length: {componentInstance2.Length} Scale: {componentInstance2.Scale} ");
				}
				AddTextLine($"Stairs As Wall: {NSMedieval.RoomDetection.RoomDetection.IsStairsAsWallAt(mapNode)}");
				AddTextLine($"Roof As Wall: {NSMedieval.RoomDetection.RoomDetection.IsRoofAsWallAt(mapNode)}");
			}
			SelectableObject mouseHoverObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
			int count = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count;
			AddTextLine("SelectableObjectManager.MouseHoverObject: " + ((mouseHoverObject != null) ? mouseHoverObject.GetType().Name : "null"));
			AddTextLine($"SelectableObjectManager.SelectedObjects: count {count}");
			IdlePointManager.AnimalIdlePoint animalIdlePoint = mapNode.Map.IdlePointManager.GetAnimalIdlePointAt(mapNode.Index);
			StringBuilder stringBuilder2 = new StringBuilder();
			if (animalIdlePoint != null)
			{
				stringBuilder2.AppendLine("Animal idle point: " + animalIdlePoint.AnimalBlueprint.GetID());
				stringBuilder2.AppendLine($"Humans nearby: {animalIdlePoint.HumansNearbyCount}");
				AddTextLine(stringBuilder2.ToString(), isInfoOnlyLine: false, "Relocate this", delegate
				{
					mapNode.Map.IdlePointManager.RelocateAnimalIdlePoint(animalIdlePoint);
				});
			}
			AddTextLine($"All animal idle points:\nBuildings nearby: {VillageMap.HomeArea.GetBuildingsNearbyCount(gridPosition)}", isInfoOnlyLine: true, "Relocate All", delegate
			{
				foreach (KeyValuePair<Animal, List<IdlePointManager.AnimalIdlePoint>> item5 in VillageMap.IdlePointManager.IdlePointsByAnimal)
				{
					foreach (IdlePointManager.AnimalIdlePoint item6 in item5.Value)
					{
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\DevVoxelInfo.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Relocating idle point ");
							messageBuilder.AppendFormatted(item6.AnimalBlueprint.GetID());
							messageBuilder.AppendLiteral(" at ");
							messageBuilder.AppendFormatted(item6.GridPosition);
						}
						Log.Info(messageBuilder);
						VillageMap.IdlePointManager.RelocateAnimalIdlePoint(item6);
					}
				}
			});
		}

		private void AddTextLine(string text, bool isInfoOnlyLine = false, string btnText = null, UnityAction btnAction = null)
		{
			info.Add(text);
			isInfoLine.Add(isInfoOnlyLine);
			buttonText.Add(btnText);
			buttonAction.Add(btnAction);
		}

		private void HideNodeConnectionsVisual()
		{
			MonoSingleton<VisualDebugManager>.Instance.DisableType(VisualDebugType.NodeConnections);
		}

		private void ShowRoomDetectionCanGoChecks()
		{
			foreach (MapNode key in roomDetectionCanGoInDirection.Keys)
			{
				Color color = (roomDetectionCanGoInDirection[key] ? Color.green : Color.red);
				MonoSingleton<VisualDebugManager>.Instance.DrawSphere(VisualDebugType.NodeConnections, "RoomDetectionCanGo", key.WorldPosition, 0.3f, color);
			}
		}

		private void ShowNodeConnectionsVisual(MapNode node)
		{
			if (node.ConnectionsCount == 0)
			{
				return;
			}
			VisualDebugManager instance = MonoSingleton<VisualDebugManager>.Instance;
			instance.EnableType(VisualDebugType.NodeConnections);
			List<MapNode> list = new List<MapNode>();
			list.Add(node);
			foreach (MapNode item in node.ConnectionsSafe)
			{
				list.Add(item);
			}
			foreach (MapNode item2 in list)
			{
				foreach (MapNode item3 in item2.ConnectionsSafe)
				{
					bool flag = item2.IsWalkable && item3.IsWalkable;
					instance.DrawLine(VisualDebugType.NodeConnections, "connect", item2.WorldPosition, item3.WorldPosition, (!flag) ? Color.red : Color.yellow);
				}
			}
		}
	}
}
