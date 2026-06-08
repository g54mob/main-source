using UnityEngine;

public class TileData
{
	public enum TileGroupEnum
	{
		Undefined = 0,
		Room = 1,
		Corridor = 2,
		PowerInlet = 3,
		Defense = 4,
		Terminal = 5,
		Vent = 6,
		SubSystem = 7,
		FuelAccess = 8,
		Painted = 9
	}

	public enum TileTypeEnum
	{
		Undefined = 0,
		Standard = 1,
		Corridor = 2,
		Wall = 3,
		Swamp = 4
	}

	public enum EdgeTypeEnum
	{
		Unknown = 0,
		Top = 1,
		Bottom = 2,
		Left = 3,
		Right = 4,
		TopLeft = 5,
		TopRight = 6,
		BottomLeft = 7,
		BottomRight = 8
	}

	private TileTypeEnum _currentTileType;

	private TileGroupEnum _currentTileGroupType;

	private bool _isEdge;

	public BoardPosition boardPosition;

	public int RoomX = -1;

	public int RoomY = -1;

	public int BoardX = -1;

	public int BoardY = -1;

	public TileScript visualComponent { get; set; }

	public TileTypeEnum currentTileType
	{
		get
		{
			return _currentTileType;
		}
		set
		{
			_currentTileType = value;
			if (!(visualComponent != null))
			{
				return;
			}
			if (value == TileTypeEnum.Undefined)
			{
				if (!Table.seeEmptyTiles)
				{
					visualComponent.GetComponent<Renderer>().enabled = false;
				}
				else
				{
					visualComponent.GetComponent<Renderer>().enabled = true;
				}
			}
			else
			{
				visualComponent.GetComponent<Renderer>().enabled = true;
			}
		}
	}

	public TileGroupEnum currentTileGroupType
	{
		get
		{
			return _currentTileGroupType;
		}
		set
		{
			_currentTileGroupType = value;
		}
	}

	public bool isEdge
	{
		get
		{
			return _isEdge;
		}
		set
		{
			_isEdge = value;
		}
	}

	public EdgeTypeEnum edgeType { get; set; }
}
