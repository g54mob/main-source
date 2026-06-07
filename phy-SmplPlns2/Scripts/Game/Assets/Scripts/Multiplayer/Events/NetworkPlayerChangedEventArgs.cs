using System;

namespace Assets.Scripts.Multiplayer.Events
{
	public class NetworkPlayerChangedEventArgs : EventArgs
	{
		public NetworkPlayerScript NewPlayer { get; }

		public NetworkPlayerScript PreviousPlayer { get; }

		public NetworkPlayerChangedEventArgs(NetworkPlayerScript previousPlayer, NetworkPlayerScript newPlayer)
		{
			PreviousPlayer = previousPlayer;
			NewPlayer = newPlayer;
		}
	}
}
