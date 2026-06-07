using System;
using DG.Tweening;
using Data.Notifications;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public class NotificationPopup : NotificationWithDuration
	{
		[Header("UI Refs")]
		[SerializeField]
		protected RectTransform _rectTransform;

		[SerializeField]
		protected RectTransform _gradientLeft;

		[SerializeField]
		protected RectTransform _gradientRight;

		[SerializeField]
		protected CanvasGroup _textCanvasGroup;

		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[Header("Behaviour")]
		[SerializeField]
		private float _popupDuration = 3f;

		public Action OnClose;

		public void Build(AbstractNotificationData notificationData)
		{
			BuildPopup(notificationData);
			SetupTimer(_popupDuration);
			Show();
		}

		protected virtual void BuildPopup(AbstractNotificationData notificationData)
		{
		}

		protected override void AnimateIn()
		{
			Reset();
			base.gameObject.SetActive(value: true);
		}

		protected virtual void Reset()
		{
			_gradientLeft.localScale = new Vector3(0f, 1f, 1f);
			_gradientRight.localScale = new Vector3(0f, 1f, 1f);
		}

		protected override void RemoveNotification()
		{
			base.RemoveNotification();
			DOTween.Sequence().Append(_rectTransform.DOScale(Vector3.zero, 0.6f).SetEase(Ease.InBack)).OnComplete(OnNotificationRemoved);
		}

		private void OnNotificationRemoved()
		{
			base.gameObject.SetActive(value: false);
			OnClose?.Invoke();
		}
	}
}
