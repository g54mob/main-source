using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Fully Connect")]
	public class FullyConnect : LayoutModule
	{
		private struct ConnectPair
		{
			public Room Room1;

			public Room Room2;

			public ConnectPair(Room room1, Room room2)
			{
				Room1 = room1;
				Room2 = room2;
			}
		}

		public RoomType BaseRoom;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			HashSet<Room> hashSet = blueprint.Rooms();
			Dictionary<Room, HashSet<Feature>> room_connections = hashSet.ToDictionary((Room r) => r, (Room r) => new HashSet<Feature>(blueprint.Tiles.SelectMany((KeyValuePair<LayoutPosition, Room> t) => from d in LayoutHelpers.Directions
				select new LayoutPosition(d.x + t.Key.x, d.y + t.Key.y) into d
				where blueprint[d].ID != t.Value.ID && blueprint[d].ID == r.ID
				select new Feature(t.Key, d, FeatureType.Generic))));
			Dictionary<Room, HashSet<Room>> room_adjacency = hashSet.ToDictionary((Room r) => r, (Room r) => new HashSet<Room>(room_connections[r].Select((Feature c) => blueprint[c.Tile2])));
			HashSet<Room> unconnected_rooms = new HashSet<Room>(hashSet);
			List<ConnectPair> added_connections = new List<ConnectPair>();
			Room room = hashSet.First((Room r) => r.Type == BaseRoom);
			connect_from(room);
			foreach (ConnectPair connection in added_connections)
			{
				List<Feature> list = room_connections[connection.Room1].Where((Feature p) => blueprint[p.Tile2].ID == connection.Room2.ID).ToList();
				Feature feature = list[Random.Range(0, list.Count)];
				blueprint.Features.Add(new Feature(feature.Tile1, feature.Tile2, FeatureType.Door));
			}
			void connect_from(Room room2)
			{
				unconnected_rooms.Remove(room2);
				foreach (Room item in room_adjacency[room2])
				{
					if (unconnected_rooms.Contains(item))
					{
						added_connections.Add(new ConnectPair(room2, item));
						connect_from(item);
					}
				}
			}
		}
	}
}
