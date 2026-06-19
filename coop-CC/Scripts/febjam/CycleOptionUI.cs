using Aggro.Core;
using UnityEngine;
using UnityEngine.EventSystems;

public class CycleOptionUI : EntityBehaviourBase, ISelectHandler, IEventSystemHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Animator animator;

	public Animator selectableAnimator;

	public EaseUI cycleLeftEaseUI;

	public EaseUI cycleRightEaseUI;

	private bool selected;

	public GameObject[] keyboardObjects;

	public GameObject[] GamepadObjects;

	private bool hover;

	private bool wasLastSelected;

	protected override void OnUpdatePresentation()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject == base.gameObject || currentSelectedGameObject == keyboardObjects[0] || currentSelectedGameObject == keyboardObjects[1])
		{
			wasLastSelected = true;
		}
		else if (currentSelectedGameObject == null && wasLastSelected && hover)
		{
			wasLastSelected = true;
		}
		else
		{
			wasLastSelected = false;
		}
		cycleLeftEaseUI.show = wasLastSelected;
		cycleRightEaseUI.show = wasLastSelected;
		GameObject[] array = keyboardObjects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(AggroInputManager.mode == InputMode.KBM);
		}
		array = GamepadObjects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(AggroInputManager.mode == InputMode.Gamepad);
		}
		if (!selected)
		{
			return;
		}
		if (AggroInputManager.input.Lobby.ChooseLeft.WasPressedThisFrame())
		{
			if (selectableAnimator != null)
			{
				selectableAnimator.SetTrigger("Pressed");
			}
			animator.SetTrigger("CycleLeft");
		}
		if (AggroInputManager.input.Lobby.ChooseRight.WasPressedThisFrame())
		{
			if (selectableAnimator != null)
			{
				selectableAnimator.SetTrigger("Pressed");
			}
			animator.SetTrigger("CycleRight");
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		hover = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hover = false;
	}
}
