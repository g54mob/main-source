using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeUI : MonoBehaviour
{
	[SerializeField]
	private Image upgradeImage;

	[SerializeField]
	private Image frame;

	[SerializeField]
	private Image ownedFrame;

	[SerializeField]
	private Image lineImage;

	[SerializeField]
	private GameObject costGroup;

	[SerializeField]
	private TextMeshProUGUI costText;

	[SerializeField]
	private GameObject lockImage;

	[Space(15f)]
	[SerializeField]
	private Color defaultImageColor = Color.white;

	[SerializeField]
	private Color ownedImageColor = Color.white;

	[SerializeField]
	private Color lockedImageColor = Color.gray;

	[Space(15f)]
	[SerializeField]
	private Color defaultFrameColor = Color.white;

	[SerializeField]
	private Color ownedFrameColor = Color.white;

	[SerializeField]
	private Color lockedFrameColor = Color.gray;

	[Space(15f)]
	[SerializeField]
	private Color defaultCostTextColor = Color.white;

	[SerializeField]
	private Color cantAffordCostTextColor = Color.gray;

	[Space(15f)]
	[SerializeField]
	private PlayerUpgrade playerUpgrade;

	[SerializeField]
	private PlayerUpgradeUI[] requiredUpgrades;

	[SerializeField]
	private PlayerUpgradeUI[] grantedUpgrades;

	[Header("Demo")]
	[SerializeField]
	public bool availableInDemo;

	public PlayerUpgrade PlayerUpgrade => playerUpgrade;

	public Image LineImage => lineImage;

	public event Action<PlayerUpgradeUI> onPlayerUpgradeUIPressed;

	private void OnEnable()
	{
		UpdateInfo();
	}

	private void OnValidate()
	{
		if ((bool)playerUpgrade)
		{
			if ((bool)upgradeImage)
			{
				upgradeImage.sprite = playerUpgrade.Icon;
			}
			if ((bool)costText)
			{
				costText.text = playerUpgrade.Cost.ToString();
			}
		}
	}

	public void UpdateInfo()
	{
		if ((bool)upgradeImage)
		{
			upgradeImage.sprite = PlayerUpgrade.Icon;
			if (!AreRequiredUpgradesUnlocked())
			{
				upgradeImage.color = lockedImageColor;
				frame.color = lockedFrameColor;
				SetRequiredUpgradesLinesColor(lockedFrameColor);
			}
			else if (!IsUnlocked())
			{
				upgradeImage.color = defaultImageColor;
				frame.color = defaultFrameColor;
				SetRequiredUpgradesLinesColor(defaultFrameColor * 0.75f);
			}
			else if (IsUnlocked())
			{
				upgradeImage.color = ownedImageColor;
				frame.color = ownedFrameColor;
				SetRequiredUpgradesLinesColor(ownedFrameColor);
			}
		}
		costText.text = PlayerUpgrade.Cost.ToString();
		costText.color = (CanBuy() ? defaultCostTextColor : cantAffordCostTextColor);
		costGroup.SetActive(AreRequiredUpgradesUnlocked() && !IsUnlocked());
		lockImage.gameObject.SetActive(!AreRequiredUpgradesUnlocked());
		ownedFrame.gameObject.SetActive(IsUnlocked());
	}

	public bool IsUnlocked()
	{
		if (!playerUpgrade.UnlockedByDefault)
		{
			return LTFunctionLibrary.GetPlayerUpgradesManager().HasUnlockedUpgrade(PlayerUpgrade);
		}
		return true;
	}

	public void OnUpgradePressed()
	{
		this.onPlayerUpgradeUIPressed?.Invoke(this);
	}

	public bool CanAfford()
	{
		return LTFunctionLibrary.GetPlayerUpgradesManager().CanAfford(PlayerUpgrade);
	}

	public bool AreRequiredUpgradesUnlocked()
	{
		PlayerUpgradeUI[] array = requiredUpgrades;
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].IsUnlocked())
			{
				return false;
			}
		}
		return true;
	}

	public bool CanBuy()
	{
		if (AreRequiredUpgradesUnlocked())
		{
			return CanAfford();
		}
		return false;
	}

	public void UnlockUpgrade()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().UnlockUpgrade(PlayerUpgrade, unlockedByPlayer: true);
		PlayerUpgradeUI[] array = grantedUpgrades;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UnlockUpgrade();
		}
	}

	private void SetRequiredUpgradesLinesColor(Color color)
	{
		PlayerUpgradeUI[] array = requiredUpgrades;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].LineImage.color = color;
		}
	}
}
