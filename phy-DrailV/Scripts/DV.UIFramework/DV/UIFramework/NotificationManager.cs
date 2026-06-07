using System;
using System.Collections.Generic;
using DV.Localization;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class NotificationManager : NullCheckingMonoBehaviour
	{
		public enum Ordering
		{
			Default = 0,
			First = 1,
			Last = 2
		}

		private class RuntimeWrapper
		{
			public GameObject notification;

			public float timer;

			public Transform target;
		}

		public struct SizeOverrides
		{
			public float? overallScale;

			public float? textScale;

			public float? verticalMarginScale;

			public float? horizontalMarginScale;
		}

		public struct ColorOverrides
		{
			public Color? backgroundColor;

			public float? backgroundOpacity;

			public Color? textColor;
		}

		[NonSerialized]
		public ANotificationManagerProvider provider;

		[SerializeField]
		private GameObject notificationPrefab;

		private List<RuntimeWrapper> notifications = new List<RuntimeWrapper>();

		public event Action<int> NotificationCountUpdated;

		private void Update()
		{
			for (int num = notifications.Count - 1; num >= 0; num--)
			{
				if (Time.unscaledTime > notifications[num].timer)
				{
					ClearNotification(notifications[num]);
				}
			}
		}

		public GameObject ShowNotification(string locKey, string[] locParams = null, float duration = float.MaxValue, bool clearExisting = true, Transform pointAt = null, bool localize = true, bool targetIsUI = false, SizeOverrides sizeOverrides = default(SizeOverrides), Ordering ordering = Ordering.Default, ColorOverrides colorOverrides = default(ColorOverrides))
		{
			if (clearExisting)
			{
				ClearAllNotifications();
			}
			string text = (localize ? LocalizationAPI.L(locKey, locParams) : locKey);
			GameObject gameObject = UnityEngine.Object.Instantiate(notificationPrefab, provider.ContentRoot, worldPositionStays: false);
			NotificationController component = gameObject.GetComponent<NotificationController>();
			if (colorOverrides.backgroundColor.HasValue && (bool)component.background)
			{
				component.background.color = colorOverrides.backgroundColor.Value;
			}
			if (colorOverrides.backgroundOpacity.HasValue && (bool)component.background)
			{
				Color color = component.background.color;
				color.a *= colorOverrides.backgroundOpacity.Value;
				component.background.color = color;
			}
			if (colorOverrides.textColor.HasValue)
			{
				component.textContent.color = colorOverrides.textColor.Value;
			}
			switch (ordering)
			{
			case Ordering.First:
				gameObject.transform.SetAsFirstSibling();
				break;
			case Ordering.Last:
				gameObject.transform.SetAsLastSibling();
				break;
			}
			if (sizeOverrides.overallScale.HasValue)
			{
				gameObject.transform.localScale *= sizeOverrides.overallScale.Value;
			}
			component.textContent.text = text;
			if (sizeOverrides.textScale.HasValue)
			{
				component.textContent.fontSize *= sizeOverrides.textScale.Value;
			}
			if (sizeOverrides.horizontalMarginScale.HasValue || sizeOverrides.verticalMarginScale.HasValue)
			{
				Vector4 margin = component.textContent.margin;
				if (sizeOverrides.horizontalMarginScale.HasValue)
				{
					margin.x *= sizeOverrides.horizontalMarginScale.Value;
					margin.z *= sizeOverrides.horizontalMarginScale.Value;
				}
				if (sizeOverrides.verticalMarginScale.HasValue)
				{
					margin.y *= sizeOverrides.verticalMarginScale.Value;
					margin.w *= sizeOverrides.verticalMarginScale.Value;
				}
				component.textContent.margin = margin;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(provider.ContentRoot);
			notifications.Add(new RuntimeWrapper
			{
				notification = gameObject,
				timer = duration + Time.unscaledTime,
				target = pointAt
			});
			if (pointAt != null)
			{
				provider.AddWorldSpacePointer(gameObject, pointAt, targetIsUI, gameObject);
			}
			provider.OnNotificationAdded(gameObject);
			this.NotificationCountUpdated?.Invoke(notifications.Count);
			return gameObject;
		}

		public void ClearNotification(GameObject notification)
		{
			int index = GetIndex(notification);
			if (index >= 0)
			{
				ClearNotification(notifications[index]);
			}
		}

		private void ClearNotification(RuntimeWrapper wrapper)
		{
			notifications.Remove(wrapper);
			if ((bool)wrapper.target)
			{
				provider.ClearWorldSpacePointer(wrapper.notification);
			}
			wrapper.notification.transform.SetParent(null);
			UnityEngine.Object.Destroy(wrapper.notification);
			LayoutRebuilder.ForceRebuildLayoutImmediate(provider.ContentRoot);
			this.NotificationCountUpdated?.Invoke(notifications.Count);
		}

		private int GetIndex(GameObject notification)
		{
			for (int i = 0; i < notifications.Count; i++)
			{
				if (notifications[i].notification.Equals(notification))
				{
					return i;
				}
			}
			return -1;
		}

		public void ClearAllNotifications()
		{
			for (int num = notifications.Count - 1; num >= 0; num--)
			{
				ClearNotification(notifications[num]);
			}
		}
	}
}
