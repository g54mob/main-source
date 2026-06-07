using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface ILocalPlayer : IPlayer
	{
		bool IsAuthenticated { get; }

		bool IsUnderAge { get; }

		void LoadFriends(EventCallback<GameServicesLoadPlayerFriendsResult> callback);

		void AddFriend(string playerId, EventCallback<bool> callback);
	}
}
