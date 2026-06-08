using System.Collections.Generic;

namespace Kitchen.Layouts
{
	public static class LayoutHelpers
	{
		public static readonly List<LayoutPosition> Directions = new List<LayoutPosition>
		{
			new LayoutPosition(0, 1),
			new LayoutPosition(0, -1),
			new LayoutPosition(-1, 0),
			new LayoutPosition(1, 0)
		};

		public static readonly List<LayoutPosition> Diagonals = new List<LayoutPosition>
		{
			new LayoutPosition(1, 1),
			new LayoutPosition(-1, 1),
			new LayoutPosition(1, -1),
			new LayoutPosition(-1, -1)
		};

		public static readonly List<LayoutPosition> AllNearby = new List<LayoutPosition>
		{
			new LayoutPosition(1, 0),
			new LayoutPosition(0, 1),
			new LayoutPosition(-1, 0),
			new LayoutPosition(0, -1),
			new LayoutPosition(1, 1),
			new LayoutPosition(-1, 1),
			new LayoutPosition(1, -1),
			new LayoutPosition(-1, -1)
		};

		public static readonly List<LayoutPosition> AllNearbyRange2 = new List<LayoutPosition>
		{
			new LayoutPosition(-2, -2),
			new LayoutPosition(-1, -2),
			new LayoutPosition(0, -2),
			new LayoutPosition(1, -2),
			new LayoutPosition(2, -2),
			new LayoutPosition(-2, -1),
			new LayoutPosition(-1, -1),
			new LayoutPosition(0, -1),
			new LayoutPosition(1, -1),
			new LayoutPosition(2, -1),
			new LayoutPosition(-2, 0),
			new LayoutPosition(-1, 0),
			new LayoutPosition(1, 0),
			new LayoutPosition(2, 0),
			new LayoutPosition(-2, 1),
			new LayoutPosition(-1, 1),
			new LayoutPosition(0, 1),
			new LayoutPosition(1, 1),
			new LayoutPosition(2, 1),
			new LayoutPosition(-2, 2),
			new LayoutPosition(-1, 2),
			new LayoutPosition(0, 2),
			new LayoutPosition(1, 2),
			new LayoutPosition(2, 2)
		};

		public static bool IsInside(RoomType type, bool allow_garden = false)
		{
			return type switch
			{
				RoomType.NoRoom => false, 
				RoomType.Garden => allow_garden, 
				RoomType.FrontEntrance => false, 
				_ => true, 
			};
		}

		public static bool IsOutsidePlayable(RoomType type)
		{
			if (type == RoomType.NoRoom)
			{
				return true;
			}
			return false;
		}

		public static bool IsInside(Room room)
		{
			return IsInside(room.Type);
		}
	}
}
