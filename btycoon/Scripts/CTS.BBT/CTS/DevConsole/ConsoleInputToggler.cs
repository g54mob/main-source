using CTS.Core;
using UnityEngine;

namespace CTS.DevConsole
{
	public class ConsoleInputToggler : MonoBehaviour
	{
		private LockToggle _inputToggle;

		private void Awake()
		{
			_inputToggle = new LockToggle(InputManager.game.cameraMovement, InputManager.game.cameraRotation, InputManager.game.cameraZoom, InputManager.game.fastForwardDialogue, InputManager.game.live.pause, InputManager.game.live.timeControlPause, InputManager.game.live.timeControlSlow, InputManager.game.live.timeControlNormal, InputManager.game.live.timeControlFast);
		}

		private void OnEnable()
		{
			DeveloperConsole.OnConsoleOpen += OnConsoleOpen;
		}

		private void OnDisable()
		{
			DeveloperConsole.OnConsoleOpen -= OnConsoleOpen;
		}

		private void OnConsoleOpen(bool isOpen)
		{
			_inputToggle.SetLock(isOpen);
		}
	}
}
