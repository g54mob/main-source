using System;
using Assets.Scripts.Craft;

namespace Assets.Scripts.Flight.Events
{
	public class AircraftKilledEventArgs : EventArgs
	{
		public AircraftScript Aircraft { get; }

		public int? KillerId { get; }

		public AircraftKilledEventArgs(AircraftScript aircraft, int? killerId)
		{
			Aircraft = aircraft;
			KillerId = killerId;
		}
	}
}
