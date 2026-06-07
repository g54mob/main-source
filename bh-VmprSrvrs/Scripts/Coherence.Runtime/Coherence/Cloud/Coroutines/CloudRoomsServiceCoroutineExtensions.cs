using System.Collections.Generic;

namespace Coherence.Cloud.Coroutines
{
	public static class CloudRoomsServiceCoroutineExtensions
	{
		public static WaitForRequestResponse<IReadOnlyList<RoomData>> WaitForFetchRooms(this CloudRoomsService cloudRoomsService, string[] tags = null)
		{
			return null;
		}

		public static WaitForRequestResponse<RoomData> WaitForCreateRoom(this CloudRoomsService cloudRoomsService, RoomCreationOptions roomCreationOptions)
		{
			return null;
		}

		public static WaitForRequestResponse<string> WaitForRemoveRoom(this CloudRoomsService cloudRoomsService, ulong uniqueID, string secret)
		{
			return null;
		}
	}
}
