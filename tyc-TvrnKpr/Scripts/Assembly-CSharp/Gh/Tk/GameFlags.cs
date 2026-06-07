namespace Gh.Tk
{
	public static class GameFlags
	{
		public static bool LEVEL_EDITOR;

		public const float UI_FRAME_LOCK_DELTATIME = 1f / 60f;

		public static bool DISABLE_CAMERA_IN_MAIN_MENU;

		public static bool ALLOW_ESCAPE_TO_MAINMENU;

		public static bool ALLOW_DEV_CHEATS;

		public static bool ALL_LEVELS_UNLOCKED;

		public static bool SHOW_STAR_REVEAL_ANIMATION;

		public static bool SHOW_STAR_REVEAL_ON_CHEATING;

		public static bool SHOW_ALL_PATRON_ARCHETYPES;

		public static bool SHOW_ALL_RATINGS_IN_TOOLTIP_ON_TAVERN_MENU;

		public static bool SHOW_ALL_SKILL_BONUS_LEVELS;

		public static bool SHOW_HIDDEN_ITEMS_IN_MENU;

		public static bool SHOW_ARRIVAL_HOUR_IN_PATRON_ATTRACTION;

		public static bool IS_SWATCH_EDITOR_ENABLED;

		public static bool OPEN_FEEDBACK_ON_FIRST_ERROR;

		public static bool SHOW_POST_FEEDBACK_DIALOG;

		public static bool ENABLE_TROPHY_CASE;

		public static bool SHOW_UNBUYABLE_SHOP_ITEMS;

		public static bool FORCE_SHOW_REGIONS_UNLOCKED_IN_MAIN_MENU;

		public static string DEFAULT_LEVEL;

		public static bool ENABLE_ERROR_NOTIFICATIONS;

		private static bool ENABLE_SAVE_SHARE_CODES;

		private static bool ENABLE_CONTENT_SHARE_CODES;

		public static bool ALLOW_DIRECTORSTOOLBAR;

		public static bool ALLOW_FIRE_SPARKS;

		public static bool ALLOW_INFESTATION_NESTS;

		public static bool ENABLE_GLOBAL_GAZETTE_STORIES;

		public static bool TRADE_ROUTES_ARE_FREE;

		public static bool ENABLE_MAINTAIN_BUTTON;

		public static bool ALLOW_SAVELOAD;

		public static bool ALLOW_MAINMENU_TIME_PROGRESSION;

		public static bool ENABLE_CREDITS;

		public static bool ENABLE_CINEMATIC_REPLAY;

		public static bool SHOW_FIND_IN_EXPLORER_ON_SAVES;

		public static bool SHOW_CAMERA_SWITCH_MESSAGE;

		public static bool SIMPLE_MESSAGES_ENABLED;

		public static bool ENABLE_PATRON_RATING_VISUAL;

		public static bool ENABLE_PIRATE_MODE;

		public static bool DISABLE_STAFF_SICKNESS;

		public static bool REQUIRE_CORRECT_ZONES;

		public static bool REQUIRE_DECOR_PIECES_UNLOCKED;

		public static bool ENABLE_DECO_MATERIAL_COST_MODIFIERS;

		public static bool PATRON_ATTRACTION_BOARD_FULLY_UNLOCKED;

		public static float FREEPLAY_MAX_STARS;

		public static string[] WHITELISTED_BUILD_CATEGORIES;

		public static string[] WHITELISTED_MUSIC_TRACKS;

		public static string[] WHITELISTED_LEVELS;

		public static string[] WHITELISTED_BUYABLE_GAME_ITEM_TYPES;

		public static string[] WHITELISTED_BUYABLE_INGREDIENT_CATEGORIES;

		public static bool ENABLE_DEMO_MAINMENU;

		public static bool ENABLE_DEMO_SWAMP;

		public static bool SHOW_NEWLETTER_DIALOG_ON_QUIT;

		public static readonly bool STEAM_ENABLED;

		public static readonly uint STEAM_APP_ID;

		public static readonly uint STEAM_APP_ID_DLC_DEV_COMMENTARY;

		public static readonly bool SUPPORT_FAMILY_SHARING;

		public static bool AUTO_LOAD_RECENT_SAVE;

		public static string AUTO_LOAD_LEVEL;

		public static int AUTO_SAVE_INTERVAL_IN_MINUTES;

		public static bool SHOWI18NERRORS;

		public static bool LOGI18NERRORS;

		public static bool FORCE_NO_SUBTITLES;

		public static bool DEBUG_RAYCAST_HIT;

		public static bool DEBUG_COLLISION_DETECTOR;

		public static bool DEBUG_SHOW_ALL_COLLECTIBLE_CARDS;

		public static bool DEBUG_EXCLUDE_STORIES_IN_EDITOR;

		public static bool ENABLE_COLLECTIBLE_CARDS;

		public static bool CHECKANIMATORS_ON_STARTUP;

		public static bool CHECK_IF_PREFABS_FOR_ALL_ITEMS_EXISTS;

		public static bool LOG_ANIMATION_PICKS;

		public static bool TESTSOCIALINTERACTION;

		public static bool SHOW_ACTIVETASKS_ON_PATRONS_AND_ENTERTAINERS;

		public const string DISCORD_SERVER_LINK = "https://discord.gg/greenheartgames";

		public const string GREENHEART_LINK = "https://greenheartgames.com/";

		public const string NEWSLETTER_STEAM_LINK = "https://store.steampowered.com/app/436780/Tavern_Keeper";

		public const string NEWSLETTER_GHG_LINK = "https://greenheart.games/";

		public const string STEAM_STORE_LINK = "https://store.steampowered.com/app/436780/Tavern_Keeper";

		public const string STEAM_COMMUNITY_LINK = "https://steamcommunity.com/app/436780";

		public static bool DISTRIBUTE_AICOMPONENTS_UPDATE_CALLS;

		public const string BUILDVARIANT_FULL_RELEASE = "GHG_BUILDVARIANT_FULL_RELEASE";

		public const string BUILDVARIANT_STEAM_EARLYACCESS = "GHG_BUILDVARIANT_STEAM_EARLYACCESS";

		public const string BUILDVARIANT_TEASER_EXPO = "GHG_BUILDVARIANT_TEASER_EXPO";

		public const string BUILDVARIANT_STEAM_BETA = "GHG_BUILDVARIANT_STEAM_BETA";

		public const string BUILDVARIANT_STEAM_DEMO = "GHG_BUILDVARIANT_STEAM_DEMO";

		public static string[] VariantBuildSymbols;

		public static string CURRENT_BUILD_VARIANT;

		public static string VERSION_TEXT;

		public static bool IsDemo => false;

		public static bool ExpectCloudSupport => false;

		public static bool DEBUG_ENABLE_DIRECTORS_TOOLBAR_DEVTOOLS => false;

		public static bool IsAnyShareCodeFeatureEnabled()
		{
			return false;
		}

		public static bool IsSaveSharingEnabled()
		{
			return false;
		}

		public static bool IsContentSharingEnabled()
		{
			return false;
		}

		static GameFlags()
		{
		}

		public static string[] GetVariantSymbols()
		{
			return null;
		}

		public static bool IsCameraPresetsFeatureEnabled()
		{
			return false;
		}

		public static bool IsItemWorkshopAllowed()
		{
			return false;
		}
	}
}
