using System;
using Restory.Infrastructure.CommonServices;
using Restory.Utils;
using Rewired;
using Zenject;

namespace Restory.Gameplay.PlayerInput
{
	public class InputSubscriber : IDisposable
	{
		public class Factory : PlaceholderFactory<Action, int, InputSubscriber>
		{
		}

		private readonly IPlayerInput playerInput;

		private readonly ControlsManager controlsManager;

		private Action callback;

		private readonly int actionId;

		private InputActionEventType eventType = InputActionEventType.ButtonJustPressed;

		private InputControlsType targetControlsType;

		private bool subscribed;

		private bool shouldBeSubscribed;

		private bool IsTargetControlTypeActive => targetControlsType == controlsManager.ControlType;

		public bool IsSubscribed => subscribed;

		public InputSubscriber(Action callback, int actionId, IPlayerInput playerInput, ControlsManager controlsManager)
		{
			this.callback = callback;
			this.actionId = actionId;
			this.playerInput = playerInput;
			this.controlsManager = controlsManager;
			controlsManager.OnControlsTypeChanged += ResolveOnControlsTypeChanged;
		}

		public void SetTargetControlType(InputControlsType targetControlsType)
		{
			this.targetControlsType = targetControlsType;
		}

		public void SetInputActionEventType(InputActionEventType eventType)
		{
			RemoveInputEventDelegate();
			this.eventType = eventType;
		}

		public void Subscribe()
		{
			shouldBeSubscribed = true;
			AddInputEventDelegate();
		}

		public void Unsubscribe()
		{
			shouldBeSubscribed = false;
			RemoveInputEventDelegate();
		}

		private void AddInputEventDelegate()
		{
			if (!subscribed && IsTargetControlTypeActive)
			{
				subscribed = true;
				playerInput.AddInputEventDelegate(ResolveInputEvent, eventType, actionId);
			}
		}

		private void RemoveInputEventDelegate()
		{
			if (subscribed)
			{
				subscribed = false;
				if (playerInput != null)
				{
					playerInput.RemoveInputEventDelegate(ResolveInputEvent, eventType, actionId);
				}
			}
		}

		private void ResolveInputEvent(InputActionEventData eventData)
		{
			if (shouldBeSubscribed)
			{
				callback?.Invoke();
			}
		}

		private void ResolveOnControlsTypeChanged(InputControlsType controlsType)
		{
			bool isTargetControlTypeActive = IsTargetControlTypeActive;
			if (isTargetControlTypeActive && shouldBeSubscribed)
			{
				AddInputEventDelegate();
			}
			else if (!isTargetControlTypeActive)
			{
				RemoveInputEventDelegate();
			}
		}

		public void Dispose()
		{
			callback = null;
			if (controlsManager.MonoShellExists())
			{
				controlsManager.OnControlsTypeChanged -= ResolveOnControlsTypeChanged;
			}
			RemoveInputEventDelegate();
		}
	}
}
