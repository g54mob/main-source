using System;
using System.Collections.Generic;
using DG.Tweening;
using Restory.Data.WorkshopStatus;
using Restory.ObjectPools;
using Restory.UI.Presenters.PauseMenu;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.WorkshopStatus
{
	public sealed class GUI_WorkshopStatusNotificationCanvas : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float showHideDelay = 0.25f;

		[SerializeField]
		private RectTransform notificationsContainer;

		[SerializeField]
		private Vector3 localPosition;

		private readonly Dictionary<GUI_WorkshopStatusNotification, Sequence> activeNotifications = new Dictionary<GUI_WorkshopStatusNotification, Sequence>();

		private GUI_PauseMenu pauseMenu;

		private ConcreteGameObjectPool pool;

		private TweenSequencesService tweenSequencesService;

		private Sequence showHideSequence;

		[Inject]
		private void Construct(GUI_PauseMenu pauseMenu, ConcreteGameObjectPool guiWorkshopStatusNotificationPool, TweenSequencesService tweenSequencesService)
		{
			this.pauseMenu = pauseMenu;
			pool = guiWorkshopStatusNotificationPool;
			this.tweenSequencesService = tweenSequencesService;
		}

		public void Initialize()
		{
			pauseMenu.OnIsShownChanged += ResolveOnPauseMenuIsShownChanged;
		}

		public void Dispose()
		{
			pauseMenu.OnIsShownChanged -= ResolveOnPauseMenuIsShownChanged;
			foreach (KeyValuePair<GUI_WorkshopStatusNotification, Sequence> activeNotification in activeNotifications)
			{
				tweenSequencesService.Kill(activeNotification.Value);
				pool.Release(activeNotification.Key);
			}
			activeNotifications.Clear();
			if (showHideSequence != null)
			{
				tweenSequencesService.Kill(showHideSequence);
				showHideSequence = null;
			}
		}

		public void Show(StatusInfo status)
		{
			GUI_WorkshopStatusNotification notification = pool.Get<GUI_WorkshopStatusNotification>(notificationsContainer);
			Sequence sequence = tweenSequencesService.Create();
			sequence.OnStart(delegate
			{
				notification.SetAnchoredPosition(localPosition);
			});
			sequence.AppendCallback(delegate
			{
				notification.Show(status);
			});
			sequence.AppendInterval(2.5f);
			sequence.AppendCallback(delegate
			{
				notification.Hide();
			});
			sequence.AppendInterval(2f);
			sequence.OnComplete(delegate
			{
				activeNotifications.Remove(notification, out var value);
				tweenSequencesService.Kill(value);
				pool.Release(notification);
			});
			activeNotifications.Add(notification, sequence);
		}

		private void ResolveOnPauseMenuIsShownChanged(GUI_PauseMenu pauseMenu, bool isShown)
		{
			if (showHideSequence != null)
			{
				tweenSequencesService.Kill(showHideSequence);
			}
			showHideSequence = tweenSequencesService.Create();
			showHideSequence.SetUpdate(isIndependentUpdate: true);
			showHideSequence.Append(canvasGroup.DOFade(isShown ? 0f : 1f, showHideDelay));
		}
	}
}
