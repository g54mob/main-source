using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coherence.Cloud
{
	public interface IRoomsService
	{
		IReadOnlyList<RoomData> CachedRooms { get; }

		void RemoveRoom(ulong uniqueID, string secret, Action<RequestResponse<string>> onRequestFinished);

		Task RemoveRoomAsync(ulong uniqueID, string secret);

		void CreateRoom(Action<RequestResponse<RoomData>> onRequestFinished, RoomCreationOptions roomCreationOptions);

		Task<RoomData> CreateRoomAsync(RoomCreationOptions roomCreationOptions);

		void FetchRooms(Action<RequestResponse<IReadOnlyList<RoomData>>> onRequestFinished, string[] tags = null);

		Task<IReadOnlyList<RoomData>> FetchRoomsAsync(string[] tags = null);
	}
}
