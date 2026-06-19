using OUSystems.Basics.DataStructures;
using UnityEngine;

public static class GeneralSettings
{
	public static BoolContainer ControlGuidesOn;

	public const string ControlGuidesKey = "Settings_General_ControlGuides";

	public static BoolContainer TutorialsOn;

	public const string TutorialsOnKey = "Settings_General_TutorialsOn";

	public static BoolContainer FullscreenOn;

	public const string FullscreenOnKey = "Settings_Display_Fullscreen";

	public static BoolContainer TrackingHUDOn;

	public const string TrackingUIOnKey = "Settings_General_TrackingUI";

	public static BoolContainer EdgeScrolling;

	public const string EdgeScrollingKey = "Settings_General_EdgeScrolling";

	public static BoolContainer SprintTogglingOn;

	public const string SprintTogglingOnKey = "Settings_General_SprintToggling";

	public static FloatContainer ZoomLevel;

	public const string ZoomLevelKey = "Settings_General_ZoomLevel";

	public static BoolContainer VSyncOn;

	public const string VSyncOnKey = "Settings_Display_VSync";

	public static BoolContainer FrameCapOn;

	public const string FrameCapOnKey = "Settings_Display_FrameCap";

	public const int FrameCapValue = 60;

	[RuntimeInitializeOnLoadMethod]
	public static void LoadSettings()
	{
	}

	private static void SaveBool(string key, bool value)
	{
	}

	private static void SaveFloat(string key, float value)
	{
	}

	private static void SetFullscreen(bool isFullscreen)
	{
	}

	private static void SetVSync(bool isOn)
	{
	}

	private static void SetFrameCap(bool isOn)
	{
	}
}
