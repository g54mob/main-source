using System;

namespace ModApi.Planet.Events
{
	public class PlanetTerrainDataEventArgs : EventArgs
	{
		public PlanetTerrainDataScript TerrainData { get; }

		public PlanetTerrainDataEventArgs(PlanetTerrainDataScript terrainData)
		{
			TerrainData = terrainData;
		}
	}
}
