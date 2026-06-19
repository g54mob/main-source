using System.Collections.Generic;
using UnityEngine;

public static class VolumeSettings
{
	public enum Bus
	{
		Master = 0,
		SFX = 1,
		Ambience = 2,
		Music = 3
	}

	public const string MasterBus = "bus:/";

	public const string SfXBus = "bus:/SFX Bus";

	public const string AmbienceBus = "bus:/Ambience Bus";

	public const string MusicBus = "bus:/Music Bus";

	public static List<string> AllBusPaths => null;

	public static string PlayerPrefsBusKey(string busPath)
	{
		return null;
	}

	public static string BusEnumToPath(Bus bus)
	{
		return null;
	}

	[RuntimeInitializeOnLoadMethod]
	public static void LoadSettings()
	{
	}

	public static void SetVolume(float volume, Bus busSelected)
	{
	}

	public static float GetVolume(Bus busSelected)
	{
		return 0f;
	}
}
