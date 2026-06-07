using UnityEngine;

public class RegisterGlobalMethodDefinitions
{
	public delegate Color ColorUtils_ColorType(byte r, byte g, byte b);

	public delegate Color ColorUtils_ColorRGBAType(byte r, byte g, byte b, byte a);

	public delegate Color ColorUtils_ColorHSVType(float h, float s, float v);

	public delegate void CPUModule_logType(FromLuaString message);

	public delegate void CPUModule_logWarningType(FromLuaString message);

	public delegate void CPUModule_logErrorType(FromLuaString message);

	public delegate void CPUModule_writeType(FromLuaString text);

	public delegate void CPUModule_writelnType(FromLuaString text);

	public delegate void CPUModule_setFgColorType(int colorId);

	public delegate void CPUModule_setBgColorType(int colorId);

	public delegate void CPUModule_resetFgColorType();

	public delegate void CPUModule_resetBgColorType();

	public delegate void CPUModule_resetColorsType();

	public delegate void CPUModule_setCursorPosType(int column, int line);

	public delegate void CPUModule_setCursorXType(int column);

	public delegate void CPUModule_setCursorYType(int line);

	public delegate void CPUModule_moveCursorXType(int deltaColumn);

	public delegate void CPUModule_moveCursorYType(int deltaLine);

	public delegate void CPUModule_saveCursorPosType();

	public delegate void CPUModule_restoreCursorPosType();

	public delegate void CPUModule_clearType();

	public delegate void CPUModule_clearToEndLineType();

	public delegate bool SceneManager_GetLampStateType();

	public delegate void SceneManager_SetLampStateType(bool state);

	public delegate void SceneManager_SetLampColorType(Color color);

	public delegate void SceneManager_ShowMessageType(FromLuaString message, bool persistent);

	public delegate void SceneManager_ShowWarningType(FromLuaString message, bool persistent);

	public delegate void SceneManager_ShowErrorType(FromLuaString message, bool persistent);

	public delegate void SceneManager_HideMessageType();

	public static void Register()
	{
	}

	public static Color ColorUtils_Color(byte r, byte g, byte b)
	{
		return default(Color);
	}

	public static Color ColorUtils_ColorRGBA(byte r, byte g, byte b, byte a)
	{
		return default(Color);
	}

	public static Color ColorUtils_ColorHSV(float h, float s, float v)
	{
		return default(Color);
	}

	public static void CPUModule_log(FromLuaString message)
	{
	}

	public static void CPUModule_logWarning(FromLuaString message)
	{
	}

	public static void CPUModule_logError(FromLuaString message)
	{
	}

	public static void CPUModule_write(FromLuaString text)
	{
	}

	public static void CPUModule_writeln(FromLuaString text)
	{
	}

	public static void CPUModule_setFgColor(int colorId)
	{
	}

	public static void CPUModule_setBgColor(int colorId)
	{
	}

	public static void CPUModule_resetFgColor()
	{
	}

	public static void CPUModule_resetBgColor()
	{
	}

	public static void CPUModule_resetColors()
	{
	}

	public static void CPUModule_setCursorPos(int column, int line)
	{
	}

	public static void CPUModule_setCursorX(int column)
	{
	}

	public static void CPUModule_setCursorY(int line)
	{
	}

	public static void CPUModule_moveCursorX(int deltaColumn)
	{
	}

	public static void CPUModule_moveCursorY(int deltaLine)
	{
	}

	public static void CPUModule_saveCursorPos()
	{
	}

	public static void CPUModule_restoreCursorPos()
	{
	}

	public static void CPUModule_clear()
	{
	}

	public static void CPUModule_clearToEndLine()
	{
	}

	public static bool SceneManager_GetLampState()
	{
		return false;
	}

	public static void SceneManager_SetLampState(bool state)
	{
	}

	public static void SceneManager_SetLampColor(Color color)
	{
	}

	public static void SceneManager_ShowMessage(FromLuaString message, bool persistent)
	{
	}

	public static void SceneManager_ShowWarning(FromLuaString message, bool persistent)
	{
	}

	public static void SceneManager_ShowError(FromLuaString message, bool persistent)
	{
	}

	public static void SceneManager_HideMessage()
	{
	}
}
