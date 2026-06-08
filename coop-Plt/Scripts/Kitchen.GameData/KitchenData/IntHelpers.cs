namespace KitchenData
{
	public static class IntHelpers
	{
		public static int Band(float input, float[] bands)
		{
			for (int i = 0; i < bands.Length; i++)
			{
				if (input <= bands[i])
				{
					return i;
				}
			}
			return bands.Length;
		}
	}
}
