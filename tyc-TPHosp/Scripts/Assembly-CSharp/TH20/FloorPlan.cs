using System;
using System.Collections.Generic;
using FullSerializerSave;
using UnityEngine;

namespace TH20
{
	public class FloorPlan : MustCallDestroy, fsISerializationCallbacks
	{
		protected BoolArray2D _tiles;

		private int _tileCount;

		[DontSave]
		private List<RoomItem>[,] _itemTileMap;

		[DontSave]
		private List<RoomItem>[,] _itemCollisionTileMap;

		private GridCoord _anchor;

		public RoomDefinition Definition;

		public List<WallCoord> Walls;

		private readonly Level _level;

		private readonly List<RoomItem> _items = new List<RoomItem>();

		[DontSave]
		private List<LandscapeRoomItem> _landscapeItems = new List<LandscapeRoomItem>();

		private RoomItem _door;

		private readonly List<RoomItem> _doors = new List<RoomItem>();

		private readonly List<RoomItem> _servingHatches = new List<RoomItem>();

		private readonly List<RoomItem> _queueItems = new List<RoomItem>();

		public readonly List<RoomItem> _hospitalWindows = new List<RoomItem>();

		public WorldState WorldState => _level.WorldState;

		public HospitalMap HospitalMap { get; private set; }

		public Room OwningRoom { get; set; }

		public int MaxCapacity { get; set; }

		public GridBounds WorldBounds { get; private set; }

		public GridCoord Anchor
		{
			get
			{
				return _anchor;
			}
			set
			{
				_anchor = value;
				RecalculateBounds();
				SetItemsCollisionDirty();
			}
		}

		public bool this[int x, int y]
		{
			get
			{
				return _tiles.Values[x, y];
			}
			set
			{
				_tiles.Values[x, y] = value;
			}
		}

		public bool this[GridCoord coord]
		{
			get
			{
				return _tiles.Values[coord.X, coord.Y];
			}
			set
			{
				_tiles.Values[coord.X, coord.Y] = value;
			}
		}

		public List<RoomItem> Items => _items;

		public List<LandscapeRoomItem> LandscapeItems => _landscapeItems;

		public RoomItem Door => _door;

		public List<RoomItem> Doors => _doors;

		public List<RoomItem> ServingHatches => _servingHatches;

		public bool[,] Tiles
		{
			get
			{
				return _tiles.Values;
			}
			set
			{
				_tiles.Values = value;
				RefreshItemTileMap();
				RecalculateBounds();
				CountFloorTiles();
			}
		}

		protected Level Level => _level;

		public int TileCount
		{
			get
			{
				if (Definition != null && Definition.IsHospitalOrBay && HospitalMap != null && HospitalMap.CorridorFloorPlan != null)
				{
					return HospitalMap.CorridorFloorPlan.TileCount;
				}
				return _tileCount;
			}
		}

		public List<RoomItem> QueueItems => _queueItems;

		public bool HasValidRequiredItems { get; private set; }

		public bool ValidCoord(int x, int y)
		{
			return _tiles.Values.ValidIndex(x, y);
		}

		public bool ValidCoord(GridCoord localCoord)
		{
			return _tiles.Values.ValidIndex(localCoord.X, localCoord.Y);
		}

		public FloorPlan(Level level)
		{
			_level = level;
			RecalculateBounds();
		}

		public override string ToString()
		{
			if (OwningRoom == null)
			{
				return Definition.ToString();
			}
			return OwningRoom.ToString();
		}

		public FloorPlan(RoomDefinition roomDefinition, Level level, HospitalMap hospitalMap)
			: this(level)
		{
			Definition = roomDefinition;
			HospitalMap = hospitalMap;
			MaxCapacity = roomDefinition._maxCapacity;
		}

		public FloorPlan(RoomTemplateFloorPlan template, Level level, HospitalMap hospitalMap)
			: this(template.Definition, level, hospitalMap)
		{
			int num = template.Width();
			int num2 = template.Height();
			_tiles = new BoolArray2D
			{
				Values = new bool[num, num2]
			};
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					_tiles.Values[j, i] = template[j, i];
				}
			}
			CreateItemTileMap();
			Anchor = template.Anchor;
			Walls = template.Walls;
			WorldBounds = template.WorldBounds;
			OwningRoom = null;
			_items = new List<RoomItem>();
			foreach (RoomTemplateItem item in template.Items)
			{
				if (item.Definition != null)
				{
					RoomItemDefinition instance = item.Definition.Instance;
					if (!instance.IsExcludedFromGameMode(_level) && !template.DLCItemsToRemove.Contains(item) && !template.InLevelItemsToRemove.Contains(item))
					{
						RoomItem roomItem = new RoomItem(instance, this, _level)
						{
							Rotation = item.Rotation,
							LocalPosition = item.Position
						};
						AddItemInternal(roomItem);
						if (item.IsHospitalWindow)
						{
							_hospitalWindows.Add(roomItem);
							roomItem.IsHospitalWindow = true;
						}
					}
				}
				else if (item.UGCDefinition != null)
				{
					RoomItemDefinitionUGC uGCDefinition = item.UGCDefinition;
					_level.UGCDefinitionsFixUp.AddRoomItem(uGCDefinition);
					RoomItem roomItem2 = new RoomItem(uGCDefinition, this, _level)
					{
						Rotation = item.Rotation,
						LocalPosition = item.Position
					};
					AddItemInternal(roomItem2);
					if (item.IsHospitalWindow)
					{
						_hospitalWindows.Add(roomItem2);
						roomItem2.IsHospitalWindow = true;
					}
				}
			}
			CountFloorTiles();
		}

		public FloorPlan(FloorPlan other, Room owningRoom)
			: this(other.Definition, other._level, other.HospitalMap)
		{
			int num = other.Width();
			int num2 = other.Height();
			_tiles = new BoolArray2D
			{
				Values = new bool[num, num2]
			};
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					_tiles.Values[j, i] = other[j, i];
				}
			}
			CreateItemTileMap();
			Anchor = other.Anchor;
			Walls = other.Walls;
			WorldBounds = other.WorldBounds;
			OwningRoom = owningRoom;
			_items = new List<RoomItem>();
			for (int k = 0; k < other._items.Count; k++)
			{
				RoomItem roomItem = other._items[k];
				RoomItem roomItem2 = new RoomItem(roomItem, this);
				AddItemInternal(roomItem2);
				if (roomItem.IsHospitalWindow)
				{
					_hospitalWindows.Add(roomItem2);
					roomItem2.IsHospitalWindow = true;
				}
			}
			CountFloorTiles();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_landscapeItems = new List<LandscapeRoomItem>();
			foreach (RoomItem item in _items)
			{
				item.RestoreFromSave();
			}
			int num;
			if (Definition != null && !Definition.IsHospitalOrBay)
			{
				num = ((!Definition.IsHospitalUnbuilt) ? 1 : 0);
				if (num != 0)
				{
					GridCoord anchor = Anchor;
					bool[,] tiles = ((Tiles == null) ? null : (Tiles.Clone() as bool[,]));
					if (RoomAlgorithms.CropEmptyCells(ref tiles, ref anchor))
					{
						UpdateAnchor(anchor);
						Tiles = tiles;
					}
				}
			}
			else
			{
				num = 0;
			}
			RefreshItemTileMap();
			if (num != 0)
			{
				RecalculateWalls();
			}
		}

		void fsISerializationCallbacks.OnBeforeSerialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnBeforeSerializeInstance(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnAfterSerialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterSerializeInstance(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserializeInstance(Type storageType)
		{
		}

		private void RefreshItemTileMap()
		{
			CreateItemTileMap();
			for (int i = 0; i < _items.Count; i++)
			{
				AddItemToTileMap(_items[i]);
			}
		}

		public void CountFloorTiles()
		{
			_tileCount = 0;
			RoomAlgorithms.IterateAllRoomTiles(this, delegate(int x, int y, bool occupied)
			{
				if (occupied)
				{
					_tileCount++;
				}
			});
		}

		private void CreateItemTileMap()
		{
			int num = Width();
			int num2 = Height();
			_itemTileMap = new List<RoomItem>[num, num2];
			_itemCollisionTileMap = new List<RoomItem>[num, num2];
		}

		public void RecalculateBounds()
		{
			List<WallCoord> list = ((Definition != null && Definition.IsHospitalOrBay && HospitalMap != null) ? HospitalMap.ExternalWalls : Walls);
			if (list != null && list.Count != 0)
			{
				GridBounds worldBounds = new GridBounds(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
				foreach (WallCoord item in list)
				{
					worldBounds.Encapsulate(_anchor + item._position);
				}
				WorldBounds = worldBounds;
			}
			else if (HasNoExteriorWalls() && HospitalMap != null)
			{
				GridBounds worldBounds2 = new GridBounds(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
				for (int i = 0; i < HospitalMap.Height; i++)
				{
					for (int j = 0; j < HospitalMap.Width; j++)
					{
						if (HospitalMap.IndoorState[j, i])
						{
							worldBounds2.Encapsulate(_anchor + new GridCoord(j, i));
						}
					}
				}
				worldBounds2.Grow(2);
				WorldBounds = worldBounds2;
			}
			else
			{
				WorldBounds = new GridBounds(_anchor.X, _anchor.Y, _anchor.X + Width(), _anchor.Y + Height());
			}
		}

		private void SetItemsCollisionDirty()
		{
			foreach (RoomItem item in Items)
			{
				item.CollisionDirty = true;
			}
		}

		private void AddItemToTileMap(RoomItem item)
		{
			GridBounds[] tileBounds = item.GetTileBounds();
			bool hasCollision = item.Definition.HasCollision;
			for (int i = 0; i < tileBounds.Length; i++)
			{
				GridBounds gridBounds = tileBounds[i];
				for (int j = gridBounds.Min.Y; j < gridBounds.Max.Y; j++)
				{
					for (int k = gridBounds.Min.X; k < gridBounds.Max.X; k++)
					{
						if (!ValidCoord(k, j))
						{
							continue;
						}
						if (_itemTileMap[k, j] == null)
						{
							_itemTileMap[k, j] = new List<RoomItem>();
						}
						_itemTileMap[k, j].Add(item);
						if (hasCollision)
						{
							if (_itemCollisionTileMap[k, j] == null)
							{
								_itemCollisionTileMap[k, j] = new List<RoomItem>();
							}
							_itemCollisionTileMap[k, j].Add(item);
						}
					}
				}
			}
		}

		private void RemoveItemFromTileMap(RoomItem item, bool silent = false)
		{
			if (OwningRoom == null)
			{
				Definition.ToString();
			}
			else
			{
				OwningRoom.ToString();
			}
			if (item.FloorPlan != this)
			{
				if (item.FloorPlan.OwningRoom == null)
				{
					Definition.ToString();
				}
				else
				{
					item.FloorPlan.OwningRoom.ToString();
				}
			}
			GridBounds[] tileBounds = item.GetTileBounds();
			bool hasCollision = item.Definition.HasCollision;
			for (int i = 0; i < tileBounds.Length; i++)
			{
				GridBounds gridBounds = tileBounds[i];
				for (int j = gridBounds.Min.Y; j < gridBounds.Max.Y; j++)
				{
					for (int k = gridBounds.Min.X; k < gridBounds.Max.X; k++)
					{
						if (!ValidCoord(k, j))
						{
							continue;
						}
						if (_itemTileMap[k, j] != null)
						{
							_itemTileMap[k, j].Remove(item);
							if (_itemTileMap[k, j].Count == 0)
							{
								_itemTileMap[k, j] = null;
							}
						}
						if (hasCollision && _itemCollisionTileMap[k, j] != null)
						{
							_itemCollisionTileMap[k, j].Remove(item);
							if (_itemCollisionTileMap[k, j].Count == 0)
							{
								_itemCollisionTileMap[k, j] = null;
							}
						}
					}
				}
			}
		}

		public override void Destroy()
		{
			if (_items.Count == 0)
			{
				if (_door != null)
				{
					_door.Destroy();
					_door = null;
				}
				_hospitalWindows.ClearAndCallDestroy();
			}
			_door = null;
			_doors.Clear();
			_servingHatches.Clear();
			_hospitalWindows.Clear();
			_queueItems.Clear();
			_items.ClearAndCallDestroy();
			_landscapeItems.ClearAndCallDestroy();
			base.Destroy();
		}

		public int Width()
		{
			if (_tiles.Values == null)
			{
				return 0;
			}
			return _tiles.Values.GetLength(0);
		}

		public int Height()
		{
			if (_tiles.Values == null)
			{
				return 0;
			}
			return _tiles.Values.GetLength(1);
		}

		public void Invert()
		{
			for (int i = 0; i < Height(); i++)
			{
				for (int j = 0; j < Width(); j++)
				{
					ref bool reference = ref _tiles.Values[j, i];
					reference = !reference;
				}
			}
		}

		public bool IsTileFree(int x, int y)
		{
			if (this[x, y])
			{
				return _itemCollisionTileMap[x, y] == null;
			}
			return false;
		}

		public List<RoomItem> GetItemsAtCoord(GridCoord localCoord)
		{
			return ArrayUtils.Get(_itemTileMap, localCoord.X, localCoord.Y, null);
		}

		public List<RoomItem> GetCollisionItemsAtCoord(GridCoord localCoord)
		{
			return ArrayUtils.Get(_itemCollisionTileMap, localCoord.X, localCoord.Y, null);
		}

		public virtual void AddItem(RoomItem item)
		{
			AddItemInternal(item);
		}

		public int GetNumPlacedItems()
		{
			int num = 0;
			foreach (RoomItem item in _items)
			{
				if (item.Cost > 0)
				{
					num++;
				}
			}
			return num;
		}

		public void AddItemNoValidation(RoomItem item)
		{
			AddItemInternal(item);
		}

		private void AddItemInternal(RoomItem item)
		{
			if (item is LandscapeRoomItem landscapeRoomItem)
			{
				_landscapeItems.Add(landscapeRoomItem);
				landscapeRoomItem.AddToWorld(updateNavigation: false);
				return;
			}
			_items.Add(item);
			if (HospitalMap != null && HospitalMap.Plot != null)
			{
				item.IsInBoughtPlot = HospitalMap.Plot.Bought;
			}
			AddItemToTileMap(item);
			if (item.Definition.ItemType == RoomItemDefinition.Type.Door || item.Definition.ItemType == RoomItemDefinition.Type.SideDoor)
			{
				_doors.Add(item);
				if (item.Definition.ItemType == RoomItemDefinition.Type.Door)
				{
					_door = item;
				}
			}
			else if (item.Definition.ItemType == RoomItemDefinition.Type.ServingHatch)
			{
				_servingHatches.Add(item);
			}
			if (item.Definition.ShowQueuePositions)
			{
				_queueItems.Add(item);
			}
			UpdateHasValidRequiredItems();
		}

		public virtual void RemoveItem(RoomItem item)
		{
			RemoveItemInternal(item);
		}

		public void RemoveItemNoValidation(RoomItem item)
		{
			RemoveItemInternal(item, silent: true);
		}

		private void RemoveItemInternal(RoomItem item, bool silent = false)
		{
			if (item is LandscapeRoomItem landscapeRoomItem)
			{
				_landscapeItems.Remove(landscapeRoomItem);
				landscapeRoomItem.RemoveFromWorld(updateNavigation: false);
				return;
			}
			_items.Remove(item);
			RemoveItemFromTileMap(item, silent);
			if (item.Definition.ItemType == RoomItemDefinition.Type.Door || item.Definition.ItemType == RoomItemDefinition.Type.SideDoor)
			{
				_doors.Remove(item);
				if (item.Definition.ItemType == RoomItemDefinition.Type.Door)
				{
					_door = null;
				}
			}
			else if (item.Definition.ItemType == RoomItemDefinition.Type.ServingHatch)
			{
				_servingHatches.Remove(item);
			}
			if (item.Definition.ShowQueuePositions)
			{
				_queueItems.Remove(item);
			}
			UpdateHasValidRequiredItems();
		}

		public void UpdateHasValidRequiredItems()
		{
			HasValidRequiredItems = true;
			if (Definition == null || Definition._requiredItemsNew == null)
			{
				return;
			}
			RequiredItem[] requiredItemsNew = Definition._requiredItemsNew;
			foreach (RequiredItem requiredItem in requiredItemsNew)
			{
				RoomItem roomItem = null;
				foreach (RoomItem item in _items)
				{
					if (item.IsValid && requiredItem.Contains(item.Definition))
					{
						roomItem = item;
						break;
					}
				}
				if (roomItem == null)
				{
					HasValidRequiredItems = false;
					break;
				}
			}
		}

		private void AddHospitalWindow(RoomItem item)
		{
			AddItemInternal(item);
			_hospitalWindows.Add(item);
			item.IsHospitalWindow = true;
			item.HasBeenPurchased = true;
		}

		private void RemoveAllHospitalWindows()
		{
			foreach (RoomItem hospitalWindow in _hospitalWindows)
			{
				RemoveItemInternal(hospitalWindow);
				if (hospitalWindow.Visual != null)
				{
					hospitalWindow.Visual.Destroy();
				}
				hospitalWindow.Destroy();
			}
			_hospitalWindows.Clear();
		}

		public void RecalculateWalls()
		{
			GridDirection bayWallOverride = HospitalMap?.Plot?.Definition.AmbulanceBayEntranceSide ?? GridDirection.Max;
			Walls = RoomAlgorithms.CalculateWalls(this, new GridBounds(0, 0, Width(), Height()), null, bayWallOverride);
			RecalculateBounds();
		}

		public void UpdateAnchor(GridCoord newAnchor)
		{
			Vector3 vector = GridCoord.GridCoordToWorldPosition(Anchor - newAnchor);
			if (vector.sqrMagnitude > 0f)
			{
				foreach (RoomItem item in _items)
				{
					item.LocalPosition += vector;
				}
				if (Walls != null)
				{
					GridCoord gridCoord = vector.ToGridCoord();
					foreach (WallCoord wall in Walls)
					{
						wall._position += gridCoord;
					}
				}
			}
			Anchor = newAnchor;
		}

		public Vector3 GetAnchorWorldPos()
		{
			return Anchor.ToWorldPosition();
		}

		public void IterateWallsAtLocalCoord(GridCoord localCoord, Action<WallCoord> callback)
		{
			if (Walls == null)
			{
				return;
			}
			foreach (WallCoord wall in Walls)
			{
				if (!wall.IsCorner() && wall._position == localCoord)
				{
					callback(wall);
				}
			}
		}

		public bool AnyWallAtLocalCoord(GridCoord localCoord)
		{
			if (Walls != null)
			{
				foreach (WallCoord wall in Walls)
				{
					if (!wall.IsCorner() && wall._position == localCoord)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool HasAnyTiles()
		{
			if (_tiles.Values != null)
			{
				bool[,] values = _tiles.Values;
				int upperBound = values.GetUpperBound(0);
				int upperBound2 = values.GetUpperBound(1);
				for (int i = values.GetLowerBound(0); i <= upperBound; i++)
				{
					for (int j = values.GetLowerBound(1); j <= upperBound2; j++)
					{
						if (values[i, j])
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public RoomItem GetFirstItemOfType(RoomItemDefinition.Type type)
		{
			for (int i = 0; i < _items.Count; i++)
			{
				RoomItem roomItem = _items[i];
				if (roomItem.Definition.ItemType == type)
				{
					return roomItem;
				}
			}
			return null;
		}

		public RoomItem GetFirstItemOfType(RoomItemDefinition definition)
		{
			for (int i = 0; i < _items.Count; i++)
			{
				RoomItem roomItem = _items[i];
				if (roomItem.Definition == definition)
				{
					return roomItem;
				}
			}
			return null;
		}

		public void AddItemsToWorld(bool updateNavigation = true)
		{
			for (int i = 0; i < _items.Count; i++)
			{
				RoomItem roomItem = _items[i];
				roomItem.AddToWorld(updateNavigation: false);
				roomItem.EnableAttributes(enabled: true);
				WorldState.AddNeedSatisfyingRoomItem(roomItem);
			}
			if (updateNavigation)
			{
				WorldState.UpdateNavigation();
			}
		}

		public void RemoveItemsFromWorld(bool updateNavigation = true)
		{
			for (int i = 0; i < _items.Count; i++)
			{
				RoomItem roomItem = _items[i];
				roomItem.RemoveFromWorld(updateNavigation: false);
				roomItem.EnableAttributes(enabled: false);
				WorldState.RemoveNeedSatisfyingRoomItem(roomItem);
			}
			if (updateNavigation)
			{
				WorldState.UpdateNavigation();
			}
		}

		public void ValidateWindows()
		{
			RemoveAllHospitalWindows();
			IRoomItemDefinition windowDefinition = WorldState.GetRoomWindowDefinition(Definition._type);
			if (windowDefinition == null)
			{
				return;
			}
			for (int i = 0; i < Walls.Count; i++)
			{
				WallCoord wall = Walls[i];
				GridCoord worldCoord = Anchor + wall._position;
				GridCoord gridCoord = wall._rotation.DirectionCoord();
				RoomAlgorithms.IterateRoomItemsAtCoord(WorldState, worldCoord + gridCoord, delegate(RoomItem item)
				{
					if (item.Definition.ItemType == RoomItemDefinition.Type.Window && (item.Rotation + 180f).ToGridDirection() == wall._rotation && !item.IsHospitalWindow)
					{
						bool flag = true;
						List<RoomItem> itemsAtCoord = GetItemsAtCoord(worldCoord - Anchor);
						if (itemsAtCoord != null)
						{
							foreach (RoomItem item3 in itemsAtCoord)
							{
								if (item3.Definition.ItemType == RoomItemDefinition.Type.Window && item3.Rotation.ToGridDirection() == wall._rotation)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag)
						{
							RoomItem item2 = new RoomItem(windowDefinition, this, _level)
							{
								Rotation = wall._rotation.YawRotation(),
								LocalPosition = wall._position.ToWorldPosition()
							};
							AddHospitalWindow(item2);
						}
					}
				});
			}
		}

		public virtual void SetHospitalMap(HospitalMap hospitalMap)
		{
			HospitalMap = hospitalMap;
		}

		public bool HasNoExteriorWalls()
		{
			RoomDefinition definition = Definition;
			if (definition == null)
			{
				return false;
			}
			return definition._wallsExterior?.NoExternalWalls == true;
		}

		public bool HasNoInteriorWalls()
		{
			RoomDefinition definition = Definition;
			if (definition == null)
			{
				return false;
			}
			return definition._wallsInterior?.NoExternalWalls == true;
		}

		public bool HasNoVisibleExteriorWalls()
		{
			RoomDefinition definition = Definition;
			if (definition == null || definition._wallsExterior?.NoExternalWalls != true)
			{
				RoomDefinition definition2 = Definition;
				if (definition2 == null)
				{
					return false;
				}
				return definition2._wallsExterior?.InvisibleWalls == true;
			}
			return true;
		}

		public void DisableItemEffects()
		{
			foreach (RoomItem item in Items)
			{
				item.GetComponent<DebrisEffectSaveLoadFixComponent>()?.DisableEffects();
			}
		}
	}
}
