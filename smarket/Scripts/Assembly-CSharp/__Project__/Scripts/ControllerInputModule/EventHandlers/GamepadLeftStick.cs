using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using __Third_Party__.Gamepad_UI_Module.Runtime;

namespace __Project__.Scripts.ControllerInputModule.EventHandlers
{
	public class GamepadLeftStick : GamepadUIHandler, ILeftStickHandler, IEventSystemHandler
	{
		[SerializeField]
		private bool m_isAxisBased;

		[SerializeField]
		private bool m_isHorizontal;

		public UnityEvent actionToCallInc;

		public UnityEvent<Vector2> actionToCallVector;

		public UnityEvent actionToCallDecHold;

		public UnityEvent actionToCallIncHold;

		public UnityEvent<Vector2> actionToCallVectorHold;

		private ButtonAxisEventData m_eventData;

		private bool m_isHolding;

		public void OnLeftStick(ButtonAxisEventData eventData)
		{
		}

		public void OnLeftStickHold(ButtonAxisEventData eventData)
		{
		}

		private void Update()
		{
		}
	}
}
