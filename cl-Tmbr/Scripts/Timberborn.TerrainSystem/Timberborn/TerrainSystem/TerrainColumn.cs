namespace Timberborn.TerrainSystem
{
	internal struct TerrainColumn
	{
		public int Floor;

		public int Ceiling;

		public TerrainColumn(int floor, int ceiling)
		{
			Floor = floor;
			Ceiling = ceiling;
		}
	}
}
