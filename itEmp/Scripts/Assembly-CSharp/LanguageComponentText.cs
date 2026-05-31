using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LanguageComponentText : MonoBehaviour
{
	public static LanguageBase languageBase;

	public TMP_Text textComponent;

	public LanguageComponentTextType Type;

	public string textID;

	public string originalText;

	public void FirstRun()
	{
	}

	public void Translate()
	{
	}

	private void EnsureLanguageBaseLoaded()
	{
	}

	private string FindTextID(string id)
	{
		return null;
	}
}
