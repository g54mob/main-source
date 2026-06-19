#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public static class RoomAlgorithms
	{
		public abstract class FreeTileDelegateParams
		{
			public abstract void Clear();
		}

		public delegate bool FreeTileDelegate(int localX, int localY, FreeTileDelegateParams param);

		private class FindNearestFreeTileParams : FreeTileDelegateParams
		{
			public FloorPlan FloorPlan;

			public HospitalMap HospitalMap;

			public Vector3 Position;

			public bool FoundTile;

			public override void Clear()
			{
				FloorPlan = null;
				HospitalMap = null;
			}
		}

		public delegate void EvaluateTileDelegate(int x, int y, bool free);

		private static readonly GridCoord[] FloorTestOffsets = new GridCoord[8]
		{
			new GridCoord(0, -1),
			new GridCoord(0, 1),
			new GridCoord(-1, 0),
			new GridCoord(1, 0),
			new GridCoord(-1, -1),
			new GridCoord(1, -1),
			new GridCoord(-1, 1),
			new GridCoord(1, 1)
		};

		private static int _maxTileX;

		private static int _maxTileY;

		private static bool _isEdgeTile;

		private const int InvalidLabel = int.MaxValue;

		private static readonly int[] ConnectedComponentNeighbourLabelsCache = new int[4];

		private static int[,] _connectedComponentLabelsCache = new int[0, 0];

		private static FindNearestFreeTileParams _findNearestFreeTileParams = new FindNearestFreeTileParams();

		private static List<GridCoord> _randomTileCache = new List<GridCoord>();

		private static List<GridCoord> _randomFreeTileCache = new List<GridCoord>();

		private static bool[,] _tileCache;

		private static Stack<GridCoord> _stackCache = new Stack<GridCoord>(256);

		private static bool IsFloorTile(FloorPlan floorPlan, HospitalMap map, int x, int y)
		{
			_isEdgeTile = false;
			if (map == null || (!map.FloorPlan.HasNoExteriorWalls() && !map.FloorPlan.HasNoInteriorWalls()))
			{
				return floorPlan[x, y];
			}
			GridCoord gridCoord = floorPlan.Anchor + new GridCoord(x, y);
			Room roomAtWorldCoord = map.GetRoomAtWorldCoord(gridCoord, includeHospital: false);
			if (floorPlan[x, y] && roomAtWorldCoord != null && roomAtWorldCoord.Definition.HasExteriorWalls())
			{
				return true;
			}
			if (!map.IndoorState[x, y] || floorPlan[x, y])
			{
				GridCoord[] floorTestOffsets = FloorTestOffsets;
				foreach (GridCoord gridCoord2 in floorTestOffsets)
				{
					GridCoord worldCoord = gridCoord + gridCoord2;
					Room roomAtWorldCoord2 = map.GetRoomAtWorldCoord(worldCoord, includeHospital: false);
					if (roomAtWorldCoord2 != null && roomAtWorldCoord2.Definition.HasExteriorWalls())
					{
						_isEdgeTile = true;
						return true;
					}
				}
			}
			return false;
		}

		private static bool TestFloorTile(FloorPlan floorPlan, HospitalMap map, int x, int y, ref bool u, ref bool d, ref bool l, ref bool r, ref bool ul, ref bool ur, ref bool bl, ref bool br)
		{
			if (IsFloorTile(floorPlan, map, x, y))
			{
				u = y > 0 && floorPlan[x, y - 1];
				d = y < _maxTileY - 1 && floorPlan[x, y + 1];
				l = x > 0 && floorPlan[x - 1, y];
				r = x < _maxTileX - 1 && floorPlan[x + 1, y];
				ul = x > 0 && y > 0 && floorPlan[x - 1, y - 1];
				ur = x < _maxTileX - 1 && y > 0 && floorPlan[x + 1, y - 1];
				bl = x > 0 && y < _maxTileY - 1 && floorPlan[x - 1, y + 1];
				br = x < _maxTileX - 1 && y < _maxTileY - 1 && floorPlan[x + 1, y + 1];
				if (_isEdgeTile)
				{
					u |= y > 0 && !map.IndoorState[x, y - 1];
					d |= y < _maxTileY - 1 && !map.IndoorState[x, y + 1];
					l |= x > 0 && !map.IndoorState[x - 1, y];
					r |= x < _maxTileX - 1 && !map.IndoorState[x + 1, y];
					ul |= x > 0 && y > 0 && !map.IndoorState[x - 1, y - 1];
					ur |= x < _maxTileX - 1 && y > 0 && !map.IndoorState[x + 1, y - 1];
					bl |= x > 0 && y < _maxTileY - 1 && !map.IndoorState[x - 1, y + 1];
					br |= x < _maxTileX - 1 && y < _maxTileY - 1 && !map.IndoorState[x + 1, y + 1];
				}
				return true;
			}
			return false;
		}

		public static List<WallCoord> CalculateWalls(FloorPlan floorPlan, GridBounds recalcBounds, HospitalMap map = null, GridDirection bayWallOverride = GridDirection.Max)
		{
			List<WallCoord> list = new List<WallCoord>();
			RoomDefinition definition = floorPlan.Definition;
			bool u = false;
			bool d = false;
			bool l = false;
			bool r = false;
			bool ul = false;
			bool ur = false;
			bool bl = false;
			bool br = false;
			_maxTileX = floorPlan.Width();
			_maxTileY = floorPlan.Height();
			for (int i = 0; i < _maxTileY; i++)
			{
				for (int j = 0; j < _maxTileX; j++)
				{
					GridCoord gridCoord = new GridCoord(j, i);
					if (recalcBounds.IsInBounds(gridCoord) && TestFloorTile(floorPlan, map, j, i, ref u, ref d, ref l, ref r, ref ul, ref ur, ref bl, ref br))
					{
						if (!u && !l)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.NegX,
								_type = RoomWallDefinition.Type.CornerInner
							});
						}
						if (!u && !r)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.NegY,
								_type = RoomWallDefinition.Type.CornerInner
							});
						}
						if (!d && !r)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.PosX,
								_type = RoomWallDefinition.Type.CornerInner
							});
						}
						if (!d && !l)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.PosY,
								_type = RoomWallDefinition.Type.CornerInner
							});
						}
						if (u && l && !ul)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.NegX,
								_type = RoomWallDefinition.Type.CornerOuter
							});
						}
						if (u && r && !ur)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.NegY,
								_type = RoomWallDefinition.Type.CornerOuter
							});
						}
						if (d && r && !br)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.PosX,
								_type = RoomWallDefinition.Type.CornerOuter
							});
						}
						if (d && l && !bl)
						{
							list.Add(new WallCoord
							{
								_position = gridCoord,
								_rotation = GridDirection.PosY,
								_type = RoomWallDefinition.Type.CornerOuter
							});
						}
						List<RoomItem> items = floorPlan.GetItemsAtCoord(gridCoord);
						if (!u)
						{
							list.Add(CalculateWall(gridCoord, GridDirection.NegY, ref items, l, r, ul, ur, bayWallOverride));
						}
						if (!r)
						{
							list.Add(CalculateWall(gridCoord, GridDirection.PosX, ref items, u, d, ur, br, bayWallOverride));
						}
						if (!d)
						{
							list.Add(CalculateWall(gridCoord, GridDirection.PosY, ref items, r, l, br, bl, bayWallOverride));
						}
						if (!l)
						{
							list.Add(CalculateWall(gridCoord, GridDirection.NegX, ref items, d, u, bl, ul, bayWallOverride));
						}
					}
				}
			}
			if (definition != null && definition.RequiresCornerFillers())
			{
				List<WallCoord> list2 = new List<WallCoord>();
				foreach (WallCoord item in list)
				{
					if (item._type != RoomWallDefinition.Type.CornerOuter)
					{
						continue;
					}
					GridDirection gridDirection = item._rotation.RotateClockwise();
					GridDirection rotation = item._rotation;
					GridCoord gridCoord2 = item._position + gridDirection.DirectionCoord();
					GridCoord gridCoord3 = item._position + rotation.DirectionCoord();
					GridCoord gridCoord4 = gridCoord2 + gridDirection.DirectionCoord();
					foreach (WallCoord item2 in list)
					{
						if (item2 != item)
						{
							if (item2._position == gridCoord4 && item2._type == RoomWallDefinition.Type.CornerOuter)
							{
								list2.Add(new WallCoord
								{
									_position = gridCoord2,
									_rotation = item._rotation,
									_type = RoomWallDefinition.Type.FillerLeft
								});
							}
							if (item2._position == gridCoord2 && item2._type == RoomWallDefinition.Type.WallCornerRight && item2._rotation == rotation)
							{
								list2.Add(new WallCoord
								{
									_position = gridCoord2,
									_rotation = item2._rotation,
									_type = RoomWallDefinition.Type.FillerLeft
								});
							}
							if (item2._position == gridCoord3 && item2._type == RoomWallDefinition.Type.WallCornerLeft && item2._rotation == gridDirection)
							{
								list2.Add(new WallCoord
								{
									_position = gridCoord3,
									_rotation = item2._rotation,
									_type = RoomWallDefinition.Type.FillerRight
								});
							}
						}
					}
				}
				list.AddRange(list2);
			}
			return list;
		}

		private static WallCoord CalculateWall(GridCoord gridPos, GridDirection gridDirection, ref List<RoomItem> items, bool leftCell, bool rightCell, bool upLeftCell, bool upRightCell, GridDirection bayEntranceOverride = GridDirection.Max)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (items != null)
			{
				foreach (RoomItem item in items)
				{
					if (item.GridRotation == gridDirection)
					{
						flag |= item.Definition.AffectsNavigation && item.Definition.ItemType == RoomItemDefinition.Type.Door;
						flag2 |= item.Definition.ItemType == RoomItemDefinition.Type.Window;
						flag3 |= item.Definition.RemoveWalls;
					}
				}
			}
			RoomWallDefinition.Type type = ((bayEntranceOverride >= GridDirection.Max || gridDirection != bayEntranceOverride) ? GetWallType(leftCell, rightCell, upLeftCell, upRightCell, flag, flag2, flag3) : RoomWallDefinition.Type.AmbulanceBayEntrance);
			return new WallCoord
			{
				_position = gridPos,
				_rotation = gridDirection,
				_type = type
			};
		}

		private static RoomWallDefinition.Type GetWallType(bool leftCell, bool rightCell, bool upLeftCell, bool upRightCell, bool door, bool window, bool removeWalls)
		{
			RoomWallDefinition.SubType subType = RoomWallDefinition.SubType.NoCorner;
			if ((!leftCell && !rightCell) || (leftCell && upLeftCell && rightCell && upRightCell) || (leftCell && upLeftCell && !rightCell && !upRightCell) || (!leftCell && !upLeftCell && upRightCell))
			{
				subType = RoomWallDefinition.SubType.BothCorners;
			}
			else if ((rightCell && upRightCell) || (leftCell && !rightCell))
			{
				subType = RoomWallDefinition.SubType.LeftCorner;
			}
			else if ((leftCell && upLeftCell) || !leftCell)
			{
				subType = RoomWallDefinition.SubType.RightCorner;
			}
			RoomWallDefinition.Type type = RoomWallDefinition.Type.Wall;
			if (door)
			{
				type = RoomWallDefinition.Type.Door;
			}
			else if (window)
			{
				type = RoomWallDefinition.Type.Window;
			}
			else if (removeWalls)
			{
				type = RoomWallDefinition.Type.Blank;
			}
			return (RoomWallDefinition.Type)((int)type + (int)subType);
		}

		public static bool RoomHasOneContinuousRegion(bool[,] tiles)
		{
			int[,] array = CalculateConnectedComponentLabels(tiles);
			int length = tiles.GetLength(0);
			int length2 = tiles.GetLength(1);
			int num = int.MaxValue;
			for (int i = 0; i < length2; i++)
			{
				for (int j = 0; j < length; j++)
				{
					if (tiles[j, i])
					{
						if (num == int.MaxValue)
						{
							num = array[j, i];
						}
						else if (num != array[j, i])
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		public static int[,] CalculateConnectedComponentLabels(bool[,] tiles)
		{
			int num = 1;
			int length = tiles.GetLength(0);
			int length2 = tiles.GetLength(1);
			if (_connectedComponentLabelsCache.GetLength(0) < length || _connectedComponentLabelsCache.GetLength(1) < length2)
			{
				_connectedComponentLabelsCache = new int[length, length2];
			}
			int[,] connectedComponentLabelsCache = _connectedComponentLabelsCache;
			ArrayUtils.Populate(connectedComponentLabelsCache, int.MaxValue);
			DisjointSetOfInts disjointSetOfInts = new DisjointSetOfInts();
			for (int i = 0; i < length2; i++)
			{
				for (int j = 0; j < length; j++)
				{
					if (!tiles[j, i])
					{
						continue;
					}
					int[] connectedComponentNeighbourLabelsCache = ConnectedComponentNeighbourLabelsCache;
					ArrayUtils.Populate(connectedComponentNeighbourLabelsCache, int.MaxValue);
					connectedComponentNeighbourLabelsCache[0] = ((i > 0) ? connectedComponentLabelsCache[j, i - 1] : int.MaxValue);
					connectedComponentNeighbourLabelsCache[1] = ((j < length - 1) ? connectedComponentLabelsCache[j + 1, i] : int.MaxValue);
					connectedComponentNeighbourLabelsCache[2] = ((i < length2 - 1) ? connectedComponentLabelsCache[j, i + 1] : int.MaxValue);
					connectedComponentNeighbourLabelsCache[3] = ((j > 0) ? connectedComponentLabelsCache[j - 1, i] : int.MaxValue);
					int num2 = Math.Min(Math.Min(connectedComponentNeighbourLabelsCache[0], connectedComponentNeighbourLabelsCache[1]), Math.Min(connectedComponentNeighbourLabelsCache[2], connectedComponentNeighbourLabelsCache[3]));
					if (num2 == int.MaxValue)
					{
						disjointSetOfInts.MakeSet(num);
						connectedComponentLabelsCache[j, i] = num;
						num++;
						continue;
					}
					connectedComponentLabelsCache[j, i] = num2;
					for (int k = 0; k < 4; k++)
					{
						if (connectedComponentNeighbourLabelsCache[k] != int.MaxValue)
						{
							disjointSetOfInts.Union(num2, connectedComponentNeighbourLabelsCache[k]);
						}
					}
				}
			}
			for (int l = 0; l < length2; l++)
			{
				for (int m = 0; m < length; m++)
				{
					if (tiles[m, l])
					{
						connectedComponentLabelsCache[m, l] = disjointSetOfInts.Find(connectedComponentLabelsCache[m, l]);
					}
				}
			}
			return connectedComponentLabelsCache;
		}

		public static List<RoomItem> ValidateRoomItems(ItemValidateMode validateMode, GridBounds? bounds, FloorPlan floorPlan, WorldState worldState, FinanceManager financeManager, RoomBuildingNavMesh navMesh)
		{
			List<RoomItem> list = new List<RoomItem>();
			if (floorPlan.HospitalMap == null || floorPlan.HospitalMap.Plot.Bought)
			{
				foreach (RoomItem item in floorPlan.Items)
				{
					bool fullTest = !bounds.HasValue || item.MapTileBound.Intersects(bounds.Value);
					RoomItemAlgorithms.Validate(validateMode, fullTest, item, worldState, financeManager, navMesh, list);
					if (!item.IsValid)
					{
						list.AddUnique(item);
					}
				}
				if (floorPlan is BlueprintFloorPlan blueprintFloorPlan)
				{
					blueprintFloorPlan.MoveInvalidItemsToSellList(list);
				}
			}
			floorPlan.UpdateHasValidRequiredItems();
			return list;
		}

		private static void AddRectToFloorplan(ref bool[,] tiles, ref GridCoord anchor, GridCoord start, GridCoord end, bool subtract)
		{
			int num = ((tiles != null) ? tiles.GetLength(0) : 0);
			int num2 = ((tiles != null) ? tiles.GetLength(1) : 0);
			bool num3 = num == 0 && num2 == 0;
			GridCoord gridCoord = new GridCoord(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));
			GridCoord gridCoord2 = new GridCoord(Math.Max(start.X, end.X), Math.Max(start.Y, end.Y));
			GridCoord gridCoord3 = (num3 ? new GridCoord(int.MaxValue, int.MaxValue) : anchor);
			GridCoord gridCoord4 = (num3 ? new GridCoord(int.MinValue, int.MinValue) : (anchor + new GridCoord(num - 1, num2 - 1)));
			if (num3 || gridCoord.X < gridCoord3.X || gridCoord.Y < gridCoord3.Y || gridCoord2.X > gridCoord4.X || gridCoord2.Y > gridCoord4.Y)
			{
				GridCoord gridCoord5 = new GridCoord(Math.Min(gridCoord.X, gridCoord3.X), Math.Min(gridCoord.Y, gridCoord3.Y));
				GridCoord gridCoord6 = new GridCoord(Math.Max(gridCoord2.X, gridCoord4.X), Math.Max(gridCoord2.Y, gridCoord4.Y));
				bool[,] array = new bool[gridCoord6.X - gridCoord5.X + 1, gridCoord6.Y - gridCoord5.Y + 1];
				if (tiles != null)
				{
					for (int i = 0; i < num2; i++)
					{
						for (int j = 0; j < num; j++)
						{
							array[j - (gridCoord5.X - gridCoord3.X), i - (gridCoord5.Y - gridCoord3.Y)] = tiles[j, i];
						}
					}
				}
				tiles = array;
				anchor = gridCoord5;
			}
			if (tiles == null)
			{
				return;
			}
			GridCoord gridCoord7 = gridCoord - anchor;
			for (int k = 0; k < gridCoord2.Y - gridCoord.Y + 1; k++)
			{
				for (int l = 0; l < gridCoord2.X - gridCoord.X + 1; l++)
				{
					tiles[l + gridCoord7.X, k + gridCoord7.Y] = !subtract;
				}
			}
		}

		private static bool HasThinTiles(ref bool[,] tiles)
		{
			if (tiles != null)
			{
				int length = tiles.GetLength(0);
				int length2 = tiles.GetLength(1);
				for (int i = 0; i < length2; i++)
				{
					for (int j = 0; j < length; j++)
					{
						if (tiles[j, i])
						{
							bool num = (tiles.ValidIndex(j + 1, i) && tiles[j + 1, i]) || (tiles.ValidIndex(j - 1, i) && tiles[j - 1, i]);
							bool flag = (tiles.ValidIndex(j, i + 1) && tiles[j, i + 1]) || (tiles.ValidIndex(j, i - 1) && tiles[j, i - 1]);
							if (!num || !flag)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public static bool CanAddRectToRoomArea(BlueprintFloorPlan floorPlan, GridCoord start, GridCoord end, bool subtract)
		{
			GridCoord anchor = floorPlan.Anchor;
			bool[,] tiles = ((floorPlan.Tiles == null) ? null : (floorPlan.Tiles.Clone() as bool[,]));
			AddRectToFloorplan(ref tiles, ref anchor, start, end, subtract);
			if (RoomHasOneContinuousRegion(tiles))
			{
				if (floorPlan.Definition._type == RoomDefinition.Type.Reception)
				{
					return !HasThinTiles(ref tiles);
				}
				return true;
			}
			return false;
		}

		public static void AddDragRectToRoomArea(BlueprintFloorPlan floorPlan, GridCoord start, GridCoord end, bool subtract)
		{
			GridCoord anchor = floorPlan.Anchor;
			bool[,] tiles = ((floorPlan.Tiles == null) ? null : (floorPlan.Tiles.Clone() as bool[,]));
			AddRectToFloorplan(ref tiles, ref anchor, start, end, subtract);
			CropEmptyCells(ref tiles, ref anchor);
			floorPlan.UpdateAnchor(anchor);
			floorPlan.Tiles = tiles;
			floorPlan.Validate();
		}

		private static bool TilesInX(ref bool[,] tiles, int x, int h)
		{
			for (int i = 0; i < h; i++)
			{
				if (tiles[x, i])
				{
					return true;
				}
			}
			return false;
		}

		private static bool TilesInY(ref bool[,] tiles, int y, int w)
		{
			for (int i = 0; i < w; i++)
			{
				if (tiles[i, y])
				{
					return true;
				}
			}
			return false;
		}

		public static bool CropEmptyCells(ref bool[,] tiles, ref GridCoord anchor)
		{
			int length = tiles.GetLength(0);
			int length2 = tiles.GetLength(1);
			int num = 0;
			int num2 = 0;
			int num3 = length;
			int num4 = length2;
			for (int i = 0; i < length; i++)
			{
				if (TilesInX(ref tiles, i, length2))
				{
					num = i;
					break;
				}
			}
			for (int j = 0; j < length2; j++)
			{
				if (TilesInY(ref tiles, j, length))
				{
					num2 = j;
					break;
				}
			}
			for (int num5 = length - 1; num5 >= 0; num5--)
			{
				if (TilesInX(ref tiles, num5, length2))
				{
					num3 = num5 + 1;
					break;
				}
			}
			for (int num6 = length2 - 1; num6 >= 0; num6--)
			{
				if (TilesInY(ref tiles, num6, length))
				{
					num4 = num6 + 1;
					break;
				}
			}
			if (num != 0 || num2 != 0 || num3 != length || num4 != length2)
			{
				anchor.X += num;
				anchor.Y += num2;
				length = num3 - num;
				length2 = num4 - num2;
				bool[,] array = new bool[length, length2];
				for (int k = 0; k < length; k++)
				{
					for (int l = 0; l < length2; l++)
					{
						array[k, l] = tiles[k + num, l + num2];
					}
				}
				tiles = array;
				return true;
			}
			return false;
		}

		public static void AddRectToRoomArea(BlueprintFloorPlan floorPlan, GridCoord start, GridCoord end, bool subtract)
		{
			GridCoord anchor = floorPlan.Anchor;
			bool[,] tiles = ((floorPlan.Tiles == null) ? null : (floorPlan.Tiles.Clone() as bool[,]));
			AddRectToFloorplan(ref tiles, ref anchor, start, end, subtract);
			if (RoomHasOneContinuousRegion(tiles))
			{
				CropEmptyCells(ref tiles, ref anchor);
				floorPlan.UpdateAnchor(anchor);
				floorPlan.Tiles = tiles;
				floorPlan.Validate();
			}
		}

		public static bool RoomContainsCoord(FloorPlan floorPlan, GridCoord coord)
		{
			if (coord.X >= 0 && coord.Y >= 0 && coord.X < floorPlan.Width() && coord.Y < floorPlan.Height() && floorPlan[coord.X, coord.Y])
			{
				return true;
			}
			return false;
		}

		public static bool RoomContainsWorldCoord(FloorPlan floorPlan, GridCoord worldCoord)
		{
			GridCoord gridCoord = worldCoord - floorPlan.Anchor;
			if (floorPlan.ValidCoord(gridCoord.X, gridCoord.Y))
			{
				return floorPlan[gridCoord.X, gridCoord.Y];
			}
			return false;
		}

		public static bool RoomContainsWorldPosition(FloorPlan floorPlan, Vector3 worldPosition, float radius)
		{
			Vector3 source = worldPosition + new Vector3(radius, 0f, 0f);
			if (RoomContainsWorldCoord(floorPlan, source.ToGridCoord()))
			{
				return true;
			}
			Vector3 source2 = worldPosition + new Vector3(0f - radius, 0f, 0f);
			if (RoomContainsWorldCoord(floorPlan, source2.ToGridCoord()))
			{
				return true;
			}
			Vector3 source3 = worldPosition + new Vector3(0f, 0f, radius);
			if (RoomContainsWorldCoord(floorPlan, source3.ToGridCoord()))
			{
				return true;
			}
			Vector3 source4 = worldPosition + new Vector3(0f, 0f, 0f - radius);
			if (RoomContainsWorldCoord(floorPlan, source4.ToGridCoord()))
			{
				return true;
			}
			return false;
		}

		public static void IterateRoomItemsAtCoord(WorldState worldState, GridCoord worldCoord, Action<RoomItem> callback)
		{
			HospitalMap hospitalMapAtWorldPosition = worldState.GetHospitalMapAtWorldPosition(worldCoord);
			foreach (Room allRoom in worldState.AllRooms)
			{
				if (hospitalMapAtWorldPosition != null && allRoom.FloorPlan.HospitalMap != hospitalMapAtWorldPosition)
				{
					continue;
				}
				GridCoord localCoord = worldCoord - allRoom.FloorPlan.Anchor;
				List<RoomItem> itemsAtCoord = allRoom.FloorPlan.GetItemsAtCoord(localCoord);
				if (itemsAtCoord == null)
				{
					continue;
				}
				foreach (RoomItem item in itemsAtCoord)
				{
					callback(item);
				}
			}
		}

		public static void IterateTilesSpiral<T>(FloorPlan floorPlan, Vector3 worldPosition, T param, FreeTileDelegate func) where T : FreeTileDelegateParams
		{
			GridCoord gridCoord = worldPosition.ToGridCoord() - floorPlan.Anchor;
			int num = 0;
			int num2 = 0;
			int num3 = floorPlan.Width();
			int num4 = floorPlan.Height();
			int num5 = Mathf.Max(num3, num4) * Mathf.Max(num3, num4);
			for (int i = 0; i < num5; i++)
			{
				if (i != 0)
				{
					int num6 = gridCoord.X + num;
					int num7 = gridCoord.Y + num2;
					if (num6 >= 0 && num6 < num3 && num7 >= 0 && num7 < num4 && func(num6, num7, param))
					{
						break;
					}
				}
				if (Mathf.Abs(num) <= Mathf.Abs(num2) && (num != num2 || num >= 0))
				{
					num += ((num2 >= 0) ? 1 : (-1));
				}
				else
				{
					num2 += ((num < 0) ? 1 : (-1));
				}
			}
		}

		public static bool FindNearestFreeTile(FloorPlan floorPlan, Vector3 worldPosition, out Vector3 result)
		{
			_findNearestFreeTileParams.FoundTile = false;
			_findNearestFreeTileParams.FloorPlan = floorPlan;
			_findNearestFreeTileParams.Position = worldPosition;
			_findNearestFreeTileParams.HospitalMap = floorPlan.HospitalMap;
			IterateTilesSpiral(floorPlan, worldPosition, _findNearestFreeTileParams, delegate(int xp, int yp, FreeTileDelegateParams inParam)
			{
				FindNearestFreeTileParams findNearestFreeTileParams = (FindNearestFreeTileParams)inParam;
				if (!findNearestFreeTileParams.FloorPlan.IsTileFree(xp, yp))
				{
					return false;
				}
				GridCoord gridCoord = findNearestFreeTileParams.FloorPlan.Anchor + new GridCoord(xp, yp);
				findNearestFreeTileParams.Position = gridCoord.ToWorldPosition();
				if (!findNearestFreeTileParams.HospitalMap.PositionConnectsToEntrance(gridCoord))
				{
					return false;
				}
				findNearestFreeTileParams.FoundTile = true;
				return true;
			});
			_findNearestFreeTileParams.Clear();
			result = _findNearestFreeTileParams.Position;
			return _findNearestFreeTileParams.FoundTile;
		}

		public static void IterateAllRoomTiles(FloorPlan floorPlan, EvaluateTileDelegate evalDelegate)
		{
			int num = floorPlan.Height();
			int num2 = floorPlan.Width();
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					evalDelegate(j, i, floorPlan[j, i]);
				}
			}
		}

		public static void IterateFreeRoomTiles(FloorPlan floorPlan, EvaluateTileDelegate evalDelegate)
		{
			int num = floorPlan.Height();
			int num2 = floorPlan.Width();
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					evalDelegate(j, i, floorPlan.IsTileFree(j, i));
				}
			}
		}

		public static bool GetRandomFreeTile(FloorPlan floorPlan, out Vector3 worldPosition, NavMesh navMesh = null, int navArea = -1)
		{
			int num = floorPlan.Width();
			int num2 = floorPlan.Height();
			HospitalMap hospitalMap = floorPlan.HospitalMap;
			bool flag = floorPlan.Definition != null && floorPlan.Definition.IsHospitalOrBay;
			_randomTileCache.Clear();
			_randomFreeTileCache.Clear();
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (!floorPlan[j, i])
					{
						continue;
					}
					GridCoord gridCoord = new GridCoord(j, i);
					if ((!flag || hospitalMap.PositionConnectsToEntrance(gridCoord + floorPlan.Anchor)) && (navArea == -1 || navArea == 0 || navMesh == null || navMesh.GetAreaIDAtGridCoord(gridCoord + floorPlan.Anchor, AllowDistanceOffNavMesh.Allow) == navArea))
					{
						_randomTileCache.Add(gridCoord);
						if (floorPlan.IsTileFree(j, i))
						{
							_randomFreeTileCache.Add(gridCoord);
						}
					}
				}
			}
			if (_randomFreeTileCache.Count != 0)
			{
				GridCoord gridCoord2 = _randomFreeTileCache.RandomItem();
				worldPosition = (floorPlan.Anchor + gridCoord2).ToWorldPosition();
				if (!floorPlan.AnyWallAtLocalCoord(gridCoord2))
				{
					worldPosition += RandomUtils.RandomXZVector(-1f, 1f);
				}
			}
			else if (_randomTileCache.Count != 0)
			{
				GridCoord gridCoord3 = _randomTileCache.RandomItem();
				worldPosition = (floorPlan.Anchor + gridCoord3).ToWorldPosition();
				if (!floorPlan.AnyWallAtLocalCoord(gridCoord3))
				{
					worldPosition += RandomUtils.RandomXZVector(-1f, 1f);
				}
			}
			else
			{
				worldPosition = Vector3.zero;
			}
			return _randomTileCache.Count != 0;
		}

		public static bool GetRandomFreeTileWithinRadius(FloorPlan floorPlan, Vector3 worldPosition, float radius, out Vector3 worldPositionOut, NavMesh navMesh = null, int navArea = -1)
		{
			int num = floorPlan.Width();
			int num2 = floorPlan.Height();
			bool flag = floorPlan.HasNoExteriorWalls();
			GridCoord gridCoord = worldPosition.ToGridCoord() - floorPlan.Anchor;
			int num3 = (int)(radius * 0.5f);
			int num4 = MathUtils.Square(num3);
			int num5 = Mathf.Clamp(gridCoord.X - num3, 0, num - 1);
			int num6 = Mathf.Clamp(gridCoord.X + num3, 0, num - 1);
			int num7 = Mathf.Clamp(gridCoord.Y - num3, 0, num2 - 1);
			int num8 = Mathf.Clamp(gridCoord.Y + num3, 0, num2 - 1);
			_randomTileCache.Clear();
			_randomFreeTileCache.Clear();
			for (int i = num7; i <= num8; i++)
			{
				for (int j = num5; j <= num6; j++)
				{
					GridCoord gridCoord2 = new GridCoord(j, i);
					if (floorPlan[j, i] && gridCoord.DistanceSquared(gridCoord2) < num4 && (flag || navArea == -1 || navArea == 0 || navMesh == null || navMesh.GetAreaIDAtGridCoord(gridCoord2 + floorPlan.Anchor, AllowDistanceOffNavMesh.Allow) == navArea))
					{
						_randomTileCache.Add(gridCoord2);
						if (floorPlan.IsTileFree(j, i))
						{
							_randomFreeTileCache.Add(gridCoord2);
						}
					}
				}
			}
			if (_randomFreeTileCache.Count != 0)
			{
				GridCoord gridCoord3 = _randomFreeTileCache.RandomItem();
				worldPositionOut = (floorPlan.Anchor + gridCoord3).ToWorldPosition();
				if (!floorPlan.AnyWallAtLocalCoord(gridCoord3))
				{
					worldPositionOut += RandomUtils.RandomXZVector(-1f, 1f);
				}
			}
			else if (_randomTileCache.Count != 0)
			{
				GridCoord gridCoord4 = _randomTileCache.RandomItem();
				worldPositionOut = (floorPlan.Anchor + gridCoord4).ToWorldPosition();
				if (!floorPlan.AnyWallAtLocalCoord(gridCoord4))
				{
					worldPositionOut += RandomUtils.RandomXZVector(-1f, 1f);
				}
			}
			else
			{
				worldPositionOut = Vector3.zero;
			}
			return _randomTileCache.Count != 0;
		}

		private static bool AreaGreater(int w2, int h2, int w1, int h1)
		{
			if (w2 >= w1 && h2 >= h1)
			{
				return true;
			}
			if (w2 >= h1 && h2 >= w1)
			{
				return true;
			}
			return false;
		}

		private static bool ContainsArea(IList<int> histogram, int areaW, int areaH)
		{
			Stack<GridCoord> stack = new Stack<GridCoord>();
			int i;
			for (i = 0; i < histogram.Count; i++)
			{
				int x = i;
				int num = histogram[i];
				while (true)
				{
					if (stack.Count == 0 || num > stack.Peek().Y)
					{
						stack.Push(new GridCoord(x, num));
						break;
					}
					if (num >= stack.Peek().Y)
					{
						break;
					}
					GridCoord gridCoord = stack.Peek();
					if (AreaGreater(i - gridCoord.X, gridCoord.Y, areaW, areaH))
					{
						return true;
					}
					x = stack.Pop().X;
				}
			}
			foreach (GridCoord item in stack)
			{
				if (AreaGreater(i - item.X, item.Y, areaW, areaH))
				{
					return true;
				}
			}
			return false;
		}

		public static bool DoesFloorPlanContainAreaOfSize(FloorPlan floorPlan, int areaW, int areaH)
		{
			int num = floorPlan.Width();
			int num2 = floorPlan.Height();
			int[] array = new int[num2];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					if (floorPlan[i, j])
					{
						array[j]++;
					}
					else
					{
						array[j] = 0;
					}
				}
				if (ContainsArea(array, areaW, areaH))
				{
					return true;
				}
			}
			return false;
		}

		public static RoomItem DoorExitAtWorldPosition(WorldState worldState, GridCoord worldCoord, HospitalMap hospitalMap)
		{
			foreach (Room allRoom in worldState.AllRooms)
			{
				FloorPlan floorPlan = allRoom.FloorPlan;
				if (floorPlan.HospitalMap != hospitalMap)
				{
					continue;
				}
				foreach (RoomItem door in floorPlan.Doors)
				{
					GridBounds[] tileBounds = door.GetTileBounds();
					for (int i = 0; i < tileBounds.Length; i++)
					{
						GridBounds gridBounds = tileBounds[i] + floorPlan.Anchor;
						gridBounds.Max.X--;
						gridBounds.Max.Y--;
						if (gridBounds.IsInBounds(worldCoord))
						{
							return door;
						}
					}
				}
			}
			return null;
		}

		public static RoomItem ServingHatchAtWorldPosition(WorldState worldState, GridCoord coord, HospitalMap hospitalMap)
		{
			foreach (Room allRoom in worldState.AllRooms)
			{
				FloorPlan floorPlan = allRoom.FloorPlan;
				if (floorPlan.HospitalMap != hospitalMap)
				{
					continue;
				}
				foreach (RoomItem servingHatch in floorPlan.ServingHatches)
				{
					GridBounds[] tileBounds = servingHatch.GetTileBounds();
					for (int i = 0; i < tileBounds.Length; i++)
					{
						GridBounds gridBounds = tileBounds[i] + floorPlan.Anchor;
						gridBounds.Max.X--;
						gridBounds.Max.Y--;
						if (gridBounds.IsInBounds(coord))
						{
							return servingHatch;
						}
					}
				}
			}
			return null;
		}

		public static void IterateRoomItemsWithComponent<T>(Room room, Action<T> callback) where T : EntityComponent
		{
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				T component = item.GetComponent<T>();
				if (component != null)
				{
					callback.InvokeSafe(component);
				}
			}
		}

		public static List<JobDescription> GetAllJobs(Metagame metagame, WorldState worldState, StaffDefinition.Type staffType)
		{
			List<JobDescription> list = new List<JobDescription>();
			if (staffType == StaffDefinition.Type.Janitor)
			{
				list.AddUnique(new JobMaintenanceDescription
				{
					Description = JobMaintenance.JobDescription.BrokenMachine
				});
				list.AddUnique(new JobUpgradeDescription());
				list.AddUnique(new JobMaintenanceDescription
				{
					Description = JobMaintenance.JobDescription.BlockedToilet
				});
				list.AddUnique(new JobMaintenanceDescription
				{
					Description = JobMaintenance.JobDescription.OutOfStock
				});
				list.AddUnique(new JobMaintenanceDescription
				{
					Description = JobMaintenance.JobDescription.WiltedPlant
				});
				list.AddUnique(new JobMaintenanceDescription
				{
					Description = JobMaintenance.JobDescription.Litter
				});
				list.AddUnique(new JobMaintenanceDescription
				{
					Description = JobMaintenance.JobDescription.MedicalWaste
				});
				list.AddUnique(new JobGhostDescription());
				list.AddUnique(new JobFireDescription());
				list.AddUnique(new JobMaintenanceDescription
				{
					Description = JobMaintenance.JobDescription.Vehicular
				});
			}
			else
			{
				for (int i = 0; i < worldState.AvailableRooms.Count; i++)
				{
					RoomDefinition roomDefinition = worldState.AvailableRooms[i];
					if (!metagame.HasUnlocked(roomDefinition) || roomDefinition.IsHospitalOrBay || roomDefinition._type == RoomDefinition.Type.Cafe)
					{
						continue;
					}
					foreach (StaffRequired item in roomDefinition.GetRequiredStaff())
					{
						if (staffType == item.Definition._type || (item.AlternativeDefinition != null && staffType == item.AlternativeDefinition._type))
						{
							list.AddUnique(new JobRoomDescription
							{
								Room = roomDefinition,
								StaffRequired = item
							});
						}
					}
				}
				for (int j = 0; j < worldState.AvailableRoomItems.Count; j++)
				{
					IRoomItemDefinition roomItemDefinition = worldState.AvailableRoomItems[j];
					if (!metagame.HasUnlocked(roomItemDefinition))
					{
						continue;
					}
					if (!roomItemDefinition.IsAnAmbulance)
					{
						if (!RoomItemCanBePlacedInRoomAvailable(roomItemDefinition, metagame))
						{
							continue;
						}
						foreach (StaffRequired item2 in roomItemDefinition.GetRequiredStaff(includeRoomModifier: false))
						{
							if (staffType == item2.Definition._type || (item2.AlternativeDefinition != null && staffType == item2.AlternativeDefinition._type))
							{
								list.AddUnique(new JobItemDescription
								{
									ItemDefinition = roomItemDefinition,
									StaffRequired = item2
								});
							}
						}
						continue;
					}
					bool flag = false;
					foreach (HospitalPlot hospitalPlot in worldState.HospitalPlots)
					{
						if (hospitalPlot.GetRoomDefinition()._type == RoomDefinition.Type.AmbulanceBay)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						continue;
					}
					AmbulanceConfig.StaffRequirement[] staffRequirements = roomItemDefinition.BaseAmbulanceConfig.Instance.StaffRequirements;
					for (int k = 0; k < staffRequirements.Length; k++)
					{
						AmbulanceConfig.StaffRequirement staffRequirement = staffRequirements[k];
						if (staffType == staffRequirement.StaffType.Definition._type || (staffRequirement.StaffType.AlternativeDefinition != null && staffType == staffRequirement.StaffType.AlternativeDefinition._type))
						{
							list.AddUnique(new JobAmbulanceDescription
							{
								ItemDefinition = roomItemDefinition,
								StaffRequired = staffRequirement.StaffType
							});
						}
					}
				}
			}
			return list;
		}

		private static bool RoomItemCanBePlacedInRoomAvailable(IRoomItemDefinition item, Metagame metagame)
		{
			if (item.CanBePlacedInRoomTypes == null || item.CanBePlacedInRoomTypes.Length == 0)
			{
				return true;
			}
			RoomDefinition.Type[] canBePlacedInRoomTypes = item.CanBePlacedInRoomTypes;
			foreach (RoomDefinition.Type type in canBePlacedInRoomTypes)
			{
				if (type == RoomDefinition.Type.Hospital || metagame.HasUnlockedRoomOfType(type))
				{
					return true;
				}
			}
			return false;
		}

		private static void DestroyFailedItems(List<RoomItem> items)
		{
			foreach (RoomItem item in items)
			{
				if (item.Visual != null)
				{
					item.Visual.Destroy();
				}
				item.RemoveFromWorld(updateNavigation: true);
				item.FloorPlan.RemoveItem(item);
				item.Destroy();
			}
		}

		public static void MoveOverlappingItemsOutOfRoom(FloorPlan floorPlan, WorldState worldState)
		{
			List<RoomItem> itemsToMove = new List<RoomItem>();
			List<RoomItem> list = new List<RoomItem>();
			RoomFloorPlanVisual roomVisual = floorPlan.HospitalMap.RoomVisual;
			FloorPlan floorPlan2 = floorPlan.HospitalMap.FloorPlan;
			IterateFreeRoomTiles(floorPlan, delegate(int x, int y, bool free)
			{
				GridCoord worldCoord = floorPlan.Anchor + new GridCoord(x, y);
				IterateRoomItemsAtCoord(worldState, worldCoord, delegate(RoomItem item)
				{
					if (item.FloorPlan != floorPlan && item.Definition.MoveOutOfWay)
					{
						itemsToMove.AddUnique(item);
					}
				});
			});
			foreach (RoomItem item in floorPlan.Items)
			{
				if (item.Definition.IgnoreValidation && !item.Definition.HasCollision && !RoomContainsWorldCoord(floorPlan, item.WorldPosition.ToGridCoord()))
				{
					itemsToMove.AddUnique(item);
				}
			}
			foreach (RoomItem item2 in itemsToMove)
			{
				MoveItemToFloorPlan(item2, floorPlan2);
				MoveItemToRandomLocation(item2, list);
			}
			DestroyFailedItems(list);
			roomVisual?.CreateRoomItems();
		}

		public static void MoveOverlappingItemsWithItem(RoomItem item)
		{
			if (!item.Definition.HasCollision)
			{
				return;
			}
			FloorPlan floorPlan = item.FloorPlan;
			IRoomItemDefinition definition = item.Definition;
			GridBounds[] tileBounds = item.GetTileBounds();
			List<RoomItem> list = new List<RoomItem>();
			List<RoomItem> list2 = new List<RoomItem>();
			ConvexPolygon combinedCollisionShape = item.GetCombinedCollisionShape(worldSpace: true, includeSolid: true, includeNonSolid: true);
			for (int i = 0; i < tileBounds.Length; i++)
			{
				GridBounds gridBounds = tileBounds[i];
				if (definition.HasCollision && !definition.OccupyWallOnly)
				{
					gridBounds.Grow(2);
				}
				for (int j = gridBounds.Min.Y; j < gridBounds.Max.Y; j++)
				{
					for (int k = gridBounds.Min.X; k < gridBounds.Max.X; k++)
					{
						List<RoomItem> itemsAtCoord = floorPlan.GetItemsAtCoord(new GridCoord(k, j));
						if (itemsAtCoord == null)
						{
							continue;
						}
						foreach (RoomItem item2 in itemsAtCoord)
						{
							if (item2 != item && item2.Definition.MoveOutOfWay)
							{
								ConvexPolygon combinedCollisionShape2 = item2.GetCombinedCollisionShape(worldSpace: true, includeSolid: true, includeNonSolid: true);
								if (ConvexPolygon.Overlaps(combinedCollisionShape, combinedCollisionShape2))
								{
									list.AddUnique(item2);
								}
							}
						}
					}
				}
			}
			foreach (RoomItem item3 in list)
			{
				MoveItemToRandomLocation(item3, list2);
			}
			DestroyFailedItems(list2);
		}

		private static void MoveItemToRandomLocation(RoomItem item, List<RoomItem> failedItems)
		{
			FloorPlan floorPlan = item.FloorPlan;
			if (!GetRandomFreeTile(floorPlan, out var worldPosition))
			{
				failedItems.AddUnique(item);
				Logging.Warning(LogChannels.Building, "Failed to move {0} to random room location...destroying!", item);
				return;
			}
			floorPlan.RemoveItemNoValidation(item);
			item.RemoveRoomModifiers(RoomModifierCondition.All);
			item.LocalPosition = worldPosition - floorPlan.Anchor.ToWorldPosition();
			RoomItemAlgorithms.Validate(ItemValidateMode.Set, fullTest: true, item, item.Level.WorldState, null, null);
			if (item.Visual != null)
			{
				item.Visual.UpdateFrom(item, snap: true);
			}
			item.AddRoomModifiers();
			if (item.IsRepaired())
			{
				item.AddRoomModifiers(RoomModifierCondition.Maintenance);
			}
			floorPlan.AddItemNoValidation(item);
			RoomItemMaintenanceComponent component = item.GetComponent<RoomItemMaintenanceComponent>();
			if (component != null)
			{
				JobMaintenance job = component.Job;
				if (job != null)
				{
					Staff staff = job.GetStaff();
					if (staff != null)
					{
						staff.Idle();
						job.MakeAvailable();
					}
				}
			}
			if (!item.IsValid)
			{
				failedItems.AddUnique(item);
			}
		}

		public static void UpdateNeighbouringWindows(FloorPlan floorPlan, WorldState worldState)
		{
			if (floorPlan == null)
			{
				return;
			}
			List<Room> list = new List<Room>();
			foreach (RoomItem item in floorPlan.Items)
			{
				if (item.Definition.ItemType == RoomItemDefinition.Type.Window && !item.IsHospitalWindow)
				{
					Vector3 worldPosition = item.WorldPosition + item.GridRotation.DirectionVector() * 2f;
					Room roomAtWorldCoord = worldState.GetRoomAtWorldCoord(worldPosition, includeHospital: false, includeClosedPlots: false);
					if (roomAtWorldCoord != null)
					{
						list.AddUnique(roomAtWorldCoord);
					}
				}
			}
			foreach (Room item2 in list)
			{
				item2.FloorPlan.ValidateWindows();
				item2.FloorPlan.RecalculateWalls();
				if (item2.FloorPlanVisual != null)
				{
					item2.FloorPlanVisual.UpdateFromRoom(item2.FloorPlan);
				}
			}
		}

		public static void RotateFloorPlan(FloorPlan floorPlan, bool clockwise)
		{
			int num = floorPlan.Width();
			int num2 = floorPlan.Height();
			bool[,] tiles = floorPlan.Tiles;
			bool[,] array = new bool[num2, num];
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (clockwise)
					{
						array[i, num - j - 1] = tiles[j, i];
					}
					else
					{
						array[num2 - i - 1, j] = tiles[j, i];
					}
				}
			}
			floorPlan.Tiles = array;
			List<RoomItem> list = new List<RoomItem>(floorPlan.Items);
			foreach (RoomItem item in list)
			{
				floorPlan.RemoveItemNoValidation(item);
				Vector3 vector = item.LocalPosition - item.LocalCoord.ToWorldPosition();
				if (clockwise)
				{
					vector = new Vector3(vector.z, 0f, 0f - vector.x);
					vector += new GridCoord(item.LocalCoord.Y, num - item.LocalCoord.X - 1).ToWorldPosition();
				}
				else
				{
					vector = new Vector3(0f - vector.z, 0f, vector.x);
					vector += new GridCoord(num2 - item.LocalCoord.Y - 1, item.LocalCoord.X).ToWorldPosition();
				}
				item.Rotation += (clockwise ? 90 : (-90));
				item.LocalPosition = vector;
			}
			foreach (RoomItem item2 in list)
			{
				floorPlan.AddItemNoValidation(item2);
			}
			if (floorPlan.LandscapeItems.Count == 0)
			{
				return;
			}
			List<LandscapeRoomItem> list2 = new List<LandscapeRoomItem>(floorPlan.LandscapeItems);
			foreach (LandscapeRoomItem item3 in list2)
			{
				floorPlan.RemoveItemNoValidation(item3);
				Vector3 vector2 = item3.LocalPosition - item3.LocalCoord.ToWorldPosition();
				if (clockwise)
				{
					vector2 = new Vector3(vector2.z, 0f, 0f - vector2.x);
					vector2 += new GridCoord(item3.LocalCoord.Y, num - item3.LocalCoord.X - 1).ToWorldPosition();
				}
				else
				{
					vector2 = new Vector3(0f - vector2.z, 0f, vector2.x);
					vector2 += new GridCoord(num2 - item3.LocalCoord.Y - 1, item3.LocalCoord.X).ToWorldPosition();
				}
				item3.Rotation += (clockwise ? 90 : (-90));
				item3.LocalPosition = vector2;
			}
			foreach (LandscapeRoomItem item4 in list2)
			{
				floorPlan.AddItemNoValidation(item4);
			}
		}

		public static Vector3 GetRandomSpawnPositionForCharacter(FloorPlan floorPlan)
		{
			if (!GetRandomFreeTile(floorPlan, out var worldPosition))
			{
				if (floorPlan.Door != null)
				{
					return floorPlan.Door.WorldPosition;
				}
				return floorPlan.Anchor.ToWorldPosition();
			}
			return worldPosition;
		}

		public static void MoveItemToFloorPlan(RoomItem item, FloorPlan destFloorPlan)
		{
			if (item.FloorPlan == destFloorPlan)
			{
				return;
			}
			Room owningRoom = item.FloorPlan.OwningRoom;
			Room owningRoom2 = destFloorPlan.OwningRoom;
			item.FloorPlan.RemoveItem(item);
			item.FloorPlan = destFloorPlan;
			item.LocalPosition = item.WorldPosition - destFloorPlan.Anchor.ToWorldPosition();
			destFloorPlan.AddItem(item);
			if (item.Visual != null)
			{
				item.Visual.Destroy();
				item.Visual = null;
			}
			if (owningRoom == null || owningRoom2 == null)
			{
				return;
			}
			RoomItemFlammableComponent component = item.GetComponent<RoomItemFlammableComponent>();
			if (component != null)
			{
				Job job = component.Job;
				if (job != null)
				{
					owningRoom.RemoveJob(job);
					owningRoom2.AddJob(job);
				}
			}
			RoomItemMaintenanceComponent component2 = item.GetComponent<RoomItemMaintenanceComponent>();
			if (component2 != null)
			{
				JobMaintenance job2 = component2.Job;
				if (job2 != null)
				{
					owningRoom.RemoveJob(job2);
					owningRoom2.AddJob(job2);
				}
			}
		}

		public static bool PositionConnectsToEntrance(GridCoord start, HospitalMap hospitalMap, FloorPlan unbuiltRoom = null)
		{
			bool result = true;
			FloorPlan corridorFloorPlan = hospitalMap.CorridorFloorPlan;
			if (corridorFloorPlan != null)
			{
				int num = corridorFloorPlan.Width();
				int num2 = corridorFloorPlan.Height();
				if (!corridorFloorPlan.ValidCoord(start) || !corridorFloorPlan[start])
				{
					result = false;
				}
				else
				{
					if (_tileCache == null || _tileCache.GetLength(0) != num || _tileCache.GetLength(1) != num2)
					{
						_tileCache = new bool[num, num2];
					}
					_stackCache.Clear();
					if (hospitalMap.FloorPlan.HasNoExteriorWalls())
					{
						result = false;
						_stackCache.Push(start);
						corridorFloorPlan.Tiles.CopyTo(_tileCache);
						while (_stackCache.Count > 0)
						{
							GridCoord gridCoord = _stackCache.Pop();
							if (hospitalMap.GetRoomAtWorldCoord(gridCoord + hospitalMap.Anchor, includeHospital: true) == null)
							{
								result = true;
								break;
							}
							if (_tileCache[gridCoord.X, gridCoord.Y])
							{
								_tileCache[gridCoord.X, gridCoord.Y] = false;
								bool flag = true;
								if (unbuiltRoom != null)
								{
									GridCoord gridCoord2 = gridCoord + corridorFloorPlan.Anchor - unbuiltRoom.Anchor;
									flag = !unbuiltRoom.ValidCoord(gridCoord2) || !unbuiltRoom[gridCoord2];
								}
								if (flag)
								{
									_stackCache.Push(new GridCoord(gridCoord.X - 1, gridCoord.Y));
									_stackCache.Push(new GridCoord(gridCoord.X + 1, gridCoord.Y));
									_stackCache.Push(new GridCoord(gridCoord.X, gridCoord.Y - 1));
									_stackCache.Push(new GridCoord(gridCoord.X, gridCoord.Y + 1));
								}
							}
						}
					}
					else
					{
						bool hasMergedPlots = hospitalMap.HasMergedPlots;
						List<RoomItem> doors = hospitalMap.FloorPlan.Doors;
						if (hasMergedPlots)
						{
							result = false;
						}
						foreach (RoomItem item in doors)
						{
							GridCoord gridCoord3 = RoomItemAlgorithms.CalculateDoorEnter(item).ToGridCoord() - corridorFloorPlan.Anchor;
							corridorFloorPlan.Tiles.CopyTo(_tileCache);
							if (!(start != gridCoord3) || !corridorFloorPlan.ValidCoord(gridCoord3) || !corridorFloorPlan[gridCoord3])
							{
								continue;
							}
							bool flag2 = false;
							_stackCache.Push(start);
							while (_stackCache.Count > 0)
							{
								GridCoord gridCoord4 = _stackCache.Pop();
								if (gridCoord4 == gridCoord3)
								{
									flag2 = true;
									break;
								}
								if (_tileCache[gridCoord4.X, gridCoord4.Y])
								{
									_tileCache[gridCoord4.X, gridCoord4.Y] = false;
									bool flag3 = true;
									if (unbuiltRoom != null)
									{
										GridCoord gridCoord5 = gridCoord4 + corridorFloorPlan.Anchor - unbuiltRoom.Anchor;
										flag3 = !unbuiltRoom.ValidCoord(gridCoord5) || !unbuiltRoom[gridCoord5];
									}
									if (flag3)
									{
										_stackCache.Push(new GridCoord(gridCoord4.X - 1, gridCoord4.Y));
										_stackCache.Push(new GridCoord(gridCoord4.X + 1, gridCoord4.Y));
										_stackCache.Push(new GridCoord(gridCoord4.X, gridCoord4.Y - 1));
										_stackCache.Push(new GridCoord(gridCoord4.X, gridCoord4.Y + 1));
									}
								}
							}
							if (hasMergedPlots)
							{
								if (flag2)
								{
									result = true;
									break;
								}
							}
							else if (!flag2)
							{
								result = false;
								break;
							}
						}
					}
				}
			}
			return result;
		}

		public static bool PositionConnectsToEntrance(Vector3 worldPos, HospitalMap hospitalMap, FloorPlan unbuiltRoom = null)
		{
			bool result = true;
			FloorPlan corridorFloorPlan = hospitalMap.CorridorFloorPlan;
			if (corridorFloorPlan != null)
			{
				result = PositionConnectsToEntrance(worldPos.ToGridCoord() - corridorFloorPlan.Anchor, hospitalMap, unbuiltRoom);
			}
			return result;
		}

		public static RoomDefinition GetDefinitionFromType(Level level, RoomDefinition.Type type)
		{
			SharedInstance<RoomDefinition>[] rooms = level.Metagame.RoomDatabase.Instance.Rooms;
			for (int i = 0; i < rooms.Length; i++)
			{
				RoomDefinition instance = rooms[i].Instance;
				if (instance._type == type)
				{
					return instance;
				}
			}
			return null;
		}

		public static int CalculateNumberOfUpgradesForRoom(RoomDefinition definition, Metagame metagame)
		{
			int num = 0;
			RequiredItem[] requiredItems = definition.GetRequiredItems();
			for (int i = 0; i < requiredItems.Length; i++)
			{
				SharedInstance<RoomItemDefinition>[] items = requiredItems[i].Items;
				for (int j = 0; j < items.Length; j++)
				{
					SharedInstance<RoomItemUpgradeDefinition>[] upgrades = items[j].Instance.Upgrades;
					if (upgrades == null)
					{
						continue;
					}
					SharedInstance<RoomItemUpgradeDefinition>[] array = upgrades;
					foreach (SharedInstance<RoomItemUpgradeDefinition> sharedInstance in array)
					{
						if (metagame.HasUnlocked(sharedInstance.Instance))
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public static RoomItem GetRoomItemWithUpgrades(Room room)
		{
			if (room != null)
			{
				foreach (RoomItem item in room.FloorPlan.Items)
				{
					if (item.Definition.GetNextUpgrade(item.UpgradeLevel) != null)
					{
						return item;
					}
				}
			}
			return null;
		}

		public static void FindInvalidWallItems(FloorPlan floorPlan, List<RoomItem> invalidItems, FloorPlan unbuiltRoom = null)
		{
			foreach (RoomItem item in floorPlan.Items)
			{
				if (!item.Definition.PlaceOnWall || !item.Definition.CanBeSoldWhenBuiltOver())
				{
					continue;
				}
				bool flag = false;
				bool allowOnWindows = !item.Definition.OccupyWallOnly;
				if (RoomItemAlgorithms.ValidWallAtItemLocation(item))
				{
					flag = true;
				}
				else
				{
					GridCoord gridCoord = item.LocalCoord + item.FloorPlan.Anchor - floorPlan.Anchor;
					GridDirection localRotation = item.GridRotation.Rotate180();
					if (floorPlan.Walls != null)
					{
						gridCoord += item.GridRotation.DirectionCoord();
						foreach (WallCoord wall in floorPlan.Walls)
						{
							if (!wall.IsCorner() && wall._position == gridCoord && IsWallItemValid(localRotation, wall, allowOnWindows))
							{
								flag = true;
								break;
							}
						}
					}
					if (unbuiltRoom != null && unbuiltRoom.Walls != null)
					{
						gridCoord = item.LocalCoord + item.FloorPlan.Anchor - unbuiltRoom.Anchor;
						gridCoord += item.GridRotation.DirectionCoord();
						foreach (WallCoord wall2 in unbuiltRoom.Walls)
						{
							if (!wall2.IsCorner() && wall2._position == gridCoord && IsWallItemValid(localRotation, wall2, allowOnWindows))
							{
								flag = true;
								break;
							}
						}
					}
				}
				if (!flag)
				{
					invalidItems.AddUnique(item);
				}
			}
		}

		private static bool IsWallItemValid(GridDirection localRotation, WallCoord wall, bool allowOnWindows)
		{
			if (localRotation == wall._rotation && (wall.IsWall() || (allowOnWindows && wall.IsWindow())))
			{
				return true;
			}
			return false;
		}

		public static bool GetQueueTransform(Character character, Room room, out Vector3 position, out float rotation)
		{
			if (!room.Definition.IsHospitalOrBay)
			{
				int num = room.PositionToStandInQueue(character);
				if (num != -1 && room.QueuePath.GetPoint(num, out position, out rotation))
				{
					return true;
				}
			}
			position = Vector3.zero;
			rotation = 0f;
			return false;
		}

		public static bool IsCharacterWithinDistanceOfQueuePosition(Character character, Room room, float distance)
		{
			bool result = false;
			if (GetQueueTransform(character, room, out var position, out var _))
			{
				float num = MathUtils.Square(distance);
				if (position.SquareDistance2D(character.Position) < num)
				{
					result = true;
				}
			}
			return result;
		}

		public static bool CanReachAnyDoor(Vector3 worldPosition, FloorPlan floorPlan, Level level)
		{
			bool result = false;
			if (floorPlan != null)
			{
				if (floorPlan.HasNoExteriorWalls())
				{
					List<RoomItem> doors = floorPlan.HospitalMap.CorridorFloorPlan.Doors;
					if (doors.Count == 0)
					{
						result = true;
					}
					else
					{
						RoomItem roomItem = doors.RandomItem();
						result = level.WorldState.NavMesh.CanReach(worldPosition, roomItem.LocalPosition + floorPlan.Anchor.ToWorldPosition());
					}
				}
				else
				{
					List<RoomItem> doors2 = floorPlan.Doors;
					result = doors2.Count != 0 && level.WorldState.NavMesh.CanReach(worldPosition, doors2.RandomItem().WorldPosition);
				}
			}
			return result;
		}
	}
}
