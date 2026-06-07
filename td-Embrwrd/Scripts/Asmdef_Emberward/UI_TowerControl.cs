using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TowerControl : AUISituational
{
	[SerializeField]
	private List<RectTransform> list_MouseDetectRects;

	[Header("按鈕:升級")]
	[SerializeField]
	private UI_HoldableButton button_Upgrade;

	[SerializeField]
	[Header("按鈕:賣塔")]
	private UI_HoldableButton button_Sell;

	[Header("按鈕:目標優先權")]
	[SerializeField]
	private TwoMouseButtonButton button_TargetPriority;

	[Header("按鈕Layout")]
	[SerializeField]
	private VerticalLayoutGroup layoutGroup_Buttons;

	[SerializeField]
	[Header("按鈕區塊:升級")]
	private Transform node_UpgradeButton;

	[Header("按鈕區塊:賣塔")]
	[SerializeField]
	private Transform node_Sell;

	[Header("按鈕區塊:目標優先權")]
	[SerializeField]
	private Transform node_TargetPriority;

	[Header("Demo中不可升級的提示")]
	[SerializeField]
	private Transform node_UpgradeLockedInDemo;

	[SerializeField]
	private Transform node_CantUpgrade;

	[Header("無法切換目標的提示")]
	[SerializeField]
	private Transform node_CannotChangeTargetPriority;

	[SerializeField]
	[Header("按鈕:強制啟動砲塔(遠古火焰效果)")]
	private UI_HoldableButton button_ForceActivateTower;

	[Header("按鈕區塊:強制啟動")]
	[SerializeField]
	private Transform node_ForceActivateTower;

	[SerializeField]
	[Header("文字:強制啟動砲塔價格")]
	private TMP_Text text_ForceActivateTowerCost;

	[SerializeField]
	[Header("區塊:重骰骰子塔")]
	private GameObject node_RerollDiceTower;

	[SerializeField]
	[Header("按鈕:重骰骰子塔")]
	private UI_HoldableButton button_RerollDiceTower;

	[Header("重骰骰子塔價格")]
	[SerializeField]
	private TMP_Text text_RerollDiceTowerCost;

	[Header("區塊:廢料坦克強化限制")]
	[SerializeField]
	private GameObject node_ScrapTankEnhanceLimit;

	[Header("按鈕:廢料坦克強化限制")]
	[SerializeField]
	private UI_HoldableButton button_ScrapTankEnhanceLimit;

	[SerializeField]
	[Header("廢料坦克強化限制進度_文字")]
	private TMP_Text text_ScrapTankEnhanceRate;

	[Header("廢料坦克強化限制進度_圖片")]
	[SerializeField]
	private Image image_ScrapTankEnhanceRate;

	[SerializeField]
	[Header("區塊:鑽地塔額外按鈕")]
	private GameObject node_DrillTowerExtraButton;

	[SerializeField]
	[Header("鑽地塔額外按鈕")]
	private UI_HoldableButton button_DrillTowerExtra;

	[SerializeField]
	[Header("鑽地塔額外按鈕價格")]
	private TMP_Text text_DrillTowerExtraCost;

	private int drillTowerExtraUseCost;

	[SerializeField]
	[Header("文字:升級費用")]
	private TMP_Text text_UpgradeCostPrefix;

	[SerializeField]
	[Header("文字:升級費用數值")]
	private TMP_Text text_UpgradeCost;

	[SerializeField]
	[Header("文字:賣塔價格")]
	private TMP_Text text_SellPricePrefix;

	[Header("文字:賣塔價格數值")]
	[SerializeField]
	private TMP_Text text_SellPrice;

	[Header("文字:目標優先權")]
	[SerializeField]
	private TMP_Text text_TargetPriorityType;

	[SerializeField]
	private TMP_Text text_TowerName;

	[SerializeField]
	private TMP_Text text_TowerInfo;

	[SerializeField]
	private Image image_TowerIcon;

	[SerializeField]
	private Image image_TowerNameFrame;

	[SerializeField]
	private Transform node_Upgrade;

	[SerializeField]
	private GameObject updateClickDetectRect;

	[SerializeField]
	private CanvasGroup canvasGroup_Upgrade;

	[SerializeField]
	private GameObject node_UpgradeKeybindTip;

	[SerializeField]
	private Image image_UpgradeButtonBG;

	[SerializeField]
	private Sprite sprite_BG_NoUpgrade;

	[SerializeField]
	private Sprite sprite_BG_UpgradeA;

	[SerializeField]
	private Sprite sprite_BG_UpgradeB;

	[SerializeField]
	private GameObject node_CantSellInBattle;

	[SerializeField]
	private List<UI_Obj_UpgradeTowerButton_V3> list_UpgradeButtons;

	[SerializeField]
	private GameObject node_ScorchTowerControl;

	[SerializeField]
	private UI_HoldableButton button_ScorchTowerInverseRotation;

	private ABaseTower curTower;

	private bool isClickedOnThisUI;

	private int skipClickDetectionFrame;

	private Color text_UpgradeCostNormalColor;

	private Canvas canvas;

	private bool isScrapTankTower;

	private Tower_ScrapTank scrapTankTowerRef;

	private bool isDiceTower;

	private ARerollableTower diceTowerRef;

	private float diceRerollTimer;

	private bool isDrillTower;

	private CR_DestroySingleBlock drillTowerRef;

	private ABaseTower lastUIUpdateTower;

	private bool isUpgradeMenuOpen;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPlayerTowerUpgradeSuccess(ABaseTower tower, ABaseTower.eUpgradeType type)
	{
	}

	private void OnUpgradeButtonPointerEnter(ABaseTower.eUpgradeType type)
	{
	}

	private void OnUpgradeButtonPointerExit(ABaseTower.eUpgradeType type)
	{
	}

	private void OnUpgradeButtonClick(ABaseTower.eUpgradeType upgradeType)
	{
	}

	private void OnClickTowerOnField(ABaseTower tower)
	{
	}

	private void OnCoinChanged(int coin, int delta)
	{
	}

	private void UpdateUpgradeCostTextColor()
	{
	}

	private void OnTowerDespawn(ABaseTower tower)
	{
	}

	private void OnTowerStatChanged(ABaseTower tower)
	{
	}

	private void UpdateUIContent(ABaseTower tower)
	{
	}

	private void OnTowerRecordChange(ABaseTower tower)
	{
	}

	private void UpdateTowerInfoText(ABaseTower tower)
	{
	}

	private void ToggleUpgradeButtonsClickable(bool isClickable)
	{
	}

	private void OnClickButtonUpgrade()
	{
	}

	private void RequestUpgradeTower(ABaseTower.eUpgradeType upgradeType)
	{
	}

	private void OnTowerUpgradeFailed(ABaseTower tower, ABaseTower.eUpgradeType type)
	{
	}

	private void OnClickButtonSell()
	{
	}

	private void OnClickTargetPriority_LeftClick()
	{
	}

	private void OnClickTargetPriority_RightClick()
	{
	}

	private void OnClickDrillTowerExtraButton()
	{
	}

	private void OnClickForceActivateTower()
	{
	}

	private void OnClickRerollDiceTower()
	{
	}

	private void OnClickScorchTowerInverseRotation()
	{
	}

	private void Close()
	{
	}

	private bool IsClickedOnThisUI()
	{
		return false;
	}

	private void Update()
	{
	}

	private void SetPositionToTower()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public void UIMustInScreen(RectTransform rectTransform, Canvas canvas)
	{
	}

	private static Bounds GetCombinedBounds(RectTransform rt)
	{
		return default(Bounds);
	}
}
