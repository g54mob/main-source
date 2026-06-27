using System;
using DG.Tweening;
using Restory.Utils;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Notifications
{
	public abstract class GUI_NotificationBase : MonoBehaviour
	{
		[SerializeField]
		private RectTransform panelTransform;

		[SerializeField]
		protected TextMeshProUGUI text;

		[Space]
		[Header("Animation Settings")]
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

		private TweenSequencesService sequencesService;

		private Sequence sequence;

		public event Action<GUI_NotificationBase> OnAnimationFinished;

		[Inject]
		private void Construct(TweenSequencesService sequencesService)
		{
			this.sequencesService = sequencesService;
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

		public void Play()
		{
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
