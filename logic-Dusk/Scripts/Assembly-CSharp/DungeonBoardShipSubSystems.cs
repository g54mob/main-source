public class DungeonBoardShipSubSystems : DungeonBoardItem
{
	public bool horizontal;

	public bool isPerm;

	public DungeonBoardShipSubSystems(Coordinate2D origin, bool isPerm)
	{
		base.origin = origin;
		this.isPerm = isPerm;
		dimensions = new Coordinate2D(1, 1);
	}
}
