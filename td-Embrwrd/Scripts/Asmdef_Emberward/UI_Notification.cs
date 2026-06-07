using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Notification : MonoBehaviour
{
	[Serializable]
	public class NotificationData
	{
		public string msg;

		public float duration;
	}

	[SerializeField]
	private GameObject prefab_Notification;

	[SerializeField]
	private VerticalLayoutGroup layoutGroup;

	[SerializeField]
	private int maxActiveNotificationCount;

	[SerializeField]
	private float notificationStayTime;

	[SerializeField]
	private Queue<NotificationData> queue_pendingNotification;

	private int activatedNotificationCount;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTriggerNotification(string msg)
	{
	}

	private void TriggerNotification_OverrideTime(string msg, float time)
	{
	}

	private void Update()
	{
	}

	private void Callback_NotificationEnd()
	{
	}
}
