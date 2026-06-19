using DevCmdLine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DevCmdLine
{
	internal class DevCmdToggleSimple : MonoBehaviour
	{
		private void Update()
		{
			if (Keyboard.current != null && Keyboard.current.backquoteKey.wasPressedThisFrame)
			{
				DevCmdConsole.ToggleConsole(DevCmdStartingSelectedButton.Input);
			}
			else if (Gamepad.current != null && Gamepad.current.selectButton.wasPressedThisFrame)
			{
				DevCmdConsole.ToggleConsole(DevCmdStartingSelectedButton.Option);
			}
		}
	}
}
