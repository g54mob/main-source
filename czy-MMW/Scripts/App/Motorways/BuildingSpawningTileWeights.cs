using System.Collections.Generic;
using FixMath;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	public class BuildingSpawningTileWeights
	{
		public Dictionary<Vector3Int, Fix64> weights;

		public BuildingSpawningTileWeights(Dictionary<Vector3Int, Fix64> weights)
		{
			this.weights = weights;
		}

		public BuildingSpawningTileWeights(Tilemap tilemap)
		{
			weights = new Dictionary<Vector3Int, Fix64>();
			foreach (Vector3Int item in tilemap.cellBounds.allPositionsWithin)
			{
				if (tilemap.GetTile(item) != null)
				{
					WeightTile weightTile = tilemap.GetTile(item) as WeightTile;
					if (weightTile != null)
					{
						weights[item] = (Fix64)weightTile.tileWeight;
					}
					else
					{
						weights[item] = Fix64.One;
					}
				}
			}
		}
	}
}
