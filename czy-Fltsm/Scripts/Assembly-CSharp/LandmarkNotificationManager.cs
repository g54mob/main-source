using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LandmarkNotificationManager : UIBehaviour
{
	public LandmarkNotification _notificationPrefab;

	private List<LandmarkNotification> _landmarkNotifications = new List<LandmarkNotification>();

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationInitialize, InstantiateLandmarkNotification);
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationDestroy, DestroyLandmarkNotification);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationInitialize, InstantiateLandmarkNotification);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationDestroy, DestroyLandmarkNotification);
	}

	private void InstantiateLandmarkNotification(GameEvent gameEvent)
	{
		LandmarkNotificationEvent landmarkNotificationEvent = gameEvent as LandmarkNotificationEvent;
		LandmarkNotification landmarkNotification = Object.Instantiate(_notificationPrefab);
		landmarkNotification.transform.SetParent(base.transform, worldPositionStays: false);
		landmarkNotification.Initialize(landmarkNotificationEvent.LandmarkBehaviour);
		_landmarkNotifications.Add(landmarkNotification);
	}

	private void DestroyLandmarkNotification(GameEvent gameEvent)
	{
		LandmarkNotificationEvent landmarkNotificationEvent = gameEvent as LandmarkNotificationEvent;
		for (int num = _landmarkNotifications.Count - 1; num >= 0; num--)
		{
			LandmarkNotification landmarkNotification = _landmarkNotifications[num];
			if (!(landmarkNotification.LandmarkBehaviour != landmarkNotificationEvent.LandmarkBehaviour))
			{
				Object.Destroy(landmarkNotification.gameObject);
				_landmarkNotifications.RemoveAt(num);
			}
		}
	}
}
