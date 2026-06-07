using System;
using ModApi.Planet;

namespace ModApi.Flight.Sim.Events
{
	public class PlanetNodeTerrainDataEventArgs : EventArgs
	{
		public IPlanetData PlanetData { get; }

		public IPlanetNode PlanetNode { get; }

		public IPlanetTerrainData TerrainData { get; }

		public ITerrainGenerator TerrainGenerator { get; }

		public PlanetNodeTerrainDataEventArgs(IPlanetNode planetNode)
		{
			PlanetNode = planetNode;
			PlanetData = planetNode.PlanetData;
			TerrainGenerator = planetNode.TerrainGenerator;
			TerrainData = planetNode.TerrainGenerator?.TerrainData;
		}
	}
}
