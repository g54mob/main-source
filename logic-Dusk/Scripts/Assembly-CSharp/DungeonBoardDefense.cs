public class DungeonBoardDefense : DungeonBoardItem
{
	public DungeonBoardDefense(Coordinate2D origin)
	{
		base.origin = origin;
		dimensions = new Coordinate2D(1, 1);
	}
}
