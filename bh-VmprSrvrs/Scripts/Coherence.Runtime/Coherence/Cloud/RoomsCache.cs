using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Coherence.Cloud
{
	public class RoomsCache
	{
		private string endpoint;

		private List<RoomData> rooms;

		public IReadOnlyList<RoomData> CachedRooms => null;

		public event Action<string, List<RoomData>> OnRoomsUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public RoomsCache(string endpoint)
		{
		}

		internal void ClearRooms()
		{
		}

		internal void AddRoom(RoomData room)
		{
		}

		internal void PopulateRooms(List<RoomData> roomsToAdd)
		{
		}

		internal void RemoveRoom(ulong uniqueId)
		{
		}
	}
}
