public static class StorefrontFlagsUtility
{
	public static bool MatchesCurrentStorefront(this StorefrontFlags sf)
	{
		StorefrontFlags storefrontFlags = (StorefrontFlags)0;
		storefrontFlags = StorefrontFlags.Steam;
		return sf.HasFlag(storefrontFlags);
	}
}
