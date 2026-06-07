using System;
using Assets.Scripts.Craft;

namespace Assets.Scripts.Flight.Events
{
	public class FlightScenePlayerAircraftLoadCompletedEventArgs : EventArgs
	{
		public AircraftScript Aircraft { get; }

		public FlightScenePlayer Player { get; }

		public bool Success { get; }

		public FlightScenePlayerAircraftLoadCompletedEventArgs(FlightScenePlayer player, AircraftScript aircraft, bool success)
		{
			Player = player;
			Aircraft = aircraft;
			Success = success;
		}
	}
}
