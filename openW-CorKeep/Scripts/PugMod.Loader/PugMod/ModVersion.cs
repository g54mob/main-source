using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PugMod
{
	public static class ModVersion
	{
		private static readonly Regex _versionRegex = new Regex("^(\\d+)\\.(\\d+)\\.(\\d+)");

		public static string GetVersion(string version)
		{
			Match match = _versionRegex.Match(version);
			if (!match.Success)
			{
				return null;
			}
			return match.Value;
		}

		public static bool IsCompatible(string appVersion, IEnumerable<string> tags)
		{
			Match match = _versionRegex.Match(appVersion);
			if (!match.Success)
			{
				return true;
			}
			foreach (string tag in tags)
			{
				Match match2 = _versionRegex.Match(tag);
				if (match2.Success && int.Parse(match2.Groups[1].Value) == int.Parse(match.Groups[1].Value) && int.Parse(match2.Groups[2].Value) == int.Parse(match.Groups[2].Value) && int.Parse(match2.Groups[3].Value) == int.Parse(match.Groups[3].Value))
				{
					return true;
				}
			}
			return false;
		}
	}
}
