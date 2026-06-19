using Intro.Tutorial;
using Services.Save.Player;
using UnityEngine;
using Zenject;

namespace Intro
{
	public class IntroBootstraper : MonoBehaviour
	{
		[SerializeField]
		private IntroSequencePlayer _introSequencePlayer;

		[SerializeField]
		private TutorialPlayer _tutorialPlayer;

		[Inject]
		private PlayerSaveService _playerSaveService;

		private void Awake()
		{
			_introSequencePlayer.OnIntroFinished += SetIntroWatched;
			_playerSaveService.OnLoadCompleted += TryStartIntro;
		}

		private void OnDestroy()
		{
			_introSequencePlayer.OnIntroFinished -= SetIntroWatched;
			_playerSaveService.OnLoadCompleted -= TryStartIntro;
		}

		private void SetIntroWatched()
		{
			_playerSaveService.PlayerData.GameData.IntroScreenShown = true;
			_playerSaveService.OnSave();
		}

		private void TryStartIntro()
		{
			if (!_playerSaveService.PlayerData.GameData.IntroScreenShown)
			{
				_introSequencePlayer.gameObject.SetActive(value: true);
				return;
			}
			_introSequencePlayer.gameObject.SetActive(value: false);
			if (_playerSaveService.PlayerData.GameData.TutorialDone)
			{
				_tutorialPlayer.gameObject.SetActive(value: false);
			}
			else
			{
				_tutorialPlayer.StartTutorial();
			}
		}
	}
}
