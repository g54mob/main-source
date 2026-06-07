using System.Collections.Generic;
using FractureField.Upgrades;
using Newtonsoft.Json;
using Reactivity;

namespace FractureField.Drones
{
	public class DroneManagerSaveData : IConvertableSaveData
	{
		public List<DroneSaveData> DronesSaveData { get; set; }

		public RBool DronesEnabled { get; set; }

		public List<UpgradeState> UpgradeStates { get; set; }

		public RBool IsHubUnlocked { get; set; }

		public RBool AreDroneHubDescriptionsHidden { get; set; }

		public Dictionary<DroneType, DroneRuleSettings> DroneRules { get; set; }

		[JsonProperty]
		protected Dictionary<DroneType, RBool> IsShowingUpgradesForDroneType { get; set; }

		public List<float[]> SavedSentryDronePositions { get; set; }

		protected DroneManagerSaveData Save(DroneManager data)
		{
			return null;
		}
	}
}
