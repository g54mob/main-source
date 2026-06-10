using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Game/Achievement")]
public class Achievement : ScriptableObject
{
	[Header("Static Data - From JSON")]
	public string ID;

	public string achievementName;

	[TextArea]
	public string description;

	public Sprite icon;

	public string category;

	public AchievementRequirementType requirementType;

	public string requirementTarget;

	public int requirementValue;

	public float rewardValue;

	[Header("Bonus Reward")]
	public SkillBonusType rewardBonusType;

	public bool isHidden;

	[Tooltip("Controls display order in the achievements panel. Lower = shown first. Set automatically by CSV row order during import.")]
	public int displayOrder;

	private static readonly Dictionary<AchievementRequirementType, string> RequirementTypeFallbacks = new Dictionary<AchievementRequirementType, string>
	{
		{
			AchievementRequirementType.total_fish_caught,
			"Total Fish Caught"
		},
		{
			AchievementRequirementType.catch_specific_fish,
			"Fish Caught"
		},
		{
			AchievementRequirementType.catch_rarity,
			"Rarity Fish Caught"
		},
		{
			AchievementRequirementType.total_money_earned,
			"Total Money Earned"
		},
		{
			AchievementRequirementType.total_xp_earned,
			"Total XP Earned"
		},
		{
			AchievementRequirementType.perfect_catches,
			"Perfect Catches"
		},
		{
			AchievementRequirementType.critical_clicks,
			"Critical Clicks"
		},
		{
			AchievementRequirementType.passive_income_earned,
			"Passive Income Earned"
		},
		{
			AchievementRequirementType.passive_fish_caught,
			"Passive Fish Caught"
		},
		{
			AchievementRequirementType.skills_unlocked,
			"Skills Unlocked"
		},
		{
			AchievementRequirementType.energy_expended,
			"Energy Expended"
		},
		{
			AchievementRequirementType.days_completed,
			"Days Completed"
		},
		{
			AchievementRequirementType.multi_catches,
			"Multi Catches"
		},
		{
			AchievementRequirementType.catch_all_zone_species,
			"Zone Completion"
		},
		{
			AchievementRequirementType.legendary_all_species,
			"Legendary Collection"
		},
		{
			AchievementRequirementType.all_skills_maxed,
			"All Skills Maxed"
		},
		{
			AchievementRequirementType.perfect_catch_streak,
			"Perfect Catch Streak"
		},
		{
			AchievementRequirementType.multi_catch_streak,
			"Multi Catch Streak"
		},
		{
			AchievementRequirementType.triple_catches,
			"Triple Catches"
		},
		{
			AchievementRequirementType.one_shot_catch,
			"One Shot Catches"
		}
	};

	private string GetLocalizedTarget()
	{
		return requirementType switch
		{
			AchievementRequirementType.catch_specific_fish => AchievementLocalizationHelper.GetLocalizedFishName(requirementTarget), 
			AchievementRequirementType.catch_rarity => AchievementLocalizationHelper.GetLocalizedRarity(requirementTarget), 
			_ => requirementTarget, 
		};
	}

	public string GetLocalizedName()
	{
		string localizedString = new LocalizedString("Skills", "#ach." + ID + ".name").GetLocalizedString();
		if (!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#ach"))
		{
			return localizedString;
		}
		return achievementName;
	}

	public string GetLocalizedDescription()
	{
		string localizedString = new LocalizedString("Skills", "#ach." + ID + ".desc").GetLocalizedString();
		if (!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#ach"))
		{
			return localizedString;
		}
		string localizedTarget = GetLocalizedTarget();
		switch (requirementType)
		{
		case AchievementRequirementType.total_fish_caught:
			return FormatTemplate("#ach.desc.catch.total", $"Catch {requirementValue} fish in total.", requirementValue);
		case AchievementRequirementType.catch_specific_fish:
			if (requirementValue <= 1)
			{
				return FormatTemplate("#ach.desc.catch.species.first", "Catch your first " + localizedTarget + ".", localizedTarget);
			}
			return FormatTemplate("#ach.desc.catch.species.n", $"Catch {requirementValue} {localizedTarget}.", requirementValue, localizedTarget);
		case AchievementRequirementType.catch_rarity:
			return FormatTemplate("#ach.desc.catch.rarity", $"Catch {requirementValue} {localizedTarget} fish.", requirementValue, localizedTarget);
		case AchievementRequirementType.total_money_earned:
			return FormatTemplate("#ach.desc.earn.money", $"${requirementValue} total earned.", requirementValue);
		case AchievementRequirementType.total_xp_earned:
			return FormatTemplate("#ach.desc.earn.xp", $"Earn {requirementValue} Total XP.", requirementValue);
		case AchievementRequirementType.catch_all_zone_species:
			return FormatTemplate("#ach.desc.catch.allzone", "Catch every species in " + requirementTarget + ".", requirementTarget);
		case AchievementRequirementType.legendary_all_species:
			return "Catch a Legendary of every fish species.";
		case AchievementRequirementType.all_skills_maxed:
			return "Buy every skill in the skill tree.";
		case AchievementRequirementType.perfect_catch_streak:
			return $"Land {requirementValue} perfect catches in a row.";
		case AchievementRequirementType.multi_catch_streak:
			return $"Get {requirementValue} multi-catches in a row.";
		case AchievementRequirementType.triple_catches:
			return $"Trigger {requirementValue} triple catches.";
		case AchievementRequirementType.one_shot_catch:
			return "Catch a fish with a single click.";
		default:
			return description;
		}
	}

	private string FormatTemplate(string key, string fallback, params object[] args)
	{
		string text = new LocalizedString("Skills", key).GetLocalizedString();
		if (string.IsNullOrEmpty(text) || text.StartsWith("#"))
		{
			text = fallback;
		}
		try
		{
			return string.Format(text, args);
		}
		catch
		{
			return fallback;
		}
	}

	public string GetLocalizedRequirementType()
	{
		string text = "#ui.achreq." + requirementType.ToString().Replace("_", ".");
		string localizedString = new LocalizedString("Skills", text).GetLocalizedString();
		if (string.IsNullOrEmpty(localizedString) || localizedString.StartsWith("#ui"))
		{
			if (RequirementTypeFallbacks.TryGetValue(requirementType, out var value))
			{
				return value;
			}
			string str = requirementType.ToString().Replace("_", " ");
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
		}
		return localizedString;
	}
}
