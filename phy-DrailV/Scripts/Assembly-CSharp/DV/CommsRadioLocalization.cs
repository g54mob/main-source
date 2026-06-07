using DV.Localization;

namespace DV
{
	public static class CommsRadioLocalization
	{
		public static string MODE_DERAIL_QUESTION = LocalizationAPI.L("comms/mode_derail_question");

		public static string MODE_DERAIL_AIM = LocalizationAPI.L("comms/mode_derail_aim");

		public static string CONFIRM => LocalizationAPI.L("comms/confirm");

		public static string CANCEL => LocalizationAPI.L("comms/cancel");

		public static string INSUFFICIENT_FUNDS => LocalizationAPI.L("comms/insufficient_funds");

		public static string SELECT => LocalizationAPI.L("comms/select");

		public static string LOADED_VEHICLE => LocalizationAPI.L("comms/loaded_vehicle");

		public static string MODE_CARGO_LOADER => LocalizationAPI.L("comms/mode_cargo_loader");

		public static string ENABLE_CARGO_LOADER => LocalizationAPI.L("comms/enable_cargo_loader");

		public static string CARGO_UNLOAD => LocalizationAPI.L("comms/cargo_unload");

		public static string MODE_SPAWNER => LocalizationAPI.L("comms/mode_spawner");

		public static string ENABLE_SPAWNER => LocalizationAPI.L("comms/enable_spawner");

		public static string SPAWNER_CAT_LOCO => LocalizationAPI.L("comms/spawner_cat_loco");

		public static string SPAWNER_CAT_CARS => LocalizationAPI.L("comms/spawner_cat_cars");

		public static string MODE_WORK_TRAIN => LocalizationAPI.L("comms/mode_work_train");

		public static string WORK_TRAIN_PICK_DESTINATION => LocalizationAPI.L("comms/work_train_pick_destination");

		public static string WORK_TRAIN_LOCKED => LocalizationAPI.L("comms/work_train_locked");

		public static string REQUEST_WORK_TRAIN => LocalizationAPI.L("comms/request_work_train");

		public static string NO_UNLOCKED_WORK_TRAIN => LocalizationAPI.L("comms/no_unlocked_work_train");

		public static string MODE_CLEAR => LocalizationAPI.L("comms/mode_clear");

		public static string DISCARD_JOB_WARNING => LocalizationAPI.L("comms/discard_job_warning");

		public static string CLEAR_CAR_FORBIDDEN_BY_DIFFICULTY => LocalizationAPI.L("comms/clear_must_rerail");

		public static string CLEAR_INSTRUCTION => LocalizationAPI.L("comms/clear_instruction");

		public static string MODE_SWITCH => LocalizationAPI.L("comms/mode_switch");

		public static string SWITCH_INSTRUCTION => LocalizationAPI.L("comms/switch_instruction");

		public static string MODE_LED => LocalizationAPI.L("comms/mode_led");

		public static string ENABLE_LED => LocalizationAPI.L("comms/enable_led");

		public static string DISABLE_LED => LocalizationAPI.L("comms/disable_led");

		public static string MODE_RERAIL => LocalizationAPI.L("comms/mode_rerail");

		public static string RERAIL_INSTRUCTION => LocalizationAPI.L("comms/rerail_instruction");

		public static string RERAIL_INSUFFICIENT_FUNDS => LocalizationAPI.L("comms/rerail_insufficient_funds");

		public static string MODE_DAMAGE => LocalizationAPI.L("comms/mode_damage");

		public static string MODE_DAMAGE_ENABLE => LocalizationAPI.L("comms/mode_enable_damage");

		public static string MODE_DERAIL => LocalizationAPI.L("comms/mode_damage_derail");

		public static string MODE_PAINTJOB => LocalizationAPI.L("comms/mode_paintjob");

		public static string MODE_PAINTJOB_ENABLE => LocalizationAPI.L("comms/mode_enable_paintjob");

		public static string MODE_PAINTJOB_ALL => LocalizationAPI.L("comms/mode_paintjob/target_all");

		public static string MODE_PAINTJOB_INTERIOR => LocalizationAPI.L("comms/mode_paintjob/target_interior");

		public static string MODE_PAINTJOB_EXTERIOR => LocalizationAPI.L("comms/mode_paintjob/target_exterior");

		public static string MODE_PAINTJOB_NOT_COMPATIBLE => LocalizationAPI.L("comms/mode_paintjob/not_compatible");

		public static string MODE_STARTUP => LocalizationAPI.L("comms/mode_startup");

		public static string MODE_STARTUP_DESC => LocalizationAPI.L("comms/mode_startup_aim");

		public static string MODE_STARTUP_START => LocalizationAPI.L("comms/mode_startup_start");

		public static string WORK_TRAIN_SUMMON_PROMPT(string car, float price)
		{
			return LocalizationAPI.L("comms/work_train_summon_prompt", car, price.ToString("N2", LocalizationAPI.CC));
		}

		public static string CLEAR_CAR_PROMPT(string car, float price)
		{
			return LocalizationAPI.L("comms/clear_car_prompt", car, price.ToString("N2", LocalizationAPI.CC));
		}

		public static string RERAIL_PROMPT_1(string car, float price)
		{
			return LocalizationAPI.L("comms/rerail_prompt_1", car, price.ToString("N2", LocalizationAPI.CC));
		}

		public static string RERAIL_PROMPT_2(float price)
		{
			return LocalizationAPI.L("comms/rerail_prompt_2", price.ToString("N2", LocalizationAPI.CC));
		}

		public static string MODE_DAMAGE_DESC(int percentage)
		{
			return LocalizationAPI.L("comms/mode_damage_aim", percentage.ToString());
		}

		public static string MODE_DAMAGE_STATS(int currentHealth, int maxHealth, int percentage)
		{
			return LocalizationAPI.L("comms/mode_damage_stats", currentHealth.ToString(), maxHealth.ToString(), percentage.ToString());
		}
	}
}
