public class DungeonBoardVent : DungeonBoardItem
{
	public bool horizontal;

	public DungeonBoardVent(Coordinate2D origin, bool horizontal)
	{
		base.origin = origin;
		dimensions = new Coordinate2D(1, 1);
		this.horizontal = horizontal;
	}
}
