using System.Collections.Generic;
using UnityEngine;

namespace BoardEditor
{
	public class GECorridorCollection
	{
		public delegate void MouseOverCorriorEventHandler(GECorridorCollection corridor);

		public delegate void MouseDownCorriorEventHandler(GECorridorCollection corridor);

		public bool isMouseOver { get; private set; }

		public bool isMouseDown { get; private set; }

		public IGEObject obj1 { get; set; }

		public IGEObject obj2 { get; set; }

		public GECorridor.CorridorLayoutEnum corridorLayout { get; set; }

		public int corridorLength { get; set; }

		public List<TileData> tiles { get; set; }

		public event MouseOverCorriorEventHandler MouseOverCorriorEvent;

		public event MouseDownCorriorEventHandler MouseDownCorriorEvent;

		public GECorridorCollection()
		{
			tiles = new List<TileData>();
		}

		public void AddTile(TileData tile)
		{
			tiles.Add(tile);
			tile.visualComponent.MouseEnterTileEvent += HandleTileMouseEnterTileEvent;
			tile.visualComponent.MouseDownOnTileEvent += HandleTileMouseDownOnTileEvent;
		}

		public void ClearTiles()
		{
			if (tiles == null)
			{
				return;
			}
			foreach (TileData tile in tiles)
			{
				tile.visualComponent.MouseEnterTileEvent -= HandleTileMouseEnterTileEvent;
				tile.visualComponent.ClearTileHighLightColor("corridor tint");
				tile.visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
			}
			tiles.Clear();
		}

		public void MouseLeftCorridor()
		{
			if (tiles != null)
			{
				foreach (TileData tile in tiles)
				{
					tile.visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
					tile.visualComponent.SetTileHighLightColor(Color.blue, 0.5f, "corridor tint");
				}
			}
			isMouseOver = false;
			isMouseDown = false;
		}

		public List<Vector2> GetTilePositions()
		{
			List<Vector2> list = new List<Vector2>();
			if (tiles != null)
			{
				foreach (TileData tile in tiles)
				{
					list.Add(new Vector2(tile.boardPosition.x, tile.boardPosition.y));
				}
			}
			return list;
		}

		private void HandleTileMouseEnterTileEvent(TileData tile)
		{
			if (isMouseOver)
			{
				return;
			}
			isMouseOver = true;
			foreach (TileData tile2 in tiles)
			{
				Color color = ((!GameEditorScript.IsWhiteTile(tile2.boardPosition.x, tile2.boardPosition.y)) ? Color.green : Color.white);
				tile.visualComponent.SetTileHighLightColor(color, 0.1f, "corridor tint");
			}
			if (this.MouseOverCorriorEvent != null)
			{
				this.MouseOverCorriorEvent(this);
			}
		}

		private void HandleTileMouseDownOnTileEvent(TileData tile)
		{
			if (!isMouseDown)
			{
				if (this.MouseDownCorriorEvent != null)
				{
					this.MouseDownCorriorEvent(this);
				}
				isMouseDown = true;
			}
		}
	}
}
