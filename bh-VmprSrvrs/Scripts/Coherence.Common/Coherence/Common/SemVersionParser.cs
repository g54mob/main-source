namespace Coherence.Common
{
	internal static class SemVersionParser
	{
		public static SemVersion Parse(string version)
		{
			return default(SemVersion);
		}

		public static bool TryParse(string versionString, out SemVersion? result)
		{
			result = null;
			return false;
		}
	}
}
