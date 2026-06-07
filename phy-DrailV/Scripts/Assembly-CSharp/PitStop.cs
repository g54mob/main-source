using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DV;
using DV.CabControls;
using DV.Common;
using DV.Localization;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using TMPro;
using UnityEngine;

public class PitStop : MonoBehaviour
{
	private const string CHECK_TRIGGER_COLLIDER_TAG = "MainTriggerCollider";

	public LampControl locoInPitStopServiceAllowedLamp;

	public LampControl locoInPitStopServiceForbidenLamp;

	public TextMeshPro manualServiceText;

	public TextMeshPro locoInRangeText;

	public TextMeshPro selectedCarText;

	public AudioClip chingSound;

	public AudioClip errorSound;

	[Header("Input")]
	public GameObject selectorKnob;

	[Header("Behavior")]
	public bool switchingWrapAround = true;

	private CarPitStopParametersBase pitStopCarParameters;

	private bool pitStopOccupied;

	private bool isManualServiceLicenseAcquired;

	private SteppedJoint selectorJoint;

	private List<TrainCar> carList = new List<TrainCar>();

	private List<CarPitStopParametersBase> paramsList = new List<CarPitStopParametersBase>();

	private int currentCarIndex;

	private string MANUAL_SERVICE_TITLE => LocalizationAPI.L("pit/ready_for_service");

	private string REQUIRES_MANUAL_SERVICE_LICENSE_TITLE => LocalizationAPI.L("pit/requires_license");

	public bool IsOccupied => pitStopOccupied;

	public TrainCar CurrentCar { get; private set; }

	public bool IsSwitchingAllowed => Globals.G.GameParams.MultiServicing;

	public Trainset CurrentSet
	{
		get
		{
			if (!(CurrentCar != null))
			{
				return null;
			}
			return CurrentCar.trainset;
		}
	}

	public bool HasEligibleCars => carList.Count > 0;

	public int EligibleCarsCount => carList.Count;

	public TrainCar SelectedCar
	{
		get
		{
			if (currentCarIndex < 0)
			{
				return null;
			}
			return carList[currentCarIndex];
		}
	}

	public int SelectedIndex => currentCarIndex;

	public CarPitStopParametersBase SelectedCarParams
	{
		get
		{
			if (currentCarIndex < 0)
			{
				return null;
			}
			return paramsList[currentCarIndex];
		}
	}

	public event Action CarExited;

	public event Action CarEntered;

	public event Action CarSelected;

	private void Awake()
	{
		if (chingSound == null || errorSound == null)
		{
			Debug.LogError("chingSound or errorSound not set!", this);
		}
		if (locoInPitStopServiceAllowedLamp == null || locoInPitStopServiceForbidenLamp == null || manualServiceText == null || locoInRangeText == null)
		{
			Debug.LogError("PitStop not initialized properly!", this);
		}
		LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
		isManualServiceLicenseAcquired = instance.IsGeneralLicenseAcquired(GeneralLicenseType.ManualService.ToV2());
		if (!isManualServiceLicenseAcquired)
		{
			instance.LicenseAcquired += OnManualServiceLicenseAcquired;
			manualServiceText.text = REQUIRES_MANUAL_SERVICE_LICENSE_TITLE;
		}
		else
		{
			manualServiceText.text = MANUAL_SERVICE_TITLE;
		}
		selectorKnob.SetActive(IsSwitchingAllowed);
		Globals.G.GameParams.PropertyChanged += OnGameParamsChanged;
		GameFeatureFlags.RegisterListenerFor(GameFeatureFlags.Flag.UseServiceStations, OnServiceStationAllowedChanged);
		locoInRangeText.text = string.Empty;
		selectedCarText.text = string.Empty;
		StartCoroutine(InitSwitcher());
	}

	private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "MultiServicing")
		{
			CarPitStopParametersBase carPitStopParametersBase = pitStopCarParameters;
			if (pitStopCarParameters != null)
			{
				CarExit();
			}
			selectorKnob.SetActive(IsSwitchingAllowed);
			if (carPitStopParametersBase != null)
			{
				CarEnter(carPitStopParametersBase);
			}
		}
	}

	private void OnServiceStationAllowedChanged(GameFeatureFlags.Flag flag, bool allowed)
	{
		if (!allowed && (bool)pitStopCarParameters)
		{
			CarExit();
		}
		else if (allowed)
		{
			RefreshPitStopCarPresence();
		}
	}

	public void RefreshPitStopCarPresence()
	{
		Collider[] components = GetComponents<Collider>();
		Collider[] array = components;
		foreach (Collider collider in array)
		{
			if (collider.isTrigger)
			{
				collider.enabled = false;
			}
		}
		array = components;
		foreach (Collider collider2 in array)
		{
			if (collider2.isTrigger)
			{
				collider2.enabled = true;
			}
		}
	}

	private IEnumerator InitSwitcher()
	{
		int attempts = 10;
		while (attempts > 0)
		{
			selectorJoint = selectorKnob.GetComponent<SteppedJoint>();
			if (selectorJoint != null)
			{
				selectorJoint.PositionChanged += OnSwitcherPositionChange;
				yield break;
			}
			attempts--;
			yield return null;
		}
		Debug.LogError("SteppedJoint not found on object " + selectorJoint.name + " where it was expected, disabling this PitStop (" + base.gameObject.name + ")", selectorJoint);
		base.enabled = false;
	}

	private void OnSwitcherPositionChange(ValueChangedEventArgs args)
	{
		if ((int)args.delta > 0)
		{
			SwitchToNext();
		}
		else if ((int)args.delta < 0)
		{
			SwitchToPrevious();
		}
	}

	private void OnManualServiceLicenseAcquired(GeneralLicenseType_v2 acquiredLicense)
	{
		if (acquiredLicense.v1 == GeneralLicenseType.ManualService)
		{
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnManualServiceLicenseAcquired;
			isManualServiceLicenseAcquired = true;
			manualServiceText.text = MANUAL_SERVICE_TITLE;
			SingletonBehaviour<CoroutineManager>.Instance.Run(RefreshTriggerEnter());
		}
	}

	private void OnDestroy()
	{
		GameFeatureFlags.UnregisterListenerFor(GameFeatureFlags.Flag.UseServiceStations, OnServiceStationAllowedChanged);
		Globals.G.GameParams.PropertyChanged -= OnGameParamsChanged;
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnManualServiceLicenseAcquired;
		}
	}

	private IEnumerator RefreshTriggerEnter()
	{
		Vector3 originalLocalPos = base.transform.localPosition;
		base.transform.localPosition = new Vector3(0f, -2000f, 0f);
		yield return null;
		base.transform.localPosition = originalLocalPos;
	}

	private void OnEnable()
	{
		StartCoroutine(ExternalCarDestroyCheck());
		OnServiceStationAllowedChanged(GameFeatureFlags.Flag.UseServiceStations, GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseServiceStations));
	}

	private void OnDisable()
	{
		StopAllCoroutines();
		CarExit();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (SingletonBehaviour<PausePhysicsHandler>.Instance.IgnorePhysicsEvents || !GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseServiceStations) || other.tag != "MainTriggerCollider")
		{
			return;
		}
		TrainCar trainCar = TrainCar.Resolve(other.gameObject);
		if (trainCar == null || trainCar.preventService)
		{
			return;
		}
		CarPitStopParametersBase component = trainCar.GetComponent<CarPitStopParametersBase>();
		if (!(component != null))
		{
			return;
		}
		if (!isManualServiceLicenseAcquired)
		{
			locoInPitStopServiceAllowedLamp.SetLampState(LampControl.LampState.Off);
			locoInPitStopServiceForbidenLamp.SetLampState(LampControl.LampState.Blinking);
			if (errorSound != null)
			{
				errorSound.Play(locoInPitStopServiceForbidenLamp.transform.position, 1f, 1f, 0f, 1f, 100f, default(AudioSourceCurves), null, locoInPitStopServiceForbidenLamp.transform);
			}
		}
		else
		{
			locoInPitStopServiceAllowedLamp.SetLampState(LampControl.LampState.On);
			locoInPitStopServiceForbidenLamp.SetLampState(LampControl.LampState.Off);
			if (chingSound != null)
			{
				chingSound.Play(locoInPitStopServiceAllowedLamp.transform.position, 1f, 1f, 0f, 1f, 100f, default(AudioSourceCurves), null, locoInPitStopServiceAllowedLamp.transform);
			}
			if (IsCarInPitStop())
			{
				CarExit();
			}
			CarEnter(component);
		}
		string iD = trainCar.ID;
		locoInRangeText.text = LocalizationAPI.L("pit/loco_in_range", iD);
	}

	private void OnTriggerExit(Collider other)
	{
		if (SingletonBehaviour<PausePhysicsHandler>.Instance.IgnorePhysicsEvents || !other.CompareTag("MainTriggerCollider"))
		{
			return;
		}
		TrainCar trainCar = TrainCar.Resolve(other.gameObject);
		if (!(trainCar == null) && !trainCar.preventService)
		{
			if (!isManualServiceLicenseAcquired)
			{
				ResetIndicatorStatus();
			}
			else if (pitStopCarParameters != null && pitStopCarParameters == trainCar.GetComponent<CarPitStopParametersBase>())
			{
				CarExit();
			}
		}
	}

	private void CarExit()
	{
		ResetIndicatorStatus();
		currentCarIndex = -1;
		carList.Clear();
		paramsList.Clear();
		pitStopCarParameters = null;
		pitStopOccupied = false;
		if (CurrentCar != null)
		{
			CurrentCar.TrainsetChanged -= OnTrainSetChanged;
		}
		CurrentCar = null;
		selectedCarText.text = string.Empty;
		this.CarExited?.Invoke();
	}

	private void CarEnter(CarPitStopParametersBase carParameters)
	{
		CurrentCar = carParameters.GetComponent<TrainCar>();
		if (CurrentCar == null)
		{
			return;
		}
		pitStopCarParameters = carParameters;
		pitStopOccupied = true;
		CurrentCar.TrainsetChanged += OnTrainSetChanged;
		currentCarIndex = -1;
		carList.Clear();
		paramsList.Clear();
		if (IsSwitchingAllowed)
		{
			foreach (TrainCar car in CurrentCar.trainset.cars)
			{
				CarPitStopParametersBase component = car.GetComponent<CarPitStopParametersBase>();
				if (component != null)
				{
					carList.Add(car);
					paramsList.Add(component);
					if (car == CurrentCar)
					{
						currentCarIndex = carList.Count - 1;
					}
				}
			}
		}
		else
		{
			carList.Add(CurrentCar);
			CarPitStopParametersBase component2 = CurrentCar.GetComponent<CarPitStopParametersBase>();
			if ((bool)component2)
			{
				paramsList.Add(component2);
			}
		}
		if (currentCarIndex < 0 && carList.Count > 0)
		{
			currentCarIndex = 0;
		}
		if (currentCarIndex >= 0)
		{
			OnCarSelectionChanged();
		}
		this.CarEntered?.Invoke();
		this.CarSelected?.Invoke();
	}

	private void OnTrainSetChanged(Trainset trainset)
	{
		CarPitStopParametersBase carPitStopParametersBase = pitStopCarParameters;
		CarExit();
		if (carPitStopParametersBase != null && trainset != null)
		{
			CarEnter(carPitStopParametersBase);
		}
	}

	private IEnumerator ExternalCarDestroyCheck()
	{
		while (true)
		{
			if (pitStopOccupied && pitStopCarParameters == null)
			{
				CarExit();
			}
			yield return WaitFor.Seconds(1f);
		}
	}

	private void ResetIndicatorStatus()
	{
		locoInPitStopServiceAllowedLamp.SetLampState(LampControl.LampState.Off);
		locoInPitStopServiceForbidenLamp.SetLampState(LampControl.LampState.Off);
		locoInRangeText.text = string.Empty;
	}

	public bool IsCarInPitStop()
	{
		return pitStopCarParameters != null;
	}

	public CarPitStopParametersBase GetCarParameters()
	{
		return SelectedCarParams;
	}

	public CarPitStopParametersBase GetCarParameters(int index)
	{
		return paramsList[index];
	}

	private void OnCarSelectionChanged()
	{
		if (IsSwitchingAllowed)
		{
			selectedCarText.text = $"({currentCarIndex + 1}/{carList.Count}) {SelectedCar.ID}";
		}
		else
		{
			selectedCarText.text = SelectedCar.ID;
		}
		this.CarSelected?.Invoke();
	}

	public bool SwitchToNext()
	{
		if (carList.Count <= 1)
		{
			return false;
		}
		if (currentCarIndex >= carList.Count - 1 && !switchingWrapAround)
		{
			return false;
		}
		for (int i = 1; i < carList.Count; i++)
		{
			int num = currentCarIndex + i;
			if (num >= carList.Count && !switchingWrapAround)
			{
				return false;
			}
			num %= carList.Count;
			if (!carList[num].preventService)
			{
				currentCarIndex = num;
				OnCarSelectionChanged();
				return true;
			}
		}
		return false;
	}

	public bool SwitchToPrevious()
	{
		if (carList.Count <= 1)
		{
			return false;
		}
		if (currentCarIndex <= 0 && !switchingWrapAround)
		{
			return false;
		}
		for (int i = 1; i < carList.Count; i++)
		{
			int num = currentCarIndex - i;
			if (num < 0 && !switchingWrapAround)
			{
				return false;
			}
			if (num < 0)
			{
				num += carList.Count;
			}
			if (!carList[num].preventService)
			{
				currentCarIndex = num;
				OnCarSelectionChanged();
				return true;
			}
		}
		return false;
	}
}
