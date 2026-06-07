using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Obj_AcademyCardSet_SecretVault : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Func_PerlinNoiseFloat perlinNoiseFloat;

	[SerializeField]
	private Image image_Frame_Selected;

	[SerializeField]
	[FormerlySerializedAs("list_CardNodes")]
	private List<GameObject> list_TowerCardNodes;

	[SerializeField]
	private List<GameObject> list_TetrisCardNodes;

	[SerializeField]
	private Button button;

	[SerializeField]
	private List<UI_CardFace> list_RuneCardFaces;

	[SerializeField]
	private GameObject node_TetrisCards;

	[SerializeField]
	private Transform node_RelicIconLayout;

	[SerializeField]
	private List<UI_Obj_RelicItem> list_RelicItems;

	private UI_MapScene_SecretVault_Popup parent;

	private Action<int> OnClickCallback;

	private List<UI_Obj_ShopCard> list_CreatedTowerCards;

	private List<UI_Obj_ShopCard> list_CreatedTetrisCards;

	private eItemType[] towerSlotContent;

	private CardData[] tetrisSlotContent;

	public List<UI_Obj_ShopCard> List_CreatedTowerCards => null;

	public List<UI_Obj_ShopCard> List_CreatedTetrisCards => null;

	public void Setup(UI_MapScene_SecretVault_Popup parent, bool isRerollAvailable, Action<int> OnClickCallback)
	{
	}

	public void SetTowerCard(UI_Obj_ShopCard card)
	{
	}

	private void OnClickTowerCard(UI_Obj_ShopCard card)
	{
	}

	public void SetTetrisCard(UI_Obj_ShopCard card)
	{
	}

	private void OnClickTetrisCard(UI_Obj_ShopCard card)
	{
	}

	public void PlaySelectedAnim()
	{
	}

	public void PlayRerollAnim()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void SetupRuneDisplay(List<eItemType> list_RuneTypes)
	{
	}

	public void RemoveTowerCardFromNode(eItemType itemType)
	{
	}

	public void RemoveTetrisCardFromNode(UI_Obj_ShopCard card)
	{
	}

	public void RemoveSelectedTetrisCardByCardData(TetrisCardData data)
	{
	}

	public int GetFirstMissingTetrisIndex()
	{
		return 0;
	}

	public void AddRelicDisplay(eItemType itemType)
	{
	}

	public void RemoveRelicDisplay(eItemType itemType)
	{
	}
}
