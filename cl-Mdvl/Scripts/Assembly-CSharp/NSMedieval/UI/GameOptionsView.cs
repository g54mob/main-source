using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Types;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class GameOptionsView : OptionsView
	{
		[SerializeField]
		private ButtonLayoutItemView difficultyButton;

		[FormerlySerializedAs("autosaveOptionsDropdown")]
		[SerializeField]
		private TMP_Dropdown autoSaveOptionsDropdown;

		[SerializeField]
		private TMP_Dropdown temperatureUnitsDropdown;

		[SerializeField]
		private TMP_Dropdown animalNamesDropdown;

		[SerializeField]
		private Slider hoverIntensity;

		[SerializeField]
		private Toggle showTutorialToggle;

		[SerializeField]
		private Toggle workerNamesToggle;

		[SerializeField]
		private Toggle devToolsToggle;

		[SerializeField]
		private Toggle autoReportExceptionToggle;

		[SerializeField]
		private TMP_Dropdown userInterfaceScaleDropdown;

		[SerializeField]
		private ScreenSettingsResetView screenSettingsFailsafePanel;

		[SerializeField]
		private GameOptionDifficultyView gameOptionDifficultyView;

		private int previousUiValue;

		private int savedUISizeIndex;

		public void Reset()
		{
			userInterfaceScaleDropdown.value = savedUISizeIndex;
		}

		private void Start()
		{
			autoSaveOptionsDropdown.onValueChanged.AddListener(delegate(int value)
			{
				OnAutoSaveFrequencyChange(value);
			});
			temperatureUnitsDropdown.onValueChanged.AddListener(delegate
			{
				OnTemperatureUnitsChange();
			});
			showTutorialToggle.onValueChanged.AddListener(delegate
			{
				OnShowTutorialToggleChange();
			});
			devToolsToggle.onValueChanged.AddListener(delegate
			{
				OnDevToolsToggleChange();
			});
			workerNamesToggle.onValueChanged.AddListener(delegate
			{
				OnShowWorkerNamesChange();
			});
			animalNamesDropdown.onValueChanged.AddListener(delegate
			{
				OnAnimalNamesChange();
			});
			hoverIntensity.onValueChanged.AddListener(delegate
			{
				OnHoverIntensityChange();
			});
			userInterfaceScaleDropdown.onValueChanged.AddListener(OnUIScaleDropdownChange);
			autoReportExceptionToggle.onValueChanged.AddListener(delegate
			{
				OnAutoReportToggleChange();
			});
			difficultyButton.Button.onClick.AddListener(delegate
			{
				gameOptionDifficultyView.Show();
				Hide();
			});
		}

		public override void Show()
		{
			base.Show();
			GlobalSaveController instance = MonoSingleton<GlobalSaveController>.Instance;
			if (SceneManager.GetActiveScene().name == "MainScene")
			{
				difficultyButton.gameObject.SetActive(value: true);
				difficultyButton.TextObject.SetText(base.Localize.GetText("scenario_game_difficulty") ?? "");
			}
			else
			{
				difficultyButton.gameObject.SetActive(value: false);
			}
			SetupFrequencyOption(instance.GlobalSettings.AutosaveFrequency);
			SetupTemperatureUnitsOption((int)instance.GlobalSettings.TemperatureUnits);
			SetupUIScaleOption((int)MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CurrentUISize);
			workerNamesToggle.isOn = instance.GlobalSettings.ShowWorkerNames;
			SetupAnimalNameOptions(instance.GlobalSettings.ShowAnimalNameOption);
			hoverIntensity.value = instance.GlobalSettings.HoverIntensity;
			showTutorialToggle.isOn = instance.GlobalSettings.ShowTutorial;
			autoReportExceptionToggle.isOn = instance.GlobalSettings.SendAutoReports;
			devToolsToggle.transform.parent.gameObject.SetActive(value: false);
			devToolsToggle.isOn = false;
		}

		private void SetupAnimalNameOptions(int globalSettingsShowAnimalNameOption)
		{
			List<string> list = new List<string>();
			foreach (int value in Enum.GetValues(typeof(AnimalNamesOption)))
			{
				if (value == 0)
				{
					list.Add(base.Localize.GetText("general_none"));
				}
				else
				{
					list.Add(base.Localize.GetText($"options_animal_names_{value}"));
				}
			}
			animalNamesDropdown.ClearOptions();
			animalNamesDropdown.AddOptions(list);
			animalNamesDropdown.SetValueWithoutNotify(globalSettingsShowAnimalNameOption);
		}

		private void OnAutoSaveFrequencyChange(int value)
		{
			MonoSingleton<OptionsController>.Instance.SetAutosaveFrequency(value);
		}

		private void OnTemperatureUnitsChange()
		{
			MonoSingleton<OptionsController>.Instance.SetTemperatureUnits((TemperatureUnitsType)temperatureUnitsDropdown.value);
		}

		private void OnShowTutorialToggleChange()
		{
			MonoSingleton<OptionsController>.Instance.SetShowTutorial(showTutorialToggle.isOn);
		}

		private void OnDevToolsToggleChange()
		{
			MonoSingleton<OptionsController>.Instance.SetDevTools(devToolsToggle.isOn);
		}

		private void OnShowWorkerNamesChange()
		{
			MonoSingleton<OptionsController>.Instance.SetShowWorkerNames(workerNamesToggle.isOn);
		}

		private void OnAnimalNamesChange()
		{
			MonoSingleton<OptionsController>.Instance.SetAnimalNameOption(animalNamesDropdown.value);
		}

		private void OnHoverIntensityChange()
		{
			MonoSingleton<OptionsController>.Instance.SetHoverIntensity(hoverIntensity.value);
		}

		private void OnAutoReportToggleChange()
		{
			MonoSingleton<OptionsController>.Instance.SetSendAutoReports(autoReportExceptionToggle.isOn);
		}

		private void OnUIScaleDropdownChange(int value)
		{
			MonoSingleton<OptionsController>.Instance.SetUIScale(userInterfaceScaleDropdown.value, savedUISizeIndex);
			screenSettingsFailsafePanel.ShowUIScale(delegate
			{
				savedUISizeIndex = value;
				MonoSingleton<OptionsController>.Instance.KeepUIScale();
			}, delegate
			{
				userInterfaceScaleDropdown.value = savedUISizeIndex;
				MonoSingleton<OptionsController>.Instance.RevertUIScale();
			});
		}

		private void SetupUIScaleOption(int index)
		{
			userInterfaceScaleDropdown.ClearOptions();
			userInterfaceScaleDropdown.AddOptions((from UISizes size in Enum.GetValues(typeof(UISizes))
				select base.Localize.GetText($"options_ui_size_{size}")).ToList());
			savedUISizeIndex = index;
			userInterfaceScaleDropdown.SetValueWithoutNotify(index);
		}

		private void SetupFrequencyOption(int frequency)
		{
			autoSaveOptionsDropdown.ClearOptions();
			autoSaveOptionsDropdown.AddOptions((from item in Enum.GetNames(typeof(AutosaveOptions))
				select MonoSingleton<LocalizationController>.Instance.GetText("autosave_" + item.ToLower())).ToList());
			autoSaveOptionsDropdown.value = frequency;
		}

		private void SetupTemperatureUnitsOption(int index)
		{
			temperatureUnitsDropdown.ClearOptions();
			temperatureUnitsDropdown.AddOptions(Enum.GetValues(typeof(TemperatureUnitsType)).Cast<TemperatureUnitsType>().Select(delegate(TemperatureUnitsType temperatureUnit)
			{
				LocalizationController instance = MonoSingleton<LocalizationController>.Instance;
				TemperatureUnitsType temperatureUnitsType = temperatureUnit;
				return instance.GetText("general_" + temperatureUnitsType);
			})
				.ToList());
			temperatureUnitsDropdown.value = index;
		}
	}
}
