using UnityEngine.EventSystems;
using UnityEngine.Events;
using __Third_Party__.Gamepad_UI_Module.Runtime;

namespace __Project__.Scripts.ControllerInputModule.EventHandlers
{
	public class GamepadUITrigger : GamepadUIHandler, ITriggerHandler, IEventSystemHandler
	{
		public UnityEvent actionToCallRight;

		public UnityEvent actionToCallLeftHold;

		public UnityEvent actionToCallRightHold;

		private bool m_isPressedLeft;

		private bool m_isPressedRight;

		private void Update()
		{
		}

		public void OnTriggerLeftPress(ButtonEventData eventData)
		{
		}

		public void OnTriggerRightPress(ButtonEventData eventData)
		{
		}

		public void OnTriggerLeftHold(ButtonEventData eventData)
		{
		}

		public void OnTriggerRightHold(ButtonEventData eventData)
		{
		}
	}
}
