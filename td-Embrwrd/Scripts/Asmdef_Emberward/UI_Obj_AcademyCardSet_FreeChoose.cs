using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Obj_AcademyCardSet_FreeChoose : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
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
	private List<UI_CardFace> list_RuneCardFaces;

	[SerializeField]
	private GameObject node_TetrisCards;

	private UI_MapScene_AcademyFreeChoose_Popup parent;

	private Action<int> OnClickCallback;

	private List<UI_Obj_ShopCard> list_CreatedTowerCards;

	private List<UI_Obj_ShopCard> list_CreatedTetrisCards;

	private eItemType[] towerSlotContent;

	private CardData[] tetrisSlotContent;

	public List<UI_Obj_ShopCard> List_CreatedTowerCards => null;

	public List<UI_Obj_ShopCard> List_CreatedTetrisCards => null;

	public void Setup(UI_MapScene_AcademyFreeChoose_Popup parent, bool isRerollAvailable, Action<int> OnClickCallback)
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

	public int GetFirstMissingTetrisIndex()
	{
		return 0;
	}

	public List<UI_Obj_ShopCard> GetAllBoundCards()
	{
		return null;
	}
}
