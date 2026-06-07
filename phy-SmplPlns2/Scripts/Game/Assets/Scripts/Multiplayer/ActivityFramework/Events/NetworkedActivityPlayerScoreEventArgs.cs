namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityPlayerScoreEventArgs : NetworkedActivityEventArgs
	{
		public NetworkedActivityPlayer Player { get; }

		public NetworkedActivityScore Score { get; }

		public NetworkedActivityPlayerScoreEventArgs(NetworkedActivityScript activity, NetworkedActivityPlayer player, NetworkedActivityScore score)
			: base(activity)
		{
			Player = player;
			Score = score;
		}
	}
}
