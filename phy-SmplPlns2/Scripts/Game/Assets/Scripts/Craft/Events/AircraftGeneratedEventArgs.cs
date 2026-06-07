using System;

namespace Assets.Scripts.Craft.Events
{
	public class AircraftGeneratedEventArgs : EventArgs
	{
		public AircraftScript AircraftScript { get; private set; }

		public AircraftGeneratedEventArgs(AircraftScript aircraftScript)
		{
			AircraftScript = aircraftScript;
		}
	}
}
