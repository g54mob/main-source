using UnityEngine;

public class ToggleController : MonoBehaviour
{
	[Header("Components")]
	public ButtonController onButton;

	public ButtonController offButton;

	[Header("State")]
	public bool isOn;

	[Header("Configuration")]
	public string playerPrefsID;

	private void Start()
	{
	}

	public void SetIsOnWithoutNotify(bool val)
	{
	}

	public void SetOn()
	{
	}

	public void SetOff()
	{
	}

	public void ButtonsVisualUpdate()
	{
	}

	public void OnValueChange()
	{
	}
}
