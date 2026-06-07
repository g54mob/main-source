using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class NotificationArea3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _buildMenuOffset;

		[SerializeField]
		private Vector3 _infoPanelOffset;

		[SerializeField]
		private Vector3 _baseOffsetWithEventCamera;

		[SerializeField]
		private Vector3 _baseOffset;

		private Tween _positionOffsetTween;

		[SerializeField]
		private Ease _positionOffsetEase;

		[SerializeField]
		private float _positionOffsetDuration;

		public GameObject notificationPrefab;

		public GameObject patronTrackerNotificationPrefab;

		[SerializeField]
		private Transform _notificationsContainer;

		private List<Notification3DUIView> _notifications;

		public float notificationSpacing;

		[SerializeField]
		private Button3DUIView _showHideButton;

		private Tween _showHideTween;

		[SerializeField]
		private float _showHideDuration;

		[SerializeField]
		private AnimationCurve _hideEase;

		[SerializeField]
		private AnimationCurve _showEase;

		public List<Notification3DUIView> Notifications => null;

		public bool IsShowing { get; private set; }

		public static event EventHandler NotificationAreaIsDirty
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler ShowHideFinished
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void RaiseNotificationAreaIsDirty()
		{
		}

		private void Awake()
		{
		}

		private void OnNotificationAreaIsDirty(object sender, EventArgs e)
		{
		}

		public void UpdateAreaPosition()
		{
		}

		private Notification3DUIView GetNotificationForGroup(string groupId)
		{
			return null;
		}

		public void UpdateNotification(UINotificationData uiNotificationData, UIController.UINotificationVisualData visualData, string oldId = null)
		{
		}

		public void AddNotification(UINotificationData uiNotificationData, UIController.UINotificationVisualData visualData)
		{
		}

		public void UpdateNotificationCount()
		{
		}

		public void RemoveNotification(string id, ShowHideAnimationSpeed speed)
		{
		}

		public void DestroyNotification(Notification3DUIView notification, ShowHideAnimationSpeed speed)
		{
		}

		public void PositionNotifications()
		{
		}

		private void Start()
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}

		private void NewNotificationFeedback(UINotificationData uiData, UIController.UINotificationVisualData visualData)
		{
		}

		private void OnNotificationDestroyed(object sender, EventArgs e)
		{
		}

		private void OnNotificationIsDirty(object sender, EventArgs e)
		{
		}
	}
}
