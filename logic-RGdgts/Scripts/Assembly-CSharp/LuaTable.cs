using System;

public class LuaTable
{
	public class HideIfNull : Attribute
	{
	}

	public class DateTimeFormat : Attribute
	{
		public string format;

		public DateTimeFormat(string format)
		{
		}
	}

	public class AddDictionaryIntoParent : Attribute
	{
	}

	public byte[] data;

	public uint virtualSize;

	public LuaTable()
	{
	}

	public LuaTable(LuaNativeTable nativeTable)
	{
	}

	public LuaTableContent GetContent()
	{
		return null;
	}

	public static implicit operator LuaTable(LuaNativeTable nativeTable)
	{
		return null;
	}
}
