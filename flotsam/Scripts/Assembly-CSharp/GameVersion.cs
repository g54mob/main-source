using System;
using System.Runtime.Serialization;

[Serializable]
public struct GameVersion
{
	public int Major;

	public int Minor;

	public int Patch;

	public string AdditionalModifiers;

	[OptionalField(VersionAdded = 2)]
	public int Save;

	public override string ToString()
	{
		return $"{Major}.{Minor}.{Patch}{AdditionalModifiers}";
	}

	public bool ReturnComesBefore(GameVersion version)
	{
		return ReturnComesBefore(version.Major, version.Minor, version.Patch);
	}

	public bool ReturnComesBefore(int major, int minor, int patch)
	{
		if (Major < major)
		{
			return true;
		}
		if (Major > major)
		{
			return false;
		}
		if (Minor < minor)
		{
			return true;
		}
		if (Minor > minor)
		{
			return false;
		}
		if (Patch < patch)
		{
			return true;
		}
		return false;
	}

	public bool Is(int major, int minor, int patch, string additionalModifiers)
	{
		if (Major == major && Minor == minor && Patch == patch)
		{
			return string.Equals(AdditionalModifiers, additionalModifiers, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}
}
