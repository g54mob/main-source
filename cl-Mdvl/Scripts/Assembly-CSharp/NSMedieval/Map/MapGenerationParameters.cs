using NSMedieval.Model.MapNew;
using UnityEngine;

namespace NSMedieval.Map
{
	public class MapGenerationParameters
	{
		public MapSize MapSize { get; }

		public NSMedieval.Model.MapNew.Map MapType { get; }

		public string MapSeed { get; }

		public Vector2Int WorldMapPosition { get; }

		public MapGenerationParameters(NSMedieval.Model.MapNew.Map mapType, MapSize mapSize, string mapSeed, Vector2Int worldMapPosition)
		{
			MapType = mapType;
			MapSeed = mapSeed;
			WorldMapPosition = worldMapPosition;
			MapSize = mapSize;
		}

		public bool Equals(MapGenerationParameters other)
		{
			if (other == null)
			{
				return false;
			}
			if (MapSize == other.MapSize && MapType == other.MapType && MapSeed == other.MapSeed)
			{
				return WorldMapPosition == other.WorldMapPosition;
			}
			return false;
		}

		public override string ToString()
		{
			return $"[{MapSize?.GetID()}, {MapType?.GetID()}, seed: {MapSeed}, world map pos: {WorldMapPosition}]";
		}
	}
}
