using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_RelicItem : Selectable, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private eItemType itemType;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private TMP_Text text_Value;

	private RelicSettingData settingData;

	private bool isEventRegistered;

	private Tweener cardMouseOverTweener;

	private Action<UI_Obj_RelicItem> OnItemSelectedCallback;

	public eItemType ItemType => default(eItemType);

	public void Setup(eItemType itemType, Action<UI_Obj_RelicItem> onItemSelectedCallback = null)
	{
	}

	protected override void OnDisable()
	{
	}

	private void OnSetRelicUIAppearUsed(eItemType type)
	{
	}

	private void OnSetRelicUIAppearUnused(eItemType type)
	{
	}

	private void OnRelicEffectTriggered(eItemType type)
	{
	}

	private void OnSetRelicUIValue(eItemType type, int value)
	{
	}

	public void SetValue(int value)
	{
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	private void ShowToolTip()
	{
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}
}
