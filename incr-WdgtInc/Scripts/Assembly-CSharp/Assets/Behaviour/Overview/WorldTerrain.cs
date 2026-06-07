using System;
using System.Collections.Generic;
using Assets.Source.UI;
using Assets.Source.World;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Behaviour.Overview
{
	public class WorldTerrain : MonoBehaviour, ITooltipTitleSource, ITooltipTextSource
	{
		[SerializeField]
		private Tilemap _tiles;

		[SerializeField]
		private GameObject _tilesetsList;

		private Dictionary<byte, TerrainTileSet> _tileSets;

		private string _currentTileName;

		private bool _currentTileBuildable;

		public Sprite GetTile(Vector2Int pos)
		{
			return _tiles.GetSprite(new Vector3Int(pos.x, pos.y));
		}

		private void Start()
		{
			foreach (KeyValuePair<Vector2Int, byte[,]> terrainBlock in WorldMap.Current.TerrainBlocks)
			{
				ShowBlock(terrainBlock.Key, terrainBlock.Value);
			}
		}

		public void ShowBlock(Vector2Int pos, byte[,] terrain)
		{
			if (_tileSets == null)
			{
				_tileSets = new Dictionary<byte, TerrainTileSet>();
				TerrainTileSet[] componentsInChildren = _tilesetsList.GetComponentsInChildren<TerrainTileSet>(includeInactive: true);
				foreach (TerrainTileSet terrainTileSet in componentsInChildren)
				{
					_tileSets.Add(terrainTileSet.TileID, terrainTileSet);
				}
			}
			SeededRandom seededRandom = new SeedGenerator().Add("WorldTerrain").Add(pos.x).Add(pos.y)
				.CreateRandom();
			int num = pos.x * 16;
			int num2 = pos.y * 16;
			int length = terrain.GetLength(0);
			int length2 = terrain.GetLength(1);
			for (int j = 0; j < length2 + length - 1; j++)
			{
				int num3 = Math.Min(j, length2 - 1);
				int num4 = Math.Max(0, j - length2 + 1);
				while (num3 >= 0 && num4 < length)
				{
					TerrainTileSet terrainTileSet2 = _tileSets[terrain[num4, num3]];
					bool flag = seededRandom.RandomBool(terrainTileSet2.DetailChance);
					SeededRandom seededRandom2 = new SeededRandom(seededRandom.RandomLong());
					TileBase tileBase;
					do
					{
						tileBase = seededRandom2.Choose(terrainTileSet2.DetailSprites);
					}
					while (_tiles.GetTile(new Vector3Int(num4 + num - 1, num3 + num2, 0)) == tileBase || _tiles.GetTile(new Vector3Int(num4 + num, num3 + num2 - 1, 0)) == tileBase);
					_tiles.SetTile(new Vector3Int(num4 + num, num3 + num2, 0), flag ? tileBase : terrainTileSet2.BaseSprite);
					num3--;
					num4++;
				}
			}
		}

		public string GetTooltipText()
		{
			if (!_currentTileBuildable)
			{
				return "@TerrainBlocksExpansion";
			}
			return null;
		}

		public string GetTooltipTitle()
		{
			return _currentTileName;
		}
	}
}
