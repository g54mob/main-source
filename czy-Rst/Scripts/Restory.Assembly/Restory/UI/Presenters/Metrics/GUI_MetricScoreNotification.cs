using System;
using DG.Tweening;
using Restory.Data.Localization;
using Restory.Data.Metrics;
using Restory.Utils;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Metrics
{
	public sealed class GUI_MetricScoreNotification : MonoBehaviour
	{
		[SerializeField]
		private RectTransform panelTransform;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private Vector2 offset = new Vector2(0f, 100f);

		[SerializeField]
		[Min(0f)]
		private float duration = 2f;

		[SerializeField]
		private Ease easeMove = Ease.OutCubic;

		[SerializeField]
		private Ease easeFade = Ease.InQuad;

		[SerializeField]
		private Ease easeOut = Ease.OutCubic;

		private Sequence sequence;

		private TweenSequencesService sequencesService;

		private LocalizationSystem localizationSystem;

		public event Action<GUI_MetricScoreNotification> OnAnimationFinished;

		[Inject]
		private void Construct(TweenSequencesService sequencesService, LocalizationSystem localizationSystem)
		{
			this.sequencesService = sequencesService;
			this.localizationSystem = localizationSystem;
		}

		private void OnDisable()
		{
			if (sequence != null)
			{
				sequencesService.Kill(sequence);
			}
		}

		public void SetScreenPosition(Vector2 screenPosition)
		{
			panelTransform.position = screenPosition;
		}

		public void Play(MetricInfo ratingInfo, int addPoints)
		{
			string translation = localizationSystem.GetTranslation(ratingInfo.NameLocalizationKey);
			text.text = $"{translation} {addPoints:+0;-0;0}";
			if (sequence != null)
			{
				sequencesService.Kill(sequence);
			}
			text.rectTransform.localPosition = Vector3.zero;
			text.alpha = 0f;
			sequence = sequencesService.Create();
			sequence.Join(text.DOFade(1f, duration * 0.5f).SetEase(easeFade));
			sequence.Append(text.DOFade(0f, duration * 0.5f).SetEase(easeOut));
			sequence.Insert(0f, text.rectTransform.DOLocalMove(offset, duration).SetEase(easeMove));
			sequence.OnComplete(delegate
			{
				this.OnAnimationFinished?.Invoke(this);
			});
		}
	}
}
