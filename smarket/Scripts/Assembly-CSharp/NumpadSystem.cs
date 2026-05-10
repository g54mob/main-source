using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using __Third_Party__.Gamepad_UI_Module.Runtime;

public class NumpadSystem : MonoBehaviour, IConfirmHandler, IEventSystemHandler, IWestButtonHandler
{
	[SerializeField]
	private TMP_InputField m_NumberField;

	[SerializeField]
	private string m_Value;

	[SerializeField]
	private GameObject m_focusObject;

	[SerializeField]
	private bool m_willDeleteDollarSign;

	[SerializeField]
	private UnityEvent m_westEvent;

	private bool m_isFocused;

	private float m_InitialValue;

	public bool IsFocused
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void SetInputField(TMP_InputField field)
	{
	}

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	public void Init(float initPrice, bool isEmpty = false)
	{
	}

	public void PressNumber(int number)
	{
	}

	public void Backspace()
	{
	}

	public void PressPoint()
	{
	}

	public float GetValue()
	{
		return 0f;
	}

	public void RectifyText(string value)
	{
	}

	public void ForceClose(bool willResetValue = true)
	{
	}

	public void OnConfirm(ButtonEventData eventData)
	{
	}

	public void OnConfirmHold(ButtonEventData eventData)
	{
	}

	public void OnWestButton(ButtonEventData eventData)
	{
	}
}
