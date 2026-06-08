using System.Collections.Generic;

public class DungeonTile
{
	public BoardTileType type;

	public BoardTileRoomItemType roomItemType;

	public DungeonBoardItem boardItem;

	public RoomSpaceType roomSpaceType;

	public bool empty;

	public List<WallSpaceTileType> wallSpaceType = new List<WallSpaceTileType>();

	public Coordinate2D position;

	public DungeonTile(Coordinate2D position)
	{
		this.position = position;
	}

	public DungeonTile(int x, int y)
	{
		position = new Coordinate2D(x, y);
	}

	public void clear()
	{
		type = BoardTileType.Undefined;
		roomItemType = BoardTileRoomItemType.None;
		empty = false;
		roomSpaceType = RoomSpaceType.None;
		wallSpaceType.Clear();
	}

	public override string ToString()
	{
		return string.Format("{0}, {1} - {2}", position.x, position.y, roomSpaceType);
	}
}
