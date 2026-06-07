using System;

public struct FromLuaDataString
{
	public ulong size;

	public IntPtr data;

	public static implicit operator byte[](FromLuaDataString value)
	{
		return null;
	}
}
