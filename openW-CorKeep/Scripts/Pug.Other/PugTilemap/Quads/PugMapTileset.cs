using System;
using System.Collections.Generic;
using UnityEngine;

namespace PugTilemap.Quads
{
	[CreateAssetMenu(fileName = "New PugMapTileset", menuName = "Pug/PugMap/Tileset", order = 1)]
	public class PugMapTileset : ScriptableObject
	{
		public Material tilesetMaterial;

		public Texture2D tilesetTexture;

		public List<QuadGenerator> layers = new List<QuadGenerator>();

		private Dictionary<TileType, QuadGenerator> defTileCache = new Dictionary<TileType, QuadGenerator>();

		private Dictionary<LayerName, QuadGenerator> defKeyCache = new Dictionary<LayerName, QuadGenerator>();

		[NonSerialized]
		public readonly int[] layerByTile = new int[256];

		public QuadGenerator GetDef(TileType tile)
		{
			if (defTileCache.ContainsKey(tile))
			{
				return defTileCache[tile];
			}
			QuadGenerator quadGenerator = null;
			for (int i = 0; i < layers.Count; i++)
			{
				if (layers[i].dataTile == tile)
				{
					quadGenerator = layers[i];
					break;
				}
			}
			if (quadGenerator != null)
			{
				defTileCache.Add(tile, quadGenerator);
			}
			return quadGenerator;
		}

		public QuadGenerator GetDef(LayerName key)
		{
			if (defKeyCache.ContainsKey(key))
			{
				return defKeyCache[key];
			}
			QuadGenerator quadGenerator = null;
			for (int i = 0; i < layers.Count; i++)
			{
				if (layers[i].layerName == key)
				{
					quadGenerator = layers[i];
					break;
				}
			}
			if (quadGenerator != null)
			{
				defKeyCache.Add(key, quadGenerator);
			}
			return quadGenerator;
		}

		public void InitLookupTables()
		{
			for (int i = 0; i < layerByTile.Length; i++)
			{
				layerByTile[i] = -1;
			}
			for (int j = 0; j < layers.Count; j++)
			{
				layers[j].layersDependentOnMyData.Clear();
			}
			for (int k = 0; k < layers.Count; k++)
			{
				QuadGenerator quadGenerator = layers[k];
				if (quadGenerator.dataTile != TileType.none)
				{
					layerByTile[(int)layers[k].dataTile] = k;
				}
				if (quadGenerator.targetTile != TileType.none)
				{
					QuadGenerator quadGenerator2 = null;
					for (int l = 0; l < layers.Count; l++)
					{
						if (layers[l].dataTile == quadGenerator.targetTile || (quadGenerator.dontAdaptIfTilePresent != TileType.none && layers[l].dataTile == quadGenerator.dontAdaptIfTilePresent))
						{
							quadGenerator2 = layers[l];
							break;
						}
					}
					if (quadGenerator2 == null)
					{
						Debug.LogWarning("!!!! EXTRUDE FROM LAYER RETURNED NULL !!!!");
						continue;
					}
					quadGenerator2.layersDependentOnMyData.Add(quadGenerator);
					if (!quadGenerator2.isDataLayer)
					{
						Debug.LogError("can only extrude from data layer");
					}
				}
				if (quadGenerator.dontAdaptIfTilePresent == TileType.none)
				{
					continue;
				}
				QuadGenerator quadGenerator3 = null;
				for (int m = 0; m < layers.Count; m++)
				{
					if (layers[m].dataTile == quadGenerator.dontAdaptIfTilePresent)
					{
						quadGenerator3 = layers[m];
						break;
					}
				}
				if (quadGenerator3 == null)
				{
					Debug.LogWarning("!!!! LAYER AFFECTED BY ME RETURNED NULL WHEN dontAdaptIfTilePresent IS SET FOR " + quadGenerator.layerName);
				}
				else
				{
					quadGenerator3.layersDependentOnMyData.Add(quadGenerator);
				}
			}
		}
	}
}
