using TMPro;
using UnityEngine;

public class TextFont : MonoBehaviour
{
	private string _key = "";

	public string ForceKey = "";

	private void Start()
	{
		TMP_Text component = GetComponent<TMP_Text>();
		TextFontManager.UpdateFont(component);
		if (TextFontManager.Instance != null)
		{
			TextFontManager.Instance.OnFontChange += HandleFontChange;
		}
		if (!string.IsNullOrEmpty(ForceKey))
		{
			_key = ForceKey;
			component.text = LanguageText.GetText(_key);
		}
		else if (component.text.StartsWith("?") && component.text.EndsWith("?"))
		{
			_key = component.text.Substring(1, component.text.Length - 2);
			component.text = LanguageText.GetText(_key);
		}
	}

	private void OnDestroy()
	{
		if (TextFontManager.Instance != null)
		{
			TextFontManager.Instance.OnFontChange -= HandleFontChange;
		}
	}

	private void HandleFontChange()
	{
		TextFontManager.UpdateFont(GetComponent<TMP_Text>(), force: true);
	}
}
