using System;
using System.Collections;
using Restory.Gameplay.PlayerInput;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonServices
{
	public class ControlsManager : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private InputControlsType controlType;

		private IPlayerInput playerInput;

		private Coroutine updateCurrentControlTypeCoroutine;

		public InputControlsType ControlType
		{
			get
			{
				return controlType;
			}
			private set
			{
				if (controlType != value)
				{
					controlType = value;
					this.OnControlsTypeChanged?.Invoke(controlType);
				}
			}
		}

		public event Action<InputControlsType> OnControlsTypeChanged;

		[Inject]
		private void Construct(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
		}

		private void UpdateCurrentControlType()
		{
			Controller lastActiveController = playerInput.GetLastActiveController();
			if (lastActiveController != null)
			{
				if (lastActiveController.type == ControllerType.Joystick)
				{
					ControlType = InputControlsType.Joystick;
				}
				else
				{
					ControlType = InputControlsType.KeyboardAndMouse;
				}
			}
		}

		private void ResolveAddLastActiveControllerChangedDelegate(Player player, Controller controller)
		{
			UpdateCurrentControlType();
		}

		public void Initialize()
		{
			if (playerInput == null)
			{
				Debug.LogException(new Exception("[ControlsManager] playerInput is NULL! Injection may have failed."));
			}
			playerInput.AddLastActiveControllerChangedDelegate(ResolveAddLastActiveControllerChangedDelegate);
			updateCurrentControlTypeCoroutine = StartCoroutine(UpdateCurrentControlTypeDelay());
		}

		private IEnumerator UpdateCurrentControlTypeDelay()
		{
			yield return new WaitForEndOfFrame();
			yield return null;
			UpdateCurrentControlType();
			updateCurrentControlTypeCoroutine = null;
		}

		public void Dispose()
		{
			this.OnControlsTypeChanged = null;
			playerInput?.RemoveLastActiveControllerChangedDelegate(ResolveAddLastActiveControllerChangedDelegate);
			if (updateCurrentControlTypeCoroutine != null)
			{
				StopCoroutine(updateCurrentControlTypeCoroutine);
				updateCurrentControlTypeCoroutine = null;
			}
		}
	}
}
