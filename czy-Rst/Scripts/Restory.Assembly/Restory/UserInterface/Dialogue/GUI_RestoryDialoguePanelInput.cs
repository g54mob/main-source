using PixelCrushers.DialogueSystem;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.CommonServices;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.Dialogue
{
	public class GUI_RestoryDialoguePanelInput : MonoBehaviour
	{
		private readonly int mouseClickButtonId = 81;

		[SerializeField]
		private CanvasDialogueUI dialogueUI;

		[SerializeField]
		private GUI_RestoryDialogueMenuPanel menuPanel;

		[SerializeField]
		private StandardUISubtitlePanel subtitlePanel;

		[SerializeField]
		private GUI_RestoryDialogueContinueButton subtitleContinueButton;

		private IPlayerInput playerInput;

		private ControlsManager controlsManager;

		[Inject]
		private void Construct(IPlayerInput playerInput, ControlsManager controlsManager)
		{
			this.playerInput = playerInput;
			this.controlsManager = controlsManager;
			if (base.isActiveAndEnabled)
			{
				SubscribeToRewired();
			}
		}

		private void OnEnable()
		{
			if (playerInput != null)
			{
				SubscribeToRewired();
			}
		}

		private void OnDisable()
		{
			UnsubscribeFromRewired();
		}

		private void SubscribeToRewired()
		{
			playerInput.AddInputEventDelegate(ResolveMouseClicked, InputActionEventType.ButtonJustPressed, mouseClickButtonId);
		}

		private void UnsubscribeFromRewired()
		{
			playerInput?.RemoveInputEventDelegate(ResolveMouseClicked, InputActionEventType.ButtonJustPressed, mouseClickButtonId);
		}

		private void ResolveMouseClicked(InputActionEventData _)
		{
			if (controlsManager.ControlType == InputControlsType.KeyboardAndMouse && dialogueUI.isOpen)
			{
				if (menuPanel.isActiveAndEnabled && menuPanel.isOpen)
				{
					menuPanel.ProcessMouseClick();
				}
				else if (subtitlePanel.isOpen && subtitleContinueButton.isActiveAndEnabled)
				{
					subtitleContinueButton.OnFastForward();
				}
			}
		}
	}
}
