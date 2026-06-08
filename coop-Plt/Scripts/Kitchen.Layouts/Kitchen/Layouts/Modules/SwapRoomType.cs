using System.Collections.Generic;
using System.Linq;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Swap Room Type")]
	public class SwapRoomType : LayoutModule
	{
		public int X;

		public int Y;

		public RoomType Type;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			Room room = blueprint[X, Y];
			Room value = new Room(Type);
			foreach (KeyValuePair<LayoutPosition, Room> item in blueprint.Tiles.ToList())
			{
				if (item.Value.ID == room.ID)
				{
					blueprint[item.Key] = value;
				}
			}
		}
	}
}
