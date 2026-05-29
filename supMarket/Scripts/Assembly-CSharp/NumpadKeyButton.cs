using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using __Third_Party__.Gamepad_UI_Module.Runtime;

[RequireComponent(typeof(Button))]
public class NumpadKeyButton : MonoBehaviour, IConfirmHandler, IEventSystemHandler
{
	private Button m_Button;

	[SerializeField]
	private int m_Value;

	public int Value => 0;

	public event Action<int> KeyPressed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnButtonClicked()
	{
	}

	public void OnConfirm(ButtonEventData eventData)
	{
	}

	public void OnConfirmHold(ButtonEventData eventData)
	{
	}
}
