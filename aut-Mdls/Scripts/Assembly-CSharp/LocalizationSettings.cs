using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class LocalizationSettings : ScriptableObject
{
	public List<LocalizationSheet> GoogleSheets;

	public LanguageCode FallbackLanguage = LanguageCode.EN;

	public List<LocalizedLanguage> Languages;

	public List<TMP_FontAsset> ManagedFontAssets;
}
