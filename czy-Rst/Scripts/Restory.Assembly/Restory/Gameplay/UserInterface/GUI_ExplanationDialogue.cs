using System;
using Restory.Gameplay.PlayerInput;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_ExplanationDialogue : MonoBehaviour
	{
		private IPlayerInput playerInput;

		public event Action OnViewed;

		[Inject]
		private void Construct(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
		}

		private void OnEnable()
		{
			playerInput.AddInputEventDelegate(ResolveButtonReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void OnDisable()
		{
			playerInput.RemoveInputEventDelegate(ResolveButtonReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void ResolveButtonReleased(InputActionEventData eventData)
		{
			this.OnViewed?.Invoke();
		}
	}
}
