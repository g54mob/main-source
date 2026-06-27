using DG.Tweening;
using Restory.Gameplay.GameView;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class RadioMusicSoundSourceMover : MonoBehaviour
	{
		[SerializeField]
		private RadioFunctionalObject radioFunctionalObject;

		[SerializeField]
		private Transform defaultMusicSoundSourceParent;

		[SerializeField]
		private float transitionDuration = 1f;

		[SerializeField]
		private Ease transitionEase = Ease.InQuad;

		private Camera gameCamera;

		private GameViewController gameViewController;

		private TweenSequencesService tweenSequencesService;

		private Sequence transitionSequence;

		[Inject]
		public void Construct([Inject(Id = "GameCamera")] Camera gameCamera, GameViewController gameViewController, TweenSequencesService tweenSequencesService)
		{
			this.gameCamera = gameCamera;
			this.gameViewController = gameViewController;
			this.tweenSequencesService = tweenSequencesService;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)gameCamera && (bool)gameViewController)
			{
				Init();
			}
		}

		private void OnDisable()
		{
			if (gameViewController.MonoShellExists())
			{
				gameViewController.OnViewPresetSwitchingProcessStarted -= ResolveViewPresetSwitchingProcessStarted;
			}
		}

		private void Init()
		{
			gameViewController.OnViewPresetSwitchingProcessStarted += ResolveViewPresetSwitchingProcessStarted;
		}

		private void ResolveViewPresetSwitchingProcessStarted()
		{
			Transform musicSoundSource = radioFunctionalObject.RadioMusicSoundSource.transform;
			ReparentSoundSource(musicSoundSource);
			LaunchSoundSourceMovementSequence(musicSoundSource);
		}

		private void ReparentSoundSource(Transform musicSoundSource)
		{
			if (gameViewController.IsCurrentViewPresetDisassemblePreset)
			{
				musicSoundSource.parent = gameCamera.transform;
			}
			else
			{
				musicSoundSource.parent = (defaultMusicSoundSourceParent ? defaultMusicSoundSourceParent.transform : base.transform);
			}
		}

		private void LaunchSoundSourceMovementSequence(Transform musicSoundSource)
		{
			if (transitionSequence.IsActive())
			{
				transitionSequence.Kill();
			}
			transitionSequence = tweenSequencesService.Create();
			transitionSequence.Join(musicSoundSource.DOLocalMove(Vector3.zero, transitionDuration)).SetEase(transitionEase).OnComplete(delegate
			{
				musicSoundSource.localPosition = Vector3.zero;
			});
		}
	}
}
