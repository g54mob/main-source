using System.Collections.Generic;
using UnityEngine;

namespace PugTilemap.Quads
{
	public class QuadCache
	{
		public BoundsInt bounds { get; private set; }

		public Dictionary<Vector3Int, Quad> quads { get; private set; } = new Dictionary<Vector3Int, Quad>();

		public void ResolveQuads(PugMultiMap multiMap, PugMap map, PugMapLayer sourceLayer, List<TileData>[,] tileLookup, HashSet<Vector3Int> positionsChangedSinceLastBuild, BoundsInt bounds)
		{
			foreach (Vector3Int item in positionsChangedSinceLastBuild)
			{
				Vector3Int vector3Int = map.LocalCoordToTileLookUpPosition(item.x, item.z);
				List<TileData> list = tileLookup[vector3Int.x, vector3Int.z];
				bool flag = quads.ContainsKey(item);
				Quad q = ((!flag) ? new Quad(item) : quads[item]);
				sourceLayer.def.ResolveQuad(multiMap, map, sourceLayer, ref q, list.GetEnumerator());
				if (flag && q.hasSprite)
				{
					quads[item] = q;
				}
				else if (!flag && q.hasSprite)
				{
					quads.Add(item, q);
				}
				else if (flag && !q.hasSprite)
				{
					quads.Remove(item);
				}
			}
		}
	}
}
