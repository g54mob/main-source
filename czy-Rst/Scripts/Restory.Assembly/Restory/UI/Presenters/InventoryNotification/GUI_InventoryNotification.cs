using System;
using DG.Tweening;
using Restory.Utils;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.InventoryNotification
{
	public sealed class GUI_InventoryNotification : MonoBehaviour
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

		public event Action<GUI_InventoryNotification> OnAnimationFinished;

		[Inject]
		private void Construct(TweenSequencesService sequencesService)
		{
			this.sequencesService = sequencesService;
		}

		private void OnDisable()
		{
			Stop();
		}

		public void SetAnchoredPosition(Vector2 anchoredPosition)
		{
			panelTransform.anchoredPosition = anchoredPosition;
		}

		public void Play(string text)
		{
			this.text.text = text;
			if (sequence != null)
			{
				sequencesService.Kill(sequence);
			}
			this.text.rectTransform.anchoredPosition = Vector2.zero;
			this.text.alpha = 0f;
			sequence = sequencesService.Create();
			sequence.Join(this.text.DOFade(1f, duration * 0.5f).SetEase(easeFade));
			sequence.Append(this.text.DOFade(0f, duration * 0.5f).SetEase(easeOut));
			sequence.Insert(0f, this.text.rectTransform.DOAnchorPos(offset, duration).SetEase(easeMove));
			sequence.OnComplete(delegate
			{
				this.OnAnimationFinished?.Invoke(this);
			});
		}

		public void Stop()
		{
			if (sequence != null)
			{
				sequencesService.Kill(sequence);
				sequence = null;
			}
		}
	}
}
