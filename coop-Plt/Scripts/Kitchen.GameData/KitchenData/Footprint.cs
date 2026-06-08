namespace KitchenData
{
	public class Footprint
	{
		public ApplianceFootprint[,] Pattern;

		private void CreateData()
		{
			Pattern = new ApplianceFootprint[5, 5];
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (i == j && i == 2)
					{
						Pattern[i, j] = ApplianceFootprint.PlacementTile;
					}
					else
					{
						Pattern[i, j] = ApplianceFootprint.Free;
					}
				}
			}
		}
	}
}
