using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapScene_AcademyFreeChoose_Popup : APopupWindow
{
	private enum eState
	{
		SELECT_TOWERS = 0,
		SELECT_BLOCKS = 1,
		SELECT_RELIC = 2,
		DONE = 3
	}

	[SerializeField]
	[Header("標題/對話")]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_NPCDialog;

	[SerializeField]
	[Header("展示用 CardSet (僅顯示已選卡片)")]
	private UI_Obj_AcademyCardSet_FreeChoose displayCardSet;

	[Header("步驟1：砲塔清單容器/Prefab")]
	[SerializeField]
	private GameObject node_TowerList;

	[SerializeField]
	private Transform anchor_TowerList;

	[SerializeField]
	private GameObject prefab_ShopCard;

	[SerializeField]
	private Button button_ConfirmStep1;

	[Header("砲塔filter按鈕")]
	[SerializeField]
	private List<UI_JournalTowerFilterButton> list_TowerFilterButtons;

	[SerializeField]
	[Header("步驟2：方塊清單容器/確認")]
	private GameObject node_TetrisList;

	[SerializeField]
	private Transform anchor_TetrisList;

	[SerializeField]
	private Button button_ConfirmStep2;

	[SerializeField]
	[Header("步驟3：神器清單容器/確認")]
	private GameObject node_RelicList;

	[SerializeField]
	private Transform anchor_RelicList;

	[SerializeField]
	private Button button_ConfirmStep3;

	[Header("神器filter按鈕")]
	[SerializeField]
	private List<UI_JournalTowerFilterButton> list_RelicFilterButtons;

	[SerializeField]
	[Header("節奏/音效")]
	private float showCardInterval;

	[SerializeField]
	private UI_Obj_ShopCard card_SelectedRelic;

	[SerializeField]
	private List<UI_ScrollView_AutoScrollToSelected> list_ScrollViewAutoScroller;

	private eState state;

	private readonly List<eItemType> selectedTowers;

	private readonly List<TetrisCardData> selectedTetris;

	private eItemType selectedRelic;

	[SerializeField]
	private List<UI_Obj_ShopCard> list_TowerCards;

	[SerializeField]
	private List<UI_Obj_ShopCard> list_TetrisCards;

	[SerializeField]
	private List<UI_Obj_ShopCard> list_RelicCards;

	private List<eItemType> list_startingRunes;

	private List<eItemFilterType> list_AvailableTowerFilters;

	private List<eItemFilterType> list_AvailableRelicFilters;

	private int canChoose1x1Count;

	private int chosen1x1Count;

	private int canChoose2x2Count;

	private int chosen2x2Count;

	private eItemFilterType currentTowerFilter;

	private eItemFilterType currentRelicFilter;

	private float joystickMoveCooldown;

	private float timeSinceOpened;

	private UI_Obj_ShopCard curSelectedCard;

	protected override void Start()
	{
	}

	protected override void OnEnableProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private void BuildTowerSelectionList()
	{
	}

	private void OnTowerFilterClicked(eItemFilterType filterType, UI_JournalTowerFilterButton selectedFilterButton)
	{
	}

	public void UpdateTowerSelectableBySize()
	{
	}

	private void OnTowerCardClicked(UI_Obj_ShopCard card)
	{
	}

	private void OnConfirmStep1()
	{
	}

	private void BuildTetrisSelectionList()
	{
	}

	private void OnTetrisCardClicked(UI_Obj_ShopCard card)
	{
	}

	private void OnConfirmStep2()
	{
	}

	private void BuildRelicSelectionList()
	{
	}

	private void OnRelicFilterClicked(eItemFilterType filterType, UI_JournalTowerFilterButton selectedFilterButton)
	{
	}

	private void OnRelicCardClicked(UI_Obj_ShopCard card)
	{
	}

	private void OnConfirmStep3()
	{
	}

	private void ClearList(List<UI_Obj_ShopCard> list)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	public void DeselectTowerCard(eItemType itemType)
	{
	}

	public void DeselectTetrisCard(UI_Obj_ShopCard card)
	{
	}

	private void Update()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}

	private void SetSelectedCard(UI_Obj_ShopCard card)
	{
	}

	private bool SelectNodeByInputAxisDirection(List<UI_Obj_ShopCard> list_SelectableCards)
	{
		return false;
	}

	private UI_Obj_ShopCard GetNodeByInputAxisDirection(List<UI_Obj_ShopCard> list_Candidates)
	{
		return null;
	}
}
