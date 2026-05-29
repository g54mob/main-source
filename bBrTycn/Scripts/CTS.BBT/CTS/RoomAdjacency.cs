using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;

namespace CTS
{
	public class RoomAdjacency : CTSSingleton<RoomAdjacency>
	{
		private readonly Dictionary<RoomBuilding, List<RoomBuilding>> _adjacencyCache = new Dictionary<RoomBuilding, List<RoomBuilding>>();

		protected override void SingletonAwake()
		{
			RoomBuilding.OnRoomDestroyed += OnRoomUpdated;
			RoomBuilding.OnRoomUpdated += OnRoomUpdated;
		}

		protected override void OnSingletonDestroy()
		{
			RoomBuilding.OnRoomDestroyed -= OnRoomUpdated;
			RoomBuilding.OnRoomUpdated += OnRoomUpdated;
		}

		public ReadOnlyList<RoomBuilding> GetAdjacentRooms(RoomBuilding room)
		{
			if (!_adjacencyCache.TryGetValue(room, out var value))
			{
				value = CalculateAdjacentRooms(room);
				_adjacencyCache[room] = value;
			}
			return value;
		}

		public void ClearCache(RoomBuilding room)
		{
			_adjacencyCache.Remove(room);
		}

		private List<RoomBuilding> CalculateAdjacentRooms(RoomBuilding room)
		{
			List<RoomBuilding> list = new List<RoomBuilding>();
			foreach (BuildingWall wallTile in room.WallTiles)
			{
				if ((object)wallTile.LinkedCell.BuildableElement == null)
				{
					continue;
				}
				BuildableElementSO.EBuildableType buildableType = wallTile.LinkedCell.BuildableElement.BuildableType;
				if (buildableType == BuildableElementSO.EBuildableType.Arch || buildableType == BuildableElementSO.EBuildableType.Door)
				{
					RoomBuilding linkedRoom = wallTile.GetNeighborWall().LinkedRoom;
					if ((object)linkedRoom != null && !(linkedRoom == room) && !list.Contains(linkedRoom))
					{
						list.Add(linkedRoom);
					}
				}
			}
			return list;
		}

		private void OnRoomUpdated(RoomBuilding room)
		{
			ClearCache(room);
		}
	}
}
