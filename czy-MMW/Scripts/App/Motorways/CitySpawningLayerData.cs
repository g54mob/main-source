using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	public class CitySpawningLayerData
	{
		public Dictionary<int, BuildingSpawningTileWeights> weights = new Dictionary<int, BuildingSpawningTileWeights>();

		public BuildingSpawningTileWeights stationWeights;

		public BuildingSpawningTileWeights boatTerminalWeights;

		public CitySpawningLayerData()
		{
		}

		public CitySpawningLayerData(List<CityTileTypeDefinition> definitions, Tilemap stationTiles, Tilemap boatTerminalTiles)
		{
			foreach (CityTileTypeDefinition definition in definitions)
			{
				weights[CityTilemap.LayerIdFor(definition.type, definition.groupIndex)] = new BuildingSpawningTileWeights(definition.tiles);
			}
			if ((Object)(object)stationTiles != null)
			{
				stationWeights = new BuildingSpawningTileWeights(stationTiles);
			}
			if ((Object)(object)boatTerminalTiles != null)
			{
				boatTerminalWeights = new BuildingSpawningTileWeights(boatTerminalTiles);
			}
		}
	}
}
