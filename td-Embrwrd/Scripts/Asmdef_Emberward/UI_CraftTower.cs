using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CraftTower : AUISituational, IDropHandler, IEventSystemHandler
{
	[SerializeField]
	[Header("砲台卡片的放置節點")]
	private Transform node_DropArea_Cannon;

	[SerializeField]
	[Header("底座卡片的放置節點")]
	private Transform node_DropArea_Panel;

	[SerializeField]
	[Header("拖拉卡片過來時的容許範圍")]
	private float dropRange;

	[SerializeField]
	[Header("合成的物品名稱文字")]
	private TMP_Text text_ItemName;

	[Header("合成的物品屬性文字")]
	[SerializeField]
	private TMP_Text text_ItemStats;

	[Header("按鈕:建造")]
	[SerializeField]
	private Button button_Craft;

	[Header("按鈕:關閉")]
	[SerializeField]
	private Button button_Close;

	[Header("--- 資料")]
	[SerializeField]
	private UI_Obj_Card dockedCard_Cannon;

	[SerializeField]
	private UI_Obj_Card dockedCard_Panel;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnToggleCraftTowerUI(bool isOn)
	{
	}

	private void Start()
	{
	}

	private void OnRequestUpdateCraftTowerTooltip()
	{
	}

	private void OnCardRemoveFromCraftTowerUI(UI_Obj_Card card)
	{
	}

	private void OnClick_CraftButton()
	{
	}

	private void OnClick_CloseButton()
	{
	}

	public void OnDrop(PointerEventData eventData)
	{
	}

	private void UpdateStatPageContent()
	{
	}

	private GameObject GetSprite(PointerEventData eventData)
	{
		return null;
	}
}
