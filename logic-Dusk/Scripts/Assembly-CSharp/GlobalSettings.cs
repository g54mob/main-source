using System.Collections.Generic;
using UnityEngine;

public static class GlobalSettings
{
	public static class Constants
	{
		public class GameConstants
		{
			public const bool ALIAS_IFMISSING_CREATEFROM_RESOURCE = true;

			public const bool AUTOSAVE_GALAXYSEED = true;

			public const bool PERSIST_SYS_OBJ_DATA = true;

			public const bool DEVMODE_GALAXY = false;

			public const bool DEVMODE_PERSIST = false;

			public const bool CLEAR_AS_NEW_INSTALL = true;

			public const float CURSOR_BLINK = 0.2f;

			public const string RICHTEXTCOLOR_BENEFIT = "#8ed0ff";

			public const string RICHTEXTCOLOR_WARNING = "#FFF000";

			public const string RICHTEXTCOLOR_WARNING_SERIOUS = "#ff9600";

			public const string RICHTEXTCOLOR_ERROR = "#FF0000";

			public const string RICHTEXTCOLOR_AI = "#62ddf9";

			public const string RICHTEXTCOLOR_CREDITS_NAME = "#f0ff00";

			public const string RICHTEXTCOLOR_CREDITS_INPUT = "#3f9eef";

			public const string RICHTEXTCOLOR_LOG_HEADER = "#1aff11";

			public const string RICHTEXTCOLOR_LOG_BODY = "#1aff11";

			public const string RICHTEXTCOLOR_LOG_END_CURRENTRUN = "#71b4ff";

			public const string RICHTEXTCOLOR_LOG_END_OTHERRUN = "#1aff11";
		}

		public class UniverseConstants
		{
			public const int BUILD_NUMBEROF_GALAXIES = 10;

			public const int BUILD_NUMBEROF_GALAXIES_WEEKLY_CH = 1;

			public const int BUILD_BREAKDOWN_DEPTH = 3;

			public const int BUILD_BREAKDOWN_CHANCEOF = 2;

			public const int BUILD_DISTANCE_SHORT = 100;

			public const int BUILD_DISTANCE_LONG = 250;

			public const int BUILD_FACTOR_BIAS = 10;

			public const int BUILD_MAX_SHORT = 3;

			public const int BUILD_MAX_LONG = 1;

			public const int BUILD_FACTOR_REDUCECHANCEOF_LONG = 4;

			public const bool CONSTELLATION_ZOOM_TO_EXTENT = true;

			public const float CONSTELLATION_ZOOM_TO_EXTENT_DEFAULT = 200f;

			public const float CONSTELLATION_ZOOM_TO_EXTENT_MIN = 100f;

			public const float CONSTELLATION_ZOOM_TO_EXTENT_MAX = 1000f;

			public const bool CONSTELLATION_ALLOW_ZOOM = true;
		}

		public class GalaxyConstants
		{
			public const int LowDensityDistanceMin = 225;

			public const int HighDensityDistanceMin = 28;

			public const int ObjectTypeMin = 2;

			public const int ObjectTypeMax = 20;

			public const int MaxNumberOfNodes = 300;

			public const float OrbitLineOffset = 10f;

			public const int DERELECTSTATION_CHANCEOF_STATION_DOMINANCE = 20;

			public const float DERELECTSTATION_FACTOROF_DOMINATE_MIN = 0.7f;

			public const float DERELECTSTATION_FACTOROF_DOMINATE_MAX = 1f;

			public const float MOTHERSHIP_TRAVEL_DELAY_MIN = 0.1f;

			public const float MOTHERSHIP_TRAVEL_DELAY_MAX = 0.11f;
		}

		public class DroneConstants
		{
			public const int CHANCEOF_SPECIAL_MODEL = 20;

			public const int TRAIT_CHANCEOF_VEER_ONDAMAGE = 40;

			public const int TRAIT_CHANCEOF_VEER_LOOTABLEDRONE = 0;

			public const float TRAIT_DAMAGETHRESHOLD = 40f;

			public const float TRAIT_VEER_MIN = 0.5f;

			public const float TRAIT_VEER_MAX = 3f;

			public const float TRAIT_VEER_WITHPERM_MIN = 2f;

			public const float TRAIT_VEER_WITHPERM_MAX = 3f;

			public const int TRAIT_CHANCEOF_VEERPERM = 20;

			public const float TRAIT_VEERPERM_MIN = 0.5f;

			public const float TRAIT_VEERPERM_MAX = 1f;

			public const int TRAIT_CHANCEOF_PITCH = 50;

			public const float TRAIT_PITCH_MIN = -0.2f;

			public const float TRAIT_PITCH_MAX = 0.1f;

			public const float GLITCH_DAMAGETHRESHOLD = 25f;

			public const int GLITCH_CHANCEOF_ONDAMAGE = 30;

			public const float STATIC_DAMAGE_TIMER = 0.25f;

			public const float STATIC_DAMAGE_STRENGTH_FACTOR = 0.01f;

			public const int HUDSTATIC_CHANCEOF_NOISE = 20;

			public const float HUDSTATIC_TESTFOR_NOISE_LENGTH_MIN = 55f;

			public const float HUDSTATIC_TESTFOR_NOISE_LENGTH_MAX = 65f;

			public const float HUDSTATIC_FACTOR_STRENGTH_NOISE_MIN = 0.6f;

			public const float HUDSTATIC_FACTOR_STRENGTH_NOISE_MAX = 1f;

			public const float HUDSTATIC_NOISE_TIMER_MIN = 1f;

			public const float HUDSTATIC_NOISE_TIMER_MAX = 3f;

			public const float HUDSTATIC_NOISE_SNAPBACK_LENGTH = 0.5f;

			public const float JITTER_THRESHOLD_MIN_PITCH = 4f;

			public const float JITTER_THRESHOLD_MAX_PITCH = 16f;

			public const float JITTER_THRESHOLD_MIN_ROLL = 4f;

			public const float JITTER_THRESHOLD_MAX_ROLL = 16f;

			public const float JITTER_THRESHOLD_MIN_YAW = 4f;

			public const float JITTER_THRESHOLD_MAX_YAW = 16f;

			public const float JITTER_TIME_LENGTH = 0.5f;

			public const float JITTER_DELAYBETWEEN_MOVE_PITCH = 0.2f;

			public const float JITTER_DELAYBETWEEN_MOVE_ROLL = 0.1f;

			public const float JITTER_DELAYBETWEEN_MOVE_YAW = 0.2f;

			public const int TRON_CHANCEOF_20 = 50;

			public const float DEADDISABLED_CHANCEOF_MICSTATIC_MIN = 1f;

			public const float DEADDISABLED_CHANCEOF_MICSTATIC_MAX = 3f;
		}

		public class DungeonConstants
		{
			public const int TILE_CHANCEOF_MISSING = 0;

			public const int CONSOLE_MAX_LINES = 50;

			public const float ENV_DEBRIS_MAX_PER_SQR_HQ = 0.5f;

			public const float ENV_DEBRIS_MAX_PER_SQR_MQ = 0.25f;

			public const float ENV_DEBRIS_MAX_PER_SQR_LQ = 0.1f;

			public const float ENV_LARGEOBJ_MAX_PER_SQR_HQ = 0.2f;

			public const float ENV_LARGEOBJ_MAX_PER_SQR_MQ = 0.1f;

			public const float ENV_LARGEOBJ_MAX_PER_SQR_LQ = 0.05f;

			public const float SV_DISCOVERED_BLINK_EXPIRES = 5f;

			public const int DV_OVERLAY_CHANCEOF_LAG = 100;

			public const float DV_OVERLAY_LAG_MIN = 0.1f;

			public const float DV_OVERLAY_LAG_MAX = 0.9f;

			public const int DEFAULT_MAX_SHIP_QTY = 50;

			public const int DEFAULT_MAX_PFUEL_QTY = 6;

			public const int CHANCEOF_PERM_SHIP_UPGRADE = 40;

			public const float FACTOR_AMBIENTSOUND_INROOM = 0.33f;

			public const int QUARANTINE_SLIME_WEIGHT = 10;

			public const int QUARANTINE_BRUTE_WEIGHT = 10;

			public const int ORACLEAI_NONSLIME_WEIGHT = 10;

			public const float ORACLEAI_RADIATION_FACTOR = 0.5f;
		}

		public class TradingPostConstants
		{
			public const int RATIONS_MIN = 5;

			public const int RATIONS_MAX = 20;

			public const int RATIONS_PER_UPGRADE = 3;

			public const int DRONE_UPGRADES_MIN = 2;

			public const int DRONE_UPGRADES_MAX = 6;

			public const int SHIP_UPGRADES_MIN = 0;

			public const int SHIP_UPGRADES_MAX = 2;

			public const int FUEL_PROP_MIN = 0;

			public const int FUEL_PROP_MAX = 2;

			public const int FUEL_JUMP_MIN = 0;

			public const int FUEL_JUMP_MAX = 2;

			public const int FUEL_PROP_SCRAP = 5;

			public const int FUEL_JUMP_SCRAP = 15;

			public const int FUEL_JUMP_SCRAP_CRAFT = 20;

			public const int INITIAL_MISSION_AGE_MIN = 0;

			public const int INITIAL_MISSION_AGE_MAX = 2;

			public const int CHANCEOF_0QTY_UPGRADE = 20;
		}

		public class DroneUpgradeConstants
		{
			public const bool DRONE_UPGRADE_USE_BLACKLIST = true;

			public const int DRONE_UPGRADE_ERROR_MIN_MISSIONS = 0;

			public const int DRONE_UPGRADE_ERROR_MAX_MISSIONS = 0;

			public const int DRONE_UPGRADE_ERROR_MIN_MISSIONS_POSTREPAIR = 0;

			public const int DRONE_UPGRADE_ERROR_MAX_MISSIONS_POSTREPAIR = 0;

			public const float DRONE_UPGRADE_ERROR_MIN_TIME = 0f;

			public const float DRONE_UPGRADE_ERROR_MAX_TIME = 0f;

			public const float DRONE_UPGRADE_BREAK_MIN_TIME_DELTA = 120f;

			public const float DRONE_UPGRADE_BREAK_MAX_TIME_DELTA = 180f;

			public const float DRONE_UPGRADE_ERROR_MISSIONS_GRACE_PERIOD = 2f;

			public const int DRONE_UPGRADE_DEFAULT_BREAK_CHANCE = 10;

			public const int DRONE_UPGRADE_BREAK_CHANCE_ONDEAD_INSTALL = 0;

			public const int DRONE_UPGRADE_BREAK_CHANCE_ONLIVE_INSTALL = 0;

			public const float BREAK_INITIAL_PROBABILITY = 0f;

			public const float BREAK_MISSIONINCREASE_MIN = 3f;

			public const float BREAK_MISSIONINCREASE_MAX = 6f;

			public const float BREAK_BASELINE_DEFICIENT = 15f;

			public const float BREAK_BASELINE_CRITICAL = 25f;

			public const float BREAK_NURSERY_FACTOR = 0.5f;

			public const float BREAK_FIRSTSYSTEM_FACTOR = 0.75f;

			public const float BREAK_SU_INITIAL_PROBABILITY = 0f;

			public const float BREAK_SU_MISSIONINCREASE_MIN = 3f;

			public const float BREAK_SU_MISSIONINCREASE_MAX = 6f;

			public const float BREAK_SU_BASELINE_DEFICIENT = 15f;

			public const float BREAK_SU_BASELINE_CRITICAL = 25f;

			public const float BREAK_SU_NURSERY_FACTOR = 0.5f;

			public const float BREAK_SU_FIRSTSYSTEM_FACTOR = 0.75f;

			public const float BREAK_SLOT_INITIAL_PROBABILITY = 0f;

			public const float BREAK_SLOT_MISSIONINCREASE_MIN = 1.5f;

			public const float BREAK_SLOT_MISSIONINCREASE_MAX = 3f;

			public const float BREAK_SLOT_BASELINE_DEFICIENT = 15f;

			public const float BREAK_SLOT_BASELINE_CRITICAL = 25f;

			public const float BREAK_SLOT_NURSERY_FACTOR = 0.5f;

			public const float BREAK_SLOT_FIRSTSYSTEM_FACTOR = 0.75f;

			public const int INITIAL_MISSION_AGE_LOOTABLE_MIN = 0;

			public const int INITIAL_MISSION_AGE_LOOTABLE_MAX = 4;

			public const int INITIAL_MISSION_SU_AGE_LOOTABLE_MIN = 0;

			public const int INITIAL_MISSION_SU_AGE_LOOTABLE_MAX = 4;

			public const int INITIAL_MISSION_SLOT_AGE_LOOTABLE_MIN = 0;

			public const int INITIAL_MISSION_SLOT_AGE_LOOTABLE_MAX = 4;
		}

		public class SoundConstants
		{
			public const int STATIC_TIMETILLNEXT_RANDOM_MIN = 1000;

			public const int STATIC_TIMETILLNEXT_RANDOM_MAX = 5000;
		}

		public static class SpawnConstants
		{
			public const bool USE_RANDOM_PLACEMENT = true;

			public const int THRESHOLD_BEFORE_RANDOM = 2;

			public const int ADJACENT_DIST = 50;

			public const int HOP_DIST = 14;

			public const int HOP_MIN = 3;

			public const int STARTUP_MIN_DERELICTS = 2;

			public const int STARTUP_MIN_RATIONS_IN_SYSTEM = 10;

			public const bool STARTUP_DIFFICULTY_ALLOW_EXPAND_RANGE = true;

			public const float STARTUP_DIFFICULTY_RANGE_MIN = 0f;

			public const float STARTUP_DIFFICULTY_RANGE_MAX = 0.65f;

			public const float STARTUP_DIFFICULTY_HARD_RANGE_MIN = 0.45f;

			public const float STARTUP_DIFFICULTY_HARD_RANGE_MAX = 1f;

			public const int STARTUP_DIFFICULTY_MIN_NODES = 3;

			public const float STARTUP_GALAXY_AVG_DIFFICULTY = 0.7f;
		}

		public static class LogConstants
		{
			public const int SCAV_CHANCEOF_LOG = 100;

			public const int SCAV_CHANCEOF_LOG_BAKED = 30;

			public const int GENERAL_CHANCEOF_COLOR = 25;

			public const int MEDICAL_CHANCEOF_CORRUPTED = 50;

			public const int MEDICAL_CHANCEOF_CORRUPTED_OUTPOST = 20;

			public const int MEDICAL_CHANCEOF_PRIORITY = 60;

			public const int MILITARY_CHANCEOF_CORRUPTED = 50;

			public const int MILITARY_CHANCEOF_CORRUPTED_OUTPOST = 20;

			public const int MILITARY_CHANCEOF_PRIORITY = 60;

			public const int GREYGOO_CHANCEOF_CORRUPTED = 50;

			public const int GREYGOO_CHANCEOF_CORRUPTED_OUTPOST = 20;

			public const int GREYGOO_CHANCEOF_PRIORITY = 60;

			public const int COSMIC_CHANCEOF_CORRUPTED = 50;

			public const int COSMIC_CHANCEOF_CORRUPTED_OUTPOST = 20;

			public const int COSMIC_CHANCEOF_PRIORITY = 60;

			public const int SINGULATIRY_CHANCEOF_CORRUPTED = 50;

			public const int SINGULATIRY_CHANCEOF_CORRUPTED_OUTPOST = 20;

			public const int SINGULATIRY_CHANCEOF_PRIORITY = 60;
		}

		public static class SubSystemConstants
		{
			public const int START_SHIP_UPGRADE_SLOTS = 2;

			public const int FILLEDSLOT_CHANCEOF_WORKING_UPGRADE = 75;

			public const int FILLEDSLOT_CHANCEOF_2NDWORKING_UPGRADE = 10;

			public const int FILLEDSLOT_CHANCE_WORKING_UPGRADE_ISLOOSE = 60;

			public const int EMPTYSLOT_CHANCEOF_BROKEN_UPGRADE = 25;

			public const int EMPTYSLOT_CHANCE_BROKEN_UPGRADE_ISLOOSE = 50;

			public const int INSTALLED_SUBSYS_UPGRADE_BREAK_MISSIONS_MIN = 4;

			public const int INSTALLED_SUBSYS_UPGRADE_BREAK_MISSIONS_MAX = 12;

			public const int INSTALLED_SUBSYS_UPGRADE_BREAK_DAYSTRAVELED_MIN = 0;

			public const int INSTALLED_SUBSYS_UPGRADE_BREAK_DAYSTRAVELED_MAX = 1;
		}

		public static class FuelConstants
		{
			public const float DISPLAY_DELAY = 1f;
		}

		public static class UnlockConstants
		{
			public static int NUMBEROF_SYSJUMP_FOR_ENEMYTYPE = 2;
		}

		public static class DungeonsConsts
		{
			public const int MIN_AGE = 0;

			public const int MAX_AGE = 500;
		}

		public static class EnemyConstants
		{
			public const bool PATROLBOT_ENABLE_LIGHT = true;
		}

		public static class BuilderConstants
		{
			public const int SUBSYS_RATIO_MIN = 10;

			public const int SUBSYS_RATIO_MAX = 4;

			public const int SUBSYS_CHANCEOF_SAMEROOM = 10;

			public const int SUBSYS_CHANCEOF_EXCLUDESAMEROOM = 3;
		}

		public static class CameraConstants
		{
			public const float SV_PAN_SPEED = 9f;

			public const float SV_PAN_MAX = 15f;

			public const bool SV_PAN_INVERT = false;

			public const float NOISE_NORMAL_MIN = 0.1f;

			public const float NOISE_NORMAL_MAX = 0.2f;

			public const float NOISE_LOW_MIN = 0.05f;

			public const float NOISE_LOW_MAX = 0.1f;
		}

		public static class HullIntegrity
		{
			public const float GOOD_PROBABILITY = 0.1f;

			public const float GOOD_CHECK_FREQUENCY = 4350f;

			public const float GOOD_EVENT_COOLDOWN = 500f;

			public const float MEDIUM_PROBABILITY = 0.25f;

			public const float MEDIUM_CHECK_FREQUENCY = 350f;

			public const float MEDIUM_EVENT_COOLDOWN = 500f;

			public const float BAD_PROBABILITY = 0.45f;

			public const float BAD_CHECK_FREQUENCY = 350f;

			public const float BAD_EVENT_COOLDOWN = 500f;
		}

		public static class TransporterConstants
		{
			public const float HIGH_INTERFERENCE_PROBABILITY = 0.1f;

			public const float MEDIUM_INTERFERENCE_PROBABILITY = 0.25f;

			public const float LOW_INTERFERENCE_PROBABILITY = 0.5f;
		}

		public static class StealthConstants
		{
			public const float STEALTH_SLOW_RATE_CONSUMPTION = 2.4f;

			public const float STEALTH_SLOW_RATE_RECHARGE = 3f;

			public const float STEALTH_FAST_RATE_CONSUMPTION = 6.5f;

			public const float STEALTH_FAST_RATE_RECHARGE = 10f;

			public const float STEALTH_LOW_FLASH_DELAY = 2f;

			public const float STEALTH_LOW_FLASH_LENGTH = 0.25f;
		}

		public static class PrototypeConstants
		{
			public const int PRESET_RANDOM_UPGRADE_CHANGE = 2;
		}

		public class CombatConstants
		{
			public const float DEFAULT_HITPOINTS = 100f;

			public const int HITPOINTS_DEVIATION_STEP_SIZE = 10;

			public const int HITPOINTS_RANDOM_DEVIATION = 30;

			public const float TOTAL_DRONE_HITPOINTS_EVER = 500f;

			public const int CHANCEOF_UNKNOWN_INFESTATION_COUNT = 5;

			public const float DOOR_HITPOINTS = 60f;

			public const float SWARM_DOOR_ATTACK_SPEED = 1f;

			public const float SWARM_DOOR_ATTACK_DAMAGE = 1f;

			public const float SWARM_HITPOINTS = 30f;

			public const float SWARM_ATTACK_SPEED = 2f;

			public const float SWARM_ATTACK_DAMAGE = 2f;

			public const float SWARM_ATTACK_RADIUS = 2f;

			public const float BRUTE_HITPOINTS = 200f;

			public const float BRUTE_ATTACK_SPEED = 3.5f;

			public const float BRUTE_ATTACK_DAMAGE = 0f;

			public const float BRUTE_ATTACK_RADIUS = 3f;

			public const float BRUTE_CHARGE_SPEED = 7f;

			public const float BRUTE_CHARGE_ATTACK_DAMAGE = 90f;

			public const float BRUTE_CHARGE_COOLDOWN = 5f;

			public const float BRUTE_CHARGE_SELFSTUN_DURATION = 5f;

			public const float SLIME_HITPOINTS = 200f;

			public const float SLIME_ATTACK_SPEED = 1f;

			public const float SLIME_ATTACK_DAMAGE = 10f;

			public const float SLIME_ATTACK_RADIUS = 0.1f;

			public const float PATROLBOT_HITPOINTS = 100f;

			public const float PATROLBOT_ATTACK_SPEED = 0.15f;

			public const float PATROLBOT_ATTACK_DAMAGE = 3f;

			public const float PATROLBOT_ATTACK_RADIUS = 3.5f;

			public const float VENT_SPAWN_DELAY_MIN = 150f;

			public const float VENT_SPAWN_DELAY_MAX = 600f;

			public const int VENT_SPAWN_SWARMENEMY_MIN = 20;

			public const int VENT_SPAWN_SWARMENEMY_MAX = 20;

			public const int VENT_MAX_ENEMIES = 20;

			public const float LURE_HITPOINTS = 1000f;

			public const float SENSOR_HITPOINTS = 100f;

			public const float PROBE_HITPOINTS = 100f;

			public const float PROBE_MODDED_HITPOINTS = 700f;

			public const float GENERATOR_HITPOINTS = 100f;

			public const float TERMINAL_HITPOINTS = 100f;

			public const float DEFENSE_HITPOINTS = 100f;

			public const float FUELACCESS_HITPOINTS = 100f;

			public const float CHANCE_ROOMITEM_EXPLODE_DAMAGE = 50f;

			public const float CHANCE_ROOMITEM_STUN_DAMAGE = 75f;

			public const float CHANCE_STUNBOMB_AFFECTS_FRIENDLY = 1f;

			public const int GATLING_ACCURACY = 95;

			public const int TURRET_ACCURACY = 95;

			public const float DURATION_STUNBOMB_MIN_ENEMY = 20f;

			public const float DURATION_STUNBOMB_MAX_ENEMY = 35f;

			public const float DURATION_STUNBOMB_MIN_ROOMITEM = 10f;

			public const float DURATION_STUNBOMB_MAX_ROOMITEM = 12f;

			public const float DURATION_STUNBOMB_MIN_FRIENDLY = 5f;

			public const float DURATION_STUNBOMB_MAX_FRIENDLY = 12f;

			public const float DIST_MINE_TRIGGER = 2f;

			public const float DIST_MINE_SAFETY = 0.5f;

			public const float DIST_STUN_TRIGGER = 2f;

			public const float DIST_STUN_SAFETY = 1f;

			public const float DELAY_MINE_ARM_POSTTRIGGER = 0.5f;

			public const float DELAY_STUN_ARM_POSTTRIGGER = 0.5f;

			public const float CHANCE_TRAP_AFFECTS_ENEMY = 1f;

			public const float CHANCE_TRAP_AFFECTS_FRIENDLY = 1f;

			public const float SLIME_SNARE_AFFECT = 0.3f;

			public const float SLIME_SNARE_DURATION = 2f;
		}

		public class CannonConstants
		{
			public const float IMPACT_DAMAGE_MIN = 1f;

			public const float IMPACT_DAMAGE_MAX = 1f;

			public const int CHANCEOF_DOOR_BREAK = 50;

			public const int CHANCEOF_DOOR_OPEN_ONBREAK = 30;
		}

		public class CollectorConstants
		{
			public const int CHANCEOF_COLLECT = 30;
		}

		public class DecontaminatorConstants
		{
			public const float DELAY_START = 1f;

			public const float DELAY_COMPLETE = 5f;
		}

		public class OverloadConstants
		{
			public const float DAMAGE_MIN = 80f;

			public const float DAMAGE_MAX = 150f;
		}

		public class AirlockConstants
		{
			public const int NUMBEROF_ADDITIONAL_AIRLOCKS_MAX = 5;

			public const int DAMAGE_COMBAT_TARGET_CHANCEOF = 3;

			public const float DAMAGE_COMBAT_TARGET_MIN = 100f;

			public const float DAMAGE_COMBAT_TARGET_MAX = 101f;

			public const float DELAY_AFFECT_ADJACENT_ROOM = 5f;

			public const float DELAY_UNTIL_RADIATION_LEAK_MIN = 5f;

			public const float DELAY_UNTIL_RADIATION_LEAK_MAX = 10f;

			public const float DELAY_UNTIL_RADIATION_VENTED_MIN = 2f;

			public const float DELAY_UNTIL_RADIATION_VENTED_MAX = 5f;

			public const float INDICATOR_BLINK_TIME = 2f;

			public const int CHANCEOF_DEPRESSURIZED_DOORBREAKING = 20;
		}

		public class AiConstants
		{
			public const float ADJACENT_ROOM_ATTACK_RANGE = 3f;

			public const int SWARM_WANDERYNESS = 50;

			public const float SWARM_WANDER_CHECK_PERIOD = 10f;

			public const int SWARM_CHANCEOF_MED_FROMVENT = 30;

			public const int SWARM_CHANCEOF_MED_ATSTART = 10;

			public const int ENEMIES_PER_SWARM_LARGE = 20;

			public const int ENEMIES_PER_SWARM_MED = 10;

			public const int BRUTE_WANDERYNESS = 65;

			public const float BRUTE_WANDER_CHECK_PERIOD = 10f;

			public const int PATROLBOT_WANDERYNESS = 85;

			public const float PATROLBOT_WANDER_CHECK_PERIOD = 5f;

			public const float DRONE_MOVING_DOOR_CHEW_TIME = 5f;

			public const int DRONE_MOVING_DOOR_CHEW_CHANCE = 4;

			public const float DRONE_IDLE_DOOR_CHEW_TIME = 60f;

			public const int DRONE_IDLE_DOOR_CHEW_CHANCE = 5;

			public const float LURE_DOOR_CHEW_TIME = 20f;

			public const int LURE_DOOR_CHEW_CHANCE = 20;

			public const float GENERAL_DOOR_CHEW_TIME = 180f;

			public const int GENERAL_DOOR_CHEW_CHANCE = 4;

			public const float CHEW_TIMETILL_FORGETDOOR_AFTER_PASSTHROUGH = 5f;

			public const int SLIME_SPAWN_NEAR_DRONE_CHANCE = 40;

			public const int SLIME_SPAWN_EMPTY_ROOM_CHANCE = 20;

			public const int SLIME_RESPAWN_CHANCE = 65;

			public const float SLIME_SPAWN_CHECK_DELAY = 120f;

			public const float SLIME_GENERAL_REPLICATE_CHECK_DELAY = 20f;

			public const float SLIME_COMBAT_REPLICATE_DELAY = 20f;

			public const int SLIME_GENERAL_REPLICATE_CHANCE = 100;

			public const float SLIME_HIBERNATE_TIME = 20f;

			public const float OBJECTIVE_TIMEOUT = 4f;

			public const float OBJECTIVE_RESET_DISTANCE = 1f;

			public const float DEFAULT_CURIOUS_PAUSE_TIME = 2f;

			public const float DEFAULT_STEALTH_REMEMBER_TIME = 10f;

			public const float DEFAULT_STEALTH_MEMORY_DISTANCE = 2.5f;

			public const int DBF_OWNED_MISSION_START_WHINE_CHANCE = 30;

			public const int DBF_OWNED_SOUND_RESPOND_BARK_CHANCE = 25;

			public const int DBF_OWNED_DRONES_DEAD_WHINE_CHANCE = 75;

			public const float DBF_OWNED_NON_BARK_SOUND_INTERVAL = 420f;

			public const int DBF_OWNED_NON_BARK_SOUND_CHANCE = 30;

			public const float DBF_GALAXYMAP_OWNED_SOUND_INTERVAL = 20f;

			public const int DBF_GALAXYMAP_OWNED_SOUND_CHANCE = 50;

			public const int DBF_SPAWN_MIN_MISSIONS = 25;

			public const int DBF_SPAWN_CHANCE = 5;
		}

		public class BoardingVesselConstants
		{
			public const float TIME_FADE = 1f;

			public const float TIME_TRAVEL = 3f;
		}

		public class GameEventConstants
		{
			public const float CLOSECMD_FAIL_PROBABILITY = 0.05f;

			public const float CLOSECMD_FAIL_CHECKFREQ = 600f;

			public const float DOOR_FAIL_PROBABILITY = 0.3f;

			public const float DOOR_FAIL_CHECKFREQ = 225f;

			public const float DOOR_FAIL_COOLDOWN = 500f;

			public const float AIRLOCK_FAIL_PROBABILITY = 0.25f;

			public const float AIRLOCK_FAIL_CHECKFREQ = 410f;

			public const float AIRLOCK_FAIL_COOLDOWN = 500f;

			public const float AIRLOCK_FAIL_RESTARTTIME_MIN = 40f;

			public const float AIRLOCK_FAIL_RESTARTTIME_MAX = 60f;

			public const float ASTEROID_PROBABILITY = 0.1f;

			public const float ASTEROID_CHECKFREQ = 120f;

			public const float ASTEROID_COOLDOWN = 480f;

			public const float ASTEROID_IMPACT_TIME_MIN = 90f;

			public const float ASTEROID_IMPACT_TIME_MAX = 480f;

			public const float ASTEROID_IMPACT_TIME_WARNING = 60f;

			public const float ASTEROID_IMPACT_DAMAGE_MIN = 1f;

			public const float ASTEROID_IMPACT_DAMAGE_MAX = 1f;

			public const float ASTEROID_IMPACT_CHANCE_MIN = 0.1f;

			public const float ASTEROID_IMPACT_CHANCE_MAX = 0.8f;

			public const float ASTEROID_IMPACT_CALC_ADJ_MIN = -0.25f;

			public const float ASTEROID_IMPACT_CALC_ADJ_MAX = 0.25f;

			public const float ASTEROID_IMPACT_CHANCE_ADDITION_MIN = 0f;

			public const float ASTEROID_IMPACT_CHANCE_ADDITION_MAX = 0.9f;

			public const int ASTEROID_ROOM_MISS_CHANCE = 100;

			public const int ASTEROID_ROOM_POTHIT_MIN = 0;

			public const int ASTEROID_ROOM_POTHIT_MAX = 4;

			public const int ASTEROID_CHANCEOF_DOOR_BREAK = 50;

			public const int ASTEROID_CHANCEOF_DOOR_OPEN_ONBREAK = 25;

			public const int ASTEROID_CHANCEOF_ONLY_RADIATION = 30;

			public const float RADIATION_GOOD_POSSIBLE_ROOM_MIN = 0f;

			public const float RADIATION_GOOD_POSSIBLE_ROOM_MAX = 0.2f;

			public const float RADIATION_GOOD_CHANCEOF_YELLOW = 0.8f;

			public const int RADIATION_GOOD_CHANCEOF_PICK_YELLOW = 30;

			public const float RADIATION_MED_POSSIBLE_ROOM_MIN = 0.3f;

			public const float RADIATION_MED_POSSIBLE_ROOM_MAX = 0.5f;

			public const float RADIATION_MED_CHANCEOF_YELLOW = 0.5f;

			public const int RADIATION_MED_CHANCEOF_PICK_YELLOW = 20;

			public const float RADIATION_POOR_POSSIBLE_ROOM_MIN = 0.3f;

			public const float RADIATION_POOR_POSSIBLE_ROOM_MAX = 0.8f;

			public const float RADIATION_POOR_CHANCEOF_YELLOW = 0.25f;

			public const int RADIATION_POOR_CHANCEOF_PICK_YELLOW = 20;

			public const float RADIATION_NATURAL_TIMETIL_MOTHERSHIPCREAK = 4f;

			public const float RADIATION_NATURAL_DELAY_MIN = 15f;

			public const float RADIATION_NATURAL_DELAY_MAX = 30f;

			public const int RADIATION_NATURAL_CHANCEOF_CANCEL = 10;
		}

		public static class ShaderGlitchEffectsConstants
		{
			public const float RADIATION_COMPRESSION_FADE = 0.5f;

			public const float GLITCH_ONDAMAGE_STRENGTH_X = 0.01f;

			public const float GLITCH_ONDAMAGE_STRENGTH_Y = 0.01f;
		}

		public static class TerminalConstants
		{
			public const int CHANCEOF_MORETHANONE_COMMAND = 30;

			public const int CHANCEOF_ALL_COMMANDS = 30;

			public const int CHANCEOF_START_BROKEN = 10;
		}

		public static class VideoSignalConstants
		{
			public const float DRONE_TIME_TIL_FAIL_MIN_INITIAL = 1200f;

			public const float DRONE_TIME_TIL_FAIL_MAX_INITIAL = 6000f;

			public const float DRONE_TIME_TIL_FAIL_MIN_REPEAT = 900f;

			public const float DRONE_TIME_TIL_FAIL_MAX_REPEAT = 1800f;

			public const float DRONE_FAIL_DURATION_MIN_INITIAL = 15f;

			public const float DRONE_FAIL_DURATION_MAX_INITIAL = 30f;

			public const float SHIP_TIME_TIL_FAIL_MIN_INITIAL = 3000f;

			public const float SHIP_TIME_TIL_FAIL_MAX_INITIAL = 7200f;

			public const float SHIP_TIME_TIL_FAIL_MIN_REPEAT = 1200f;

			public const float SHIP_TIME_TIL_FAIL_MAX_REPEAT = 2400f;

			public const float SHIP_FAIL_DURATION_MIN_INITIAL = 15f;

			public const float SHIP_FAIL_DURATION_MAX_INITIAL = 60f;

			public const float SHIP_FAIL_WARNING_DURATION_MIN_INITIAL = 15f;

			public const float SHIP_FAIL_WARNING_DURATION_MAX_INITIAL = 30f;

			public const float SHIP_FAIL_WARNING_LENGTH = 1f;

			public const float FAIL_DURATION_INCREMENT = 15f;

			public const float TIME_TIL_FAIL_DECREMENT = 60f;

			public const float ABSOLUTE_MIN_TIME_TO_FAIL = 60f;
		}

		public static class SpecialObjectiveConstants
		{
			public const int SAM_FIRST_MISSIONMIN = 7;

			public const int SAM_FIRST_MISSIONMAX = 12;

			public const int SAM_AFTERFIRST_MISSIONMIN = 10;

			public const int SAM_AFTERFIRST_MISSIONMAX = 20;
		}

		public static class DifficultyConstants
		{
			public const float EASY_SCRAP = 1.5f;

			public const float EASY_UPGRADE_BREAKING = 0.5f;

			public const float HARD_SCRAP = 0.5f;

			public const float HARD_UPGRADE_BREAKING = 1.5f;
		}

		public static class ChallengeConstants
		{
			public const int DAILY_MULTIPLIER_SCRAP = 20;

			public const int DAILY_MULTIPLIER_DRONE_HP = 1;

			public const int DAILY_MULTIPLIER_DRONE_ALIVE = 35;

			public const int DAILY_MULTIPLIER_DRONE_UPGRADES = 25;

			public const int DAILY_MULTIPLIER_SHIP_UPGRADES = 30;

			public const int DAILY_MULTIPLIER_PFUEL = 5;

			public const int DAILY_MULTIPLIER_JFUEL = 20;

			public const float DAILY_SCRAP_FACTOR = 2f;

			public const int WEEKLY_MULTIPLIER_SCRAP = 1;

			public const int WEEKLY_MULTIPLIER_DRONE_HP = 10;

			public const int WEEKLY_MULTIPLIER_DRONE_ALIVE = 35;

			public const int WEEKLY_MULTIPLIER_DRONE_UPGRADES = 3;

			public const int WEEKLY_MULTIPLIER_SHIP_UPGRADES = 30;

			public const int WEEKLY_MULTIPLIER_PFUEL = 5;

			public const int WEEKLY_MULTIPLIER_JFUEL = 20;
		}

		public static class ConsoleConstants
		{
			public const int FONT_SIZE_DEAULT = 14;

			public const int FONT_SIZE_MIN = 8;

			public const int FONT_SIZE_MAX = 24;
		}

		public const int DEFAULT_DRONES_ALLOWED_TOTAL = 7;

		public const int MAX_NUMBER_OF_DEPLOYED_DRONES = 4;

		public const int INITIAL_NUMBER_OF_DEPLOYED_DRONES = 3;

		public const int MAX_DRONE_UPGRADE_SLOT_COUNT = 4;

		public const int INITIAL_DRONE_UPGRADE_SLOT_COUNT = 3;

		public const float DEFAULT_MONEY_AMOUNT = 1000f;

		public const float GAME_VERSION = 1.041f;

		public const string GAME_STATE = "";

		public const string GAME_NAME = "Duskers";

		public const float MENUSCREEN_BACKGROUND_ALPHA = 0.75f;

		public const int NUMBER_OF_SWARMS = 5;

		public const int NUMBER_OF_BRUTES = 7;

		public const int NUMBER_OF_INITIAL_SLIMES = 4;

		public const int MAX_RANDOM_SPAWN_SLIMES = 3;

		public const int NUMBER_OF_PATROLBOTS = 5;

		public const float BASE_VELOCITY_SCALE = 2.4f;

		public const float DEFAULT_DRONE_SPEED = 1f;

		public const int RANDOM_DRONE_SPEED_DEVIATION = 0;

		public const int DRONE_CHANCEOF_ALTERNATEDVP = 20;

		public const float TRANSPORTER_DEADAIR_MIN = 60f;

		public const float TRANSPORTER_DEADAIR_MAX = 120f;

		public const float TRANSPORTER_TRANSMIT_SPEED = 1f;

		public const int TRANSPORTER_ALLOWED_SIGNALS_MIN = 1;

		public const int TRANSPORTER_ALLOWED_SIGNALS_MAX = 5;

		public const int TRANSPORTER_CHANCE_OF_EXTRA_ONLINE = 3;

		public const float RECEIVER_SIGNAL_STRONG_MIN_TIME = 240f;

		public const float RECEIVER_SIGNAL_STRONG_MAX_TIME = 600f;

		public const float RECEIVER_SIGNAL_WEAK_MIN_TIME = 120f;

		public const float RECEIVER_SIGNAL_WEAK_MAX_TIME = 300f;

		public const float RECEIVER_SIGNAL_NONE_MIN_TIME = 120f;

		public const float RECEIVER_SIGNAL_NONE_MAX_TIME = 360f;

		public const float RECEIVER_SIGNAL_ACTIVATE_MIN_TIME = 240f;

		public const float RECEIVER_SIGNAL_ACTIVATE_MAX_TIME = 900f;

		public const int RECEIVER_SIGNAL_CHANCE_OF_INCREASE_STRENGTH = 3;

		public const int LOOTABLE_DRONE_MIN = 0;

		public const int LOOTABLE_DRONE_MAX = 2;

		public const int DRONE_FLEET_UPGRADE_RANDOM_MIN = 1;

		public const int DRONE_FLEET_UPGRADE_RANDOM_MAX = 1;

		public const int DRONE_DEAD_UPGRADE_RANDOM_MIN = 1;

		public const int DRONE_DEAD_UPGRADE_RANDOM_MAX = 2;

		public const float SONIC_RATE_CONSUMPTION = 0.8f;

		public const float SONIC_SLOW_RATE_RECHARGE = 0.3f;

		public const float GALAXY_MAP_CHANCEOF_OUTPOST = 0.33f;

		public const int GALAXY_MAP_MIN_DUNGEONS = 6;

		public const int GALAXY_MAP_MAX_DUNGEONS = 10;

		public const int GALAXY_MAP_MIN_AUTOTRADE = 0;

		public const int GALAXY_MAP_MAX_AUTOTRADE = 2;

		public const int GALAXY_MAP_TOTAL_SYSTEMS = 5;

		public const int STARTING_SCRAP_AMOUNT = 2;

		public const int STARTING_FUEL_PROP_CHARGE = 6;

		public const int STARTING_FUEL_JUMP = 2;

		public const int JumpFuelInDays = 15;

		public const int boardWidth = 36;

		public const int boardHeight = 28;

		public const int RESTORE_DRONE_HITPOINTS_COUNT_PER_DAY = 10;

		public const int RESTORE_DRONE_BACK_TO_LIFE_DAY_COUNT = 1;

		public const int RESTORE_DRONE_ITEMS_COUNT_PER_DAY = 0;

		public const int DRONE_REPAIRABLE_PERCENT_CHANCE = 80;

		public const int DRONE_LOOTABLE_REPAIRABLE_CHANCE = 25;

		public const int DRONE_LOOTABLE_NONSTANDARD_SLOTS_CHANCE = 10;

		public const string DEAD_NO_REPAIR_TEXT = "Destroyed";

		public const string DEAD_YES_REPAIR_TEXT = "Disabled";

		public const int TUTORIAL_NUMBER_OF_DRONES = 2;

		public static Color ORANGE = new Color(1f, 0.5882353f, 10f / 51f);

		public static Color ORANGE_DIM = new Color(0.5f, 0.29411766f, 5f / 51f);

		public static Color CONSOLE_GREEN = new Color(0.5f, 1f, 0.5f);

		public static Color LIGHT_GRAY = new Color(0.75f, 0.75f, 0.75f);

		public static Color MENU_TITLE = new Color(0.08f, 0.96f, 0.89f);

		public static Color LOG_DEFAULT_TYPING_COLOR = new Color(0.101960786f, 1f, 1f / 15f);

		public static Color LOG_INTRO_DEFAULT_COLOR = new Color(0.101960786f, 1f, 1f / 15f);

		public static Color LOG_DEFAULT_COLOR = new Color(2f / 3f, 2f / 3f, 0f);

		public static Color MISSION_SUMMARY_DEFAULT_COLOR = new Color(0.101960786f, 1f, 1f / 15f);

		public static Color GAME_END_DEFAULT_COLOR = new Color(0.101960786f, 1f, 1f / 15f);

		public static DroneUpgradeType[] EXPLORE_UPGRADE_TYPES = new DroneUpgradeType[4]
		{
			DroneUpgradeType.Sensor,
			DroneUpgradeType.AreaSensor,
			DroneUpgradeType.StealthField,
			DroneUpgradeType.Lure
		};
	}

	public static class TileTints
	{
		public static Color moveColor;

		public static float moveLerp;

		public static Color altMoveColor;

		public static float altMoveLerp;

		public static Color pieceSpawnColor;

		public static Color pieceSpawnColor2;

		public static float pieceSpawnLerp;
	}

	public static class InventoryDragInfo
	{
		public static bool IsDragging;

		public static IInventoryItem ItemBeingDragged;

		public static InventoryWindow SourceWindow;
	}

	public const bool TEST_DRONE_AVOIDANCE = true;

	public const int UniverseDaysSurvivedMax = 200;

	public const int NumUniversePlaysMax = 5;

	public static GameModeEnum gameMode = GameModeEnum.Normal;

	public static CameraMode cameraMode = CameraMode.Drone;

	public static bool cheatMode = false;

	public static bool MissionStarted = false;

	public static bool GameIsOver = false;

	public static bool IsTutorial = false;

	public static bool IsGameEditor = false;

	public static bool IsExitingApplication = false;

	public static bool IsInResetState = false;

	public static bool IsContinuingWeeklyChallenge = false;

	public static bool UseTransporters = false;

	public static bool UsePowerManager = false;

	public static bool UseRemotePower = false;

	public static bool UseCombinedTerminal = true;

	public static ShipUpgradeType UseThisPermUpgrade = ShipUpgradeType.Unknown;

	public static bool GenerateGalaxyMapFromImage = true;

	public static bool UseCommandTree = false;

	public static int PerformanceFarView = 0;

	public static bool EnableShiftButtonForChangeView = false;

	public static int NumLogsAfterTutorial = 10000;

	public static bool InterfaceUsedOnce = GameSaveFile.Get("INTERFACE_USED", false);

	public static float MissionTime = 0f;

	public static float SFXMaster = 1f;

	public static float SFXVolume = 0.5f;

	public static float SFXVolumeRemote = 0.5f;

	public static float SFXVolumeRemoteAmbience = 1f;

	public static float SFXVolumeSchematic = 1f;

	public static float SFXVolumeInterface = 1f;

	public static float SFXDroneCallSignal = 0.5f;

	public static float MusicVolume = 0.5f;

	public static bool SafeTutorialMode = false;

	public static bool IsGamePaused = false;

	public static bool ShowDailyLeaderboard = false;

	public static bool ShowWeeklyLeaderboard = false;

	public static bool GameStartedFromGalaxyMap = false;

	public static bool FirstTimeIn = false;

	public static bool RetrySameInitialState = false;

	public static bool ShowingGameOverlayWindow = false;

	public static bool CommandeeringShip = false;

	public static bool DiscoveredUpgradesOnly = true;

	public static List<DroneUpgradeType> DiscoveredUpgrades_Exploring = new List<DroneUpgradeType>
	{
		DroneUpgradeType.AreaSensor,
		DroneUpgradeType.StealthField
	};

	public static List<DroneUpgradeType> DiscoveredUpgrades = new List<DroneUpgradeType>
	{
		DroneUpgradeType.Interface,
		DroneUpgradeType.Probe
	};

	public static List<string> LogFilesAlreadyViewed = new List<string>();

	public static Dictionary<int, int> SystemIdToGroupNumberMapping = new Dictionary<int, int>();

	public static int NextStoryGroupNumber = 1;

	public static int BestDaysSurvived = 0;

	public static int UniverseDaysSurvived = 0;

	public static int NumUniversePlays = 0;

	public static List<string> CrippledCommandList = null;

	public static DroneUpgradeType[] UPGRADE_IGNORE_ALWAYS_LIST = new DroneUpgradeType[2]
	{
		DroneUpgradeType.SwarmTurret,
		DroneUpgradeType.Repair
	};

	public static DroneUpgradeType[] UPGRADE_IGNORE_STARTUP_LIST = new DroneUpgradeType[2]
	{
		DroneUpgradeType.Tow,
		DroneUpgradeType.SpeedBoost
	};

	public static bool OwnsDronesBestFriend = false;

	public static readonly Color editorUnusedTileColor = new Color(0.6f, 0.6f, 0.6f);

	public static bool selectionEnabled = true;

	public static bool gameLaunchedFromMenu = false;

	public static string gameBoardFile = null;

	private static GameState _gameState = null;

	public static bool AreaSensorUsedOnce
	{
		get
		{
			return GameSaveFile.Get("AREASENSOR_USED", false);
		}
		set
		{
			GameSaveFile.Save("AREASENSOR_USED", value);
		}
	}

	public static bool StealthUsedOnce
	{
		get
		{
			return GameSaveFile.Get("STEALTH_USED", false);
		}
		set
		{
			GameSaveFile.Save("STEALTH_USED", value);
		}
	}

	public static bool OverrideCameraVisibility
	{
		get
		{
			return cheatMode || GameIsOver;
		}
	}

	public static bool GameStateIsLoaded { get; set; }

	public static GameState GameState
	{
		get
		{
			if (_gameState == null)
			{
				GameStateIsLoaded = true;
				_gameState = new GameState();
				_gameState.CreateDefault();
				if (!IsTutorial)
				{
					Debug.LogWarning("Auto-Created default GameState -- should ONLY happen if you don't launch game from menu or galaxymap");
				}
			}
			return _gameState;
		}
		set
		{
			GameStateIsLoaded = value != null;
			_gameState = value;
		}
	}

	public static void ResetDiscoveredUpgrades()
	{
		List<DroneUpgradeType> list = new List<DroneUpgradeType>();
		list.Add(DroneUpgradeType.AreaSensor);
		list.Add(DroneUpgradeType.StealthField);
		DiscoveredUpgrades_Exploring = list;
		list = new List<DroneUpgradeType>();
		list.Add(DroneUpgradeType.Interface);
		list.Add(DroneUpgradeType.Probe);
		DiscoveredUpgrades = list;
	}

	public static void ResetStoryLogHistory()
	{
		LogFilesAlreadyViewed.Clear();
		SystemIdToGroupNumberMapping.Clear();
		NextStoryGroupNumber = 1;
	}

	public static void SubmitBestDaysSurvived(int newValue)
	{
		if (newValue > BestDaysSurvived)
		{
			BestDaysSurvived = newValue;
			GameSaveFile.SaveBestDaysSurvived(BestDaysSurvived);
		}
	}
}
