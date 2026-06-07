namespace VoxelBusters.EssentialKit
{
	public class GameServicesLoadPlayersResult
	{
		public IPlayer[] Players { get; private set; }

		internal GameServicesLoadPlayersResult(IPlayer[] players)
		{
		}
	}
}
