using System;
using System.Collections.Generic;

[Serializable]
public struct LocalizedLanguage
{
	public string Name;

	public LanguageCode LanguageCode;

	public List<int> GoogleIds;

	public bool IsActive;

	public List<FontFallbackEntry> FontFallbacks;

	public LocalizedLanguage(int sheetsCount)
	{
		Name = "New Language";
		LanguageCode = LanguageCode.N;
		IsActive = true;
		FontFallbacks = new List<FontFallbackEntry>();
		GoogleIds = new List<int>();
		for (int i = 0; i < sheetsCount; i++)
		{
			GoogleIds.Add(0);
		}
	}
}
