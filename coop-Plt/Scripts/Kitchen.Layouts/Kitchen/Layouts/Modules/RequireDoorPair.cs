using System.Linq;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Conditions/Door Pair")]
	public class RequireDoorPair : LayoutCondition
	{
		public RoomType Room1;

		public RoomType Room2;

		protected override bool Test(LayoutBlueprint blueprint)
		{
			foreach (Room item in blueprint.Rooms())
			{
				if (item.Type == Room1 && !blueprint.AdjacentRooms(item).Any((Room r) => r.Type == Room2))
				{
					return false;
				}
			}
			return true;
		}
	}
}
