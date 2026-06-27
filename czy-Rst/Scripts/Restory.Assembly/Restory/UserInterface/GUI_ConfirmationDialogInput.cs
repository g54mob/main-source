using System;
using Restory.Gameplay.PlayerInput;
using Restory.UserInterface.ConfirmationDialogues;
using Rewired;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	[Obsolete("Need to inherit from GUI_InteractableElementInputModule")]
	public class GUI_ConfirmationDialogInput : MonoBehaviour
	{
		[SerializeField]
		[RewiredActionsDropdown]
		private int positiveActionId;

		[SerializeField]
		[RewiredActionsDropdown]
		private int negativeActionId;

		[SerializeField]
		private GUI_ConfirmationDialogueBase confirmationDialog;

		[SerializeField]
		private Selectable selectable;

		private IPlayerInput playerInput;

		[Inject]
		private void Construct(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
			if (base.isActiveAndEnabled)
			{
				Subscribe();
			}
		}

		private void Awake()
		{
			if (!confirmationDialog)
			{
				confirmationDialog = GetComponent<GUI_ConfirmationDialogueBase>();
			}
			if (!selectable)
			{
				selectable = GetComponent<Selectable>();
			}
		}

		private void OnEnable()
		{
			if (playerInput != null)
			{
				Subscribe();
			}
		}

		private void OnDisable()
		{
			Unsubscribe();
		}

		private void Unsubscribe()
		{
			if (playerInput != null)
			{
				playerInput.RemoveInputEventDelegate(ResolvePositiveInput, InputActionEventType.ButtonJustPressed, positiveActionId);
				playerInput.RemoveInputEventDelegate(ResolveNegativeInput, InputActionEventType.ButtonJustPressed, negativeActionId);
			}
		}

		private void Subscribe()
		{
			if (playerInput != null)
			{
				playerInput.AddInputEventDelegate(ResolvePositiveInput, InputActionEventType.ButtonJustPressed, positiveActionId);
				playerInput.AddInputEventDelegate(ResolveNegativeInput, InputActionEventType.ButtonJustPressed, negativeActionId);
			}
		}

		private void ResolvePositiveInput(InputActionEventData obj)
		{
			if (selectable.IsInteractable())
			{
				confirmationDialog.OnSelectedPositive();
			}
		}

		private void ResolveNegativeInput(InputActionEventData obj)
		{
			if (selectable.IsInteractable())
			{
				confirmationDialog.OnSelectedNegative();
			}
		}
	}
}
