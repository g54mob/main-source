using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.CommonServices;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_DialogueBubbleButton : MonoBehaviour
	{
		[SerializeField]
		private bool clickAnywhereCountsAsButtonPress;

		[SerializeField]
		[RewiredActionsDropdown]
		private int mouseClickButtonId = -1;

		[SerializeField]
		private Button button;

		[SerializeField]
		private GameObject inputContainer;

		[SerializeField]
		private GameObject dynamicInputContainer;

		private ICursorDetector cursorDetector;

		private IPlayerInput playerInput;

		private ControlsManager controlsManager;

		private bool isSubscribedToRewired;

		[Inject]
		private void Construct(ICursorDetector cursorDetector, IPlayerInput playerInput, ControlsManager controlsManager)
		{
			this.cursorDetector = cursorDetector;
			this.playerInput = playerInput;
			this.controlsManager = controlsManager;
		}

		private void Start()
		{
			if (button == null)
			{
				TryGetComponent<Button>(out button);
			}
			TryToSubscribeToRewired();
		}

		private void OnEnable()
		{
			TryToSubscribeToRewired();
		}

		private void OnDisable()
		{
			UnsubscribeFromRewired();
		}

		private void TryToSubscribeToRewired()
		{
			if (playerInput != null && !isSubscribedToRewired)
			{
				playerInput.AddInputEventDelegate(ResolveMouseClicked, InputActionEventType.ButtonJustPressed, mouseClickButtonId);
				isSubscribedToRewired = true;
			}
		}

		private void UnsubscribeFromRewired()
		{
			isSubscribedToRewired = false;
			playerInput?.RemoveInputEventDelegate(ResolveMouseClicked, InputActionEventType.ButtonJustPressed, mouseClickButtonId);
		}

		private void ResolveMouseClicked(InputActionEventData _)
		{
			if (button.isActiveAndEnabled && clickAnywhereCountsAsButtonPress && controlsManager.ControlType == InputControlsType.KeyboardAndMouse && !cursorDetector.IsMouseOverRaycastedUI && cursorDetector.ConversationBubble != this)
			{
				button.OnPointerClick(new PointerEventData(EventSystem.current));
			}
		}

		public void SetClickAnywhereToCountAsButtonPress(bool to)
		{
			clickAnywhereCountsAsButtonPress = to;
		}

		public void SetInputContainerActive(bool active)
		{
			if (inputContainer != null)
			{
				inputContainer.SetActive(active);
			}
			if (dynamicInputContainer != null)
			{
				dynamicInputContainer.SetActive(!active);
			}
		}
	}
}
