using System;
using JSAM;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using Player;
using Player.FSM;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UI.HUD
{
	internal class PauseMenuViewModel : ViewModelBase
	{
		public ObservableProperty<bool> PauseMenuOpened = new ObservableProperty<bool>();

		private InteractionRequest<Notification> _openControlsRequest;

		protected IPlayerInputService _inputService;

		protected IPlayerStateMachineParametersManipulator _playerFSM;

		protected PlayerBehaviour _player;

		protected FirstPersonController _fpsController;

		public IInteractionRequest OpenControlsRequest => _openControlsRequest;

		public PauseMenuViewModel(IPlayerInputService inputService, IPlayerStateMachineParametersManipulator playerFSM)
		{
			_inputService = inputService;
			_playerFSM = playerFSM;
			_player = (playerFSM as MonoBehaviour).GetComponentInParent<PlayerBehaviour>();
			_fpsController = _player.GetComponent<FirstPersonController>();
			_openControlsRequest = new InteractionRequest<Notification>(this);
			_inputService.OnPause += OnPauseInput;
			PauseMenuOpened.ValueChanged += MenuOpenedValueChanged;
		}

		public void Destroy()
		{
			_inputService.OnPause -= OnPauseInput;
			PauseMenuOpened.ValueChanged -= MenuOpenedValueChanged;
		}

		private void MenuOpenedValueChanged(object sender, EventArgs e)
		{
			if (PauseMenuOpened.Value)
			{
				OpenPauseMenu();
			}
			else
			{
				ClosePauseMenu();
			}
		}

		private void OnPauseInput(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				PauseMenuOpened.Value = !PauseMenuOpened.Value;
			}
		}

		private void OpenPauseMenu()
		{
			AudioManager.PlaySound(UILibrarySounds.UIPauseOpen);
			AudioManager.PlaySound(UILibrarySounds.UIPauseOpenAdd);
			AudioManager.PlaySound(UILibrarySounds.UIPauseStatic);
			_inputService.DisableJumpAction();
			_inputService.DisableLookAction();
			_inputService.DisableMoveAction();
			CursorLockKeeper.Apply(CursorLockMode.Confined, visible: true);
		}

		private void ClosePauseMenu()
		{
			AudioManager.StopSoundIfPlaying(UILibrarySounds.UIPauseOpen);
			AudioManager.StopSoundIfPlaying(UILibrarySounds.UIPauseOpenAdd);
			AudioManager.StopSoundIfPlaying(UILibrarySounds.UIPauseStatic);
			_inputService.EnableJumpAction();
			_inputService.EnableLookAction();
			_inputService.EnableMoveAction();
			CursorLockKeeper.Apply(CursorLockMode.Locked, visible: false);
		}

		public void ResetPositionCommand()
		{
			PlayerSpawnPoint playerSpawnPoint = UnityEngine.Object.FindFirstObjectByType<PlayerSpawnPoint>();
			if (playerSpawnPoint != null)
			{
				_player.enabled = false;
				Debug.Log("Player spawned at " + playerSpawnPoint.transform.position.ToString());
				_player.transform.position = playerSpawnPoint.transform.position;
				_player.transform.rotation = playerSpawnPoint.transform.rotation;
			}
			_player.enabled = true;
			PauseMenuOpened.Value = false;
		}

		public void OpenControlsCommand()
		{
			_openControlsRequest.Raise(new Notification("Open Controls"));
		}

		public void MainMenuCommand()
		{
			_inputService.EnableJumpAction();
			_inputService.EnableLookAction();
			_inputService.EnableMoveAction();
			SceneManager.LoadScene(0);
			_inputService.OnPause -= OnPauseInput;
			PauseMenuOpened.ValueChanged -= MenuOpenedValueChanged;
			AudioManager.StopSoundIfPlaying(UILibrarySounds.UIPauseOpen);
			AudioManager.StopSoundIfPlaying(UILibrarySounds.UIPauseOpenAdd);
			AudioManager.StopSoundIfPlaying(UILibrarySounds.UIPauseStatic);
		}

		public void ExitGameCommand()
		{
			Application.Quit();
		}

		public void OpenDiscordCommand()
		{
			Application.OpenURL("https://discord.com/invite/ypK6YH4gB2");
		}

		public void OpenSteamCommand()
		{
			Application.OpenURL("https://store.steampowered.com/app/3906460/The_Last_Flight/");
		}
	}
}
