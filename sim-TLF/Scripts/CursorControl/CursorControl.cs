using System;
using UnityCursorControl;
using UnityEngine;

public static class CursorControl
{
	private static ICursorControl _cursorControl;

	static CursorControl()
	{
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			_cursorControl = new CursorControlWindows();
			return;
		}
		throw new PlatformNotSupportedException("CursorControl is not supported on this platform");
	}

	public static Vector2 GetGlobalCursorPos()
	{
		return _cursorControl.GetGlobalCursorPos();
	}

	public static void SetGlobalCursorPos(Vector2 pos)
	{
		_cursorControl.SetGlobalCursorPos(pos);
	}

	public static void SetLocalCursorPos(Vector2 pos)
	{
		_cursorControl.SetLocalCursorPos(pos);
	}

	public static void SimulateLeftClick()
	{
		_cursorControl.SimulateLeftClick();
	}

	public static void SimulateMiddleClick()
	{
		_cursorControl.SimulateMiddleClick();
	}

	public static void SimulateRightClick()
	{
		_cursorControl.SimulateRightClick();
	}
}
