using System;
using System.Collections.Generic;
using DV.Scenarios;
using DV.Scenarios.Common;
using DV.UI;
using UnityEngine;

namespace DV.Utils
{
	public static class DifficultyParamsSetter
	{
		public static readonly IDifficulty Standard = ((Difficulty)PopulateStandard(new Difficulty())).MakeReadOnly();

		public static readonly IDifficulty Comfort = ((Difficulty)PopulateComfort(new Difficulty())).MakeReadOnly();

		public static readonly IDifficulty Realistic = ((Difficulty)PopulateRealistic(new Difficulty())).MakeReadOnly();

		public static readonly IDifficulty StandardSandbox = ((Difficulty)PopulateStandardSandbox(new Difficulty())).MakeReadOnly();

		public static readonly IReadOnlyList<IDifficulty> PredefinedDifficulties = new List<IDifficulty> { Standard, Comfort, Realistic, StandardSandbox };

		public const string STANDARD_NAME = "Standard";

		public const string COMFORT_NAME = "Comfort";

		public const string REALISTIC_NAME = "Realistic";

		public const string STANDARD_SANDBOX_NAME = "Standard Sandbox";

		public const int KEYBOARD_DRIVING_OFF = 0;

		public const int KEYBOARD_DRIVING_WITHIN_REACH = 1;

		public const int KEYBOARD_DRIVING_ON_VEHICLE = 2;

		private const int REMOTE_SWITCHING_OFF = 0;

		private const int REMOTE_SWITCHING_COMMS = 1;

		private const int REMOTE_SWITCHING_UI = 2;

		private const int REMOTE_COUPLING_OFF = 0;

		private const int REMOTE_COUPLING_REMOTE_CONTROLLER = 1;

		private const int REMOTE_COUPLING_UI = 2;

		private const int AUTOMATIC_HANDBRAKE_OFF = 0;

		private const int AUTOMATIC_HANDBRAKE_REMOTE_CONTROLLER = 1;

		private const int AUTOMATIC_HANDBRAKE_UI = 2;

		private const int AUTOMATIC_HANDBRAKE_ALWAYS = 3;

		private const int AUTOMATIC_HEADLIGHT_OFF = 0;

		private const int AUTOMATIC_HEADLIGHT_DIRECTION = 1;

		private const int AUTOMATIC_HEADLIGHT_ALL = 2;

		private const int FAST_TRAVEL_FREE = 0;

		private const int FAST_TRAVEL_PAID = 1;

		private const int FAST_TRAVEL_OFF = 2;

		private const int DASH_OFF = 0;

		private const int DASH_SHORT = 1;

		private const int DASH_LONG = 2;

		private const int WEATHER_EDITOR_OFF = 0;

		private const int WEATHER_EDITOR_PAUSED_PHOTO_MODE = 1;

		private const int WEATHER_EDITOR_PHOTO_MODE = 2;

		private const int WEATHER_EDITOR_ALWAYS = 3;

		private const float BASE_COMPRESSOR_PRODUCTION_MULTIPLIER = 10f;

		public static void SetDifficultyParams(IDifficulty dp)
		{
			GameParams gameParams = Globals.G.GameParams;
			gameParams.KeyboardDrivingAllowed = dp.KeyboardDriving >= 1;
			gameParams.KeyboardDrivingAnywhereOnVehicleAllowed = dp.KeyboardDriving >= 2;
			gameParams.FreeCamAllowed = dp.FreeCamera;
			gameParams.LocoHUDAllowed = dp.HUD;
			gameParams.JobPaymentModifier = dp.PaymentModifier;
			gameParams.JobBonusTimeLimitModifier = dp.BonusTimeModifier;
			gameParams.InsuranceFeeQuotaMax = dp.MaxCopay;
			bool drivetrainFailuresAllowed = (gameParams.DrivetrainOverheatingAllowed = dp.DrivetrainFailures);
			gameParams.DrivetrainFailuresAllowed = drivetrainFailuresAllowed;
			gameParams.SteamStartupMultiplier = dp.SteamStartupMultiplier;
			gameParams.CompressorProductionModifier = 10f / dp.MainResFillTime;
			drivetrainFailuresAllowed = (gameParams.WheelSlideAllowed = dp.TractionFailures);
			gameParams.WheelslipAllowed = drivetrainFailuresAllowed;
			bool flag = (gameParams.CompressorFailureAllowed = dp.BrakeFailures);
			drivetrainFailuresAllowed = (gameParams.BrakesPressureLeakAllowed = flag);
			gameParams.BrakesOverheatingAllowed = drivetrainFailuresAllowed;
			gameParams.BrakeWarningsAllowed = dp.BrakeWarnings;
			gameParams.HandbrakeControlViaUIAllowed = dp.RemoteHandbrake;
			gameParams.AutoHandbrakeViaRemoteControlCouplingAllowed = dp.AutomaticHandbrakeMode >= 1;
			gameParams.AutoHandbrakeViaUICouplingAllowed = dp.AutomaticHandbrakeMode >= 2;
			gameParams.AutoHandbrakeViaManualCouplingAllowed = dp.AutomaticHandbrakeMode >= 3;
			gameParams.AutoHeadlightsDirectionAllowed = dp.AutomaticHeadlightMode >= 1;
			gameParams.AutoHeadlightsOnOffAllowed = dp.AutomaticHeadlightMode >= 2;
			gameParams.ResourceConsumptionModifier = dp.ResourceConsumptionModifier;
			gameParams.ConsumablesPriceModifier = dp.ResourceCostModifier;
			gameParams.DamageSensitivityModifier = dp.DamageSensitivityModifier;
			gameParams.DamageablePriceModifier = dp.RepairCostModifier;
			gameParams.CargoDamagePriceModifier = dp.CargoDamageCostModifier;
			gameParams.EnvironmentDamagePriceModifier = dp.EnvironmentDamageCostModifier;
			gameParams.SwitchModeAllowed = dp.RemoteSwitchingMode >= 1;
			gameParams.SwitchJunctionsViaMouse = dp.RemoteSwitchingMode >= 2;
			gameParams.MultiServicing = dp.MultiServicing;
			gameParams.SleepCooldownInHours = dp.SleepCooldownInHours;
			gameParams.CouplingViaRemoteControllerAllowed = dp.RemoteCouplingMode >= 1;
			gameParams.CouplingViaHUDAllowed = dp.RemoteCouplingMode >= 2;
			gameParams.VRRemoteDrivingAllowed = dp.VRRemoteDriving;
			gameParams.RemoteSignReadingAllowed = dp.RemoteSignReading;
			gameParams.DerailStressThreshold = (dp.Derailing ? gameParams.defaultStressThreshold : float.PositiveInfinity);
			gameParams.RerailMaxPrice = dp.RerailMaxCost;
			gameParams.ClearDerailedAllowed = dp.ClearDerailed;
			gameParams.DeleteCarMaxPrice = dp.ClearMaxCost;
			gameParams.WorkTrainSummonMaxPrice = dp.SummonWorkTrainMaxCost;
			gameParams.CommsRadioSandboxCheatMode = dp.CommsRadioCheatMode;
			bool flag3 = Enum.IsDefined(typeof(GameParams.StartingItemsType), dp.StartingItems);
			if (!flag3)
			{
				Debug.LogError("Unexpected state: Difficulty param StartingItems couldn't be parsed. Using Auto");
			}
			gameParams.StartingItems = (flag3 ? ((GameParams.StartingItemsType)dp.StartingItems) : GameParams.StartingItemsType.Auto);
			gameParams.EssentialItemsGetterAllowed = dp.InventoryItemRespawn;
			drivetrainFailuresAllowed = (gameParams.PlayerMarkerDisplayed = dp.MapBlips);
			gameParams.LocoMarkersDisplayed = drivetrainFailuresAllowed;
			gameParams.FastTravelAllowed = dp.FastTravelMode != 2;
			gameParams.FastTravelPriceModifier = ((dp.FastTravelMode == 1) ? 1f : 0f);
			gameParams.ShortDashAllowed = dp.Dash >= 1;
			gameParams.LongDashAllowed = dp.Dash >= 2;
			gameParams.FreeCamDashAllowed = dp.CameraDash;
			gameParams.DayLengthInMinutes = dp.DayDurationInMinutes;
			gameParams.WeatherSpeedModifier = dp.WeatherChangeSpeedModifier;
			gameParams.RainAllowed = dp.Rain;
			gameParams.ThunderAllowed = dp.Lightnings;
			gameParams.WeatherEditorInPausedPhotoModeAllowed = dp.WeatherEditorMode >= 1;
			gameParams.WeatherEditorInPhotoModeAllowed = dp.WeatherEditorMode >= 2;
			gameParams.WeatherEditorAlwaysAllowed = dp.WeatherEditorMode >= 3;
			gameParams.TimeOfDayEditingAllowed = dp.TimeOfDayEditing;
			gameParams.SingleSaveMode = dp.SingleSaveMode;
		}

		private static IDifficulty PopulateComfort(IDifficulty d)
		{
			d.Name = "Comfort";
			d.KeyboardDriving = 2;
			d.FreeCamera = true;
			d.HUD = true;
			d.PaymentModifier = 1.5f;
			d.BonusTimeModifier = 2f;
			d.MaxCopay = 10000;
			d.DrivetrainFailures = false;
			d.TractionFailures = false;
			d.BrakeFailures = false;
			d.BrakeWarnings = true;
			d.RemoteHandbrake = true;
			d.AutomaticHandbrakeMode = 2;
			d.AutomaticHeadlightMode = 1;
			d.ResourceConsumptionModifier = 0.5f;
			d.ResourceCostModifier = 0.5f;
			d.DamageSensitivityModifier = 0.5f;
			d.RepairCostModifier = 0.5f;
			d.CargoDamageCostModifier = 0f;
			d.EnvironmentDamageCostModifier = 0f;
			d.MultiServicing = true;
			d.SleepCooldownInHours = 0;
			d.RemoteSwitchingMode = 2;
			d.RemoteCouplingMode = 2;
			d.VRRemoteDriving = true;
			d.RemoteSignReading = true;
			d.Derailing = true;
			d.SteamStartupMultiplier = 0.25f;
			d.MainResFillTime = 1f;
			d.RerailMaxCost = 0;
			d.ClearDerailed = true;
			d.ClearMaxCost = 0;
			d.SummonWorkTrainMaxCost = 0;
			d.CommsRadioCheatMode = true;
			d.StartingItems = 1;
			d.InventoryItemRespawn = true;
			d.MapBlips = true;
			d.FastTravelMode = 0;
			d.Dash = 2;
			d.CameraDash = true;
			d.DayDurationInMinutes = 120f;
			d.WeatherChangeSpeedModifier = 1f;
			d.Rain = true;
			d.Lightnings = true;
			d.WeatherEditorMode = 2;
			d.TimeOfDayEditing = true;
			d.SingleSaveMode = false;
			d.SyncState = SyncState.Fresh;
			return d;
		}

		private static IDifficulty PopulateStandard(IDifficulty d)
		{
			d.Name = "Standard";
			d.KeyboardDriving = 1;
			d.FreeCamera = true;
			d.HUD = true;
			d.PaymentModifier = 1f;
			d.BonusTimeModifier = 1f;
			d.MaxCopay = 1000000;
			d.DrivetrainFailures = true;
			d.TractionFailures = true;
			d.BrakeFailures = true;
			d.BrakeWarnings = true;
			d.RemoteHandbrake = true;
			d.AutomaticHandbrakeMode = 1;
			d.AutomaticHeadlightMode = 0;
			d.ResourceConsumptionModifier = 1f;
			d.ResourceCostModifier = 1f;
			d.DamageSensitivityModifier = 1f;
			d.RepairCostModifier = 1f;
			d.CargoDamageCostModifier = 1f;
			d.EnvironmentDamageCostModifier = 1f;
			d.MultiServicing = true;
			d.SleepCooldownInHours = 6;
			d.RemoteSwitchingMode = 2;
			d.RemoteCouplingMode = 2;
			d.VRRemoteDriving = true;
			d.RemoteSignReading = true;
			d.Derailing = true;
			d.SteamStartupMultiplier = 1f;
			d.MainResFillTime = 1f;
			d.RerailMaxCost = 5000;
			d.ClearDerailed = true;
			d.ClearMaxCost = 0;
			d.SummonWorkTrainMaxCost = 10000;
			d.CommsRadioCheatMode = true;
			d.StartingItems = 3;
			d.InventoryItemRespawn = true;
			d.MapBlips = true;
			d.FastTravelMode = 1;
			d.Dash = 2;
			d.CameraDash = true;
			d.DayDurationInMinutes = 120f;
			d.WeatherChangeSpeedModifier = 1f;
			d.Rain = true;
			d.Lightnings = true;
			d.WeatherEditorMode = 1;
			d.TimeOfDayEditing = false;
			d.SingleSaveMode = false;
			d.SyncState = SyncState.Fresh;
			return d;
		}

		private static IDifficulty PopulateStandardSandbox(IDifficulty d)
		{
			d.InitiallyLocked = true;
			d.Name = "Standard Sandbox";
			d.KeyboardDriving = 1;
			d.FreeCamera = true;
			d.HUD = true;
			d.PaymentModifier = 1f;
			d.BonusTimeModifier = 1f;
			d.MaxCopay = 1000000;
			d.DrivetrainFailures = true;
			d.TractionFailures = true;
			d.BrakeFailures = true;
			d.BrakeWarnings = true;
			d.RemoteHandbrake = true;
			d.AutomaticHandbrakeMode = 1;
			d.AutomaticHeadlightMode = 0;
			d.ResourceConsumptionModifier = 1f;
			d.ResourceCostModifier = 1f;
			d.DamageSensitivityModifier = 1f;
			d.RepairCostModifier = 1f;
			d.CargoDamageCostModifier = 1f;
			d.EnvironmentDamageCostModifier = 1f;
			d.MultiServicing = true;
			d.SleepCooldownInHours = 0;
			d.RemoteSwitchingMode = 2;
			d.RemoteCouplingMode = 2;
			d.VRRemoteDriving = true;
			d.RemoteSignReading = true;
			d.Derailing = true;
			d.SteamStartupMultiplier = 1f;
			d.MainResFillTime = 1f;
			d.RerailMaxCost = 5000;
			d.ClearDerailed = true;
			d.ClearMaxCost = 0;
			d.SummonWorkTrainMaxCost = 10000;
			d.CommsRadioCheatMode = true;
			d.StartingItems = 2;
			d.InventoryItemRespawn = true;
			d.MapBlips = true;
			d.FastTravelMode = 0;
			d.Dash = 2;
			d.CameraDash = true;
			d.DayDurationInMinutes = 120f;
			d.WeatherChangeSpeedModifier = 1f;
			d.Rain = true;
			d.Lightnings = true;
			d.WeatherEditorMode = 3;
			d.TimeOfDayEditing = true;
			d.SingleSaveMode = false;
			d.SyncState = SyncState.Fresh;
			return d;
		}

		private static IDifficulty PopulateRealistic(IDifficulty d)
		{
			d.Name = "Realistic";
			d.KeyboardDriving = 1;
			d.FreeCamera = false;
			d.HUD = false;
			d.PaymentModifier = 1.5f;
			d.BonusTimeModifier = 1.5f;
			d.MaxCopay = 5000000;
			d.DrivetrainFailures = true;
			d.TractionFailures = true;
			d.BrakeFailures = true;
			d.BrakeWarnings = false;
			d.RemoteHandbrake = false;
			d.AutomaticHandbrakeMode = 0;
			d.AutomaticHeadlightMode = 0;
			d.ResourceConsumptionModifier = 1f;
			d.ResourceCostModifier = 1f;
			d.DamageSensitivityModifier = 1f;
			d.RepairCostModifier = 1f;
			d.CargoDamageCostModifier = 1f;
			d.EnvironmentDamageCostModifier = 1f;
			d.MultiServicing = true;
			d.SleepCooldownInHours = 8;
			d.RemoteSwitchingMode = 1;
			d.RemoteCouplingMode = 0;
			d.VRRemoteDriving = false;
			d.RemoteSignReading = false;
			d.Derailing = true;
			d.SteamStartupMultiplier = 2f;
			d.MainResFillTime = 5f;
			d.RerailMaxCost = 10000;
			d.ClearDerailed = false;
			d.ClearMaxCost = 5000;
			d.SummonWorkTrainMaxCost = 10000;
			d.CommsRadioCheatMode = true;
			d.StartingItems = 3;
			d.InventoryItemRespawn = false;
			d.MapBlips = false;
			d.FastTravelMode = 1;
			d.Dash = 1;
			d.CameraDash = false;
			d.DayDurationInMinutes = 120f;
			d.WeatherChangeSpeedModifier = 0.75f;
			d.Rain = true;
			d.Lightnings = true;
			d.WeatherEditorMode = 0;
			d.TimeOfDayEditing = false;
			d.SingleSaveMode = true;
			d.SyncState = SyncState.Fresh;
			return d;
		}

		public static IScenario DefaultEmptyTrain(IScenario s)
		{
			if (s.Train == null)
			{
				s.Train = new Train();
			}
			s.RandomTrain = false;
			s.Train.Cars.Clear();
			s.PlayerPosition = default(Vector3);
			s.PlayerRotationY = 0f;
			s.RandomStartingTrackID = false;
			s.StartingTrackID = "";
			s.ReverseTrain = false;
			s.RandomDestinationTrackID = false;
			s.DestinationTrackID = "";
			s.RandomTimeOfDay = false;
			s.TimeOfDay = 660;
			s.RandomCloudsPercentage = false;
			s.CloudsPercentage = 0;
			s.RandomFogPercentage = false;
			s.FogPercentage = 0;
			s.RandomWetnessPercentage = false;
			s.WetnessPercentage = 0;
			s.RandomRainPercentage = false;
			s.RainPercentage = 0;
			s.RandomLightningPercentage = false;
			s.LightningPercentage = 0;
			s.StartingWeatherDuration = 0;
			s.RandomSeed = false;
			s.Seed = "default";
			s.SyncState = SyncState.Fresh;
			return s;
		}

		public static IScenario Default1(IScenario s, AScenarioProvider provider)
		{
			ScenarioEditorStationMapping scenarioEditorStationMapping = provider.GetStationMappings()[0];
			(Vector3 playerPos, float playerRotationY, string trackID, bool reverseTrain) spawnData = scenarioEditorStationMapping.GetSpawnData(scenarioEditorStationMapping.mappings[0].id);
			Vector3 item = spawnData.playerPos;
			float item2 = spawnData.playerRotationY;
			string item3 = spawnData.trackID;
			bool item4 = spawnData.reverseTrain;
			s.Name = "Default Scenario";
			s.RandomTrain = false;
			s.PlayerPosition = item;
			s.PlayerRotationY = item2;
			s.RandomStartingTrackID = false;
			s.StartingTrackID = item3;
			s.ReverseTrain = item4;
			s.RandomDestinationTrackID = false;
			s.DestinationTrackID = "";
			s.RandomTimeOfDay = false;
			s.TimeOfDay = 720;
			s.RandomCloudsPercentage = false;
			s.CloudsPercentage = 0;
			s.RandomFogPercentage = false;
			s.FogPercentage = 0;
			s.RandomWetnessPercentage = false;
			s.WetnessPercentage = 0;
			s.RandomRainPercentage = false;
			s.RainPercentage = 0;
			s.RandomLightningPercentage = false;
			s.LightningPercentage = 0;
			s.StartingWeatherDuration = 0;
			s.RandomSeed = false;
			s.Seed = "default1";
			s.SyncState = SyncState.Fresh;
			return s;
		}

		public static ITrain DefaultTrain(ITrain t)
		{
			t.Name = "Diesel & Tanks";
			t.Cars.AddRange(new Car[6]
			{
				new Car
				{
					Name = "LocoDE2"
				},
				new Car
				{
					Name = "TankBlue"
				},
				new Car
				{
					Name = "TankChrome"
				},
				new Car
				{
					Name = "TankYellow"
				},
				new Car
				{
					Name = "TankYellow"
				},
				new Car
				{
					Name = "TankWhite"
				}
			});
			t.SyncState = SyncState.Fresh;
			return t;
		}
	}
}
