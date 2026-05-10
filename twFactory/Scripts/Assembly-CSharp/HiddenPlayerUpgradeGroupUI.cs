using UnityEngine;

public class HiddenPlayerUpgradeGroupUI : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Player Upgrade que tiene que estar desbloqueada para que este grupo sea visible")]
	private PlayerUpgrade upgradeToCheck;

	private void Start()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradeUnlocked += OnPlayerUpgradeUnlocked;
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded += OnPlayerUpgradesLoaded;
		OnPlayerUpgradesLoaded();
	}

	private void OnDestroy()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradeUnlocked -= OnPlayerUpgradeUnlocked;
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesLoaded -= OnPlayerUpgradesLoaded;
	}

	private void OnPlayerUpgradesLoaded()
	{
		if (LTFunctionLibrary.GetPlayerUpgradesManager().HasUnlockedUpgrade(upgradeToCheck))
		{
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnPlayerUpgradeUnlocked(PlayerUpgrade upgrade, bool unlockedByPlayer)
	{
		if (upgrade == upgradeToCheck)
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
