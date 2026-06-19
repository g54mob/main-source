using System.Collections.Generic;

public static class RoomPathfinder
{
	public static bool DoesRoomPathExist(ulong startRoomID, ulong endRoomID, ConstructionManager constructionRef)
	{
		return RoomBFS(startRoomID, endRoomID, constructionRef).Count > 0;
	}

	public static float EstimatePathDistance(ulong? startRoomID, ulong? endRoomID, ConstructionManager constructionRef)
	{
		if (!startRoomID.HasValue || !endRoomID.HasValue)
		{
			return -1f;
		}
		return RoomBFS(startRoomID.Value, endRoomID.Value, constructionRef).Count;
	}

	public static List<ulong> GetLinkedRooms(ulong roomID, ConstructionManager constructionRef)
	{
		return constructionRef.GetAllAttachedRooms(roomID);
	}

	private static List<ulong> RoomBFS(ulong startRoomID, ulong endRoomID, ConstructionManager constructionRef)
	{
		if (startRoomID == endRoomID)
		{
			return new List<ulong>();
		}
		List<ulong> list = new List<ulong>();
		List<ulong> list2 = new List<ulong>();
		Dictionary<ulong, ulong> dictionary = new Dictionary<ulong, ulong>();
		list.Add(startRoomID);
		while (list.Count > 0)
		{
			ulong num = list[0];
			list.RemoveAt(0);
			if (num == endRoomID)
			{
				return ConstructPath(num, dictionary);
			}
			List<ulong> linkedRooms = GetLinkedRooms(num, constructionRef);
			for (int i = 0; i < linkedRooms.Count; i++)
			{
				ulong num2 = linkedRooms[i];
				if (!list2.Contains(num2) && !list.Contains(num2))
				{
					list.Add(num2);
					dictionary[num2] = num;
				}
			}
			list2.Add(num);
		}
		return new List<ulong>();
	}

	private static List<ulong> ConstructPath(ulong endPos, Dictionary<ulong, ulong> connections)
	{
		ulong num = endPos;
		List<ulong> list = new List<ulong>();
		while (true)
		{
			list.Insert(0, num);
			if (!connections.ContainsKey(num))
			{
				break;
			}
			num = connections[num];
		}
		return list;
	}
}
