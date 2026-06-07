using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggeredByButtons : DynamicObjectBase
{
	[SerializeField]
	private List<LevelButtonBase> buttons = new List<LevelButtonBase>();

	[SerializeField]
	private bool isPressOnce;

	[SerializeField]
	private bool shouldResetWhenRecyling;

	private Animator animator;

	private bool isFirstTimePressed;

	protected override void Awake()
	{
		base.Awake();
		base.RestoresPosition = false;
		animator = GetComponent<Animator>();
		buttons.ForEach(delegate(LevelButtonBase button)
		{
			button.OnChangedState += ButtonChangedStateHandler;
		});
		isFirstTimePressed = false;
	}

	public override void SetupToAction()
	{
		base.SetupToAction();
		animator.SetBoolIfExist("Reset", value: false);
		isFirstTimePressed = false;
	}

	private void ButtonChangedStateHandler(bool isOn)
	{
		bool flag = CheckAllButtonsOn();
		if (isPressOnce)
		{
			if (!isFirstTimePressed && flag)
			{
				animator.SetBool("Button", flag);
				isFirstTimePressed = true;
			}
		}
		else
		{
			animator.SetBool("Button", flag);
		}
	}

	private bool CheckAllButtonsOn()
	{
		bool result = true;
		for (int i = 0; i < buttons.Count; i++)
		{
			if (!buttons[i].IsOn)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	public override void Recycle()
	{
		base.Recycle();
		animator.SetBoolIfExist("Reset", shouldResetWhenRecyling);
		animator.SetBool("Button", value: false);
		isFirstTimePressed = false;
	}

	private void OnDrawGizmos()
	{
		if (buttons.Count == 0)
		{
			return;
		}
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(base.transform.position, 0.25f);
		foreach (LevelButtonBase button in buttons)
		{
			if (!(button == null))
			{
				Gizmos.DrawSphere(button.transform.position, 0.25f);
				Gizmos.DrawLine(base.transform.position, button.transform.position);
			}
		}
	}
}
