namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityPlayerTeamEventArgs : NetworkedActivityPlayerEventArgs
	{
		public NetworkedActivityTeam Team { get; }

		public NetworkedActivityPlayerTeamEventArgs(NetworkedActivityScript activity, NetworkedActivityPlayer player, NetworkedActivityTeam team)
			: base(activity, player)
		{
			Team = team;
		}
	}
}
