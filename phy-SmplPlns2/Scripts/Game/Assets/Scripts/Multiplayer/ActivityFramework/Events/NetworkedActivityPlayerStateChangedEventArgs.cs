namespace Assets.Scripts.Multiplayer.ActivityFramework.Events
{
	public class NetworkedActivityPlayerStateChangedEventArgs : NetworkedActivityPlayerEventArgs
	{
		public NetworkedActivityPlayerState NewState { get; }

		public NetworkedActivityPlayerState PreviousState { get; }

		public NetworkedActivityPlayerStateChangedEventArgs(NetworkedActivityScript activity, NetworkedActivityPlayer player, NetworkedActivityPlayerState previousState, NetworkedActivityPlayerState newState)
			: base(activity, player)
		{
			PreviousState = previousState;
			NewState = newState;
		}
	}
}
