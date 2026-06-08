using System;

[Serializable]
public class WaqlArgs : Args
{
	public string waql;

	public WaqlArgs(string query)
	{
		waql = query;
	}
}
