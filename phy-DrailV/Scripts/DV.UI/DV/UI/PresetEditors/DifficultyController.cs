using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DV.Localization;
using DV.Scenarios.Common;
using DV.UIFramework;
using DV.Util;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	public class DifficultyController : APresetEditorController<IDifficulty>
	{
		private readonly float[] paymentPercentageValues = new float[7] { 0.25f, 0.5f, 0.75f, 1f, 1.25f, 1.5f, 2f };

		private readonly float[] bonusTimePercentageValues = new float[5] { 0.5f, 0.75f, 1f, 1.5f, 2f };

		private readonly float[] weatherChangeSpeedPercentageValues = new float[10] { 0f, 0.05f, 0.1f, 0.25f, 0.5f, 0.75f, 1f, 1.25f, 1.5f, 2f };

		private readonly float[] steamStartupPercentageValues = new float[9] { 0.25f, 0.5f, 1f, 1.5f, 2f, 3f, 5f, 10f, 25f };

		private readonly float[] mainResFillTimePercentageValues = new float[4] { 1f, 2.5f, 5f, 10f };

		private readonly float[] percentage25Step0To200Without175 = new float[8] { 0f, 0.25f, 0.5f, 0.75f, 1f, 1.25f, 1.5f, 2f };

		private readonly string[] automaticHandbrakeLocalizationKeys = new string[4] { "difficulty/auto_handbrake_off", "difficulty/auto_handbrake_remote", "difficulty/auto_handbrake_remote_and_ui", "difficulty/auto_handbrake_always" };

		private readonly string[] automaticHeadlightsLocalizationKeys = new string[3] { "difficulty/auto_headlights_off", "difficulty/auto_headlights_direction", "difficulty/auto_headlights_all" };

		private readonly string[] keyboardDrivingLocalizationKeys = new string[3] { "difficulty/keyboard_driving_off", "difficulty/keyboard_driving_within_reach", "difficulty/keyboard_driving_on_vehicle" };

		private readonly string[] remoteSwitchLocalizationKeys = new string[3] { "difficulty/remote_switch_off", "difficulty/remote_switch_comms", "difficulty/remote_switch_ui" };

		private readonly string[] remoteCoupleLocalizationKeys = new string[3] { "difficulty/remote_couple_off", "difficulty/remote_couple_remote", "difficulty/remote_couple_ui" };

		private readonly string[] startingItemsLocalizationKeys = new string[4] { "difficulty/start_items_basic", "difficulty/start_items_expanded", "difficulty/start_items_engineer", "difficulty/start_items_auto" };

		private readonly string[] fastTravelLocalizationKeys = new string[3] { "difficulty/fast_travel_free", "difficulty/fast_travel_paid", "difficulty/fast_travel_off" };

		private readonly string[] dashLocalizationKeys = new string[3] { "difficulty/dash_off", "difficulty/dash_short", "difficulty/dash_long" };

		private readonly string[] weatherEditorLocalizationKeys = new string[4] { "difficulty/weather_editor_off", "difficulty/weather_editor_paused_photo_mode", "difficulty/weather_editor_photo_mode", "difficulty/weather_editor_on" };

		private readonly (int value, string label)[] maxCopayValueLabelPairs = new(int, string)[12]
		{
			(100, "$100"),
			(1000, "$1k"),
			(5000, "$5k"),
			(10000, "$10k"),
			(20000, "$20k"),
			(50000, "$50k"),
			(100000, "$100k"),
			(200000, "$200k"),
			(500000, "$500k"),
			(1000000, "$1m"),
			(2000000, "$2m"),
			(5000000, "$5m")
		};

		private readonly (int value, string label)[] rerailMaxCostValueLabelPairs = new(int, string)[7]
		{
			(0, "$0"),
			(100, "$100"),
			(1000, "$1k"),
			(5000, "$5k"),
			(10000, "$10k"),
			(20000, "$20k"),
			(50000, "$50k")
		};

		private readonly (int value, string label)[] clearMaxCostValueLabelPairs = new(int, string)[4]
		{
			(0, "$0"),
			(100, "$100"),
			(1000, "$1k"),
			(5000, "$5k")
		};

		private readonly (int value, string label)[] summonWorkTrainMaxCostValueLabelPairs = new(int, string)[7]
		{
			(0, "$0"),
			(100, "$100"),
			(1000, "$1k"),
			(5000, "$5k"),
			(10000, "$10k"),
			(20000, "$20k"),
			(50000, "$50k")
		};

		private readonly (float value, string label)[] commsRadioCheatModeValueLabelPairs = new(float, string)[2]
		{
			(0f, "difficulty/comms_cheat_off"),
			(1f, "difficulty/comms_cheat_sandbox")
		};

		private readonly (int value, string label)[] dayDurationValueLocLabelPairs = new(int, string)[9]
		{
			(30, "difficulty/day_duration_30m"),
			(60, "difficulty/day_duration_1h"),
			(120, "difficulty/day_duration_2h"),
			(180, "difficulty/day_duration_3h"),
			(240, "difficulty/day_duration_4h"),
			(360, "difficulty/day_duration_6h"),
			(480, "difficulty/day_duration_8h"),
			(720, "difficulty/day_duration_12h"),
			(1440, "difficulty/day_duration_24h")
		};

		private readonly (int value, string label)[] sleepCooldownInHoursPairs = new(int, string)[9]
		{
			(0, "difficulty/sleep_cooldown_none"),
			(1, "difficulty/sleep_cooldown_1h"),
			(2, "difficulty/sleep_cooldown_2h"),
			(4, "difficulty/sleep_cooldown_4h"),
			(6, "difficulty/sleep_cooldown_6h"),
			(8, "difficulty/sleep_cooldown_8h"),
			(10, "difficulty/sleep_cooldown_10h"),
			(12, "difficulty/sleep_cooldown_12h"),
			(-1, "difficulty/sleep_cooldown_infinite")
		};

		[Header("GUI Element References")]
		[NullCheck]
		public SliderSelector keyboardDrivingSliderSelector;

		[NullCheck]
		public ToggleDV freeCamCheckbox;

		[NullCheck]
		public ToggleDV hudCheckbox;

		[NullCheck]
		public SliderSelector paymentSliderSelector;

		[NullCheck]
		public SliderSelector bonusTimeSliderSelector;

		[NullCheck]
		public SliderSelector maxCopaySliderSelector;

		[NullCheck]
		public ToggleDV drivetrainFailuresCheckbox;

		[NullCheck]
		public ToggleDV tractionFailuresCheckbox;

		[NullCheck]
		public ToggleDV brakeFailuresCheckbox;

		[NullCheck]
		public ToggleDV brakeWarningsCheckbox;

		[NullCheck]
		public ToggleDV remoteHandbrakeCheckbox;

		[NullCheck]
		public SliderSelector automaticHandbrakeSliderSelector;

		[NullCheck]
		public SliderSelector automaticHeadlightSliderSelector;

		[NullCheck]
		public SliderSelector resourceConsumptionSliderSelector;

		[NullCheck]
		public SliderSelector resourceCostSliderSelector;

		[NullCheck]
		public SliderSelector damageSliderSelector;

		[NullCheck]
		public SliderSelector repairCostSliderSelector;

		[NullCheck]
		public SliderSelector cargoDamageCostSliderSelector;

		[NullCheck]
		public SliderSelector environmentDamageCostSliderSelector;

		[NullCheck]
		public ToggleDV multiServicingCheckbox;

		[NullCheck]
		public SliderSelector remoteSwitchingSliderSelector;

		[NullCheck]
		public SliderSelector remoteCouplingSliderSelector;

		[NullCheck]
		public ToggleDV vrRemoteDrivingCheckbox;

		[NullCheck]
		public ToggleDV remoteSignReadCheckbox;

		[NullCheck]
		public ToggleDV derailCheckbox;

		[NullCheck]
		public SliderSelector steamStartupSliderSelector;

		[NullCheck]
		public SliderSelector mainResFillTimeSliderSelector;

		[NullCheck]
		public SliderSelector rerailMaxCostSliderSelector;

		[NullCheck]
		public ToggleDV clearDerailedCheckbox;

		[NullCheck]
		public SliderSelector clearMaxCostSliderSelector;

		[NullCheck]
		public SliderSelector summonWorkTrainMaxCostSliderSelector;

		[NullCheck]
		public SliderSelector commsRadioCheatModeSliderSelector;

		[NullCheck]
		public SliderSelector startingItemsSliderSelector;

		[NullCheck]
		public ToggleDV inventoryItemRespawnCheckbox;

		[NullCheck]
		public ToggleDV mapBlipsCheckbox;

		[NullCheck]
		public SliderSelector fastTravelSliderSelector;

		[NullCheck]
		public SliderSelector dashSelector;

		[NullCheck]
		public ToggleDV cameraDashCheckbox;

		[NullCheck]
		public SliderSelector dayDurationSliderSelector;

		[NullCheck]
		public SliderSelector weatherChangeSpeedSliderSelector;

		[NullCheck]
		public ToggleDV rainCheckbox;

		[NullCheck]
		public ToggleDV lightningsCheckbox;

		[NullCheck]
		public SliderSelector weatherEditorSliderSelector;

		[NullCheck]
		public ToggleDV timeOfDayEditingCheckbox;

		[NullCheck]
		public ToggleDV singleSaveModeCheckbox;

		[NullCheck]
		public SliderSelector sleepCooldownSelector;

		private IScenarioCRUD crud;

		private bool needsRefreshInterface;

		private bool reentrancyCheck_RefreshData;

		private bool reentrancyCheck_RefreshInterface;

		protected override string LOC_RENAME_PROMPT => "difficulty/rename_difficulty_prompt";

		protected override string LOC_DELETE_PROMPT => "difficulty/delete_difficulty_prompt";

		protected override string LOC_SAVE_OR_REVERT_PROMPT => "scenario/save_or_revert_difficulty";

		protected override bool HasSaveButton => true;

		protected override bool HasOpenFolderButton => true;

		protected override bool HasDoneButton => true;

		public override IScenarioCRUD CRUD => crud;

		public override ObservableCollectionExt<IDifficulty> Things => crud?.Difficulties;

		public override IDifficulty CurrentThing { get; protected set; }

		private List<string> PercentagesToListOfStrings(float[] percentages)
		{
			return percentages.Select((float p) => $"{Mathf.RoundToInt(p * 100f)}%").ToList();
		}

		public void SetData(IScenarioCRUD crud, IDifficulty difficulty, bool isVR)
		{
			this.crud = crud;
			base.isVR = isVR;
			CurrentThing = difficulty;
			base.IsInitialized = true;
		}

		protected override bool IsDefaultPresetName(string name)
		{
			if (!DifficultyExtensions.LOCALIZATION_KEYS.ContainsKey(name))
			{
				return DifficultyExtensions.LOCALIZATION_KEYS.Values.Select((string val) => LocalizationAPI.L(val)).Contains(name);
			}
			return true;
		}

		protected override void Awake()
		{
			base.Awake();
			paymentSliderSelector.SetValues(PercentagesToListOfStrings(paymentPercentageValues));
			bonusTimeSliderSelector.SetValues(PercentagesToListOfStrings(bonusTimePercentageValues));
			resourceConsumptionSliderSelector.SetValues(PercentagesToListOfStrings(percentage25Step0To200Without175));
			resourceCostSliderSelector.SetValues(PercentagesToListOfStrings(percentage25Step0To200Without175));
			damageSliderSelector.SetValues(PercentagesToListOfStrings(percentage25Step0To200Without175));
			repairCostSliderSelector.SetValues(PercentagesToListOfStrings(percentage25Step0To200Without175));
			cargoDamageCostSliderSelector.SetValues(PercentagesToListOfStrings(percentage25Step0To200Without175));
			environmentDamageCostSliderSelector.SetValues(PercentagesToListOfStrings(percentage25Step0To200Without175));
			keyboardDrivingSliderSelector.LocalizedValues = true;
			keyboardDrivingSliderSelector.SetValues(keyboardDrivingLocalizationKeys.ToList());
			automaticHandbrakeSliderSelector.LocalizedValues = true;
			automaticHandbrakeSliderSelector.SetValues(automaticHandbrakeLocalizationKeys.ToList());
			automaticHeadlightSliderSelector.LocalizedValues = true;
			automaticHeadlightSliderSelector.SetValues(automaticHeadlightsLocalizationKeys.ToList());
			remoteSwitchingSliderSelector.LocalizedValues = true;
			remoteSwitchingSliderSelector.SetValues(remoteSwitchLocalizationKeys.ToList());
			remoteCouplingSliderSelector.LocalizedValues = true;
			remoteCouplingSliderSelector.SetValues(remoteCoupleLocalizationKeys.ToList());
			startingItemsSliderSelector.LocalizedValues = true;
			startingItemsSliderSelector.SetValues(startingItemsLocalizationKeys.ToList());
			maxCopaySliderSelector.SetValues(maxCopayValueLabelPairs.Select(((int value, string label) mc) => mc.label).ToList());
			steamStartupSliderSelector.SetValues(PercentagesToListOfStrings(steamStartupPercentageValues));
			mainResFillTimeSliderSelector.SetValues(PercentagesToListOfStrings(mainResFillTimePercentageValues));
			rerailMaxCostSliderSelector.SetValues(rerailMaxCostValueLabelPairs.Select(((int value, string label) rmc) => rmc.label).ToList());
			clearMaxCostSliderSelector.SetValues(clearMaxCostValueLabelPairs.Select(((int value, string label) cmc) => cmc.label).ToList());
			summonWorkTrainMaxCostSliderSelector.SetValues(summonWorkTrainMaxCostValueLabelPairs.Select(((int value, string label) swtmc) => swtmc.label).ToList());
			commsRadioCheatModeSliderSelector.LocalizedValues = true;
			commsRadioCheatModeSliderSelector.SetValues(commsRadioCheatModeValueLabelPairs.Select(((float value, string label) crcm) => crcm.label).ToList());
			fastTravelSliderSelector.LocalizedValues = true;
			fastTravelSliderSelector.SetValues(fastTravelLocalizationKeys.ToList());
			dashSelector.LocalizedValues = true;
			dashSelector.SetValues(dashLocalizationKeys.ToList());
			dayDurationSliderSelector.LocalizedValues = true;
			dayDurationSliderSelector.SetValues(dayDurationValueLocLabelPairs.Select(((int value, string label) dd) => dd.label).ToList());
			weatherChangeSpeedSliderSelector.SetValues(PercentagesToListOfStrings(weatherChangeSpeedPercentageValues));
			weatherEditorSliderSelector.LocalizedValues = true;
			weatherEditorSliderSelector.SetValues(weatherEditorLocalizationKeys.ToList());
			sleepCooldownSelector.LocalizedValues = true;
			sleepCooldownSelector.SetValues(sleepCooldownInHoursPairs.Select(((int value, string label) sch) => sch.label).ToList());
		}

		protected override void SetupListeners(bool on)
		{
			base.SetupListeners(on);
			if (on)
			{
				keyboardDrivingSliderSelector.SelectionChanged += OnSelectorChanged;
				freeCamCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				hudCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				paymentSliderSelector.SelectionChanged += OnSelectorChanged;
				bonusTimeSliderSelector.SelectionChanged += OnSelectorChanged;
				maxCopaySliderSelector.SelectionChanged += OnSelectorChanged;
				drivetrainFailuresCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				tractionFailuresCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				brakeFailuresCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				brakeWarningsCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				remoteHandbrakeCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				automaticHandbrakeSliderSelector.SelectionChanged += OnSelectorChanged;
				automaticHeadlightSliderSelector.SelectionChanged += OnSelectorChanged;
				resourceConsumptionSliderSelector.SelectionChanged += OnSelectorChanged;
				resourceCostSliderSelector.SelectionChanged += OnSelectorChanged;
				damageSliderSelector.SelectionChanged += OnSelectorChanged;
				repairCostSliderSelector.SelectionChanged += OnSelectorChanged;
				cargoDamageCostSliderSelector.SelectionChanged += OnSelectorChanged;
				environmentDamageCostSliderSelector.SelectionChanged += OnSelectorChanged;
				multiServicingCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				remoteSwitchingSliderSelector.SelectionChanged += OnSelectorChanged;
				remoteCouplingSliderSelector.SelectionChanged += OnSelectorChanged;
				vrRemoteDrivingCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				remoteSignReadCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				derailCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				steamStartupSliderSelector.SelectionChanged += OnSelectorChanged;
				mainResFillTimeSliderSelector.SelectionChanged += OnSelectorChanged;
				rerailMaxCostSliderSelector.SelectionChanged += OnSelectorChanged;
				clearDerailedCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				clearMaxCostSliderSelector.SelectionChanged += OnSelectorChanged;
				summonWorkTrainMaxCostSliderSelector.SelectionChanged += OnSelectorChanged;
				commsRadioCheatModeSliderSelector.SelectionChanged += OnSelectorChanged;
				startingItemsSliderSelector.SelectionChanged += OnSelectorChanged;
				inventoryItemRespawnCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				mapBlipsCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				fastTravelSliderSelector.SelectionChanged += OnSelectorChanged;
				dashSelector.SelectionChanged += OnSelectorChanged;
				cameraDashCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				dayDurationSliderSelector.SelectionChanged += OnSelectorChanged;
				weatherChangeSpeedSliderSelector.SelectionChanged += OnSelectorChanged;
				rainCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				lightningsCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				weatherEditorSliderSelector.SelectionChanged += OnSelectorChanged;
				timeOfDayEditingCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				singleSaveModeCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				sleepCooldownSelector.SelectionChanged += OnSelectorChanged;
			}
			else
			{
				keyboardDrivingSliderSelector.SelectionChanged -= OnSelectorChanged;
				freeCamCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				hudCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				paymentSliderSelector.SelectionChanged -= OnSelectorChanged;
				bonusTimeSliderSelector.SelectionChanged -= OnSelectorChanged;
				maxCopaySliderSelector.SelectionChanged -= OnSelectorChanged;
				drivetrainFailuresCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				tractionFailuresCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				brakeFailuresCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				brakeWarningsCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				remoteHandbrakeCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				automaticHandbrakeSliderSelector.SelectionChanged -= OnSelectorChanged;
				automaticHeadlightSliderSelector.SelectionChanged -= OnSelectorChanged;
				resourceConsumptionSliderSelector.SelectionChanged -= OnSelectorChanged;
				resourceCostSliderSelector.SelectionChanged -= OnSelectorChanged;
				damageSliderSelector.SelectionChanged -= OnSelectorChanged;
				repairCostSliderSelector.SelectionChanged -= OnSelectorChanged;
				cargoDamageCostSliderSelector.SelectionChanged -= OnSelectorChanged;
				environmentDamageCostSliderSelector.SelectionChanged -= OnSelectorChanged;
				multiServicingCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				remoteSwitchingSliderSelector.SelectionChanged -= OnSelectorChanged;
				remoteCouplingSliderSelector.SelectionChanged -= OnSelectorChanged;
				vrRemoteDrivingCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				remoteSignReadCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				derailCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				steamStartupSliderSelector.SelectionChanged -= OnSelectorChanged;
				mainResFillTimeSliderSelector.SelectionChanged -= OnSelectorChanged;
				rerailMaxCostSliderSelector.SelectionChanged -= OnSelectorChanged;
				clearDerailedCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				clearMaxCostSliderSelector.SelectionChanged -= OnSelectorChanged;
				summonWorkTrainMaxCostSliderSelector.SelectionChanged -= OnSelectorChanged;
				commsRadioCheatModeSliderSelector.SelectionChanged -= OnSelectorChanged;
				startingItemsSliderSelector.SelectionChanged -= OnSelectorChanged;
				inventoryItemRespawnCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				mapBlipsCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				fastTravelSliderSelector.SelectionChanged -= OnSelectorChanged;
				dashSelector.SelectionChanged -= OnSelectorChanged;
				cameraDashCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				dayDurationSliderSelector.SelectionChanged -= OnSelectorChanged;
				weatherChangeSpeedSliderSelector.SelectionChanged -= OnSelectorChanged;
				rainCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				lightningsCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				weatherEditorSliderSelector.SelectionChanged -= OnSelectorChanged;
				timeOfDayEditingCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				singleSaveModeCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				sleepCooldownSelector.SelectionChanged -= OnSelectorChanged;
			}
		}

		public override void RefreshData()
		{
			if (reentrancyCheck_RefreshData)
			{
				Debug.LogError(GetType().Name + " RefreshData reentrancy check fail!", this);
			}
			reentrancyCheck_RefreshData = true;
			base.RefreshData();
			RefreshInterface();
			reentrancyCheck_RefreshData = false;
		}

		public override void RefreshInterface()
		{
			if (reentrancyCheck_RefreshInterface)
			{
				Debug.LogError(GetType().Name + " RefreshInterface reentrancy check fail!", this);
			}
			reentrancyCheck_RefreshInterface = true;
			base.RefreshInterface();
			if (CurrentThing != null)
			{
				UpdateAllValues();
				ToggleBunchOfElements(!CurrentThing.IsReadOnly);
			}
			else
			{
				ToggleBunchOfElements(enabled: false);
			}
			reentrancyCheck_RefreshInterface = false;
		}

		private void ToggleBunchOfElements(bool enabled)
		{
			keyboardDrivingSliderSelector.ToggleInteractable(enabled);
			freeCamCheckbox.ToggleInteractable(enabled);
			hudCheckbox.ToggleInteractable(enabled);
			paymentSliderSelector.ToggleInteractable(enabled);
			bonusTimeSliderSelector.ToggleInteractable(enabled);
			maxCopaySliderSelector.ToggleInteractable(enabled);
			drivetrainFailuresCheckbox.ToggleInteractable(enabled);
			tractionFailuresCheckbox.ToggleInteractable(enabled);
			brakeFailuresCheckbox.ToggleInteractable(enabled);
			brakeWarningsCheckbox.ToggleInteractable(enabled);
			remoteHandbrakeCheckbox.ToggleInteractable(enabled);
			automaticHandbrakeSliderSelector.ToggleInteractable(enabled);
			automaticHeadlightSliderSelector.ToggleInteractable(enabled);
			resourceConsumptionSliderSelector.ToggleInteractable(enabled);
			resourceCostSliderSelector.ToggleInteractable(enabled);
			damageSliderSelector.ToggleInteractable(enabled);
			repairCostSliderSelector.ToggleInteractable(enabled);
			cargoDamageCostSliderSelector.ToggleInteractable(enabled);
			environmentDamageCostSliderSelector.ToggleInteractable(enabled);
			multiServicingCheckbox.ToggleInteractable(enabled);
			remoteSwitchingSliderSelector.ToggleInteractable(enabled);
			remoteCouplingSliderSelector.ToggleInteractable(enabled);
			vrRemoteDrivingCheckbox.ToggleInteractable(enabled);
			remoteSignReadCheckbox.ToggleInteractable(enabled);
			derailCheckbox.ToggleInteractable(enabled);
			steamStartupSliderSelector.ToggleInteractable(enabled);
			mainResFillTimeSliderSelector.ToggleInteractable(enabled);
			rerailMaxCostSliderSelector.ToggleInteractable(enabled);
			clearDerailedCheckbox.ToggleInteractable(enabled);
			clearMaxCostSliderSelector.ToggleInteractable(enabled);
			summonWorkTrainMaxCostSliderSelector.ToggleInteractable(enabled);
			commsRadioCheatModeSliderSelector.ToggleInteractable(enabled);
			startingItemsSliderSelector.ToggleInteractable(enabled);
			inventoryItemRespawnCheckbox.ToggleInteractable(enabled);
			mapBlipsCheckbox.ToggleInteractable(enabled);
			fastTravelSliderSelector.ToggleInteractable(enabled);
			dashSelector.ToggleInteractable(enabled);
			cameraDashCheckbox.ToggleInteractable(enabled);
			dayDurationSliderSelector.ToggleInteractable(enabled);
			weatherChangeSpeedSliderSelector.ToggleInteractable(enabled);
			rainCheckbox.ToggleInteractable(enabled);
			lightningsCheckbox.ToggleInteractable(enabled);
			weatherEditorSliderSelector.ToggleInteractable(enabled);
			timeOfDayEditingCheckbox.ToggleInteractable(enabled);
			singleSaveModeCheckbox.ToggleInteractable(enabled);
			sleepCooldownSelector.ToggleInteractable(enabled);
		}

		protected override void OnPresetSelected(IClickable _, int selectedIndex)
		{
			CurrentThing = crud.Difficulties[selectedIndex];
			RefreshData();
		}

		protected override void OnSavePresetClicked()
		{
			crud.Flush();
			RefreshInterface();
		}

		protected override string GetSuggestedNameForNew()
		{
			return CRUD.GetAutoIncrementName(CurrentThing);
		}

		protected override void CreateNewImpl(string nameToUse)
		{
			CurrentThing = ((CurrentThing == null) ? crud.CreateDifficulty() : crud.CreateCopyOf(CurrentThing));
			CurrentThing.Name = nameToUse;
			CRUD.Flush();
		}

		protected override void DeleteImpl()
		{
			crud.DeleteDifficulty(CurrentThing);
			CurrentThing = null;
		}

		protected override void FlushChanges()
		{
			CRUD.Flush();
		}

		private int GetIndexForSelector(int value, int[] availableValues)
		{
			int num = Array.IndexOf(availableValues, value);
			if (num == -1)
			{
				int num2 = Mathf.Clamp(value, availableValues.Min(), availableValues.Max());
				Debug.LogWarning($"Float value {value} not available values, clamped it to {num2}", this);
				num = Array.IndexOf(availableValues, num2);
			}
			return num;
		}

		private int GetIndexForSelector(float value, float[] availableValues)
		{
			int num = Array.IndexOf(availableValues, value);
			if (num == -1)
			{
				float num2 = Mathf.Clamp(value, availableValues.Min(), availableValues.Max());
				Debug.LogWarning($"Int value {value} not available values, clamped it to {num2}", this);
				num = Array.IndexOf(availableValues, num2);
			}
			return num;
		}

		private void UpdateAllValues()
		{
			keyboardDrivingSliderSelector.SetSelectedIndex(CurrentThing.KeyboardDriving, fireEvent: false);
			freeCamCheckbox.SetIsOnWithoutNotify(CurrentThing.FreeCamera);
			hudCheckbox.SetIsOnWithoutNotify(CurrentThing.HUD);
			paymentSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.PaymentModifier, paymentPercentageValues), fireEvent: false);
			bonusTimeSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.BonusTimeModifier, bonusTimePercentageValues), fireEvent: false);
			maxCopaySliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.MaxCopay, maxCopayValueLabelPairs.Select(((int value, string label) mc) => mc.value).ToArray()), fireEvent: false);
			drivetrainFailuresCheckbox.SetIsOnWithoutNotify(CurrentThing.DrivetrainFailures);
			tractionFailuresCheckbox.SetIsOnWithoutNotify(CurrentThing.TractionFailures);
			brakeFailuresCheckbox.SetIsOnWithoutNotify(CurrentThing.BrakeFailures);
			brakeWarningsCheckbox.SetIsOnWithoutNotify(CurrentThing.BrakeWarnings);
			remoteHandbrakeCheckbox.SetIsOnWithoutNotify(CurrentThing.RemoteHandbrake);
			automaticHandbrakeSliderSelector.SetSelectedIndex(CurrentThing.AutomaticHandbrakeMode, fireEvent: false);
			automaticHeadlightSliderSelector.SetSelectedIndex(CurrentThing.AutomaticHeadlightMode, fireEvent: false);
			resourceConsumptionSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.ResourceConsumptionModifier, percentage25Step0To200Without175), fireEvent: false);
			resourceCostSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.ResourceCostModifier, percentage25Step0To200Without175), fireEvent: false);
			damageSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.DamageSensitivityModifier, percentage25Step0To200Without175), fireEvent: false);
			repairCostSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.RepairCostModifier, percentage25Step0To200Without175), fireEvent: false);
			cargoDamageCostSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.CargoDamageCostModifier, percentage25Step0To200Without175), fireEvent: false);
			environmentDamageCostSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.EnvironmentDamageCostModifier, percentage25Step0To200Without175), fireEvent: false);
			multiServicingCheckbox.SetIsOnWithoutNotify(CurrentThing.MultiServicing);
			remoteSwitchingSliderSelector.SetSelectedIndex(CurrentThing.RemoteSwitchingMode, fireEvent: false);
			remoteCouplingSliderSelector.SetSelectedIndex(CurrentThing.RemoteCouplingMode, fireEvent: false);
			vrRemoteDrivingCheckbox.SetIsOnWithoutNotify(CurrentThing.VRRemoteDriving);
			remoteSignReadCheckbox.SetIsOnWithoutNotify(CurrentThing.RemoteSignReading);
			derailCheckbox.SetIsOnWithoutNotify(CurrentThing.Derailing);
			steamStartupSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.SteamStartupMultiplier, steamStartupPercentageValues), fireEvent: false);
			mainResFillTimeSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.MainResFillTime, mainResFillTimePercentageValues), fireEvent: false);
			rerailMaxCostSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.RerailMaxCost, rerailMaxCostValueLabelPairs.Select(((int value, string label) rmc) => rmc.value).ToArray()), fireEvent: false);
			clearDerailedCheckbox.SetIsOnWithoutNotify(CurrentThing.ClearDerailed);
			clearMaxCostSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.ClearMaxCost, clearMaxCostValueLabelPairs.Select(((int value, string label) cmc) => cmc.value).ToArray()), fireEvent: false);
			summonWorkTrainMaxCostSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.SummonWorkTrainMaxCost, summonWorkTrainMaxCostValueLabelPairs.Select(((int value, string label) swmc) => swmc.value).ToArray()), fireEvent: false);
			commsRadioCheatModeSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.CommsRadioCheatMode ? 1 : 0, commsRadioCheatModeValueLabelPairs.Select(((float value, string label) crcm) => crcm.value).ToArray()), fireEvent: false);
			startingItemsSliderSelector.SetSelectedIndex(CurrentThing.StartingItems, fireEvent: false);
			inventoryItemRespawnCheckbox.SetIsOnWithoutNotify(CurrentThing.InventoryItemRespawn);
			mapBlipsCheckbox.SetIsOnWithoutNotify(CurrentThing.MapBlips);
			fastTravelSliderSelector.SetSelectedIndex(CurrentThing.FastTravelMode, fireEvent: false);
			dashSelector.SetSelectedIndex(CurrentThing.Dash, fireEvent: false);
			cameraDashCheckbox.SetIsOnWithoutNotify(CurrentThing.CameraDash);
			dayDurationSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.DayDurationInMinutes, ((IEnumerable<(int, string)>)dayDurationValueLocLabelPairs).Select((Func<(int, string), float>)(((int value, string label) dd) => dd.value)).ToArray()), fireEvent: false);
			weatherChangeSpeedSliderSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.WeatherChangeSpeedModifier, weatherChangeSpeedPercentageValues), fireEvent: false);
			rainCheckbox.SetIsOnWithoutNotify(CurrentThing.Rain);
			lightningsCheckbox.SetIsOnWithoutNotify(CurrentThing.Lightnings);
			weatherEditorSliderSelector.SetSelectedIndex(CurrentThing.WeatherEditorMode, fireEvent: false);
			timeOfDayEditingCheckbox.SetIsOnWithoutNotify(CurrentThing.TimeOfDayEditing);
			singleSaveModeCheckbox.SetIsOnWithoutNotify(CurrentThing.SingleSaveMode);
			sleepCooldownSelector.SetSelectedIndex(GetIndexForSelector(CurrentThing.SleepCooldownInHours, sleepCooldownInHoursPairs.Select(((int value, string label) sch) => sch.value).ToArray()), fireEvent: false);
		}

		private void OnSliderChanged(float arg0)
		{
			OnUserInteracted();
		}

		private void OnSelectorChanged(IClickable clickable, int selectedIndex)
		{
			OnUserInteracted();
		}

		private void OnCheckboxChanged(bool arg0)
		{
			OnUserInteracted();
		}

		private void OnUserInteracted()
		{
			CurrentThing.KeyboardDriving = keyboardDrivingSliderSelector.SelectedIndex;
			CurrentThing.FreeCamera = freeCamCheckbox.isOn;
			CurrentThing.HUD = hudCheckbox.isOn;
			CurrentThing.PaymentModifier = paymentPercentageValues[paymentSliderSelector.SelectedIndex];
			CurrentThing.BonusTimeModifier = bonusTimePercentageValues[bonusTimeSliderSelector.SelectedIndex];
			CurrentThing.MaxCopay = maxCopayValueLabelPairs[maxCopaySliderSelector.SelectedIndex].value;
			CurrentThing.DrivetrainFailures = drivetrainFailuresCheckbox.isOn;
			CurrentThing.TractionFailures = tractionFailuresCheckbox.isOn;
			CurrentThing.BrakeFailures = brakeFailuresCheckbox.isOn;
			CurrentThing.BrakeWarnings = brakeWarningsCheckbox.isOn;
			CurrentThing.RemoteHandbrake = remoteHandbrakeCheckbox.isOn;
			CurrentThing.AutomaticHandbrakeMode = automaticHandbrakeSliderSelector.SelectedIndex;
			CurrentThing.AutomaticHeadlightMode = automaticHeadlightSliderSelector.SelectedIndex;
			CurrentThing.ResourceConsumptionModifier = percentage25Step0To200Without175[resourceConsumptionSliderSelector.SelectedIndex];
			CurrentThing.ResourceCostModifier = percentage25Step0To200Without175[resourceCostSliderSelector.SelectedIndex];
			CurrentThing.DamageSensitivityModifier = percentage25Step0To200Without175[damageSliderSelector.SelectedIndex];
			CurrentThing.RepairCostModifier = percentage25Step0To200Without175[repairCostSliderSelector.SelectedIndex];
			CurrentThing.CargoDamageCostModifier = percentage25Step0To200Without175[cargoDamageCostSliderSelector.SelectedIndex];
			CurrentThing.EnvironmentDamageCostModifier = percentage25Step0To200Without175[environmentDamageCostSliderSelector.SelectedIndex];
			CurrentThing.MultiServicing = multiServicingCheckbox.isOn;
			CurrentThing.RemoteSwitchingMode = remoteSwitchingSliderSelector.SelectedIndex;
			CurrentThing.RemoteCouplingMode = remoteCouplingSliderSelector.SelectedIndex;
			CurrentThing.VRRemoteDriving = vrRemoteDrivingCheckbox.isOn;
			CurrentThing.RemoteSignReading = remoteSignReadCheckbox.isOn;
			CurrentThing.Derailing = derailCheckbox.isOn;
			CurrentThing.SteamStartupMultiplier = steamStartupPercentageValues[steamStartupSliderSelector.SelectedIndex];
			CurrentThing.MainResFillTime = mainResFillTimePercentageValues[mainResFillTimeSliderSelector.SelectedIndex];
			CurrentThing.RerailMaxCost = rerailMaxCostValueLabelPairs[rerailMaxCostSliderSelector.SelectedIndex].value;
			CurrentThing.ClearDerailed = clearDerailedCheckbox.isOn;
			CurrentThing.ClearMaxCost = clearMaxCostValueLabelPairs[clearMaxCostSliderSelector.SelectedIndex].value;
			CurrentThing.SummonWorkTrainMaxCost = summonWorkTrainMaxCostValueLabelPairs[summonWorkTrainMaxCostSliderSelector.SelectedIndex].value;
			CurrentThing.CommsRadioCheatMode = commsRadioCheatModeValueLabelPairs[commsRadioCheatModeSliderSelector.SelectedIndex].value > 0.5f;
			CurrentThing.StartingItems = startingItemsSliderSelector.SelectedIndex;
			CurrentThing.InventoryItemRespawn = inventoryItemRespawnCheckbox.isOn;
			CurrentThing.MapBlips = mapBlipsCheckbox.isOn;
			CurrentThing.FastTravelMode = fastTravelSliderSelector.SelectedIndex;
			CurrentThing.Dash = dashSelector.SelectedIndex;
			CurrentThing.CameraDash = cameraDashCheckbox.isOn;
			CurrentThing.DayDurationInMinutes = dayDurationValueLocLabelPairs[dayDurationSliderSelector.SelectedIndex].value;
			CurrentThing.WeatherChangeSpeedModifier = weatherChangeSpeedPercentageValues[weatherChangeSpeedSliderSelector.SelectedIndex];
			CurrentThing.Rain = rainCheckbox.isOn;
			CurrentThing.Lightnings = lightningsCheckbox.isOn;
			CurrentThing.WeatherEditorMode = weatherEditorSliderSelector.SelectedIndex;
			CurrentThing.TimeOfDayEditing = timeOfDayEditingCheckbox.isOn;
			CurrentThing.SingleSaveMode = singleSaveModeCheckbox.isOn;
			CurrentThing.SleepCooldownInHours = sleepCooldownInHoursPairs[sleepCooldownSelector.SelectedIndex].value;
			needsRefreshInterface = true;
		}

		private void Update()
		{
			if (needsRefreshInterface)
			{
				needsRefreshInterface = false;
				RefreshInterface();
			}
		}

		protected override string GetTargetFilePath()
		{
			if (CurrentThing == null || string.IsNullOrEmpty(CurrentThing.FileName))
			{
				return crud.BaseStoragePath;
			}
			return crud.BaseStoragePath + Path.DirectorySeparatorChar + CurrentThing.FileName;
		}
	}
}
