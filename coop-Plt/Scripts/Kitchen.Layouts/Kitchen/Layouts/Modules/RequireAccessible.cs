using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Features;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Conditions/Accessible")]
	public class RequireAccessible : LayoutCondition
	{
		public bool AllowGardens;

		protected override bool Test(LayoutBlueprint blueprint)
		{
			List<Feature> list = blueprint.Features.Where((Feature f) => f.Type == FeatureType.FrontDoor && (blueprint[f.Tile1].Type == RoomType.NoRoom || blueprint[f.Tile2].Type == RoomType.NoRoom)).ToList();
			if (!list.Any())
			{
				throw new LayoutFailureException("No front door");
			}
			HashSet<Room> accessible_rooms = new HashSet<Room>();
			foreach (Feature item in list)
			{
				if (blueprint[item.Tile1].Type != RoomType.NoRoom)
				{
					process(blueprint[item.Tile1]);
				}
				if (blueprint[item.Tile2].Type != RoomType.NoRoom)
				{
					process(blueprint[item.Tile2]);
				}
			}
			foreach (Room item2 in blueprint.Rooms())
			{
				if (item2.Type != RoomType.NoRoom && (AllowGardens || item2.Type != RoomType.Garden))
				{
					if (!accessible_rooms.Contains(item2))
					{
						throw new LayoutFailureException($"Unable to find path to {item2.Type} ({item2.ID})");
					}
					if (IsDisjoint(blueprint.TilesOfRoom(item2)))
					{
						throw new LayoutFailureException($"Room {item2.Type} ({item2.ID}) is disjoint");
					}
				}
			}
			return true;
			void process(Room room)
			{
				if (!AllowGardens && room.Type == RoomType.Garden)
				{
					return;
				}
				accessible_rooms.Add(room);
				foreach (Room item3 in blueprint.ConnectedRooms(room))
				{
					if (!accessible_rooms.Contains(item3))
					{
						process(item3);
					}
				}
			}
		}

		private bool IsDisjoint(HashSet<LayoutPosition> tiles)
		{
			if (tiles.Count == 0)
			{
				return false;
			}
			HashSet<LayoutPosition> hashSet = new HashSet<LayoutPosition>();
			Stack<LayoutPosition> stack = new Stack<LayoutPosition>();
			stack.Push(tiles.First());
			while (stack.Count != 0)
			{
				LayoutPosition layoutPosition = stack.Pop();
				foreach (LayoutPosition direction in LayoutHelpers.Directions)
				{
					LayoutPosition item = layoutPosition + direction;
					if (tiles.Contains(item) && hashSet.Add(item))
					{
						stack.Push(item);
					}
				}
			}
			return hashSet.Count != tiles.Count;
		}
	}
}
