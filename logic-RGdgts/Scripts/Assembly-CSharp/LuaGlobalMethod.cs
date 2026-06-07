using System;

public class LuaGlobalMethod : Attribute
{
	public string table;

	public string name;

	public LuaGlobalMethod(string table, string name)
	{
	}
}
