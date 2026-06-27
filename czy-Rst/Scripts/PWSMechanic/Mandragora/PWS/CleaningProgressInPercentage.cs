namespace Mandragora.PWS
{
	public struct CleaningProgressInPercentage
	{
		public float RedAndGreenChannel;

		public float BlueChannel;

		public static CleaningProgressInPercentage ZeroProgress => new CleaningProgressInPercentage
		{
			RedAndGreenChannel = 0f,
			BlueChannel = 0f
		};

		public static CleaningProgressInPercentage FullProgress => new CleaningProgressInPercentage
		{
			RedAndGreenChannel = 1f,
			BlueChannel = 1f
		};

		public bool IsFullyCleaned()
		{
			if (RedAndGreenChannel >= 1f)
			{
				return BlueChannel >= 1f;
			}
			return false;
		}
	}
}
