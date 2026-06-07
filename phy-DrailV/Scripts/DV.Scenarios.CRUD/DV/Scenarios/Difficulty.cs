using System;
using System.ComponentModel;
using DV.Common;
using DV.Scenarios.Common;
using Newtonsoft.Json;

namespace DV.Scenarios
{
	public class Difficulty : Thing, IDifficulty, IScenariosThing, IThing, INotifyPropertyChanged, IEquatable<IDifficulty>
	{
		public const string BUILTIN_PRESET_REFERENCE_KEY = "_Difficulty_preset";

		private bool _initiallyLocked;

		private int _keyboardDriving;

		private bool _freeCamera;

		private bool _hud;

		private float _paymentModifier;

		private float _bonusTimeModifier;

		private int _maxCopay;

		private bool _drivetrainFailures;

		private bool _tractionFailures;

		private bool _brakeFailures;

		private bool _brakeWarnings;

		private bool _remoteHandbrake;

		private int _automaticHandbrakeMode;

		private int _automaticHeadlightMode;

		private bool _stuckBrakesWarning;

		private bool _heavyTrainWarning;

		private float _resourceConsumptionModifier;

		private float _resourceCostModifier;

		private float _damageSensitivityModifier;

		private float _repairCostModifier;

		private float _cargoDamageCostModifier;

		private float _environmentDamageCostModifier;

		private bool _multiServicing;

		private int _sleepCooldown;

		private int _remoteSwitchMode;

		private int _remoteCouplingMode;

		private bool _vrRemoteDriving;

		private bool _remoteSignReading;

		private bool _derailing;

		private float _steamStartupMultiplier;

		private float _mainResFillTime;

		private int _rerailMaxCost;

		private bool _clearDerailed;

		private int _clearMaxCost;

		private int _summonWorkTrainMaxCost;

		private bool _commsRadioCheatMode;

		private int _startingItems;

		private bool _inventoryItemRespawn;

		private bool _mapBlips;

		private int _fastTravelMode;

		private int _dash;

		private bool _cameraDash;

		private float _dayDurationInMinutes;

		private float _weatherChangeSpeedModifier;

		private bool _rain;

		private bool _lightnings;

		private int _weatherEditorMode;

		private bool _timeOfDayEditing;

		private int _sessionLimitInMinutes;

		private bool _singleSaveMode;

		public override string FileExtension => "dvdifficulty";

		[JsonIgnore]
		public bool InitiallyLocked
		{
			get
			{
				return _initiallyLocked;
			}
			set
			{
				SetField(ref _initiallyLocked, value, "InitiallyLocked");
			}
		}

		[JsonProperty]
		public int KeyboardDriving
		{
			get
			{
				return _keyboardDriving;
			}
			set
			{
				SetField(ref _keyboardDriving, value, "KeyboardDriving");
			}
		}

		[JsonProperty]
		public bool FreeCamera
		{
			get
			{
				return _freeCamera;
			}
			set
			{
				SetField(ref _freeCamera, value, "FreeCamera");
			}
		}

		[JsonProperty]
		public bool HUD
		{
			get
			{
				return _hud;
			}
			set
			{
				SetField(ref _hud, value, "HUD");
			}
		}

		[JsonProperty]
		public float PaymentModifier
		{
			get
			{
				return _paymentModifier;
			}
			set
			{
				SetField(ref _paymentModifier, value, "PaymentModifier");
			}
		}

		[JsonProperty]
		public float BonusTimeModifier
		{
			get
			{
				return _bonusTimeModifier;
			}
			set
			{
				SetField(ref _bonusTimeModifier, value, "BonusTimeModifier");
			}
		}

		[JsonProperty]
		public int MaxCopay
		{
			get
			{
				return _maxCopay;
			}
			set
			{
				SetField(ref _maxCopay, value, "MaxCopay");
			}
		}

		[JsonProperty]
		public bool DrivetrainFailures
		{
			get
			{
				return _drivetrainFailures;
			}
			set
			{
				SetField(ref _drivetrainFailures, value, "DrivetrainFailures");
			}
		}

		[JsonProperty]
		public bool TractionFailures
		{
			get
			{
				return _tractionFailures;
			}
			set
			{
				SetField(ref _tractionFailures, value, "TractionFailures");
			}
		}

		[JsonProperty]
		public bool BrakeFailures
		{
			get
			{
				return _brakeFailures;
			}
			set
			{
				SetField(ref _brakeFailures, value, "BrakeFailures");
			}
		}

		[JsonProperty]
		public bool BrakeWarnings
		{
			get
			{
				return _brakeWarnings;
			}
			set
			{
				SetField(ref _brakeWarnings, value, "BrakeWarnings");
			}
		}

		[JsonProperty]
		public bool RemoteHandbrake
		{
			get
			{
				return _remoteHandbrake;
			}
			set
			{
				SetField(ref _remoteHandbrake, value, "RemoteHandbrake");
			}
		}

		[JsonProperty]
		public int AutomaticHandbrakeMode
		{
			get
			{
				return _automaticHandbrakeMode;
			}
			set
			{
				SetField(ref _automaticHandbrakeMode, value, "AutomaticHandbrakeMode");
			}
		}

		[JsonProperty]
		public int AutomaticHeadlightMode
		{
			get
			{
				return _automaticHeadlightMode;
			}
			set
			{
				SetField(ref _automaticHeadlightMode, value, "AutomaticHeadlightMode");
			}
		}

		[JsonProperty]
		public bool StuckBrakesWarning
		{
			get
			{
				return _stuckBrakesWarning;
			}
			set
			{
				SetField(ref _stuckBrakesWarning, value, "StuckBrakesWarning");
			}
		}

		[JsonProperty]
		public bool HeavyTrainWarning
		{
			get
			{
				return _heavyTrainWarning;
			}
			set
			{
				SetField(ref _heavyTrainWarning, value, "HeavyTrainWarning");
			}
		}

		[JsonProperty]
		public float ResourceConsumptionModifier
		{
			get
			{
				return _resourceConsumptionModifier;
			}
			set
			{
				SetField(ref _resourceConsumptionModifier, value, "ResourceConsumptionModifier");
			}
		}

		[JsonProperty]
		public float ResourceCostModifier
		{
			get
			{
				return _resourceCostModifier;
			}
			set
			{
				SetField(ref _resourceCostModifier, value, "ResourceCostModifier");
			}
		}

		[JsonProperty]
		public float DamageSensitivityModifier
		{
			get
			{
				return _damageSensitivityModifier;
			}
			set
			{
				SetField(ref _damageSensitivityModifier, value, "DamageSensitivityModifier");
			}
		}

		[JsonProperty]
		public float RepairCostModifier
		{
			get
			{
				return _repairCostModifier;
			}
			set
			{
				SetField(ref _repairCostModifier, value, "RepairCostModifier");
			}
		}

		[JsonProperty]
		public float CargoDamageCostModifier
		{
			get
			{
				return _cargoDamageCostModifier;
			}
			set
			{
				SetField(ref _cargoDamageCostModifier, value, "CargoDamageCostModifier");
			}
		}

		[JsonProperty]
		public float EnvironmentDamageCostModifier
		{
			get
			{
				return _environmentDamageCostModifier;
			}
			set
			{
				SetField(ref _environmentDamageCostModifier, value, "EnvironmentDamageCostModifier");
			}
		}

		[JsonProperty]
		public bool MultiServicing
		{
			get
			{
				return _multiServicing;
			}
			set
			{
				SetField(ref _multiServicing, value, "MultiServicing");
			}
		}

		[JsonProperty]
		public int SleepCooldownInHours
		{
			get
			{
				return _sleepCooldown;
			}
			set
			{
				SetField(ref _sleepCooldown, value, "SleepCooldownInHours");
			}
		}

		[JsonProperty]
		public int RemoteSwitchingMode
		{
			get
			{
				return _remoteSwitchMode;
			}
			set
			{
				SetField(ref _remoteSwitchMode, value, "RemoteSwitchingMode");
			}
		}

		[JsonProperty]
		public int RemoteCouplingMode
		{
			get
			{
				return _remoteCouplingMode;
			}
			set
			{
				SetField(ref _remoteCouplingMode, value, "RemoteCouplingMode");
			}
		}

		[JsonProperty]
		public bool VRRemoteDriving
		{
			get
			{
				return _vrRemoteDriving;
			}
			set
			{
				SetField(ref _vrRemoteDriving, value, "VRRemoteDriving");
			}
		}

		[JsonProperty]
		public bool RemoteSignReading
		{
			get
			{
				return _remoteSignReading;
			}
			set
			{
				SetField(ref _remoteSignReading, value, "RemoteSignReading");
			}
		}

		[JsonProperty]
		public bool Derailing
		{
			get
			{
				return _derailing;
			}
			set
			{
				SetField(ref _derailing, value, "Derailing");
			}
		}

		[JsonProperty]
		public float SteamStartupMultiplier
		{
			get
			{
				return _steamStartupMultiplier;
			}
			set
			{
				SetField(ref _steamStartupMultiplier, value, "SteamStartupMultiplier");
			}
		}

		[JsonProperty]
		public float MainResFillTime
		{
			get
			{
				return _mainResFillTime;
			}
			set
			{
				SetField(ref _mainResFillTime, value, "MainResFillTime");
			}
		}

		[JsonProperty]
		public int RerailMaxCost
		{
			get
			{
				return _rerailMaxCost;
			}
			set
			{
				SetField(ref _rerailMaxCost, value, "RerailMaxCost");
			}
		}

		[JsonProperty]
		public bool ClearDerailed
		{
			get
			{
				return _clearDerailed;
			}
			set
			{
				SetField(ref _clearDerailed, value, "ClearDerailed");
			}
		}

		[JsonProperty]
		public int ClearMaxCost
		{
			get
			{
				return _clearMaxCost;
			}
			set
			{
				SetField(ref _clearMaxCost, value, "ClearMaxCost");
			}
		}

		[JsonProperty]
		public int SummonWorkTrainMaxCost
		{
			get
			{
				return _summonWorkTrainMaxCost;
			}
			set
			{
				SetField(ref _summonWorkTrainMaxCost, value, "SummonWorkTrainMaxCost");
			}
		}

		[JsonProperty]
		public bool CommsRadioCheatMode
		{
			get
			{
				return _commsRadioCheatMode;
			}
			set
			{
				SetField(ref _commsRadioCheatMode, value, "CommsRadioCheatMode");
			}
		}

		[JsonProperty]
		public int StartingItems
		{
			get
			{
				return _startingItems;
			}
			set
			{
				SetField(ref _startingItems, value, "StartingItems");
			}
		}

		[JsonProperty]
		public bool InventoryItemRespawn
		{
			get
			{
				return _inventoryItemRespawn;
			}
			set
			{
				SetField(ref _inventoryItemRespawn, value, "InventoryItemRespawn");
			}
		}

		[JsonProperty]
		public bool MapBlips
		{
			get
			{
				return _mapBlips;
			}
			set
			{
				SetField(ref _mapBlips, value, "MapBlips");
			}
		}

		[JsonProperty]
		public int FastTravelMode
		{
			get
			{
				return _fastTravelMode;
			}
			set
			{
				SetField(ref _fastTravelMode, value, "FastTravelMode");
			}
		}

		[JsonProperty]
		public int Dash
		{
			get
			{
				return _dash;
			}
			set
			{
				SetField(ref _dash, value, "Dash");
			}
		}

		[JsonProperty]
		public bool CameraDash
		{
			get
			{
				return _cameraDash;
			}
			set
			{
				SetField(ref _cameraDash, value, "CameraDash");
			}
		}

		[JsonProperty]
		public float DayDurationInMinutes
		{
			get
			{
				return _dayDurationInMinutes;
			}
			set
			{
				SetField(ref _dayDurationInMinutes, value, "DayDurationInMinutes");
			}
		}

		[JsonProperty]
		public float WeatherChangeSpeedModifier
		{
			get
			{
				return _weatherChangeSpeedModifier;
			}
			set
			{
				SetField(ref _weatherChangeSpeedModifier, value, "WeatherChangeSpeedModifier");
			}
		}

		[JsonProperty]
		public bool Rain
		{
			get
			{
				return _rain;
			}
			set
			{
				SetField(ref _rain, value, "Rain");
			}
		}

		[JsonProperty]
		public bool Lightnings
		{
			get
			{
				return _lightnings;
			}
			set
			{
				SetField(ref _lightnings, value, "Lightnings");
			}
		}

		[JsonProperty]
		public int WeatherEditorMode
		{
			get
			{
				return _weatherEditorMode;
			}
			set
			{
				SetField(ref _weatherEditorMode, value, "WeatherEditorMode");
			}
		}

		[JsonProperty]
		public bool TimeOfDayEditing
		{
			get
			{
				return _timeOfDayEditing;
			}
			set
			{
				SetField(ref _timeOfDayEditing, value, "TimeOfDayEditing");
			}
		}

		[JsonProperty]
		public int SessionLimitInMinutes
		{
			get
			{
				return _sessionLimitInMinutes;
			}
			set
			{
				SetField(ref _sessionLimitInMinutes, value, "SessionLimitInMinutes");
			}
		}

		[JsonProperty]
		public bool SingleSaveMode
		{
			get
			{
				return _singleSaveMode;
			}
			set
			{
				SetField(ref _singleSaveMode, value, "SingleSaveMode");
			}
		}

		public bool Equals(IDifficulty other)
		{
			if (other is Thing)
			{
				return Thing.GetMatchScore(this, other as Thing) == 2;
			}
			return false;
		}

		public Difficulty MakeReadOnly()
		{
			base.IsReadOnly = true;
			return this;
		}
	}
}
