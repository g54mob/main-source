using System;

namespace ModApi.PlanetStudio.Events
{
	public class CelestialBodyLoadingEventArgs : EventArgs
	{
		public bool ReloadingDueToManualXmlChange { get; }

		public CelestialBodyLoadingEventArgs(bool reloadingDueToManualXmlChange)
		{
			ReloadingDueToManualXmlChange = reloadingDueToManualXmlChange;
		}
	}
}
