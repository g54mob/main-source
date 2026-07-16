using System;
using System.Text.RegularExpressions;

public static class VersionExtensions
{
	public static Version ToVersion(this string versionString)
	{
		return Version.Parse(versionString);
	}

	public static bool IsStrictValidVersion(this string versionString)
	{
		return Regex.IsMatch(versionString, "^(0|[1-9]\\d*)(\\.(0|[1-9]\\d*)){0,3}$");
	}
}
