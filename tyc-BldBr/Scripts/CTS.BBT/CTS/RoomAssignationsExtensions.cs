namespace CTS
{
	public static class RoomAssignationsExtensions
	{
		public static bool IsInRoomAssignation(this IBBTObject bbtObject, RoomAssignations roomAssignations)
		{
			if (roomAssignations.AssignedRooms.Count <= 0)
			{
				return true;
			}
			foreach (RoomBuilding assignedRoom in roomAssignations.AssignedRooms)
			{
				if ((object)assignedRoom == bbtObject.RoomObject.CurrentRoom)
				{
					return true;
				}
			}
			return false;
		}
	}
}
