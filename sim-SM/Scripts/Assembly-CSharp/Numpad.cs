using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using __Third_Party__.Gamepad_UI_Module.Runtime;

public class Numpad : MonoBehaviour, IWestButtonHandler, IEventSystemHandler
{
	[SerializeField]
	private TMP_Text m_TextDisplay;

	private NumpadKeyButton[] m_Keys;

	private NumpadKeyFocusable[] m_FocusableKeys;

	[SerializeField]
	private UnityEvent m_WestEvent;

	[SerializeField]
	private int m_Limit;

	public string Value { get; private set; }

	public int Limit
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public event Action<string> ValueChanged
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

	public void Clear()
	{
	}

	private void OnKeyPressed(int obj)
	{
	}

	public void Delete()
	{
	}

	public void AddValue(int value)
	{
	}

	private void UpdateText()
	{
	}

	public void FocusOnKey(int i)
	{
	}

	public void ClearFocus()
	{
	}

	public void OnWestButton(ButtonEventData eventData)
	{
	}
}
