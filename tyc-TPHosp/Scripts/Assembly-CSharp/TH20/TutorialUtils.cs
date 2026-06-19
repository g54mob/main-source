using TH20.UI;

namespace TH20
{
	public static class TutorialUtils
	{
		public static RibbonRoomRow GetRibbonRoomRow(Level level, RoomDefinition roomDefinition)
		{
			RibbonMenu ribbonMenu = level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				return null;
			}
			return ribbonMenu.FindRoomRow(roomDefinition);
		}

		public static RibbonItemRow GetRibbonItemRow(Level level, RoomItemDefinition itemDefinition)
		{
			RibbonMenu ribbonMenu = level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				return null;
			}
			return ribbonMenu.FindItemRow(itemDefinition);
		}

		public static bool GetRibbonHireMenuSettings(Level level, out RibbonMenuHireState.Settings settings)
		{
			RibbonMenu ribbonMenu = level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				settings = null;
				return false;
			}
			settings = ribbonMenu.HireStateSettings;
			return true;
		}

		public static bool GetRibbonBuildMenuSettings(Level level, out RibbonMenuBuildState.Settings settings)
		{
			RibbonMenu ribbonMenu = level.HUD.FindMenu<RibbonMenu>();
			if (ribbonMenu == null)
			{
				settings = null;
				return false;
			}
			settings = ribbonMenu.BuildStateSettings;
			return true;
		}

		public static ButtonAnimator GetHubRoomsButton(Level level)
		{
			HubMenu hubMenu = level.HUD.FindMenu<HubMenu>();
			if (hubMenu == null)
			{
				return null;
			}
			return hubMenu.HubMenuButtons.RoomsButtonAnimator;
		}

		public static ButtonAnimator GetHubItemsButton(Level level)
		{
			HubMenu hubMenu = level.HUD.FindMenu<HubMenu>();
			if (hubMenu == null)
			{
				return null;
			}
			return hubMenu.HubMenuButtons.ItemsButtonAnimator;
		}

		public static ButtonAnimator GetHubHiresButton(Level level)
		{
			HubMenu hubMenu = level.HUD.FindMenu<HubMenu>();
			if (hubMenu == null)
			{
				return null;
			}
			return hubMenu.HubMenuButtons.HireButtonAnimator;
		}

		public static DynamicButton GetMetaMapButton(Level level)
		{
			HubMenu hubMenu = level.HUD.FindMenu<HubMenu>();
			if (hubMenu == null)
			{
				return null;
			}
			return hubMenu.HubMenuButtons.MetaMapButton;
		}

		public static bool HasMenuBeenSeenBefore(string menuName, Level level)
		{
			bool value = true;
			if (!DebugVars.DisableTutorialMessages.Value && !level.IsSandbox())
			{
				level.Metagame.GetHUDSavedState(menuName, out value);
			}
			return value;
		}

		public static void SetMenuHasBeenSeen(string menuName, Level level)
		{
			level.Metagame.SetHUDSavedState(menuName, value: true);
		}
	}
}
