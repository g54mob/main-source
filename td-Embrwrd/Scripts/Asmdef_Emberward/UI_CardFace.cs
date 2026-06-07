using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardFace : MonoBehaviour
{
	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private TMP_Text text_ItemName;

	[SerializeField]
	[Header("砲塔卡片節點")]
	private Transform node_TowerCard;

	[SerializeField]
	[Header("方塊卡片節點")]
	private Transform node_PanelCard;

	[SerializeField]
	[Header("方塊卡片 符文節點")]
	private Transform node_PanelRunes;

	[SerializeField]
	[Header("強化卡節點")]
	private Transform node_BuffCard;

	[SerializeField]
	[Header("HP 卡節點")]
	private Transform node_HPCard;

	[Header("金幣卡節點")]
	[SerializeField]
	private Transform node_CoinCard;

	[Header("Reroll 卡節點")]
	[SerializeField]
	private Transform node_RerollCard;

	[SerializeField]
	[Header("神器卡節點")]
	private Transform node_RelicCard;

	[SerializeField]
	[Header("符文卡節點")]
	private Transform node_RuneCard;

	[SerializeField]
	[Header("齒輪卡節點")]
	private Transform node_GearCard;

	[SerializeField]
	[Header("節點-腐化卡片")]
	private Transform node_Corrupted;

	[SerializeField]
	[Header("腐化圖示")]
	private Image image_Corrupted;

	[Header("選中卡片效果")]
	[SerializeField]
	private GameObject node_CardSelected;

	[Header("選中邊框 - 卡片")]
	[SerializeField]
	private Image image_SelectedBorder_Card;

	[SerializeField]
	[Header("選中邊框 - 神器")]
	private Image image_SelectedBorder_Relic;

	[SerializeField]
	[Header("選中邊框 - 符文")]
	private Image image_SelectedBorder_Rune;

	[SerializeField]
	[Header("砲塔 - 大小節點")]
	private Transform node_TowerSize;

	[SerializeField]
	[Header("砲塔 - 特殊大小節點")]
	private Transform nodes_SpecialTowerSize;

	[SerializeField]
	[Header("砲塔 - 特殊大小圖示")]
	private Image image_SpecialTowerSize;

	[Header("砲塔 - 花費節點")]
	[SerializeField]
	private Transform node_TowerCost;

	[Header("砲塔 - 大小文字")]
	[SerializeField]
	private TMP_Text text_TowerSize;

	[Header("砲塔 - 元素類型文字")]
	[SerializeField]
	private TMP_Text text_ElementType;

	[SerializeField]
	[Header("砲塔 - 花費文字")]
	private TMP_Text text_TowerCost;

	[SerializeField]
	[Header("符文卡片背景圖")]
	private Image image_RuneBG;

	[SerializeField]
	[Header("符文卡片背景光暈")]
	private Image image_RuneGlow;

	[SerializeField]
	[Header("方塊 - 符文列表")]
	private List<UI_Obj_TetrisCardRune> list_TetrisCardRunes;

	[SerializeField]
	[Header("方塊 - 特殊符文物件")]
	private UI_Obj_TetrisCardRune specialRune;

	[Header("方塊 - 特殊符文外框")]
	[SerializeField]
	private Image image_SpecialRuneOutline;

	[Header("當卡片不可使用時顯示的X圖片")]
	[SerializeField]
	private Image image_Unavailable;

	[SerializeField]
	[Header("當卡片被選中時顯示的標記圖片")]
	private Image image_Chosen;

	private eItemType itemType;

	private bool doShowName;

	private bool doOverrideName;

	private string overrideItemName;

	private bool isCorrupted;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLanguageChanged()
	{
	}

	private void UpdateCardName()
	{
	}

	public void SetupContent(eItemType itemType, eCardType cardType, Sprite iconSprite, bool showItemName = false)
	{
	}

	public void OverrideItemName(string name)
	{
	}

	public void SetupTetrisCardContent(TetrisCardData cardData)
	{
	}

	public void ToggleCardAsUnknown(bool isUnknown)
	{
	}

	public void ToggleShowAvailable(bool isAvailable)
	{
	}

	public void ToggleShowChosen(bool isChosen)
	{
	}

	public void ToggleIsCorrupted(bool isCorrupted)
	{
	}

	public void SetTowerDetail(eItemType itemType, bool showTowerSize, bool showTowerCost)
	{
	}

	public void SetIconColor(Color color)
	{
	}

	public void ToggleNameText(bool isOn)
	{
	}

	public void ToggleShowTowerCost(bool isOn)
	{
	}

	public Vector3 GetTetrisRunePosition(int index)
	{
		return default(Vector3);
	}

	public void ToggleSelectedEffect(bool isOn)
	{
	}
}
