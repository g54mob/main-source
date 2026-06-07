using Assets.Scripts.Craft;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityPlayerAircraftEventArgs : NetworkedActivityPlayerEventArgs
	{
		public AircraftScript Aircraft { get; }

		public NetworkedActivityPlayerAircraftEventArgs(NetworkedActivityScript activity, NetworkedActivityPlayer player, AircraftScript aircraft)
			: base(activity, player)
		{
			Aircraft = aircraft;
		}
	}
}
