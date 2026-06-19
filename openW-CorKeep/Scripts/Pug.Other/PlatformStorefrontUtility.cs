public static class PlatformStorefrontUtility
{
	public static bool MatchesCurrent(PlatformFlags pf, StorefrontFlags sf)
	{
		if (pf.MatchesCurrentPlatform())
		{
			return sf.MatchesCurrentStorefront();
		}
		return false;
	}
}
