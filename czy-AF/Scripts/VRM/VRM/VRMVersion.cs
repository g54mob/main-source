using System;
using System.Text.RegularExpressions;

namespace VRM
{
	public static class VRMVersion
	{
		public struct Version
		{
			public int Major;

			public int Minor;

			public int Patch;

			public string Pre;
		}

		public const int MAJOR = 0;

		public const int MINOR = 58;

		public const int PATCH = 1;

		public const string VERSION = "0.58.1";

		private static readonly Regex VersionSpec = new Regex("(?<major>\\d+)\\.(?<minor>\\d+)(\\.(?<patch>\\d+))?(-(?<pre>[0-9A-Za-z-]+))?");

		public const string VRM_VERSION = "UniVRM-0.58.1";

		public const string MENU = "VRM/UniVRM-0.58.1";

		public static bool IsNewer(string version)
		{
			if (string.IsNullOrEmpty(version))
			{
				return false;
			}
			string text = "UniVRM-";
			if (version.StartsWith(text))
			{
				version = version.Substring(text.Length);
			}
			return IsNewer(version, "0.58.1");
		}

		public static bool IsNewer(string newer, string older)
		{
			if (!ParseVersion(newer, out var v))
			{
				return false;
			}
			if (!ParseVersion(older, out var v2))
			{
				return false;
			}
			if (v.Major > v2.Major)
			{
				return true;
			}
			if (v.Minor > v2.Minor)
			{
				return true;
			}
			if (v.Patch > v2.Patch)
			{
				return true;
			}
			if (string.Compare(v.Pre, v2.Pre) > 0)
			{
				return true;
			}
			return false;
		}

		public static bool ParseVersion(string version, out Version v)
		{
			Match match = VersionSpec.Match(version);
			if (!match.Success)
			{
				v = default(Version);
				return false;
			}
			v = default(Version);
			try
			{
				v.Major = int.Parse(match.Groups["major"].Value);
				v.Minor = int.Parse(match.Groups["minor"].Value);
				v.Patch = (match.Groups["patch"].Success ? int.Parse(match.Groups["patch"].Value) : 0);
				v.Pre = (match.Groups["pre"].Success ? match.Groups["pre"].Value : "");
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
