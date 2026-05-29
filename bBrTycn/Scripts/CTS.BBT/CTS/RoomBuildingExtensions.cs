using System;
using System.Collections.Generic;
using CTS.AI;
using CTS.Core;
using CTS.Core.Utilities;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public static class RoomBuildingExtensions
	{
		private struct RoomData : IComparable<RoomData>, IEquatable<RoomData>
		{
			public int Score;

			public RoomBuilding Room;

			public int CompareTo(RoomData other)
			{
				return Score.CompareTo(other.Score);
			}

			public bool Equals(RoomData other)
			{
				if (Room == other.Room)
				{
					return Score == other.Score;
				}
				return false;
			}
		}

		public static bool IsCustomerRoom(this RoomBuilding roomBuilding)
		{
			return roomBuilding.NavArea.IsCustomerArea();
		}

		public static bool IsWorkerRoom(this RoomBuilding roomBuilding)
		{
			return roomBuilding.NavArea.IsWorkerArea();
		}

		public static bool IsVampireRoom(this RoomBuilding roomBuilding)
		{
			return roomBuilding.NavArea.IsVampireArea();
		}

		public static bool IsExterior(this RoomBuilding roomBuilding)
		{
			return roomBuilding.RoomIndex == 0;
		}

		public static bool IsCustomerArea(this NavigationArea navigationArea)
		{
			return navigationArea == 3;
		}

		public static bool IsWorkerArea(this NavigationArea navigationArea)
		{
			return navigationArea == 4;
		}

		public static bool IsVampireArea(this NavigationArea navigationArea)
		{
			return navigationArea == 8;
		}

		public static bool HasACustomerRoom(this BuildingRoomsContainerManager roomsContainerManager)
		{
			foreach (BuildingRoomContainer roomManager in roomsContainerManager.RoomManagers)
			{
				if (roomManager.HasACustomerRoom())
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasAVampireRoom(this BuildingRoomsContainerManager roomsContainerManager)
		{
			foreach (BuildingRoomContainer roomManager in roomsContainerManager.RoomManagers)
			{
				if (roomManager.HasAVampireRoom())
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasAWorkerRoom(this BuildingRoomsContainerManager roomsContainerManager)
		{
			foreach (BuildingRoomContainer roomManager in roomsContainerManager.RoomManagers)
			{
				if (roomManager.HasAWorkerRoom())
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasACustomerRoom(this BuildingRoomContainer roomContainer)
		{
			foreach (RoomBuilding value in roomContainer.GeneratedRooms.Values)
			{
				if (value.IsCustomerRoom())
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasAWorkerRoom(this BuildingRoomContainer roomContainer)
		{
			foreach (RoomBuilding value in roomContainer.GeneratedRooms.Values)
			{
				if (value.IsWorkerRoom())
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasAVampireRoom(this BuildingRoomContainer roomContainer)
		{
			foreach (RoomBuilding value in roomContainer.GeneratedRooms.Values)
			{
				if (value.IsVampireRoom())
				{
					return true;
				}
			}
			return false;
		}

		public static Vector3 GetInteractionPoint(this RoomBuilding roomBuilding)
		{
			NavMeshQueryFilter filter = new NavMeshQueryFilter
			{
				areaMask = roomBuilding.NavArea.ToMask(),
				agentTypeID = AgentsMover.InteractionAgentID
			};
			ReadOnlyList<BuildingFloor> floorTiles = roomBuilding.FloorTiles;
			int num = UnityEngine.Random.Range(0, floorTiles.Count);
			for (int i = num; i < floorTiles.Count; i++)
			{
				if (TryGetPosition(i, out var outPosition))
				{
					return outPosition;
				}
			}
			for (int j = 0; j < num; j++)
			{
				if (TryGetPosition(j, out var outPosition2))
				{
					return outPosition2;
				}
			}
			Debug.LogException(new Exception("No position found."));
			return Vector3.zero;
			bool TryGetPosition(int tileIndex, out Vector3 reference)
			{
				if (NavMesh.SamplePosition(floorTiles[tileIndex].transform.position, out var hit, 1f, filter))
				{
					reference = hit.position;
					return true;
				}
				reference = Vector3.zero;
				return false;
			}
		}

		public static RoomBuilding GetNearestRoom(this RoomBuilding currentRoom, [CanBeNull] Func<RoomBuilding, bool> filter, [CanBeNull] Func<RoomBuilding, int> scoreChange)
		{
			List<RoomData> rooms = new List<RoomData>();
			HashSet<RoomBuilding> visitedRooms = new HashSet<RoomBuilding>();
			HandleRoom(currentRoom, 0);
			rooms.Sort();
			if (rooms.Count > 0)
			{
				return rooms[0].Room;
			}
			return currentRoom;
			void HandleRoom(RoomBuilding room, int depth)
			{
				visitedRooms.Add(room);
				foreach (RoomBuilding adjacentRoom in CTSSingleton<RoomAdjacency>.Instance.GetAdjacentRooms(room))
				{
					int num = (adjacentRoom.IsExterior() ? (depth + 51) : (depth + 1));
					RoomData item = new RoomData
					{
						Room = adjacentRoom,
						Score = num
					};
					if (filter == null || filter(adjacentRoom))
					{
						if (scoreChange != null)
						{
							item.Score += scoreChange(adjacentRoom);
						}
						rooms.Add(item);
					}
					if (!visitedRooms.Contains(adjacentRoom))
					{
						HandleRoom(adjacentRoom, num);
					}
				}
			}
		}
	}
}
