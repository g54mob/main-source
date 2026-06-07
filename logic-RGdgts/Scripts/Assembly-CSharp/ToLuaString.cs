public struct ToLuaString
{
	public ulong size;

	public string data;

	public ToLuaString(string str)
	{
		size = 0uL;
		data = null;
	}

	public static implicit operator ToLuaString(string value)
	{
		return default(ToLuaString);
	}
}
