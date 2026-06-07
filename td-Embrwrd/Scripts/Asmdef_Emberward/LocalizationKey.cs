using System;

[Serializable]
public class LocalizationKey
{
	public string tableName;

	public string key;

	public LocalizationKey(string tableName, string key)
	{
	}

	public string GetString(params object[] arg)
	{
		return null;
	}
}
