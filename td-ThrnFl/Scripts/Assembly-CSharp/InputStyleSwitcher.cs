using Rewired;
using UnityEngine;

public class InputStyleSwitcher : MonoBehaviour
{
	public InputActionGlyph.InputPriority inputPriority;

	private Player player;

	private void Start()
	{
		player = ReInput.players.GetPlayer(0);
	}

	private void Update()
	{
		Controller lastActiveController = player.controllers.GetLastActiveController();
		if (lastActiveController != null)
		{
			if (lastActiveController.type == ControllerType.Keyboard || lastActiveController.type == ControllerType.Mouse)
			{
				inputPriority = InputActionGlyph.InputPriority.PrioritizeKeyboardAndMouse;
			}
			else if (lastActiveController.type == ControllerType.Joystick)
			{
				inputPriority = InputActionGlyph.InputPriority.PrioritizeController;
			}
			TextTranslator.inputPriority = inputPriority;
		}
	}
}
