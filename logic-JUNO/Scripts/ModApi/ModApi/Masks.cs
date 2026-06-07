namespace ModApi
{
	public static class Masks
	{
		public static class Flight
		{
			public const int TerrainAndFeatures = 603979776;
		}

		public static bool IsLayerInMask(int layer, int mask)
		{
			return ((1 << layer) & mask) != 0;
		}
	}
}
