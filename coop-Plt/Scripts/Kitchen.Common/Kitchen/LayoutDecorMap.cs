using System;
using KitchenData;
using MessagePack;
using Unity.Collections;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct LayoutDecorMap
	{
		[SerializeField]
		[Key(0)]
		public FixedListInt64 Rooms;

		[Key(1)]
		[SerializeField]
		public FixedListInt64 Wallpapers;

		[Key(2)]
		[SerializeField]
		public FixedListInt64 Floors;

		public bool Apply(CChangeDecorEvent evt)
		{
			if (evt.Type == LayoutMaterialType.Wallpaper)
			{
				return Wallpaper(evt.RoomID, evt.DecorID);
			}
			return Floor(evt.RoomID, evt.DecorID);
		}

		public int Wallpaper(int room)
		{
			return Get(ref Wallpapers, Index(room));
		}

		public int Floor(int room)
		{
			return Get(ref Floors, Index(room));
		}

		public bool Wallpaper(int room, int set)
		{
			return SetOrAdd(ref Wallpapers, room, set);
		}

		public bool Floor(int room, int set)
		{
			return SetOrAdd(ref Floors, room, set);
		}

		public bool SetOrAdd(ref FixedListInt64 list, int room, int value)
		{
			int num = Index(room);
			if (num == -1)
			{
				Rooms.Add(in room);
				Wallpapers.Add(0);
				Floors.Add(0);
				num = Index(room);
			}
			return Set(ref list, num, value);
		}

		public bool IsChangedFrom(LayoutDecorMap other)
		{
			if (other.Rooms.Length != Rooms.Length)
			{
				return true;
			}
			foreach (int room in Rooms)
			{
				if (Wallpaper(room) != other.Wallpaper(room))
				{
					return true;
				}
				if (Floor(room) != other.Floor(room))
				{
					return true;
				}
			}
			return false;
		}

		private int Get(ref FixedListInt64 list, int index)
		{
			if (index == -1 || index >= list.Length)
			{
				return 0;
			}
			return list[index];
		}

		private bool Set(ref FixedListInt64 list, int index, int value)
		{
			if (index == -1 || index >= list.Length)
			{
				return false;
			}
			if (value == list[index])
			{
				return false;
			}
			list[index] = value;
			return true;
		}

		private int Index(int room)
		{
			for (int i = 0; i < Rooms.Length; i++)
			{
				if (Rooms[i] == room)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
