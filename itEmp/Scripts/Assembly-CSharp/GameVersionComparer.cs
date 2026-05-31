public static class GameVersionComparer
{
	public enum VersionCompareResult
	{
		Older = -1,
		Same = 0,
		Newer = 1
	}

	public enum GamePhase
	{
		Prototype = 0,
		PreAlpha = 1,
		Alpha = 2,
		Beta = 3,
		EA = 4,
		Release = 5,
		Patch = 6
	}

	public static VersionCompareResult Compare(string saveVersion, string currentVersion)
	{
		return default(VersionCompareResult);
	}

	private static (GamePhase, int[]) ParseVersion(string version)
	{
		return default((GamePhase, int[]));
	}

	private static GamePhase PhaseFromString(string phase)
	{
		return default(GamePhase);
	}

	private static GamePhase PhaseFromMajor(int major)
	{
		return default(GamePhase);
	}
}
