using DG.Tweening;
using Data.Variables;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class PausedStateWidget : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _pausedState;

		[SerializeField]
		private BoolVariableSO _pausedBuildMode;

		private void Awake()
		{
			_pausedState.alpha = 0f;
		}

		private void OnEnable()
		{
			_pausedBuildMode.ValueChanged += HandlePausedBuildModeChanged;
			HandlePausedBuildModeChanged(_pausedBuildMode.Value);
			_pausedState.alpha = (_pausedBuildMode.Value ? 0f : 1f);
		}

		private void OnDisable()
		{
			_pausedBuildMode.ValueChanged -= HandlePausedBuildModeChanged;
			_pausedBuildMode.SetValue(value: false);
		}

		private void HandlePausedBuildModeChanged(bool paused)
		{
			_pausedState.gameObject.SetActive(value: true);
			_pausedState.DOKill();
			_pausedState.DOFade(paused ? 1f : 0f, 0.3f).OnComplete(OnFadeComplete);
		}

		private void OnFadeComplete()
		{
			if (!_pausedBuildMode.Value)
			{
				_pausedState.gameObject.SetActive(value: false);
			}
		}
	}
}
