using System.Collections.Generic;
using DG.Tweening;
using Restory.Gameplay.Equipment;
using Restory.ObjectPools;
using Restory.UserInterface;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.InventoryNotification
{
	public sealed class GUI_InventoryNotificationCanvas : MonoBehaviour
	{
		[SerializeField]
		private RectTransform notificationsContainer;

		[SerializeField]
		private GUI_ScreenObjectModelFollower notificationsContainerFollower;

		private readonly HashSet<GUI_InventoryNotification> activeNotifications = new HashSet<GUI_InventoryNotification>();

		private ConcreteGameObjectPool pool;

		private Sequence sequence;

		private TweenSequencesService sequencesService;

		public bool HasActiveNotifications => activeNotifications.Count > 0;

		[Inject]
		private void Construct(TweenSequencesService sequencesService)
		{
			this.sequencesService = sequencesService;
		}

		[Inject]
		private void Construct(ConcreteGameObjectPool guiRatingScoreNotificationPool, InventoryBox inventoryBox)
		{
			pool = guiRatingScoreNotificationPool;
			notificationsContainerFollower.FollowTransform = inventoryBox.transform;
		}

		private void OnDisable()
		{
			foreach (GUI_InventoryNotification activeNotification in activeNotifications)
			{
				activeNotification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			}
		}

		public void Show(IEnumerable<string> items)
		{
			if (sequence != null)
			{
				sequencesService.Kill(sequence);
			}
			sequence = sequencesService.Create();
			foreach (string item in items)
			{
				sequence.AppendCallback(delegate
				{
					Show(item);
				});
				sequence.AppendInterval(0.5f);
			}
		}

		private void Show(string text)
		{
			GUI_InventoryNotification gUI_InventoryNotification = pool.Get<GUI_InventoryNotification>(notificationsContainer);
			gUI_InventoryNotification.SetAnchoredPosition(Vector3.zero);
			gUI_InventoryNotification.Play(text);
			activeNotifications.Add(gUI_InventoryNotification);
			gUI_InventoryNotification.OnAnimationFinished += ResolveOnNotificationAnimationFinished;
		}

		public void Hide()
		{
			if (sequence != null)
			{
				sequencesService.Kill(sequence);
				sequence = null;
			}
			foreach (GUI_InventoryNotification activeNotification in activeNotifications)
			{
				activeNotification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
				activeNotification.Stop();
				pool.Release(activeNotification);
			}
			activeNotifications.Clear();
		}

		private void ResolveOnNotificationAnimationFinished(GUI_InventoryNotification notification)
		{
			notification.OnAnimationFinished -= ResolveOnNotificationAnimationFinished;
			activeNotifications.Remove(notification);
			pool.Release(notification);
		}
	}
}
