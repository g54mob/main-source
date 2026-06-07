namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityTeamScoreEventArgs : NetworkedActivityEventArgs
	{
		public NetworkedActivityPlayer Player { get; }

		public NetworkedActivityScore Score { get; }

		public NetworkedActivityTeam Team { get; }

		public NetworkedActivityTeamScoreEventArgs(NetworkedActivityScript activity, NetworkedActivityTeam team, NetworkedActivityPlayer player, NetworkedActivityScore score)
			: base(activity)
		{
			Team = team;
			Player = player;
			Score = score;
		}
	}
}
