using System;

namespace ModApi.PlanetStudio.Events
{
	public class CelestialBodyUnloadedEventArgs : EventArgs
	{
		public bool ReloadingDueToManualXmlChange { get; }

		public CelestialBodyUnloadedEventArgs(bool reloadingDueToManualXmlChange)
		{
			ReloadingDueToManualXmlChange = reloadingDueToManualXmlChange;
		}
	}
}
