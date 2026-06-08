using System;
using System.Collections;
using NotificationSamples;
using UnityEngine;

public class LocalNotifications : MonoBehaviour
{
	public static bool TEST_NOTIFICATIONS;

	public GameNotificationsManager manager;

	public static LocalNotifications singleton { get; private set; }

	private void Awake()
	{
		singleton = this;
	}

	private IEnumerator Start()
	{
		return null;
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus && manager.Initialized)
		{
			manager.DismissAllNotifications();
		}
	}

	public void Schedule(string title, string body, DateTime deliveryDateTime, bool autoReschedule = false)
	{
		IGameNotification gameNotification = manager.CreateNotification();
		if (gameNotification != null)
		{
			gameNotification.Title = title;
			gameNotification.Body = body;
			gameNotification.DeliveryTime = deliveryDateTime;
			gameNotification.SmallIcon = "small_game_icon";
			manager.ScheduleNotification(gameNotification).Reschedule = autoReschedule;
		}
	}

	private void OnGUI()
	{
		if (TEST_NOTIFICATIONS)
		{
			NotificationMacros.DebugGUI();
		}
	}
}
