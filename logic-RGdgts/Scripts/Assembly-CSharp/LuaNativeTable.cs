using System;

public struct LuaNativeTable
{
	public int length;

	public IntPtr data;

	public uint virtualSize;

	public LuaNativeTable(LuaTable luaTable)
	{
		length = 0;
		data = (IntPtr)0;
		virtualSize = 0u;
	}

	public static implicit operator LuaNativeTable(LuaTable table)
	{
		return default(LuaNativeTable);
	}
}
