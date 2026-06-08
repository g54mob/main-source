public class DungeonBoardPowerInlet : DungeonBoardItem
{
	public DungeonBoardPowerInlet(Coordinate2D origin)
	{
		base.origin = origin;
		dimensions = new Coordinate2D(2, 2);
	}
}
