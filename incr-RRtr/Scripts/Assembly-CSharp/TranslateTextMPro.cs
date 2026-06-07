using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TranslateTextMPro : MonoBehaviour
{
	private TMP_Text text;

	private string key;

	private bool hasKey;

	private string previousText;

	private LocalizationSystem.Language previousLanguage;

	private TMP_FontAsset previousFont;

	[SerializeField]
	private bool capitalize;

	private void Start()
	{
		text = GetComponent<TMP_Text>();
		if (!hasKey)
		{
			key = text.text;
			hasKey = true;
		}
		if (hasKey)
		{
			CheckLanguage();
		}
		CheckFont();
	}

	private void OnEnable()
	{
		if (hasKey && LocalizationSystem.language != previousLanguage)
		{
			CheckLanguage();
			previousLanguage = LocalizationSystem.language;
		}
		CheckFont();
	}

	private void Update()
	{
		if (previousText != text.text && hasKey)
		{
			CheckLanguage();
		}
		if (LocalizationSystem.language != previousLanguage)
		{
			if (hasKey)
			{
				CheckLanguage();
			}
			previousLanguage = LocalizationSystem.language;
		}
		CheckFont();
	}

	private void CheckLanguage()
	{
		previousText = LocalizationSystem.GetLocalizedValue(key);
		if (capitalize)
		{
			previousText = previousText.ToUpper();
		}
		text.text = previousText;
	}

	private void CheckFont()
	{
		if (!(text == null) && !(text.font == GameManager.ins.fontAsset))
		{
			text.font = GameManager.ins.fontAsset;
			previousFont = text.font;
		}
	}
}
