namespace VoxelBusters.EssentialKit
{
	public class GameServicesLoadPlayerFriendsResult
	{
		public IPlayer[] Players { get; private set; }

		internal GameServicesLoadPlayerFriendsResult(IPlayer[] players)
		{
		}
	}
}
