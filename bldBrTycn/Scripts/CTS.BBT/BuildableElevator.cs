using System.Collections.Generic;
using UnityEngine;

public class BuildableElevator : BuildableElement
{
	[SerializeField]
	private Vector2Int[] _environnementCell;

	[SerializeField]
	private Vector2Int[] _overrideCell;

	private List<ConstructionCell> _overridedCell = new List<ConstructionCell>();

	public override bool CanBePlaced(BuildingWall wall)
	{
		return ScanCellsZone(wall);
	}

	private bool ScanCellsZone(BuildingWall wall)
	{
		ConstructionGrid linkedGrid = wall.LinkedCell.LinkedGrid;
		for (int i = 0; i < _environnementCell.Length; i++)
		{
			Vector2Int coordinate = GetPositionFromRotation(wall.RotationAngle, _environnementCell[i]) + wall.LinkedCell.Coordinate;
			if (coordinate.x <= 0 || coordinate.x >= linkedGrid.GetGridSize.x - 1)
			{
				return false;
			}
			if (coordinate.y <= 0 || coordinate.y >= linkedGrid.GetGridSize.y - 1)
			{
				return false;
			}
			if (linkedGrid.GetCell(coordinate) == null || linkedGrid.GetCell(coordinate).BuildableElement != null)
			{
				return false;
			}
		}
		return true;
	}

	public override void OnPlaced(BuildingWall wall)
	{
		ConstructionGrid linkedGrid = wall.LinkedCell.LinkedGrid;
		List<Vector2Int> list = new List<Vector2Int>();
		for (int i = 0; i < _environnementCell.Length; i++)
		{
			Vector2Int item = GetPositionFromRotation(wall.RotationAngle, _environnementCell[i]) + wall.LinkedCell.Coordinate;
			list.Add(item);
		}
		linkedGrid.AddZone(list.ToArray(), EConstructionMode.Construction);
		for (int j = 0; j < list.Count; j++)
		{
			ConstructionCell cell = linkedGrid.GetCell(list[j]);
			if (cell != null)
			{
				_overridedCell.Add(cell);
				cell.BuildableElement = this;
				cell.OverridableCell = false;
			}
		}
	}

	protected override void BeforeDestoy()
	{
		for (int i = 0; i < _overridedCell.Count; i++)
		{
			_overridedCell[i].BuildableElement = null;
			_overridedCell[i].OverridableCell = true;
			_overridedCell[i].NordWall?.SurfaceObject.ResetCutter();
			_overridedCell[i].EastWall?.SurfaceObject.ResetCutter();
			_overridedCell[i].SouthWall?.SurfaceObject.ResetCutter();
			_overridedCell[i].WestWall?.SurfaceObject.ResetCutter();
		}
		_overridedCell.Clear();
		base.BeforeDestoy();
	}

	private static Vector2Int GetPositionFromRotation(ERotationAngle rotation, Vector2Int position)
	{
		return rotation switch
		{
			ERotationAngle.Nord => position, 
			ERotationAngle.East => new Vector2Int(position.y, position.x * -1), 
			ERotationAngle.South => position * -1, 
			ERotationAngle.West => new Vector2Int(position.y * -1, position.x), 
			_ => position, 
		};
	}
}
