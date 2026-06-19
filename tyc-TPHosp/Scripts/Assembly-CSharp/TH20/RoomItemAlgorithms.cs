#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public static class RoomItemAlgorithms
	{
		private static List<Vector2> _enlargedShapePoints = new List<Vector2>();

		private static bool CollisionInsideRoom(RoomItem item, FloorPlan floorPlan)
		{
			float wallThickness = floorPlan.Definition.WallThickness;
			List<ConvexPolygon> worldSpaceSolidAndNonSolidShapes = item.WorldSpaceSolidAndNonSolidShapes;
			for (int i = 0; i < worldSpaceSolidAndNonSolidShapes.Count; i++)
			{
				ConvexPolygon.Enlarge(worldSpaceSolidAndNonSolidShapes[i], wallThickness, ref _enlargedShapePoints);
				foreach (Vector2 enlargedShapePoint in _enlargedShapePoints)
				{
					if (!RoomAlgorithms.RoomContainsWorldCoord(floorPlan, new Vector3(enlargedShapePoint.x, 0f, enlargedShapePoint.y).ToGridCoord()))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static WallCoord GetClosestWallToLocation(FloorPlan floorPlan, Vector3 worldPosition, float radius, bool onlyOnSameAxis = false, RoomItem roomItem = null)
		{
			float num = radius * radius;
			Vector3 anchorWorldPos = floorPlan.GetAnchorWorldPos();
			Vector3 vector = worldPosition - anchorWorldPos;
			GridCoord gridCoord = GridCoord.WorldPositionToGridCoord(vector);
			float num2 = float.MaxValue;
			WallCoord result = null;
			List<WallCoord> list = ((roomItem == null || floorPlan.Walls.Count <= 0 || roomItem.Definition.FixedWallPlacement == RoomItemDefinition.FixedWallPlacementOption.None) ? floorPlan.Walls : GetRelevantWalls(roomItem.Definition.FixedWallPlacement, floorPlan.Walls));
			for (int i = 0; i < list.Count; i++)
			{
				WallCoord wallCoord = list[i];
				if (wallCoord.IsCorner())
				{
					continue;
				}
				GridCoord gridCoord2 = gridCoord - wallCoord._position;
				if (!onlyOnSameAxis || gridCoord2.X == 0 || gridCoord2.Y == 0)
				{
					float num3 = wallCoord.DistanceSquared(vector);
					if (num3 <= num2 && num3 <= num)
					{
						num2 = num3;
						result = wallCoord;
					}
				}
			}
			return result;
		}

		public static List<WallCoord> GetRelevantWalls(RoomItemDefinition.FixedWallPlacementOption fixedWallPlacementOption, List<WallCoord> originalList)
		{
			List<WallCoord> result = new List<WallCoord>();
			if (fixedWallPlacementOption == RoomItemDefinition.FixedWallPlacementOption.AmbulanceBayEntrance)
			{
				result = originalList.Where((WallCoord x) => x._type == RoomWallDefinition.Type.AmbulanceBayEntrance).ToList();
			}
			return result;
		}

		public static bool CanAutoPlaceDoorAtLocation(FloorPlan floorPlan, Vector3 worldPosition, float radius)
		{
			if (GetClosestWallToLocation(floorPlan, worldPosition, radius, onlyOnSameAxis: true) != null)
			{
				return true;
			}
			return false;
		}

		private static bool WallCornerAtItemLocation(RoomItem item)
		{
			List<WallCoord> walls = item.FloorPlan.Walls;
			if (walls != null)
			{
				GridCoord localCoord = item.LocalCoord;
				foreach (WallCoord item2 in walls)
				{
					if (!item2.IsCorner() && item2._position == localCoord && item2._type != RoomWallDefinition.Type.Wall && item2._type != RoomWallDefinition.Type.Door && item2._type != RoomWallDefinition.Type.Window)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool ValidWallAtItemLocation(RoomItem item)
		{
			float wallWidth = item.WallWidth;
			Vector3 vector = item.GridRotation.RotateClockwise().DirectionVector() * wallWidth * 0.5f;
			if (TestWall(item, item.LocalPosition + vector) && TestWall(item, item.LocalPosition - vector))
			{
				return true;
			}
			return false;
		}

		private static bool TestWall(RoomItem item, Vector3 pos)
		{
			List<WallCoord> list = item.FloorPlan.Walls;
			if (item.FloorPlan.Walls.Count > 0 && item.Definition.FixedWallPlacement != RoomItemDefinition.FixedWallPlacementOption.None)
			{
				list = GetRelevantWalls(item.Definition.FixedWallPlacement, item.FloorPlan.Walls);
			}
			if (list != null)
			{
				GridCoord gridCoord = pos.ToGridCoord();
				foreach (WallCoord item2 in list)
				{
					if (!item2.IsCorner() && item2._position == gridCoord && item.GridRotation == item2._rotation)
					{
						return true;
					}
				}
			}
			return false;
		}

		private static bool ItemExitsToHospital(RoomItem item, WorldState worldState)
		{
			Vector3 vector = item.WorldPosition + item.GridRotation.DirectionVector() * 2f;
			Vector3 vector2 = item.GridRotation.RotateClockwise().DirectionVector() * 0.9f;
			if (!TestHospitalLocation(item, worldState, (vector + vector2).ToGridCoord()))
			{
				return false;
			}
			if (!TestHospitalLocation(item, worldState, (vector - vector2).ToGridCoord()))
			{
				return false;
			}
			return true;
		}

		private static bool TestHospitalLocation(RoomItem item, WorldState worldState, GridCoord worldCoord)
		{
			Room roomAtWorldCoord = worldState.GetRoomAtWorldCoord(worldCoord, includeHospital: true, includeClosedPlots: false);
			if (item.Level.BuildingLogic.CurrentBlueprintFloorPlan != null && RoomAlgorithms.RoomContainsWorldCoord(item.Level.BuildingLogic.CurrentBlueprintFloorPlan, worldCoord))
			{
				return false;
			}
			if (roomAtWorldCoord != null && roomAtWorldCoord.Definition.IsHospitalOrBay)
			{
				return !OtherItemsAtLocation(item, worldState, worldCoord, null);
			}
			return false;
		}

		private static bool ItemsWithinRange(RoomItem item, RoomItem other)
		{
			if (item.ValidCollisionShapesRadius && other.ValidCollisionShapesRadius)
			{
				return (item.CollisionShapesRadiusWorldCenter - other.CollisionShapesRadiusWorldCenter).sqrMagnitude < MathUtils.Square(item.CollisionShapesRadius + other.CollisionShapesRadius);
			}
			return false;
		}

		private static bool OtherItemsAtLocation(RoomItem item, WorldState worldState, GridCoord worldCoord, List<RoomItem> otherItems)
		{
			FloorPlan floorPlan = item.FloorPlan;
			List<RoomItem> itemsAtCoord = floorPlan.GetItemsAtCoord(worldCoord - floorPlan.Anchor);
			if (itemsAtCoord != null)
			{
				foreach (RoomItem item2 in itemsAtCoord)
				{
					if (item2 != item && ItemsWithinRange(item, item2) && !ItemsCanBePlacedOnEachOther(item, item2, otherItems))
					{
						otherItems?.AddUnique(item2);
						return true;
					}
				}
			}
			HospitalMap hospitalMap = floorPlan.HospitalMap;
			foreach (Room allRoom in worldState.AllRooms)
			{
				FloorPlan floorPlan2 = allRoom.FloorPlan;
				if (floorPlan == floorPlan2 || floorPlan2.HospitalMap != hospitalMap)
				{
					continue;
				}
				itemsAtCoord = floorPlan2.GetItemsAtCoord(worldCoord - floorPlan2.Anchor);
				if (itemsAtCoord != null)
				{
					foreach (RoomItem item3 in itemsAtCoord)
					{
						if (item3 != item && ItemsWithinRange(item, item3) && !ItemsCanBePlacedOnEachOther(item, item3, otherItems))
						{
							otherItems?.AddUnique(item3);
							return true;
						}
					}
				}
				RoomItem door = floorPlan2.Door;
				if (door != null && door != item && ItemsWithinRange(item, door) && !ItemsCanBePlacedOnEachOther(item, door, otherItems))
				{
					otherItems?.AddUnique(door);
					return true;
				}
			}
			return false;
		}

		private static bool ItemsCanBePlacedOnEachOther(RoomItem item, RoomItem otherItem, List<RoomItem> otherItems)
		{
			if (item == otherItem)
			{
				return true;
			}
			IRoomItemDefinition definition = item.Definition;
			IRoomItemDefinition definition2 = otherItem.Definition;
			bool flag = definition.HasCollision && definition.PlaceOnWall && !definition.OccupyWallOnly;
			bool flag2 = definition2.HasCollision && definition2.PlaceOnWall && !definition2.OccupyWallOnly;
			if (otherItem.IsHospitalWindow || item.IsHospitalWindow)
			{
				return true;
			}
			if (!flag && !flag2 && definition.OccupyWallOnly != definition2.OccupyWallOnly && definition.ItemType != RoomItemDefinition.Type.Door && definition2.ItemType != RoomItemDefinition.Type.Door && definition.ItemType != RoomItemDefinition.Type.SideDoor && definition2.ItemType != RoomItemDefinition.Type.SideDoor)
			{
				return true;
			}
			if (definition.OccupyWallOnly && definition2.OccupyWallOnly)
			{
				if (item.GridRotation != otherItem.GridRotation)
				{
					return true;
				}
				if (definition.ItemType == RoomItemDefinition.Type.Window && definition2.ItemType == RoomItemDefinition.Type.Window)
				{
					return false;
				}
			}
			bool num = definition.ItemType == RoomItemDefinition.Type.Door && definition2.ItemType == RoomItemDefinition.Type.Window;
			bool flag3 = definition.ItemType == RoomItemDefinition.Type.Window && definition2.ItemType == RoomItemDefinition.Type.Door;
			if (!num && !flag3 && (definition.ItemCollisionType != RoomItemDefinition.CollisionType.Rug || !definition2.CollideWithRugs) && (definition2.ItemCollisionType != RoomItemDefinition.CollisionType.Rug || !definition.CollideWithRugs))
			{
				if (definition.ItemCollisionType == RoomItemDefinition.CollisionType.Rug)
				{
					if (!definition2.CollideWithRugs && definition2.ItemCollisionType != RoomItemDefinition.CollisionType.Rug)
					{
						return true;
					}
				}
				else if ((!definition.CollideWithSameType || (definition.CollideWithSameType && definition != definition2)) && (!definition.HasCollision || !definition2.HasCollision))
				{
					return true;
				}
			}
			bool flag4 = item.GetComponent<RoomItemSellInvalidComponent>() != null;
			bool flag5 = otherItem.GetComponent<RoomItemSellInvalidComponent>() != null;
			if (flag4 || flag5)
			{
				if (otherItems != null)
				{
					if (flag4)
					{
						otherItems.AddUnique(item);
					}
					if (flag5)
					{
						otherItems.AddUnique(otherItem);
					}
				}
				return true;
			}
			if (item.FloorPlan != otherItem.FloorPlan)
			{
				if (item.FloorPlan is BlueprintFloorPlan && ((BlueprintFloorPlan)item.FloorPlan).ItemsToSell.Contains(otherItem))
				{
					return true;
				}
				if (otherItem.FloorPlan is BlueprintFloorPlan && ((BlueprintFloorPlan)otherItem.FloorPlan).ItemsToSell.Contains(item))
				{
					return true;
				}
			}
			if (!ItemsWithinRange(item, otherItem))
			{
				return true;
			}
			List<ConvexPolygon> worldSpaceSolidShapes = item.WorldSpaceSolidShapes;
			List<ConvexPolygon> worldSpaceSolidShapes2 = otherItem.WorldSpaceSolidShapes;
			List<ConvexPolygon> worldSpaceNonSolidShapes = item.WorldSpaceNonSolidShapes;
			List<ConvexPolygon> worldSpaceNonSolidShapes2 = otherItem.WorldSpaceNonSolidShapes;
			bool flag6 = false;
			foreach (ConvexPolygon item2 in worldSpaceSolidShapes)
			{
				foreach (ConvexPolygon item3 in worldSpaceSolidShapes2)
				{
					if (ConvexPolygon.Overlaps(item2, item3))
					{
						flag6 = true;
					}
				}
				foreach (ConvexPolygon item4 in worldSpaceNonSolidShapes2)
				{
					if (ConvexPolygon.Overlaps(item2, item4))
					{
						flag6 = true;
					}
				}
			}
			foreach (ConvexPolygon item5 in worldSpaceNonSolidShapes)
			{
				foreach (ConvexPolygon item6 in worldSpaceSolidShapes2)
				{
					if (ConvexPolygon.Overlaps(item5, item6))
					{
						flag6 = true;
					}
				}
			}
			if (flag6 && (definition.UseVerticalCollision || definition2.UseVerticalCollision))
			{
				Vector2 itemVerticalSpace = GetItemVerticalSpace(item);
				Vector2 itemVerticalSpace2 = GetItemVerticalSpace(otherItem);
				if (itemVerticalSpace.y < itemVerticalSpace2.x || itemVerticalSpace.x > itemVerticalSpace2.y)
				{
					flag6 = false;
				}
			}
			return !flag6;
		}

		private static Vector2 GetItemVerticalSpace(RoomItem item)
		{
			Vector2 result = new Vector2(float.MaxValue, float.MinValue);
			Bounds[] cachedBounds = item.CachedBounds;
			for (int i = 0; i < cachedBounds.Length; i++)
			{
				Bounds bounds = cachedBounds[i];
				if (bounds.min.y < result.x)
				{
					result.x = bounds.min.y;
				}
				if (bounds.max.y > result.y)
				{
					result.y = bounds.max.y;
				}
			}
			return result;
		}

		public static void Validate(ItemValidateMode validateMode, bool fullTest, RoomItem item, WorldState worldState, FinanceManager financeManager, RoomBuildingNavMesh navMesh, List<RoomItem> invalidItems = null, Vector3 cellOffset = default(Vector3))
		{
			if (item.Definition.IgnoreValidation)
			{
				if (validateMode != ItemValidateMode.Set)
				{
					return;
				}
				if (item.Definition.ItemType == RoomItemDefinition.Type.Landscape)
				{
					foreach (LandscapeRoomItem landscapeItem in item.FloorPlan.LandscapeItems)
					{
						if (landscapeItem != item && landscapeItem.Definition == item.Definition && landscapeItem.WorldPosition == item.WorldPosition && landscapeItem.Rotation.CompareTo(item.Rotation) == 0)
						{
							item.SetValidDebug(valid: false, "Duplicate landscape item at location");
							return;
						}
					}
				}
				if (!InteractionAlgorithms.ValidateInteractionStartLocations(validateMode, item, worldState, navMesh, invalidItems, cellOffset))
				{
					item.SetValid(valid: false, "Invalid start location(s)", ScriptLocalization.Menu.ItemInvalid_InvalidStartLocations_CS);
				}
				else
				{
					item.SetValidDebug(valid: true, "Validation ignored");
				}
				return;
			}
			FloorPlan floorPlan = item.FloorPlan;
			IRoomItemDefinition definition = item.Definition;
			if (!fullTest)
			{
				if (!InteractionAlgorithms.ValidateInteractionStartLocations(validateMode, item, worldState, navMesh, invalidItems, cellOffset))
				{
					if (validateMode == ItemValidateMode.Set)
					{
						item.SetValidDebug(valid: false, "Invalid start location(s)");
					}
				}
				else if (validateMode == ItemValidateMode.Set)
				{
					item.SetValidDebug(valid: true, "OK");
				}
				return;
			}
			if (floorPlan.HospitalMap != null && !floorPlan.HospitalMap.Plot.Bought)
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValid(valid: false, "Unreachable", ScriptLocalization.Menu.ItemInvalid_InvalidNavigation_CS);
				}
				return;
			}
			if (financeManager != null && !item.IsHospitalWindow && !financeManager.CanAfford(item.Cost) && !item.HasBeenPurchased)
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValid(valid: false, "Can't afford item", ScriptLocalization.Menu.ItemInvalid_Unaffordable_CS);
				}
				return;
			}
			if (!definition.CanBePlacedIn(floorPlan.Definition._type) && RoomAlgorithms.RoomContainsWorldCoord(floorPlan, item.WorldPosition.ToGridCoord()))
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValid(valid: false, "Invalid item for room", ScriptLocalization.Menu.ItemInvalid_InvalidItemForRoom_CS);
				}
				return;
			}
			if (definition.PlaceOnWall && !ValidWallAtItemLocation(item))
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValid(valid: false, "Invalid wall location", ScriptLocalization.Menu.ItemInvalid_InvalidWallLocation_CS);
				}
				return;
			}
			if (!definition.AllowOnCorner && WallCornerAtItemLocation(item))
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValid(valid: false, "Invalid corner location", ScriptLocalization.Menu.ItemInvalid_InvalidCornerLocation_CS);
				}
				return;
			}
			if (definition.ItemType == RoomItemDefinition.Type.Door && (!ItemExitsToHospital(item, worldState) || !DoorConnectsToEntrance(item, item.FloorPlan)))
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValid(valid: false, "Door doesn't exit to hospital", ScriptLocalization.Menu.ItemInvalid_DoorExitNotToHospital_CS);
				}
				return;
			}
			if (definition.ItemType == RoomItemDefinition.Type.Window && !item.IsHospitalWindow)
			{
				Vector3 vector = item.WorldPosition + item.GridRotation.DirectionVector() * 2f;
				if (worldState.GetRoomAtWorldCoord(vector, includeHospital: true, includeClosedPlots: false) == null)
				{
					if (validateMode == ItemValidateMode.Set)
					{
						item.SetValid(valid: false, "Window doesn't look into hospital", ScriptLocalization.Menu.ItemInvalid_WindowNotIntoHospital_CS);
					}
					return;
				}
				bool windowFound = false;
				GridDirection windowDir = item.GridRotation.Rotate180();
				RoomAlgorithms.IterateRoomItemsAtCoord(worldState, vector.ToGridCoord(), delegate(RoomItem otherItem)
				{
					if (item != otherItem && otherItem.Definition.ItemType == RoomItemDefinition.Type.Window && otherItem.GridRotation == windowDir && !otherItem.IsHospitalWindow)
					{
						windowFound = true;
					}
				});
				if (windowFound)
				{
					if (validateMode == ItemValidateMode.Set)
					{
						item.SetValid(valid: false, "Neighbouring window at location", ScriptLocalization.Menu.ItemInvalid_NeighbouringWindowAtLocation_CS);
					}
					return;
				}
			}
			if (floorPlan.Definition._singlePlaceItems.Contains(definition.ItemType))
			{
				foreach (RoomItem item2 in floorPlan.Items)
				{
					if (item != item2 && definition == item2.Definition)
					{
						if (validateMode == ItemValidateMode.Set)
						{
							item.SetValid(valid: false, "Invalid item for room", ScriptLocalization.Menu.ItemInvalid_InvalidItemForRoom_CS);
						}
						return;
					}
				}
			}
			if (definition.ItemType == RoomItemDefinition.Type.ServingHatch && !ItemExitsToHospital(item, worldState))
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValid(valid: false, "Serving hatch doesn't exit to hospital", ScriptLocalization.Menu.ItemInvalid_ServingHatchNotExitToHospital_CS);
				}
				return;
			}
			if (!InteractionAlgorithms.ValidateInteractionStartLocations(validateMode, item, worldState, navMesh, invalidItems, cellOffset))
			{
				if (validateMode == ItemValidateMode.Set)
				{
					item.SetValidDebug(valid: false, "Invalid start location(s)");
				}
				return;
			}
			GridBounds[] tileBounds = item.GetTileBounds();
			HospitalMap hospitalMap = floorPlan.HospitalMap;
			for (int num = 0; num < tileBounds.Length; num++)
			{
				GridBounds gridBounds = tileBounds[num];
				for (int num2 = gridBounds.Min.Y; num2 < gridBounds.Max.Y; num2++)
				{
					for (int num3 = gridBounds.Min.X; num3 < gridBounds.Max.X; num3++)
					{
						GridCoord gridCoord = new GridCoord(num3, num2);
						GridCoord worldCoord = gridCoord + floorPlan.Anchor;
						RoomItem roomItem = RoomAlgorithms.DoorExitAtWorldPosition(worldState, worldCoord, hospitalMap);
						if (roomItem != null && !ItemsCanBePlacedOnEachOther(item, roomItem, invalidItems))
						{
							if (validateMode == ItemValidateMode.Set)
							{
								item.SetValidDebug(valid: false, "Door exit at location");
							}
							invalidItems?.AddUnique(roomItem);
							return;
						}
						if (definition.AllowCollisionOutsideRoom())
						{
							continue;
						}
						if (!RoomAlgorithms.RoomContainsCoord(floorPlan, gridCoord))
						{
							if (validateMode == ItemValidateMode.Set)
							{
								item.SetValidDebug(valid: false, "Item outside room");
							}
							return;
						}
						if (!CollisionInsideRoom(item, floorPlan))
						{
							if (validateMode == ItemValidateMode.Set)
							{
								item.SetValidDebug(valid: false, "Collision outside room");
							}
							return;
						}
					}
				}
				if (definition.HasCollision && !definition.OccupyWallOnly)
				{
					gridBounds.Grow(2);
				}
				for (int num4 = gridBounds.Min.Y; num4 < gridBounds.Max.Y; num4++)
				{
					for (int num5 = gridBounds.Min.X; num5 < gridBounds.Max.X; num5++)
					{
						int num6 = num5 + floorPlan.Anchor.X;
						int num7 = num4 + floorPlan.Anchor.Y;
						Vector2 vector2 = new Vector2((float)num6 * 2f, (float)num7 * 2f);
						if ((!item.ValidCollisionShapesRadius || !((item.CollisionShapesRadiusWorldCenter - vector2).magnitude > item.CollisionShapesRadius + 2f)) && OtherItemsAtLocation(item, worldState, new GridCoord(num6, num7), invalidItems))
						{
							if (validateMode == ItemValidateMode.Set)
							{
								item.SetValidDebug(valid: false, "Other item at location");
							}
							return;
						}
					}
				}
			}
			if (validateMode == ItemValidateMode.Set)
			{
				item.SetValidDebug(valid: true, "OK");
			}
		}

		public static bool DoorConnectsToEntrance(RoomItem door, FloorPlan unbuiltRoom)
		{
			Vector3 worldPos = CalculateDoorEnter(door);
			door.FloorPlan.HospitalMap.CacheArrivalDeparturePositions();
			return RoomAlgorithms.PositionConnectsToEntrance(worldPos, door.FloorPlan.HospitalMap, unbuiltRoom);
		}

		public static int RequiredItemCount(FloorPlan floorPlan, IRoomItemDefinition itemDefinition)
		{
			RequiredItem[] requiredItemsNew = floorPlan.Definition._requiredItemsNew;
			foreach (RequiredItem requiredItem in requiredItemsNew)
			{
				if (!requiredItem.Contains(itemDefinition))
				{
					continue;
				}
				int num = 0;
				{
					foreach (RoomItem item in floorPlan.Items)
					{
						if (requiredItem.Contains(item.Definition))
						{
							num++;
						}
					}
					return num;
				}
			}
			return 0;
		}

		public static RoomItem SpawnItem(RoomItemDefinition definition, Vector3 position, float randomOffset, float rotation, Level level, Room room)
		{
			if (room == null)
			{
				Logging.Warning(LogChannels.Building, "Trying to spawn item {0} in a NULL room", definition.GetName());
				return null;
			}
			if (level.ItemSpawnLimits != null && level.ItemSpawnLimits.MaxReached(definition))
			{
				return null;
			}
			if (randomOffset > 0f && !room.FloorPlan.AnyWallAtLocalCoord(position.ToGridCoord()))
			{
				position += RandomUtils.RandomXZVector(0f - randomOffset, randomOffset);
			}
			RoomItem roomItem = new RoomItem(definition, room.FloorPlan, level)
			{
				Rotation = rotation,
				LocalPosition = position - room.FloorPlan.Anchor.ToWorldPosition()
			};
			room.FloorPlan.AddItem(roomItem);
			room.FloorPlanVisual.CreateRoomItems();
			Validate(ItemValidateMode.Set, fullTest: true, roomItem, level.WorldState, level.FinanceManager, null);
			if (roomItem.IsValid)
			{
				roomItem.AddToWorld(updateNavigation: true);
				return roomItem;
			}
			Logging.Warning(LogChannels.Building, "Spawned item {0} is invalid: {1}", roomItem, roomItem.InvalidReasonDebug);
			level.BuildEvents.OnRoomItemDestroy.InvokeSafe(roomItem);
			return null;
		}

		public static void RefreshInvalidItemBounds(FloorPlan floorPlan)
		{
			if (floorPlan.HospitalMap?.Plot == null || !floorPlan.HospitalMap.Plot.Bought)
			{
				return;
			}
			foreach (RoomItem item in floorPlan.Items)
			{
				RoomItemVisual visual = item.Visual;
				if (visual != null)
				{
					if (!item.IsValid)
					{
						visual.ShowBoundsVisual(item, thinking: false);
					}
					else
					{
						visual.HideBoundsVisual();
					}
				}
			}
		}

		public static void ShowItemBounds(List<RoomItem> items)
		{
			if (items == null)
			{
				return;
			}
			foreach (RoomItem item in items)
			{
				RoomItemVisual visual = item.Visual;
				if (visual != null)
				{
					bool isValid = item.IsValid;
					item.SetValid(valid: false, item.InvalidReasonDebug, item.InvalidReasonDisplay);
					visual.ShowBoundsVisual(item, thinking: false);
					item.SetValid(isValid, item.InvalidReasonDebug, item.InvalidReasonDisplay);
				}
			}
		}

		public static void HideItemBounds(List<RoomItem> items)
		{
			if (items == null)
			{
				return;
			}
			foreach (RoomItem item in items)
			{
				item.Visual?.HideBoundsVisual();
			}
		}

		public static void ShowSellItems(List<RoomItem> items)
		{
			if (items == null)
			{
				return;
			}
			foreach (RoomItem item in items)
			{
				item.GetOrAddComponent<RoomItemSellInvalidComponent>();
			}
		}

		public static void RefreshBoundVisualsOnItems(List<RoomItem> previousItems, List<RoomItem> currentItems)
		{
			foreach (RoomItem previousItem in previousItems)
			{
				if (!currentItems.Contains(previousItem))
				{
					previousItem.Visual?.HideBoundsVisual();
				}
			}
			foreach (RoomItem currentItem in currentItems)
			{
				if (!previousItems.Contains(currentItem))
				{
					RoomItemVisual visual = currentItem.Visual;
					if (visual != null)
					{
						bool isValid = currentItem.IsValid;
						currentItem.SetValid(valid: false, currentItem.InvalidReasonDebug, currentItem.InvalidReasonDisplay);
						visual.ShowBoundsVisual(currentItem, thinking: false);
						currentItem.SetValid(isValid, currentItem.InvalidReasonDebug, currentItem.InvalidReasonDisplay);
					}
				}
			}
		}

		public static void RefreshSellVisualsOnItems(List<RoomItem> previousSellItems, List<RoomItem> currentSellItems)
		{
			foreach (RoomItem previousSellItem in previousSellItems)
			{
				if (!currentSellItems.Contains(previousSellItem))
				{
					previousSellItem.RemoveComponents<RoomItemSellInvalidComponent>();
				}
			}
			foreach (RoomItem currentSellItem in currentSellItems)
			{
				if (!previousSellItems.Contains(currentSellItem))
				{
					currentSellItem.GetOrAddComponent<RoomItemSellInvalidComponent>();
				}
			}
		}

		public static void HideSellItems(List<RoomItem> items)
		{
			if (items == null)
			{
				return;
			}
			foreach (RoomItem item in items)
			{
				item.RemoveComponents<RoomItemSellInvalidComponent>();
			}
		}

		public static Vector3 CalculateDoorEnter(RoomItem door)
		{
			return door.WorldPosition + door.GridRotation.DirectionVector() * 2f;
		}
	}
}
