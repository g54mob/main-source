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
			for (int j = 0; j < 16; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					TerrainTileSet terrainTileSet2 = _tileSets[terrain[j, k]];
					bool flag = seededRandom.RandomBool(terrainTileSet2.DetailChance);
					_tiles.SetTile(new Vector3Int(j + pos.x * 16, k + pos.y * 16, 0), flag ? seededRandom.Choose(terrainTileSet2.DetailSprites) : terrainTileSet2.BaseSprite);
				}
			}
		}

		public string GetTooltipText()
		{
			if (!_currentTileBuildable)
			{
				return "Blocks expansion of your factory.";
			}
			return null;
		}

		public string GetTooltipTitle()
		{
			return _currentTileName;
		}
	}
}
