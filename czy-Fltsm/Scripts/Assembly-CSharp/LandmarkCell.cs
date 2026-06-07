using System;
using PajamaLlama.Enums;
using UnityEngine;

public class LandmarkCell
{
	public const int NEIGHBOR_LEFT = 0;

	public const int NEIGHBOR_RIGHT = 1;

	public const int NEIGHBOR_BOTTOM = 2;

	public const int NEIGHBOR_TOP = 3;

	private LandmarkCellData _data;

	private LandmarkCellType _cellType;

	private CardinalDirectionFlags _possibleEntranceDirections;

	public LandmarkCellType CellType
	{
		get
		{
			return _cellType;
		}
		set
		{
			_cellType = value;
		}
	}

	public LandmarkCell[] Neighbors { get; private set; }

	public bool IsReserved { get; set; }

	public Vector3 Position => _data.Position;

	public int RowPos { get; }

	public int ColumnPos { get; }

	public bool IsRoad
	{
		get
		{
			if (_cellType != LandmarkCellType.Road)
			{
				return _cellType == LandmarkCellType.Entrance;
			}
			return true;
		}
	}

	public HorizontalVerticalFlags RoadOrientation { get; private set; }

	public CardinalDirectionFlags EntranceDirection { get; private set; }

	public int EntranceClearance { get; private set; }

	public bool IsBorder { get; private set; }

	public int SignedDistanceFieldValue { get; private set; }

	public bool IsPossibleEntrance => _possibleEntranceDirections != CardinalDirectionFlags.None;

	public LandmarkCell(int rowPos, int columnPos, LandmarkCellData data)
	{
		RowPos = rowPos;
		ColumnPos = columnPos;
		_data = data;
		_cellType = data.Type;
	}

	public void Initialize(LandmarkGrid landmarkGrid)
	{
		Neighbors = new LandmarkCell[4]
		{
			landmarkGrid.ReturnCell(RowPos, ColumnPos - 1),
			landmarkGrid.ReturnCell(RowPos, ColumnPos + 1),
			landmarkGrid.ReturnCell(RowPos - 1, ColumnPos),
			landmarkGrid.ReturnCell(RowPos + 1, ColumnPos)
		};
		IsReserved = false;
		IsBorder = ReturnIsBorder(landmarkGrid);
		PopulatePossibleEntranceDirections();
	}

	public void AddRoadOrientation(HorizontalVerticalFlags orientation)
	{
		LandmarkCellType cellType = _cellType;
		if (cellType == LandmarkCellType.Road || cellType == LandmarkCellType.Entrance)
		{
			RoadOrientation |= orientation;
			return;
		}
		throw new NotSupportedException();
	}

	public void ComputeDistanceFieldValue()
	{
		if (!IsBorder && CellType != LandmarkCellType.Empty)
		{
			int num = int.MaxValue;
			if (TryReturnDistanceToBorder(3, out var distance) && distance < num)
			{
				num = distance;
			}
			if (TryReturnDistanceToBorder(1, out distance) && distance < num)
			{
				num = distance;
			}
			if (TryReturnDistanceToBorder(2, out distance) && distance < num)
			{
				num = distance;
			}
			if (TryReturnDistanceToBorder(0, out distance) && distance < num)
			{
				num = distance;
			}
			SignedDistanceFieldValue = ((CellType == LandmarkCellType.Empty) ? num : (-num));
		}
	}

	private bool TryReturnDistanceToBorder(int neighborIndex, out int distance)
	{
		LandmarkCell landmarkCell = Neighbors[neighborIndex];
		distance = 1;
		while (landmarkCell != null)
		{
			if (landmarkCell.IsBorder)
			{
				return true;
			}
			distance++;
			landmarkCell = landmarkCell.Neighbors[neighborIndex];
		}
		return false;
	}

	private void PopulatePossibleEntranceDirections()
	{
		if (_cellType != LandmarkCellType.Empty)
		{
			TryAddPossibleEntranceDirection(3, CardinalDirectionFlags.North);
			TryAddPossibleEntranceDirection(1, CardinalDirectionFlags.East);
			TryAddPossibleEntranceDirection(2, CardinalDirectionFlags.South);
			TryAddPossibleEntranceDirection(0, CardinalDirectionFlags.West);
		}
	}

	private void TryAddPossibleEntranceDirection(int neighborIndex, CardinalDirectionFlags entranceDirection)
	{
		LandmarkCell landmarkCell = Neighbors[neighborIndex];
		if (landmarkCell == null || landmarkCell._cellType == LandmarkCellType.Empty)
		{
			_possibleEntranceDirections |= entranceDirection;
		}
	}

	public void ComputeEntranceDirectionAndClearance()
	{
		EntranceDirection = CardinalDirectionFlags.None;
		EntranceClearance = 0;
		for (CardinalDirectionFlags cardinalDirectionFlags = CardinalDirectionFlags.North; cardinalDirectionFlags <= CardinalDirectionFlags.West; cardinalDirectionFlags = (CardinalDirectionFlags)((int)cardinalDirectionFlags << 1))
		{
			int num = ReturnEntranceClearance(cardinalDirectionFlags);
			if (EntranceClearance < num)
			{
				EntranceDirection = cardinalDirectionFlags;
				EntranceClearance = num;
			}
		}
	}

	private int ReturnEntranceClearance(CardinalDirectionFlags direction)
	{
		if (!_possibleEntranceDirections.IsFlagSet(direction))
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		switch (direction)
		{
		case CardinalDirectionFlags.North:
		case CardinalDirectionFlags.South:
			num2 = ReturnEntranceNeighborCount(0, direction);
			num = ReturnEntranceNeighborCount(1, direction);
			break;
		case CardinalDirectionFlags.East:
		case CardinalDirectionFlags.West:
			num2 = ReturnEntranceNeighborCount(2, direction);
			num = ReturnEntranceNeighborCount(3, direction);
			break;
		}
		if (num2 >= num)
		{
			return num;
		}
		return num2;
	}

	private int ReturnEntranceNeighborCount(int neighborIndex, CardinalDirectionFlags entranceDirection)
	{
		LandmarkCell landmarkCell = Neighbors[neighborIndex];
		int num = 0;
		while (landmarkCell != null && landmarkCell._possibleEntranceDirections.IsFlagSet(entranceDirection))
		{
			num++;
			landmarkCell = landmarkCell.Neighbors[neighborIndex];
		}
		return num;
	}

	public bool TryReturnNeighbor(out LandmarkCell neighbor, int neighborIndex, bool unreserved = false)
	{
		neighbor = null;
		if (Neighbors == null)
		{
			return false;
		}
		neighbor = Neighbors[neighborIndex];
		if (unreserved && neighbor.IsReserved)
		{
			return false;
		}
		return neighbor != null;
	}

	public bool ReturnIsNeighborOfType(int neighborIndex, LandmarkCellType type)
	{
		if (Neighbors == null)
		{
			return false;
		}
		LandmarkCell landmarkCell = Neighbors[neighborIndex];
		if (landmarkCell == null)
		{
			return false;
		}
		return landmarkCell.CellType == type;
	}

	public int ReturnAmountOfType(int neighborIndex, LandmarkCellType type)
	{
		int num = 0;
		LandmarkCell landmarkCell = this;
		while (landmarkCell != null && landmarkCell.CellType == type)
		{
			num++;
			landmarkCell = landmarkCell.Neighbors[neighborIndex];
		}
		return num;
	}

	private bool ReturnIsBorder(LandmarkGrid landmarkGrid)
	{
		if (_cellType == LandmarkCellType.Empty)
		{
			return false;
		}
		if (!IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos + 1, ColumnPos)) && !IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos + 1, ColumnPos + 1)) && !IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos, ColumnPos + 1)) && !IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos - 1, ColumnPos + 1)) && !IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos - 1, ColumnPos)) && !IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos - 1, ColumnPos - 1)) && !IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos, ColumnPos - 1)))
		{
			return IsNullOrEmpty(landmarkGrid.ReturnCell(RowPos + 1, ColumnPos - 1));
		}
		return true;
	}

	private bool IsNullOrEmpty(LandmarkCell cell)
	{
		if (cell != null)
		{
			return cell.CellType == LandmarkCellType.Empty;
		}
		return true;
	}
}
