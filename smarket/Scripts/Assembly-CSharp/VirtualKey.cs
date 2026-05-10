using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class VirtualKey : MonoBehaviour
{
	[SerializeField]
	private string m_Value;

	[SerializeField]
	private VirtualKeyboard m_Keyboard;

	[SerializeField]
	private UnityEvent m_MyEvent;

	private TextMeshProUGUI m_ChildText;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnValidate()
	{
	}

	private void OnCharCaseChanged(bool isUpper)
	{
	}

	public void CallEvent()
	{
	}

	public void PressKey()
	{
	}

	public void PressSpace()
	{
	}
}
