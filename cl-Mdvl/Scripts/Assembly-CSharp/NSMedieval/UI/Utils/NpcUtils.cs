using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class NpcUtils
	{
		public static string GetLocalizedFactionName(HumanoidInstance npcInstance)
		{
			return UiUtils.Localize.GetText("general_faction") + ": " + npcInstance.Faction.NameLocalized;
		}

		public static string GetLocalizedFactionLink(HumanoidInstance npcInstance)
		{
			return UiUtils.GetFactionLink(npcInstance.Faction, npcInstance.Faction.NameLocalized) ?? "";
		}

		public static string GetLocalizedFactionFriendliness(HumanoidInstance npcInstance)
		{
			return GetLocalizedFactionFriendliness(npcInstance.Faction);
		}

		public static string GetLocalizedFactionFriendliness(FactionInstance factionInstance)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText("faction_status") + ": " + factionInstance.GetFriendlinessTextColored();
		}

		public static string GetLocalizedFactionAlignment(HumanoidInstance npcInstance)
		{
			return GetLocalizedFactionAlignment(npcInstance.Faction);
		}

		public static string GetLocalizedFactionAlignment(FactionInstance factionInstance)
		{
			int num = Mathf.RoundToInt(Mathf.Clamp(factionInstance.PlayerFriendliness, -100f, 100f));
			Color gradientColor = ColorTools.GetGradientColor(num + 100, 200f, MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.GetFriendlinessColors());
			string text = ColorUtils.ColorText($"{num}%", gradientColor);
			return UiUtils.Localize.GetText("faction_player_friendliness") + ": " + text;
		}
	}
}
