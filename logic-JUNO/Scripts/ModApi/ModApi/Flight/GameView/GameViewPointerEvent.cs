using ModApi.Input.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModApi.Flight.GameView
{
	public class GameViewPointerEvent
	{
		public PointerEventData EventData { get; }

		public GameViewPointerEventType EventType { get; }

		public bool Handled { get; private set; }

		public InputButton InputButton => (InputButton)EventData.button;

		public bool IsTouch => EventData.pointerId >= 0;

		public bool IsTouchPrimary
		{
			get
			{
				if (EventData.pointerId >= 0)
				{
					return EventData.button == PointerEventData.InputButton.Left;
				}
				return false;
			}
		}

		public GameViewPointerEventModifierType ModifierType { get; }

		public GameViewPointerEvent(GameViewPointerEventType eventType, PointerEventData eventData)
		{
			EventType = eventType;
			ModifierType = ((UnityEngine.Input.GetKeyDown(KeyCode.LeftAlt) || UnityEngine.Input.GetKeyDown(KeyCode.RightAlt)) ? GameViewPointerEventModifierType.Alt : GameViewPointerEventModifierType.None);
			EventData = eventData;
		}

		public void MarkAsHandled()
		{
			Handled = true;
		}
	}
}
