using System;
using Events.Integrations;
using Integrations.Data;
using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotContest : MonoBehaviour
{
	[SerializeField]
	private RectTransform _panel;

	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private RawImage _rawImage;

	[SerializeField]
	private RawImage _expandedRawImage;

	[SerializeField]
	private TextMeshProUGUI _descriptionText;

	[SerializeField]
	private TextMeshProUGUI _callToActionText;

	[SerializeField]
	private GameObject _buttons;

	[SerializeField]
	private Button _callToActionButton;

	[SerializeField]
	private TitleDataAvailableEvent _titleDataAvailable;

	[SerializeField]
	private IntegrationManagerLocator _integrationManagerLocator;

	private TitleData _titleData;

	public Action<bool> OnContentAvailable;

	private void Awake()
	{
		_titleData = _integrationManagerLocator.Integration.CloudService.GetTitleData();
		_titleDataAvailable.Register(OnTitleDataAvailable);
		LocalizationUtility.OnLanguageUpdate += OnLanguageChanged;
		_callToActionButton.onClick.AddListener(OnCTAClicked);
	}

	private void Start()
	{
		if (_titleData?.ScreenshotContestInfo != null)
		{
			ShowScreenshotContestInfo();
		}
	}

	private void OnDestroy()
	{
		_titleDataAvailable.UnRegister(OnTitleDataAvailable);
		LocalizationUtility.OnLanguageUpdate -= OnLanguageChanged;
		_callToActionButton.onClick.RemoveListener(OnCTAClicked);
	}

	private void OnLanguageChanged()
	{
		ShowScreenshotContestInfo();
	}

	private void OnTitleDataAvailable(TitleData titleData)
	{
		_titleData = titleData;
		ShowScreenshotContestInfo();
	}

	private void ShowScreenshotContestInfo(bool updateImage = true)
	{
		bool obj = false;
		TitleData titleData = _titleData;
		if (titleData != null)
		{
			ScreenshotContestInfo screenshotContestInfo = titleData.ScreenshotContestInfo;
			if (screenshotContestInfo != null && screenshotContestInfo.Active)
			{
				_titleText.SetText(_titleData.ScreenshotContestInfo.Title);
				_descriptionText.SetText(_titleData.ScreenshotContestInfo.Description);
				if (_titleData.ScreenshotContestInfo.DisableCTA)
				{
					_buttons.SetActive(value: false);
				}
				else
				{
					_buttons.SetActive(value: true);
					_callToActionText.SetText(_titleData.ScreenshotContestInfo.CallToAction);
				}
				if (updateImage)
				{
					Texture2D image = _titleData.ScreenshotContestInfo.GetImage();
					if ((bool)image)
					{
						_rawImage.texture = image;
						_expandedRawImage.texture = image;
					}
				}
				obj = true;
			}
		}
		OnContentAvailable?.Invoke(obj);
	}

	private void OnCTAClicked()
	{
		_integrationManagerLocator.Integration.Platform.OpenWebPage(_titleData.ScreenshotContestInfo.CallToActionLink, forceWebLink: true);
	}
}
