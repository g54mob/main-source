using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerUpgradesManager : MonoBehaviour, ISavable
{
	public static PlayerUpgradesManager instance;

	[Savable("money", true, false)]
	private int money;

	[SerializeField]
	private float refundMultiplier = 0.5f;

	[SerializeField]
	private List<PlayerUpgrade> projectPlayerUpgrades;

	private List<PlayerUpgrade> unlockedUpgrades;

	[Savable("unlockedUpgradesIDs", true, false)]
	private List<string> unlockedUpgradesIDs;

	[Header("Debug")]
	[SerializeField]
	private bool freeCosts;

	public int Money
	{
		get
		{
			return money;
		}
		private set
		{
			money = value;
			this.onMoneyChanged?.Invoke(money);
			SaveSystem.instance.SaveData();
		}
	}

	public List<PlayerUpgrade> UnlockedUpgrades
	{
		get
		{
			return unlockedUpgrades;
		}
		private set
		{
			unlockedUpgrades = value;
		}
	}

	public float RefundMultiplier => refundMultiplier;

	public event Action<int> onMoneyChanged;

	public event Action onPlayerUpgradesLoaded;

	public event Action onPlayerUpgradesRefunded;

	public event Action<PlayerUpgrade, bool> onPlayerUpgradeUnlocked;

	private void Awake()
	{
		if (!instance)
		{
			instance = this;
			UnlockedUpgrades = new List<PlayerUpgrade>();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void UnlockDefaultUpgrades()
	{
		foreach (PlayerUpgrade projectPlayerUpgrade in projectPlayerUpgrades)
		{
			if (projectPlayerUpgrade.UnlockedByDefault)
			{
				UnlockUpgrade(projectPlayerUpgrade, unlockedByPlayer: false);
			}
		}
	}

	public void AddMoney(int moneyToAdd)
	{
		Money += moneyToAdd;
	}

	public bool CanAfford(int amountToCheck)
	{
		return Money >= amountToCheck;
	}

	public bool CanAfford(PlayerUpgrade playerUpgrade)
	{
		return Money >= playerUpgrade.Cost;
	}

	private bool PayMoney(int moneyToPay)
	{
		if (CanAfford(moneyToPay))
		{
			Money -= moneyToPay;
			return true;
		}
		return false;
	}

	public bool UnlockUpgrade(PlayerUpgrade upgradeToUnlock, bool unlockedByPlayer)
	{
		if (!HasUnlockedUpgrade(upgradeToUnlock) && PayMoney(upgradeToUnlock.Cost))
		{
			UnlockedUpgrades.Add(upgradeToUnlock);
			this.onPlayerUpgradeUnlocked?.Invoke(upgradeToUnlock, unlockedByPlayer);
			SaveSystem.instance.SaveData();
			return true;
		}
		return false;
	}

	public void RefundUpgrades()
	{
		PayMoney(-GetTotalUnlockedUpgradesCost(applyRefundMultiplier: true));
		UnlockedUpgrades.Clear();
		UnlockDefaultUpgrades();
		SaveSystem.instance.SaveData();
		this.onPlayerUpgradesLoaded?.Invoke();
		this.onPlayerUpgradesRefunded?.Invoke();
	}

	public int GetTotalUnlockedUpgradesCost(bool applyRefundMultiplier)
	{
		int num = 0;
		foreach (PlayerUpgrade unlockedUpgrade in UnlockedUpgrades)
		{
			num += unlockedUpgrade.Cost;
		}
		if (applyRefundMultiplier && refundMultiplier != 1f)
		{
			num = Mathf.CeilToInt((float)num * RefundMultiplier);
		}
		return num;
	}

	public bool HasUnlockedUpgrade(PlayerUpgrade playerUpgrade)
	{
		return UnlockedUpgrades.Contains(playerUpgrade);
	}

	public bool HasUnlockedUpgrade(string id)
	{
		return UnlockedUpgrades.Any((PlayerUpgrade x) => x.Id == id);
	}

	public bool RemoveUnlockedUpgrade(PlayerUpgrade upgradeToRemove)
	{
		bool result = unlockedUpgrades.Remove(upgradeToRemove);
		SaveSystem.instance.SaveData();
		return result;
	}

	public List<PlayerUpgrade> GetAllUpgrades()
	{
		return projectPlayerUpgrades;
	}

	public List<PlayerUpgrade> GetAllAvailableUpgrades()
	{
		List<PlayerUpgrade> list = new List<PlayerUpgrade>();
		List<PlayerUpgrade> list2 = new List<PlayerUpgrade>();
		list2.AddRange(unlockedUpgrades);
		foreach (PlayerUpgrade unlockedUpgrade in unlockedUpgrades)
		{
			PlayerUpgrade[] upgradesToLock = unlockedUpgrade.UpgradesToLock;
			foreach (PlayerUpgrade item in upgradesToLock)
			{
				list.Add(item);
			}
		}
		foreach (PlayerUpgrade item2 in list)
		{
			list2.Remove(item2);
		}
		return list2;
	}

	public void OnSave()
	{
		unlockedUpgradesIDs = new List<string>();
		foreach (PlayerUpgrade unlockedUpgrade in unlockedUpgrades)
		{
			unlockedUpgradesIDs.Add(unlockedUpgrade.Id);
		}
	}

	public void OnPreLoad()
	{
		unlockedUpgrades.Clear();
		money = 0;
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething && data.ContainsKey("unlockedUpgradesIDs"))
		{
			unlockedUpgradesIDs = data["unlockedUpgradesIDs"] as List<string>;
			foreach (string unlockedUpgradesID in unlockedUpgradesIDs)
			{
				for (int i = 0; i < projectPlayerUpgrades.Count; i++)
				{
					if ((bool)projectPlayerUpgrades[i] && (projectPlayerUpgrades[i].Id == unlockedUpgradesID || (projectPlayerUpgrades[i].OldIds != null && projectPlayerUpgrades[i].OldIds.Contains(unlockedUpgradesID))) && !HasUnlockedUpgrade(projectPlayerUpgrades[i]))
					{
						unlockedUpgrades.Add(projectPlayerUpgrades[i]);
					}
				}
			}
		}
		UnlockDefaultUpgrades();
		this.onPlayerUpgradesLoaded?.Invoke();
	}
}
