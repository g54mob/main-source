using DG.Tweening;
using JSAM;
using Minigames.Core;
using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace Minigames
{
	public class HintSystem : MonoBehaviour
	{
		[SerializeField]
		private Image _warningImage;

		[SerializeField]
		private Image _breakImage;

		[SerializeField]
		private Image _tutorialImage;

		[SerializeField]
		private Image[] _heads;

		[SerializeField]
		private float _showTutorialAfterTimeIdle = 3f;

		[SerializeField]
		private float _warningInterval = 0.5f;

		[SerializeField]
		private float _rotationSpeed = 15f;

		[SerializeField]
		private float _tutorialHintTime = 1f;

		[SerializeField]
		private float _warningImageFadeTime = 0.5f;

		[SerializeField]
		private float _warningImageWaitInterval = 0.5f;

		[SerializeField]
		private float _breakHintStrength = 100f;

		private Sequence _warningSequence;

		private Sequence _breakSequence;

		private Sequence _tutorialSequence;

		private Vector3[] _initialHeadPositions;

		private float _currentTutorialTime;

		private float _lastProgress;

		private ProgressTracker _progressTracker;

		private bool _breakSoundPlayed;

		private bool _tightSoundPlayed;

		public void Init(ProgressTracker progressTracker)
		{
			_breakImage.SetAlpha(0f);
			_tutorialImage.SetAlpha(0f);
			_warningImage.SetAlpha(0f);
			_tutorialSequence = DOTween.Sequence().SetAutoKill(autoKillOnCompletion: false).Pause();
			_breakSequence = DOTween.Sequence();
			_warningSequence = DOTween.Sequence().SetAutoKill(autoKillOnCompletion: false).Pause();
			StartWarningSequence();
			StartTutorialSequence();
			_initialHeadPositions = new Vector3[_heads.Length];
			for (int i = 0; i < _heads.Length; i++)
			{
				_initialHeadPositions[i] = _heads[i].rectTransform.anchoredPosition;
			}
			_progressTracker = progressTracker;
			_progressTracker.OnProgressChanged += OnProgressChanged;
		}

		private void OnDestroy()
		{
			_progressTracker.OnProgressChanged -= OnProgressChanged;
		}

		private void OnDisable()
		{
			_breakSoundPlayed = false;
			_tightSoundPlayed = false;
		}

		private void Update()
		{
			if (_lastProgress == _progressTracker.Progress)
			{
				_currentTutorialTime += Time.deltaTime;
			}
			else
			{
				_currentTutorialTime = 0f;
				if (_tutorialSequence.IsPlaying())
				{
					_tutorialSequence.Complete();
				}
				if (_progressTracker.Progress >= 1f)
				{
					if (!_tightSoundPlayed)
					{
						_tightSoundPlayed = true;
						PlayTightSound();
					}
					if (!_warningSequence.IsPlaying())
					{
						_warningSequence.Restart();
					}
				}
				if (_progressTracker.Progress == 2f)
				{
					if (!_breakSoundPlayed)
					{
						_breakSoundPlayed = true;
						PlayeBreakSound();
					}
					StartBreakSequence();
				}
			}
			if (_currentTutorialTime >= _showTutorialAfterTimeIdle && _progressTracker.Progress < 1f)
			{
				_currentTutorialTime = 0f;
				_tutorialSequence.Restart();
			}
			_lastProgress = _progressTracker.Progress;
		}

		private void PlayTightSound()
		{
			AudioManager.PlaySound(MiniGamesLibrarySounds.NutTightened);
			AudioManager.PlaySound(MiniGamesLibrarySounds.NutTightenedAdd);
		}

		private void StartBreakSequence()
		{
			_breakSequence?.Complete();
			Image[] heads = _heads;
			foreach (Image image in heads)
			{
				image.rectTransform.DOJumpAnchorPos(image.rectTransform.anchoredPosition + new Vector2(Random.Range(-200, 200), Random.Range(600, 1000)), 20f, 1, 0.5f);
			}
			_breakSequence.Append(_breakImage.DOFade(1f, 0.2f)).Join(_breakImage.rectTransform.DOShakeAnchorPos(0.5f, _breakHintStrength));
		}

		private void PlayeBreakSound()
		{
			AudioManager.PlaySound(MiniGamesLibrarySounds.NutBreak);
			AudioManager.PlaySound(MiniGamesLibrarySounds.NutBreakAdd);
		}

		private void StartTutorialSequence()
		{
			_tutorialSequence.Append(_tutorialImage.DOFade(1f, 0.5f)).Join(_tutorialImage.rectTransform.DOLocalRotate(Vector3.forward * _rotationSpeed, 1f).SetRelative()).AppendInterval(_tutorialHintTime)
				.Append(_tutorialImage.DOFade(0f, 0.5f));
		}

		private void StartWarningSequence()
		{
			_warningSequence.Append(_warningImage.DOFade(1f, _warningImageFadeTime)).AppendInterval(_warningImageWaitInterval).Append(_warningImage.DOFade(0f, _warningImageFadeTime));
		}

		private void OnProgressChanged(float progress)
		{
			if (_lastProgress >= 2f && progress < 2f)
			{
				ResetBreakIcon();
				ResetHeadsPositions();
			}
		}

		private void ResetBreakIcon()
		{
			_breakImage.SetAlpha(0f);
		}

		private void ResetHeadsPositions()
		{
			for (int i = 0; i < _heads.Length; i++)
			{
				_heads[i].rectTransform.anchoredPosition = _initialHeadPositions[i];
			}
		}
	}
}
