using System;
using System.Collections.Generic;
using UnityEngine;

public class LanguageDataBlock : LocalizedDataBlock
{
	[Header("Language")]
	public string ISO6391;

	public bool enabled;

	public int displayOrder;

	private static LanguageDataBlock s_activeLanguage;

	public static LanguageDataBlock activeLanguage
	{
		get
		{
			if (s_activeLanguage == null)
			{
				activeLanguage = GetPrimaryLanguage();
			}
			return s_activeLanguage;
		}
		set
		{
			if (!(s_activeLanguage == value))
			{
				s_activeLanguage = value;
				LanguageDataBlock.onActiveLanguageChanged?.Invoke(s_activeLanguage);
			}
		}
	}

	public static event Action<LanguageDataBlock> onActiveLanguageChanged;

	public static LanguageDataBlock GetPrimaryLanguage()
	{
		return GetPrimaryLanguage(ScriptableData.GetDataBlocks<LanguageDataBlock>());
	}

	public static LanguageDataBlock GetPrimaryLanguage(IReadOnlyList<LanguageDataBlock> languages)
	{
		int num = int.MaxValue;
		LanguageDataBlock languageDataBlock = null;
		foreach (LanguageDataBlock language in languages)
		{
			if (language.enabled && language.displayOrder < num)
			{
				num = language.displayOrder;
				languageDataBlock = language;
			}
		}
		if (languageDataBlock == null)
		{
			Debug.LogError($"No primary language found! Out of {languages.Count} languages");
		}
		return languageDataBlock;
	}
}
