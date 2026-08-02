using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class AutoTextRegistrar : MonoBehaviour
{
	private TMP_Text textComponent;

	private FontManager fontManager;

	private void Awake()
	{
		textComponent = GetComponent<TMP_Text>();
		fontManager = Object.FindObjectOfType<FontManager>();
		if (fontManager != null)
		{
			fontManager.RegisterText(textComponent);
		}
	}

	private void OnDestroy()
	{
		if (fontManager != null)
		{
			fontManager.UnregisterText(textComponent);
		}
	}
}
