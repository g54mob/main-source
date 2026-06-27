using System;
using Restory.Gameplay.Devices;
using Restory.Gameplay.PlayerInput;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_DisassembleObjectGameModeCanvas : MonoBehaviour, IDisposable
	{
		[SerializeField]
		private GUI_DisassembleLongActionProgressBar longActionProgressBar;

		[SerializeField]
		private Button exitButton;

		private IPlayerInput playerInput;

		private bool isSubscribed;

		public Button ExitButton => exitButton;

		public event Action OnExitAction;

		[Inject]
		public void Construct(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
		}

		public void Dispose()
		{
			UnsubscribeEvents();
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
			SubscribeEvents();
		}

		public void SetDevice(DeviceContainer placedDeviceContainer)
		{
			if ((bool)placedDeviceContainer)
			{
				longActionProgressBar.Init(placedDeviceContainer.Device);
			}
			else
			{
				longActionProgressBar.Hide();
			}
		}

		public void Hide()
		{
			longActionProgressBar.Hide();
			base.gameObject.SetActive(value: false);
			UnsubscribeEvents();
		}

		private void SubscribeEvents()
		{
			if (!isSubscribed)
			{
				exitButton.onClick.AddListener(Exit);
				isSubscribed = true;
			}
		}

		private void UnsubscribeEvents()
		{
			if (isSubscribed)
			{
				exitButton.onClick.RemoveListener(Exit);
				isSubscribed = false;
			}
		}

		private void Exit()
		{
			this.OnExitAction?.Invoke();
		}
	}
}
