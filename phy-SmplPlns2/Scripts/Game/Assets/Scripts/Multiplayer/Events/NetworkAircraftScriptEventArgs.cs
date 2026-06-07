using System;

namespace Assets.Scripts.Multiplayer.Events
{
	public class NetworkAircraftScriptEventArgs : EventArgs
	{
		public NetworkAircraftScript Craft { get; }

		public NetworkAircraftScriptEventArgs(NetworkAircraftScript craft)
		{
			Craft = craft;
		}
	}
}
