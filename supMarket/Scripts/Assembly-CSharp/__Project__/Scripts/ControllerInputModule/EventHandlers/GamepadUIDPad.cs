using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using __Third_Party__.Gamepad_UI_Module.Runtime;

namespace __Project__.Scripts.ControllerInputModule.EventHandlers
{
	public class GamepadUIDPad : GamepadUIHandler, IDpadHandler, IEventSystemHandler
	{
		[SerializeField]
		private bool m_isAxisBased;

		[SerializeField]
		private bool m_isHorizontal;

		public UnityEvent actionToCallDec;

		public UnityEvent actionToCallInc;

		public void OnDPad(ButtonAxisEventData eventData)
		{
		}
	}
}
