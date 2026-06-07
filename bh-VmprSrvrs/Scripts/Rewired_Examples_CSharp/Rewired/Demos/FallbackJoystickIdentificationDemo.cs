using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class FallbackJoystickIdentificationDemo : MonoBehaviour
	{
		private const float windowWidth = 250f;

		private const float windowHeight = 250f;

		private const float inputDelay = 1f;

		private bool identifyRequired;

		private Queue<Joystick> joysticksToIdentify;

		private float nextInputAllowedTime;

		private GUIStyle style;

		private void Awake()
		{
		}

		private void JoystickConnected(ControllerStatusChangedEventArgs args)
		{
		}

		private void JoystickDisconnected(ControllerStatusChangedEventArgs args)
		{
		}

		public void IdentifyAllJoysticks()
		{
		}

		private void SetInputDelay()
		{
		}

		private void OnGUI()
		{
		}

		private void DrawDialogWindow(int windowId)
		{
		}

		private void Reset()
		{
		}
	}
}
