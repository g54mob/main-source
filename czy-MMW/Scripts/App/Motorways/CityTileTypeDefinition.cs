using System;
using UnityEngine.Tilemaps;

namespace Motorways
{
	[Serializable]
	public struct CityTileTypeDefinition
	{
		public CityTileType type;

		public int groupIndex;

		public Tilemap tiles;
	}
}
