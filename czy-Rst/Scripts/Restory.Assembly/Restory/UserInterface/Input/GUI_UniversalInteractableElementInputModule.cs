using System.Collections.Generic;
using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UserInterface.Input
{
	[RequireComponent(typeof(GUI_Interactable))]
	public sealed class GUI_UniversalInteractableElementInputModule : GUI_InteractableElementInputModule
	{
		[SerializeField]
		private List<InputEventDelegatesContainer> inputEvents = new List<InputEventDelegatesContainer>();

		protected override void OnSubscribeInput()
		{
			foreach (InputEventDelegatesContainer inputEvent in inputEvents)
			{
				base.PlayerInput.AddInputEventDelegate(inputEvent.InputEvent.Invoke, inputEvent.EventType, inputEvent.ActionId);
			}
		}

		protected override void OnUnsubscribeInput()
		{
			foreach (InputEventDelegatesContainer inputEvent in inputEvents)
			{
				base.PlayerInput.RemoveInputEventDelegate(inputEvent.InputEvent.Invoke, inputEvent.EventType, inputEvent.ActionId);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			foreach (InputEventDelegatesContainer inputEvent in inputEvents)
			{
				inputEvent.Dispose();
			}
			inputEvents.Clear();
		}
	}
}
