public static class PlatformFlagsUtility
{
	public static bool MatchesCurrentPlatform(this PlatformFlags pf)
	{
		PlatformFlags platformFlags = (PlatformFlags)0;
		platformFlags = PlatformFlags.PC;
		return pf.HasFlag(platformFlags);
	}
}
