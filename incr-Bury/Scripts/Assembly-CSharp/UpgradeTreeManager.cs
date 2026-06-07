using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTreeManager : MonoBehaviour
{
	public static UpgradeTreeManager Singleton;

	public bool disableAllInteractionsWithShopButtons;

	[Header("Tile Colors")]
	public Color upgradeTileColor_Unlocked;

	public Color upgradeTileColor_CannotAfford;

	public Color upgradeTileColor_CanAfford;

	public Color upgradeTileColor_Almost;

	public List<UpgradeTreeButton> allUpgradeTreeButtons;

	public UpgradeTreeButton currentlyHighlightedUpgradeTreeTile;

	[SerializeField]
	private GameObject currHighlighted_Indicator;

	[SerializeField]
	private GameObject startingUpgradeTreeIconForControllerNavigation;

	[Header("Cultists")]
	public int additionalCultist_UpgradeLevel;

	public float additionalCultist_PricePercentIncrease;

	public int unlockCultistSpawnTierThreshold;

	[Header("Growth Rate")]
	public List<float> growthRate_LevelValues;

	public float growthRate_BonusForEachRewind;

	[Header("Gold Rush")]
	public List<float> goldRush_DurationValues;

	public List<int> goldRush_RoundBasedCooldownValues;

	public List<float> goldRush_BonusGrowthRateValues;

	public List<float> goldRush_TimeCooldownValues;

	[Header("Big Hole")]
	public List<int> bigHole_RoundBasedCooldownValues;

	public List<float> bigHole_SizeValues;

	public List<float> bigHole_TimeCooldownValues;

	[Header("Vacuum")]
	public List<int> vacuum_CapacityValues;

	public float vacuum_FireRateIncreasePerUpgrade;

	[Header("Golden Berry")]
	public List<float> goldenBerry_ChanceValues;

	public List<float> goldenBerry_MultiplierValues;

	[Header("Piggy Bank")]
	public List<int> piggyBank_CapacityValues;

	[Header("Berry Plant")]
	public int numOfBerrysDepositedForBerryPlantUpgrade;

	[Header("Cultist Capacity")]
	public List<int> cultistCapacity_Values;

	[Header("Hole Movement")]
	public List<int> holeMoveJuiceCapacity_Values;

	public List<float> holeMoveSpeed_Values;

	[Header("Round Timer")]
	public List<float> roundTimerIncrease_Values;

	[Header("Star Orb Generator")]
	public List<int> starOrbGen_AmtIncreaseValues;

	[Header("Cultist Upgrade Prices")]
	public List<int> cultists_UpgradePrices;

	[Header("JUICED")]
	public List<float> JUICED_MultiplierValues;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		SetValuesFromUnlocks();
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Combine(singleton.ControllerTypeChanged, new Action(OnControllerChanged));
	}

	private void OnDestroy()
	{
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Remove(singleton.ControllerTypeChanged, new Action(OnControllerChanged));
	}

	private void OnControllerChanged()
	{
		if ((bool)HudManager.Singleton && HudManager.Singleton.activeUiGroup == HudManager.ActiveUiGroup.Shop && InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			SelectStartingUpgradeNode_ControllerIsActive();
		}
	}

	public void SelectStartingUpgradeNode_ControllerIsActive()
	{
		if (HudManager.Singleton.activeUiGroup == HudManager.ActiveUiGroup.Shop)
		{
			EventSystem.current.SetSelectedGameObject(startingUpgradeTreeIconForControllerNavigation);
		}
	}

	private void Update()
	{
		HandleCurrentlySelectedIndicator();
		if (Application.isEditor && Input.GetKeyDown(KeyCode.M))
		{
			Debug_FindAllUpgradesOverACertainPrice(100000000);
		}
	}

	public void OnUpgradeTreeMenuOpened()
	{
		UnHoverOverAllUpgradeTreeTiles();
		currentlyHighlightedUpgradeTreeTile = null;
		UpdateAllUpgradeTreeTiles(_resetFeedbacks: true);
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			SelectStartingUpgradeNode_ControllerIsActive();
		}
	}

	public void UnHoverOverAllUpgradeTreeTiles()
	{
		currentlyHighlightedUpgradeTreeTile = null;
		foreach (UpgradeTreeButton allUpgradeTreeButton in allUpgradeTreeButtons)
		{
			_ = allUpgradeTreeButton == currentlyHighlightedUpgradeTreeTile;
			allUpgradeTreeButton.OnPointerExit(null);
		}
		HudManager.Singleton.UpgradeTree_HideDescriptionPanel();
	}

	public void AttemptToUnlockUpgrade(UpgradeTreeButton _upgrade)
	{
	}

	public void UnlockUpgrade(UpgradeTreeButton _upgrade, bool _SetValuesAfter = true)
	{
		if (_upgrade.upgradeIdentity == UpgradeTreeIdentity.NextRoundButton)
		{
			disableAllInteractionsWithShopButtons = true;
			GameManager.Singleton.InShop_CloseShopAndStartNextRound();
			return;
		}
		switch (_upgrade.upgradeIdentity)
		{
		case UpgradeTreeIdentity.AdditionalCultist:
			additionalCultist_UpgradeLevel++;
			SpawnANewCultistFromUpgradeButtonClick(_upgrade.tier);
			HudManager.Singleton.PlayFeedback_PiggyBankPickUp();
			break;
		case UpgradeTreeIdentity.GrowthRateUp:
			PlayerStats.Singleton.berryGrowthRate_Multiplier += growthRate_LevelValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.GoldRush_Unlock:
			PlayerStats.Singleton.goldRush_Unlocked = true;
			break;
		case UpgradeTreeIdentity.GoldRush_Duration:
			PlayerStats.Singleton.goldRush_Duration_Max += goldRush_DurationValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.GoldRush_Cooldown:
			PlayerStats.Singleton.goldRush_Cooldown_Max -= goldRush_TimeCooldownValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.GoldRush_BonusGrowthRate:
			PlayerStats.Singleton.goldRush_BonusGrowthRate += goldRush_BonusGrowthRateValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.BigHole_Unlock:
			PlayerStats.Singleton.bigHole_Unlocked = true;
			break;
		case UpgradeTreeIdentity.BigHole_Cooldown:
			PlayerStats.Singleton.bigHole_Cooldown_Max -= bigHole_TimeCooldownValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.BigHole_Size:
			PlayerStats.Singleton.bigHole_Size += bigHole_SizeValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.Vacuum_Unlock:
			PlayerStats.Singleton.vacuum_Unlocked = true;
			PlayerStats.Singleton.broom_Unlocked = true;
			break;
		case UpgradeTreeIdentity.Vacuum_Capacity:
			PlayerStats.Singleton.vacuumCapacity += vacuum_CapacityValues[_upgrade.tier];
			PlayerStats.Singleton.vacShootDowntime_Max -= vacuum_FireRateIncreasePerUpgrade;
			break;
		case UpgradeTreeIdentity.Broom_Unlock:
			PlayerStats.Singleton.broom_Unlocked = true;
			break;
		case UpgradeTreeIdentity.GoldenBerry_SpawnChance:
			PlayerStats.Singleton.goldenBerryChance_Curr += goldenBerry_ChanceValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.GoldenBerry_Multiplier:
			PlayerStats.Singleton.goldenBerry_ValueMultiplier_Curr += goldenBerry_MultiplierValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.PiggyBank_Unlock:
			PlayerStats.Singleton.piggyBank_Unlocked = true;
			GameManager.Singleton.prefabBank.piggyBankInScene.SetActive(value: true);
			break;
		case UpgradeTreeIdentity.PiggyBank_Capacity:
			PlayerStats.Singleton.piggyBank_Limit += piggyBank_CapacityValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.Bush_Upgrade:
			PlayerStats.Singleton.bushUpgrade_Unlocked = true;
			GameManager.Singleton.prefabBank.plantBed_SpawnedInScene.UpgradeToBush();
			break;
		case UpgradeTreeIdentity.Tree_Upgrade:
			PlayerStats.Singleton.treeUpgrade_Unlocked = true;
			GameManager.Singleton.prefabBank.plantBed_SpawnedInScene.UpgradeToTree();
			break;
		case UpgradeTreeIdentity.ConveyorBelt_Upgrade:
			PlayerStats.Singleton.conveyorBelt_Unlocked = true;
			GameManager.Singleton.prefabBank.conveyorBelt_InScene.SetActive(value: true);
			break;
		case UpgradeTreeIdentity.BerryPlant_BerryTier_Upgrade:
			GameManager.Singleton.prefabBank.plantBed_SpawnedInScene.ChangeBerryProfile(GameManager.Singleton.prefabBank.berryProfiles[_upgrade.tier]);
			break;
		case UpgradeTreeIdentity.AutoCoinPickUp_Unlock:
			PlayerStats.Singleton.autoCoinPickup_Unlocked = true;
			break;
		case UpgradeTreeIdentity.AutoCoinPickUp_Size:
			PlayerStats.Singleton.autoCoinPickUp_RadiusLevel++;
			PlayerStats.Singleton.autoCoinPickUp_Radius_Current += PlayerStats.Singleton.autoCoinPickUp_RadiusLevel_Values[PlayerStats.Singleton.autoCoinPickUp_RadiusLevel];
			break;
		case UpgradeTreeIdentity.CultistCapacity:
			PlayerStats.Singleton.cultistCapacity_Curr += cultistCapacity_Values[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.HoleMoveJuiceCapacity:
			PlayerStats.Singleton.holeMoveJuiceCapacity_Curr += holeMoveJuiceCapacity_Values[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.HoleMoveSpeed:
			PlayerStats.Singleton.holeMoveSpeed_Curr += holeMoveSpeed_Values[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.HoleMove_Unlock:
			PlayerStats.Singleton.holeMove_IsUnlocked = true;
			break;
		case UpgradeTreeIdentity.BlenderBot_Unlock:
			PlayerStats.Singleton.blenderBot_Unlocked = true;
			break;
		case UpgradeTreeIdentity.RoundTimerIncrease:
			PlayerStats.Singleton.roundTimerLength += roundTimerIncrease_Values[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.StarOrbGen_Unlock:
			PlayerStats.Singleton.starOrbGen_IsUnlocked = true;
			break;
		case UpgradeTreeIdentity.StarOrbGen_SpawnsPerRound:
			PlayerStats.Singleton.starOrbGen_SpawnsPerRound += starOrbGen_AmtIncreaseValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.BubbleJetpack:
			PlayerStats.Singleton.bubbleJetpack_Unlocked = true;
			break;
		case UpgradeTreeIdentity.Pinata_Unlock:
			PlayerStats.Singleton.pinata_Unlocked = true;
			break;
		case UpgradeTreeIdentity.Pinata_ZoneTierUp:
			PlayerStats.Singleton.pinata_ZoneSpawnTier++;
			break;
		case UpgradeTreeIdentity.AutoPopStarOrbs_Unlock:
			PlayerStats.Singleton.autoPopStarOrbs_Unlocked = true;
			break;
		case UpgradeTreeIdentity.Cultist_AddNewBlueBerry:
			if (GameManager.Singleton.gameState == GameManager.GameState.RoundOverShop)
			{
				SpawnANewCultistFromUpgradeButtonClick(0);
			}
			break;
		case UpgradeTreeIdentity.StarWand_Unlock:
			PlayerStats.Singleton.StarWand_Unlocked = true;
			break;
		case UpgradeTreeIdentity.SledgeHammer_Unlock:
			PlayerStats.Singleton.SledgeHammer_Unlocked = true;
			break;
		case UpgradeTreeIdentity.SledgeHammer_TierUp:
			PlayerStats.Singleton.SledgeHammer_Tier++;
			break;
		case UpgradeTreeIdentity.Rewind:
			disableAllInteractionsWithShopButtons = true;
			GameManager.Singleton.ActivateRewind();
			break;
		case UpgradeTreeIdentity.PopGun_Unlock:
			PlayerStats.Singleton.popgun_Unlocked = true;
			break;
		case UpgradeTreeIdentity.BerryPicker_Unlock:
			PlayerStats.Singleton.berryPicker_IsUnlocked = true;
			break;
		case UpgradeTreeIdentity.Juiced_Multiplier:
			PlayerStats.Singleton.juiced_GrowthMultiplier += JUICED_MultiplierValues[_upgrade.tier];
			break;
		case UpgradeTreeIdentity.Trampoline_Unlock:
			PlayerStats.Singleton.trampoline_Unlocked = true;
			break;
		case UpgradeTreeIdentity.StarKey_Unlock:
			PlayerStats.Singleton.starKey_Unlocked = true;
			break;
		}
		if (GameManager.Singleton.gameState == GameManager.GameState.RoundOverShop)
		{
			if (_upgrade.upgradeCostType == UpgradeTreeCostType.Money)
			{
				PlayerStats.Singleton.SpendMoney(_upgrade.calculatedPrice);
			}
			else if (_upgrade.upgradeCostType == UpgradeTreeCostType.StarOrb)
			{
				PlayerStats.Singleton.starOrbs -= _upgrade.calculatedPrice;
			}
		}
		_upgrade.OnSuccessfulUnlock();
		if (_SetValuesAfter)
		{
			SetValuesFromUnlocks();
			SaveLoadManager.Singleton.CheckForAllUpgradesUnlocked_Achievement();
		}
	}

	public void SetValuesFromUnlocks()
	{
		if (PlayerStats.Singleton.autoCoinPickup_Unlocked)
		{
			Player.Singleton.AutoCoinPickUpSphere_Enable();
		}
		else
		{
			Player.Singleton.AutoCoinPickUpSphere_Disable();
		}
		if (PlayerStats.Singleton.goldRush_Unlocked)
		{
			HudManager.Singleton.ShowAbilityUI_GoldRush();
		}
		else
		{
			HudManager.Singleton.HideAbilityUI_GoldRush();
		}
		if (PlayerStats.Singleton.bigHole_Unlocked)
		{
			HudManager.Singleton.ShowAbilityUI_BigHole();
		}
		else
		{
			HudManager.Singleton.HideAbilityUI_BigHole();
		}
		if (MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_GrowthBoost)
		{
			PlayerStats.Singleton.berryGrowthRate_Multiplier = 5f + (float)PlayerStats.Singleton.rewind_TimesUsed * growthRate_BonusForEachRewind;
		}
		else
		{
			PlayerStats.Singleton.berryGrowthRate_Multiplier = 1f + (float)PlayerStats.Singleton.rewind_TimesUsed * growthRate_BonusForEachRewind;
		}
		GameManager.Singleton.ResetRoundTimer();
	}

	public int CalculatePriceFromStackMultiplier(int _basePrice, float _percentageIncrease, int _stackCount)
	{
		_percentageIncrease += 1f;
		long val = Mathf.RoundToInt((float)_basePrice * Mathf.Pow(_percentageIncrease, _stackCount));
		return CheckForIntOverflow(val);
	}

	private int CheckForIntOverflow(long _val)
	{
		if (_val > int.MaxValue)
		{
			return int.MaxValue;
		}
		if (_val < int.MinValue)
		{
			return int.MinValue;
		}
		return (int)_val;
	}

	public void SelectNewUnlockTile(UpgradeTreeButton _newTile)
	{
		if (!(currentlyHighlightedUpgradeTreeTile == _newTile))
		{
			if ((bool)currentlyHighlightedUpgradeTreeTile)
			{
				currentlyHighlightedUpgradeTreeTile.OnPointerExit(null);
			}
			currentlyHighlightedUpgradeTreeTile = _newTile;
		}
	}

	public void HandleCurrentlySelectedIndicator()
	{
		if (currentlyHighlightedUpgradeTreeTile != null)
		{
			currHighlighted_Indicator.SetActive(value: true);
			currHighlighted_Indicator.transform.position = currentlyHighlightedUpgradeTreeTile.gameObject.transform.position;
		}
		else
		{
			currHighlighted_Indicator.SetActive(value: false);
		}
	}

	public void UpdateAllUpgradeTreeTiles(bool _resetFeedbacks = false)
	{
		foreach (UpgradeTreeButton allUpgradeTreeButton in allUpgradeTreeButtons)
		{
			if (allUpgradeTreeButton.DISABLED_DO_NOT_INCLUDE_IN_TREE)
			{
				allUpgradeTreeButton.gameObject.SetActive(value: false);
				continue;
			}
			allUpgradeTreeButton.gameObject.SetActive(value: true);
			if (_resetFeedbacks)
			{
				allUpgradeTreeButton.ResetAllFeedbacks();
			}
		}
		bool flag = false;
		foreach (UpgradeTreeButton allUpgradeTreeButton2 in allUpgradeTreeButtons)
		{
			flag = true;
			if (allUpgradeTreeButton2.preReqUpgrades.Count > 0)
			{
				foreach (UpgradeTreeButton preReqUpgrade in allUpgradeTreeButton2.preReqUpgrades)
				{
					if (!preReqUpgrade.isUnlocked)
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag || allUpgradeTreeButton2.DISABLED_DO_NOT_INCLUDE_IN_TREE)
			{
				allUpgradeTreeButton2.gameObject.SetActive(value: false);
				continue;
			}
			if (allUpgradeTreeButton2.upgradeIdentity == UpgradeTreeIdentity.AdditionalCultist)
			{
				bool active = false;
				if (allUpgradeTreeButton2.tier == 0 || PlayerStats.Singleton.cultistsCreated_TotalsByType[allUpgradeTreeButton2.tier] >= unlockCultistSpawnTierThreshold)
				{
					active = true;
				}
				allUpgradeTreeButton2.gameObject.SetActive(active);
			}
			allUpgradeTreeButton2.ChangeVisualsBasedOnAffordability();
		}
		StartCoroutine(HudManager.Singleton.UpgradeTree_UpdateBerryCultistAmountsDisplay());
	}

	public BerryCultist_AI SpawnANewCultistFromUpgradeButtonClick(int _cultistTier, bool _randomizeName = true)
	{
		try
		{
			BerryCultist_AI component = UnityEngine.Object.Instantiate(GameManager.Singleton.GetCultistPrefabFromBerryTier(_cultistTier), GameManager.Singleton.GetCultistsSpawnPoint().position, Quaternion.identity).GetComponent<BerryCultist_AI>();
			PlayerStats.Singleton.AddToCultistTotalCount(_cultistTier);
			if (_randomizeName)
			{
				component.cultistsName = CultistNameGenerator.PickARandomName();
			}
			return component;
		}
		catch
		{
			Debug.Log("Something went wrong spawning the berry cultist? Ignoring!");
		}
		return null;
	}

	public Vector2 GetUnlockedAndTotalUpgradeAmounts()
	{
		Vector2 result = default(Vector2);
		int num = 0;
		int num2 = 0;
		foreach (UpgradeTreeButton allUpgradeTreeButton in allUpgradeTreeButtons)
		{
			if (!allUpgradeTreeButton.DISABLED_DO_NOT_INCLUDE_IN_TREE && allUpgradeTreeButton.clickType == UpgradeButtonClickType.Click)
			{
				num2++;
				if (allUpgradeTreeButton.isUnlocked)
				{
					num++;
				}
			}
		}
		result.x = num;
		result.y = num2;
		return result;
	}

	public void Debug_FindAllUpgradesOverACertainPrice(int _priceThreshold)
	{
		int num = 0;
		Debug.Log("Searching For Prices");
		foreach (UpgradeTreeButton allUpgradeTreeButton in allUpgradeTreeButtons)
		{
			if (!allUpgradeTreeButton.DISABLED_DO_NOT_INCLUDE_IN_TREE)
			{
				allUpgradeTreeButton.CalculateCurrentPrice();
				num = allUpgradeTreeButton.calculatedPrice;
				if (num >= _priceThreshold)
				{
					Debug.Log("Over " + _priceThreshold + ": " + allUpgradeTreeButton.gameObject.name + ", " + FormatHelper.FormatNumberWithCommmas(num));
				}
			}
		}
	}
}
