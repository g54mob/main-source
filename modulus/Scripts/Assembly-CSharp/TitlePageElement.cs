#define ENABLE_DEBUG_EXCEPTIONS
using TMPro;
using UnityEngine;
using Utils;

public class TitlePageElement : PageElement
{
	[SerializeField]
	private TextMeshProUGUI _titleText;

	private TitlePageElementSO _textElement;

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
		_titleText.SetText(LocalizationUtility.GetLocalizedText(_textElement.TitleLocaKey));
	}

	public override void Setup(PageElementSO element)
	{
		if (!(element is TitlePageElementSO titlePageElementSO))
		{
			this.DevException("Setup called with wrong PageElementSO!", "Setup", 30);
			return;
		}
		_textElement = element as TitlePageElementSO;
		_titleText.SetText(LocalizationUtility.GetLocalizedText(titlePageElementSO.TitleLocaKey));
	}
}
