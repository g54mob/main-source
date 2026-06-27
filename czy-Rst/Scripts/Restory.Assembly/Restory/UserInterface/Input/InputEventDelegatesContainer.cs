using System;
using Rewired;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.UserInterface.Input
{
	[Serializable]
	internal sealed class InputEventDelegatesContainer
	{
		[Serializable]
		public class UnityInputActionEvent : UnityEvent<InputActionEventData>
		{
		}

		[SerializeField]
		[RewiredActionsDropdown]
		private int actionId = -1;

		[SerializeField]
		private InputActionEventType eventType = InputActionEventType.ButtonJustPressed;

		[SerializeField]
		private UnityInputActionEvent inputEvent = new UnityInputActionEvent();

		public int ActionId => actionId;

		public InputActionEventType EventType => eventType;

		public UnityInputActionEvent InputEvent => inputEvent;

		public void Dispose()
		{
			inputEvent.RemoveAllListeners();
		}
	}
}
