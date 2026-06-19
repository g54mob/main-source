using Cysharp.Threading.Tasks;
using JSAM;
using Loxodon.Framework.ViewModels;
using Player;
using UnityEngine.SceneManagement;

namespace HUD
{
	public class DeathScreenViewModel : ViewModelBase
	{
		private readonly IPlayerInputService _playerInputService;

		private bool _isLoading;

		public DeathScreenViewModel(IPlayerInputService playerInputService)
		{
			_playerInputService = playerInputService;
			AudioManager.PlaySound(AmbientLibrarySounds.WindClear);
			AudioManager.PlaySound(MainMenuLibrarySounds.Glitch);
		}

		public void DisableInput()
		{
			_playerInputService.DisableAllInput();
		}

		public void ScreenClickCommand()
		{
			if (!_isLoading)
			{
				_isLoading = true;
				LoadMainMenu().Forget();
			}
		}

		public async UniTaskVoid LoadMainMenu()
		{
			await SceneManager.LoadSceneAsync(0).ToUniTask();
			AudioManager.StopSoundIfPlaying(AmbientLibrarySounds.WindClear);
			AudioManager.StopSoundIfPlaying(MainMenuLibrarySounds.Glitch);
			_playerInputService.EnableAllInput();
		}
	}
}
