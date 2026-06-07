using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelHelper : MonoBehaviour
{
	public static ShopPanelHelper Singleton;

	[SerializeField]
	private Color canAfford_BuyButton_Color;

	[SerializeField]
	private Color cannotAfford_BuyButton_Color;

	[SerializeField]
	private Gradient upgradeLevelBar_ColorGradient;

	private const string MAXLEVEL_STRING = "MAX";

	[Header("Shop Groups")]
	[SerializeField]
	private List<GameObject> shopGroups;

	public int lastVisibleShopGroupIndex;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	public void UpdateStorePanelInfo(ShopPanel _shopPanel)
	{
		switch (_shopPanel.shopIdentity)
		{
		case ShopPanelIdentity.DirtPatch:
			UpdatePanel_DirtPatch(_shopPanel);
			break;
		case ShopPanelIdentity.PiggyBank_Capacity:
			UpdatePanel_PiggyBankCapacity(_shopPanel);
			break;
		case ShopPanelIdentity.PiggyBank_CanSuckSeeds:
			UpdatePanel_PiggyBank_SeedVacuum(_shopPanel);
			break;
		case ShopPanelIdentity.ConveyorBelt:
			UpdatePanel_ConveyorBelt(_shopPanel);
			break;
		case ShopPanelIdentity.Trampoline:
			UpdatePanel_Trampoline(_shopPanel);
			break;
		case ShopPanelIdentity.Turtle_EatSpeed:
			UpdatePanel_TurtleEatSpeed(_shopPanel);
			break;
		case ShopPanelIdentity.SeedDropRate:
			UpdatePanel_SeedDropRate(_shopPanel);
			break;
		case ShopPanelIdentity.Turtle_BonusCoins:
			UpdatePanel_BonusCoinsUpgrade(_shopPanel);
			break;
		case ShopPanelIdentity.TrickShotBonus:
			UpdatePanel_TrickShotUpgrade(_shopPanel);
			break;
		case ShopPanelIdentity.GrowthRate:
			UpdatePanel_GrowthRateUpgrade(_shopPanel);
			break;
		case ShopPanelIdentity.GoldenBerryChance:
			UpdatePanel_GoldenBerryChance(_shopPanel);
			break;
		case ShopPanelIdentity.GoldenBerryMulti:
			UpdatePanel_GoldenBerryMulti(_shopPanel);
			break;
		case ShopPanelIdentity.BonusTile_Additional:
			UpdatePanel_BonusTile(_shopPanel);
			break;
		case ShopPanelIdentity.BonusTile_BonusXP:
			UpdatePanel_BonusTileXpMulti(_shopPanel);
			break;
		case ShopPanelIdentity.GoldRush_Duration:
			UpdatePanel_GoldRushDuration(_shopPanel);
			break;
		case ShopPanelIdentity.GoldRush_Cooldown:
			UpdatePanel_GoldRushCooldown(_shopPanel);
			break;
		case ShopPanelIdentity.Blender:
			UpdatePanel_Blender(_shopPanel);
			break;
		}
	}

	public int GetDirtPatchPriceFromPurchasedAmount()
	{
		if (!ShopAndUpgradesManager.Singleton)
		{
			return 0;
		}
		int dirtPatch_NumOfPurchased = PlayerStats.Singleton.dirtPatch_NumOfPurchased;
		float num = ShopAndUpgradesManager.Singleton.dirtPatch_BasePrice;
		for (int i = 0; i < dirtPatch_NumOfPurchased; i++)
		{
			num *= ShopAndUpgradesManager.Singleton.dirtPatch_CostIncreaseMultiPer;
		}
		return Mathf.FloorToInt(num);
	}

	public int GetConveyorBeltPriceFromPurchasedAmount()
	{
		if (!ShopAndUpgradesManager.Singleton)
		{
			return 0;
		}
		int conveyorBelt_NumOfPacksPurchased = PlayerStats.Singleton.conveyorBelt_NumOfPacksPurchased;
		float num = ShopAndUpgradesManager.Singleton.conveyorBelt_BasePrice;
		for (int i = 0; i < conveyorBelt_NumOfPacksPurchased; i++)
		{
			num *= ShopAndUpgradesManager.Singleton.conveyorBelt_CostIncreaseMultiPer;
		}
		return Mathf.FloorToInt(num);
	}

	public int GetTrampolinePriceFromPurchasedAmount()
	{
		if (!ShopAndUpgradesManager.Singleton)
		{
			return 0;
		}
		int trampolines_NumOfPurchased = PlayerStats.Singleton.trampolines_NumOfPurchased;
		float num = ShopAndUpgradesManager.Singleton.trampolines_BasePrice;
		for (int i = 0; i < trampolines_NumOfPurchased; i++)
		{
			num *= ShopAndUpgradesManager.Singleton.trampolines_CostIncreaseMultiPer;
		}
		return Mathf.FloorToInt(num);
	}

	public int GetBlenderPriceFromPurchasedAmount()
	{
		if (!ShopAndUpgradesManager.Singleton)
		{
			return 0;
		}
		int blenders_NumOfPurchased = PlayerStats.Singleton.blenders_NumOfPurchased;
		float num = ShopAndUpgradesManager.Singleton.blenders_BasePrice;
		for (int i = 0; i < blenders_NumOfPurchased; i++)
		{
			num *= ShopAndUpgradesManager.Singleton.blenders_CostIncreaseMultiPer;
		}
		return Mathf.FloorToInt(num);
	}

	private void UpdatePanel_DirtPatch(ShopPanel _shopPanel)
	{
		int dirtPatchPriceFromPurchasedAmount = GetDirtPatchPriceFromPurchasedAmount();
		UpdatePanelPart_BuyButton(_shopPanel.buyButton, dirtPatchPriceFromPurchasedAmount);
		_shopPanel.currentLevel_Parent.gameObject.SetActive(value: false);
		UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "+1 Dirt Patch");
		if (PlayerStats.Singleton.dirtPatch_NumOfPurchased == 0)
		{
			_shopPanel.placement_Parent.SetActive(value: false);
		}
		else
		{
			_shopPanel.placement_Parent.SetActive(value: true);
			if (PlayerStats.Singleton.dirtPatch_NumOfPurchased - PlayerStats.Singleton.dirtPatch_NumPlaced > 0)
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: true);
			}
			else
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: false);
			}
		}
		_shopPanel.placementText_NumberPlacedvsInventory.text = "Placed " + PlayerStats.Singleton.dirtPatch_NumPlaced + "/" + PlayerStats.Singleton.dirtPatch_NumOfPurchased;
	}

	private void UpdatePanel_ConveyorBelt(ShopPanel _shopPanel)
	{
		int conveyorBeltPriceFromPurchasedAmount = GetConveyorBeltPriceFromPurchasedAmount();
		UpdatePanelPart_BuyButton(_shopPanel.buyButton, conveyorBeltPriceFromPurchasedAmount);
		_shopPanel.currentLevel_Parent.gameObject.SetActive(value: false);
		UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "+" + PlayerStats.Singleton.conveyorBelt_NumOfBeltsPerPack + " Conveyor Belts");
		PlayerStats.Singleton.CalculateNumberOfIndividualConveyorBeltsOwned();
		if (PlayerStats.Singleton.conveyorBelt_NumOfIndividualConveyorBeltsOwned == 0)
		{
			_shopPanel.placement_Parent.SetActive(value: false);
		}
		else
		{
			_shopPanel.placement_Parent.SetActive(value: true);
			if (PlayerStats.Singleton.conveyorBelt_NumOfIndividualConveyorBeltsOwned - PlayerStats.Singleton.conveyorBelt_NumPlaced > 0)
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: true);
			}
			else
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: false);
			}
		}
		_shopPanel.placementText_NumberPlacedvsInventory.text = "Placed " + PlayerStats.Singleton.conveyorBelt_NumPlaced + "/" + PlayerStats.Singleton.conveyorBelt_NumOfIndividualConveyorBeltsOwned;
	}

	private void UpdatePanel_Trampoline(ShopPanel _shopPanel)
	{
		int trampolinePriceFromPurchasedAmount = GetTrampolinePriceFromPurchasedAmount();
		UpdatePanelPart_BuyButton(_shopPanel.buyButton, trampolinePriceFromPurchasedAmount);
		_shopPanel.currentLevel_Parent.gameObject.SetActive(value: false);
		UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "+1 Trampoline");
		if (PlayerStats.Singleton.trampolines_NumOfPurchased == 0)
		{
			_shopPanel.placement_Parent.SetActive(value: false);
		}
		else
		{
			_shopPanel.placement_Parent.SetActive(value: true);
			if (PlayerStats.Singleton.trampolines_NumOfPurchased - PlayerStats.Singleton.trampolines_NumPlaced > 0)
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: true);
			}
			else
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: false);
			}
		}
		_shopPanel.placementText_NumberPlacedvsInventory.text = "Placed " + PlayerStats.Singleton.trampolines_NumPlaced + "/" + PlayerStats.Singleton.trampolines_NumOfPurchased;
	}

	private void UpdatePanel_Blender(ShopPanel _shopPanel)
	{
		int blenderPriceFromPurchasedAmount = GetBlenderPriceFromPurchasedAmount();
		UpdatePanelPart_BuyButton(_shopPanel.buyButton, blenderPriceFromPurchasedAmount);
		_shopPanel.currentLevel_Parent.gameObject.SetActive(value: false);
		UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "+1 Juicer");
		if (PlayerStats.Singleton.blenders_NumOfPurchased == 0)
		{
			_shopPanel.placement_Parent.SetActive(value: false);
		}
		else
		{
			_shopPanel.placement_Parent.SetActive(value: true);
			if (PlayerStats.Singleton.blenders_NumOfPurchased - PlayerStats.Singleton.blenders_NumPlaced > 0)
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: true);
			}
			else
			{
				_shopPanel.placement_Button.gameObject.SetActive(value: false);
			}
		}
		_shopPanel.placementText_NumberPlacedvsInventory.text = "Placed " + PlayerStats.Singleton.blenders_NumPlaced + "/" + PlayerStats.Singleton.blenders_NumOfPurchased;
	}

	private void UpdatePanelPart_BuyButton(Button _button, long _price)
	{
		Color color = (CanAffordThisUpgrade_Money(_price) ? canAfford_BuyButton_Color : cannotAfford_BuyButton_Color);
		_button.image.color = color;
		_button.GetComponentInChildren<TMP_Text>().text = "$" + GameManager.Singleton.FormatMoney(_price);
	}

	private void UpdatePanelPart_LevelBarFill(Image _fillImage, int _currLevel, int _maxLevel)
	{
		float time = (_fillImage.fillAmount = (float)_currLevel / (float)_maxLevel);
		_fillImage.color = upgradeLevelBar_ColorGradient.Evaluate(time);
	}

	private void UpdatePanelPart_NextLevelInfo(TMP_Text _text, string _info)
	{
		_text.text = _info;
	}

	private void UpdatePanel_PiggyBankCapacity(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level >= ShopAndUpgradesManager.Singleton.piggyBank_Capacity_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Prices[ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level, ShopAndUpgradesManager.Singleton.piggyBank_Capacity_UpgradeDescriptions.Count);
		try
		{
			if (ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level == 0 || ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level == 5)
			{
				UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.piggyBank_Capacity_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level]);
			}
			else
			{
				UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.piggyBank_Capacity_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level] + " " + ShopAndUpgradesManager.Singleton.piggyBank_Capacity_LevelValues[ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level + 1]);
			}
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
		if (ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level > 0)
		{
			_shopPanel.childUpgrades[0].gameObject.SetActive(value: true);
		}
	}

	private void UpdatePanel_PiggyBank_SeedVacuum(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Level >= ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Prices[ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Level, 1);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_TurtleEatSpeed(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.turtleEatSpeed_Level >= ShopAndUpgradesManager.Singleton.turtleEatSpeed_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.turtleEatSpeed_Prices[ShopAndUpgradesManager.Singleton.turtleEatSpeed_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.turtleEatSpeed_Level, ShopAndUpgradesManager.Singleton.turtleEatSpeed_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.turtleEatSpeed_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.turtleEatSpeed_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_SeedDropRate(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.seedDropRate_Level >= ShopAndUpgradesManager.Singleton.seedDropRate_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.seedDropRate_Prices[ShopAndUpgradesManager.Singleton.seedDropRate_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.seedDropRate_Level, ShopAndUpgradesManager.Singleton.seedDropRate_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.seedDropRate_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.seedDropRate_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_BonusCoinsUpgrade(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Level >= ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Prices[ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Level, ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_TrickShotUpgrade(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level >= ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level_Prices[ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level, ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_GrowthRateUpgrade(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level >= ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level_Prices[ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level, ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_GoldenBerryChance(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level >= ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level_Prices[ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level, ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_GoldenBerryMulti(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level >= ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level_Prices[ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level, ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_BonusTile(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.bonusTile_Level >= ShopAndUpgradesManager.Singleton.bonusTile_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.bonusTile_Level_Prices[ShopAndUpgradesManager.Singleton.bonusTile_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.bonusTile_Level, ShopAndUpgradesManager.Singleton.bonusTile_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.bonusTile_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.bonusTile_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
		if (ShopAndUpgradesManager.Singleton.bonusTile_Level > 0)
		{
			_shopPanel.childUpgrades[0].gameObject.SetActive(value: true);
		}
	}

	private void UpdatePanel_BonusTileXpMulti(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level >= ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level_Prices[ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level, ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_GoldRushDuration(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.goldRushDuration_Level >= ShopAndUpgradesManager.Singleton.goldRushDuration_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.goldRushDuration_Level_Prices[ShopAndUpgradesManager.Singleton.goldRushDuration_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.goldRushDuration_Level, ShopAndUpgradesManager.Singleton.goldRushDuration_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.goldRushDuration_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.goldRushDuration_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private void UpdatePanel_GoldRushCooldown(ShopPanel _shopPanel)
	{
		if (ShopAndUpgradesManager.Singleton.goldRushCooldown_Level >= ShopAndUpgradesManager.Singleton.goldRushCooldown_Level_UpgradeDescriptions.Count)
		{
			_shopPanel.buyButton.gameObject.SetActive(value: false);
		}
		else
		{
			_shopPanel.buyButton.gameObject.SetActive(value: true);
			UpdatePanelPart_BuyButton(_shopPanel.buyButton, ShopAndUpgradesManager.Singleton.goldRushCooldown_Level_Prices[ShopAndUpgradesManager.Singleton.goldRushCooldown_Level]);
		}
		UpdatePanelPart_LevelBarFill(_shopPanel.currentLevel_FillBar, ShopAndUpgradesManager.Singleton.goldRushCooldown_Level, ShopAndUpgradesManager.Singleton.goldRushCooldown_Level_UpgradeDescriptions.Count);
		try
		{
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, ShopAndUpgradesManager.Singleton.goldRushCooldown_Level_UpgradeDescriptions[ShopAndUpgradesManager.Singleton.goldRushCooldown_Level]);
		}
		catch
		{
			Debug.Log("Max level or missing description data for this level. Leaving blank");
			UpdatePanelPart_NextLevelInfo(_shopPanel.nextLevelInfo, "MAX");
		}
	}

	private bool CanAffordThisUpgrade_Money(long _cost)
	{
		return PlayerStats.Singleton.money >= _cost;
	}

	public void BuyButton_DirtPatch()
	{
		if (CanAffordThisUpgrade_Money(GetDirtPatchPriceFromPurchasedAmount()))
		{
			PlayerStats.Singleton.SpendMoney(GetDirtPatchPriceFromPurchasedAmount());
			PlayerStats.Singleton.dirtPatch_NumOfPurchased++;
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
		else
		{
			Debug.Log("Can't afford this dirt patch!");
		}
	}

	public void PlacementButton_DirtPatch()
	{
		GameManager.Singleton.EnterBuildMode(GameManager.Singleton.prefabBank.buildable_DirtPatch, _snapToGrid: true, BuildModeRotationMode.SnapRotation_90, _cancelAfterPlacement: true, BuildableIdentity.DirtPatch);
	}

	public void BuyButton_ConveyorBelt()
	{
		if (CanAffordThisUpgrade_Money(GetConveyorBeltPriceFromPurchasedAmount()))
		{
			PlayerStats.Singleton.SpendMoney(GetConveyorBeltPriceFromPurchasedAmount());
			PlayerStats.Singleton.conveyorBelt_NumOfPacksPurchased++;
			PlayerStats.Singleton.CalculateNumberOfIndividualConveyorBeltsOwned();
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
		else
		{
			Debug.Log("Can't afford this conveyor pack!");
		}
	}

	public void PlacementButton_ConveyorBelt()
	{
		GameManager.Singleton.EnterBuildMode(GameManager.Singleton.prefabBank.buildable_ConveyorBelt, _snapToGrid: true, BuildModeRotationMode.SnapRotation_90, _cancelAfterPlacement: true, BuildableIdentity.ConveyorBelt);
	}

	public void BuyButton_Trampoline()
	{
		if (CanAffordThisUpgrade_Money(GetTrampolinePriceFromPurchasedAmount()))
		{
			PlayerStats.Singleton.SpendMoney(GetTrampolinePriceFromPurchasedAmount());
			PlayerStats.Singleton.trampolines_NumOfPurchased++;
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
		else
		{
			Debug.Log("Can't afford this trampoline!");
		}
	}

	public void PlacementButton_Trampoline()
	{
		GameManager.Singleton.EnterBuildMode(GameManager.Singleton.prefabBank.buildable_Trampoline, _snapToGrid: true, BuildModeRotationMode.SnapRotation_90, _cancelAfterPlacement: true, BuildableIdentity.Trampoline);
	}

	public void BuyButton_Blender()
	{
		if (CanAffordThisUpgrade_Money(GetBlenderPriceFromPurchasedAmount()))
		{
			PlayerStats.Singleton.SpendMoney(GetBlenderPriceFromPurchasedAmount());
			PlayerStats.Singleton.blenders_NumOfPurchased++;
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
		else
		{
			Debug.Log("Can't afford this Juicer!");
		}
	}

	public void PlacementButton_Blender()
	{
		GameManager.Singleton.EnterBuildMode(GameManager.Singleton.prefabBank.buildable_Blender, _snapToGrid: true, BuildModeRotationMode.SnapRotation_90, _cancelAfterPlacement: true, BuildableIdentity.Blender);
	}

	public void BuyButton_PiggyBankCapacity()
	{
		int num = ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Prices[ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.piggyBank_Capacity_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_PiggyBankCapacity();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_PiggyBankSeedVacuum()
	{
		int num = ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Prices[ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.piggyBank_CanPickUpSeeds_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValus_PiggyBankSeedVacuum();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_TurtleEatSpeed()
	{
		int num = ShopAndUpgradesManager.Singleton.turtleEatSpeed_Prices[ShopAndUpgradesManager.Singleton.turtleEatSpeed_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.turtleEatSpeed_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_TurtleEatSpeed();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_SeedDropRate()
	{
		int num = ShopAndUpgradesManager.Singleton.seedDropRate_Prices[ShopAndUpgradesManager.Singleton.seedDropRate_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.seedDropRate_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_SeedDropRate();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_BonusCoinsUpgrade()
	{
		int num = ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Prices[ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.bonusCoinsUpgrade_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_BonusCoinsUpgrade();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_TrickShotUpgrade()
	{
		int num = ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level_Prices[ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.trickShotUpgrade_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_TrickShotUpgrade();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_GrowthRate()
	{
		int num = ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level_Prices[ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.growthRateUpgrade_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_GrowthRateUpgrade();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_GoldenBerryChance()
	{
		int num = ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level_Prices[ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.goldenBerrySpawnChance_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_GoldenBerrySpawnRate();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_GoldenBerryMulti()
	{
		int num = ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level_Prices[ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.goldenBerryMulti_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_GoldenBerryMulti();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_BonusTile()
	{
		int num = ShopAndUpgradesManager.Singleton.bonusTile_Level_Prices[ShopAndUpgradesManager.Singleton.bonusTile_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.bonusTile_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_BonusTile();
			for (int i = 0; (float)i < ShopAndUpgradesManager.Singleton.bonusTile_Level_LevelValues[ShopAndUpgradesManager.Singleton.bonusTile_Level]; i++)
			{
				GameManager.Singleton.SpawnNewBonusXPTile();
			}
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_BonusTileXpMulti()
	{
		int num = ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level_Prices[ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.bonusTileXpMulti_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_BonusTileXpMulti();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_GoldRushDuration()
	{
		int num = ShopAndUpgradesManager.Singleton.goldRushDuration_Level_Prices[ShopAndUpgradesManager.Singleton.goldRushDuration_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.goldRushDuration_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_GoldRushDuration();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	public void BuyButton_GoldRushCooldown()
	{
		int num = ShopAndUpgradesManager.Singleton.goldRushCooldown_Level_Prices[ShopAndUpgradesManager.Singleton.goldRushCooldown_Level];
		if (CanAffordThisUpgrade_Money(num))
		{
			ShopAndUpgradesManager.Singleton.goldRushCooldown_Level++;
			ShopAndUpgradesManager.Singleton.SetLevelValues_GoldRushCooldown();
			PlayerStats.Singleton.SpendMoney(num);
			TogglePlayingAndShopToReUpdatePanelInfo();
		}
	}

	private void TogglePlayingAndShopToReUpdatePanelInfo()
	{
		HudManager.Singleton.ShowUiGroup_Playing();
		HudManager.Singleton.ShowUiGroup_Shop(_showLastShopGroup: true);
	}

	public void OpenNewShopGroup(int _index)
	{
		foreach (GameObject shopGroup in shopGroups)
		{
			shopGroup.SetActive(value: false);
		}
		shopGroups[_index].SetActive(value: true);
		lastVisibleShopGroupIndex = _index;
	}

	private void UpdatePanel_CultistBlueBerry(CultistPanel _panel)
	{
		bool num = PlayerStats.Singleton.berryTotal_Blueberry >= GameManager.Singleton.cultistBerryGrownRequirement;
		string text = PlayerStats.Singleton.berryTotal_Blueberry + "/" + GameManager.Singleton.cultistBerryGrownRequirement;
		if (PlayerStats.Singleton.berryTotal_Blueberry > 0)
		{
			_panel.descriptionLabel.text = "<size=48>" + text + "</size>\nBlueberries Grown";
		}
		else
		{
			_panel.descriptionLabel.text = "???";
		}
		if (num)
		{
			_panel.summonButton_Text.text = "Summon";
			_panel.itemNameText.text = "Sentient Blueberry";
			_panel.progress_FillBar.fillAmount = 1f;
			_panel.progress_FillBar.color = upgradeLevelBar_ColorGradient.Evaluate(1f);
		}
		else
		{
			_panel.summonButton_Text.text = "???";
			_panel.itemNameText.text = "?????";
			float num2 = (float)PlayerStats.Singleton.berryTotal_Blueberry / (float)GameManager.Singleton.cultistBerryGrownRequirement;
			_panel.progress_FillBar.fillAmount = num2;
			_panel.progress_FillBar.color = upgradeLevelBar_ColorGradient.Evaluate(num2);
		}
	}
}
