using System;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class FilthManager : CTSSingleton<FilthManager>
	{
		[SerializeField]
		[ReadOnly]
		private SerializableDictionary<RoomBuilding, List<IFilth>> _roomsFilth = new SerializableDictionary<RoomBuilding, List<IFilth>>();

		public int TotalFilth
		{
			get
			{
				int num = 0;
				foreach (KeyValuePair<RoomBuilding, List<IFilth>> item in _roomsFilth)
				{
					foreach (IFilth item2 in item.Value)
					{
						num += item2.FilthLevel;
					}
				}
				return num;
			}
		}

		public static event Action<RoomBuilding, int> RoomFilthChanged;

		public void AddFilth(RoomBuilding room, IFilth filth)
		{
			if (!_roomsFilth.ContainsKey(room))
			{
				_roomsFilth.Add(room, new List<IFilth>());
			}
			if (!_roomsFilth[room].Contains(filth))
			{
				_roomsFilth[room].Add(filth);
			}
			else
			{
				FilthManager.RoomFilthChanged?.Invoke(room, _roomsFilth[room].Count);
			}
		}

		public void RemoveFilth(RoomBuilding room, IFilth filth)
		{
			if (_roomsFilth.ContainsKey(room))
			{
				_roomsFilth[room].Remove(filth);
				FilthManager.RoomFilthChanged?.Invoke(room, _roomsFilth[room].Count);
			}
		}

		public int GetRoomFilth(RoomBuilding room)
		{
			if (!_roomsFilth.ContainsKey(room))
			{
				return 0;
			}
			return _roomsFilth[room].Sum((IFilth filth) => filth.FilthLevel);
		}

		protected override void OnEnabled()
		{
			RoomBuilding.OnRoomDestroyed += OnRoomDestroyed;
		}

		private void OnRoomDestroyed(RoomBuilding room)
		{
			_roomsFilth.Remove(room);
		}

		protected override void OnDisabled()
		{
			_roomsFilth.Clear();
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
