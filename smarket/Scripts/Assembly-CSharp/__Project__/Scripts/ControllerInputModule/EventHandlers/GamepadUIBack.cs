using UnityEngine.EventSystems;
using UnityEngine.Events;
using __Third_Party__.Gamepad_UI_Module.Runtime;

namespace __Project__.Scripts.ControllerInputModule.EventHandlers
{
	public class GamepadUIBack : GamepadUIHandler, IBackHandler, IEventSystemHandler
	{
		public UnityEvent actionToCallHold;

		public UnityEvent actionToCallRelease;

		private bool m_IsHolding;

		private void OnEnable()
		{
		}

		public void OnBack(ButtonEventData eventData)
		{
		}

		public void OnBackHold(ButtonEventData eventData)
		{
		}

		private void Update()
		{
		}
	}
}
