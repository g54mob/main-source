using System;
using System.Collections.Generic;

[Serializable]
public class RoomGroup
{
	public string Name;

	public RoomStyle Indoor;

	public RoomStyle Outdoor;

	private SHashSet<uint> _rooms = new SHashSet<uint>();

	[NonSerialized]
	private List<Room> _actualRooms;

	[NonSerialized]
	public bool SaveMe = true;

	public int Count
	{
		get
		{
			return _rooms.Count;
		}
	}

	public List<Room> GetRooms()
	{
		if (_actualRooms == null)
		{
			_actualRooms = new List<Room>();
			if (_rooms.Contains(GameSettings.Instance.sRoomManager.Outside.DID))
			{
				_actualRooms.Add(GameSettings.Instance.sRoomManager.Outside);
			}
			for (int i = 0; i < GameSettings.Instance.sRoomManager.Rooms.Count; i++)
			{
				Room room = GameSettings.Instance.sRoomManager.Rooms[i];
				if (_rooms.Contains(room.DID))
				{
					_actualRooms.Add(room);
				}
			}
		}
		return _actualRooms;
	}

	public void AddRoom(Room room)
	{
		if (_rooms.Add(room.DID))
		{
			_actualRooms = null;
			room.RoomGroup = Name;
			if (room.Outdoors && Outdoor != null)
			{
				Outdoor.Apply(room, null);
			}
			if (!room.Outdoors && Indoor != null)
			{
				Indoor.Apply(room, null);
			}
		}
	}

	public void RemoveRoom(Room room)
	{
		if (_rooms.Remove(room.DID))
		{
			_actualRooms = null;
		}
	}

	public RoomGroup()
	{
	}

	public RoomGroup(string name)
	{
		Name = name;
	}
}
