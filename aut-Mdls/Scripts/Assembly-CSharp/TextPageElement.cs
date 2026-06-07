#define ENABLE_DEBUG_EXCEPTIONS
using TMPro;
using UnityEngine;
using Utils;

public class TextPageElement : PageElement
{
	[SerializeField]
	private TextMeshProUGUI _paragraphText;

	private TextPageElementSO _textElement;

	private void Awake()
	{
		LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
	}

	private void OnDestroy()
	{
		LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
	}

	private void OnLanguageUpdate()
	{
		_paragraphText.SetText(LocalizationUtility.GetLocalizedText(_textElement.TextLocaKey));
	}

	public override void Setup(PageElementSO element)
	{
		if (!(element is TextPageElementSO textPageElementSO))
		{
			this.DevException("Setup called with wrong PageElementSO!", "Setup", 31);
			return;
		}
		_textElement = element as TextPageElementSO;
		_paragraphText.SetText(LocalizationUtility.GetLocalizedText(textPageElementSO.TextLocaKey));
	}
}
