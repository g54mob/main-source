using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsPanel : MenuPanel
{
	public TextMeshProUGUI headerLabel;

	public OptionListItemSlider masterVolumeSlider;

	public OptionListItemSlider musicVolumeSlider;

	public OptionListItemSlider interfaceVolumeSlider;

	public OptionListItemDropDown languageOptions;

	public OptionListItemDropDown windowOptions;

	public OptionListItemDropDown resolutionOptions;

	public OptionListItemDropDown scalingOptions;

	public OptionListItemDropDown autosaveOptions;

	public LabelButton confirmButton;

	private bool hasLoadedPreferences;

	private readonly List<MenuButton> optionRows = new List<MenuButton>();

	private string displayedPrefKey;

	private OptionListItemDropDown displayedDropDown;

	protected override void Awake()
	{
		base.Awake();
		masterVolumeSlider.onChangedDelegate = OnSliderChanged;
		musicVolumeSlider.onChangedDelegate = OnSliderChanged;
		interfaceVolumeSlider.onChangedDelegate = OnSliderChanged;
		languageOptions.onButtonClickedDelegate = OnButtonClicked;
		windowOptions.onButtonClickedDelegate = OnButtonClicked;
		resolutionOptions.onButtonClickedDelegate = OnButtonClicked;
		scalingOptions.onButtonClickedDelegate = OnButtonClicked;
		autosaveOptions.onButtonClickedDelegate = OnButtonClicked;
		confirmButton.AddPointerClickTrigger(OnConfirmPressed);
		optionRows.Add(masterVolumeSlider);
		optionRows.Add(musicVolumeSlider);
		optionRows.Add(interfaceVolumeSlider);
		optionRows.Add(languageOptions);
		optionRows.Add(windowOptions);
		optionRows.Add(resolutionOptions);
		optionRows.Add(scalingOptions);
		optionRows.Add(autosaveOptions);
		languageOptions.loadedObject = "PrefInterfaceKeyLanguage";
		windowOptions.loadedObject = "PrefVideoKeyWindowMode";
		resolutionOptions.loadedObject = "PrefVideoKeyResolution";
		scalingOptions.loadedObject = "PrefInterfaceKeyScaling";
		autosaveOptions.loadedObject = "PrefInterfaceKeyAutosave";
		foreach (MenuButton optionRow in optionRows)
		{
			if (optionRow is OptionListItemDropDown optionListItemDropDown)
			{
				optionListItemDropDown.valueButton.buttonState = CustomButtonState.Default;
			}
		}
		confirmButton.buttonState = CustomButtonState.Default;
	}

	public override void Show()
	{
		if (!hasLoadedPreferences)
		{
			LoadPreferences();
		}
		base.Show();
	}

	private void LoadPreferences()
	{
		hasLoadedPreferences = false;
		foreach (MenuButton optionRow in optionRows)
		{
			LoadPreference(optionRow);
		}
		hasLoadedPreferences = true;
	}

	private void LoadPreference(MenuButton prefItem)
	{
		if (prefItem is OptionListItemSlider optionListItemSlider)
		{
			if (optionListItemSlider == masterVolumeSlider)
			{
				optionListItemSlider.slider.value = Preferences.masterVolume * 100f;
			}
			else if (optionListItemSlider == musicVolumeSlider)
			{
				optionListItemSlider.slider.value = Preferences.musicVolume * 100f;
			}
			else if (optionListItemSlider == interfaceVolumeSlider)
			{
				optionListItemSlider.slider.value = Preferences.interfaceVolume * 100f;
			}
		}
		if (prefItem is OptionListItemDropDown { loadedObject: string loadedObject } optionListItemDropDown)
		{
			string optionString = Preferences.ValueForKey(loadedObject);
			optionListItemDropDown.valueLabel.text = TextDisplay.LabelForPreferenceOption(loadedObject, optionString);
		}
	}

	private void OnConfirmPressed()
	{
		Hide();
	}

	private void OnSliderChanged(OptionListItemSlider sender)
	{
		sender.valueLabel.text = TextDisplay.Percent(sender.slider.value * 0.01f);
		if (hasLoadedPreferences)
		{
			if (sender == masterVolumeSlider)
			{
				Preferences.SetValueForKey("PrefAudioMasterVolume", Mathf.RoundToInt(sender.slider.value));
			}
			else if (sender == musicVolumeSlider)
			{
				Preferences.SetValueForKey("PrefAudioMusicVolume", Mathf.RoundToInt(sender.slider.value));
			}
			else if (sender == interfaceVolumeSlider)
			{
				Preferences.SetValueForKey("PrefAudioInterfaceVolume", Mathf.RoundToInt(sender.slider.value));
			}
		}
	}

	private void OnButtonClicked(OptionListItemDropDown sender)
	{
		PopupMenu popupMenu = MenuPanel.m.ShowPopupMenu(null);
		if (sender.loadedObject is string key)
		{
			displayedPrefKey = key;
			displayedDropDown = sender;
			foreach (string item in Preferences.PreferenceOptionsForKey(key))
			{
				popupMenu.AddLabelButton(TextDisplay.LabelForPreferenceOption(key, item), item, OnPopupItemClicked);
			}
		}
		popupMenu.ResizeHeight();
	}

	private void OnPopupItemClicked(PopupMenuItem sender)
	{
		MenuPanel.m.popupMenu.Hide();
		if (sender.loadedObject is string value)
		{
			Preferences.SetValueForKey(displayedPrefKey, value);
			if (null != displayedDropDown)
			{
				LoadPreference(displayedDropDown);
			}
		}
	}

	public override bool IsFixedPosition()
	{
		return true;
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		headerLabel.text = "MenuFunctionOptions".Localized();
		masterVolumeSlider.keyLabel.text = "MasterVolume".Localized();
		musicVolumeSlider.keyLabel.text = "MusicVolume".Localized();
		interfaceVolumeSlider.keyLabel.text = "SoundEffects".Localized();
		languageOptions.keyLabel.text = "PrefInterfaceKeyLanguage".Localized();
		windowOptions.keyLabel.text = "PrefVideoKeyWindowMode".Localized();
		resolutionOptions.keyLabel.text = "PrefVideoKeyResolution".Localized();
		scalingOptions.keyLabel.text = "PrefInterfaceKeyScaling".Localized();
		autosaveOptions.keyLabel.text = "PrefInterfaceKeyAutosave".Localized();
		confirmButton.label.text = "OK".Localized();
		LoadPreferences();
	}
}
