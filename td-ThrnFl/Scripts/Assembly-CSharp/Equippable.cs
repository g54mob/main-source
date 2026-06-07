using UnityEngine;

public class Equippable : ScriptableObject
{
	public enum UnlockRequirement
	{
		MetaLevel = 0,
		CampaignProgress = 1
	}

	public enum LevelName
	{
		DefaultUnlocked = 0,
		Nordfels = 1,
		Durststein = 2,
		Frostsee = 3,
		Uferwind = 4,
		Sturmklamm = 5,
		Wildbach = 6,
		Moorweg = 7,
		Freifort = 8,
		Totend = 9
	}

	public Sprite icon;

	public string displayName;

	[TextArea]
	public string description;

	public UnlockRequirement unlockRequirement;

	public LevelName requiredBeatenLevel;

	public string LOCIDENTIFIER_NAME => "Equippable/" + displayName;

	public string LOCIDENTIFIER_DESCRIPTION => LOCIDENTIFIER_NAME + " Description";

	private bool UnlockIsCampaignProgress => unlockRequirement == UnlockRequirement.CampaignProgress;

	private bool UnlockIsMetaLevel => unlockRequirement == UnlockRequirement.MetaLevel;

	public int sortingValue
	{
		get
		{
			if (!UnlockIsCampaignProgress)
			{
				return PerkManager.instance.metaLevelByPerk[this];
			}
			return (int)requiredBeatenLevel;
		}
	}

	public bool IsUnlocked
	{
		get
		{
			if (unlockRequirement == UnlockRequirement.MetaLevel)
			{
				if (PerkManager.instance.metaLevelByPerk.ContainsKey(this))
				{
					return PerkManager.instance.level > PerkManager.instance.metaLevelByPerk[this];
				}
				return true;
			}
			if (requiredBeatenLevel == LevelName.DefaultUnlocked)
			{
				return true;
			}
			return LevelProgressManager.instance.GetLevelInfoFromSceneName(requiredBeatenLevel.ToString()).Beaten;
		}
	}

	public string GetLockedTooltip()
	{
		if (unlockRequirement == UnlockRequirement.CampaignProgress)
		{
			return TextTranslator.TranslateAndInsertMapName("Menu/Beat Map to Unlock Cue", requiredBeatenLevel.ToString(), highlighted: true);
		}
		int targetLevel = 1;
		if (PerkManager.instance.metaLevelByPerk.ContainsKey(this))
		{
			targetLevel = PerkManager.instance.metaLevelByPerk[this] + 1;
		}
		return TextTranslator.TranslateAndInsertLevelNumber("Menu/Reach Level to Unlock Cue", targetLevel, highlighted: true);
	}
}
