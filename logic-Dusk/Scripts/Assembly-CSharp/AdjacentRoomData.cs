using System.Collections.Generic;

public class AdjacentRoomData
{
	public Room Room1 { get; set; }

	public Room Room2 { get; set; }

	public List<Waypoint> ConnectingWaypoints { get; set; }

	public Door ConnectingDoor { get; set; }

	public bool IsDataForTheseRooms(Room roomA, Room roomB)
	{
		return (roomA == Room1 && roomB == Room2) || (roomA == Room2 && roomB == Room1);
	}
}
