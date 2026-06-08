using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Merge Rooms By Type")]
	public class MergeRoomsByType : LayoutModule
	{
		public override void ActOn(LayoutBlueprint blueprint)
		{
			foreach (Room item in blueprint.Rooms())
			{
				foreach (Room item2 in blueprint.AdjacentRooms(item))
				{
					if (item2.Type == item.Type)
					{
						blueprint.SetRoom(item2, item);
					}
				}
			}
		}
	}
}
