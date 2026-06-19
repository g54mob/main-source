using System.Collections.Generic;
using UnityEngine;

public static class DisplaySettings
{
	public const string ResolutionHeightKey = "Settings_Display_ResolutionHeight";

	public const string ResolutionWidthKey = "Settings_Display_ResolutionWidtt";

	public static List<Resolution> GetResolutions()
	{
		return null;
	}

	public static Resolution GetCurrentResolution(out int currentIndex)
	{
		currentIndex = default(int);
		return default(Resolution);
	}

	[RuntimeInitializeOnLoadMethod]
	public static void Load()
	{
	}

	private static void ApplyResolution(Resolution resolution)
	{
	}

	public static void SetResolution(Resolution resolution)
	{
	}
}
