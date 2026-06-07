using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorTriggeredByButton : DynamicObjectBase
{
	public enum ButtonType
	{
		KeepPressing = 0,
		PressOnce = 1
	}

	[SerializeField]
	private LevelButtonBase button;

	[SerializeField]
	private ButtonType buttonType;

	[SerializeField]
	private bool invertedLogic;

	[SerializeField]
	private float pressOnceTriggerDelay;

	[SerializeField]
	private bool shouldResetWhenRecyling;

	private Animator animator;

	private bool isButtonChangedState;

	private bool isFirstTimePressed;

	private bool delayedIsOn;

	private float timeCounter;

	public event Action<bool> OnButtonChangedEvent;

	protected override void Awake()
	{
		base.Awake();
		isButtonChangedState = false;
		base.RestoresPosition = false;
		isFirstTimePressed = false;
		timeCounter = 0f;
		animator = GetComponent<Animator>();
		if (button != null)
		{
			button.OnChangedState += ButtonChangedStateHandler;
		}
	}

	public override void SetupToAction()
	{
		base.SetupToAction();
		animator.SetBoolIfExist("Reset", value: false);
		isButtonChangedState = false;
		isFirstTimePressed = false;
	}

	private void Update()
	{
		if (base.IsInAction && buttonType == ButtonType.PressOnce && isFirstTimePressed && !isButtonChangedState)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter > pressOnceTriggerDelay)
			{
				animator.SetBool("Button", delayedIsOn);
				this.OnButtonChangedEvent?.Invoke(delayedIsOn);
				isButtonChangedState = true;
			}
		}
	}

	public void SetButton(LevelButtonBase levelButton, bool isInvertedLogic = false, bool isPressOnce = false)
	{
		invertedLogic = isInvertedLogic;
		buttonType = (isPressOnce ? ButtonType.PressOnce : ButtonType.KeepPressing);
		button = levelButton;
		button.OnChangedState += ButtonChangedStateHandler;
		animator.SetBool("Button", invertedLogic ? (!button.IsOn) : button.IsOn);
	}

	private void ButtonChangedStateHandler(bool isOn)
	{
		isOn = (invertedLogic ? (!isOn) : isOn);
		switch (buttonType)
		{
		case ButtonType.KeepPressing:
			animator.SetBool("Button", isOn);
			this.OnButtonChangedEvent?.Invoke(isOn);
			break;
		case ButtonType.PressOnce:
			if (!isFirstTimePressed)
			{
				if (pressOnceTriggerDelay <= 0f || !base.IsInAction)
				{
					animator.SetBool("Button", isOn);
					this.OnButtonChangedEvent?.Invoke(isOn);
					isButtonChangedState = true;
				}
				delayedIsOn = isOn;
				isFirstTimePressed = true;
			}
			break;
		}
	}

	public override void Recycle()
	{
		base.Recycle();
		animator.SetBoolIfExist("Reset", shouldResetWhenRecyling);
		if (button != null)
		{
			animator.SetBool("Button", invertedLogic ? (!button.IsOn) : button.IsOn);
		}
		else
		{
			animator.SetBool("Button", invertedLogic);
		}
		isButtonChangedState = false;
		isFirstTimePressed = false;
		timeCounter = 0f;
	}

	private void OnDrawGizmos()
	{
		if (!(button == null))
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(base.transform.position, 0.25f);
			Gizmos.DrawSphere(button.transform.position, 0.25f);
			Gizmos.DrawLine(base.transform.position, button.transform.position);
		}
	}
}
