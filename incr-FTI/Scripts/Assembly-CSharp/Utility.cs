using System.Diagnostics;
using UnityEngine;

public static class Utility
{
	public const float InitialULong = float.MinValue;

	[Conditional("UNITY_EDITOR")]
	public static void LogEditor(string s, bool highlight = false, Object contextObject = null)
	{
		string text = "EDITOR: " + s;
		if (highlight)
		{
			UnityEngine.Debug.Log("<color=yellow>" + text + "</color>", contextObject);
		}
		else
		{
			UnityEngine.Debug.Log(text, contextObject);
		}
	}
}
