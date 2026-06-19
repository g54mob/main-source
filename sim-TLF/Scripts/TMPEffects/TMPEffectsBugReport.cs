using System;
using UnityEngine;

internal static class TMPEffectsBugReport
{
	public static void BugReportPrompt(Exception exception)
	{
		BugReportPrompt(exception.ToString());
	}

	public static void BugReportPrompt(string message)
	{
		Debug.LogWarning("It seems you ran into a bug: " + message + "\nPlease take the time to make a bug report on GitHub:\nhttps://github.com/Luca3317/TMPEffects.BugReport");
	}
}
