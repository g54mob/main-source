using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class UpgradeTreeButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	public bool DISABLED_DO_NOT_INCLUDE_IN_TREE;

	[SerializeField]
	private bool notAvailableInDemo;

	public bool DO_NOT_RESET_WITH_REWIND;

	public UpgradeTreeIdentity upgradeIdentity;

	public UpgradeTreeCostType upgradeCostType;

	public UpgradeButtonClickType clickType;

	public bool isRepeatable;

	public bool isUnlocked;

	[Header("Text")]
	public string locTable_Description;

	[Header("Tier")]
	public int tier;

	[Header("Price")]
	public int basePrice;

	public int calculatedPrice;

	public string locTable_PriceRequirement;

	[Header("PreReqs")]
	public List<UpgradeTreeButton> preReqUpgrades = new List<UpgradeTreeButton>();

	[Header("Effects/Polish")]
	public MMF_Player feedback_MouseEnter;

	public MMF_Player feedback_MouseExit;

	public MMF_Player feedback_UnlockSuccessful;

	public MMF_Player feedback_UnlockSuccessful_Repeatable;

	public MMF_Player feedback_UnlockFailed;

	public GameObject canAffordIndicator;

	[Header("Hold Buttons")]
	private bool isCurrentlyHeld;

	[SerializeField]
	private Image holdClick_FillImage;

	private float holdTime_Curr;

	[SerializeField]
	private float holdTime_Max = 3f;

	private bool hasBeenUsedThisHold;

	private const float hold_RepeatTaps_IncreasePerTap = 0.2f;

	private const float hold_RepeatTaps_BufferBeforeDecay = 1.2f;

	private float hold_RepeatTaps_BufferBeforeDecay_Curr;

	private const float hold_RepeatTaps_DecayRate = 0.65f;

	private Image backerImage;

	private Color startingColor;

	public bool isLargeIcon;

	private const float LARGEICON_SCALE = 1.7f;

	public bool NOT_AVAILABLE_IN_DEMO => notAvailableInDemo;

	private void Awake()
	{
		backerImage = GetComponent<Image>();
		startingColor = backerImage.color;
	}

	private void SetPriceOfRewindUpgrade()
	{
		if ((bool)GameManager.Singleton && upgradeIdentity == UpgradeTreeIdentity.Rewind)
		{
			calculatedPrice = GameManager.Singleton.rewind_TierPrices[Mathf.Clamp(PlayerStats.Singleton.rewind_TimesUsed, 0, GameManager.Singleton.rewind_TierPrices.Count - 1)];
			if (PlayerStats.Singleton.rewind_TimesUsed > 0)
			{
				notAvailableInDemo = true;
			}
		}
	}

	private void Update()
	{
		if (UpgradeTreeManager.Singleton.currentlyHighlightedUpgradeTreeTile == this)
		{
			string detailText = "";
			string priceText = "";
			if (upgradeCostType == UpgradeTreeCostType.Money)
			{
				if (!isUnlocked)
				{
					switch (upgradeIdentity)
					{
					case UpgradeTreeIdentity.GrowthRateUp:
						detailText = PlayerStats.Singleton.berryGrowthRate_Multiplier + "x -> " + (PlayerStats.Singleton.berryGrowthRate_Multiplier + UpgradeTreeManager.Singleton.growthRate_LevelValues[tier]) + "x";
						break;
					case UpgradeTreeIdentity.GoldRush_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_BerryBoostAbility");
						break;
					case UpgradeTreeIdentity.GoldRush_Duration:
						detailText = PlayerStats.Singleton.goldRush_Duration_Max + "s -> " + (PlayerStats.Singleton.goldRush_Duration_Max + UpgradeTreeManager.Singleton.goldRush_DurationValues[tier]) + "s";
						break;
					case UpgradeTreeIdentity.GoldRush_Cooldown:
						detailText = PlayerStats.Singleton.goldRush_Cooldown_Max + " -> " + (PlayerStats.Singleton.goldRush_Cooldown_Max - UpgradeTreeManager.Singleton.goldRush_TimeCooldownValues[tier]);
						break;
					case UpgradeTreeIdentity.GoldRush_BonusGrowthRate:
						detailText = PlayerStats.Singleton.goldRush_BonusGrowthRate + "x -> " + (PlayerStats.Singleton.goldRush_BonusGrowthRate + UpgradeTreeManager.Singleton.goldRush_BonusGrowthRateValues[tier]) + "x";
						break;
					case UpgradeTreeIdentity.BigHole_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_BigHoleAbility");
						break;
					case UpgradeTreeIdentity.BigHole_Cooldown:
						detailText = FormatHelper.SecondsToMinuteString(PlayerStats.Singleton.bigHole_Cooldown_Max) + " -> " + FormatHelper.SecondsToMinuteString(PlayerStats.Singleton.bigHole_Cooldown_Max - UpgradeTreeManager.Singleton.bigHole_TimeCooldownValues[tier]);
						break;
					case UpgradeTreeIdentity.BigHole_Size:
						detailText = PlayerStats.Singleton.bigHole_Size + " -> " + (PlayerStats.Singleton.bigHole_Size + UpgradeTreeManager.Singleton.bigHole_SizeValues[tier]);
						break;
					case UpgradeTreeIdentity.Vacuum_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Vacuum");
						break;
					case UpgradeTreeIdentity.Vacuum_Capacity:
						detailText = PlayerStats.Singleton.vacuumCapacity + " -> " + (PlayerStats.Singleton.vacuumCapacity + UpgradeTreeManager.Singleton.vacuum_CapacityValues[tier]);
						break;
					case UpgradeTreeIdentity.Broom_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Broom");
						break;
					case UpgradeTreeIdentity.GoldenBerry_SpawnChance:
						detailText = PlayerStats.Singleton.goldenBerryChance_Curr + "% -> " + (PlayerStats.Singleton.goldenBerryChance_Curr + UpgradeTreeManager.Singleton.goldenBerry_ChanceValues[tier]) + "%";
						break;
					case UpgradeTreeIdentity.GoldenBerry_Multiplier:
						detailText = PlayerStats.Singleton.goldenBerry_ValueMultiplier_Curr + "x -> " + (PlayerStats.Singleton.goldenBerry_ValueMultiplier_Curr + UpgradeTreeManager.Singleton.goldenBerry_MultiplierValues[tier]) + "x";
						break;
					case UpgradeTreeIdentity.Bush_Upgrade:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Bush");
						break;
					case UpgradeTreeIdentity.Tree_Upgrade:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Tree");
						break;
					case UpgradeTreeIdentity.ConveyorBelt_Upgrade:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_ConveyorBelt");
						break;
					case UpgradeTreeIdentity.AutoCoinPickUp_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_AutoCoinPickUp");
						break;
					case UpgradeTreeIdentity.AutoCoinPickUp_Size:
						detailText = PlayerStats.Singleton.autoCoinPickUp_Radius_Current + " -> " + (PlayerStats.Singleton.autoCoinPickUp_Radius_Current + PlayerStats.Singleton.autoCoinPickUp_RadiusLevel_Values[tier]);
						break;
					case UpgradeTreeIdentity.HoleMoveJuiceCapacity:
						detailText = PlayerStats.Singleton.holeMoveJuiceCapacity_Curr + " -> " + (PlayerStats.Singleton.holeMoveJuiceCapacity_Curr + UpgradeTreeManager.Singleton.holeMoveJuiceCapacity_Values[tier]);
						break;
					case UpgradeTreeIdentity.HoleMoveSpeed:
						detailText = PlayerStats.Singleton.holeMoveSpeed_Curr + " -> " + (PlayerStats.Singleton.holeMoveSpeed_Curr + UpgradeTreeManager.Singleton.holeMoveSpeed_Values[tier]);
						break;
					case UpgradeTreeIdentity.HoleMove_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_HoleMove");
						break;
					case UpgradeTreeIdentity.BlenderBot_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_BlenderBot");
						break;
					case UpgradeTreeIdentity.RoundTimerIncrease:
						detailText = PlayerStats.Singleton.roundTimerLength + "s -> " + (PlayerStats.Singleton.roundTimerLength + UpgradeTreeManager.Singleton.roundTimerIncrease_Values[tier]) + "s";
						break;
					case UpgradeTreeIdentity.StarOrbGen_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_StarOrbGenerator");
						break;
					case UpgradeTreeIdentity.StarOrbGen_SpawnsPerRound:
						detailText = PlayerStats.Singleton.starOrbGen_SpawnsPerRound + " -> " + (PlayerStats.Singleton.starOrbGen_SpawnsPerRound + UpgradeTreeManager.Singleton.starOrbGen_AmtIncreaseValues[tier]);
						break;
					case UpgradeTreeIdentity.BubbleJetpack:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_BubbleJetPack");
						break;
					case UpgradeTreeIdentity.Pinata_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Pinata_Unlock");
						break;
					case UpgradeTreeIdentity.Pinata_ZoneTierUp:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Pinata_ZoneUp");
						break;
					case UpgradeTreeIdentity.AutoPopStarOrbs_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeTree_AutoPopStarOrbs_Detail");
						break;
					case UpgradeTreeIdentity.StarWand_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_StarWand_Unlock");
						break;
					case UpgradeTreeIdentity.Cultist_AddNewBlueBerry:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Blueberry");
						break;
					case UpgradeTreeIdentity.SledgeHammer_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_SledgeHammer_Unlock");
						break;
					case UpgradeTreeIdentity.SledgeHammer_TierUp:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_SledgeHammerTierUp");
						break;
					case UpgradeTreeIdentity.Rewind:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Rewind");
						break;
					case UpgradeTreeIdentity.PopGun_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_PopGun");
						break;
					case UpgradeTreeIdentity.BerryPicker_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_BerryPicker");
						break;
					case UpgradeTreeIdentity.Juiced_Multiplier:
						detailText = PlayerStats.Singleton.juiced_GrowthMultiplier + " -> " + (PlayerStats.Singleton.juiced_GrowthMultiplier + UpgradeTreeManager.Singleton.JUICED_MultiplierValues[tier]);
						break;
					case UpgradeTreeIdentity.Trampoline_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_Trampoline");
						break;
					case UpgradeTreeIdentity.StarKey_Unlock:
						detailText = LocTableHelpers.GetStringFromTable("UpgradeDetail_StarKey");
						break;
					}
					if (NOT_AVAILABLE_IN_DEMO)
					{
						priceText = "Not Available In Demo";
					}
					else if (calculatedPrice > 0)
					{
						priceText = "$" + FormatHelper.FormatNumberWithCommmas(calculatedPrice);
					}
					else
					{
						try
						{
							priceText = ((!(LocalizationSettings.SelectedLocale.Identifier.Code == "en")) ? "" : "<size=50%>(Also Saves Your Game)</size>");
						}
						catch
						{
							priceText = "";
							Debug.Log("Failed to detect language settings, ignoring!");
						}
					}
				}
				if (upgradeIdentity == UpgradeTreeIdentity.Rewind && PlayerStats.Singleton.rewind_TimesUsed > 0)
				{
					HudManager.Singleton.UpgradeTree_UpdateDescriptionPanel(LocTableHelpers.GetStringFromTable(locTable_Description) + " " + (PlayerStats.Singleton.rewind_TimesUsed + 1), detailText, priceText);
				}
				else
				{
					HudManager.Singleton.UpgradeTree_UpdateDescriptionPanel(LocTableHelpers.GetStringFromTable(locTable_Description), detailText, priceText);
				}
			}
			else if (upgradeCostType == UpgradeTreeCostType.Custom)
			{
				HudManager.Singleton.UpgradeTree_UpdateDescriptionPanel(LocTableHelpers.GetStringFromTable(locTable_Description), detailText, LocTableHelpers.GetStringFromTable(locTable_PriceRequirement));
			}
			else if (upgradeCostType == UpgradeTreeCostType.StarOrb)
			{
				if (upgradeIdentity == UpgradeTreeIdentity.AdditionalCultist)
				{
					switch (tier)
					{
					case 0:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Blueberry");
						break;
					case 1:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Raspberry");
						break;
					case 2:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Strawberry");
						break;
					case 3:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Kiwi");
						break;
					case 4:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Plum");
						break;
					case 5:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Apple");
						break;
					case 6:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Pear");
						break;
					case 7:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Peach");
						break;
					case 8:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Banana");
						break;
					case 9:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Pineapple");
						break;
					case 10:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Watermelon");
						break;
					case 11:
						detailText = LocTableHelpers.GetStringFromTable("BerryName_Pumpkin");
						break;
					}
				}
				HudManager.Singleton.UpgradeTree_UpdateDescriptionPanel(LocTableHelpers.GetStringFromTable(locTable_Description), detailText, "(*)" + GameManager.Singleton.FormatMoney(calculatedPrice));
			}
			if (clickType != UpgradeButtonClickType.Hold)
			{
			}
		}
		else
		{
			isCurrentlyHeld = false;
		}
		if (clickType == UpgradeButtonClickType.Hold)
		{
			HandleHoldRepeatableClicksDecay();
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!UpgradeTreeManager.Singleton.disableAllInteractionsWithShopButtons && clickType == UpgradeButtonClickType.Click && !isUnlocked)
		{
			if (CanAfford())
			{
				UpgradeTreeManager.Singleton.UnlockUpgrade(this);
				AudioManager.Singleton.PlayUiSFX_Click();
				AudioManager.Singleton.PlayUiSFX_UnlockUpgrade();
			}
			else
			{
				AudioManager.Singleton.PlayUiSFX_CannotAfford();
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (UpgradeTreeManager.Singleton.disableAllInteractionsWithShopButtons || hasBeenUsedThisHold || clickType != UpgradeButtonClickType.Hold)
		{
			return;
		}
		if (CanAfford())
		{
			isCurrentlyHeld = true;
			if (clickType == UpgradeButtonClickType.Hold)
			{
				Hold_RepeatableClicks_Clicked();
			}
			AudioManager.Singleton.PlayUiSFX_Click();
		}
		else
		{
			AudioManager.Singleton.PlayUiSFX_CannotAfford();
		}
	}

	private void HandleHeld()
	{
		if (isCurrentlyHeld)
		{
			if (holdTime_Curr < holdTime_Max)
			{
				holdTime_Curr += Time.deltaTime;
			}
			else
			{
				holdTime_Curr = holdTime_Max;
				hasBeenUsedThisHold = true;
				UpgradeTreeManager.Singleton.UnlockUpgrade(this);
			}
			holdClick_FillImage.fillAmount = holdTime_Curr / holdTime_Max;
		}
	}

	private void Hold_RepeatableClicks_Clicked()
	{
		if (!UpgradeTreeManager.Singleton.disableAllInteractionsWithShopButtons && !hasBeenUsedThisHold)
		{
			holdTime_Curr += 0.2f;
			hold_RepeatTaps_BufferBeforeDecay_Curr = 1.2f;
			if (holdTime_Curr < 1f)
			{
				feedback_MouseEnter?.PlayFeedbacks();
				return;
			}
			hasBeenUsedThisHold = true;
			UpgradeTreeManager.Singleton.UnlockUpgrade(this);
			feedback_UnlockSuccessful_Repeatable?.PlayFeedbacks();
		}
	}

	private void HandleHoldRepeatableClicksDecay()
	{
		if (holdTime_Curr > 0f)
		{
			if (hold_RepeatTaps_BufferBeforeDecay_Curr > 0f)
			{
				hold_RepeatTaps_BufferBeforeDecay_Curr -= Time.deltaTime;
			}
			else
			{
				holdTime_Curr -= Time.deltaTime * 0.65f;
			}
			holdClick_FillImage.fillAmount = holdTime_Curr;
		}
		else
		{
			holdTime_Curr = 0f;
			holdClick_FillImage.fillAmount = 0f;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public bool CanAfford()
	{
		if (NOT_AVAILABLE_IN_DEMO)
		{
			return false;
		}
		if (upgradeCostType == UpgradeTreeCostType.Money)
		{
			if (PlayerStats.Singleton.money >= calculatedPrice)
			{
				return true;
			}
			return false;
		}
		if (upgradeCostType == UpgradeTreeCostType.StarOrb)
		{
			if (PlayerStats.Singleton.starOrbs >= calculatedPrice)
			{
				bool flag = false;
				if (upgradeIdentity == UpgradeTreeIdentity.AdditionalCultist && GameManager.Singleton.spawnedCultists.Count >= PlayerStats.Singleton.cultistCapacity_Curr)
				{
					flag = true;
				}
				if (flag)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		bool flag2 = false;
		if (upgradeIdentity == UpgradeTreeIdentity.BerryPlant_BerryTier_Upgrade && PlayerStats.Singleton.deposited_BerryTotals[tier] < UpgradeTreeManager.Singleton.numOfBerrysDepositedForBerryPlantUpgrade)
		{
			flag2 = true;
		}
		if (flag2)
		{
			return false;
		}
		return true;
	}

	public bool CanAlmostAfford()
	{
		if (upgradeCostType == UpgradeTreeCostType.Money)
		{
			if ((float)PlayerStats.Singleton.money >= (float)calculatedPrice * 0.6f)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		CalculateCurrentPrice();
		feedback_MouseEnter?.PlayFeedbacks();
		AudioManager.Singleton.PlayUiSFX_ButtonOver();
		UpgradeTreeManager.Singleton.SelectNewUnlockTile(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (isLargeIcon)
		{
			base.transform.localScale = Vector3.one * 1.7f;
		}
		else
		{
			base.transform.localScale = Vector3.one;
		}
		HudManager.Singleton.UpgradeTree_HideDescriptionPanel();
		UpgradeTreeManager.Singleton.currentlyHighlightedUpgradeTreeTile = null;
	}

	public void OnSuccessfulUnlock()
	{
		if (isRepeatable)
		{
			CalculateCurrentPrice();
			StartCoroutine(WaitAFewSeconds_ThenCheckAffordabilityOfRepeatables());
		}
		else
		{
			isUnlocked = true;
			GetComponent<Image>().color = UpgradeTreeManager.Singleton.upgradeTileColor_Unlocked;
		}
		UpgradeTreeManager.Singleton.UpdateAllUpgradeTreeTiles();
		if (isRepeatable)
		{
			feedback_UnlockSuccessful_Repeatable?.PlayFeedbacks();
			return;
		}
		feedback_MouseEnter?.PlayFeedbacks();
		backerImage.color = UpgradeTreeManager.Singleton.upgradeTileColor_Unlocked;
	}

	private IEnumerator WaitAFewSeconds_ThenCheckAffordabilityOfRepeatables()
	{
		yield return new WaitForSeconds(0.6f);
		ChangeVisualsBasedOnAffordability();
	}

	public void OnFailedUnlock()
	{
		feedback_UnlockFailed?.PlayFeedbacks();
		Debug.Log("FAILED BUY: " + base.gameObject.name);
	}

	public void CalculateCurrentPrice()
	{
		if (upgradeIdentity == UpgradeTreeIdentity.Rewind)
		{
			SetPriceOfRewindUpgrade();
		}
		else
		{
			if (upgradeCostType != UpgradeTreeCostType.Money && upgradeCostType != UpgradeTreeCostType.StarOrb)
			{
				return;
			}
			if (isRepeatable)
			{
				if (upgradeIdentity != UpgradeTreeIdentity.AdditionalCultist)
				{
					_ = 1;
				}
				else
				{
					calculatedPrice = basePrice;
				}
			}
			else
			{
				calculatedPrice = basePrice;
			}
		}
	}

	public void ResetAllFeedbacks()
	{
		base.transform.rotation = Quaternion.identity;
		if (isLargeIcon)
		{
			base.transform.localScale = Vector3.one * 1.7f;
		}
		else
		{
			base.transform.localScale = Vector3.one;
		}
		if (isUnlocked)
		{
			backerImage.color = UpgradeTreeManager.Singleton.upgradeTileColor_Unlocked;
		}
		else
		{
			backerImage.color = startingColor;
		}
	}

	public void ChangeVisualsBasedOnAffordability()
	{
		CalculateCurrentPrice();
		if (!isUnlocked)
		{
			if (CanAfford())
			{
				backerImage.color = UpgradeTreeManager.Singleton.upgradeTileColor_CanAfford;
			}
			else if (CanAlmostAfford())
			{
				backerImage.color = UpgradeTreeManager.Singleton.upgradeTileColor_Almost;
			}
			else
			{
				backerImage.color = UpgradeTreeManager.Singleton.upgradeTileColor_CannotAfford;
			}
		}
	}
}
