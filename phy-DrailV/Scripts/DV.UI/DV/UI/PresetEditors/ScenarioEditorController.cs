using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DV.Common;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.UIFramework;
using DV.Util;
using TMPro;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	public class ScenarioEditorController : APresetEditorController<IScenario>
	{
		public const int WEATHER_PERCENTAGE_STEP = 5;

		private IScenarioCRUD crud;

		private HashSet<GeneralLicenseType_v2> unlockedLicenses = new HashSet<GeneralLicenseType_v2>();

		private HashSet<GarageType_v2> unlockedGarages = new HashSet<GarageType_v2>();

		private readonly List<ScenarioEditorStationMapping> stationMappings = new List<ScenarioEditorStationMapping>();

		private readonly List<(int value, string label)> startingWeatherDurationValueLabelPairs = new List<(int, string)>
		{
			(-1, "scenario/start_weather_off"),
			(0, "scenario/start_weather_momentary"),
			(10, "10%"),
			(25, "25%"),
			(50, "50%"),
			(75, "75%"),
			(100, "100%"),
			(int.MaxValue, "scenario/start_weather_infinite")
		};

		[Header("GUI Element References")]
		[NullCheck]
		public Selector startingTrackSelector;

		[NullCheck]
		public ToggleDV randomStartingTrackCheckbox;

		[NullCheck]
		public Selector destinationTrackSelector;

		[NullCheck]
		public ToggleDV randomDestinationTrackCheckbox;

		[NullCheck]
		public PresetSelectorLogicTrain trainSelectorLogic;

		[NullCheck]
		public ToggleDV randomTrainCheckbox;

		[NullCheck]
		public SliderSelector timeOfDaySlider;

		[NullCheck]
		public ToggleDV randomTimeOfDayCheckbox;

		[NullCheck]
		public SliderDV cloudsSlider;

		[NullCheck]
		public ToggleDV randomCloudsCheckbox;

		[NullCheck]
		public SliderDV fogSlider;

		[NullCheck]
		public ToggleDV randomFogCheckbox;

		[NullCheck]
		public SliderDV wetnessSlider;

		[NullCheck]
		public ToggleDV randomWetnessCheckbox;

		[NullCheck]
		public SliderDV rainSlider;

		[NullCheck]
		public ToggleDV randomRainCheckbox;

		[NullCheck]
		public SliderDV lightningsSlider;

		[NullCheck]
		public ToggleDV randomLightningsCheckbox;

		[NullCheck]
		public SliderSelector startingWeatherDurationSlider;

		[NullCheck]
		public TrainEditorGridView trainPreviewGrid;

		[NullCheck]
		public ButtonDV trainEditorButton;

		private ScenarioEditorStationMapping currentWorldMappings;

		private int startingTrackMappingIndex = -1;

		private int destinationTrackMappingIndex = -1;

		private bool needsRefreshInterface;

		private List<(int minute, string timestamp)> minuteToTimestamp = GetTimesOfDay();

		private bool reentrancyCheck_RefreshData;

		private bool reentrancyCheck_RefreshInterface;

		public TextMeshProUGUI debugTMPro;

		protected override string LOC_RENAME_PROMPT => "scenario/rename_scenario_prompt";

		protected override string LOC_DELETE_PROMPT => "scenario/delete_scenario_prompt";

		protected override string LOC_SAVE_OR_REVERT_PROMPT => "scenario/save_or_revert_scenario";

		private bool IsStartingWeatherOff => startingWeatherDurationSlider.SelectedIndex == 0;

		private bool IsStartingWeatherDurationLabelLocalized
		{
			get
			{
				if (!IsStartingWeatherOff && startingWeatherDurationSlider.SelectedIndex != 1)
				{
					return startingWeatherDurationSlider.SelectedIndex == 7;
				}
				return true;
			}
		}

		protected override bool HasSaveButton => true;

		protected override bool HasOpenFolderButton => true;

		protected override bool HasDoneButton => true;

		public override IScenarioCRUD CRUD => crud;

		public override ObservableCollectionExt<IScenario> Things => crud?.Scenarios;

		public override IScenario CurrentThing { get; protected set; }

		public event Action<IScenario> TrainEditorRequested;

		public void SetData(AScenarioProvider provider, IScenario currentScenario)
		{
			crud = provider.CRUD;
			isVR = provider.IsVR;
			unlockedLicenses = provider.GetUnlockedLicenses();
			unlockedGarages = provider.GetUnlockedGarages();
			CurrentThing = currentScenario;
			List<ScenarioEditorStationMapping> list = provider.GetStationMappings();
			stationMappings.Clear();
			if (list == null)
			{
				Debug.LogError("ScenarioEditorController got assigned null worlds list", this);
			}
			else if (list.Count == 0)
			{
				Debug.LogError("ScenarioEditorController got assigned an empty worlds list", this);
			}
			else
			{
				stationMappings.AddRange(list);
			}
			base.IsInitialized = true;
			RefreshData();
		}

		protected override bool IsDefaultPresetName(string name)
		{
			return false;
		}

		protected override void Awake()
		{
			base.Awake();
			timeOfDaySlider.SetValues(minuteToTimestamp.Select(((int minute, string timestamp) tup) => tup.timestamp).ToList());
			startingWeatherDurationSlider.SetValues(startingWeatherDurationValueLabelPairs.Select(((int value, string label) swd) => swd.label).ToList());
			startingWeatherDurationSlider.LocalizedValues = IsStartingWeatherDurationLabelLocalized;
			trainSelectorLogic.SetCallbacks(() => CurrentThing?.Train, () => CRUD?.Trains, () => CRUD);
		}

		protected override void SetupListeners(bool on)
		{
			base.SetupListeners(on);
			if (on)
			{
				startingTrackSelector.SelectionChanged += OnStartingTrackChanged;
				randomStartingTrackCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				destinationTrackSelector.SelectionChanged += OnDestinationTrackChanged;
				randomDestinationTrackCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				trainSelectorLogic.selector.SelectionChanged += OnTrainChanged;
				randomTrainCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				trainEditorButton.Clicked += OnTrainEditorButtonClicked;
				timeOfDaySlider.SelectionChanged += OnSelectorSlidersChanged;
				randomTimeOfDayCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				cloudsSlider.onValueChanged.AddListener(OnSelectorSlidersChanged);
				randomCloudsCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				fogSlider.onValueChanged.AddListener(OnSelectorSlidersChanged);
				randomFogCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				wetnessSlider.onValueChanged.AddListener(OnSelectorSlidersChanged);
				randomWetnessCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				rainSlider.onValueChanged.AddListener(OnSelectorSlidersChanged);
				randomRainCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				lightningsSlider.onValueChanged.AddListener(OnSelectorSlidersChanged);
				randomLightningsCheckbox.onValueChanged.AddListener(OnCheckboxChanged);
				startingWeatherDurationSlider.SelectionChanged += OnSelectorSlidersChanged;
			}
			else
			{
				startingTrackSelector.SelectionChanged -= OnStartingTrackChanged;
				randomStartingTrackCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				destinationTrackSelector.SelectionChanged -= OnDestinationTrackChanged;
				randomDestinationTrackCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				trainSelectorLogic.selector.SelectionChanged -= OnTrainChanged;
				randomTrainCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				trainEditorButton.Clicked -= OnTrainEditorButtonClicked;
				timeOfDaySlider.SelectionChanged -= OnSelectorSlidersChanged;
				randomTimeOfDayCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				cloudsSlider.onValueChanged.RemoveListener(OnSelectorSlidersChanged);
				randomCloudsCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				fogSlider.onValueChanged.RemoveListener(OnSelectorSlidersChanged);
				randomFogCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				wetnessSlider.onValueChanged.RemoveListener(OnSelectorSlidersChanged);
				randomWetnessCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				rainSlider.onValueChanged.RemoveListener(OnSelectorSlidersChanged);
				randomRainCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				lightningsSlider.onValueChanged.RemoveListener(OnSelectorSlidersChanged);
				randomLightningsCheckbox.onValueChanged.RemoveListener(OnCheckboxChanged);
				startingWeatherDurationSlider.SelectionChanged -= OnSelectorSlidersChanged;
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
			if (!base.IsInitialized)
			{
				reentrancyCheck_RefreshData = false;
				return;
			}
			currentWorldMappings = stationMappings[0];
			foreach (string item in currentWorldMappings.Validate())
			{
				Debug.LogError(item);
			}
			if (CurrentThing != null)
			{
				startingTrackMappingIndex = currentWorldMappings.Unmap(CurrentThing.StartingTrackID, CurrentThing.ReverseTrain).index;
				destinationTrackMappingIndex = currentWorldMappings.Unmap(CurrentThing.DestinationTrackID, CurrentThing.ReverseTrain).index;
			}
			else
			{
				startingTrackMappingIndex = 0;
				destinationTrackMappingIndex = 0;
			}
			startingTrackMappingIndex = Mathf.Clamp(startingTrackMappingIndex, 0, currentWorldMappings.mappings.Count - 1);
			destinationTrackMappingIndex = Mathf.Clamp(destinationTrackMappingIndex, 0, currentWorldMappings.mappings.Count - 1);
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
				trainPreviewGrid.IsLiveryUnlocked = IsLiveryUnlocked;
				trainPreviewGrid.SetModel(CurrentThing.Train?.Cars ?? new ObservableCollectionExt<ICar>());
				trainSelectorLogic.RefreshInterface();
				randomTrainCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomTrain);
				List<string> values = currentWorldMappings.mappings.Select((ScenarioEditorStationMapping.Mapping m) => m.id).ToList();
				startingTrackSelector.SetValues(values);
				destinationTrackSelector.SetValues(new List<string> { "(TODO)" });
				startingTrackSelector.SetSelectedIndex(startingTrackMappingIndex, fireEvent: false);
				randomStartingTrackCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomStartingTrackID);
				randomDestinationTrackCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomDestinationTrackID);
				timeOfDaySlider.SetSelectedIndex(GetIndex(CurrentThing.TimeOfDay, minuteToTimestamp), fireEvent: false);
				randomTimeOfDayCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomTimeOfDay);
				cloudsSlider.SetValueWithoutNotify(CurrentThing.CloudsPercentage);
				randomCloudsCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomCloudsPercentage);
				fogSlider.SetValueWithoutNotify(CurrentThing.FogPercentage);
				randomFogCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomFogPercentage);
				wetnessSlider.SetValueWithoutNotify(CurrentThing.WetnessPercentage);
				randomWetnessCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomWetnessPercentage);
				rainSlider.SetValueWithoutNotify(CurrentThing.RainPercentage);
				randomRainCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomRainPercentage);
				lightningsSlider.SetValueWithoutNotify(CurrentThing.LightningPercentage);
				randomLightningsCheckbox.SetIsOnWithoutNotify(CurrentThing.RandomLightningPercentage);
				startingWeatherDurationSlider.SetSelectedIndex(GetIndex(CurrentThing.StartingWeatherDuration, startingWeatherDurationValueLabelPairs), fireEvent: false);
				startingWeatherDurationSlider.LocalizedValues = IsStartingWeatherDurationLabelLocalized;
				ToggleBunchOfElements(!CurrentThing.IsReadOnly);
			}
			else
			{
				trainPreviewGrid.IsLiveryUnlocked = (TrainCarLivery _) => true;
				trainPreviewGrid.SetModel(new ObservableCollectionExt<ICar>());
				ToggleBunchOfElements(enabled: false);
			}
			reentrancyCheck_RefreshInterface = false;
		}

		private void ToggleBunchOfElements(bool enabled)
		{
			startingTrackSelector.ToggleInteractable(enabled && !randomStartingTrackCheckbox.isOn);
			randomStartingTrackCheckbox.ToggleInteractable(enabled);
			destinationTrackSelector.ToggleInteractable(newInteractable: false);
			randomDestinationTrackCheckbox.ToggleInteractable(newInteractable: false);
			trainSelectorLogic.selector.ToggleInteractable(enabled && !randomTrainCheckbox.isOn);
			randomTrainCheckbox.ToggleInteractable(enabled);
			timeOfDaySlider.ToggleInteractable(enabled && !randomTimeOfDayCheckbox.isOn);
			randomTimeOfDayCheckbox.ToggleInteractable(enabled);
			bool flag = !IsStartingWeatherOff;
			cloudsSlider.ToggleInteractable(enabled && !randomCloudsCheckbox.isOn && flag);
			randomCloudsCheckbox.ToggleInteractable(enabled);
			fogSlider.ToggleInteractable(enabled && !randomFogCheckbox.isOn && flag);
			randomFogCheckbox.ToggleInteractable(enabled);
			wetnessSlider.ToggleInteractable(enabled && !randomWetnessCheckbox.isOn && flag);
			randomWetnessCheckbox.ToggleInteractable(enabled);
			rainSlider.ToggleInteractable(enabled && !randomRainCheckbox.isOn && flag);
			randomRainCheckbox.ToggleInteractable(enabled);
			lightningsSlider.ToggleInteractable(enabled && !randomLightningsCheckbox.isOn && flag);
			randomLightningsCheckbox.ToggleInteractable(enabled);
			startingWeatherDurationSlider.ToggleInteractable(enabled);
			trainEditorButton.ToggleInteractable(enabled);
		}

		protected override void OnPresetSelected(IClickable _, int selectedIndex)
		{
			CurrentThing = crud.Scenarios[selectedIndex];
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
			CurrentThing = ((CurrentThing == null) ? crud.CreateScenario() : crud.CreateCopyOf(CurrentThing));
			CurrentThing.Name = nameToUse;
			CRUD.Flush();
		}

		protected override void DeleteImpl()
		{
			crud.DeleteScenario(CurrentThing);
			CurrentThing = null;
		}

		protected override void FlushChanges()
		{
			CRUD.Flush();
		}

		private void OnStartingTrackChanged(IClickable target, int selectedStationIndex)
		{
			startingTrackMappingIndex = selectedStationIndex;
			OnLocationChanged(isStartingLocation: true, selectedStationIndex);
		}

		private void OnDestinationTrackChanged(IClickable target, int selectedMappingIndex)
		{
			destinationTrackMappingIndex = selectedMappingIndex;
			OnLocationChanged(isStartingLocation: false, selectedMappingIndex);
		}

		private void OnLocationChanged(bool isStartingLocation, int mappingIndex)
		{
			ScenarioEditorStationMapping.Mapping mapping = currentWorldMappings.mappings[mappingIndex];
			(WorldStationsExtractedData.StationData station, int trackIndex) tuple = currentWorldMappings.Map(mapping);
			WorldStationsExtractedData.StationData item = tuple.station;
			int item2 = tuple.trackIndex;
			string text = item.trackIds[item2];
			if (isStartingLocation)
			{
				CurrentThing.StartingTrackID = text;
				CurrentThing.ReverseTrain = mapping.reverseTrain;
			}
			else
			{
				CurrentThing.DestinationTrackID = text;
			}
			CurrentThing.PlayerPosition = item.playerAnchorWorldPosition;
			CurrentThing.PlayerRotationY = item.playerAnchorRotation.y;
			needsRefreshInterface = true;
		}

		private void OnTrainChanged(IClickable _, int selectedIndex)
		{
			ITrain train = crud.Trains[selectedIndex];
			CurrentThing.Train = train;
			RefreshInterface();
		}

		private void OnTrainEditorButtonClicked(IClickable _)
		{
			this.TrainEditorRequested?.Invoke(CurrentThing);
		}

		private void OnCheckboxChanged(bool _)
		{
			OnUserInteracted();
		}

		private void OnSelectorSlidersChanged(float _)
		{
			OnUserInteracted();
		}

		private void OnSelectorSlidersChanged(IClickable _, int __)
		{
			OnUserInteracted();
		}

		private void OnUserInteracted()
		{
			CurrentThing.RandomStartingTrackID = randomStartingTrackCheckbox.isOn;
			CurrentThing.RandomDestinationTrackID = randomDestinationTrackCheckbox.isOn;
			CurrentThing.RandomTrain = randomTrainCheckbox.isOn;
			CurrentThing.TimeOfDay = minuteToTimestamp[timeOfDaySlider.SelectedIndex].minute;
			CurrentThing.RandomTimeOfDay = randomTimeOfDayCheckbox.isOn;
			CurrentThing.CloudsPercentage = Mathf.RoundToInt(cloudsSlider.value);
			CurrentThing.RandomCloudsPercentage = randomCloudsCheckbox.isOn;
			CurrentThing.FogPercentage = Mathf.RoundToInt(fogSlider.value);
			CurrentThing.RandomFogPercentage = randomFogCheckbox.isOn;
			CurrentThing.WetnessPercentage = Mathf.RoundToInt(wetnessSlider.value);
			CurrentThing.RandomWetnessPercentage = randomWetnessCheckbox.isOn;
			CurrentThing.RainPercentage = Mathf.RoundToInt(rainSlider.value);
			CurrentThing.RandomRainPercentage = randomRainCheckbox.isOn;
			CurrentThing.LightningPercentage = Mathf.RoundToInt(lightningsSlider.value);
			CurrentThing.RandomLightningPercentage = randomLightningsCheckbox.isOn;
			CurrentThing.StartingWeatherDuration = startingWeatherDurationValueLabelPairs[startingWeatherDurationSlider.SelectedIndex].value;
			needsRefreshInterface = true;
		}

		public static List<(int minute, string timestamp)> GetTimesOfDay()
		{
			return (from m in Enumerable.Range(0, 1439)
				where m % 30 == 0
				select (minute: m, time: $"{TimeSpan.FromMinutes(m):hh\\:mm}")).ToList();
		}

		private static int GetIndex<T>(int value, List<(int originalValue, T mappedValue)> availableValues)
		{
			int num = availableValues.FindIndex(((int originalValue, T mappedValue) tup) => tup.originalValue == value);
			if (num == -1)
			{
				var (num2, _, num3) = (from tup in availableValues.Select(((int originalValue, T mappedValue) tup, int i) => (originalValue: tup.originalValue, diff: Mathf.Abs(tup.originalValue - value), index: i))
					orderby tup.diff
					select tup).FirstOrDefault();
				Debug.LogWarning($"Int value {value} not available values, will use closest value {num2}");
				num = num3;
			}
			return num;
		}

		private void Update()
		{
			if (needsRefreshInterface)
			{
				needsRefreshInterface = false;
				RefreshInterface();
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (CurrentThing == null)
			{
				stringBuilder.AppendLine("SCENARIO IS NULL!");
			}
			else if (CurrentThing.Train == null)
			{
				stringBuilder.AppendLine("Scenario: " + CurrentThing.Name);
				stringBuilder.AppendLine("SCENARIO'S TRAIN IS NULL!");
			}
			else
			{
				stringBuilder.AppendLine("Scenario: " + CurrentThing.Name);
				stringBuilder.AppendLine($"Scenario SyncState: {CurrentThing.SyncState}");
				stringBuilder.AppendLine("Train: " + CurrentThing.Train.Name);
				stringBuilder.AppendLine($"Train SyncState: {CurrentThing.Train.SyncState}");
			}
			debugTMPro.text = stringBuilder.ToString();
		}

		protected override string GetTargetFilePath()
		{
			if (CurrentThing == null || string.IsNullOrEmpty(CurrentThing.FileName))
			{
				return crud.BaseStoragePath;
			}
			return crud.BaseStoragePath + Path.DirectorySeparatorChar + CurrentThing.FileName;
		}

		private bool IsLiveryUnlocked(TrainCarLivery livery)
		{
			return TrainEditor_Helpers.IsLiveryUnlocked(livery, unlockedLicenses, unlockedGarages);
		}
	}
}
