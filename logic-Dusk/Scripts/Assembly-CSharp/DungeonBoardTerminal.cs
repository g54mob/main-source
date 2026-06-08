public class DungeonBoardTerminal : DungeonBoardItem
{
	public bool horizontal;

	public DungeonBoardDefense defense;

	public DungeonTerminalType type = DungeonTerminalType.Scan;

	public DungeonBoardTerminal(Coordinate2D origin, bool horizontal)
	{
		base.origin = origin;
		this.horizontal = horizontal;
	}
}
