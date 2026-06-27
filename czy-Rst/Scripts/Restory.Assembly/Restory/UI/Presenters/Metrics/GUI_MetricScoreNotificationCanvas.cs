using System.Collections.Generic;
using Restory.Data.Metrics;
using Restory.Gameplay.GameCursor;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Metrics
{
	public sealed class GUI_MetricScoreNotificationCanvas : MonoBehaviour
	{
		[SerializeField]
		private Vector2 offset = new Vector2(0f, 50f);

		[SerializeField]
		private RectTransform notificationsContainer;

		private readonly HashSet<GUI_MetricScoreNotification> activeNotifications = new HashSet<GUI_MetricScoreNotification>();

		private VirtualCursorPresenter playerMouse;

		private ConcreteGameObjectPool pool;

		[Inject]
		private void Construct(VirtualCursorPresenter playerMouse, ConcreteGameObjectPool guiMetricScoreNotificationPool)
		{
			this.playerMouse = playerMouse;
			pool = guiMetricScoreNotificationPool;
		}

		private void OnDisable()
		{
			foreach (GUI_MetricScoreNotification activeNotification in activeNotifications)
			{
				activeNotification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			}
		}

		public void Show(MetricInfo ratingInfo, int addPoints)
		{
			GUI_MetricScoreNotification gUI_MetricScoreNotification = pool.Get<GUI_MetricScoreNotification>(notificationsContainer);
			gUI_MetricScoreNotification.SetScreenPosition(playerMouse.ScreenPosition + offset);
			gUI_MetricScoreNotification.Play(ratingInfo, addPoints);
			activeNotifications.Add(gUI_MetricScoreNotification);
			gUI_MetricScoreNotification.OnAnimationFinished += ResolveOnNotificationAnimationFinished;
		}

		private void ResolveOnNotificationAnimationFinished(GUI_MetricScoreNotification notification)
		{
			notification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			activeNotifications.Remove(notification);
			pool.Release(notification);
		}
	}
}
