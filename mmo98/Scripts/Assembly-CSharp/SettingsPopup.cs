using System;
using System.Collections.Generic;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SettingsPopup : Popup
{
	[Serializable]
	public struct TabWindow
	{
		public ButtonWrapper button;

		public GameObject content;
	}

	[SerializeField]
	private List<TabWindow> tabs;

	[SerializeField]
	private TMP_Dropdown languageDropdown;

	[SerializeField]
	private TMP_Dropdown displaymodeDropdown;

	[SerializeField]
	private List<FullscreenModeDropdownOption> displaymodeOptions;

	[SerializeField]
	private TMP_Dropdown fpsLimitDropdown;

	[SerializeField]
	private List<FpsLimitDropdownOption> fpsLimitOptions;

	[SerializeField]
	private Slider brightnessSlider;

	[SerializeField]
	private Toggle crtEffectToggle;

	[SerializeField]
	private Toggle gnormanMuffleToggle;

	[SerializeField]
	private Toggle twitchIntegrationToggle;

	[SerializeField]
	private TMP_InputField twitchChannelInput;

	[SerializeField]
	private GameObject twitchChannelLine;

	[SerializeField]
	private Slider masterChannelSlider;

	[SerializeField]
	private Slider sfxChannelSlider;

	[SerializeField]
	private Slider musicChannelSlider;

	[SerializeField]
	private Slider ambientChannelSlider;

	[SerializeField]
	private Toggle muteOnFocusLossToggle;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Each(tabs, delegate(TabWindow tab)
		{
			tab.button.onClick.AddListener(delegate
			{
				ShowTab(tab);
			});
		}).Context(brightnessSlider).Configure(ReactiveSettings.Brightness)
			.Context(crtEffectToggle)
			.Configure(ReactiveSettings.CRTEffect)
			.Context(gnormanMuffleToggle)
			.Configure(ReactiveSettings.GnormanMuffled)
			.Context(masterChannelSlider)
			.Configure(ReactiveSettings.AudioMaster)
			.Context(sfxChannelSlider)
			.Configure(ReactiveSettings.AudioSfx)
			.Context(musicChannelSlider)
			.Configure(ReactiveSettings.AudioMusic)
			.Context(ambientChannelSlider)
			.Configure(ReactiveSettings.AudioAmbient)
			.Context(twitchIntegrationToggle)
			.Configure(ReactiveSettings.TwitchEnabled)
			.Context(twitchChannelInput)
			.Configure(ReactiveSettings.TwitchChannel)
			.Context(muteOnFocusLossToggle)
			.Configure(ReactiveSettings.MuteAudioOnFocusLoss)
			.Invoke(ConfigureLanguageDropdown)
			.Invoke(delegate
			{
				LocalizationSettings.SelectedLocaleChanged += ConfigureLocalizedDropdowns;
			})
			.Invoke(ConfigureDisplayModeDropdown)
			.Invoke(ConfigureFpsLimitDropdown);
		ReactiveSettings.TwitchEnabled.SubscribeToSetActive(twitchChannelLine).AddTo(this);
		ShowTab(tabs[0]);
	}

	protected override void OnDestroy()
	{
		LocalizationSettings.SelectedLocaleChanged -= ConfigureLocalizedDropdowns;
	}

	private void ShowTab(TabWindow tabToOpen)
	{
		foreach (TabWindow tab in tabs)
		{
			bool flag = tab.button == tabToOpen.button;
			tab.content.SetActive(flag);
			if (flag)
			{
				tab.button.ForceSelected();
			}
			else
			{
				tab.button.Clear();
			}
		}
	}

	private void ConfigureLanguageDropdown()
	{
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int value = 0;
		for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
		{
			Locale locale = LocalizationSettings.AvailableLocales.Locales[i];
			if (LocalizationSettings.SelectedLocale == locale)
			{
				value = i;
			}
			list.Add(new TMP_Dropdown.OptionData(locale.LocaleName));
		}
		languageDropdown.options = list;
		languageDropdown.value = value;
		languageDropdown.onValueChanged.AddListener(delegate(int index)
		{
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
		});
	}

	private void ConfigureLocalizedDropdowns(Locale locale)
	{
		ConfigureDisplayModeDropdown();
		ConfigureFpsLimitDropdown();
	}

	private void ConfigureDisplayModeDropdown()
	{
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int value = 0;
		for (int i = 0; i < displaymodeOptions.Count; i++)
		{
			FullscreenModeDropdownOption fullscreenModeDropdownOption = displaymodeOptions[i];
			if (fullscreenModeDropdownOption.mode == ReactiveSettings.FullscreenMode.Value)
			{
				value = i;
			}
			list.Add(new TMP_Dropdown.OptionData(fullscreenModeDropdownOption.label.GetLocalizedString()));
		}
		displaymodeDropdown.options = list;
		displaymodeDropdown.value = value;
		displaymodeDropdown.onValueChanged.AddListener(delegate(int index)
		{
			ReactiveSettings.FullscreenMode.Value = displaymodeOptions[index].mode;
		});
	}

	private void ConfigureFpsLimitDropdown()
	{
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int value = 0;
		for (int i = 0; i < fpsLimitOptions.Count; i++)
		{
			FpsLimitDropdownOption fpsLimitDropdownOption = fpsLimitOptions[i];
			if (fpsLimitDropdownOption.fps == ReactiveSettings.FpsLimit.Value)
			{
				value = i;
			}
			list.Add(new TMP_Dropdown.OptionData(fpsLimitDropdownOption.label.GetLocalizedString()));
		}
		fpsLimitDropdown.options = list;
		fpsLimitDropdown.value = value;
		fpsLimitDropdown.onValueChanged.AddListener(delegate(int index)
		{
			ReactiveSettings.FpsLimit.Value = fpsLimitOptions[index].fps;
		});
	}
}
