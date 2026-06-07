using System;

namespace ModApi.PlanetStudio.Events
{
	public class CelestialBodyLoadedEventArgs : EventArgs
	{
		public bool ReloadingDueToManualXmlChange { get; }

		public CelestialBodyLoadedEventArgs(bool reloadingDueToManualXmlChange)
		{
			ReloadingDueToManualXmlChange = reloadingDueToManualXmlChange;
		}
	}
}
