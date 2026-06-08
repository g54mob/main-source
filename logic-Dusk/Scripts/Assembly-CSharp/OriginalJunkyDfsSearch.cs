using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OriginalJunkyDfsSearch
{
	public static bool Search(Waypoint current, Waypoint end, Stack<Waypoint> pathSoFar, bool stopAtBlocked)
	{
		pathSoFar.Push(current);
		if (current == end)
		{
			return true;
		}
		IEnumerable<Waypoint> enumerable = current.ConnectedRooms.Where((Waypoint x) => !pathSoFar.Any((Waypoint p) => p == x));
		bool flag = false;
		foreach (Waypoint item in enumerable)
		{
			if (stopAtBlocked)
			{
				AdjacentRoomData adjacentRoomData = NavigationHelper.GetAdjacentRoomData(current, item);
				if (adjacentRoomData != null)
				{
					if (adjacentRoomData.ConnectingDoor.state == DoorState.Closed)
					{
						continue;
					}
				}
				else
				{
					Debug.Log(string.Format("Missing adjacent room data for {0} and {1}", current.Room, item.Room));
				}
			}
			flag = Search(item, end, pathSoFar, stopAtBlocked);
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			pathSoFar.Pop();
		}
		return flag;
	}
}
