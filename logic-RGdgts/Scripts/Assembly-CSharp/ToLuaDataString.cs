using System;

public struct ToLuaDataString
{
	public int length;

	public IntPtr data;

	public ToLuaDataString(byte[] data)
	{
		length = 0;
		this.data = (IntPtr)0;
	}

	public static implicit operator ToLuaDataString(byte[] data)
	{
		return default(ToLuaDataString);
	}
}
