using UnityEngine.EventSystems;
using UnityEngine.Events;
using __Third_Party__.Gamepad_UI_Module.Runtime;

namespace __Project__.Scripts.ControllerInputModule.EventHandlers
{
	public class GamepadUIShoulder : GamepadUIHandler, IBumperHandler, IEventSystemHandler
	{
		public UnityEvent actionToCallRight;

		public UnityEvent actionToCallLeftHold;

		public UnityEvent actionToCallRightHold;

		public void OnBumperLeftPress(ButtonEventData eventData)
		{
		}

		public void OnBumperRightPress(ButtonEventData eventData)
		{
		}

		public void OnBumperLeftHold(ButtonEventData eventData)
		{
		}

		public void OnBumperRightHold(ButtonEventData eventData)
		{
		}
	}
}
