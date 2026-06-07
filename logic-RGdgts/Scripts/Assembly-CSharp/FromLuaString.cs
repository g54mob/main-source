using System;

public struct FromLuaString
{
	public ulong size;

	public IntPtr data;

	public static implicit operator string(FromLuaString value)
	{
		return null;
	}
}
