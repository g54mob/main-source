using System;
using DG.Tweening;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Views.ConfirmationDialog
{
	public class GUI_ConfirmationDialogView : UIBehaviour, ICancelHandler, IEventSystemHandler, ISubmitHandler
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		[Min(0f)]
		private float showHideDuration = 0.25f;

		[SerializeField]
		private GUI_LocalisedText description;

		[SerializeField]
		private Button positiveButton;

		[SerializeField]
		private Button negativeButton;

		private Sequence currentSequence;

		private TweenSequencesService tweenSequencesService;

		public event Action OnPositiveClicked;

		public event Action OnNegativeClicked;

		[Inject]
		private void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			positiveButton.onClick.AddListener(ResolveOnPositiveClicked);
			negativeButton.onClick.AddListener(ResolveOnNegativeClicked);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			positiveButton.onClick.RemoveListener(ResolveOnPositiveClicked);
			negativeButton.onClick.RemoveListener(ResolveOnNegativeClicked);
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

		public void SetDescription(string textLocalizationID)
		{
			description.LocalizationID = textLocalizationID;
		}

		private void ResolveOnNegativeClicked()
		{
			this.OnNegativeClicked?.Invoke();
		}

		private void ResolveOnPositiveClicked()
		{
			this.OnPositiveClicked?.Invoke();
		}

		public void OnCancel(BaseEventData eventData)
		{
			this.OnNegativeClicked?.Invoke();
		}

		public void OnSubmit(BaseEventData eventData)
		{
			this.OnPositiveClicked?.Invoke();
		}
	}
}
