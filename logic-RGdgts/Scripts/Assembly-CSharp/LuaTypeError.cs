using System;

[Serializable]
public class LuaTypeError
{
	public RetroUIText.TextAreaCoord location;

	public string moduleName;

	public int code;

	public string message;
}
