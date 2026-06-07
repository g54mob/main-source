using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public static class RoomHelpers
	{
		public static bool IsInSameRoom(this GameObjectX gox, GameObjectX other)
		{
			return false;
		}

		public static bool IsInRoom(this GameObjectX gox, Room room)
		{
			return false;
		}

		public static bool IsInRoom(this GameObjectX gox, IEnumerable<Room> rooms)
		{
			return false;
		}

		public static bool IsInRoomWithSchedule(this GameObjectX gox, string scheduleOption)
		{
			return false;
		}

		public static IEnumerable<Room> GetCurrentRoomsAndConnectingRooms(this GameObjectX gox)
		{
			return null;
		}

		public static IEnumerable<Room> GetConnectingRooms(this GameObjectX gox)
		{
			return null;
		}

		public static List<Room> GetConnectingRooms(this List<Room> rooms)
		{
			return null;
		}

		public static IEnumerable<GameObjectX> GetGameObjectXsInCurrentRoomsAndConnectingRooms(this GameObjectX gox)
		{
			return null;
		}

		public static IEnumerable<GameObjectX> GetGameObjectXsInSameRoom(this GameObjectX gox)
		{
			return null;
		}

		public static IEnumerable<Prop> GetPropsInSameRoom(this GameObjectX gox)
		{
			return null;
		}

		public static IEnumerable<Door> GetDoorsInSameRoom(this GameObjectX gox)
		{
			return null;
		}

		public static IEnumerable<Fire> GetFiresInSameRoom(this GameObjectX gox)
		{
			return null;
		}

		public static IEnumerable<Fire> GetFiresInSameRoom(this Vector3 worldPosition)
		{
			return null;
		}

		public static IEnumerable<Actor> GetActorsInSameRoom(this GameObjectX gox)
		{
			return null;
		}
	}
}
