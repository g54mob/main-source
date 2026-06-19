using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20
{
	public class BlueprintFloorPlan : FloorPlan
	{
		private BoolArray2D _tileValidity;

		public bool ValidFloorTiles = true;

		public bool ValidRoomSize = true;

		public bool ValidRoomItems = true;

		public bool ValidRequiredItems = true;

		public bool CanAfford = true;

		private readonly List<RequiredItem> _requiredItems;

		[Obsolete("Not used any more - just keeping in to maintain save compatibility. Can remove if this class gets versioned.")]
		private readonly List<RoomItem> _ownedItems;

		private List<RoomItem> _invalidItems;

		private readonly List<RoomItem> _itemsToSell = new List<RoomItem>();

		private bool[,] _dragStartTiles;

		private GridCoord _dragStartAnchor;

		[DontSave]
		private RoomBuildingNavMesh _navMesh;

		private static readonly List<string> _validStartLocations = new List<string>();

		public bool AutoFlowActive { get; set; }

		public bool CanBeBuilt
		{
			get
			{
				if (ValidFloorTiles && ValidRoomSize && ValidRoomItems && ValidRequiredItems)
				{
					return CanAfford;
				}
				return false;
			}
		}

		public bool[,] TileValidity => _tileValidity.Values;

		public List<RequiredItem> RequiredItems => _requiredItems;

		public List<RoomItem> InvalidItems => _invalidItems;

		public List<RoomItem> ItemsToSell => _itemsToSell;

		public BlueprintFloorPlan(RoomDefinition roomDefinition, Level level, HospitalMap hospitalMap)
			: base(roomDefinition, level, hospitalMap)
		{
			_requiredItems = roomDefinition.GetRequiredItems().ToList();
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnStopRoomAutoFlow = (Action)Delegate.Combine(buildEvents.OnStopRoomAutoFlow, new Action(OnStopRoomAutoFlow));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents2.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			if (base.HospitalMap != null)
			{
				_navMesh = base.Level.BuildingLogic.GetRoomBuildingNavMesh(base.HospitalMap);
			}
			Validate();
		}

		public BlueprintFloorPlan(RoomTemplateFloorPlan template, Level level, HospitalMap hospitalMap)
			: base(template, level, hospitalMap)
		{
			_requiredItems = template.Definition.GetRequiredItems().ToList();
			foreach (RoomTemplateItem item in template.Items)
			{
				if (!(item.Definition != null))
				{
					continue;
				}
				foreach (RequiredItem requiredItem in _requiredItems)
				{
					if (requiredItem.Contains(item.Definition.Instance))
					{
						_requiredItems.Remove(requiredItem);
						break;
					}
				}
			}
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnStopRoomAutoFlow = (Action)Delegate.Combine(buildEvents.OnStopRoomAutoFlow, new Action(OnStopRoomAutoFlow));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents2.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			if (base.HospitalMap != null)
			{
				_navMesh = base.Level.BuildingLogic.GetRoomBuildingNavMesh(base.HospitalMap);
			}
			Validate();
		}

		public BlueprintFloorPlan(FloorPlan other)
			: base(other, null)
		{
			_requiredItems = other.Definition.GetRequiredItems().ToList();
			foreach (RoomItem item in other.Items)
			{
				foreach (RequiredItem requiredItem in _requiredItems)
				{
					if (requiredItem.Contains(item.Definition))
					{
						_requiredItems.Remove(requiredItem);
						break;
					}
				}
			}
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnStopRoomAutoFlow = (Action)Delegate.Combine(buildEvents.OnStopRoomAutoFlow, new Action(OnStopRoomAutoFlow));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents2.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			if (base.HospitalMap != null)
			{
				_navMesh = base.Level.BuildingLogic.GetRoomBuildingNavMesh(base.HospitalMap);
			}
			Validate();
		}

		public override void Destroy()
		{
			_itemsToSell.Clear();
			if (_invalidItems != null)
			{
				_invalidItems.Clear();
			}
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnStopRoomAutoFlow = (Action)Delegate.Remove(buildEvents.OnStopRoomAutoFlow, new Action(OnStopRoomAutoFlow));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents2.OnRoomItemDestroyed, new Action<RoomItem>(OnRoomItemDestroyed));
			if (_navMesh != null)
			{
				_navMesh = null;
				base.Level.BuildingLogic.ReleaseRoomBuildingNavMesh();
			}
			base.Destroy();
		}

		private void OnRoomItemDestroyed(RoomItem roomItem)
		{
			_itemsToSell.Remove(roomItem);
			if (_invalidItems != null)
			{
				_invalidItems.Remove(roomItem);
			}
		}

		private void OnStopRoomAutoFlow()
		{
			AutoFlowActive = false;
		}

		public void Validate(bool validateItems = true, bool validateWindows = true)
		{
			RecalculateWalls();
			ValidateTiles();
			if (_navMesh != null)
			{
				_navMesh.UpdateFrom(this, null, base.Level.WorldState.Anchor);
			}
			if (validateWindows)
			{
				ValidateWindows();
			}
			if (validateItems)
			{
				ValidateItems();
			}
			if (base.Level.BuildingLogic.CurrentState == BuildingLogic.State.NewRoom)
			{
				ValidRequiredItems = _requiredItems.Count == 0;
			}
			else
			{
				ValidRequiredItems = base.Door != null;
			}
			ValidateCanAfford();
			base.Level.BuildEvents.OnRoomValidityChanged.InvokeSafe(this);
		}

		public void ValidateCanAfford()
		{
			bool isNewRoom = base.Level.BuildingLogic.CurrentState == BuildingLogic.State.NewRoom;
			CanAfford = base.Level.FinanceManager.CanAfford(GameAlgorithms.CalculatePurchaseCostOfRoom(this, isNewRoom));
		}

		private void ValidateAllRoomDoors()
		{
			HospitalMap hospitalMap = base.HospitalMap;
			if (hospitalMap == null)
			{
				return;
			}
			foreach (Room allRoom in base.Level.WorldState.AllRooms)
			{
				if (allRoom.Definition.IsHospitalOrBay || allRoom.FloorPlan.HospitalMap != hospitalMap)
				{
					continue;
				}
				foreach (RoomItem door in allRoom.FloorPlan.Doors)
				{
					if (!RoomItemAlgorithms.DoorConnectsToEntrance(door, this))
					{
						_invalidItems.AddUnique(door);
					}
				}
			}
		}

		private void ValidateCorridorItemsAreReachable()
		{
			if (base.HospitalMap == null)
			{
				return;
			}
			FloorPlan floorPlan = base.HospitalMap.FloorPlan;
			base.HospitalMap.CacheArrivalDeparturePositions();
			foreach (RoomItem item in floorPlan.Items)
			{
				if (item.Interactions.Count != 0 && item.Definition.MinValidInteractions != 0)
				{
					Vector3 worldPosition = item.WorldPosition;
					if (base.WorldBounds.IsInBounds(worldPosition.ToGridCoord()) && !RoomAlgorithms.PositionConnectsToEntrance(worldPosition, base.HospitalMap, this))
					{
						_invalidItems.AddUnique(item);
					}
				}
			}
		}

		private void ValidateWallObjects()
		{
			if (_invalidItems == null)
			{
				return;
			}
			foreach (HospitalMap hospitalMap in base.WorldState.HospitalMaps)
			{
				RoomAlgorithms.FindInvalidWallItems(hospitalMap.FloorPlan, _invalidItems, this);
			}
			foreach (RoomItem item in base.Items)
			{
				if (item.Definition.ItemType != RoomItemDefinition.Type.Window || item.IsHospitalWindow)
				{
					continue;
				}
				Vector3 source = item.WorldPosition + item.GridRotation.DirectionVector() * 2f;
				GridDirection windowRotation = item.GridRotation.Rotate180();
				RoomAlgorithms.IterateRoomItemsAtCoord(base.WorldState, source.ToGridCoord(), delegate(RoomItem roomItem)
				{
					if (roomItem.Definition.ItemType != RoomItemDefinition.Type.Window && roomItem.Definition.ItemType != RoomItemDefinition.Type.SideDoor && roomItem.Definition.PlaceOnWall && roomItem.GridRotation == windowRotation)
					{
						_invalidItems.AddUnique(roomItem);
					}
				});
			}
		}

		public void ValidateTiles()
		{
			_itemsToSell.Clear();
			HospitalMap hospitalMap = base.HospitalMap;
			ValidRoomSize = RoomAlgorithms.DoesFloorPlanContainAreaOfSize(this, Definition._minSizeX, Definition._minSizeY);
			if (base.WorldState == null || hospitalMap == null)
			{
				return;
			}
			int num = Width();
			int num2 = Height();
			bool isHospitalOnly = Definition.IsHospitalOnly;
			bool bought = hospitalMap.Plot.Bought;
			bool isAmbulanceBayOnly = hospitalMap.Room.Definition.IsAmbulanceBayOnly;
			if (_tileValidity.Values == null || _tileValidity.Values.GetLength(0) != num || _tileValidity.Values.GetLength(1) != num2)
			{
				_tileValidity.Values = new bool[num, num2];
			}
			FloorPlan floorPlan = hospitalMap.FloorPlan;
			GridCoord gridCoord = base.Anchor - hospitalMap.Anchor;
			int num3 = floorPlan.Width();
			int num4 = floorPlan.Height();
			if (hospitalMap.Plot.Definition.UseEnergyUI)
			{
				ValidFloorTiles = false;
				return;
			}
			ValidFloorTiles = true;
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (!_tiles.Values[j, i])
					{
						continue;
					}
					GridCoord gridCoord2 = new GridCoord(j + gridCoord.X, i + gridCoord.Y);
					if (!MathUtils.IsInRange(gridCoord2.X, 0, num3 - 1) || !MathUtils.IsInRange(gridCoord2.Y, 0, num4 - 1) || !bought || isAmbulanceBayOnly)
					{
						_tileValidity.Values[j, i] = false;
					}
					else if (isHospitalOnly)
					{
						_tileValidity.Values[j, i] = true;
					}
					else
					{
						GridCoord gridCoord3 = new GridCoord(base.Anchor.X + j, base.Anchor.Y + i);
						bool flag = floorPlan[gridCoord2];
						bool flag2 = hospitalMap.WorldRooms[gridCoord2.X, gridCoord2.Y] != null;
						bool flag3 = RoomAlgorithms.DoorExitAtWorldPosition(base.WorldState, gridCoord3, hospitalMap) != null;
						bool flag4 = RoomAlgorithms.ServingHatchAtWorldPosition(base.WorldState, gridCoord3, hospitalMap) != null;
						bool flag5 = false;
						List<RoomItem> itemsAtCoord = floorPlan.GetItemsAtCoord(gridCoord2);
						if (itemsAtCoord != null)
						{
							foreach (RoomItem item in itemsAtCoord)
							{
								if (item.Definition.HasCollision)
								{
									if (item.Interactions.Count != 0)
									{
										_validStartLocations.Clear();
										foreach (ObjectInteraction interaction in item.Interactions)
										{
											if (interaction.ValidStartPosition && interaction.WorldStartPosition.ToGridCoord() != gridCoord3)
											{
												_validStartLocations.AddUnique(interaction.StartSocketName);
											}
										}
										if (_validStartLocations.Count < item.Definition.MinValidInteractions)
										{
											if (!CanBeSoldWhenBuiltOver(item))
											{
												flag5 = true;
												break;
											}
											_itemsToSell.AddUnique(item);
										}
									}
									if (flag5)
									{
										continue;
									}
									foreach (ConvexPolygon worldSpaceSolidAndNonSolidShape in item.WorldSpaceSolidAndNonSolidShapes)
									{
										foreach (Vector2 point in worldSpaceSolidAndNonSolidShape.Points)
										{
											if (new Vector3(point.x, 0f, point.y).ToGridCoord() == gridCoord3)
											{
												if (!CanBeSoldWhenBuiltOver(item))
												{
													flag5 = true;
													break;
												}
												_itemsToSell.AddUnique(item);
											}
										}
									}
								}
								else if (CanBeSoldWhenBuiltOver(item))
								{
									_itemsToSell.AddUnique(item);
								}
							}
						}
						_tileValidity.Values[j, i] = flag && !flag2 && !flag5 && !flag3 && !flag4;
					}
					ValidFloorTiles &= _tileValidity.Values[j, i];
				}
			}
		}

		private bool CanBeSoldWhenBuiltOver(RoomItem item)
		{
			if (!item.Definition.CanBeSoldWhenBuiltOver())
			{
				return false;
			}
			if (Definition.IsRequiredItem(item.Definition))
			{
				bool result = false;
				{
					foreach (RoomItem item2 in base.Items)
					{
						if (item2 != item && item2.Definition == item.Definition && item2.IsValid)
						{
							result = true;
						}
					}
					return result;
				}
			}
			return true;
		}

		private void ValidateItems()
		{
			_invalidItems = RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, null, this, base.WorldState, base.Level.FinanceManager, (_navMesh != null && _navMesh.Built) ? _navMesh : null);
			ValidateAllRoomDoors();
			ValidateWallObjects();
			SellInvalidWindows();
			ValidateCorridorItemsAreReachable();
			MoveInvalidItemsToSellList(_invalidItems);
			ValidRoomItems = _invalidItems.Count == 0;
		}

		private void SellInvalidWindows()
		{
			foreach (RoomItem item in base.Items)
			{
				if (!item.IsValid && item.Definition.ItemType == RoomItemDefinition.Type.Window && !_hospitalWindows.Contains(item))
				{
					_itemsToSell.Add(item);
					_invalidItems.Remove(item);
				}
			}
		}

		public void MoveInvalidItemsToSellList(List<RoomItem> invalidItems)
		{
			for (int num = invalidItems.Count - 1; num >= 0; num--)
			{
				RoomItem item = invalidItems[num];
				if (CanBeSoldWhenBuiltOver(item))
				{
					invalidItems.Remove(item);
					_itemsToSell.AddUnique(item);
				}
			}
		}

		public override void AddItem(RoomItem item)
		{
			base.AddItem(item);
			foreach (RequiredItem requiredItem in _requiredItems)
			{
				if (requiredItem.Contains(item.Definition))
				{
					_requiredItems.Remove(requiredItem);
					break;
				}
			}
			Validate();
		}

		public override void RemoveItem(RoomItem removedItem)
		{
			base.RemoveItem(removedItem);
			RequiredItem requiredItem = Definition.GetRequiredItem(removedItem.Definition);
			if (requiredItem != null && !base.Items.Any((RoomItem item) => requiredItem.Contains(item.Definition)))
			{
				_requiredItems.AddUnique(requiredItem);
			}
			Validate();
		}

		public void RemoveItemToSell(RoomItem item)
		{
			_itemsToSell.Remove(item);
		}

		public override void SetHospitalMap(HospitalMap hospitalMap)
		{
			if (hospitalMap != base.HospitalMap)
			{
				if (_navMesh != null)
				{
					_navMesh = null;
					base.Level.BuildingLogic.ReleaseRoomBuildingNavMesh();
				}
				if (hospitalMap != null)
				{
					_navMesh = base.Level.BuildingLogic.GetRoomBuildingNavMesh(hospitalMap);
				}
			}
			base.SetHospitalMap(hospitalMap);
		}

		public void StartDrag()
		{
			_dragStartTiles = base.Tiles;
			_dragStartAnchor = base.Anchor;
		}

		public void AddDragRect(GridCoord start, GridCoord end, bool subtract)
		{
			UpdateAnchor(_dragStartAnchor);
			base.Tiles = _dragStartTiles;
			RoomAlgorithms.AddDragRectToRoomArea(this, start, end, subtract);
		}

		public void EndDrag()
		{
			UpdateAnchor(_dragStartAnchor);
			base.Tiles = _dragStartTiles;
			_dragStartTiles = null;
		}

		public void RebuildNavMesh()
		{
			if (_navMesh != null)
			{
				_navMesh.RebuildFrom(this, null, base.Level.WorldState.Anchor);
			}
		}
	}
}
