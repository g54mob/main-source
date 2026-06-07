using System;
using System.ComponentModel;
using DV.Common;

namespace DV.Scenarios.Common
{
	public interface IDifficulty : IScenariosThing, IThing, INotifyPropertyChanged, IEquatable<IDifficulty>
	{
		bool InitiallyLocked { get; set; }

		int KeyboardDriving { get; set; }

		bool FreeCamera { get; set; }

		bool HUD { get; set; }

		float PaymentModifier { get; set; }

		float BonusTimeModifier { get; set; }

		int MaxCopay { get; set; }

		bool DrivetrainFailures { get; set; }

		bool TractionFailures { get; set; }

		bool BrakeFailures { get; set; }

		bool BrakeWarnings { get; set; }

		bool RemoteHandbrake { get; set; }

		int AutomaticHandbrakeMode { get; set; }

		int AutomaticHeadlightMode { get; set; }

		float ResourceConsumptionModifier { get; set; }

		float ResourceCostModifier { get; set; }

		float DamageSensitivityModifier { get; set; }

		float RepairCostModifier { get; set; }

		float CargoDamageCostModifier { get; set; }

		float EnvironmentDamageCostModifier { get; set; }

		bool MultiServicing { get; set; }

		int SleepCooldownInHours { get; set; }

		int RemoteSwitchingMode { get; set; }

		int RemoteCouplingMode { get; set; }

		bool VRRemoteDriving { get; set; }

		bool RemoteSignReading { get; set; }

		bool Derailing { get; set; }

		float SteamStartupMultiplier { get; set; }

		float MainResFillTime { get; set; }

		int RerailMaxCost { get; set; }

		bool ClearDerailed { get; set; }

		int ClearMaxCost { get; set; }

		int SummonWorkTrainMaxCost { get; set; }

		bool CommsRadioCheatMode { get; set; }

		int StartingItems { get; set; }

		bool InventoryItemRespawn { get; set; }

		bool MapBlips { get; set; }

		int FastTravelMode { get; set; }

		int Dash { get; set; }

		bool CameraDash { get; set; }

		float DayDurationInMinutes { get; set; }

		float WeatherChangeSpeedModifier { get; set; }

		bool Rain { get; set; }

		bool Lightnings { get; set; }

		int WeatherEditorMode { get; set; }

		bool TimeOfDayEditing { get; set; }

		bool SingleSaveMode { get; set; }
	}
}
