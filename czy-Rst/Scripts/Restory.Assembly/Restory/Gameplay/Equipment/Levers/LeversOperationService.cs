using System;
using System.Collections;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.ProjectServices;
using Restory.Utils;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Levers
{
	public class LeversOperationService : IDisposable
	{
		private const float MOUSE_DELTA_MOVEMENT_TO_TURN_LEVER = 20f;

		private ICoroutineRunner coroutineRunner;

		private IPlayerInput playerInput;

		private VerticalLever currentlyOperatedLever;

		private Coroutine inputDetectionCoroutine;

		private float mouseVerticalPositionAtDetectionStart;

		private ApplicationFocusDetectionService applicationFocusDetectionService;

		public LeversOperationService(ICoroutineRunner coroutineRunner, IPlayerInput playerInput, ApplicationFocusDetectionService applicationFocusDetectionService)
		{
			this.playerInput = playerInput;
			this.applicationFocusDetectionService = applicationFocusDetectionService;
			this.coroutineRunner = coroutineRunner;
		}

		public void Dispose()
		{
			if (inputDetectionCoroutine != null)
			{
				coroutineRunner.Stop(inputDetectionCoroutine);
				inputDetectionCoroutine = null;
			}
			if ((bool)currentlyOperatedLever)
			{
				currentlyOperatedLever.OnActiveStateChanged -= ResolveLeverActiveStateChanged;
			}
			if ((bool)applicationFocusDetectionService)
			{
				applicationFocusDetectionService.OnApplicationLostFocus.RemoveListener(ResolveApplicationLostFocus);
			}
		}

		public void StartMovingLever(VerticalLever lever)
		{
			StopMovingLever();
			if (lever.MonoShellExists())
			{
				currentlyOperatedLever = lever;
				if (inputDetectionCoroutine == null)
				{
					inputDetectionCoroutine = coroutineRunner.Run(InputDetectionCoroutine());
				}
				mouseVerticalPositionAtDetectionStart = playerInput.GetMousePosition().y;
				lever.OnActiveStateChanged += ResolveLeverActiveStateChanged;
				applicationFocusDetectionService.OnApplicationLostFocus.AddListener(ResolveApplicationLostFocus);
			}
		}

		public void StopMovingLever()
		{
			if ((bool)currentlyOperatedLever)
			{
				currentlyOperatedLever.OnActiveStateChanged -= ResolveLeverActiveStateChanged;
			}
			if ((bool)applicationFocusDetectionService)
			{
				applicationFocusDetectionService.OnApplicationLostFocus.RemoveListener(ResolveApplicationLostFocus);
			}
			currentlyOperatedLever = null;
			if (inputDetectionCoroutine != null)
			{
				coroutineRunner.Stop(inputDetectionCoroutine);
				inputDetectionCoroutine = null;
			}
		}

		private IEnumerator InputDetectionCoroutine()
		{
			while ((currentlyOperatedLever.CurrentPosition == LeverPositions.Top && playerInput.GetMousePosition().y > mouseVerticalPositionAtDetectionStart - 20f) || (currentlyOperatedLever.CurrentPosition == LeverPositions.Bottom && playerInput.GetMousePosition().y < mouseVerticalPositionAtDetectionStart + 20f))
			{
				yield return null;
			}
			currentlyOperatedLever.TryToSwitchLeverPosition();
			StopMovingLever();
			inputDetectionCoroutine = null;
		}

		private void ResolveLeverActiveStateChanged()
		{
			if ((bool)currentlyOperatedLever && !currentlyOperatedLever.IsActive)
			{
				StopMovingLever();
			}
		}

		private void ResolveApplicationLostFocus()
		{
			StopMovingLever();
		}
	}
}
