using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public static class ActionInfoUtils
	{
		private const string OrderDefault = "OrderDefault";

		public static string PlaceSingle => GetLocalized("menu_action_place_single");

		public static string PlaceRow => GetLocalized("menu_action_place_row");

		public static string PlaceRotate => GetLocalized("menu_action_place_rotate");

		public static string Socketable => GetLocalized("menu_action_socketable");

		public static string Dismiss => GetLocalized("menu_action_dismiss");

		public static string Attack => GetLocalized("menu_action_attack");

		public static string RightClickEquip => GetLocalized("menu_action_rightclick_equip");

		public static string RightClickMove => GetLocalized("menu_action_rightclick_move");

		public static string RightClickAttack => GetLocalized("menu_action_rightclick_attack");

		public static string ScrollWheelLayer => GetLocalized("menu_action_scroll_wheel_layer");

		public static string CameraLockScrollWheelLayer => GetLocalized("menu_action_scroll_wheel_camera_layer");

		public static string ClickLayer => GetLocalized("menu_action_click_layer");

		public static List<string> GetOrderInfos(OrderType orderType)
		{
			ActionInfoData byID = Repository<ActionInfoDataRepository, ActionInfoData>.Instance.GetByID(orderType.ToString());
			if (byID == null)
			{
				return GetLocalized(Repository<ActionInfoDataRepository, ActionInfoData>.Instance.GetByID("OrderDefault").ActionInfos);
			}
			if (byID.ActionInfos != null)
			{
				return GetLocalized(Repository<ActionInfoDataRepository, ActionInfoData>.Instance.GetByID(orderType.ToString()).ActionInfos);
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(49, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Tooltip\\ActionInfoUtils.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("There is no Action Info Data for: ");
				messageBuilder.AppendFormatted(byID.GetID());
				messageBuilder.AppendLiteral(" ActionInfoData");
			}
			Log.Error(messageBuilder);
			return null;
		}

		public static List<string> GetLocalized(string[] textKeys)
		{
			List<string> list = new List<string>();
			foreach (string textKey in textKeys)
			{
				list.Add(GetLocalized(textKey));
			}
			return list;
		}

		public static string GetLocalized(string textKey)
		{
			return TextFormatting.FormatKeyInputEvent(textKey.ToLocalized());
		}
	}
}
