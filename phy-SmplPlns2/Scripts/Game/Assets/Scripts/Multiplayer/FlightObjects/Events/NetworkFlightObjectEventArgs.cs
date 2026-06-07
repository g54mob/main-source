using System;

namespace Assets.Scripts.Multiplayer.FlightObjects.Events
{
	public class NetworkFlightObjectEventArgs : EventArgs
	{
		public NetworkFlightObject Object { get; }

		public NetworkFlightObjectEventArgs(NetworkFlightObject obj)
		{
			Object = obj;
		}
	}
}
