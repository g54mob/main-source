using System.Collections.Generic;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shredders
{
	public sealed class GUI_ShredderRewardsNotificationCanvas : MonoBehaviour
	{
		[SerializeField]
		private RectTransform notificationsContainer;

		[SerializeField]
		private Vector2 offset = new Vector2(0f, 50f);

		private readonly HashSet<GUI_ShredderRewardsNotification> activeNotifications = new HashSet<GUI_ShredderRewardsNotification>();

		private Camera gameCamera;

		private ConcreteGameObjectPool rewardsNotificationPool;

		[Inject]
		private void Construct([Inject(Id = "GameCamera")] Camera gameCamera, ConcreteGameObjectPool rewardsNotificationPool)
		{
			this.gameCamera = gameCamera;
			this.rewardsNotificationPool = rewardsNotificationPool;
		}

		private void OnDisable()
		{
			foreach (GUI_ShredderRewardsNotification activeNotification in activeNotifications)
			{
				activeNotification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			}
		}

		public void Show(int rewardAmount, bool isCriticalSuccess, Transform target)
		{
			Vector2 vector = gameCamera.WorldToScreenPoint(target.position);
			GUI_ShredderRewardsNotification gUI_ShredderRewardsNotification = rewardsNotificationPool.Get<GUI_ShredderRewardsNotification>(notificationsContainer);
			gUI_ShredderRewardsNotification.SetScreenPosition(vector + offset);
			gUI_ShredderRewardsNotification.Play(rewardAmount, isCriticalSuccess);
			activeNotifications.Add(gUI_ShredderRewardsNotification);
			gUI_ShredderRewardsNotification.OnAnimationFinished += ResolveOnNotificationAnimationFinished;
		}

		private void ResolveOnNotificationAnimationFinished(GUI_ShredderRewardsNotification notification)
		{
			notification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			activeNotifications.Remove(notification);
			rewardsNotificationPool.Release(notification);
		}
	}
}
