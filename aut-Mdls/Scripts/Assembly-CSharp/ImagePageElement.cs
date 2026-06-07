#define ENABLE_DEBUG_EXCEPTIONS
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class ImagePageElement : PageElement
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TextMeshProUGUI _captionText;

	private ImagePageElementSO _imageElementSO;

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
		_captionText.SetText(LocalizationUtility.GetLocalizedText(_imageElementSO.CaptionLocaKey));
	}

	public override void Setup(PageElementSO element)
	{
		if (!(element is ImagePageElementSO imagePageElementSO))
		{
			this.DevException("Setup called with wrong PageElementSO!", "Setup", 32);
			return;
		}
		_imageElementSO = element as ImagePageElementSO;
		_image.sprite = imagePageElementSO.Image;
		_captionText.gameObject.SetActive(_imageElementSO.HasCaption);
		if (_imageElementSO.HasCaption)
		{
			_captionText.SetText(LocalizationUtility.GetLocalizedText(_imageElementSO.CaptionLocaKey));
		}
	}
}
