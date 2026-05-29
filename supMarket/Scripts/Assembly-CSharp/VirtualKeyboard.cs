using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using __Third_Party__.Gamepad_UI_Module.Runtime;

public class VirtualKeyboard : MonoBehaviour, IBumperHandler, IEventSystemHandler, IConfirmHandler, ITriggerHandler, IWestButtonHandler, INorthButtonHandler
{
	public Action<bool> OnCharCaseChanged;

	[SerializeField]
	private TMP_InputField m_TextField;

	private int m_CarretPosition;

	private bool m_IsUpper;

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	public void PressKey(string key)
	{
	}

	public void PressSpace()
	{
	}

	public void PressDelete()
	{
	}

	public void IncreaseCarret()
	{
	}

	public void DecreaseCarret()
	{
	}

	private void SetCarretVisible(int pos)
	{
	}

	public void ChangeCharCase()
	{
	}

	public void OnConfirm(ButtonEventData eventData)
	{
	}

	public void OnConfirmHold(ButtonEventData eventData)
	{
	}

	public void OnBumperLeftPress(ButtonEventData eventData)
	{
	}

	public void OnBumperRightPress(ButtonEventData eventData)
	{
	}

	public void OnBumperLeftHold(ButtonEventData eventData)
	{
	}

	public void OnBumperRightHold(ButtonEventData eventData)
	{
	}

	public void OnTriggerLeftPress(ButtonEventData eventData)
	{
	}

	public void OnTriggerRightPress(ButtonEventData eventData)
	{
	}

	public void OnTriggerLeftHold(ButtonEventData eventData)
	{
	}

	public void OnTriggerRightHold(ButtonEventData eventData)
	{
	}

	public void OnWestButton(ButtonEventData eventData)
	{
	}

	public void OnNorthButton(ButtonEventData eventData)
	{
	}
}
