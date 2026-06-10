using UnityEngine.Localization;

public static class AchievementLocalizationHelper
{
	public static string GetLocalizedFishName(string speciesName)
	{
		if (string.IsNullOrEmpty(speciesName))
		{
			return speciesName;
		}
		string text = "#fish." + speciesName.ToLower().Replace(" ", "_") + ".name";
		string localizedString = new LocalizedString("Skills", text).GetLocalizedString();
		if (!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#fish"))
		{
			return localizedString;
		}
		return speciesName;
	}

	public static string GetLocalizedRarity(string rarityName)
	{
		if (string.IsNullOrEmpty(rarityName))
		{
			return rarityName;
		}
		string text = "#fish.rarity." + rarityName.ToLower();
		string localizedString = new LocalizedString("Skills", text).GetLocalizedString();
		if (!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#fish"))
		{
			return localizedString;
		}
		return rarityName;
	}
}
