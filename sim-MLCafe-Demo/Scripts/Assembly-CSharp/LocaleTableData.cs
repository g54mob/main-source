using System;

[Serializable]
public class LocaleTableData
{
	public string Key;

	public string English;

	public string German;

	public bool HasKey(string key)
	{
		return Key.ToLower().Contains(key.ToLower());
	}

	public string GetLocaleString(int langKey)
	{
		return langKey switch
		{
			0 => English, 
			1 => German, 
			_ => English, 
		};
	}
}
