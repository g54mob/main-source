using System.Collections.Generic;

public class DungeonBoard : DungeonBoardItem
{
	public List<DungeonRoom> rooms = new List<DungeonRoom>();

	public List<DungeonDoor> doors = new List<DungeonDoor>();

	public void Clear()
	{
		rooms.Clear();
		doors.Clear();
		DungeonRoom.Clear();
	}
}
