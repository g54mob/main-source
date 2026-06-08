public class Features
{
	public static Version VERSION = new Version(3, 56, 0);

	public static Version PREV_VERSION;

	public static Version PREV_APP_VERSION;

	public const bool CHEATS_ENABLED = false;

	public const bool PRERELEASE_CHEATS_METHOD = false;

	public const bool PLAY_MAIN_MENU_MUSIC = true;

	public const bool SCROLL_BAR_ENABLED = true;

	public const bool ITEM_DRAG_N_DROP = true;

	public const bool ITEM_SELECTABLE = true;

	public const bool ANVIL_SINGLE_CLICK = true;

	public const bool IS_MOBILE = false;

	public const bool IS_STANDALONE = true;

	public const bool SCROLL_WHEEL_ENABLED = true;

	public const bool SCROLL_BAR_INTERACTIVE = true;

	public const bool PREVENT_SLEEP = false;

	public const bool LOCAL_NOTIFICATIONS_ENABLED = false;

	public const bool LIMITED_TIME_BUNDLES_ENABLED = false;

	public const bool UTILITY_BELT_UI_ENABLED = false;

	public const float SCROLL_WHEEL_SPEED = 26f;

	public const float SCROLL_WHEEL_MIN = 0f;

	public const float SCROLL_WHEEL_MAX = 50f;

	public const bool SCROLL_INVERT = false;

	public const int TARGET_FRAME_RATE = 60;

	public const float TIME_PER_TIC = 0.03333333f;

	public const bool PROGRESS_BAR_SFXS = true;

	public const int DEFAULT_COLUMN_COUNT = 46;

	public const int DEFAULT_ROW_COUNT = 26;

	public const float HIDE_MOUSE_IDLE_TIME = 2f;

	public const string SUBTITLE = "RPG";

	public const bool PRESS_TO_SKIP_LOGO = false;

	public const bool FX_SLOW_MOTION_ON_HIT_ENABLED = true;

	public const bool FX_CAM_SHAKE_ON_HIT_ENABLED = true;

	public const bool EXIT_APP_DIALOG_ENABLED = true;

	public const float SHOW_RESTART_PROGRESS_AFTER_IDLE_TIME = -1f;

	public const float AUTO_RESTART_PROGRESS_AFTER_IDLE_TIME = 150f;

	public const bool COLOR_ITEM_NAME_BY_RARITY = true;

	public const bool COLOR_ITEM_SLOT_STARS_BY_RARITY = true;

	public const bool SHOW_ITEM_SLOT_RARITY_BONUS = true;

	public const bool ENCRYPT_SAVE_FILES = true;

	public const bool COPY_PROGRESS_DATA_ENABLED = true;

	public const bool FAERIE_ENABLED = false;

	public const int TREASURE_PICKUP_LIMIT = 100;

	public const int TREASURE_LIMIT_PER_HERO_LEVEL = 5;

	public const int DEFAULT_VSYNC = 1;

	public const bool IS_LINUX = false;

	public const bool IS_OSX = false;

	public const bool IS_ANDROID = false;

	public const bool IS_IOS = false;

	public const int MAX_STAR_STONE_LEVEL = 3;

	public const bool REROLL_ENCHANTMENT_ENABLED = true;

	public const bool STEAMWORKS_ENABLED = true;

	public const bool DISCORD_ENABLED = false;

	public const bool PERIODIC_SPRITE_RELOAD = true;

	public const bool LANGUAGE_SELECTION_FOR_NEW_PLAYERS = true;

	public const float MAGIC_TRANSITION_DIM = 0.35f;

	public const float TIC_MULTIPLY = 1f;

	public const bool SHOW_ABILITY_KEY_BINDINGS = true;

	public const int EXPIRATION_MONTH = 5;

	public const int EXPIRATION_YEAR = 2020;

	public static bool CODES_SCREEN_ENABLED = false;

	public const bool SS_IMPORT_ENABLED = true;

	public const bool SS_STORAGE_ENABLED = true;

	public const bool CUSTOM_QUESTS_ENABLED = true;

	public const bool EPIC_QUEST_COOLDOWNS = true;

	public const bool ACHIEVEMENTS_ENABLED = true;

	public const int MAX_SAVE_FILES = 10;

	public const bool REFERRALS_ENABLED = true;

	public const bool EVENTS_v2_ENABLED = true;

	public const bool LEADERBOARDS_ENABLED = true;

	public const bool LOCATION_LEADERBOARDS_ENABLED = true;

	public const bool LEADERBOARD_SUBMIT_ENABLED = true;

	public static bool IS_TOUCH_MACRO
	{
		get
		{
			if (AsciiMouse.singleton != null)
			{
				return AsciiMouse.singleton.isTouch;
			}
			return false;
		}
	}

	public static bool SCROLL_BY_DRAGGING => IS_TOUCH_MACRO;

	public static int SCROLL_BY_DRAG_DELAY
	{
		get
		{
			if (!IS_TOUCH_MACRO)
			{
				return 0;
			}
			return 1;
		}
	}

	public static int ITEM_DRAG_AUTO_INIT_NO_MOVE_TICS
	{
		get
		{
			if (!IS_TOUCH_MACRO)
			{
				return 10;
			}
			return 20;
		}
	}

	public static int ITEM_DRAG_MIN_TICS_WITHOUT_MOVE
	{
		get
		{
			if (!IS_TOUCH_MACRO)
			{
				return 0;
			}
			return 4;
		}
	}

	public static bool HasExpired()
	{
		return false;
	}
}
