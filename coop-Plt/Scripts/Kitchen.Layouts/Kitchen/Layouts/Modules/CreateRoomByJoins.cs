using System.Linq;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Create Room By Joins")]
	public class CreateRoomByJoins : LayoutModule
	{
		public int StartX;

		public int StartY;

		public int Joins;

		public RoomType Type;

		public bool Required;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			Room room = blueprint[StartX, StartY];
			room.Type = Type;
			blueprint.SetRoom(room, room);
			for (int i = 0; i < Joins; i++)
			{
				Room[] array = (from e in blueprint.AdjacentRooms(room)
					where e.Type == RoomType.Unassigned
					select e).ToArray();
				if (array.Length == 0)
				{
					if (Required)
					{
						throw new ModuleException("CreateRoomByJoins: Not enough rooms to join");
					}
					break;
				}
				Room current = array[Random.Range(0, array.Length)];
				blueprint.SetRoom(current, room);
			}
		}
	}
}
