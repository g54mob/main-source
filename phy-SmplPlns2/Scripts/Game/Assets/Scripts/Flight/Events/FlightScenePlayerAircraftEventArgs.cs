using System;
using Assets.Scripts.Craft;

namespace Assets.Scripts.Flight.Events
{
	public class FlightScenePlayerAircraftEventArgs : EventArgs
	{
		public AircraftScript Aircraft { get; }

		public FlightScenePlayer Player { get; }

		public FlightScenePlayerAircraftEventArgs(FlightScenePlayer player, AircraftScript aircraft)
		{
			Player = player;
			Aircraft = aircraft;
		}
	}
}
