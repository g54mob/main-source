using System;

namespace ModApi.PlanetStudio.Events
{
	public class CelestialBodyViewRefreshedEventArgs : EventArgs
	{
		public bool CleanGeneratedData { get; }

		public CelestialBodyViewRefreshedEventArgs(bool cleanGeneratedData)
		{
			CleanGeneratedData = cleanGeneratedData;
		}
	}
}
