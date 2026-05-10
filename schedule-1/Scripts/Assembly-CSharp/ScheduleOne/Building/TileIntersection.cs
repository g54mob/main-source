using ScheduleOne.Tiles;

namespace ScheduleOne.Building
{
	public class TileIntersection
	{
		public FootprintTile footprint;

		public Tile tile;

		public static bool operator ==(TileIntersection a, TileIntersection b)
		{
			return false;
		}

		public static bool operator !=(TileIntersection a, TileIntersection b)
		{
			return false;
		}
	}
}
