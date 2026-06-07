using System.Collections.Generic;
using FractureField.Rocks;

namespace FractureField.Upgrades
{
	public static class UpgradeIds
	{
		public static class Player
		{
			public const string Fracture = "player_fracture";

			public const string HitSpeed = "player_hit_speed";

			public const string Pierce = "player_pierce";

			public const string CritChance = "player_crit_chance";

			public const string CritMultiplier = "player_crit_multiplier";
		}

		public static class Drones
		{
			public static class Sentry
			{
				public const string Chassis = "drone_sentry_chassis";

				public const string Rangefinder = "drone_sentry_rangefinder";
			}

			public static class Collector
			{
				public const string Chassis = "drone_collector_chassis";

				public const string SiphonRate = "drone_collector_siphon_rate";

				public const string SiphonExtractor = "drone_collector_siphon_extractor";
			}

			public static class Pierce
			{
				public const string Chassis = "drone_pierce_chassis";

				public const string TungstenTip = "drone_pierce_tungsten_tip";
			}

			public static class Supervisor
			{
				public const string Chassis = "drone_supervisor_chassis";

				public const string GetBackToWork = "drone_supervisor_get_back_to_work";
			}

			public static class Shatter
			{
				public const string Chassis = "drone_shatter_chassis";

				public const string BlastRadius = "drone_shatter_blast_radius";
			}

			public static class Boost
			{
				public const string Chassis = "drone_boost_chassis";

				public const string AuraRadius = "drone_boost_aura_radius";

				public const string AuraOfSpeed = "drone_boost_aura_of_speed";

				public const string AuraOfEfficiency = "drone_boost_aura_of_efficiency";

				public const string BuffDuration = "drone_boost_buff_duration";
			}

			public const string Count = "drone_count";

			public const string MoveSpeed = "drone_move_speed";

			public const string HitSpeed = "drone_hit_speed";

			public const string Damage = "drone_damage";
		}

		public static class Bombs
		{
			public const string MaxCharges = "bomb_max_charges";

			public const string Cooldown = "bomb_cooldown";

			public const string Radius = "bomb_radius";

			public const string DamageMultiplier = "bomb_damage_multiplier";
		}

		public static class RockLayers
		{
			public const string WorldFractureUnlock = "rock_layers_world_fracture_unlock";

			public const string RealityShatterUnlock = "rock_layers_reality_shatter_unlock";

			public const string DroneHubUnlock = "rock_layers_drone_hub_unlock";

			public static string GetYieldId(string layerType)
			{
				return null;
			}

			public static string GetManualDamageId(string layerType)
			{
				return null;
			}

			public static string GetCapacityId(string layerType)
			{
				return null;
			}

			public static string GetTransitionChanceId(string layerType)
			{
				return null;
			}

			public static string GetHardnessId(string layerType)
			{
				return null;
			}

			public static string GetLayerPierceId(string layerType)
			{
				return null;
			}

			public static string GetUnlockId(string layerType)
			{
				return null;
			}
		}

		public static class WorldFracture
		{
			public const string FracturedMind = "world_fracture_fractured_mind";

			public const string GeologistsInsight = "world_fracture_geologists_insight";

			public const string QuarryExpansion = "world_fracture_quarry_expansion";

			public const string AnomalousYields = "world_fracture_anomalous_yields";

			public const string GeologicalHaste = "world_fracture_geological_haste";

			public const string PredictiveDrones = "world_fracture_predictive_drones";

			public const string QuarryForeman = "world_fracture_quarry_foreman";

			public const string CoreSaturation = "world_fracture_core_saturation";

			public const string CoreExtraction = "world_fracture_core_extraction";

			public const string DroneSchematics = "world_fracture_drone_schematics";

			public const string DustMultiplier = "world_fracture_dust_multiplier";

			private static readonly Dictionary<RockLayerType, string> _primalIdCache;

			public static string GetPrimalId(RockLayerType rockLayerType)
			{
				return null;
			}
		}

		public static class QuarryForeman
		{
			public const string PlayerUpgrades = "quarry_foreman_player_upgrades";

			public const string DroneUpgrades = "quarry_foreman_drone_upgrades";

			public const string BombUpgrades = "quarry_foreman_bomb_upgrades";

			public const string ToolUpgrades = "quarry_foreman_tool_upgrades";

			public const string DroneHubUpgrades = "quarry_foreman_drone_hub_upgrades";

			public const string QuarryForemanUpgrades = "quarry_foreman_foreman_upgrades";

			public const string WorldFractureUpgrades = "quarry_foreman_world_fracture_upgrades";

			public const string RealityShatterUpgrades = "quarry_foreman_reality_shatter_upgrades";

			public static string GetRockLayerId(RockLayerType rockLayerType)
			{
				return null;
			}
		}

		public static class RealityShatter
		{
			public const string FracturedMindMkII = "reality_shatter_fractured_mind_mk_ii";

			public const string GeologistsInsightMkII = "reality_shatter_geologists_insight_mk_ii";

			public const string SwiftStrikesMkII = "reality_shatter_swift_strikes_mk_ii";

			public const string ExtendedReach = "reality_shatter_extended_reach";

			public const string ToolLegacy = "reality_shatter_tool_legacy";

			public const string LuckyStrikeMkII = "reality_shatter_lucky_strike_mk_ii";

			public const string DevastatingBlowMkII = "reality_shatter_devastating_blow_mk_ii";

			public const string CriticalCascade = "reality_shatter_critical_cascade";

			public const string AdeptMiner = "reality_shatter_adept_miner";

			public const string MuscleMemory = "reality_shatter_muscle_memory";

			public const string DustMultiplierMkII = "reality_shatter_dust_multiplier_mk_ii";

			public const string QuarryExpansionMkII = "reality_shatter_quarry_expansion_mk_ii";

			public const string AnomalousYieldsMkII = "reality_shatter_anomalous_yields_mk_ii";

			public const string GeologicalHasteMkII = "reality_shatter_geological_haste_mk_ii";

			public const string CoreSaturationMkII = "reality_shatter_core_saturation_mk_ii";

			public const string SuddenAppearance = "reality_shatter_sudden_appearance";

			public const string GeodeClusters = "reality_shatter_geode_clusters";

			public const string GeologicalMemory = "reality_shatter_geological_memory";

			public const string Layers1to3RealityPurity = "reality_shatter_layers_1_to_3_reality_purity";

			public const string Layers1to3EfficientProspecting = "reality_shatter_layers_1_to_3_efficient_prospecting";

			public const string Layers1to3GeologicalErosion = "reality_shatter_layers_1_to_3_geological_erosion";

			public const string Layers4to5RealityPurity = "reality_shatter_layers_4_to_5_reality_purity";

			public const string Layers4to5EfficientProspecting = "reality_shatter_layers_4_to_5_efficient_prospecting";

			public const string Layers4to5GeologicalErosion = "reality_shatter_layers_4_to_5_geological_erosion";

			private static readonly Dictionary<RockLayerType, string> _realityPurityIdCache;

			private static readonly Dictionary<RockLayerType, string> _efficientProspectingIdCache;

			private static readonly Dictionary<RockLayerType, string> _geologicalErosionIdCache;

			public const string DroneSchematicsMkII = "reality_shatter_drone_schematics_mk_ii";

			public const string MassProduction = "reality_shatter_mass_production";

			public const string SwarmTactics = "reality_shatter_swarm_tactics";

			public const string PredictiveDronesMkII = "reality_shatter_predictive_drones_mk_ii";

			public const string CoreSynthesis = "reality_shatter_core_synthesis";

			public const string PersistentHub = "reality_shatter_persistent_hub";

			public const string DroneHubForeman = "reality_shatter_drone_hub_foreman";

			public const string DroneMemory = "reality_shatter_drone_memory";

			public const string AdvancedOrdnance = "reality_shatter_advanced_ordnance";

			public const string SurplusMunitions = "reality_shatter_surplus_munitions";

			public const string BombMemory = "reality_shatter_bomb_memory";

			public const string ArmorPiercingWarhead = "reality_shatter_armor_piercing_warhead";

			public const string FocusedBombardment = "reality_shatter_focused_bombardment";

			public const string ExtractorCharges = "reality_shatter_extractor_charges";

			public const string SingularityGain = "reality_shatter_singularity_gain";

			public const string FracturedCosts = "reality_shatter_fractured_costs";

			public const string WorldFractureForeman = "reality_shatter_world_fracture_foreman";

			public const string PrestigeMomentum = "reality_shatter_prestige_momentum";

			public const string PersistentForeman = "reality_shatter_persistent_foreman";

			public const string ForemanSquared = "reality_shatter_foreman_squared";

			public const string ForemanMemory = "reality_shatter_foreman_memory";

			public const string FractureMemory = "reality_shatter_fracture_memory";

			public const string RealityShatterForeman = "reality_shatter_reality_shatter_foreman";

			public static string GetRealityPurityId(RockLayerType layerType)
			{
				return null;
			}

			public static string GetEfficientProspectingId(RockLayerType layerType)
			{
				return null;
			}

			public static string GetGeologicalErosionId(RockLayerType layerType)
			{
				return null;
			}
		}
	}
}
