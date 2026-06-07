using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using DV.Simulation.Brake;
using DV.ThingTypes;
using DV.WeatherSystem;
using LocoSim.Implementations;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/GameParams config")]
public class GameParams : ScriptableObject, INotifyPropertyChanged
{
	public enum StartingItemsType
	{
		Basic = 0,
		Expanded = 1,
		Engineer = 2,
		Auto = 3
	}

	[NonSerialized]
	public float defaultStressThreshold;

	[Header("Derailment")]
	[Tooltip("Above this value stress will start building up. (BuildUp increases)")]
	[SerializeField]
	private float derailStressThreshold = 0.021f;

	[Header("Jobs")]
	[SerializeField]
	private float jobPaymentModifier = 1f;

	[SerializeField]
	private float jobBonusTimeLimitModifier = 1f;

	[Header("Fees")]
	[SerializeField]
	private float insuranceFeeQuotaMax = float.PositiveInfinity;

	[SerializeField]
	[Header("Comms Radio")]
	private float rerailMaxPrice = 5000f;

	[SerializeField]
	private bool clearDerailedAllowed = true;

	[SerializeField]
	private float deleteCarMaxPrice = 5000f;

	[SerializeField]
	private float workTrainSummonMaxPrice = float.PositiveInfinity;

	[SerializeField]
	private bool commsRadioSandboxCheatMode;

	[SerializeField]
	private bool switchModeAllowed = true;

	[Header("Coupling")]
	[SerializeField]
	private bool couplingViaRemoteControllerAllowed = true;

	[SerializeField]
	private bool couplingViaHUDAllowed = true;

	[SerializeField]
	private bool vrRemoteDrivingAllowed = true;

	[SerializeField]
	private bool handbrakeControlViaUIAllowed = true;

	[SerializeField]
	private bool autoHandbrakeViaRemoteControlCouplingAllowed = true;

	[SerializeField]
	private bool autoHandbrakeViaUICouplingAllowed;

	[SerializeField]
	private bool autoHandbrakeViaManualCouplingAllowed;

	[SerializeField]
	private bool autoHeadlightsDirectionAllowed;

	[SerializeField]
	private bool autoHeadlightsOnOffAllowed;

	[SerializeField]
	[Header("Player")]
	private StartingItemsType startingItems = StartingItemsType.Auto;

	[SerializeField]
	private bool keyboardDrivingAllowed = true;

	[SerializeField]
	private bool keyboardDrivingAnywhereOnVehicleAllowed;

	[SerializeField]
	private bool locoHUDAllowed = true;

	[SerializeField]
	private bool switchJunctionsViaMouse = true;

	[SerializeField]
	private bool shortDashAllowed = true;

	[SerializeField]
	private bool longDashAllowed = true;

	[SerializeField]
	private bool freeCamAllowed = true;

	[SerializeField]
	private bool freeCamDashAllowed = true;

	[SerializeField]
	private bool fastTravelAllowed = true;

	[SerializeField]
	private float fastTravelPriceModifier = 1f;

	[SerializeField]
	private bool playerMarkerDisplayed = true;

	[SerializeField]
	private bool locoMarkersDisplayed = true;

	[SerializeField]
	private bool remoteSignReadingAllowed = true;

	[SerializeField]
	private bool essentialItemsGetterAllowed = true;

	[SerializeField]
	private bool multiServicing = true;

	[SerializeField]
	private int sleepCooldownInHours = 6;

	[SerializeField]
	[Header("Warnings")]
	private bool brakeWarningsAllowed = true;

	[SerializeField]
	[Header("Adhesion")]
	private bool wheelSlideAllowed = true;

	[SerializeField]
	private bool wheelslipAllowed = true;

	[Header("Damage")]
	[SerializeField]
	private float damageSensitivityModifier = 1f;

	[SerializeField]
	[Header("Brakes")]
	private bool brakesPressureLeakAllowed = true;

	[SerializeField]
	private bool brakesOverheatingAllowed = true;

	[SerializeField]
	private bool compressorFailureAllowed = true;

	[SerializeField]
	[Header("Resource price modifiers")]
	private float consumablesPriceModifier = 1f;

	[SerializeField]
	private float damageablePriceModifier = 1f;

	[SerializeField]
	private float cargoDamagePriceModifier = 1f;

	[SerializeField]
	private float environmentDamagePriceModifier = 1f;

	[SerializeField]
	[Header("Sim")]
	private bool drivetrainFailuresAllowed = true;

	[SerializeField]
	private bool drivetrainOverheatingAllowed = true;

	[SerializeField]
	private float resourceConsumptionModifier = 1f;

	[SerializeField]
	private float steamStartupMultiplier = 1f;

	[Header("Weather")]
	[SerializeField]
	private bool rainAllowed = true;

	[SerializeField]
	private bool thunderAllowed = true;

	[SerializeField]
	private bool weatherEditorInPausedPhotoModeAllowed = true;

	[SerializeField]
	private bool weatherEditorInPhotoModeAllowed = true;

	[SerializeField]
	private bool weatherEditorAlwaysAllowed;

	[SerializeField]
	private bool timeOfDayEditingAllowed;

	[SerializeField]
	private float weatherSpeedModifier = 1f;

	[SerializeField]
	private float dayLengthInMinutes = 120f;

	[Header("Saving")]
	[SerializeField]
	private bool singleSaveMode;

	[Space(15f, order = 1)]
	[Header("Internal Parameters", order = 2)]
	[Space(15f, order = 3)]
	[Header("Adhesion", order = 4)]
	[SerializeField]
	private bool adhesionInfluencedByWeather = true;

	[SerializeField]
	[Header("Brakes")]
	private float compressorProductionModifier = 1f;

	[Header("Comms Radio")]
	[SerializeField]
	private bool commsRadioCheatMode;

	[Tooltip("Minimal speed below which it won't be derailed. In kmh")]
	[SerializeField]
	[Header("Derailment")]
	private float derailMinVelocity = 10f;

	[Tooltip("Whenever stress BuildUp is above this value, train will derail (but see RandomChance)")]
	[SerializeField]
	private float derailBuildUpThreshold = 0.6f;

	[SerializeField]
	[Tooltip("The speed at which stress build up will build up")]
	private float derailBuildUpMultiplier = 0.65f;

	[Tooltip("Speed at which BuildUp will falloff if not under stress")]
	[SerializeField]
	private float derailBuildUpRelease = 2.5f;

	[SerializeField]
	[Tooltip("Whenever build up is over threshold and a random value is below this (recalculated in every frame), it will derail")]
	private float derailRandomChance = 2f;

	private BrakeGameParams _brakeParams;

	private ResourceGameParams _resourcesParams;

	private SimGameParams _simParams;

	private WeatherGameParams _weatherParams;

	public float DerailStressThreshold
	{
		get
		{
			return derailStressThreshold;
		}
		set
		{
			SetField(ref derailStressThreshold, value, "DerailStressThreshold");
		}
	}

	public float JobPaymentModifier
	{
		get
		{
			return jobPaymentModifier;
		}
		set
		{
			SetField(ref jobPaymentModifier, value, "JobPaymentModifier");
		}
	}

	public float JobBonusTimeLimitModifier
	{
		get
		{
			return jobBonusTimeLimitModifier;
		}
		set
		{
			SetField(ref jobBonusTimeLimitModifier, value, "JobBonusTimeLimitModifier");
		}
	}

	public float InsuranceFeeQuotaMax
	{
		get
		{
			return insuranceFeeQuotaMax;
		}
		set
		{
			SetField(ref insuranceFeeQuotaMax, value, "InsuranceFeeQuotaMax");
		}
	}

	public float RerailMaxPrice
	{
		get
		{
			return rerailMaxPrice;
		}
		set
		{
			SetField(ref rerailMaxPrice, value, "RerailMaxPrice");
		}
	}

	public bool ClearDerailedAllowed
	{
		get
		{
			return clearDerailedAllowed;
		}
		set
		{
			SetField(ref clearDerailedAllowed, value, "ClearDerailedAllowed");
		}
	}

	public float DeleteCarMaxPrice
	{
		get
		{
			return deleteCarMaxPrice;
		}
		set
		{
			SetField(ref deleteCarMaxPrice, value, "DeleteCarMaxPrice");
		}
	}

	public float WorkTrainSummonMaxPrice
	{
		get
		{
			return workTrainSummonMaxPrice;
		}
		set
		{
			SetField(ref workTrainSummonMaxPrice, value, "WorkTrainSummonMaxPrice");
		}
	}

	public bool CommsRadioSandboxCheatMode
	{
		get
		{
			return commsRadioSandboxCheatMode;
		}
		set
		{
			SetField(ref commsRadioSandboxCheatMode, value, "CommsRadioSandboxCheatMode");
		}
	}

	public bool SwitchModeAllowed
	{
		get
		{
			return switchModeAllowed;
		}
		set
		{
			SetField(ref switchModeAllowed, value, "SwitchModeAllowed");
		}
	}

	public bool CouplingViaRemoteControllerAllowed
	{
		get
		{
			return couplingViaRemoteControllerAllowed;
		}
		set
		{
			SetField(ref couplingViaRemoteControllerAllowed, value, "CouplingViaRemoteControllerAllowed");
		}
	}

	public bool CouplingViaHUDAllowed
	{
		get
		{
			return couplingViaHUDAllowed;
		}
		set
		{
			SetField(ref couplingViaHUDAllowed, value, "CouplingViaHUDAllowed");
		}
	}

	public bool VRRemoteDrivingAllowed
	{
		get
		{
			return vrRemoteDrivingAllowed;
		}
		set
		{
			SetField(ref vrRemoteDrivingAllowed, value, "VRRemoteDrivingAllowed");
		}
	}

	public bool HandbrakeControlViaUIAllowed
	{
		get
		{
			return handbrakeControlViaUIAllowed;
		}
		set
		{
			SetField(ref handbrakeControlViaUIAllowed, value, "HandbrakeControlViaUIAllowed");
		}
	}

	public bool AutoHandbrakeViaRemoteControlCouplingAllowed
	{
		get
		{
			return autoHandbrakeViaRemoteControlCouplingAllowed;
		}
		set
		{
			SetField(ref autoHandbrakeViaRemoteControlCouplingAllowed, value, "AutoHandbrakeViaRemoteControlCouplingAllowed");
		}
	}

	public bool AutoHandbrakeViaUICouplingAllowed
	{
		get
		{
			return autoHandbrakeViaUICouplingAllowed;
		}
		set
		{
			SetField(ref autoHandbrakeViaUICouplingAllowed, value, "AutoHandbrakeViaUICouplingAllowed");
		}
	}

	public bool AutoHandbrakeViaManualCouplingAllowed
	{
		get
		{
			return autoHandbrakeViaManualCouplingAllowed;
		}
		set
		{
			SetField(ref autoHandbrakeViaManualCouplingAllowed, value, "AutoHandbrakeViaManualCouplingAllowed");
		}
	}

	public bool AutoHeadlightsDirectionAllowed
	{
		get
		{
			return autoHeadlightsDirectionAllowed;
		}
		set
		{
			SetField(ref autoHeadlightsDirectionAllowed, value, "AutoHeadlightsDirectionAllowed");
		}
	}

	public bool AutoHeadlightsOnOffAllowed
	{
		get
		{
			return autoHeadlightsOnOffAllowed;
		}
		set
		{
			SetField(ref autoHeadlightsOnOffAllowed, value, "AutoHeadlightsOnOffAllowed");
		}
	}

	public StartingItemsType StartingItems
	{
		get
		{
			return startingItems;
		}
		set
		{
			SetField(ref startingItems, value, "StartingItems");
		}
	}

	public bool KeyboardDrivingAllowed
	{
		get
		{
			return keyboardDrivingAllowed;
		}
		set
		{
			SetField(ref keyboardDrivingAllowed, value, "KeyboardDrivingAllowed");
		}
	}

	public bool KeyboardDrivingAnywhereOnVehicleAllowed
	{
		get
		{
			return keyboardDrivingAnywhereOnVehicleAllowed;
		}
		set
		{
			SetField(ref keyboardDrivingAnywhereOnVehicleAllowed, value, "KeyboardDrivingAnywhereOnVehicleAllowed");
		}
	}

	public bool LocoHUDAllowed
	{
		get
		{
			return locoHUDAllowed;
		}
		set
		{
			SetField(ref locoHUDAllowed, value, "LocoHUDAllowed");
		}
	}

	public bool SwitchJunctionsViaMouse
	{
		get
		{
			return switchJunctionsViaMouse;
		}
		set
		{
			SetField(ref switchJunctionsViaMouse, value, "SwitchJunctionsViaMouse");
		}
	}

	public bool ShortDashAllowed
	{
		get
		{
			return shortDashAllowed;
		}
		set
		{
			SetField(ref shortDashAllowed, value, "ShortDashAllowed");
		}
	}

	public bool LongDashAllowed
	{
		get
		{
			return longDashAllowed;
		}
		set
		{
			SetField(ref longDashAllowed, value, "LongDashAllowed");
		}
	}

	public bool FreeCamAllowed
	{
		get
		{
			return freeCamAllowed;
		}
		set
		{
			SetField(ref freeCamAllowed, value, "FreeCamAllowed");
		}
	}

	public bool FreeCamDashAllowed
	{
		get
		{
			return freeCamDashAllowed;
		}
		set
		{
			SetField(ref freeCamDashAllowed, value, "FreeCamDashAllowed");
		}
	}

	public bool FastTravelAllowed
	{
		get
		{
			return fastTravelAllowed;
		}
		set
		{
			SetField(ref fastTravelAllowed, value, "FastTravelAllowed");
		}
	}

	public float FastTravelPriceModifier
	{
		get
		{
			return fastTravelPriceModifier;
		}
		set
		{
			SetField(ref fastTravelPriceModifier, value, "FastTravelPriceModifier");
		}
	}

	public bool PlayerMarkerDisplayed
	{
		get
		{
			return playerMarkerDisplayed;
		}
		set
		{
			SetField(ref playerMarkerDisplayed, value, "PlayerMarkerDisplayed");
		}
	}

	public bool LocoMarkersDisplayed
	{
		get
		{
			return locoMarkersDisplayed;
		}
		set
		{
			SetField(ref locoMarkersDisplayed, value, "LocoMarkersDisplayed");
		}
	}

	public bool RemoteSignReadingAllowed
	{
		get
		{
			return remoteSignReadingAllowed;
		}
		set
		{
			SetField(ref remoteSignReadingAllowed, value, "RemoteSignReadingAllowed");
		}
	}

	public bool EssentialItemsGetterAllowed
	{
		get
		{
			return essentialItemsGetterAllowed;
		}
		set
		{
			SetField(ref essentialItemsGetterAllowed, value, "EssentialItemsGetterAllowed");
		}
	}

	public bool MultiServicing
	{
		get
		{
			return multiServicing;
		}
		set
		{
			SetField(ref multiServicing, value, "MultiServicing");
		}
	}

	public int SleepCooldownInHours
	{
		get
		{
			return sleepCooldownInHours;
		}
		set
		{
			SetField(ref sleepCooldownInHours, value, "SleepCooldownInHours");
		}
	}

	public bool BrakeWarningsAllowed
	{
		get
		{
			return brakeWarningsAllowed;
		}
		set
		{
			SetField(ref brakeWarningsAllowed, value, "BrakeWarningsAllowed");
		}
	}

	public bool WheelSlideAllowed
	{
		get
		{
			return wheelSlideAllowed;
		}
		set
		{
			SetField(ref wheelSlideAllowed, value, "WheelSlideAllowed");
		}
	}

	public bool WheelslipAllowed
	{
		get
		{
			return wheelslipAllowed;
		}
		set
		{
			SetField(ref wheelslipAllowed, value, "WheelslipAllowed");
		}
	}

	public float DamageSensitivityModifier
	{
		get
		{
			return damageSensitivityModifier;
		}
		set
		{
			SetField(ref damageSensitivityModifier, value, "DamageSensitivityModifier");
		}
	}

	public bool BrakesPressureLeakAllowed
	{
		get
		{
			return brakesPressureLeakAllowed;
		}
		set
		{
			if (SetField(ref brakesPressureLeakAllowed, value, "BrakesPressureLeakAllowed"))
			{
				BrakeParams.OverrideGameParams(compressorProductionModifier, brakesPressureLeakAllowed, brakesOverheatingAllowed);
			}
		}
	}

	public bool BrakesOverheatingAllowed
	{
		get
		{
			return brakesOverheatingAllowed;
		}
		set
		{
			if (SetField(ref brakesOverheatingAllowed, value, "BrakesOverheatingAllowed"))
			{
				BrakeParams.OverrideGameParams(compressorProductionModifier, brakesPressureLeakAllowed, brakesOverheatingAllowed);
			}
		}
	}

	public bool CompressorFailureAllowed
	{
		get
		{
			return compressorFailureAllowed;
		}
		set
		{
			if (SetField(ref compressorFailureAllowed, value, "CompressorFailureAllowed"))
			{
				SimParams.OverrideGameParams(drivetrainFailuresAllowed, drivetrainOverheatingAllowed, compressorFailureAllowed, resourceConsumptionModifier, steamStartupMultiplier);
			}
		}
	}

	public float ConsumablesPriceModifier
	{
		get
		{
			return consumablesPriceModifier;
		}
		set
		{
			if (SetField(ref consumablesPriceModifier, value, "ConsumablesPriceModifier"))
			{
				ResourcesParams.OverrideGameParams(consumablesPriceModifier, damageablePriceModifier, cargoDamagePriceModifier, environmentDamagePriceModifier);
			}
		}
	}

	public float DamageablePriceModifier
	{
		get
		{
			return damageablePriceModifier;
		}
		set
		{
			if (SetField(ref damageablePriceModifier, value, "DamageablePriceModifier"))
			{
				ResourcesParams.OverrideGameParams(consumablesPriceModifier, damageablePriceModifier, cargoDamagePriceModifier, environmentDamagePriceModifier);
			}
		}
	}

	public float CargoDamagePriceModifier
	{
		get
		{
			return cargoDamagePriceModifier;
		}
		set
		{
			if (SetField(ref cargoDamagePriceModifier, value, "CargoDamagePriceModifier"))
			{
				ResourcesParams.OverrideGameParams(consumablesPriceModifier, damageablePriceModifier, cargoDamagePriceModifier, environmentDamagePriceModifier);
			}
		}
	}

	public float EnvironmentDamagePriceModifier
	{
		get
		{
			return environmentDamagePriceModifier;
		}
		set
		{
			if (SetField(ref environmentDamagePriceModifier, value, "EnvironmentDamagePriceModifier"))
			{
				ResourcesParams.OverrideGameParams(consumablesPriceModifier, damageablePriceModifier, cargoDamagePriceModifier, environmentDamagePriceModifier);
			}
		}
	}

	public bool DrivetrainFailuresAllowed
	{
		get
		{
			return drivetrainFailuresAllowed;
		}
		set
		{
			if (SetField(ref drivetrainFailuresAllowed, value, "DrivetrainFailuresAllowed"))
			{
				SimParams.OverrideGameParams(drivetrainFailuresAllowed, drivetrainOverheatingAllowed, compressorFailureAllowed, resourceConsumptionModifier, steamStartupMultiplier);
			}
		}
	}

	public bool DrivetrainOverheatingAllowed
	{
		get
		{
			return drivetrainOverheatingAllowed;
		}
		set
		{
			if (SetField(ref drivetrainOverheatingAllowed, value, "DrivetrainOverheatingAllowed"))
			{
				SimParams.OverrideGameParams(drivetrainFailuresAllowed, drivetrainOverheatingAllowed, compressorFailureAllowed, resourceConsumptionModifier, steamStartupMultiplier);
			}
		}
	}

	public float ResourceConsumptionModifier
	{
		get
		{
			return resourceConsumptionModifier;
		}
		set
		{
			if (SetField(ref resourceConsumptionModifier, value, "ResourceConsumptionModifier"))
			{
				SimParams.OverrideGameParams(drivetrainFailuresAllowed, drivetrainOverheatingAllowed, compressorFailureAllowed, resourceConsumptionModifier, steamStartupMultiplier);
			}
		}
	}

	public float SteamStartupMultiplier
	{
		get
		{
			return steamStartupMultiplier;
		}
		set
		{
			if (SetField(ref steamStartupMultiplier, value, "SteamStartupMultiplier"))
			{
				SimParams.OverrideGameParams(drivetrainFailuresAllowed, drivetrainOverheatingAllowed, compressorFailureAllowed, resourceConsumptionModifier, steamStartupMultiplier);
			}
		}
	}

	public bool RainAllowed
	{
		get
		{
			return rainAllowed;
		}
		set
		{
			if (SetField(ref rainAllowed, value, "RainAllowed"))
			{
				WeatherParams.OverrideGameParams(rainAllowed, thunderAllowed, weatherSpeedModifier, dayLengthInMinutes);
			}
		}
	}

	public bool ThunderAllowed
	{
		get
		{
			return thunderAllowed;
		}
		set
		{
			if (SetField(ref thunderAllowed, value, "ThunderAllowed"))
			{
				WeatherParams.OverrideGameParams(rainAllowed, thunderAllowed, weatherSpeedModifier, dayLengthInMinutes);
			}
		}
	}

	public bool WeatherEditorInPausedPhotoModeAllowed
	{
		get
		{
			return weatherEditorInPausedPhotoModeAllowed;
		}
		set
		{
			SetField(ref weatherEditorInPausedPhotoModeAllowed, value, "WeatherEditorInPausedPhotoModeAllowed");
		}
	}

	public bool WeatherEditorInPhotoModeAllowed
	{
		get
		{
			return weatherEditorInPhotoModeAllowed;
		}
		set
		{
			SetField(ref weatherEditorInPhotoModeAllowed, value, "WeatherEditorInPhotoModeAllowed");
		}
	}

	public bool WeatherEditorAlwaysAllowed
	{
		get
		{
			return weatherEditorAlwaysAllowed;
		}
		set
		{
			SetField(ref weatherEditorAlwaysAllowed, value, "WeatherEditorAlwaysAllowed");
		}
	}

	public bool TimeOfDayEditingAllowed
	{
		get
		{
			return timeOfDayEditingAllowed;
		}
		set
		{
			SetField(ref timeOfDayEditingAllowed, value, "TimeOfDayEditingAllowed");
		}
	}

	public float WeatherSpeedModifier
	{
		get
		{
			return weatherSpeedModifier;
		}
		set
		{
			if (SetField(ref weatherSpeedModifier, value, "WeatherSpeedModifier"))
			{
				WeatherParams.OverrideGameParams(rainAllowed, thunderAllowed, weatherSpeedModifier, dayLengthInMinutes);
			}
		}
	}

	public float DayLengthInMinutes
	{
		get
		{
			return dayLengthInMinutes;
		}
		set
		{
			if (SetField(ref dayLengthInMinutes, value, "DayLengthInMinutes"))
			{
				WeatherParams.OverrideGameParams(rainAllowed, thunderAllowed, weatherSpeedModifier, dayLengthInMinutes);
			}
		}
	}

	public bool SingleSaveMode
	{
		get
		{
			return singleSaveMode;
		}
		set
		{
			SetField(ref singleSaveMode, value, "SingleSaveMode");
		}
	}

	public bool AdhesionInfluencedByWeather
	{
		get
		{
			return adhesionInfluencedByWeather;
		}
		set
		{
			SetField(ref adhesionInfluencedByWeather, value, "AdhesionInfluencedByWeather");
		}
	}

	public float CompressorProductionModifier
	{
		get
		{
			return compressorProductionModifier;
		}
		set
		{
			if (SetField(ref compressorProductionModifier, value, "CompressorProductionModifier"))
			{
				BrakeParams.OverrideGameParams(compressorProductionModifier, brakesPressureLeakAllowed, brakesOverheatingAllowed);
			}
		}
	}

	public bool CommsRadioCheatMode
	{
		get
		{
			return commsRadioCheatMode;
		}
		set
		{
			SetField(ref commsRadioCheatMode, value, "CommsRadioCheatMode");
		}
	}

	public float DerailMinVelocity
	{
		get
		{
			return derailMinVelocity;
		}
		set
		{
			SetField(ref derailMinVelocity, value, "DerailMinVelocity");
		}
	}

	public float DerailBuildUpThreshold
	{
		get
		{
			return derailBuildUpThreshold;
		}
		set
		{
			SetField(ref derailBuildUpThreshold, value, "DerailBuildUpThreshold");
		}
	}

	public float DerailBuildUpMultiplier
	{
		get
		{
			return derailBuildUpMultiplier;
		}
		set
		{
			SetField(ref derailBuildUpMultiplier, value, "DerailBuildUpMultiplier");
		}
	}

	public float DerailBuildUpRelease
	{
		get
		{
			return derailBuildUpRelease;
		}
		set
		{
			SetField(ref derailBuildUpRelease, value, "DerailBuildUpRelease");
		}
	}

	public float DerailRandomChance
	{
		get
		{
			return derailRandomChance;
		}
		set
		{
			SetField(ref derailRandomChance, value, "DerailRandomChance");
		}
	}

	public BrakeGameParams BrakeParams
	{
		get
		{
			if (_brakeParams == null)
			{
				return _brakeParams = new BrakeGameParams(compressorProductionModifier, brakesPressureLeakAllowed, brakesOverheatingAllowed);
			}
			return _brakeParams;
		}
	}

	public ResourceGameParams ResourcesParams
	{
		get
		{
			if (_resourcesParams == null)
			{
				return _resourcesParams = new ResourceGameParams(consumablesPriceModifier, damageablePriceModifier, cargoDamagePriceModifier, environmentDamagePriceModifier);
			}
			return _resourcesParams;
		}
	}

	public SimGameParams SimParams
	{
		get
		{
			if (_simParams == null)
			{
				return _simParams = new SimGameParams(drivetrainFailuresAllowed, drivetrainOverheatingAllowed, compressorFailureAllowed, resourceConsumptionModifier, steamStartupMultiplier);
			}
			return _simParams;
		}
	}

	public WeatherGameParams WeatherParams
	{
		get
		{
			if (_weatherParams == null)
			{
				return _weatherParams = new WeatherGameParams(rainAllowed, thunderAllowed, weatherSpeedModifier, dayLengthInMinutes);
			}
			return _weatherParams;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	private void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(field, value))
		{
			return false;
		}
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	private void Awake()
	{
		defaultStressThreshold = derailStressThreshold;
	}

	public override string ToString()
	{
		PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
		string text = "";
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			text += $"{propertyInfo.Name}: {propertyInfo.GetValue(this)}\n";
		}
		return text;
	}
}
