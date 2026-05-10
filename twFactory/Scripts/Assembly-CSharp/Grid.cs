using System.Collections.Generic;
using LightTower;
using UnityEngine;

public class Grid
{
	private GridCell[,] cells;

	private List<PathTile> pathTiles = new List<PathTile>();

	public Grid(int gridSizeX, int gridSizeZ)
	{
		cells = new GridCell[gridSizeX, gridSizeZ];
	}

	public Grid(int gridSizeX, int gridSizeZ, Tile[] tiles)
	{
		cells = new GridCell[gridSizeX, gridSizeZ];
		AddGridCells(tiles);
	}

	public Vector2Int GetGridSize()
	{
		return new Vector2Int(cells.GetLength(0), cells.GetLength(1));
	}

	public void AddGridCell(Tile tile)
	{
		if (tile.TileType != Tile.ETileType.Border)
		{
			GridCell gridCell = new GridCell();
			gridCell.Tile = tile;
			cells[Mathf.RoundToInt(tile.transform.position.x), Mathf.RoundToInt(tile.transform.position.z)] = gridCell;
			if (tile.TileType == Tile.ETileType.Path)
			{
				pathTiles.Add(tile as PathTile);
			}
		}
	}

	public void AddGridCells(Tile[] tiles)
	{
		foreach (Tile tile in tiles)
		{
			AddGridCell(tile);
		}
	}

	public GridCell GetGridCell(int xIdx, int yIdx)
	{
		if (IsPositionInGrid(new Vector3(xIdx, 0f, yIdx)))
		{
			return cells[xIdx, yIdx];
		}
		return null;
	}

	public GridCell GetGridCell(Vector3 position)
	{
		Vector3 vector = SnapPositionToGrid(position);
		return GetGridCell((int)vector.x, (int)vector.z);
	}

	public GridCell GetAdjacentGridCell(Transform transform, EOrientation orientation, bool localOrientation = true)
	{
		return GetAdjacentGridCell(transform.position, transform.rotation, orientation, localOrientation);
	}

	public GridCell GetAdjacentGridCell(Vector3 position, Quaternion rotation, EOrientation orientation, bool localOrientation = true)
	{
		if (localOrientation)
		{
			orientation = LTFunctionLibrary.OrientationToWorldSpace(orientation, rotation.eulerAngles.y);
		}
		return GetGridCell(position + LTFunctionLibrary.GetDirectionFromOrientation(orientation));
	}

	public GameplayObject GetAdjacentBuiltObject(Transform transform, EOrientation orientation, bool localOrientation = true, bool forceGetMainObject = false)
	{
		GridCell adjacentGridCell = GetAdjacentGridCell(transform, orientation, localOrientation);
		if (adjacentGridCell != null && (bool)adjacentGridCell.BuiltObject)
		{
			if (!forceGetMainObject)
			{
				return adjacentGridCell.BuiltObject.GetObjectByPosition(transform.position);
			}
			return adjacentGridCell.BuiltObject.MainObject;
		}
		return null;
	}

	public T GetAdjacentBuiltObject<T>(Transform transform, EOrientation orientation, bool localOrientation = true, bool forceGetMainObject = false) where T : GameplayObject
	{
		return GetAdjacentBuiltObject(transform, orientation, localOrientation, forceGetMainObject) as T;
	}

	public List<GridCell> GetAdjacentGridCells(Vector3 position)
	{
		List<GridCell> list = new List<GridCell>();
		list.Add(GetGridCell(position + LTFunctionLibrary.GetDirectionFromOrientation(EOrientation.North)));
		list.Add(GetGridCell(position + LTFunctionLibrary.GetDirectionFromOrientation(EOrientation.East)));
		list.Add(GetGridCell(position + LTFunctionLibrary.GetDirectionFromOrientation(EOrientation.South)));
		list.Add(GetGridCell(position + LTFunctionLibrary.GetDirectionFromOrientation(EOrientation.West)));
		list.RemoveAll((GridCell x) => x == null);
		return list;
	}

	public List<GameplayObject> GetAdjacentBuiltObjects(Vector3 position, bool forceGetMainObject = false)
	{
		List<GameplayObject> list = new List<GameplayObject>();
		foreach (GridCell adjacentGridCell in GetAdjacentGridCells(position))
		{
			if (adjacentGridCell.BuiltObject != null)
			{
				list.Add(forceGetMainObject ? adjacentGridCell.BuiltObject.MainObject : adjacentGridCell.BuiltObject.GetObjectByPosition(position));
			}
		}
		return list;
	}

	public List<T> GetAdjacentBuiltObjects<T>(Vector3 position, bool forceGetMainObject = false) where T : GameplayObject
	{
		List<T> list = new List<T>();
		foreach (GameplayObject adjacentBuiltObject in GetAdjacentBuiltObjects(position, forceGetMainObject))
		{
			if (adjacentBuiltObject is T)
			{
				list.Add(adjacentBuiltObject as T);
			}
		}
		return list;
	}

	public List<GameplayObject> GetAdjacentBuiltObjects(Transform transform, bool forceGetMainObject = false)
	{
		return GetAdjacentBuiltObjects(transform.position, forceGetMainObject);
	}

	public List<T> GetAdjacentBuiltObjects<T>(Transform transform, bool forceGetMainObject = false) where T : GameplayObject
	{
		return GetAdjacentBuiltObjects<T>(transform.position, forceGetMainObject);
	}

	public Vector3Int SnapPositionToGrid(Vector3 position)
	{
		Vector3Int zero = Vector3Int.zero;
		zero.x = Mathf.RoundToInt(position.x);
		zero.y = Mathf.RoundToInt(position.y);
		zero.z = Mathf.RoundToInt(position.z);
		return zero;
	}

	public bool IsPositionInGrid(Vector3 position)
	{
		Vector2Int gridSize = GetGridSize();
		if (position.x >= 0f && position.x < (float)gridSize.x && position.z >= 0f)
		{
			return position.z < (float)gridSize.y;
		}
		return false;
	}

	public void UpdatePathTilesVisibility()
	{
		foreach (PathTile pathTile in pathTiles)
		{
			pathTile.IsVisible = LTFunctionLibrary.GetFogOfWarController().IsPositionVisible(pathTile.transform.position);
		}
	}
}
