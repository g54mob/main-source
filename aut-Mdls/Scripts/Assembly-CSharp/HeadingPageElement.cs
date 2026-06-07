#define ENABLE_DEBUG_EXCEPTIONS
using TMPro;
using UnityEngine;
using Utils;

public class HeadingPageElement : PageElement
{
	[SerializeField]
	private TextMeshProUGUI _headingText;

	private HeadingPageElementSO _textElement;

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
		_headingText.SetText(LocalizationUtility.GetLocalizedText(_textElement.HeadingLocaKey));
	}

	public override void Setup(PageElementSO element)
	{
		if (!(element is HeadingPageElementSO headingPageElementSO))
		{
			this.DevException("Setup called with wrong PageElementSO!", "Setup", 30);
			return;
		}
		_textElement = element as HeadingPageElementSO;
		_headingText.SetText(LocalizationUtility.GetLocalizedText(headingPageElementSO.HeadingLocaKey));
	}
}
