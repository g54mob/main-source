namespace WorldEnvironment.Islands
{
	public interface IIslandWorldGrid
	{
		WorldGridParams GridParams { get; }

		int[,] IslandGrid { get; }

		void GenerateIslandGrid(int seed);
	}
}
