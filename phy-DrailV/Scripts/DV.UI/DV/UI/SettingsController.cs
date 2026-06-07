using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DV.ThingTypes;
using DV.UIFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class SettingsController : AUIController, IUIMenuSwitchPreventer
	{
		private const string LOC_POPUP_LABEL = "settings/confirm_changes_popup";

		private const string LOC_GENERIC_SAVE = "save";

		private const string LOC_GENERIC_DISCARD = "discard";

		private const string LOC_GENERIC_CANCEL = "cancel";

		private const string CATEGORY_VR = "VR";

		private ASettingsProvider provider;

		private readonly Dictionary<string, PreferenceValues> diff = new Dictionary<string, PreferenceValues>();

		[NullCheck]
		public PlatformSpecificElements platformSpecificElements;

		[NullCheck]
		public UIMenuRequester languageButton;

		[Header("Bottom")]
		[NullCheck]
		public Button applyChanges;

		[NullCheck]
		public Button revertChanges;

		[NullCheck]
		public TextMeshProUGUI infoTMPro;

		[NullCheck]
		public Selector presetSelector;

		[Header("Special")]
		[NullCheck]
		public Button exportTelemetry;

		[NullCheck]
		public FullscreenToggleButton fullscreenToggle;

		[NullCheck]
		public ButtonDV localizationButton;

		[NullCheck]
		public ButtonDV calibrateHeightVRButton;

		[NullCheck]
		public ButtonDV calibrateInputVRButton;

		[NullCheck]
		public UIMenuController menuController;

		[NullCheck]
		public LanguageSelectorController languageSelectorController;

		[NullCheck]
		public ToggleDV seatedAreaPlayType;

		[NullCheck]
		public GameObject roomscaleHeight;

		[NullCheck]
		public GameObject seatedHeight;

		[NullCheck]
		public GameObject itemHoldTypeGO;

		[NullCheck]
		public GameObject wandPressToMoveGO;

		[Header("Dialogs")]
		[NullCheck]
		public Popup messageDialog;

		[NullCheck]
		public Popup spinnerDialog;

		[NullCheck]
		public Popup confirmChange;

		private List<SettingsPreset> presets;

		private SettingChangeSourceSelector[] categorySelectors;

		private SettingChangeSourceSlider[] categorySliders;

		private SettingChangeSourceCheckbox[] categoryCheckboxes;

		private int lastPresetIndex = -1;

		private UniTaskCompletionSource menuSwitchRequest;

		private PopupManager _popupManager;

		public bool HasChanges => diff.Count != 0;

		private PopupManager PopupManager => this.FindPopupManager(ref _popupManager);

		public event Action LocalizationButtonPressed;

		public void SetProvider(ASettingsProvider provider)
		{
			if (this.provider != null)
			{
				SetupProviderListeners(on: false);
				this.provider = null;
			}
			if (provider != null)
			{
				this.provider = provider;
				provider.ReloadPreferenceValues();
				SetupProviderListeners(on: true);
				OnMenuChanged(menuController.ActiveMenu);
			}
			if (provider.ShouldShowLanguageSelector)
			{
				languageSelectorController.SetProvider(provider);
				languageButton.gameObject.SetActive(value: true);
			}
			else
			{
				languageSelectorController.gameObject.SetActive(value: false);
				languageButton.gameObject.SetActive(value: false);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			seatedAreaPlayType.onValueChanged.AddListener(delegate
			{
				RefreshSeatedOrRoomscale();
			});
		}

		private void RefreshSeatedOrRoomscale()
		{
			if ((bool)provider)
			{
				roomscaleHeight.SetActive(provider.IsVR && !seatedAreaPlayType.isOn);
				seatedHeight.SetActive(provider.IsVR && seatedAreaPlayType.isOn);
			}
		}

		private void RefreshWandDependentSettings()
		{
			bool anyWandController = provider.AnyWandController;
			itemHoldTypeGO.gameObject.SetActive(!anyWandController);
			wandPressToMoveGO.gameObject.SetActive(anyWandController);
		}

		private void SetupProviderListeners(bool on)
		{
			if (!(provider != null))
			{
				return;
			}
			if (on)
			{
				platformSpecificElements.SetPlatform(provider.IsVR);
				SettingChangeSource[] componentsInChildren = GetComponentsInChildren<SettingChangeSource>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].SetProvider(provider);
				}
				applyChanges.onClick.AddListener(provider.ApplyChanges);
				revertChanges.onClick.AddListener(provider.RevertChanges);
				exportTelemetry.onClick.AddListener(ExportTelemetry);
				menuController.MenuChanged += OnMenuChanged;
				fullscreenToggle.SetProvider(provider);
				localizationButton.onClick.AddListener(LocalizationScenePressed);
				calibrateHeightVRButton.onClick.AddListener(CalibrateHeightVRPressed);
				calibrateInputVRButton.onClick.AddListener(CalibrateInputVRPressed);
				provider.ResetOrApplied += ProviderOnResetOrApplied;
				RefreshSeatedOrRoomscale();
			}
			else
			{
				SettingChangeSource[] componentsInChildren = GetComponentsInChildren<SettingChangeSource>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].SetProvider(null);
				}
				applyChanges.onClick.RemoveListener(provider.ApplyChanges);
				revertChanges.onClick.RemoveListener(provider.RevertChanges);
				exportTelemetry.onClick.RemoveListener(ExportTelemetry);
				menuController.MenuChanged -= OnMenuChanged;
				fullscreenToggle.SetProvider(null);
				localizationButton.onClick.RemoveListener(LocalizationScenePressed);
				calibrateHeightVRButton.onClick.RemoveListener(CalibrateHeightVRPressed);
				calibrateInputVRButton.onClick.RemoveListener(CalibrateInputVRPressed);
				provider.ResetOrApplied -= ProviderOnResetOrApplied;
			}
		}

		private void LocalizationScenePressed()
		{
			if ((bool)provider)
			{
				DoThingIfProviderAndNoChanges(this.LocalizationButtonPressed ?? new Action(provider.OpenLocalizationScene));
			}
		}

		private void CalibrateHeightVRPressed()
		{
			if ((bool)provider)
			{
				DoThingIfProviderAndNoChanges(provider.CalibrateHeightVR);
			}
		}

		private void CalibrateInputVRPressed()
		{
			if ((bool)provider)
			{
				DoThingIfProviderAndNoChanges(provider.CalibrateInputVR);
			}
		}

		private void DoThingIfProviderAndNoChanges(Action action)
		{
			if (HasChanges && menuSwitchRequest == null)
			{
				RequestSwitch().ContinueWith(action);
			}
			else
			{
				action();
			}
		}

		private void ProviderOnResetOrApplied()
		{
			if ((bool)provider)
			{
				provider.GetDiff(diff);
			}
		}

		private void OnMenuChanged(UIMenu menu)
		{
			presetSelector.SelectionChanged -= PresetChanged;
			SettingsCategoryMarker settingsCategoryMarker = null;
			if (menu != null)
			{
				settingsCategoryMarker = menu.GetComponent<SettingsCategoryMarker>();
				categorySelectors = menuController.ActiveMenu.GetComponentsInChildren<SettingChangeSourceSelector>();
				categorySliders = menuController.ActiveMenu.GetComponentsInChildren<SettingChangeSourceSlider>();
				categoryCheckboxes = menuController.ActiveMenu.GetComponentsInChildren<SettingChangeSourceCheckbox>();
				if (settingsCategoryMarker.categoryName == "VR")
				{
					RefreshWandDependentSettings();
				}
			}
			string text = (((bool)settingsCategoryMarker && !string.IsNullOrEmpty(settingsCategoryMarker.categoryName)) ? settingsCategoryMarker.categoryName : null);
			if (!string.IsNullOrEmpty(text))
			{
				presets = provider.GetPresetsFor(text);
				if (presets != null && presets.Count > 0)
				{
					presetSelector.LocalizedValues = true;
					List<string> list = presets.Select((SettingsPreset p) => "settings/quality_level_" + p.Name.Replace(' ', '_').ToLower()).ToList();
					lastPresetIndex = -1;
					list.Add("custom");
					presetSelector.SetValues(list);
					presetSelector.gameObject.SetActive(value: true);
					UpdatePresetFromDiff();
					presetSelector.SelectionChanged += PresetChanged;
				}
				else
				{
					presetSelector.gameObject.SetActive(value: false);
				}
			}
			else
			{
				presets = null;
				presetSelector.gameObject.SetActive(value: false);
			}
		}

		private void Update()
		{
			if ((bool)provider)
			{
				provider.GetDiff(diff);
				bool hasChanges = HasChanges;
				applyChanges.gameObject.SetActive(hasChanges);
				revertChanges.gameObject.SetActive(hasChanges);
				infoTMPro.text = (hasChanges ? string.Join("\n", Enumerable.Select(diff, FormatChangeLine)) : "");
				if (presets != null)
				{
					UpdatePresetFromDiff();
				}
				if (hasChanges && provider.IsClosePauseMenuKeyPressed)
				{
					RequestSwitchFromClose();
				}
			}
			else
			{
				infoTMPro.text = "Interface was not set up correctly,\n'provider' reference is null";
			}
		}

		private void UpdatePresetFromDiff()
		{
			if (provider == null || presets == null)
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < presets.Count; i++)
			{
				bool flag = true;
				foreach (KeyValuePair<string, object> value2 in presets[i].Values)
				{
					if (provider.IsPreferenceApplicable(value2.Key))
					{
						PreferenceValues value;
						dynamic val = (provider.preferenceValues.TryGetValue(value2.Key, out value) ? value.latestValue : null);
						if ((!value2.Value.Equals(val)))
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					num = i;
					break;
				}
			}
			if (num >= 0)
			{
				lastPresetIndex = num;
				presetSelector.SetSelectedIndex(num, fireEvent: false);
			}
			else
			{
				lastPresetIndex = presets.Count;
				presetSelector.SetSelectedIndex(presets.Count, fireEvent: false);
			}
		}

		private void PresetChanged(IClickable clickable, int selectedIndex)
		{
			if (presets != null && selectedIndex <= presets.Count)
			{
				if (selectedIndex == presets.Count)
				{
					if (selectedIndex - lastPresetIndex == 1)
					{
						selectedIndex = 0;
						presetSelector.SetSelectedIndex(selectedIndex, fireEvent: false);
					}
					else
					{
						selectedIndex = presets.Count - 1;
						presetSelector.SetSelectedIndex(selectedIndex, fireEvent: false);
					}
				}
				foreach (KeyValuePair<string, object> value in presets[selectedIndex].Values)
				{
					if (provider.IsPreferenceApplicable(value.Key))
					{
						provider.AddChange(value.Key, value.Value);
					}
				}
			}
			lastPresetIndex = selectedIndex;
		}

		private string FormatChangeLine(KeyValuePair<string, PreferenceValues> kv)
		{
			string text = "#58C";
			return $"<line-height=100%><alpha=#70>{kv.Key}:<alpha=#FF> {kv.Value.originalValue}  <voffset=-1><size=150%><color={text}>»</color></size></voffset>  {kv.Value.latestValue}";
		}

		private void ExportTelemetry()
		{
			StartCoroutine(TelemetryExportingRoutine());
		}

		private IEnumerator TelemetryExportingRoutine()
		{
			if (provider.ExportTelemetry(out var exportedPath))
			{
				if (!string.IsNullOrEmpty(exportedPath))
				{
					Popup spinnerInstance = PopupManager.ShowPopup(spinnerDialog, new PopupLocalizationKeys
					{
						labelKey = "please_wait"
					});
					while (provider.IsStillExportingTelemetry)
					{
						yield return null;
					}
					spinnerInstance.RequestClose(PopupClosedByAction.Positive, "");
					PopupLocalizationKeys locKeys = new PopupLocalizationKeys
					{
						positiveKey = "ok",
						labelKey = "telemetry/exportsuccess"
					};
					Dictionary<string, string> locParams = new Dictionary<string, string> { { "PATH", exportedPath } };
					PopupManager.ShowPopup(messageDialog, locKeys, locParams);
				}
				else
				{
					PopupLocalizationKeys locKeys2 = new PopupLocalizationKeys
					{
						positiveKey = "ok",
						labelKey = "telemetry/exportnodata"
					};
					PopupManager.ShowPopup(messageDialog, locKeys2);
				}
			}
			else
			{
				PopupLocalizationKeys locKeys3 = new PopupLocalizationKeys
				{
					positiveKey = "ok",
					labelKey = "telemetry/exporterror"
				};
				PopupManager.ShowPopup(messageDialog, locKeys3);
			}
		}

		public void RequestSwitchFromClose()
		{
			if (menuSwitchRequest == null)
			{
				RequestSwitch().Forget();
			}
		}

		public UniTask RequestSwitch()
		{
			if (HasChanges)
			{
				menuSwitchRequest = new UniTaskCompletionSource();
				OpenPopup();
				return menuSwitchRequest.Task;
			}
			return UniTask.FromResult(value: true);
		}

		GameObject IUIMenuSwitchPreventer.GetGameObject()
		{
			return base.gameObject;
		}

		private void OpenPopup()
		{
			if (!PopupManager.CanShowPopup())
			{
				Debug.LogWarning("PopupManager can't show popups at this moment", this);
				return;
			}
			PopupLocalizationKeys locKeys = new PopupLocalizationKeys
			{
				labelKey = "settings/confirm_changes_popup",
				positiveKey = "save",
				negativeKey = "discard",
				abortionKey = "cancel"
			};
			PopupManager.ShowPopup(confirmChange, locKeys).Closed += delegate(PopupResult result)
			{
				switch (result.closedBy)
				{
				case PopupClosedByAction.Abortion:
					menuSwitchRequest.TrySetCanceled();
					break;
				case PopupClosedByAction.Positive:
					provider.ApplyChanges();
					menuSwitchRequest.TrySetResult();
					break;
				case PopupClosedByAction.Negative:
					provider.RevertChanges();
					menuSwitchRequest.TrySetResult();
					break;
				default:
					Debug.LogError($"Unhandled case '{result.closedBy}'");
					break;
				}
				menuSwitchRequest = null;
			};
		}
	}
}
