using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Localization;
using Restory.Gameplay.GameSettings;
using Restory.UserInterface.CommonElements;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_GraphicsSettingPanel : GUI_BaseSettingPanel
	{
		[Space]
		[SerializeField]
		private GUI_DropdownWithData fpsLockDropdown;

		[SerializeField]
		private GUI_Toggle vsyncToggle;

		[SerializeField]
		private GUI_DropdownWithData screenModeDropdown;

		[SerializeField]
		private GUI_DropdownWithData resolutionDropdown;

		[SerializeField]
		private GUI_DropdownWithData graphicsQualityDropdown;

		[SerializeField]
		private GUI_DropdownWithData textSizeModifiersDropdown;

		[SerializeField]
		private GameObject textSizeModifiersRoot;

		[SerializeField]
		private GameObject textSizeModifiersSeparator;

		[Header("Language Settings")]
		[SerializeField]
		private string unlimitedFPSLangKey = "";

		[SerializeField]
		private string fullscreenLangKey = "";

		[SerializeField]
		private string screenModeLangKey = "";

		[Space]
		[SerializeField]
		private string qualityLowLangKey = "";

		[SerializeField]
		private string qualityNormalLangKey = "";

		[SerializeField]
		private string qualityGoodLangKey = "";

		[SerializeField]
		private string qualityFantasticLangKey = "";

		[Space]
		[SerializeField]
		private string standardTextSize = "UI_TEXT_SIZE_SETTINGS_STANDARD";

		[SerializeField]
		private string largeTextSize = "UI_TEXT_SIZE_SETTINGS_LARGE";

		private LocalizationSystem localizationSystem;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
			if (localizationSystem == null)
			{
				Debug.LogException(new Exception("[Type] got injected with a null LocalizationSystem!"));
			}
		}

		protected override void SubscribeChildren()
		{
			base.SubscribeChildren();
			fpsLockDropdown.onValueChanged.AddListener(FpsLockDropdownOnValueChanged);
			vsyncToggle.OnValueChanged.AddListener(VsyncToggleOnValueChanged);
			screenModeDropdown.onValueChanged.AddListener(FullScreenDropdownOnValueChanged);
			resolutionDropdown.onValueChanged.AddListener(ResolutionDropdownOnValueChanged);
			graphicsQualityDropdown.onValueChanged.AddListener(GraphicsQualityDropdownOnValueChanged);
			textSizeModifiersDropdown.onValueChanged.AddListener(TextSizeModifiersDropdownOnValueChanged);
			fpsLockDropdown.IsShownChanged += ResolveDropdownIsShownChanged;
			screenModeDropdown.IsShownChanged += ResolveDropdownIsShownChanged;
			resolutionDropdown.IsShownChanged += ResolveDropdownIsShownChanged;
			graphicsQualityDropdown.IsShownChanged += ResolveDropdownIsShownChanged;
			if (gameSettingsManager != null)
			{
				gameSettingsManager.OnLocalisationChanged.AddListener(OnLocalisationChanged);
			}
		}

		protected override void UnsubscribeChildren()
		{
			base.UnsubscribeChildren();
			fpsLockDropdown.onValueChanged.RemoveListener(FpsLockDropdownOnValueChanged);
			vsyncToggle.OnValueChanged.RemoveListener(VsyncToggleOnValueChanged);
			screenModeDropdown.onValueChanged.RemoveListener(FullScreenDropdownOnValueChanged);
			resolutionDropdown.onValueChanged.RemoveListener(ResolutionDropdownOnValueChanged);
			graphicsQualityDropdown.onValueChanged.RemoveListener(GraphicsQualityDropdownOnValueChanged);
			textSizeModifiersDropdown.onValueChanged.RemoveListener(TextSizeModifiersDropdownOnValueChanged);
			fpsLockDropdown.IsShownChanged -= ResolveDropdownIsShownChanged;
			screenModeDropdown.IsShownChanged -= ResolveDropdownIsShownChanged;
			resolutionDropdown.IsShownChanged -= ResolveDropdownIsShownChanged;
			graphicsQualityDropdown.IsShownChanged -= ResolveDropdownIsShownChanged;
			if (gameSettingsManager != null)
			{
				gameSettingsManager.OnLocalisationChanged.RemoveListener(OnLocalisationChanged);
			}
		}

		public override void Load()
		{
			fpsLockDropdown.SetValueWithoutNotifyByData(gameSettingsManager.FpsLock);
			vsyncToggle.SetIsOnWithoutNotify(gameSettingsManager.Vsync);
			screenModeDropdown.SetValueWithoutNotifyByData(gameSettingsManager.Fullscreen);
			resolutionDropdown.SetValueWithoutNotifyByData(gameSettingsManager.ScreenResolution);
			graphicsQualityDropdown.SetValueWithoutNotify(gameSettingsManager.CurrentUnityPlayerQualityIndex);
			textSizeModifiersDropdown.SetValueWithoutNotify((int)gameSettingsManager.TextSize.GetValueOrDefault());
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void SetDefault()
		{
			fpsLockDropdown.SetValueWithoutNotifyByData(gameSettingsManager.DefaultData.FpsLock);
			vsyncToggle.SetIsOnWithoutNotify(gameSettingsManager.DefaultData.Vsync);
			screenModeDropdown.SetValueWithoutNotifyByData(gameSettingsManager.DefaultData.FullScreen);
			resolutionDropdown.SetValueWithoutNotifyByData(gameSettingsManager.DefaultData.Resolution);
			graphicsQualityDropdown.SetValueWithoutNotify(gameSettingsManager.DefaultData.UnityPlayerQualityIndex);
			textSizeModifiersDropdown.SetValueWithoutNotify((int)gameSettingsManager.TextSize.GetValueOrDefault());
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void Apply()
		{
			gameSettingsManager.FpsLock = fpsLockDropdown.GetData(-1);
			gameSettingsManager.ScreenResolution = resolutionDropdown.GetData(gameSettingsManager.ScreenResolution);
			gameSettingsManager.Vsync = vsyncToggle.IsOn;
			gameSettingsManager.Fullscreen = screenModeDropdown.GetData(defaultData: true);
			gameSettingsManager.CurrentUnityPlayerQualityIndex = graphicsQualityDropdown.value;
			gameSettingsManager.TextSize = (TextSize)textSizeModifiersDropdown.value;
			gameSettingsSaver.Save();
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void UpdateView()
		{
			base.UpdateView();
			UpdateFPSDropdownValues();
			UpdateScreenModeDropdownValues();
			UpdateResolutionDropdownValues();
			UpdateGraphicsQualityDropdownValues();
			UpdateTextSizeDropdownValues();
		}

		private void UpdateFPSDropdownValues()
		{
			int data = fpsLockDropdown.GetData(-1);
			HashSet<int> hashSet = new HashSet<int>(Screen.resolutions.Length) { 30, 60 };
			for (int i = 0; i < Screen.resolutions.Length; i++)
			{
				hashSet.Add((int)Screen.resolutions[i].refreshRateRatio.value);
			}
			List<int> list = hashSet.ToList();
			list.Sort();
			List<Dropdown.OptionData> list2 = new List<Dropdown.OptionData>(list.Count + 1)
			{
				new GUI_DropdownWithData.OptionData<int>(-1, localizationSystem.GetTranslation(unlimitedFPSLangKey))
			};
			foreach (int item in list)
			{
				list2.Add(new GUI_DropdownWithData.OptionData<int>(item, item.ToString()));
			}
			fpsLockDropdown.ClearOptions();
			fpsLockDropdown.AddOptions(list2);
			fpsLockDropdown.SetValueWithoutNotifyByData(data);
		}

		private void UpdateScreenModeDropdownValues()
		{
			bool data = screenModeDropdown.GetData(gameSettingsManager.Fullscreen);
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();
			list.Add(new GUI_DropdownWithData.OptionData<bool>(data: true, localizationSystem.GetTranslation(fullscreenLangKey)));
			list.Add(new GUI_DropdownWithData.OptionData<bool>(data: false, localizationSystem.GetTranslation(screenModeLangKey)));
			screenModeDropdown.ClearOptions();
			screenModeDropdown.AddOptions(list);
			screenModeDropdown.SetValueWithoutNotifyByData(data);
		}

		private void UpdateResolutionDropdownValues()
		{
			Resolution data = resolutionDropdown.GetData(Screen.currentResolution);
			List<Resolution> resolutions = GameSettingsManager.GetResolutions();
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>(resolutions.Count);
			foreach (Resolution item in resolutions)
			{
				list.Add(new GUI_DropdownWithData.OptionData<Resolution>(item, $"{item.width}x{item.height}"));
			}
			resolutionDropdown.ClearOptions();
			resolutionDropdown.AddOptions(list);
			resolutionDropdown.SetValueWithoutNotifyByData(data);
		}

		private void UpdateGraphicsQualityDropdownValues()
		{
			int value = graphicsQualityDropdown.value;
			List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();
			list.Add(new Dropdown.OptionData(localizationSystem.GetTranslation(qualityLowLangKey)));
			list.Add(new Dropdown.OptionData(localizationSystem.GetTranslation(qualityNormalLangKey)));
			list.Add(new Dropdown.OptionData(localizationSystem.GetTranslation(qualityGoodLangKey)));
			list.Add(new Dropdown.OptionData(localizationSystem.GetTranslation(qualityFantasticLangKey)));
			graphicsQualityDropdown.ClearOptions();
			graphicsQualityDropdown.AddOptions(list);
			graphicsQualityDropdown.SetValueWithoutNotify(value);
		}

		private void UpdateTextSizeDropdownValues()
		{
			int value = textSizeModifiersDropdown.value;
			List<Dropdown.OptionData> options = new List<Dropdown.OptionData>
			{
				new Dropdown.OptionData(localizationSystem.GetTranslation(standardTextSize)),
				new Dropdown.OptionData(localizationSystem.GetTranslation(largeTextSize))
			};
			textSizeModifiersDropdown.ClearOptions();
			textSizeModifiersDropdown.AddOptions(options);
			textSizeModifiersDropdown.SetValueWithoutNotify(value);
		}

		protected override void UpdateHasChanges()
		{
			if (!(gameSettingsManager == null))
			{
				SetHasChange(gameSettingsManager.FpsLock != fpsLockDropdown.GetData(-1) || gameSettingsManager.Vsync != vsyncToggle.IsOn || gameSettingsManager.Fullscreen != screenModeDropdown.GetData(defaultData: true) || !GameSettingsManager.EqualResolutions(gameSettingsManager.ScreenResolution, resolutionDropdown.GetData(default(Resolution))) || gameSettingsManager.CurrentUnityPlayerQualityIndex != graphicsQualityDropdown.value || gameSettingsManager.TextSize != (TextSize?)textSizeModifiersDropdown.value);
			}
		}

		protected override void UpdateIsDefaultValues()
		{
			if (!(gameSettingsManager == null))
			{
				SetIsDefaultValues(gameSettingsManager.DefaultData.FpsLock == fpsLockDropdown.GetData(-1) && gameSettingsManager.DefaultData.Vsync == vsyncToggle.IsOn && gameSettingsManager.DefaultData.FullScreen == screenModeDropdown.GetData(defaultData: true) && GameSettingsManager.EqualResolutions(gameSettingsManager.DefaultData.Resolution, resolutionDropdown.GetData(default(Resolution))) && gameSettingsManager.DefaultData.UnityPlayerQualityIndex == graphicsQualityDropdown.value && gameSettingsManager.DefaultData.TextSize == (TextSize?)textSizeModifiersDropdown.value);
			}
		}

		private void ResolveDropdownIsShownChanged(Dropdown dropdown, bool isShown)
		{
			canvasGroup.interactable = !isShown;
			dropdown.GetComponent<CanvasGroup>().ignoreParentGroups = isShown;
		}

		private void OnLocalisationChanged(SystemLanguage parLanguage)
		{
			UpdateView();
		}

		private void FpsLockDropdownOnValueChanged(int value)
		{
			vsyncToggle.SetIsOnWithoutNotify(value: false);
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnDropdownChangedValue?.Invoke();
		}

		private void VsyncToggleOnValueChanged(bool value)
		{
			if (value)
			{
				fpsLockDropdown.SetValueWithoutNotifyByData((int)Screen.currentResolution.refreshRateRatio.value);
			}
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnToggleSwitchedToNewValue?.Invoke(value);
		}

		private void FullScreenDropdownOnValueChanged(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnDropdownChangedValue?.Invoke();
		}

		private void ResolutionDropdownOnValueChanged(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnDropdownChangedValue?.Invoke();
		}

		private void GraphicsQualityDropdownOnValueChanged(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnDropdownChangedValue?.Invoke();
		}

		private void TextSizeModifiersDropdownOnValueChanged(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnDropdownChangedValue?.Invoke();
		}
	}
}
