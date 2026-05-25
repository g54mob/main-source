using TMPro;
using UnityEngine;

public class TextFont : MonoBehaviour
{
	private void Start()
	{
		TextFontManager.UpdateFont(GetComponent<TMP_Text>());
		if (TextFontManager.Instance != null)
		{
			TextFontManager.Instance.OnFontChange += HandleFontChange;
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
