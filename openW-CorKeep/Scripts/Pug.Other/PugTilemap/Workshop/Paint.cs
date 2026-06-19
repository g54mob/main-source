using UnityEngine;

namespace PugTilemap.Workshop
{
	public class Paint : Tool
	{
		private SpriteRenderer floatingPiece;

		private Vector2Int prevTileMouse;

		private Workshop.Modification modification;

		public Paint(Workshop ed)
			: base(ed, "Paint")
		{
		}

		public override void OnEnable()
		{
			floatingPiece = ed.CreateFloatingPiece();
			floatingPiece.sprite = ed.sprites["editor dirt"];
			floatingPiece.transform.eulerAngles = new Vector3(90f, 0f, 0f);
		}

		public override void OnDisable()
		{
			if (floatingPiece != null)
			{
				Object.DestroyImmediate(floatingPiece.gameObject);
			}
		}

		public override void OnMouseMove()
		{
			UpdateFloatingPiece();
		}

		public void UpdateFloatingPiece()
		{
			floatingPiece.transform.localPosition = new Vector3(ed.tileMouse.x, 0f, ed.tileMouse.y);
			string key = ed.tile.ToString().ToLower() + " " + ed.currentTileset;
			if (ed.spritesByTile.ContainsKey(key))
			{
				floatingPiece.sprite = ed.spritesByTile[key];
			}
			else
			{
				floatingPiece.sprite = ed.spritesByTile[ed.tile.ToString().ToLower()];
			}
		}

		public override void OnMouseDown()
		{
			modification = ed.UndoableModification("paint");
			floatingPiece.gameObject.SetActive(value: false);
			prevTileMouse = ed.tileMouse - Vector2Int.right;
			OnMouseDrag();
		}

		private bool ClearTilesAtPosition(Vector3Int p)
		{
			ed.multiMap.ClearTile(p);
			return true;
		}

		private bool ClearTilesAtPosition(Vector3Int p, TileType t)
		{
			ed.multiMap.ClearTileOfType(p, t);
			return true;
		}

		private bool Plot(Vector3Int p, bool erase)
		{
			bool result = false;
			PugMapLayer pugMapLayer = ed.EnsureLayerPresentAt(p);
			if (pugMapLayer == null)
			{
				return result;
			}
			if (erase)
			{
				result = ClearTilesAtPosition(p, ed.tile) || ClearTilesAtPosition(p);
			}
			else
			{
				ed.multiMap.SetTile(p, pugMapLayer.tilesetKey, pugMapLayer.def.dataTile);
				result = true;
			}
			for (int i = p.x - 1; i <= p.x + 1; i++)
			{
				for (int j = p.z - 1; j <= p.z + 1; j++)
				{
					ed.multiMap.SetDirty(new Vector3Int(i, 0, j));
				}
			}
			ed.multiMap.Build();
			return result;
		}

		public override void OnMouseDrag()
		{
			if (prevTileMouse == ed.tileMouse)
			{
				return;
			}
			bool flag = false;
			Bresenham enumerator = new Bresenham(prevTileMouse, ed.tileMouse).GetEnumerator();
			while (enumerator.MoveNext())
			{
				Vector2Int current = enumerator.Current;
				Vector3Int p = new Vector3Int(current.x, 0, current.y);
				if (Plot(p, ed.shift))
				{
					ed.multiMap.SetDirty(new Vector3Int(current.x, 0, current.y));
					flag = true;
				}
			}
			prevTileMouse = ed.tileMouse;
			if (flag)
			{
				ed.multiMap.Build();
			}
		}

		public override void OnMouseUp()
		{
			modification.Dispose();
			modification = null;
			floatingPiece.gameObject.SetActive(value: true);
			UpdateFloatingPiece();
		}
	}
}
