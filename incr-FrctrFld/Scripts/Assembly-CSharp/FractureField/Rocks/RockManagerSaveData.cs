using System.Collections.Generic;
using FractureField.Upgrades;
using Reactivity;

namespace FractureField.Rocks
{
	public class RockManagerSaveData : IConvertableSaveData
	{
		public long NextRockId { get; set; }

		public Ref<RockLayerType> DroneTargetLayer { get; set; }

		public List<float> PendingSpawnTimers { get; set; }

		public List<RockSaveData> RocksSaveData { get; set; }

		public RDictionary<RockLayerType, RBool> UnlockedLayers { get; set; }

		public List<UpgradeState> UpgradeStates { get; set; }

		public string CurrentQuarryBackgroundId { get; set; }

		public RBool EnableAutoHit { get; set; }

		protected RockManagerSaveData Save(RockManager data)
		{
			return null;
		}
	}
}
