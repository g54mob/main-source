using System;
using FishNet.Connection;

namespace Assets.Scripts.Multiplayer.Events
{
	public class NetworkConnectionEventArgs : EventArgs
	{
		public NetworkConnection NetworkConnection { get; }

		public NetworkConnectionEventArgs(NetworkConnection networkConnection)
		{
			NetworkConnection = networkConnection;
		}
	}
}
