using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_DraggableCard : Selectable, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler, ISubmitHandler, ISelectHandler, IDeselectHandler
{
	[SerializeField]
	private new Animator animator;

	[SerializeField]
	private RectTransform rectTransform;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private UI_CardFace cardFace;

	private bool isDragging;

	private Vector3 startDragPosition;

	private Vector3 startDragMousePos;

	private Transform node_CardPool;

	private Transform node_DraggingCardParent;

	private int siblingIndexInCardPool;

	[SerializeField]
	private LayoutElement layoutElement;

	[SerializeField]
	private UI_Func_FollowUITarget func_FollowUITarget;

	[SerializeField]
	private UI_Obj_CardSlot currentCardSlot;

	private TowerIngameData towerIngameData;

	private UI_TowerArrange_Popup ref_TowerArrangeUI;

	public Action<UI_DraggableCard> OnCardStartDragCallback;

	public Action<UI_DraggableCard> OnCardEndDragCallback;

	public Action<UI_DraggableCard> OnCardClickCallback;

	private TowerSettingData cache_TowerSettingData;

	private bool isMouseOver;

	private float mouseStayTime;

	private bool isTooltipOn;

	private bool isDraggable;

	private bool isSelectedByJoystick;

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}

	protected override void Awake()
	{
	}

	public void SetupContent(TowerIngameData data)
	{
	}

	public void ForceCompleteFollowing()
	{
	}

	public void SetupReference(UI_TowerArrange_Popup towerArrangeUI, Transform node_CardPool, Transform node_DraggingCardParent)
	{
	}

	public void ToggleDraggable(bool isOn)
	{
	}

	public void StartCardFollowing()
	{
	}

	public void ReturnToCardPool()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	public TowerIngameData GetTowerIngameData()
	{
		return null;
	}

	public bool IsInCardSlot()
	{
		return false;
	}

	public void SetCardToSlotPosition()
	{
	}

	public UI_Obj_CardSlot GetCardSlot()
	{
		return null;
	}

	public void RegisterToCardSlot(UI_Obj_CardSlot slot)
	{
	}

	public void ToggleRaycast(bool isOn)
	{
	}

	public void ToggleSelectedEffect(bool isOn)
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}

	public void OnSubmit(BaseEventData eventData)
	{
	}
}
