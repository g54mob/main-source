using System;
using System.Collections.Generic;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Notifications
{
	public sealed class GUI_NotificationCanvas : MonoBehaviour
	{
		[SerializeField]
		private RectTransform notificationsContainer;

		[SerializeField]
		private Vector2 offset = new Vector2(0f, 60f);

		private readonly HashSet<GUI_NotificationBase> activeNotifications = new HashSet<GUI_NotificationBase>();

		private Camera gameCamera;

		private GUI_TipsNotificationPool tipsNotificationPool;

		private GUI_MoneyNotificationPool moneyNotificationPool;

		[Inject]
		private void Construct([Inject(Id = "GameCamera")] Camera gameCamera, GUI_TipsNotificationPool tipsNotificationPool, GUI_MoneyNotificationPool moneyNotificationPool)
		{
			this.gameCamera = gameCamera;
			this.tipsNotificationPool = tipsNotificationPool;
			this.moneyNotificationPool = moneyNotificationPool;
		}

		private void OnDisable()
		{
			foreach (GUI_NotificationBase activeNotification in activeNotifications)
			{
				activeNotification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			}
		}

		public void ShowTipsNotification(int tipsAmount, Transform target)
		{
			GUI_TipsNotification notification = tipsNotificationPool.Get<GUI_TipsNotification>(notificationsContainer);
			InitNotification(notification, target);
		}

		public void ShowMoneyNotification(int moneyAmount, Transform target)
		{
			GUI_MoneyNotification gUI_MoneyNotification = moneyNotificationPool.Get<GUI_MoneyNotification>(notificationsContainer);
			gUI_MoneyNotification.SetMoneyAmount(moneyAmount);
			InitNotification(gUI_MoneyNotification, target);
		}

		private void InitNotification(GUI_NotificationBase notification, Transform target)
		{
			Vector2 vector = gameCamera.WorldToScreenPoint(target.position);
			activeNotifications.Add(notification);
			notification.SetScreenPosition(vector + offset);
			notification.OnAnimationFinished += ResolveOnNotificationAnimationFinished;
			notification.Play();
		}

		private void ResolveOnNotificationAnimationFinished(GUI_NotificationBase notification)
		{
			notification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			activeNotifications.Remove(notification);
			if (!(notification is GUI_TipsNotification instance))
			{
				if (!(notification is GUI_MoneyNotification instance2))
				{
					throw new ArgumentOutOfRangeException("notification", notification, null);
				}
				moneyNotificationPool.Release(instance2);
			}
			else
			{
				tipsNotificationPool.Release(instance);
			}
		}
	}
}
