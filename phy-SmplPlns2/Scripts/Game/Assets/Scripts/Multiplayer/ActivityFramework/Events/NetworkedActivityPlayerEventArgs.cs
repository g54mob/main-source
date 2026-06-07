namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityPlayerEventArgs : NetworkedActivityEventArgs
	{
		public NetworkedActivityPlayer Player { get; }

		public NetworkedActivityPlayerEventArgs(NetworkedActivityScript activity, NetworkedActivityPlayer player)
			: base(activity)
		{
			Player = player;
		}
	}
}
