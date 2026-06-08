using System;
using System.Collections.Generic;
using UnityEngine;

public class ExceptionHandlingUI : MonoBehaviour
{
	private static Dictionary<string, int> stackTraces = new Dictionary<string, int>();

	private static int errorCount = 0;

	private static string fullMessage = "";

	private GUIStyle style;

	public static void Report(Exception e)
	{
		Report(e.ToString());
	}

	public static void Report(string str)
	{
		if (stackTraces.ContainsKey(str))
		{
			stackTraces[str]++;
		}
		else
		{
			stackTraces.Add(str, 1);
			CrashReportController.singleton.SendReport(str);
			if (DiagnosticsUI.singleton != null && GameStates.Singleton != null && GameStates.Singleton.CurrentState > GameStates.State.Intro)
			{
				str = str + "\n" + DiagnosticsUI.singleton.ToString();
			}
			fullMessage = fullMessage + str + "\n\n";
		}
		errorCount++;
		GUIUtility.systemCopyBuffer = fullMessage;
	}

	public static bool HasErrors()
	{
		return errorCount > 0;
	}

	private void OnGUI()
	{
		if (HasErrors())
		{
			if (style == null)
			{
				style = new GUIStyle(GUI.skin.label);
				style.normal.textColor = Color.red;
			}
			GUILayout.BeginHorizontal();
			GUILayout.Space(10f);
			GUILayout.BeginVertical();
			GUILayout.Space(10f);
			GUILayout.Label(errorCount + " critical errors have been copied to your clipboard. Please report to the developer.", style);
			GUILayout.Label("No screenshot needed. Paste the error directly to one of the following:", style);
			GUILayout.Label("Discord: discord.gg/StoneStoryRPG", style);
			GUILayout.Label("Email: support@martianrex.com", style);
			GUILayout.Label("Some progress may be lost. Reboot the game to continue.", style);
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
		}
	}

	private void Update()
	{
		if (HasErrors() && Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftMeta) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.RightMeta)))
		{
			GUIUtility.systemCopyBuffer = fullMessage;
		}
	}
}
