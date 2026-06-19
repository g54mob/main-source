using System.Collections.Generic;
using UnityEngine;

namespace PugTilemap.Workshop
{
	public class Fill : Tool
	{
		private Workshop.Modification modification;

		private Vector2Int prevTileMouse;

		private HashSet<Vector2Int> visitedPositions = new HashSet<Vector2Int>();

		private bool clickedOwnTileType;

		private TileType clickedTileType;

		public Fill(Workshop ed)
			: base(ed, "Fill")
		{
		}

		public override void OnMouseDown()
		{
			if (modification == null)
			{
				modification = ed.UndoableModification("Fill");
			}
			RunFill();
		}

		public override void OnMouseDrag()
		{
			if (!(prevTileMouse == ed.tileMouse))
			{
				if (modification == null)
				{
					modification = ed.UndoableModification("Fill");
				}
				RunFill();
				prevTileMouse = ed.tileMouse;
			}
		}

		public override void OnMouseUp()
		{
			modification.Dispose();
			modification = null;
		}

		private void RunFill()
		{
			visitedPositions.Clear();
			Vector3Int vector3Int = new Vector3Int(ed.tileMouse.x, 0, ed.tileMouse.y);
			PugMapLayer pugMapLayer = ed.EnsureLayerPresentAt(vector3Int);
			clickedOwnTileType = pugMapLayer != null && ed.multiMap.IsTileTypeAt(vector3Int, pugMapLayer.def.dataTile);
			clickedTileType = ed.multiMap.GetSurfaceTileAt(vector3Int)?.info.tileType ?? TileType.none;
			RecursiveFill(ed.tileMouse, Vector2Int.zero);
			ed.multiMap.Build();
		}

		private void RecursiveFill(Vector2Int p, Vector2Int depth)
		{
			if (Mathf.Abs(depth.x) > 4 || Mathf.Abs(depth.y) > 4 || visitedPositions.Contains(p))
			{
				return;
			}
			visitedPositions.Add(p);
			Vector3Int vector3Int = new Vector3Int(p.x, 0, p.y);
			if (CanSpreadToTile(vector3Int))
			{
				if (Plot(vector3Int, ed.shift))
				{
					ed.multiMap.SetDirty(new Vector3Int(p.x, 0, p.y));
				}
				Vector2Int depth2 = depth + Vector2Int.up;
				RecursiveFill(p + Vector2Int.up, depth2);
				Vector2Int depth3 = depth + Vector2Int.right;
				RecursiveFill(p + Vector2Int.right, depth3);
				Vector2Int depth4 = depth + Vector2Int.down;
				RecursiveFill(p + Vector2Int.down, depth4);
				Vector2Int depth5 = depth + Vector2Int.left;
				RecursiveFill(p + Vector2Int.left, depth5);
			}
		}

		private bool CanSpreadToTile(Vector3Int pos)
		{
			PugMapLayer pugMapLayer = ed.EnsureLayerPresentAt(pos);
			if (!ed.shift)
			{
				if (pugMapLayer != null && pugMapLayer.def.dataTile == TileType.wall && clickedTileType != TileType.none)
				{
					TileData surfaceTileAt = ed.multiMap.GetSurfaceTileAt(pos);
					if (pugMapLayer != null)
					{
						if (pugMapLayer.def.dataTile == TileType.wall && surfaceTileAt != null)
						{
							if (!surfaceTileAt.info.tileType.IsWalkableTile())
							{
								return surfaceTileAt.info.tileType == TileType.wall;
							}
							return true;
						}
						return false;
					}
					return false;
				}
				if (clickedOwnTileType)
				{
					if (ed.multiMap.HasAnyTileAt(pos))
					{
						if (pugMapLayer != null)
						{
							if (!ed.multiMap.IsTileTypeAt(pos, pugMapLayer.def.dataTile))
							{
								if (pugMapLayer.def.dataTile == TileType.wall && ed.multiMap.GetSurfaceTileAt(pos).info.tileType.IsWalkableTile())
								{
									return ed.multiMap.GetObjects(pos).Count == 0;
								}
								return false;
							}
							return true;
						}
						return false;
					}
					return true;
				}
				if (ed.multiMap.HasAnyTileAt(pos))
				{
					if (pugMapLayer != null)
					{
						if (pugMapLayer.def.dataTile == TileType.wall && ed.multiMap.GetSurfaceTileAt(pos).info.tileType.IsWalkableTile())
						{
							return ed.multiMap.GetObjects(pos).Count == 0;
						}
						return false;
					}
					return false;
				}
				return true;
			}
			if (pugMapLayer != null && pugMapLayer.def.dataTile == TileType.wall && clickedTileType != TileType.none)
			{
				TileData surfaceTileAt2 = ed.multiMap.GetSurfaceTileAt(pos);
				if (ed.multiMap.HasAnyTileAt(pos) && (!(pugMapLayer != null) || !ed.multiMap.IsTileTypeAt(pos, pugMapLayer.def.dataTile)))
				{
					return surfaceTileAt2?.info.tileType.IsWalkableTile() ?? false;
				}
				return true;
			}
			if (ed.multiMap.HasAnyTileAt(pos))
			{
				if (pugMapLayer != null)
				{
					return ed.multiMap.IsTileTypeAt(pos, pugMapLayer.def.dataTile);
				}
				return false;
			}
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
				ed.multiMap.SetTile(p, pugMapLayer.tilesetKey, pugMapLayer.def.dataTile, rebuild: false);
				result = true;
			}
			for (int i = p.x - 1; i <= p.x + 1; i++)
			{
				for (int j = p.z - 1; j <= p.z + 1; j++)
				{
					ed.multiMap.SetDirty(new Vector3Int(i, 0, j));
				}
			}
			return result;
		}

		private bool ClearTilesAtPosition(Vector3Int p)
		{
			ed.multiMap.ClearTile(p, rebuild: false);
			return true;
		}

		private bool ClearTilesAtPosition(Vector3Int p, TileType t)
		{
			ed.multiMap.ClearTileOfType(p, t, rebuild: false);
			return true;
		}
	}
}
