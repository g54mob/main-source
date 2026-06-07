using DG.Tweening;
using Data.Notifications;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Overlays.Notifications
{
	public class GenericNotificationPopup : NotificationPopup
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private RectTransform _emblem;

		[SerializeField]
		private RectTransform _line;

		[SerializeField]
		private TextMeshProUGUI _Text;

		protected override void BuildPopup(AbstractNotificationData notificationData)
		{
			GenericNotificationData genericNotificationData = notificationData as GenericNotificationData;
			_icon.sprite = genericNotificationData.Sprite;
			_Text.text = LocalizationUtility.GetLocalizedText(genericNotificationData.LocaKey);
		}

		protected override void AnimateIn()
		{
			base.AnimateIn();
			DOTween.Sequence().AppendInterval(0.3f).Append(_rectTransform.DOScale(Vector3.one, 0.4f).From(Vector3.zero).SetEase(Ease.OutBack, 2f))
				.Insert(0.3f, _gradientLeft.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutSine))
				.Insert(0.3f, _gradientRight.DOScale(Vector3.one, 1.5f).SetEase(Ease.OutSine))
				.Insert(0.6f, _icon.rectTransform.DOScale(Vector3.one, 0.4f).From(Vector3.zero).SetEase(Ease.OutBack, 4f))
				.Insert(0.6f, _textCanvasGroup.DOFade(1f, 0.3f).From(0f))
				.Insert(0.6f, _line.DOScaleX(1f, 0.3f).From(0f).SetEase(Ease.OutBack))
				.OnComplete(base.StartTimer);
		}
	}
}
