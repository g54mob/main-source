using UnityEngine;

public class IntroLogWindow : LogWindow
{
	private GUIStyle _textStyle = new GUIStyle();

	private Texture2D _backgroundTexture;

	public void ShowIntroLogWindow()
	{
		base.WindowIsShown = true;
		logText = ">\n> Boot sequence initiated";
		LoadActualLogText();
	}

	private void LoadActualLogText()
	{
		if (GameSaveFile.Get("RESETS", 0) == 1)
		{
			SetFullText(LogManager.GetLogFromResource("Data/ShipsLogs/intro_modified_log_2", false));
		}
		else
		{
			SetFullText(LogManager.GetLogFromResource("Data/ShipsLogs/intro_mothership_loop_log", false));
		}
	}
}
