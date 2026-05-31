using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LanguageBase", menuName = "Language Base")]
public class LanguageBase : ScriptableObject
{
	private static string assetPath;

	public bool viewLanguage;

	public List<LanguageHeader> language;

	public bool viewLanguageText;

	public List<LanguageText> LanguageText;

	public List<LanguageLevel> LanguageData;

	public void SaveLanguageTextToJson()
	{
	}

	[ContextMenu("Load BackUp Language")]
	public void LoadLanguageTextFromJson()
	{
	}

	public void LoadLanguageTextFromFileAssets(TextAsset file)
	{
	}
}
