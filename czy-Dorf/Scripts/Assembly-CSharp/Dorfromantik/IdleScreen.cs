using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class IdleScreen : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference startPlayingAction;

		[SerializeField]
		private Image resettingProgressBar;

		[SerializeField]
		private RectTransform resettingProgressBarContainer;

		[SerializeField]
		private Vector2 resettingContainerHiddenAnchoredPos;

		private CanvasGroup canvasGroup;

		public CanvasGroup CanvasGroup => canvasGroup;

		public event Action OnHide;

		private void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}

		private void Start()
		{
			startPlayingAction.action.performed += StartPlaying;
		}

		private void StartPlaying(InputAction.CallbackContext obj)
		{
			this.OnHide?.Invoke();
		}

		public void SetResettingProgress(float progress)
		{
			resettingProgressBar.fillAmount = progress;
			if (progress >= 1f)
			{
				DOTweenModuleUI.DOAnchorPos(resettingProgressBarContainer, resettingContainerHiddenAnchoredPos, 0.5f);
			}
		}

		private void OnDestroy()
		{
			startPlayingAction.action.performed -= StartPlaying;
		}
	}
}
