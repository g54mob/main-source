using System.Collections.Generic;

public class DungeonDoor : DungeonBoardItem
{
	public List<DungeonRoom> rooms = new List<DungeonRoom>();

	public bool horizontal;

	public bool initialDockingAirlock;

	public bool airlock;

	public bool dontTranslateAirlock;

	public DungeonDoor(Coordinate2D origin, bool horizontal)
	{
		base.origin = origin;
		dimensions = new Coordinate2D(2, 2);
		this.horizontal = horizontal;
	}

	public void AddRoom(DungeonRoom room)
	{
		rooms.Add(room);
		room.AddDoor(this);
	}

	public DungeonRoom GetOtherRoom(DungeonRoom startRoom)
	{
		foreach (DungeonRoom room in rooms)
		{
			if (room != startRoom)
			{
				return room;
			}
		}
		return null;
	}
}
