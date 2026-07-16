using UnityEngine;
using UnityEngine.Localization;

public abstract class EnhancementUpgrade : Enhancement
{
	public int maxQuantity = 1;

	public bool IsEnabled { get; private set; }

	[field: SerializeField]
	public string ModulesTag { get; private set; }

	[field: SerializeField]
	public LocalizedString ModuleTagKey { get; set; }

	[field: SerializeField]
	[field: Tooltip("Which stats objects this upgrade should apply itself to. For this upgrade to be presented, the UpgradeManager needs at least one of these stats objects present to be applied to.")]
	public Stats[] StatsObjectsToUpgrade { get; private set; }

	[field: SerializeField]
	[field: NonReorderable]
	public EnhancementUpgrade[] UpgradesExclusiveTo { get; private set; }

	[field: SerializeField]
	[field: NonReorderable]
	[field: Tooltip("Which upgrades are required to be offered this upgrade.")]
	public EnhancementUpgrade[] PrerequisiteUpgrades { get; private set; }

	[field: SerializeField]
	[field: NonReorderable]
	[field: Tooltip("Which modules are required to be offered this upgrade.")]
	public EnhancementModule[] RequiredModules { get; private set; }

	[field: SerializeField]
	[field: NonReorderable]
	[field: Tooltip("Remove prerequisite upgrades upon taking this upgrade if true.")]
	public bool ShouldRemovePrerequisites { get; private set; }

	[field: SerializeField]
	[field: NonReorderable]
	[field: Tooltip("Check if you want this upgrade to skip LootUtils eligibility check. CRITICAL! CHECK ONLY IF NEEDED")]
	public bool IgnoreChecks { get; private set; }

	[field: SerializeField]
	public bool IsRelic { get; private set; }

	public virtual void ApplyUpgrade()
	{
	}

	public virtual void UpdateUpgrade()
	{
	}

	public virtual void ResetUpgrade()
	{
	}

	public virtual void OnRemove()
	{
	}

	public override string GetEnhancementType()
	{
		if (IsRelic)
		{
			return $"<color=#{ColorUtils.ColorToHex(UIManager.Instance.RarityColor(base.Rarity))}>{base.Rarity} Relic</color>";
		}
		return $"<color=#{ColorUtils.ColorToHex(UIManager.Instance.RarityColor(base.Rarity))}>{base.Rarity} {ModulesTag} Upgrade</color>";
	}

	public override string GetEnhancementSimplified()
	{
		if (IsRelic)
		{
			return "<color=#" + ColorUtils.ColorToHex(UIManager.Instance.RarityColor(base.Rarity)) + ">Relic</color>";
		}
		return "<color=#" + ColorUtils.ColorToHex(UIManager.Instance.RarityColor(base.Rarity)) + ">" + ModulesTag + " Upgrade</color>";
	}
}
