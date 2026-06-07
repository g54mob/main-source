using System;

namespace Assets.Scripts.Multiplayer.Events
{
	public class NetworkPlayerEventArgs : EventArgs
	{
		public NetworkPlayerScript Player { get; }

		public NetworkPlayerEventArgs(NetworkPlayerScript player)
		{
			Player = player;
		}
	}
}
