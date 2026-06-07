using System.Collections.Generic;
using UnityEngine;

public class KeyboardUtil
{
	private int singleStepFireCounter;

	private int singleStepFireCount;

	private static Dictionary<KeyCode, int> fireCounter;

	private static Dictionary<KeyCode, int> fireCount;

	public static bool GetKeyDownRepeat(KeyCode key)
	{
		return false;
	}

	public static void ClipboardCopy(string s)
	{
	}

	public static string ClipboardPaste()
	{
		return null;
	}
}
