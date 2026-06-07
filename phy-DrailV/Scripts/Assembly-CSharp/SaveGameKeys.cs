using DV.Utils;

public static class SaveGameKeys
{
	public const string Save_version = "Version";

	public const string Save_version_initial = "Version_initial";

	public const string Game_version_initial = "Game_version_initial";

	public const string Game_version_latest = "Game_version_latest";

	public const string Player_position = "Player_position";

	public const string Player_rotation = "Player_rotation";

	public const string Player_car_guid = "Player_car_guid";

	public const string Player_money = "Player_money";

	public const string ModManager_info = "ModManagers";

	public const string PreOverhaul_Player = "PreOverhaul_Player";

	public const string Licenses_General = "Licenses_General";

	public const string Licenses_Jobs = "Licenses_Jobs";

	public const string Garages = "Garages";

	public const string RestorationLocos = "Restoration_Locos";

	public const string Storage_Inventory = "Storage_Inventory";

	public const string Storage_Belt = "Storage_Belt";

	public const string Storage_LostAndFound = "Storage_LostAndFound";

	public const string Storage_World = "Storage_World";

	public const string Storage_InstalledGadgets = "Storage_InstalledGadgets";

	public const string Storage_ItemContainers = "Storage_ItemContainers";

	private const string JOBS_KEY_PREFIX = "Jobs#";

	private const string CARS_KEY_PREFIX = "Cars#";

	public const string Unique_cars = "Unique_cars";

	public const string Caboose_In_Range = "Caboose_In_Range";

	public const string Customizers = "Customizers";

	public const string Turntables = "Turntables";

	public const string Generic_switches = "Generic_switches";

	private const string JUNCTIONS_KEY_PREFIX = "Junctions#";

	public const string Last_Tracks_Hash = "Last_Tracks_Hash";

	public const string TRACKS_HASH_KEY_PREFIX = "Map_hash#";

	public const string Debt_existing_locos = "Debt_existing_locos";

	public const string Debt_deleted_locos = "Debt_deleted_locos";

	public const string Debt_existing_jobs = "Debt_existing_jobs";

	public const string Debt_staged_jobs = "Debt_staged_jobs";

	public const string Debt_existing_jobless_cars = "Debt_existing_jobless_cars";

	public const string Debt_deleted_jobless_cars = "Debt_deleted_jobless_cars";

	public const string Debt_insurance = "Debt_insurance";

	public const string Debt_total = "Debt_total";

	public const string Debt_deleted_owned_cars = "Debt_deleted_owned_cars";

	public const string Derail_Popup_Shown = "Derail_Popup_Shown";

	public const string Damage_Popup_Shown = "Damage_Popup_Shown";

	public const string Tutorial_01_completed = "Tutorial_01_completed";

	public const string Tutorial_02_completed = "Tutorial_02_completed";

	public const string Tutorial_03_completed = "Tutorial_03_completed";

	public const string Tutorial_loco_id = "Tutorial_loco_id";

	public const string Tutorial_cargo_car_id = "Tutorial_cargo_car_id";

	public const string Tutorial_state = "Tutorial_state";

	public const string Tutorial_backtrack_state = "Tutorial_backtrack_state";

	public const string Tutorial_turntable_loco_ids = "Tutorial_turntable_loco_ids";

	public const string Tutorial_service_loco_id = "Tutorial_service_loco_id";

	public const string Tutorial_just_finished = "Tutorial_just_finished";

	public const string Belt_slot_positions = "Belt_slot_positions";

	public const string Belt_slot_rotations = "Belt_slot_rotations";

	public const string Belt_slot_states = "Belt_slot_states";

	public const string Time_and_date = "Time_and_date";

	public const string Starting_time_and_date = "Starting_time_and_date";

	public const string World = "World";

	public const string Game_mode = "Game_mode";

	public const string Starting_items = "Starting_items";

	public const string Hazmat_data = "Hazmat_data";

	public const string Difficulty_params = "Difficulty_params";

	public const string Starting_difficulty = "Starting_difficulty";

	public const string Consistent_difficulty = "Consistent_difficulty";

	public const string Last_used_difficulty = "Last_used_difficulty";

	public const string Scenario = "Scenario";

	public const string Difficulty_picked = "Difficulty_picked";

	public const string Progression_state = "Progression_state";

	public const string Unlocked_general_licenses = "Unlocked_general_licenses";

	public const string Unlocked_job_licenses = "Unlocked_job_licenses";

	public const string Unlocked_garages = "Unlocked_garages";

	public const string Unlocked_items = "Unlocked_items";

	public const string Boombox_info_displayed = "Boombox_info_displayed";

	public const string TutorialQuick_DE2 = "QT_DE2";

	public const string TutorialQuick_DE6 = "QT_DE6";

	public const string TutorialQuick_DH4 = "QT_DH4";

	public const string TutorialQuick_DM3 = "QT_DM3";

	public const string TutorialQuick_S282A = "QT_S282A";

	public const string TutorialQuick_S060 = "QT_S060";

	public const string TutorialQuick_Microshunter = "QT_Microshunter";

	public const string TutorialQuick_DM1U = "QT_DM1U";

	public const string CabPositionsVR = "CabPositionsVR";

	public const string CabPositionsNonVR = "CabPositionsNonVR";

	public const string ExtCamPose = "ExtCamPose";

	public const string Shop_save_data = "Shop_item_amount_data";

	public const string BedSleeping_last_wakeup_time = "Last_wake_time";

	public const string BedSleeping_last_sleep_duration = "Last_sleep_duration";

	public static string Jobs => GetJobsSaveKeyForDesiredTracksHash(SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash);

	public static string Cars => GetCarsSaveKeyForDesiredTracksHash(SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash);

	public static string Junctions => "Junctions#" + SingletonBehaviour<RailTrackRegistryBase>.Instance.JunctionsHash;

	public static string GetJobsSaveKeyForDesiredTracksHash(string tracksHash)
	{
		return "Jobs#" + tracksHash;
	}

	public static string GetCarsSaveKeyForDesiredTracksHash(string tracksHash)
	{
		return "Cars#" + tracksHash;
	}
}
