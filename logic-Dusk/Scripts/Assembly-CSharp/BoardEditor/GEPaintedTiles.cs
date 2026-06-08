using System.Collections.Generic;
using UnityEngine;

namespace BoardEditor
{
	public class GEPaintedTiles
	{
		public List<TileData> tiles = new List<TileData>();

		private Table gameTable;

		public Color baseLightColor
		{
			get
			{
				return Color.white;
			}
		}

		public Color baseDarkColor
		{
			get
			{
				return Color.gray;
			}
		}

		public GEPaintedTiles(Table gameTable)
		{
			this.gameTable = gameTable;
			if (!(gameTable != null))
			{
			}
		}

		public void AddTile(int x, int y)
		{
			TileData tileData = gameTable.tiles[x, y];
			tiles.Add(tileData);
			tileData.currentTileGroupType = TileData.TileGroupEnum.Painted;
			tileData.currentTileType = TileData.TileTypeEnum.Standard;
			tileData.visualComponent.SetColor((!GameEditorScript.IsWhiteTile(tileData.boardPosition.x, tileData.boardPosition.y)) ? baseDarkColor : baseLightColor);
		}

		public void AddShadowTiles(GEShadow shadow)
		{
			if (!shadow.hasMoved)
			{
				return;
			}
			shadow.hasMoved = false;
			foreach (TileData tile in shadow.getTiles())
			{
				if (!tiles.Contains(tile))
				{
					tiles.Add(tile);
					tile.currentTileGroupType = TileData.TileGroupEnum.Painted;
					tile.currentTileType = TileData.TileTypeEnum.Standard;
					tile.visualComponent.SetColor((!GameEditorScript.IsWhiteTile(tile.boardPosition.x, tile.boardPosition.y)) ? Color.black : Color.white);
				}
			}
		}

		public void RemoveShadowTiles(GEShadow shadow)
		{
			if (!shadow.hasMoved)
			{
				return;
			}
			shadow.hasMoved = false;
			foreach (TileData tile in shadow.getTiles())
			{
				if (tiles.Contains(tile))
				{
					tiles.Remove(tile);
					tile.currentTileGroupType = TileData.TileGroupEnum.Undefined;
					tile.currentTileType = TileData.TileTypeEnum.Undefined;
					tile.visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
				}
			}
		}

		public void Clear()
		{
			tiles.Clear();
		}
	}
}
