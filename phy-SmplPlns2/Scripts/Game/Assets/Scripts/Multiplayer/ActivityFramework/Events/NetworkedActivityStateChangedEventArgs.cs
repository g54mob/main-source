namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityStateChangedEventArgs : NetworkedActivityEventArgs
	{
		public NetworkedActivityState State { get; }

		public NetworkedActivityStateChangedEventArgs(NetworkedActivityScript activity, NetworkedActivityState state)
			: base(activity)
		{
			State = state;
		}
	}
}
