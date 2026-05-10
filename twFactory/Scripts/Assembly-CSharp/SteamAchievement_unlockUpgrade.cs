using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_unlockUpgrade_default", menuName = "Tower Factory/Steam Achievements/Unlock Upgrade")]
public class SteamAchievement_unlockUpgrade : SteamAchievement
{
	[Header("Unlock Upgrade")]
	[SerializeField]
	private PlayerUpgrade[] upgradesToUnlock;

	private Dictionary<PlayerUpgrade, bool> unlockedUpgrades;

	public override void StartAchievement()
	{
		base.StartAchievement();
		unlockedUpgrades = new Dictionary<PlayerUpgrade, bool>();
		PlayerUpgrade[] array = upgradesToUnlock;
		foreach (PlayerUpgrade playerUpgrade in array)
		{
			unlockedUpgrades.Add(playerUpgrade, LTFunctionLibrary.GetPlayerUpgradesManager().UnlockedUpgrades.Contains(playerUpgrade));
		}
		if (!CheckAllUpgradesUnlocked())
		{
			LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradeUnlocked += OnPlayerUpgradeUnlocked;
			LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded += OnPlayerUpgradesLoaded;
		}
	}

	private bool CheckAllUpgradesUnlocked()
	{
		foreach (PlayerUpgrade key in unlockedUpgrades.Keys)
		{
			if (!unlockedUpgrades[key])
			{
				return false;
			}
		}
		UnlockAchievement();
		return true;
	}

	private void OnPlayerUpgradesLoaded()
	{
		foreach (PlayerUpgrade item in unlockedUpgrades.Keys.ToList())
		{
			unlockedUpgrades[item] = LTFunctionLibrary.GetPlayerUpgradesManager().UnlockedUpgrades.Contains(item);
		}
		CheckAllUpgradesUnlocked();
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded -= OnPlayerUpgradesLoaded;
	}

	private void OnPlayerUpgradeUnlocked(PlayerUpgrade upgrade, bool unlockedByPlayer)
	{
		if (unlockedUpgrades.ContainsKey(upgrade))
		{
			unlockedUpgrades[upgrade] = true;
			if (CheckAllUpgradesUnlocked())
			{
				LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradeUnlocked -= OnPlayerUpgradeUnlocked;
			}
		}
	}
}
