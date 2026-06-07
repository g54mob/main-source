using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Tools;
using Reactivity;

namespace FractureField.Stats
{
	public class StatsManagerSaveData : IConvertableSaveData
	{
		public RLong TimePlayedMS { get; set; }

		public RFloat TotalDamage { get; set; }

		public RLong ManualHits { get; set; }

		public Dictionary<RockLayerType, RLong> ManualHitsForType { get; set; }

		public Dictionary<ToolType, RLong> ManualHitsForTool { get; set; }

		public RLong ManualMisses { get; set; }

		public RFloat ManualDamage { get; set; }

		public Dictionary<RockLayerType, RFloat> ManualDamageForType { get; set; }

		public RFloat HighestManualDamage { get; set; }

		public RLong DroneHits { get; set; }

		public Dictionary<RockLayerType, RLong> DroneHitsForType { get; set; }

		public RFloat DroneDamage { get; set; }

		public Dictionary<RockLayerType, RFloat> DroneDamageForType { get; set; }

		public RLong BombsUsed { get; set; }

		public RLong BombHits { get; set; }

		public Dictionary<RockLayerType, RLong> BombHitsForType { get; set; }

		public RFloat BombDamage { get; set; }

		public Dictionary<RockLayerType, RFloat> BombDamageForType { get; set; }

		public RLong CriticalHits { get; set; }

		public RLong MegaCriticalHits { get; set; }

		public RLong LayersDestroyed { get; set; }

		public Dictionary<RockLayerType, RLong> LayersDestroyedForType { get; set; }

		public RLong RocksDestroyed { get; set; }

		public Dictionary<RockLayerType, RLong> RocksDestroyedForType { get; set; }

		public RLong SuddenAppearanceCount { get; set; }

		public RLong GeodeClusterCount { get; set; }

		public RLong UpgradesPurchased { get; set; }

		public RLong UpgradesPurchasedByQuarryForeman { get; set; }

		protected StatsManagerSaveData Save(StatsManager data)
		{
			return null;
		}
	}
}
