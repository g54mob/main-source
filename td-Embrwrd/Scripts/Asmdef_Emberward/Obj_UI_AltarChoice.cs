using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obj_UI_AltarChoice : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Button button;

	[SerializeField]
	private eAltarEffectType altarEffectType;

	[SerializeField]
	private Image image_Unavailable;

	[SerializeField]
	private Image image_Frame_Selected;

	[SerializeField]
	private UI_Obj_ShopCard shopCard;

	[SerializeField]
	private TMP_Text text_Cost;

	public Action<eAltarEffectType> OnSelectedCallback;

	public eAltarEffectType AltarEffectType => default(eAltarEffectType);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(Action<eAltarEffectType> callback)
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void TriggerSelectedAnimation()
	{
	}

	private void OnClickButton()
	{
	}

	public void ToggleUseable(bool isUseable)
	{
	}

	public void SetCostText(string text, bool isEnoughGem)
	{
	}

	public void SetCardFace(eItemType itemType)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
