using System;

public static class BuildConstants
{
	public enum ReleaseType
	{
		None = 0,
		itch_io = 1,
		Steam = 2
	}

	public enum Platform
	{
		None = 0,
		PC = 1,
		macOS = 2
	}

	public enum Architecture
	{
		None = 0,
		Windows_x64 = 1,
		macOS = 2
	}

	public enum Distribution
	{
		None = 0
	}

	public static readonly DateTime buildDate = new DateTime(638683044050848351L);

	public const string version = "1.5.0.25";

	public const ReleaseType releaseType = ReleaseType.Steam;

	public const Platform platform = Platform.PC;

	public const Architecture architecture = Architecture.Windows_x64;

	public const Distribution distribution = Distribution.None;
}
