using System;
using MessagePack;
using UnityEngine;

namespace Kitchen.Layouts
{
	[Serializable]
	[MessagePackObject(false)]
	public struct Room
	{
		[Key(0)]
		public int ID;

		[Key(1)]
		public RoomType Type;

		public static Room New => new Room
		{
			ID = UnityEngine.Random.Range(int.MinValue, int.MaxValue),
			Type = RoomType.Unassigned
		};

		public static Room Null => new Room
		{
			ID = 0,
			Type = RoomType.NoRoom
		};

		public Room(int id, RoomType type)
		{
			ID = id;
			Type = type;
		}

		public Room(RoomType type)
		{
			ID = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			Type = type;
		}

		public Room(Room copy)
		{
			ID = copy.ID;
			Type = copy.Type;
		}

		public static implicit operator RoomType(Room room)
		{
			return room.Type;
		}
	}
}
