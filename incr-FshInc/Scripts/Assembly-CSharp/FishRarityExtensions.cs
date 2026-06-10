using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public static class FishRarityExtensions
{
	public static string GetLocalizedText(this FishRarity rarity)
	{
		string key = "#fish.rarity." + rarity.ToString().ToLower();
		StringTableEntry stringTableEntry = LocalizationSettings.StringDatabase.GetTable("Skills")?.GetEntry(key);
		if (stringTableEntry == null || string.IsNullOrEmpty(stringTableEntry.GetLocalizedString()))
		{
			return rarity.ToString();
		}
		return stringTableEntry.GetLocalizedString();
	}
}
