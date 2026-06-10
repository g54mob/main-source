using System.Collections.Generic;

public class DistrictsCreator : Creator
{
	public class DistrictPlacement
	{
		public float score;

		public List<CityTile> tiles;

		public List<CityTile> innerTiles;

		public List<CityTile> edgeTiles;
	}

	private static DistrictsCreator _instance;

	public static DistrictsCreator Instance => null;

	private void Awake()
	{
	}

	public override void StartLoading()
	{
	}
}
