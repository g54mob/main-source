using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Settings___Saves;

public static class MonitorController
{
	public unsafe static void UseMonitor(DisplayInfo display)
	{
		//IL_0021: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		FullScreenMode fullScreenMode = Screen.fullScreenMode;
		bool flag = fullScreenMode == FullScreenMode.Windowed;
		Vector2Int position = (Vector2Int)0;
		if (!flag)
		{
			int num = display.width >> 31;
			object obj = display.width - num;
			Vector2Int vector2Int = (Vector2Int)(obj >> 1);
			position = vector2Int;
		}
		AsyncOperation asyncOperation = Screen.MoveMainWindowTo(ref *(DisplayInfo*)display, position);
	}

	public unsafe static int GetCurrentDisplayIndex()
	{
		//IL_004f: Expected I4, but got O
		//IL_0038: Expected O, but got Ref
		List<DisplayInfo> list = new List<DisplayInfo>();
		Screen.GetDisplayLayout(list);
		DisplayInfo mainWindowDisplayInfo = Screen.mainWindowDisplayInfo;
		object obj = default(object);
		if (list != null)
		{
			return list.IndexOf((DisplayInfo)(&obj));
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}
}
