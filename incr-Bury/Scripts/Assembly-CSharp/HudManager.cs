using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
	public enum CrossHairType
	{
		Basic = 0,
		Useable = 1,
		MouseCursor = 2
	}

	public enum ActiveUiGroup
	{
		Playing = 0,
		Paused = 1,
		Shop = 2,
		PlantBedUpgrade = 3,
		DemoEnding = 4,
		NarrativePopUp = 5
	}

	public static HudManager Singleton;

	[SerializeField]
	private Canvas uiCanvas;

	[Header("Crosshairs")]
	[SerializeField]
	private GameObject crosshair_Basic;

	[SerializeField]
	private GameObject crosshair_Usable;

	[SerializeField]
	private GameObject crosshair_MouseCursor;

	private bool crosshairsForcedDisabled;

	[SerializeField]
	private Image crosshair_Basic_Image;

	[SerializeField]
	private Image crosshair_Usable_Image;

	[SerializeField]
	private GameObject crosshairs_Parent;

	[Header("UI Groups")]
	[SerializeField]
	private GameObject uiGroup_Playing;

	[SerializeField]
	private GameObject uiGroup_Paused;

	[SerializeField]
	private GameObject uiGroup_Shop;

	[Header("UI SubGroups")]
	[SerializeField]
	private GameObject uiSubGroup_PlantBedInfo;

	public ActiveUiGroup activeUiGroup;

	[Header("Temp Paused Options")]
	[SerializeField]
	private TMP_Text mouseSens_DisplayValue;

	[SerializeField]
	private Slider mouseSens_Slider;

	private Slider.SliderEvent mouseSensSlider_OnValueChanged;

	[Header("Stamina UI")]
	[SerializeField]
	private GameObject staminaBar_Parent;

	[SerializeField]
	private Image staminaBar_Fill;

	[SerializeField]
	private Gradient staminaBar_ColorGradient;

	[Header("Berry Blitz UI")]
	[SerializeField]
	private GameObject berryBlitz_UI_Parent;

	[SerializeField]
	private Image berryBlitz_CooldownFillImage;

	[SerializeField]
	private GameObject berryBlitz_ReadyToUse_Image;

	[SerializeField]
	private TMP_Text berryBlitz_Timer_Text;

	[Header("Big Hole UI")]
	[SerializeField]
	private GameObject bigHole_UI_Parent;

	[SerializeField]
	private Image bigHole_CooldownFillImage;

	[SerializeField]
	private GameObject bigHole_ReadyToUse_Image;

	[SerializeField]
	private TMP_Text bigHole_Timer_Text;

	[Header("Plant Bed Upgrade Menu")]
	public PlantBed selectedPlantBed;

	[SerializeField]
	private TMP_Text plantBedUpgrade_BerryNameText;

	[SerializeField]
	private TMP_Text plantBedUpgrade_SeedCostToUpgradeText;

	[SerializeField]
	private TMP_Text plantBedUpgrade_ProducedText;

	[SerializeField]
	private Image plantBedUpgrade_XPbarFill;

	[SerializeField]
	private GameObject plantBed_UpgradeButton_CanAfford;

	[SerializeField]
	private GameObject plantBed_UpgradeButton_CannotAfford;

	[SerializeField]
	private GameObject haltProduction_Button_Visuals;

	[SerializeField]
	private GameObject enableProduction_Button_Visuals;

	[Header("Hole Related")]
	public GameObject holeMoveJuice_UIGroup;

	public Image holeMoveJuice_CurrentProgress_Fill;

	public Image holeMoveJuice_FadedBacker_ReverseFill;

	public Gradient holeLevelGradient;

	private float totalHoleMoveJuice_PossibleAtMaxUpgrade;

	public Image holePrestigeUI_CurrentProgress_Fill;

	[Header("Feedbacks")]
	[SerializeField]
	private MMF_Player hudFeedback_MoneyPickup;

	[SerializeField]
	private MMF_Player hudFeedback_HeldMoneyPickup;

	[SerializeField]
	private MMF_Player hudFeedback_SeedPickup;

	[SerializeField]
	private MMF_Player hudFeedback_PiggyBankPickUp;

	[SerializeField]
	private MMF_Player hudFeedback_DroppedMoney;

	[Header("Upgrade Tree")]
	[SerializeField]
	private GameObject UpgradeTree_DescriptionBox_Parent;

	[SerializeField]
	private TMP_Text UpgradeTree_DescriptionBox_DescriptionText;

	[SerializeField]
	private TMP_Text UpgradeTree_DescriptionBox_DetailText;

	[SerializeField]
	private TMP_Text UpgradeTree_DescriptionBox_PriceText;

	[SerializeField]
	private Vector2 UpgradeTree_DescriptionBox_PlacementOffset;

	private float UpgradeTree_DescriptionBox_PlacementOffset_ScreenSideThreshold;

	public List<UpgradeTree_BerryCultistAmt_Display> upgradeTree_CultistsAmountDisplays;

	[Header("Round Timer")]
	[SerializeField]
	private TMP_Text roundTimer_Display;

	[Header("Cultist Info")]
	[SerializeField]
	private GameObject cultistInfoDisplayGroup;

	[SerializeField]
	private TMP_Text cultistsName_Display;

	[SerializeField]
	private TMP_Text cultistsUpgradeCost_Display;

	[Header("Hint Text")]
	[SerializeField]
	private GameObject hintText_DisplayGroup;

	[SerializeField]
	private TMP_Text hintText_Text;

	[Header("Kick Charge Up")]
	[SerializeField]
	private Image kickCharge_FillImage;

	[SerializeField]
	private Gradient kickCharge_Gradient;

	[Header("BIG TEXT Pop Ups")]
	[SerializeField]
	private List<GameObject> BigTextPopUps_MasterList;

	private Coroutine bigText_Coroutine;

	[Header("Currency Displays")]
	public GameObject currencyDisplay_BankedMoney;

	public GameObject currencyDisplay_HeldMoney;

	public GameObject currencyDisplay_StarOrbs;

	public TMP_Text currencyDisplay_DroppedMoney;

	public GameObject currencyDisplay_GrowthModifier;

	public GameObject currencyDisplay_CanAffordBerryBuddyNotification_Backer;

	public GameObject currencyDisplay_CanAffordBerryBuddyNotification_Text;

	[Header("Growth Modifier Bars")]
	[SerializeField]
	private GameObject growthMod_Juiced_Parent;

	[SerializeField]
	private Image growthMod_Juiced_Fill;

	[SerializeField]
	private TMP_Text growthMod_Juiced_TimerText;

	public bool forceHide_StatusEffectBars;

	[SerializeField]
	private GameObject growthMod_Blitz_Parent;

	[SerializeField]
	private Image growthMod_Blitz_Fill;

	[SerializeField]
	private TMP_Text growthMod_Blitz_TimerText;

	[Header("Hud Toggle")]
	private bool hudToggle;

	public List<GameObject> additionalHudToggles;

	[Header("Demo Specific")]
	[SerializeField]
	private GameObject uigroup_DemoEnding;

	[Header("Narrative Groups")]
	[SerializeField]
	private GameObject uiGroup_Narrative;

	[SerializeField]
	private List<GameObject> narrative_SubGroups;

	[SerializeField]
	private GameObject narrativePopUp_DefaultSelectedUI;

	[Header("Misc Extra Hud")]
	[SerializeField]
	private TMP_Text miscExtra_SpeedRunTimer;

	[SerializeField]
	private TMP_Text miscExtra_HoleLevelDisplay;

	public Action OnPausingGame_Action;

	public Action OnUnpausingGame_Action;

	[SerializeField]
	private GameObject wakingUpTextPopUp;

	[SerializeField]
	private GameObject hudScale_Object;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(this);
		}
		else
		{
			Singleton = this;
		}
	}

	private void OnDestroy()
	{
		mouseSens_Slider.onValueChanged.RemoveAllListeners();
		OptionsManager singleton = OptionsManager.Singleton;
		singleton.OnHudScaleChanged = (Action)Delegate.Remove(singleton.OnHudScaleChanged, new Action(UpdateUiScale));
	}

	private void Start()
	{
		OptionsManager singleton = OptionsManager.Singleton;
		singleton.OnHudScaleChanged = (Action)Delegate.Combine(singleton.OnHudScaleChanged, new Action(UpdateUiScale));
		UpdateUiScale();
		ShowUiGroup_Playing();
		HideAllNarrativeSubGroups();
		SetCrossHair(CrossHairType.Basic);
		UpgradeTree_DescriptionBox_PlacementOffset_ScreenSideThreshold = (float)Screen.width * 0.05f;
		CalculateTotalHoleMoveJuiceWithAllUpgrades();
		currencyDisplay_DroppedMoney.gameObject.SetActive(value: false);
	}

	private void CalculateTotalHoleMoveJuiceWithAllUpgrades()
	{
		totalHoleMoveJuice_PossibleAtMaxUpgrade = 0f;
		foreach (int holeMoveJuiceCapacity_Value in UpgradeTreeManager.Singleton.holeMoveJuiceCapacity_Values)
		{
			totalHoleMoveJuice_PossibleAtMaxUpgrade += holeMoveJuiceCapacity_Value;
		}
	}

	private void Update()
	{
		HandleGrowthModDisplayUI();
		if (Application.isEditor && Input.GetKeyDown(KeyCode.F3))
		{
			ToggleHud();
		}
		if (activeUiGroup == ActiveUiGroup.Playing)
		{
			GenericMenuManager.Singleton.menuState = GenericMenuManager.MenuState.idle;
		}
		else
		{
			GenericMenuManager.Singleton.menuState = GenericMenuManager.MenuState.open;
		}
		if (activeUiGroup == ActiveUiGroup.PlantBedUpgrade)
		{
			UpdatePlantBedUpgradeUI();
		}
		if (InputManager.Singleton.inputActions.PlayerActionMap.Escape.WasReleasedThisFrame() && !ControlsMenuManager.Singleton.GetIsRebindMenuActive() && activeUiGroup != ActiveUiGroup.Shop)
		{
			if (activeUiGroup == ActiveUiGroup.Playing)
			{
				OnPausingGame_Action?.Invoke();
				ShowUiGroup_Paused();
			}
			else if (activeUiGroup == ActiveUiGroup.Paused)
			{
				OnUnpausingGame_Action?.Invoke();
				ShowUiGroup_Playing();
			}
			else if (activeUiGroup == ActiveUiGroup.NarrativePopUp)
			{
				ShowUiGroup_Playing();
			}
			else if (activeUiGroup == ActiveUiGroup.PlantBedUpgrade)
			{
				HideUIGroup_SubGroup_PlantBedInfo();
				ShowUiGroup_Playing();
			}
		}
		if (PlayerStats.Singleton.goldRush_Unlocked)
		{
			berryBlitz_CooldownFillImage.fillAmount = 1f - GameManager.Singleton.goldRush_Cooldown_Curr / PlayerStats.Singleton.goldRush_Cooldown_Max;
			berryBlitz_ReadyToUse_Image.SetActive(GameManager.Singleton.canUseGoldRush && !GameManager.Singleton.goldRushIsActive);
			if (GameManager.Singleton.goldRushIsActive)
			{
				berryBlitz_Timer_Text.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("AbilityHud_Active", null, FallbackBehavior.UseProjectSettings).Result;
			}
			else if (GameManager.Singleton.canUseGoldRush)
			{
				berryBlitz_Timer_Text.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("AbilityHud_Ready", null, FallbackBehavior.UseProjectSettings).Result;
			}
			else
			{
				berryBlitz_Timer_Text.text = FormatHelper.SecondsToMinuteString(GameManager.Singleton.goldRush_Cooldown_Curr);
			}
		}
		if (PlayerStats.Singleton.bigHole_Unlocked)
		{
			bigHole_CooldownFillImage.fillAmount = 1f - GameManager.Singleton.bigHole_Cooldown_Curr / PlayerStats.Singleton.bigHole_Cooldown_Max;
			bigHole_ReadyToUse_Image.SetActive(GameManager.Singleton.canUseBigHole && !GameManager.Singleton.bigHoleIsActive);
			if (GameManager.Singleton.bigHoleIsActive)
			{
				bigHole_Timer_Text.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("AbilityHud_Active", null, FallbackBehavior.UseProjectSettings).Result;
			}
			else if (GameManager.Singleton.canUseBigHole)
			{
				bigHole_Timer_Text.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("AbilityHud_Ready", null, FallbackBehavior.UseProjectSettings).Result;
			}
			else
			{
				bigHole_Timer_Text.text = FormatHelper.SecondsToMinuteString(GameManager.Singleton.bigHole_Cooldown_Curr);
			}
		}
		if (crosshairsForcedDisabled)
		{
			crosshair_Basic.SetActive(value: false);
			crosshair_Usable.SetActive(value: false);
			crosshair_MouseCursor.SetActive(value: false);
			HideAllCurrencyDisplays();
		}
		HandleMiscExtraHudDisplays();
		HandleCrossHairSettings();
	}

	public void SetCrossHair(CrossHairType _type)
	{
		crosshair_Basic.SetActive(value: false);
		crosshair_Usable.SetActive(value: false);
		crosshair_MouseCursor.SetActive(value: false);
		switch (_type)
		{
		case CrossHairType.Basic:
			crosshair_Basic.SetActive(value: true);
			break;
		case CrossHairType.Useable:
			crosshair_Usable.SetActive(value: true);
			break;
		case CrossHairType.MouseCursor:
			crosshair_MouseCursor.SetActive(value: true);
			break;
		}
	}

	public void HideAllUIGroups()
	{
		uiGroup_Paused.SetActive(value: false);
		uiGroup_Playing.SetActive(value: false);
		uiGroup_Shop.SetActive(value: false);
		uigroup_DemoEnding.SetActive(value: false);
		uiGroup_Narrative.SetActive(value: false);
		OptionsManager.Singleton.OptionsMenuCanvas_Hide();
	}

	public void HideAllUIGroups_SubGroups()
	{
		HideUIGroup_SubGroup_PlantBedInfo();
	}

	public void ShowUiGroup_Playing()
	{
		Time.timeScale = 1f;
		HideAllUIGroups();
		uiGroup_Playing.SetActive(value: true);
		activeUiGroup = ActiveUiGroup.Playing;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void ShowUiGroup_Paused()
	{
		Time.timeScale = 0f;
		HideAllUIGroups();
		uiGroup_Paused.SetActive(value: true);
		OptionsManager.Singleton.OptionsMenuCanvas_Show();
		activeUiGroup = ActiveUiGroup.Paused;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void ShowUiGroup_Shop(bool _showLastShopGroup = false)
	{
		HideAllUIGroups();
		uiGroup_Shop.SetActive(value: true);
		activeUiGroup = ActiveUiGroup.Shop;
		if (_showLastShopGroup)
		{
			ShopPanelHelper.Singleton.OpenNewShopGroup(ShopPanelHelper.Singleton.lastVisibleShopGroupIndex);
		}
		else
		{
			ShopPanelHelper.Singleton.OpenNewShopGroup(0);
		}
		UpgradeTreeManager.Singleton.OnUpgradeTreeMenuOpened();
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	public IEnumerator WaitASecThen_ShowUiGroupDemoEnding()
	{
		yield return new WaitForSeconds(3f);
		ShowUiGroup_DemoEnding();
	}

	public void ShowUiGroup_DemoEnding()
	{
		Time.timeScale = 0f;
		HideAllUIGroups();
		uigroup_DemoEnding.SetActive(value: true);
		activeUiGroup = ActiveUiGroup.DemoEnding;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void ShowUiGroup_Narrative(int _narrativeIndex)
	{
		HideAllUIGroups();
		HideAllNarrativeSubGroups();
		uiGroup_Narrative.SetActive(value: true);
		narrative_SubGroups[_narrativeIndex].SetActive(value: true);
		activeUiGroup = ActiveUiGroup.NarrativePopUp;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			EventSystem.current.SetSelectedGameObject(narrativePopUp_DefaultSelectedUI);
		}
	}

	public void HideAllNarrativeSubGroups()
	{
		foreach (GameObject narrative_SubGroup in narrative_SubGroups)
		{
			if (!(narrative_SubGroup == null))
			{
				narrative_SubGroup.SetActive(value: false);
			}
		}
	}

	public void ShowUIGroup_SubGroup_PlantBedInfo()
	{
		uiSubGroup_PlantBedInfo.SetActive(value: true);
		activeUiGroup = ActiveUiGroup.PlantBedUpgrade;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		int index = Mathf.Clamp(selectedPlantBed.currentBerryTier + 1, 0, 11);
		if (ShopAndUpgradesManager.Singleton.BerryUpgradesSeedPriceList[index] <= PlayerStats.Singleton.seeds)
		{
			plantBed_UpgradeButton_CanAfford.SetActive(value: true);
			plantBed_UpgradeButton_CannotAfford.SetActive(value: false);
		}
		else
		{
			plantBed_UpgradeButton_CanAfford.SetActive(value: false);
			plantBed_UpgradeButton_CannotAfford.SetActive(value: true);
		}
		if (selectedPlantBed.GetIsProductionHalted())
		{
			enableProduction_Button_Visuals.SetActive(value: true);
			haltProduction_Button_Visuals.SetActive(value: false);
		}
		else
		{
			enableProduction_Button_Visuals.SetActive(value: false);
			haltProduction_Button_Visuals.SetActive(value: true);
		}
	}

	public void HideUIGroup_SubGroup_PlantBedInfo()
	{
		uiSubGroup_PlantBedInfo.SetActive(value: false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		ShowUiGroup_Playing();
	}

	public void ToggleShopMenu()
	{
		if (activeUiGroup == ActiveUiGroup.Shop)
		{
			ShowUiGroup_Playing();
			return;
		}
		ShowUiGroup_Shop();
		GameManager.Singleton.ExitBuildMode();
	}

	public void ShopMenu_Close()
	{
		ShowUiGroup_Playing();
	}

	public void ShopMenu_Open()
	{
		ShowUiGroup_Shop();
	}

	public void UpdateStaminaBar(float _value)
	{
	}

	public void HideStaminaBar()
	{
	}

	public void ShowStaminaBar()
	{
	}

	public void TogglePlantBedUpgradeUI(PlantBed _plantBed)
	{
		if (activeUiGroup == ActiveUiGroup.PlantBedUpgrade)
		{
			HideUIGroup_SubGroup_PlantBedInfo();
			return;
		}
		selectedPlantBed = _plantBed;
		ShowUIGroup_SubGroup_PlantBedInfo();
	}

	public void UpdatePlantBedUpgradeUI()
	{
		if (selectedPlantBed.currentBerryTier == -1)
		{
			plantBedUpgrade_BerryNameText.text = "Dirt";
		}
		else
		{
			TMP_Text tMP_Text = plantBedUpgrade_BerryNameText;
			BerryNames currentBerryTier = (BerryNames)selectedPlantBed.currentBerryTier;
			tMP_Text.text = currentBerryTier.ToString();
		}
		plantBedUpgrade_ProducedText.text = selectedPlantBed.GetXP() + selectedPlantBed.GetNextLevelXpRequirementString();
		plantBedUpgrade_XPbarFill.fillAmount = selectedPlantBed.GetXPBarFill();
		if (selectedPlantBed.currentBerryTier < 11)
		{
			plantBedUpgrade_SeedCostToUpgradeText.text = GameManager.Singleton.FormatMoney(ShopAndUpgradesManager.Singleton.BerryUpgradesSeedPriceList[selectedPlantBed.currentBerryTier + 1]);
		}
		else
		{
			plantBedUpgrade_SeedCostToUpgradeText.text = "MAX";
		}
	}

	public void UpdateHoleLevelProgressUI(float _fillAmount)
	{
		holeMoveJuice_CurrentProgress_Fill.fillAmount = _fillAmount;
		holeMoveJuice_CurrentProgress_Fill.color = holeLevelGradient.Evaluate(_fillAmount);
	}

	public void PlayFeedback_MoneyBanked()
	{
		hudFeedback_MoneyPickup?.PlayFeedbacks();
	}

	public void PlayFeedback_MoneyHeldPickUp()
	{
		hudFeedback_HeldMoneyPickup?.PlayFeedbacks();
	}

	public void PlayFeedback_SeedHeldPickUp()
	{
		hudFeedback_SeedPickup?.PlayFeedbacks();
	}

	public void PlayFeedback_PiggyBankPickUp()
	{
		hudFeedback_PiggyBankPickUp?.PlayFeedbacks();
	}

	public void UpgradeTree_HideDescriptionPanel()
	{
		UpgradeTree_DescriptionBox_Parent.SetActive(value: false);
	}

	public void UpgradeTree_UpdateDescriptionPanel(string _descriptionText, string _detailText, string _priceText)
	{
		UpgradeTree_DescriptionBox_Parent.SetActive(value: true);
		UpgradeTree_DescriptionBox_DescriptionText.text = _descriptionText;
		UpgradeTree_DescriptionBox_DetailText.text = _detailText;
		UpgradeTree_DescriptionBox_PriceText.text = _priceText;
	}

	public IEnumerator UpgradeTree_UpdateBerryCultistAmountsDisplay()
	{
		yield return null;
		List<int> list = new List<int>();
		for (int i = 0; i < 12; i++)
		{
			list.Add(0);
		}
		foreach (BerryCultist_AI spawnedCultist in GameManager.Singleton.spawnedCultists)
		{
			if (spawnedCultist.GetBerryTier() <= 11)
			{
				list[spawnedCultist.GetBerryTier()]++;
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (list[j] > 0)
			{
				upgradeTree_CultistsAmountDisplays[j].gameObject.SetActive(value: true);
				upgradeTree_CultistsAmountDisplays[j].amtDisplay.text = list[j].ToString();
			}
			else
			{
				upgradeTree_CultistsAmountDisplays[j].gameObject.SetActive(value: false);
			}
		}
	}

	public void HideAbilityUI_GoldRush()
	{
		berryBlitz_UI_Parent.SetActive(value: false);
	}

	public void HideAbilityUI_BigHole()
	{
		bigHole_UI_Parent.SetActive(value: false);
	}

	public void ShowAbilityUI_GoldRush()
	{
		berryBlitz_UI_Parent.SetActive(value: true);
	}

	public void ShowAbilityUI_BigHole()
	{
		bigHole_UI_Parent.SetActive(value: true);
	}

	public void UpdateHoleGrowthPrestigeUI(float _fillAmt)
	{
		holePrestigeUI_CurrentProgress_Fill.fillAmount = _fillAmt;
	}

	public void UpdateHoleMoveJuiceUI()
	{
		if (PlayerStats.Singleton.holeMove_IsUnlocked)
		{
			holeMoveJuice_UIGroup.SetActive(value: true);
			float fillAmount = GameManager.Singleton.holeMoveJuice_Curr / (float)PlayerStats.Singleton.holeMoveJuiceCapacity_Curr;
			holeMoveJuice_CurrentProgress_Fill.fillAmount = fillAmount;
		}
		else
		{
			holeMoveJuice_UIGroup.SetActive(value: false);
		}
	}

	private void HandleRoundTimer()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing)
		{
			roundTimer_Display.gameObject.SetActive(value: true);
			roundTimer_Display.text = FloatToTimeString(GameManager.Singleton.roundTimer_Curr);
		}
		else
		{
			roundTimer_Display.gameObject.SetActive(value: false);
		}
	}

	public static string FloatToTimeString(float timeInSeconds)
	{
		int num = Mathf.FloorToInt(timeInSeconds);
		int num2 = num / 3600;
		int num3 = num % 3600 / 60;
		int num4 = num % 60;
		if (num2 > 0)
		{
			return $"{num2:D2}:{num3:D2}:{num4:D2}";
		}
		return $"{num3:D2}:{num4:D2}";
	}

	public void DisplayNewCultistInfo(string _name, int _upgradeCost)
	{
		cultistInfoDisplayGroup.SetActive(value: true);
		cultistsName_Display.text = _name;
		if (_upgradeCost == -1)
		{
			cultistsUpgradeCost_Display.text = "";
		}
		else
		{
			cultistsUpgradeCost_Display.text = "++ *" + _upgradeCost + " ++";
		}
	}

	public void HideCultistInfo()
	{
		cultistInfoDisplayGroup.SetActive(value: false);
	}

	public void DisplayNewHintText(string _hint)
	{
		hintText_DisplayGroup.SetActive(value: true);
		hintText_Text.text = _hint;
	}

	public void HideHintText()
	{
		hintText_DisplayGroup.SetActive(value: false);
	}

	public void UpdateKickChargeUI(float _fillVal)
	{
		kickCharge_FillImage.fillAmount = _fillVal;
		kickCharge_FillImage.color = kickCharge_Gradient.Evaluate(_fillVal);
	}

	public void ShowBigTextPopUp(int _index)
	{
		HideAllBigTextPopUps();
		BigTextPopUps_MasterList[_index].SetActive(value: true);
		if (bigText_Coroutine != null)
		{
			StopCoroutine(bigText_Coroutine);
		}
		bigText_Coroutine = StartCoroutine(HandleBigTextPopUpFadingWithTime());
	}

	private IEnumerator HandleBigTextPopUpFadingWithTime()
	{
		yield return new WaitForSeconds(3f);
		HideAllBigTextPopUps();
	}

	public void HideAllBigTextPopUps()
	{
		for (int i = 0; i < BigTextPopUps_MasterList.Count; i++)
		{
			BigTextPopUps_MasterList[i].SetActive(value: false);
		}
	}

	public void HideAllCurrencyDisplays()
	{
		currencyDisplay_BankedMoney.SetActive(value: false);
		currencyDisplay_HeldMoney.SetActive(value: false);
		currencyDisplay_StarOrbs.SetActive(value: false);
		currencyDisplay_GrowthModifier.SetActive(value: false);
		currencyDisplay_CanAffordBerryBuddyNotification_Backer.SetActive(value: false);
		currencyDisplay_CanAffordBerryBuddyNotification_Text.SetActive(value: false);
	}

	public void ShowAllCurrencyDisplays()
	{
		currencyDisplay_BankedMoney.SetActive(value: true);
		currencyDisplay_HeldMoney.SetActive(value: true);
		currencyDisplay_StarOrbs.SetActive(value: true);
		currencyDisplay_GrowthModifier.SetActive(value: true);
	}

	public void ToggleHud()
	{
		hudToggle = !hudToggle;
		if (hudToggle)
		{
			uiCanvas.gameObject.SetActive(value: false);
			if (additionalHudToggles.Count <= 0)
			{
				return;
			}
			{
				foreach (GameObject additionalHudToggle in additionalHudToggles)
				{
					additionalHudToggle.SetActive(value: false);
				}
				return;
			}
		}
		uiCanvas.gameObject.SetActive(value: true);
		if (additionalHudToggles.Count <= 0)
		{
			return;
		}
		foreach (GameObject additionalHudToggle2 in additionalHudToggles)
		{
			additionalHudToggle2.SetActive(value: true);
		}
	}

	public void QuitToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void OpenSteamStorePage()
	{
		Application.OpenURL("https://store.steampowered.com/app/3370870/Berry_Bury_Berry/");
	}

	public void ShowDroppedMoneyEffects(int _amtDropped)
	{
		StartCoroutine(DroppedMoneyDisplay_Coroutine(_amtDropped));
	}

	private IEnumerator DroppedMoneyDisplay_Coroutine(int _amtDropped)
	{
		currencyDisplay_DroppedMoney.gameObject.SetActive(value: true);
		string[] arguments = new string[1] { _amtDropped.ToString() };
		currencyDisplay_DroppedMoney.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("Hud_WoopsYouDroppedMoney", arguments).Result;
		hudFeedback_DroppedMoney?.PlayFeedbacks();
		yield return new WaitForSeconds(6f);
		currencyDisplay_DroppedMoney.gameObject.SetActive(value: false);
	}

	private void HandleGrowthModDisplayUI()
	{
		if (GameManager.Singleton.GetBlitzCurrentTimer() > 0f && !forceHide_StatusEffectBars)
		{
			growthMod_Blitz_Parent.SetActive(value: true);
			growthMod_Blitz_Fill.fillAmount = GameManager.Singleton.GetBlitzCurrentTimer() / PlayerStats.Singleton.goldRush_Duration_Max;
			growthMod_Blitz_TimerText.text = GameManager.Singleton.GetBlitzCurrentTimer().ToString("F0");
		}
		else
		{
			growthMod_Blitz_Parent.SetActive(value: false);
		}
		if (GameManager.Singleton.GetJuicedCurrentAmt() > 0f && !forceHide_StatusEffectBars)
		{
			growthMod_Juiced_Parent.SetActive(value: true);
			growthMod_Juiced_Fill.fillAmount = GameManager.Singleton.GetJuicedCurrentAmt() / GameManager.Singleton.GetJuicedMaxAmt();
			growthMod_Juiced_TimerText.text = FormatHelper.SecondsToMinuteString(GameManager.Singleton.GetJuicedCurrentAmt());
		}
		else
		{
			growthMod_Juiced_Parent.SetActive(value: false);
		}
	}

	public void DisableHudForCutscenes()
	{
		crosshairsForcedDisabled = true;
		HideAbilityUI_BigHole();
		HideAbilityUI_GoldRush();
		forceHide_StatusEffectBars = true;
	}

	public void EnableCrossHairs()
	{
		crosshairsForcedDisabled = false;
	}

	private void HandleMiscExtraHudDisplays()
	{
		if (OptionsManager.Singleton.speedrunTimer_Setting == 1)
		{
			miscExtra_SpeedRunTimer.gameObject.SetActive(value: true);
			miscExtra_SpeedRunTimer.text = FormatHelper.FormatTimeSmartWithMs(GameManager.Singleton.GetCurrentTotalTime_ForSpeedrunTimer());
		}
		else
		{
			miscExtra_SpeedRunTimer.gameObject.SetActive(value: false);
		}
		if (OptionsManager.Singleton.showHoleUI_Setting == 1)
		{
			miscExtra_HoleLevelDisplay.gameObject.SetActive(value: true);
			if (PlayerStats.Singleton.holeGrowth_Level == 19)
			{
				miscExtra_HoleLevelDisplay.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("Generic_Level", null, FallbackBehavior.UseProjectSettings).Result + " MAX";
				return;
			}
			miscExtra_HoleLevelDisplay.text = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("Generic_Level", null, FallbackBehavior.UseProjectSettings).Result + " " + (PlayerStats.Singleton.holeGrowth_Level + 1) + " (" + GameManager.Singleton.holePrestigeCurrPercent.ToString("F0") + "%)";
		}
		else
		{
			miscExtra_HoleLevelDisplay.gameObject.SetActive(value: false);
		}
	}

	private void HandleCrossHairSettings()
	{
		crosshair_Basic_Image.gameObject.transform.localScale = Vector3.one * ((float)OptionsManager.Singleton.crosshair_Size_Setting * OptionsManager.Singleton.crosshair_ScaleMult_InGame);
		crosshair_Basic_Image.color = OptionsManager.Singleton.crosshair_Color_List[OptionsManager.Singleton.crosshair_Color_Setting];
		crosshair_Usable_Image.color = OptionsManager.Singleton.crosshair_Color_List[OptionsManager.Singleton.crosshair_Color_Setting];
	}

	public void ShowWakingUpPopupInShop()
	{
		wakingUpTextPopUp.SetActive(value: true);
	}

	public void UpdateUiScale()
	{
		hudScale_Object.transform.localScale = Vector3.one * OptionsManager.Singleton.uiScale_Setting;
	}
}
