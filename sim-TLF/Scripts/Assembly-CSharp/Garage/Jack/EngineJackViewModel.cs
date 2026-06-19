using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Garage.Jack
{
	internal class EngineJackViewModel : ViewModelBase
	{
		public ObservableProperty<bool> CanManipulte = new ObservableProperty<bool>();

		public ObservableProperty<bool> PlayerInReleaseZone = new ObservableProperty<bool>();

		public ObservableProperty<float> JackLeanProgress = new ObservableProperty<float>();

		public InteractionRequest<Notification> JackRequest = new InteractionRequest<Notification>();

		public InteractionRequest<Notification> ReleaseRequest = new InteractionRequest<Notification>();

		public InteractionRequest<Notification> PickupRequest = new InteractionRequest<Notification>();

		public InteractionRequest<Notification> ToggleJackRequest = new InteractionRequest<Notification>();

		public bool _hasObject;

		private bool _isInteracting;

		private float _movingForce = 0.5f;

		private GameObject _jackedObject;

		private CancellationTokenSource _cts;

		[Inject]
		private readonly IPlayerInputService _playerInputService;

		public EngineJackViewModel()
		{
			CanManipulte.ValueChanged += CanManipulateValueChanged;
			PlayerInReleaseZone.ValueChanged += PlayerInReleaseZoneValueChanged;
		}

		private void PlayerInReleaseZoneValueChanged(object sender, EventArgs e)
		{
			if (PlayerInReleaseZone.Value)
			{
				_playerInputService.OnPlayerUse += TryToggleJack;
			}
			else
			{
				_playerInputService.OnPlayerUse -= TryToggleJack;
			}
		}

		private void CanManipulateValueChanged(object sender, EventArgs e)
		{
			if (CanManipulte.Value)
			{
				_playerInputService.OnPlayerUse += ManipulateJack;
				return;
			}
			_playerInputService.OnPlayerUse -= ManipulateJack;
			StopInteraction();
		}

		private void TryRelease(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				Debug.Log("Trying Release");
				ReleaseRequest.Raise(new Notification("Release"));
			}
		}

		private void TryToggleJack(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				ToggleJackRequest.Raise(new Notification("Toggled"));
			}
		}

		private void TryPickup(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				Debug.Log("Trying Pickup");
				PickupRequest.Raise(new Notification("Pickup"));
			}
		}

		private void ManipulateJack(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				StartInteraction();
			}
			else if (context.canceled)
			{
				StopInteraction();
				_movingForce *= -1f;
			}
		}

		private void StartInteraction()
		{
			if (!_isInteracting)
			{
				_isInteracting = true;
				_cts = new CancellationTokenSource();
				RunInteractionLoop(_cts.Token).Forget();
			}
		}

		private void StopInteraction()
		{
			_isInteracting = false;
			_cts?.Cancel();
			_cts?.Dispose();
			_cts = null;
		}

		private async UniTaskVoid RunInteractionLoop(CancellationToken token)
		{
			try
			{
				while (!token.IsCancellationRequested)
				{
					JackLeanProgress.Value = Mathf.Clamp01(JackLeanProgress.Value + Time.deltaTime * _movingForce);
					await UniTask.Yield(PlayerLoopTiming.Update, token);
				}
			}
			catch (OperationCanceledException)
			{
			}
		}
	}
}
