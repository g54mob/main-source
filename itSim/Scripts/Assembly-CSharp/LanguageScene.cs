using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanguageScene : MonoBehaviour
{
	public static LanguageScene instance;

	public LanguageBase languageBase;

	public TextAsset languageBaseJson;

	public Dictionary<string, string> LanguageByText;

	public Dictionary<string, string> LanguageByTextID;

	public string ShortLanguage;

	public UnityEvent ActionAfterTranslate;

	private void Awake()
	{
	}

	public void ButtonTranslate()
	{
	}

	private void SetOrginalTextInComponent()
	{
	}

	public void SetLanguage()
	{
	}

	public void TranslateAll()
	{
	}

	public void SetLanguage(string language)
	{
	}

	public static string GetText(string text)
	{
		return null;
	}

	public static string GetTextByID(string id, string textView = "")
	{
		return null;
	}

	public static string GetHierarchyPath(Transform transform)
	{
		return null;
	}
}
