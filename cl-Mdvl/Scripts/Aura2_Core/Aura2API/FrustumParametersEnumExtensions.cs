namespace Aura2API
{
	public static class FrustumParametersEnumExtensions
	{
		public static bool HasFlags(this FrustumParameters referenceFlags, FrustumParameters comparisonFlags)
		{
			return (referenceFlags & comparisonFlags) == comparisonFlags;
		}

		public static FrustumParameters SetFlags(this FrustumParameters referenceFlags, FrustumParameters addedFlags)
		{
			return referenceFlags | addedFlags;
		}

		public static FrustumParameters RemoveFlags(this FrustumParameters referenceFlags, FrustumParameters removedFlags)
		{
			return referenceFlags & ~removedFlags;
		}

		public static FrustumParameters ToggleFlags(this FrustumParameters referenceFlags, FrustumParameters togglingFlags)
		{
			return referenceFlags ^ togglingFlags;
		}

		public static FrustumParameters ReplaceFlags(this FrustumParameters referenceFlags, FrustumParameters replacingFlags, bool value)
		{
			FrustumParameters result = referenceFlags;
			if ((value && !referenceFlags.HasFlags(replacingFlags)) || (!value && referenceFlags.HasFlags(replacingFlags)))
			{
				result = referenceFlags.ToggleFlags(replacingFlags);
			}
			return result;
		}
	}
}
