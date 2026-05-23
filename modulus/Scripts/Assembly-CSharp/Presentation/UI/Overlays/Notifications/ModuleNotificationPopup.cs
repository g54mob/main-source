using DG.Tweening;
using Data.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Overlays.Notifications
{
	public class ModuleNotificationPopup : NotificationPopup
	{
		[SerializeField]
		private Image _shape;

		[SerializeField]
		private RectTransform _emblem;

		[SerializeField]
		private CanvasGroup _completionCheck;

		[SerializeField]
		private RectTransform _line;

		protected override void BuildPopup(AbstractNotificationData notificationData)
		{
			Texture2D gridIcon = (notificationData as ModuleNotificationData).ShapeData.GridIcon;
			_shape.sprite = Sprite.Create(gridIcon, new Rect(0f, 0f, gridIcon.width, gridIcon.height), new Vector2(0.5f, 0.5f));
		}

		protected override void AnimateIn()
		{
			base.AnimateIn();
			DOTween.Sequence().AppendInterval(0.3f).Append(_rectTransform.DOScale(Vector3.one, 0.4f).From(Vector3.zero).SetEase(Ease.OutBack, 2f))
				.Insert(0.3f, _gradientLeft.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutSine))
				.Insert(0.3f, _gradientRight.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutSine))
				.Insert(0.6f, _shape.rectTransform.DOScale(Vector3.one, 0.4f).From(Vector3.zero).SetEase(Ease.OutBack, 4f))
				.Insert(0.6f, _textCanvasGroup.DOFade(1f, 0.3f).From(0f))
				.Insert(0.6f, _line.DOScaleX(1f, 0.3f).From(0f).SetEase(Ease.OutBack))
				.Append(_completionCheck.transform.DOPunchScale(Vector3.one * 1.5f, 0.4f, 2))
				.Join(_completionCheck.DOFade(1f, 0.15f).From(0f))
				.OnComplete(base.StartTimer);
			_audioManagerLocator.AudioManager.PlayNewModuleCreated();
		}

		protected new virtual void Reset()
		{
			base.Reset();
			_completionCheck.transform.localScale = Vector3.one;
		}
	}
}
