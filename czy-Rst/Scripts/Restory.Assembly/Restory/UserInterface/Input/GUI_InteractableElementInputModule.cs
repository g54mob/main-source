using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UserInterface.Input
{
	[RequireComponent(typeof(GUI_Interactable))]
	public abstract class GUI_InteractableElementInputModule : GUI_BaseElementInputModule
	{
		[SerializeField]
		protected GUI_Interactable interactable;

		protected override void OnEnable()
		{
			base.OnEnable();
			interactable.IsInteractableChanged += ResolveIsInteractableChanged;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			interactable.IsInteractableChanged -= ResolveIsInteractableChanged;
		}

		public bool IsInteractable()
		{
			return interactable.IsInteractable();
		}

		protected override bool CanSubscribeInput()
		{
			return interactable.IsInteractable();
		}

		private void ResolveIsInteractableChanged()
		{
			SubscribeOrUnsubscribeInput();
		}
	}
}
