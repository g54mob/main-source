using System;

namespace ModApi.Flight.Events
{
	public class FlightEndedEventArgs : EventArgs
	{
		public FlightSceneExitReason ExitReason { get; }

		public FlightEndedEventArgs(FlightSceneExitReason exitReason)
		{
			ExitReason = exitReason;
		}
	}
}
