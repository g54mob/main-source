using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_ShopCard : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public enum eCardSelectType
	{
		NONE = 0,
		BUYABLE = 1,
		SELECTABLE = 2
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private UI_CardFace cardFace;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_Price;

	[SerializeField]
	private TMP_Text text_Price;

	[SerializeField]
	private eCardSelectType cardSelectType;

	[SerializeField]
	private Func_PerlinNoiseFloat perlinNoiseFloat;

	private eItemType curItemType;

	private AItemSettingData itemData;

	private bool isClicked;

	private CardData cardData;

	private eCardType cardType;

	private int price;

	private Tweener cardMouseOverTweener;

	private bool isActivated;

	private bool isClickable;

	private bool doShowTooltip;

	public Action<UI_Obj_ShopCard> OnCardClicked;

	public Action<UI_Obj_ShopCard> OnCardMouseEnter;

	public Action<UI_Obj_ShopCard> OnCardMouseExit;

	public Action<UI_Obj_ShopCard> OnCardSelected;

	public Action<UI_Obj_ShopCard> OnCardDeselected;

	public eCardType DEBUG_CARD_TYPE;

	public UI_CardFace CardFace => null;

	public Button Button => null;

	public eItemType ItemType => default(eItemType);

	public AItemSettingData Data => null;

	public CardData CardData => null;

	public eCardType CardType => default(eCardType);

	public bool IsActivated => false;

	public static UI_Obj_ShopCard CreateCard(Transform parent, bool resetToLocalZero = true)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnDisable()
	{
	}

	public void OnClickButton()
	{
	}

	public void ToggleClickable(bool isClickable)
	{
	}

	public void SetupContent(eItemType itemType, eCardSelectType cardSelectType, int price)
	{
	}

	public void SetupContent(CardData cardData, eCardSelectType cardSelectType, int price)
	{
	}

	public void SetupContent(eCardType cardType, eCardSelectType cardSelectType, int price, string name)
	{
	}

	public void ToggleCardAsUnknown(bool isUnknown)
	{
	}

	public void UpdatePrice(int curCurrency)
	{
	}

	private void UpdateUI_ResourceCard(eCardType cardType, int value)
	{
	}

	private void UpdateUI(AItemSettingData itemData, eCardType cardType)
	{
	}

	public void TogglePerlinNoiseFloat(bool isOn)
	{
	}

	public void ToggleCard(bool isOn)
	{
	}

	public void ResetAnimation()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	public void ToggleInteractable(bool isInteractable)
	{
	}

	public void ToggleShowTooltip(bool isShow)
	{
	}

	public void ToggleShowTowerCost(bool isShow)
	{
	}

	public void ToggleShowAvailable(bool isAvailable)
	{
	}

	public void ToggleShowChosen(bool isChosen)
	{
	}

	public void ToggleSelectedEffect(bool isSelected)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void ShowTooltip(Vector3 extraOffset)
	{
	}

	public void HideTooltip()
	{
	}

	public string GetLocNameString()
	{
		return null;
	}

	public string GetLocTooltipString()
	{
		return null;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void PlayPurchaseAnimation()
	{
	}

	public void PlayPurchaseFailAnimation()
	{
	}

	public void SetSold()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	internal void UpdateRuneDisplay(int slotIndex, bool doPlayVfx)
	{
	}
}
