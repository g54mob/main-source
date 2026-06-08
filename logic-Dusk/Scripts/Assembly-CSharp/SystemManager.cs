public static class SystemManager
{
	public enum AspectRationEnum
	{
		ar16x9OrUnknown = 0,
		ar16x10 = 1,
		ar5x4 = 2,
		ar4x3 = 3,
		ar3x2 = 4,
		ar21x9 = 5
	}

	public static AspectRationEnum AspectRatio { get; set; }
}
