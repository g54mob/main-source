using System;
using DG.Tweening;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.PauseMenu
{
	public class GUI_PauseMenuView : UIBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		[Min(0f)]
		private float showHideDuration = 0.25f;

		[SerializeField]
		private Button continueButton;

		[SerializeField]
		private Button saveButton;

		[SerializeField]
		private TextMeshProUGUI saveInfoText;

		[SerializeField]
		private Button optionsButton;

		[SerializeField]
		private Button mainMenuButton;

		private Sequence currentSequence;

		private TweenSequencesService tweenSequencesService;

		public event Action OnContinueClick;

		public event Action OnSaveGameClick;

		public event Action OnSettingsClick;

		public event Action OnMainMenuClick;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		protected override void OnEnable()
		{
			continueButton.onClick.AddListener(ResolveContinueOnClick);
			saveButton.onClick.AddListener(ResolveSaveGameClick);
			optionsButton.onClick.AddListener(ResolveSettingsOnClick);
			mainMenuButton.onClick.AddListener(ResolveMainMenuClick);
		}

		protected override void OnDisable()
		{
			continueButton.onClick.RemoveListener(ResolveContinueOnClick);
			saveButton.onClick.RemoveListener(ResolveSaveGameClick);
			optionsButton.onClick.RemoveListener(ResolveSettingsOnClick);
			mainMenuButton.onClick.RemoveListener(ResolveMainMenuClick);
		}

		public void Show()
		{
			if (tweenSequencesService == null)
			{
				canvasGroup.alpha = 1f;
				base.gameObject.SetActive(value: true);
				return;
			}
			tweenSequencesService.Kill(currentSequence);
			currentSequence = tweenSequencesService.Create();
			currentSequence.OnStart(delegate
			{
				base.gameObject.SetActive(value: true);
			});
			currentSequence.SetUpdate(isIndependentUpdate: true);
			currentSequence.Append(canvasGroup.DOFade(1f, showHideDuration));
		}

		public void Hide()
		{
			if (tweenSequencesService == null)
			{
				canvasGroup.alpha = 0f;
				base.gameObject.SetActive(value: false);
				return;
			}
			tweenSequencesService.Kill(currentSequence);
			currentSequence = tweenSequencesService.Create();
			currentSequence.SetUpdate(isIndependentUpdate: true);
			currentSequence.Append(canvasGroup.DOFade(0f, showHideDuration));
			currentSequence.OnComplete(delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}

		public void SetSaveInfo(DateTime lastSaveTime)
		{
			saveInfoText.text = lastSaveTime.ToString("dd-MM-yyyy HH:mm");
		}

		private void ResolveSaveGameClick()
		{
			this.OnSaveGameClick?.Invoke();
		}

		private void ResolveContinueOnClick()
		{
			this.OnContinueClick?.Invoke();
		}

		private void ResolveSettingsOnClick()
		{
			this.OnSettingsClick?.Invoke();
		}

		private void ResolveMainMenuClick()
		{
			this.OnMainMenuClick?.Invoke();
		}
	}
}
