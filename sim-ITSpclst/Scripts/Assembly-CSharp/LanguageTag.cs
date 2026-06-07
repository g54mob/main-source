using System;
using System.Collections.Generic;

[Serializable]
public class LanguageTag
{
	public string nameTag;

	public string tagID;

	public bool view;

	public List<LanguageText> languageTexts;
}
