using System;

[Serializable]
public class LocalizationItem
{
	public string Key;

	public string Value;

	public string GetValue()
	{
		return Value;
	}
}
