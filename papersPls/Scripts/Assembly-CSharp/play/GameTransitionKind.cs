using app.plat;
using data;
using haxe.lang;
using play.day;
using play.save;

namespace play
{
	public class GameTransitionKind : Enum
	{
		public static readonly GameTransitionKind NONE;

		public static readonly GameTransitionKind ADVANCE_TO_NEXTDAY;

		public static readonly GameTransitionKind MAKE_STASH_DAY;

		public static readonly GameTransitionKind STASH_RESTORE;

		public static readonly GameTransitionKind START_AUTO_SOAK;

		public static readonly GameTransitionKind QUIT;

		protected static readonly string[] __hx_constructs;

		protected GameTransitionKind(int index)
			: base(0)
		{
		}

		public static GameTransitionKind FADE_TO_SCREEN(string name, bool instant)
		{
			return null;
		}

		public static GameTransitionKind LOAD_TO_SCREEN(SaveHeader saveHeader, string screenName)
		{
			return null;
		}

		public static GameTransitionKind FADE_TO_ENDLESS_DAY(EndlessId endlessId)
		{
			return null;
		}

		public static GameTransitionKind FADE_TO_ENDLESS_RESULT(EndlessResult endlessResult)
		{
			return null;
		}

		public static GameTransitionKind FADE_TO_END(string endId)
		{
			return null;
		}

		public static GameTransitionKind SKIP_TO_DAY(int dayId)
		{
			return null;
		}

		public static GameTransitionKind SKIP_TO_TRAVELER(string travelerId, int forceDayId)
		{
			return null;
		}

		public static GameTransitionKind FLASH_TO_TITLE(double duration)
		{
			return null;
		}

		public static GameTransitionKind OPEN_EXTERNAL_LINK(string url)
		{
			return null;
		}

		public static GameTransitionKind SET_PAUSE(bool pause)
		{
			return null;
		}

		public static GameTransitionKind MAKE_STASH_END(string endId)
		{
			return null;
		}

		public static GameTransitionKind REQUEST_PLATFORM_CHANGE(PlatformKind newPlatformKind)
		{
			return null;
		}

		public static GameTransitionKind SHOW_RATING_SCREEN(Function doneFunc)
		{
			return null;
		}
	}
}
