using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Font Group")]
public class LocalizedFontGroup : ScriptableObject
{
	public TMP_FontAsset Default;

	public List<LocaleFont> Fonts;

	public Action<TMP_FontAsset> AnnounceUpdateFont;

	public TMP_FontAsset CurrentFont { get; private set; }

	public void SetLanguage(string languageCode)
	{
	}
}
