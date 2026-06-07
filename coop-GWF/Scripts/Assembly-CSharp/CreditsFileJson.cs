using System;

[Serializable]
public class CreditsFileJson
{
	public string body;

	public string[] lines;

	public CreditEntryJson[] entries;
}
