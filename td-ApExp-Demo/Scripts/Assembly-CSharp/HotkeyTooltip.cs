using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotkeyTooltip : MonoBehaviour
{
	[SerializeField]
	private Hotkey hotkey;

	[SerializeField]
	private Image playerTint;

	[SerializeField]
	private TextMeshProUGUI actionText;

	private ControllerType controllerType = ControllerType.KeyboardMouse;

	private void Awake()
	{
	}

	public void SetActionText(string actionString)
	{
		actionText.text = actionString;
	}

	public void SetPlayerTint(Color color)
	{
		playerTint.color = color;
	}

	public void SetControllerType(ControllerType controller)
	{
		hotkey.ShowButtonText(controller == ControllerType.KeyboardMouse);
		controllerType = controller;
		hotkey.UpdateIconAndKey(controllerType);
	}
}
