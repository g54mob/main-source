using System;

namespace Assets.Scripts.Flight.GameView.Planet.Events
{
	public class PlanetScriptEventArgs : EventArgs
	{
		public PlanetScript PlanetScript { get; }

		public PlanetScriptEventArgs(PlanetScript planetScript)
		{
			PlanetScript = planetScript;
		}
	}
}
