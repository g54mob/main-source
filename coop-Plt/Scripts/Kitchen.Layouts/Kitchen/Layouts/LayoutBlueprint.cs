using System;
using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using MessagePack;
using UnityEngine;

namespace Kitchen.Layouts
{
	[Serializable]
	[MessagePackObject(false)]
	public class LayoutBlueprint
	{
		[Key(0)]
		public int ID;

		[Key(1)]
		public Dictionary<LayoutPosition, Room> Tiles;

		[Key(2)]
		public List<Feature> Features;

		public static LayoutBlueprint New => new LayoutBlueprint
		{
			ID = UnityEngine.Random.Range(int.MinValue, int.MaxValue)
		};

		public Room this[int x, int y]
		{
			get
			{
				if (!Tiles.ContainsKey(new LayoutPosition(x, y)))
				{
					return Room.Null;
				}
				return Tiles[new LayoutPosition(x, y)];
			}
			set
			{
				Tiles[new LayoutPosition(x, y)] = value;
			}
		}

		public Room this[LayoutPosition pos]
		{
			get
			{
				if (!Tiles.ContainsKey(pos))
				{
					return Room.Null;
				}
				return Tiles[pos];
			}
			set
			{
				Tiles[pos] = value;
			}
		}

		public LayoutBlueprint()
		{
			ID = 0;
			Tiles = new Dictionary<LayoutPosition, Room>();
			Features = new List<Feature>();
		}

		public static LayoutBlueprint Blank(int width, int height, RoomType type = RoomType.NoRoom)
		{
			LayoutBlueprint layoutBlueprint = New;
			int num = width / 2;
			int num2 = height / 2;
			Room value = new Room(type);
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					layoutBlueprint.Tiles.Add(new LayoutPosition(i - num, j - num2), value);
				}
			}
			return layoutBlueprint;
		}

		public LayoutBlueprint(LayoutBlueprint source)
		{
			ID = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			if (source != null)
			{
				Tiles = new Dictionary<LayoutPosition, Room>();
				Features = new List<Feature>();
				foreach (KeyValuePair<LayoutPosition, Room> tile in source.Tiles)
				{
					Tiles.Add(tile.Key, new Room(tile.Value));
				}
				{
					foreach (Feature feature in source.Features)
					{
						Features.Add(new Feature(feature));
					}
					return;
				}
			}
			Tiles = new Dictionary<LayoutPosition, Room>();
			Features = new List<Feature>();
		}

		public Bounds GetBounds()
		{
			int num = int.MaxValue;
			int num2 = int.MinValue;
			int num3 = int.MaxValue;
			int num4 = int.MinValue;
			foreach (KeyValuePair<LayoutPosition, Room> tile in Tiles)
			{
				if (tile.Key.x < num)
				{
					num = tile.Key.x;
				}
				if (tile.Key.y < num3)
				{
					num3 = tile.Key.y;
				}
				if (tile.Key.x > num2)
				{
					num2 = tile.Key.x;
				}
				if (tile.Key.y > num4)
				{
					num4 = tile.Key.y;
				}
			}
			return new Bounds(new Vector3((float)(num + num2) / 2f, (float)(num3 + num4) / 2f), new Vector3(num2 - num, num4 - num3));
		}

		public Bounds GetWorldBounds()
		{
			Bounds bounds = GetBounds();
			bounds.center = new Vector3(bounds.center.x, bounds.center.z, bounds.center.y);
			bounds.size = new Vector3(bounds.size.x, 10f, bounds.size.y);
			return bounds;
		}

		public HashSet<Room> ConnectedRooms(Room start)
		{
			HashSet<Room> hashSet = new HashSet<Room>();
			foreach (Feature feature in Features)
			{
				if (feature.Type.IsDoor())
				{
					if (this[feature.Tile1].ID == start.ID)
					{
						hashSet.Add(this[feature.Tile2]);
					}
					if (this[feature.Tile2].ID == start.ID)
					{
						hashSet.Add(this[feature.Tile1]);
					}
				}
			}
			return hashSet;
		}

		public HashSet<Room> AdjacentRooms(Room start)
		{
			HashSet<Room> hashSet = new HashSet<Room>();
			foreach (KeyValuePair<LayoutPosition, Room> tile in Tiles)
			{
				if (tile.Value.ID != start.ID)
				{
					continue;
				}
				foreach (LayoutPosition direction in LayoutHelpers.Directions)
				{
					Room item = this[direction.x + tile.Key.x, direction.y + tile.Key.y];
					if (item.ID != Room.Null.ID && item.ID != start.ID)
					{
						hashSet.Add(item);
					}
				}
			}
			return hashSet;
		}

		public void SetRoom(Room current, Room next)
		{
			LayoutPosition[] array = Tiles.Keys.ToArray();
			foreach (LayoutPosition key in array)
			{
				if (Tiles[key].ID == current.ID)
				{
					Tiles[key] = next;
				}
			}
		}

		public HashSet<Room> Rooms()
		{
			return new HashSet<Room>(Tiles.Values);
		}

		public HashSet<LayoutPosition> TilesOfRoom(Room room)
		{
			return new HashSet<LayoutPosition>(from t in Tiles
				where t.Value.ID == room.ID
				select t.Key);
		}

		public HashSet<LayoutPosition> TilesOfRoom(LayoutPosition tile)
		{
			return TilesOfRoom(this[tile]);
		}

		public bool IsTileOpenSpace(LayoutPosition tile)
		{
			int room = this[tile].ID;
			return LayoutHelpers.AllNearby.All((LayoutPosition n) => this[tile + n].ID == room);
		}

		public bool IsTileFlatWall(LayoutPosition tile)
		{
			int room = this[tile].ID;
			return LayoutHelpers.Directions.Count((LayoutPosition n) => this[tile + n].ID == room) == 3;
		}

		public bool IsTileAccessible(LayoutPosition tile)
		{
			return LayoutHelpers.Directions.Any((LayoutPosition n) => IsTileOpenSpace(tile + n));
		}

		public bool HasFeature(LayoutPosition tile, FeatureType type = FeatureType.Generic)
		{
			return GetFeatures(tile, type).Any();
		}

		public bool HasReachingFeature(LayoutPosition tile, LayoutPosition neighbour)
		{
			return GetFeatures(tile).Any((Feature e) => e.Type.IsReaching() && (e.Tile1 == neighbour || e.Tile2 == neighbour));
		}

		public bool HasFeature(LayoutPosition tile1, LayoutPosition tile2)
		{
			return GetFeatures(tile1).Any((Feature f) => f.Tile1 == tile2 || f.Tile2 == tile2);
		}

		public List<Feature> GetFeatures(LayoutPosition tile, FeatureType type = FeatureType.Generic)
		{
			return Features.Where((Feature f) => (f.Tile1 == tile || f.Tile2 == tile) && (type == FeatureType.Generic || f.Type == type)).ToList();
		}

		public List<Feature> GetFeaturesBetweenTypes(RoomType type1, RoomType type2, FeatureType type = FeatureType.Generic)
		{
			return Features.Where((Feature f) => (type == FeatureType.Generic || f.Type == type) && ((this[f.Tile1].Type == type1 && this[f.Tile2].Type == type2) || (this[f.Tile2].Type == type1 && this[f.Tile1].Type == type2))).ToList();
		}

		public List<Feature> GetFeaturesBetweenRoomAndType(Room room, RoomType type2, FeatureType type = FeatureType.Generic)
		{
			return Features.Where((Feature f) => (type == FeatureType.Generic || f.Type == type) && ((this[f.Tile1].ID == room.ID && this[f.Tile2].Type == type2) || (this[f.Tile2].ID == room.ID && this[f.Tile1].Type == type2))).ToList();
		}

		public (LayoutPosition, LayoutPosition) GetOrderedTiles(Feature feature, RoomType first_type)
		{
			if (this[feature.Tile1].Type == first_type)
			{
				return (feature.Tile1, feature.Tile2);
			}
			return (feature.Tile2, feature.Tile1);
		}

		public List<LayoutPosition> GetWalls(LayoutPosition tile)
		{
			int room = this[tile].ID;
			return (from d in LayoutHelpers.Directions
				where this[tile + d].ID != room
				select d + tile).ToList();
		}

		public List<LayoutPosition> GetInternalWalls(LayoutPosition tile)
		{
			return GetWalls(tile).FindAll((LayoutPosition t) => LayoutHelpers.IsInside(this[t].Type));
		}

		public List<LayoutPosition> GetExternalWalls(LayoutPosition tile)
		{
			return GetWalls(tile).FindAll((LayoutPosition t) => !LayoutHelpers.IsInside(this[t].Type));
		}

		public List<LayoutPosition> AdjacentInRoom(LayoutPosition tile)
		{
			int room = this[tile].ID;
			return (from d in LayoutHelpers.Directions
				where this[tile + d].ID == room
				select tile + d).ToList();
		}
	}
}
