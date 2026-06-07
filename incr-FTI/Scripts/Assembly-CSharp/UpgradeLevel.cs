using System.Collections.Generic;

public class UpgradeLevel
{
	public readonly UpgradeLevelDef def;

	public List<Requirement> unlockRequirements;

	private readonly Upgrade parentUpgrade;

	public int levelIndex;

	public UpgradeLevel(Upgrade parent, UpgradeLevelDef levelDef, int index)
	{
		parentUpgrade = parent;
		def = levelDef;
		levelIndex = index;
	}

	public List<Requirement> ConfirmedRequirements()
	{
		if (unlockRequirements == null)
		{
			unlockRequirements = new List<Requirement>();
			if (parentUpgrade.parentTown == null)
			{
				foreach (RequirementId unlockRequirement in def.unlockRequirements)
				{
					unlockRequirements.Add(GameManager.Instance.GetCachedWorldRequirement(unlockRequirement));
				}
			}
			else
			{
				foreach (RequirementId unlockRequirement2 in def.unlockRequirements)
				{
					unlockRequirements.Add(parentUpgrade.parentTown.GetCachedRequirement(unlockRequirement2));
				}
			}
		}
		return unlockRequirements;
	}

	public void Unlock()
	{
		if (GameManager.Instance.gameState != GameState.InGame || !GameManager.IsGlobalQuestComplete(QuestType.ResearchForUpgrades))
		{
			return;
		}
		parentUpgrade.isInAlertState = true;
		if (parentUpgrade.parentTown == MenuManager.Instance.upgradesPanel.displayedTown)
		{
			MenuManager.Instance.upgradesPanel.isTownLayoutStale = true;
		}
		if (!parentUpgrade.parentTown.suppressUnlockNotifications && parentUpgrade.parentTown == GameManager.Instance.activeTown)
		{
			MenuManager.Instance.OnStateBecameAvailableInActiveTownDuringGame(this);
			if (ShouldDisplayUnlockNotification())
			{
				GameManager.Instance.TryAddUnlock(EntityId.FromUpgrade(def.parentUpgradeType), levelIndex);
			}
		}
	}

	public bool ShouldDisplayUnlockNotification()
	{
		if (levelIndex == 0)
		{
			return true;
		}
		foreach (Requirement unlockRequirement in unlockRequirements)
		{
			if (!(unlockRequirement is RequiredUpgrade requiredUpgrade) || requiredUpgrade.upgradeType != parentUpgrade.type)
			{
				return true;
			}
		}
		return false;
	}
}
