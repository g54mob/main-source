public struct LuaSelection
{
	public int type;

	public int id;

	public LuaSelection(int type, int id)
	{
		this.type = 0;
		this.id = 0;
	}

	public LuaSelection(Data.Selection s)
	{
		type = 0;
		id = 0;
	}

	public Data.Selection ToDataSelection()
	{
		return default(Data.Selection);
	}
}
