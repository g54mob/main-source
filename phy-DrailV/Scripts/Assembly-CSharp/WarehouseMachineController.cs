using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DV;
using DV.Highlighting;
using DV.Localization;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using TMPro;
using UnityEngine;

public class WarehouseMachineController : MonoBehaviour
{
	[Flags]
	public enum TextPreset : ushort
	{
		Idle = 1,
		NoTrains = 2,
		Busy = 4,
		Completed = 8,
		Failed = 0x10,
		ClearDesc = 0x20,
		Error = 0x40,
		Moving = 0x80,
		CarUpdated = 0x100,
		Partial = 0x200,
		Full = 0x400,
		TrainInRange = 0x800,
		ClearTrainInRange = 0x1000,
		InstantLoad = 0x2000,
		InstantUnload = 0x4000,
		WithoutLoading = 0x1821,
		WithJobId = 0x6C0,
		WithCarId = 0x100,
		WithCargoType = 0x100,
		WithExtra = 0x6800,
		AppendDescription = 0x1FD8,
		ClearCars = 0x118
	}

	public readonly struct TextPresetData
	{
		public readonly TextPreset preset;

		public readonly bool isLoading;

		public readonly string jobId;

		public readonly Car car;

		public readonly CargoType_v2 cargoType;

		public readonly string extra;

		public TextPresetData(TextPreset preset, bool isLoading, string jobId, Car car, CargoType_v2 cargoType, string extra)
		{
			this.preset = preset;
			this.isLoading = isLoading;
			this.jobId = jobId;
			this.car = car;
			this.cargoType = cargoType;
			this.extra = extra;
		}

		public bool UpdateStack(List<TextPresetData> stack)
		{
			if (!TextPreset.AppendDescription.HasUShortFlag(preset))
			{
				if (stack.Count == 1 && Equals(stack[0]))
				{
					return false;
				}
				stack.Clear();
				stack.Add(this);
				return true;
			}
			if (TextPreset.ClearCars.HasUShortFlag(preset))
			{
				for (int num = stack.Count - 1; num >= 0; num--)
				{
					if (stack[num].preset == TextPreset.CarUpdated)
					{
						stack.RemoveAt(num);
					}
				}
			}
			if (stack.Count > 0 && Equals(stack[stack.Count - 1]))
			{
				return false;
			}
			stack.Add(this);
			return true;
		}

		public override string ToString()
		{
			return $"{preset} (isLoading: {isLoading}, jobId: {jobId}, carId: {car?.ID}, cargoType: {cargoType?.name}, extra: {extra})";
		}

		private bool Equals(TextPresetData y)
		{
			if (preset == y.preset && isLoading == y.isLoading && jobId == y.jobId && object.Equals(car, y.car) && object.Equals(cargoType, y.cargoType))
			{
				return extra == y.extra;
			}
			return false;
		}
	}

	private const float DELAY_BETWEEN_MACHINE_ACTIONS = 0.5f;

	private const float CLEAR_MACHINE_ACTION_TEXT_AFTER_TIME_LONG = 10f;

	private const float CLEAR_MACHINE_ACTION_TEXT_AFTER_TIME_SHORT = 4f;

	private const float TRAIN_IN_RANGE_CHECK_PERIOD = 1f;

	private const string LOAD_BRACKETS = "whm/load_brackets";

	private const string UNLOAD_BRACKETS = "whm/unload_brackets";

	private const string LOAD_UNLOAD_BRACKETS = "whm/load_unload_brackets";

	private const string TRAIN_IN_RANGE_FORMAT = "whm/train_in_range";

	private const string LOAD_ERROR_CARS_ON_TRACK_FORMAT = "whm/load_error_cars_on_track";

	private const string UNLOAD_ERROR_CARS_ON_TRACK_FORMAT = "whm/unload_error_cars_on_track";

	private const string LOAD_ERROR_CARS_MOVING_FORMAT = "whm/load_error_cars_moving";

	private const string UNLOAD_ERROR_CARS_MOVING_FORMAT = "whm/unload_error_cars_moving";

	private const string ITEM_LOADED_FORMAT = "whm/item_loaded";

	private const string ITEM_UNLOADED_FORMAT = "whm/item_unloaded";

	private const string TRAIN_PARTIALLY_LOADED = "whm/train_partially_loaded";

	private const string TRAIN_PARTIALLY_UNLOADED = "whm/train_partially_unloaded";

	private const string TRAIN_FULLY_LOADED = "whm/train_fully_loaded";

	private const string TRAIN_FULLY_UNLOADED = "whm/train_fully_unloaded";

	public static List<WarehouseMachineController> allControllers = new List<WarehouseMachineController>();

	[Header("Track")]
	public string warehouseTrackName = "";

	[NonSerialized]
	public RailTrack warehouseTrack;

	[Header("Cargo")]
	public List<CargoType> supportedCargoTypes;

	[Header("Text")]
	public TextMeshPro trackIdText;

	public TextMeshPro displayTitleText;

	public TextMeshPro displayText;

	public TextMeshPro displayTrainInRangeText;

	[Header("Audio")]
	public AudioClip errorSound;

	public AudioClip machineSound;

	[Header("Highlight")]
	public HighlightTag highlightTag;

	public readonly List<TextPresetData> CurrentTextPresets = new List<TextPresetData>();

	private Coroutine loadUnloadCoro;

	private Coroutine activateExternallyCoro;

	private string supportedCargoTypesText = "";

	private bool initialized;

	private string SUPPORTED_CARGO_TITLE => LocalizationAPI.L("whm/supported_cargo");

	private string LOADING_IN_PROGRESS => LocalizationAPI.L("whm/loading_in_progress");

	private string UNLOADING_IN_PROGRESS => LocalizationAPI.L("whm/unloading_in_progress");

	private string LOADING_UNAVAILABLE_TITLE => LocalizationAPI.L("whm/loading_unavailable");

	private string LOADING_COMPLETED_TITLE => LocalizationAPI.L("whm/loading_completed");

	private string UNLOADING_UNAVAILABLE_TITLE => LocalizationAPI.L("whm/unloading_unavailable");

	private string UNLOADING_COMPLETED_TITLE => LocalizationAPI.L("whm/unloading_completed");

	private string NO_LOADABLE_TRAINS => LocalizationAPI.L("whm/no_loadable_trains");

	private string NO_UNLOADABLE_TRAINS => LocalizationAPI.L("whm/no_unloadable_trains");

	public WarehouseMachine warehouseMachine { get; private set; }

	public bool LoadOrUnloadOngoing { get; private set; }

	private void Awake()
	{
		allControllers.Add(this);
	}

	private void Start()
	{
		if (errorSound == null || machineSound == null)
		{
			Debug.LogError("Not all sounds are set for WarehouseMachineController. Sound will not be played", this);
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < supportedCargoTypes.Count; i++)
		{
			string value = LocalizationAPI.L(supportedCargoTypes[i].ToV2().localizationKeyFull);
			stringBuilder.AppendLine(value);
		}
		supportedCargoTypesText = stringBuilder.ToString();
		ClearTrainInRangeText();
		DisplayIdleText();
		warehouseTrack = SingletonBehaviour<RailTrackRegistryBase>.Instance.GetTrackWithName(warehouseTrackName);
		if (warehouseTrack == null)
		{
			Debug.LogError("warehouseTrack was not correctly initialized with warehouseTrackName!", this);
		}
		warehouseMachine = new WarehouseMachine(warehouseTrack.LogicTrack(), supportedCargoTypes);
		trackIdText.text = warehouseMachine.WarehouseTrack.ID.TrackPartOnly;
	}

	private void OnEnable()
	{
		if (!initialized)
		{
			StartCoroutine(InitLeverHJAF());
		}
		StartCoroutine(TrainInRangeCheck(1f));
		DisplayIdleText();
	}

	private void OnDisable()
	{
		StopAllCoroutines();
		loadUnloadCoro = null;
		activateExternallyCoro = null;
	}

	private void OnDestroy()
	{
		allControllers.Remove(this);
	}

	private IEnumerator InitLeverHJAF()
	{
		HingeJointAngleFix componentInChildren;
		while ((componentInChildren = GetComponentInChildren<HingeJointAngleFix>()) == null)
		{
			yield return WaitFor.Seconds(0.2f);
		}
		RotaryAmplitudeChecker rotaryAmplitudeChecker = componentInChildren.gameObject.AddComponent<RotaryAmplitudeChecker>();
		HingeJoint component = componentInChildren.gameObject.GetComponent<HingeJoint>();
		float num = component.limits.max - component.limits.min;
		rotaryAmplitudeChecker.checkThreshold = num * 0.2f;
		rotaryAmplitudeChecker.checkPeriod = 0.1f;
		rotaryAmplitudeChecker.RotaryStateChanged += OnLeverPositionChange;
		initialized = true;
	}

	private void OnLeverPositionChange(int positionState)
	{
		switch (positionState)
		{
		case -1:
			StartLoadSequence();
			break;
		case 1:
			StartUnloadSequence();
			break;
		}
	}

	private void StartLoadSequence()
	{
		if (loadUnloadCoro == null && activateExternallyCoro == null)
		{
			ClearTrainInRangeText();
			loadUnloadCoro = StartCoroutine(DelayedLoadUnload(isLoading: true, 0.5f));
		}
	}

	private void StartUnloadSequence()
	{
		if (loadUnloadCoro == null && activateExternallyCoro == null)
		{
			ClearTrainInRangeText();
			loadUnloadCoro = StartCoroutine(DelayedLoadUnload(isLoading: false, 0.5f));
		}
	}

	public void SetHighlight(bool on)
	{
		SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on, highlightTag, AGeneralHighlighter.HighlightType.Generic, useObstructedMaterial: true);
	}

	public void ActivateExternally()
	{
		if (activateExternallyCoro == null)
		{
			activateExternallyCoro = StartCoroutine(ActivateExternallyCoro());
		}
	}

	private IEnumerator ActivateExternallyCoro()
	{
		if (warehouseMachine.AnyTrainToUnloadPresentOnTrack())
		{
			yield return DelayedLoadUnload(isLoading: false, 0.5f, play2D: true);
		}
		if (warehouseMachine.AnyTrainToLoadPresentOnTrack())
		{
			yield return DelayedLoadUnload(isLoading: true, 0.5f, play2D: true);
		}
		activateExternallyCoro = null;
	}

	private IEnumerator DelayedLoadUnload(bool isLoading, float delayBetweenActions, bool play2D = false)
	{
		WaitForSeconds waitDelayBetweenActions = WaitFor.Seconds(delayBetweenActions);
		SetScreen(TextPreset.ClearDesc);
		if (machineSound != null)
		{
			if (play2D)
			{
				machineSound.Play2D();
			}
			else
			{
				machineSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}
		List<WarehouseMachine.WarehouseLoadUnloadDataPerJob> currentLoadUnloadData = warehouseMachine.GetCurrentLoadUnloadData(isLoading ? WarehouseTaskType.Loading : WarehouseTaskType.Unloading);
		if (currentLoadUnloadData.Count == 0)
		{
			SetScreen(TextPreset.NoTrains, isLoading);
			yield return StartCoroutine(ResetTextToIdleDisplay(4f));
			loadUnloadCoro = null;
			yield break;
		}
		LoadOrUnloadOngoing = true;
		SetScreen(TextPreset.Busy, isLoading);
		bool anythingProcessed = false;
		foreach (WarehouseMachine.WarehouseLoadUnloadDataPerJob loadUnloadData in currentLoadUnloadData)
		{
			yield return waitDelayBetweenActions;
			if (loadUnloadData.state == WarehouseMachine.WarehouseLoadUnloadDataPerJob.State.SomeCarsPresentLoadUnloadForbiden)
			{
				SetScreen(TextPreset.Error, isLoading, loadUnloadData.id);
				continue;
			}
			List<WarehouseTask> tasksAvailableToProcess = loadUnloadData.tasksAvailableToProcess;
			if (tasksAvailableToProcess != null)
			{
				bool flag = false;
				foreach (WarehouseTask item in tasksAvailableToProcess)
				{
					if (AnyCarMoving(item.cars))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					SetScreen(TextPreset.Moving, isLoading, loadUnloadData.id);
					continue;
				}
				foreach (WarehouseTask task in tasksAvailableToProcess)
				{
					foreach (Car car2 in task.cars)
					{
						_ = car2;
						Car car = (isLoading ? warehouseMachine.LoadOneCarOfTask(task) : warehouseMachine.UnloadOneCarOfTask(task));
						if (car == null)
						{
							Debug.LogError("Shouldn't happen!");
							break;
						}
						CargoType enumVal = (isLoading ? car.CurrentCargoTypeInCar : car.LastUnloadedCargoType);
						SetScreen(TextPreset.CarUpdated, isLoading, loadUnloadData.id, car, enumVal.ToV2());
						yield return waitDelayBetweenActions;
					}
				}
			}
			else if (loadUnloadData.specialDeliveryToProcess != null)
			{
				if (AnyCarMoving(loadUnloadData.specialDeliveryToProcess.reservedCarsOnTrack))
				{
					SetScreen(TextPreset.Moving, isLoading, loadUnloadData.id);
					continue;
				}
				List<Car> list = (isLoading ? warehouseMachine.LoadSpecialDelivery(loadUnloadData.specialDeliveryToProcess) : warehouseMachine.UnloadSpecialDelivery(loadUnloadData.specialDeliveryToProcess));
				if (list.Any())
				{
					StringBuilder stringBuilder = new StringBuilder(6 + 2 * list.Count - 2);
					foreach (Car item2 in list)
					{
						stringBuilder.Append(item2.ID + ((list.Last() != item2) ? " ," : ""));
					}
					SetScreen(isLoading ? TextPreset.InstantLoad : TextPreset.InstantUnload, isLoading: false, null, null, null, stringBuilder.ToString());
				}
			}
			anythingProcessed = true;
			if (loadUnloadData.state == WarehouseMachine.WarehouseLoadUnloadDataPerJob.State.PartialLoadUnloadPossible)
			{
				SetScreen(TextPreset.Partial, isLoading, loadUnloadData.id);
			}
			else if (loadUnloadData.state == WarehouseMachine.WarehouseLoadUnloadDataPerJob.State.FullLoadUnloadPossible)
			{
				SetScreen(TextPreset.Full, isLoading, loadUnloadData.id);
			}
		}
		if (anythingProcessed)
		{
			SetScreen(TextPreset.Completed, isLoading);
		}
		else
		{
			SetScreen(TextPreset.Failed, isLoading);
		}
		LoadOrUnloadOngoing = false;
		yield return StartCoroutine(ResetTextToIdleDisplay(anythingProcessed ? 10f : 4f));
		loadUnloadCoro = null;
	}

	private bool AnyCarMoving(List<Car> cars)
	{
		foreach (Car car in cars)
		{
			if (SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.TryGetValue(car, out var value))
			{
				if (value.GetAbsSpeed() > 0.3f)
				{
					return true;
				}
			}
			else
			{
				Debug.LogError("Unexpected error: can't pair " + car.ID + " with its TrainCar!");
			}
		}
		return false;
	}

	private IEnumerator ResetTextToIdleDisplay(float resetTextAfter)
	{
		yield return WaitFor.Seconds(resetTextAfter);
		DisplayIdleText();
	}

	private IEnumerator TrainInRangeCheck(float checkPeriod)
	{
		while (true)
		{
			yield return WaitFor.Seconds(checkPeriod);
			bool flag = warehouseMachine.AnyTrainToLoadPresentOnTrack();
			bool flag2 = warehouseMachine.AnyTrainToUnloadPresentOnTrack();
			if (!(flag || flag2) || loadUnloadCoro != null)
			{
				if (displayTrainInRangeText.text.Length != 0)
				{
					ClearTrainInRangeText();
				}
			}
			else
			{
				string extra = ((!flag) ? "whm/unload_brackets" : ((!flag2) ? "whm/load_brackets" : "whm/load_unload_brackets"));
				SetScreen(TextPreset.TrainInRange, isLoading: false, null, null, null, extra);
			}
		}
	}

	private void DisplayIdleText()
	{
		SetScreen(TextPreset.Idle);
	}

	private void ClearTrainInRangeText()
	{
		SetScreen(TextPreset.ClearTrainInRange);
	}

	private void ResetText()
	{
		displayTitleText.text = "";
		displayText.text = "";
	}

	private void LoadAllInstant()
	{
		List<Car> list = warehouseMachine.TryLoadCargoToAllCarsInstant();
		if (list.Any())
		{
			StringBuilder stringBuilder = new StringBuilder(6 + 2 * list.Count - 2);
			foreach (Car item in list)
			{
				stringBuilder.Append(item.ID + ((list.Last() != item) ? " ," : ""));
			}
			SetScreen(TextPreset.InstantLoad, isLoading: false, null, null, null, stringBuilder.ToString());
		}
		else
		{
			DisplayIdleText();
		}
	}

	private void UnloadAllInstant()
	{
		List<Car> list = warehouseMachine.TryUnloadCargoToAllCarsInstant();
		if (list.Any())
		{
			StringBuilder stringBuilder = new StringBuilder(6 + 2 * list.Count - 2);
			foreach (Car item in list)
			{
				stringBuilder.Append(item.ID + ((list.Last() != item) ? " ," : ""));
			}
			SetScreen(TextPreset.InstantUnload, isLoading: false, null, null, null, stringBuilder.ToString());
		}
		else
		{
			DisplayIdleText();
		}
	}

	private void SetScreen(TextPreset preset, bool isLoading = false, string jobId = null, Car car = null, CargoType_v2 cargoType = null, string extra = null)
	{
		if (new TextPresetData(preset, isLoading, jobId, car, cargoType, extra).UpdateStack(CurrentTextPresets))
		{
			UpdateScreen();
		}
	}

	public void UpdateScreen()
	{
		ResetText();
		foreach (TextPresetData currentTextPreset in CurrentTextPresets)
		{
			ShowPreset(currentTextPreset);
		}
	}

	public void ShowPreset(TextPresetData data)
	{
		switch (data.preset)
		{
		case TextPreset.NoTrains:
			if (errorSound != null)
			{
				errorSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			displayTitleText.text = (data.isLoading ? LOADING_UNAVAILABLE_TITLE : UNLOADING_UNAVAILABLE_TITLE);
			displayText.text = (data.isLoading ? NO_LOADABLE_TRAINS : NO_UNLOADABLE_TRAINS);
			break;
		case TextPreset.Busy:
			displayTitleText.text = (data.isLoading ? LOADING_IN_PROGRESS : UNLOADING_IN_PROGRESS);
			break;
		case TextPreset.Idle:
			displayTitleText.text = SUPPORTED_CARGO_TITLE;
			displayText.text = supportedCargoTypesText;
			break;
		case TextPreset.Completed:
			displayTitleText.text = (data.isLoading ? LOADING_COMPLETED_TITLE : UNLOADING_COMPLETED_TITLE);
			break;
		case TextPreset.Failed:
			if (errorSound != null)
			{
				errorSound.Play(base.transform.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			displayTitleText.text = (data.isLoading ? LOADING_UNAVAILABLE_TITLE : UNLOADING_UNAVAILABLE_TITLE);
			break;
		case TextPreset.ClearDesc:
			displayText.text = string.Empty;
			break;
		case TextPreset.Error:
		{
			TextMeshPro textMeshPro = displayText;
			textMeshPro.text = textMeshPro.text + "[" + data.jobId + "] " + LocalizationAPI.L(data.isLoading ? "whm/load_error_cars_on_track" : "whm/unload_error_cars_on_track") + "\n\n";
			break;
		}
		case TextPreset.Moving:
		{
			TextMeshPro textMeshPro = displayText;
			textMeshPro.text = textMeshPro.text + "[" + data.jobId + "] " + LocalizationAPI.L(data.isLoading ? "whm/load_error_cars_moving" : "whm/unload_error_cars_moving") + "\n\n";
			break;
		}
		case TextPreset.CarUpdated:
		{
			if (data.car == null || data.cargoType == null)
			{
				throw new ArgumentException("Both car and cargoType must be set when setting CarUpdated!");
			}
			TextMeshPro textMeshPro = displayText;
			textMeshPro.text = textMeshPro.text + "[" + data.car.ID + "] " + LocalizationAPI.L(data.isLoading ? "whm/item_loaded" : "whm/item_unloaded", LocalizationAPI.L(data.cargoType.localizationKeyFull)) + "\n\n";
			break;
		}
		case TextPreset.Partial:
		{
			TextMeshPro textMeshPro = displayText;
			textMeshPro.text = textMeshPro.text + "[" + data.jobId + "] " + LocalizationAPI.L(data.isLoading ? "whm/train_partially_loaded" : "whm/train_partially_unloaded") + "\n\n";
			break;
		}
		case TextPreset.Full:
		{
			TextMeshPro textMeshPro = displayText;
			textMeshPro.text = textMeshPro.text + "[" + data.jobId + "] " + LocalizationAPI.L(data.isLoading ? "whm/train_fully_loaded" : "whm/train_fully_unloaded") + "\n\n";
			break;
		}
		case TextPreset.TrainInRange:
			if (string.IsNullOrEmpty(data.extra))
			{
				throw new ArgumentException("extra must be set when setting TrainInRange!");
			}
			displayTrainInRangeText.text = LocalizationAPI.L("whm/train_in_range", data.extra);
			break;
		case TextPreset.ClearTrainInRange:
			displayTrainInRangeText.text = string.Empty;
			break;
		case TextPreset.InstantLoad:
			displayTitleText.text = LOADING_IN_PROGRESS;
			displayText.text = data.extra;
			break;
		case TextPreset.InstantUnload:
			displayTitleText.text = UNLOADING_IN_PROGRESS;
			displayText.text = data.extra;
			break;
		}
	}
}
