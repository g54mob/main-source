using System;

namespace ModApi.PlanetStudio.Events
{
	public class CelestialBodyUnloadingEventArgs : EventArgs
	{
		public bool ReloadingDueToManualXmlChange { get; }

		public CelestialBodyUnloadingEventArgs(bool reloadingDueToManualXmlChange)
		{
			ReloadingDueToManualXmlChange = reloadingDueToManualXmlChange;
		}
	}
}
