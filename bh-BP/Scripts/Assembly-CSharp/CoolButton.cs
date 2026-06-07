using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoolButton : CoolSelectable, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
	public static CoolButton sPressedBtn;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnHover;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnHoverExit;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnPressed;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnClicked;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnRightClicked;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnSelected;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnDeselected;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnStateChanged;

	[Header("Click Config")]
	public CoolButtonViz Viz;

	protected CoolButtonState _btnState;

	[Header("Refs")]
	protected bool _isInteractable;

	public Graphic ImgBackground;

	protected bool _isPointerDown;

	protected bool _isPointerInside;

	protected bool _isSelected;

	protected virtual void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected override void Start()
	{
	}

	public void SetViz(CoolButtonViz viz)
	{
	}

	public override bool IsInteractable()
	{
		return false;
	}

	public void SetInteractable(bool isOn, bool force = false)
	{
	}

	public virtual void ReevaluateState(bool force = false)
	{
	}

	protected virtual void RefreshViz(CoolButtonState btnState)
	{
	}

	public override void RunNavSFX()
	{
	}

	public virtual void SetButtonState(CoolButtonState btnState, bool force)
	{
	}

	public CoolButtonState GetState()
	{
		return default(CoolButtonState);
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
	}

	public void CancelPressState()
	{
	}

	public virtual void RunOnPointerUp(PointerEventData.InputButton btn)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}

	public override void OnSubmit(BaseEventData eventData)
	{
	}

	private void Reset()
	{
	}
}
