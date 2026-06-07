using System;
using System.Collections.Generic;
using Rewired.Glyphs.UnityUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Obj_AcademyCardSet : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
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
	private Button button_Reroll;

	[SerializeField]
	private Image image_RerollAvailable;

	[SerializeField]
	private Image image_RerollUnavailable;

	[SerializeField]
	private Image image_RerollIcon;

	[Header("搖桿控制的提示")]
	[SerializeField]
	private UnityUITextMeshProGlyphHelper text_JoystickControlTip;

	private int index;

	private Action<int> OnClickCallback;

	private List<UI_Obj_ShopCard> list_CreatedTowerCards;

	private List<UI_Obj_ShopCard> list_CreatedTetrisCards;

	private bool isSelectOutlineOn;

	private UI_MapScene_Academy_Popup parentUI;

	public Button Button => null;

	public Button Button_Reroll => null;

	public List<UI_Obj_ShopCard> List_CreatedTowerCards => null;

	public List<UI_Obj_ShopCard> List_CreatedTetrisCards => null;

	public void Setup(int index, bool isRerollAvailable, Action<int> OnClickCallback, UI_MapScene_Academy_Popup parentUI)
	{
	}

	public void SetTowerCardToNode(UI_Obj_ShopCard card, int index)
	{
	}

	public void SetTetrisCardToNode(UI_Obj_ShopCard card, int index)
	{
	}

	private void OnClickCard(UI_Obj_ShopCard card)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnAcademyRerollCountChanged(int value)
	{
	}

	public void ToggleRerollButton(bool doShow)
	{
	}

	private void UpdateButtonState(bool isClickable)
	{
	}

	private void OnClickButton()
	{
	}

	private void OnClickReroll()
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

	public void ToggleSelectedEffect(bool isOn)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}
}
