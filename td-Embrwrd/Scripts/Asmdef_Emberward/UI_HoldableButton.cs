using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_HoldableButton : Button
{
	[Header("第一次觸發Hold需要多久")]
	[SerializeField]
	protected float triggerDelay;

	[SerializeField]
	[Header("是否會連續觸發")]
	protected bool doContinuousTriggerOnHold;

	[Header("按著多久會連續觸發一次")]
	[SerializeField]
	protected float triggerEventInterval;

	protected float eventTimer;

	protected float pressedTime;

	public Action OnButtonDown;

	public Action OnHoldButton;

	public Action OnButtonUp;

	private bool isLastFramePressed;

	private bool isPointerOnButton;

	private bool isFirstHoldEventCalled;

	public float PressedTime => 0f;

	protected override void Awake()
	{
	}

	public void Update()
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
	}
}
