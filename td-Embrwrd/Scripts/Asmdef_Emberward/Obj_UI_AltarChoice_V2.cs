using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obj_UI_AltarChoice_V2 : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Button button;

	[SerializeField]
	private eAltarEffectTypeV2 altarEffectType;

	[SerializeField]
	private Image image_Unavailable;

	[SerializeField]
	private Image image_Frame_Selected;

	[SerializeField]
	private RectTransform rectTransform_Frame;

	[SerializeField]
	private UI_Obj_ShopCard shopCard;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_SacrificeEffect;

	[SerializeField]
	private TMP_Text text_SacrificeDuration;

	[SerializeField]
	private TMP_Text text_AlreadyCompleted;

	[SerializeField]
	private TMP_Text text_InProgress;

	[SerializeField]
	private TMP_Text text_CompleteReward;

	[SerializeField]
	private float frameHeight_SmallMode;

	private eItemType perkEffect;

	public Action<eAltarEffectTypeV2> OnSelectedCallback;

	public Button Button => null;

	public eAltarEffectTypeV2 AltarEffectType => default(eAltarEffectTypeV2);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Setup(eItemType perkEffect, Action<eAltarEffectTypeV2> callback)
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void ToggleAlreadyCompleted(bool isCompleted)
	{
	}

	public void ToggleInProgress(bool isInProgress)
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

	public void SetRewardCardFace(eItemType itemType)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void SwitchToSmallMode()
	{
	}

	public void DeactiveButton()
	{
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}
}
