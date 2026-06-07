using System;
using System.Collections.Generic;
using UnityEngine;

public class NotificationHandler : MonoBehaviour
{
	[Serializable]
	public class PersistentData
	{
		private readonly List<int> _notifiedNotificationsIDs;

		public PersistentData()
		{
			NotificationHandler notificationHandler = GameManager.UIManager.NotificationHandler;
			_notifiedNotificationsIDs = new List<int>((notificationHandler._notifiedNotifications.Count > 0) ? notificationHandler._notifiedNotifications.Count : 8);
			foreach (NotificationProperties notifiedNotification in notificationHandler._notifiedNotifications)
			{
				_notifiedNotificationsIDs.Add(GameManager.PersistenceManager.ReturnPropertiesIndex(notifiedNotification));
			}
		}

		public void Restore()
		{
			if (_notifiedNotificationsIDs.IsNullOrEmpty())
			{
				return;
			}
			NotificationHandler notificationHandler = GameManager.UIManager.NotificationHandler;
			notificationHandler._notifiedNotifications.Clear();
			foreach (int notifiedNotificationsID in _notifiedNotificationsIDs)
			{
				if (GameManager.PersistenceManager.TryReturnPropertiesReference<NotificationProperties>(notifiedNotificationsID, out var reference))
				{
					notificationHandler._notifiedNotifications.Add(reference);
				}
			}
		}
	}

	[Header("Notification Log")]
	[SerializeField]
	private NotificationLog _log;

	private readonly HashSet<NotificationProperties> _notifiedNotifications = new HashSet<NotificationProperties>();

	private void Start()
	{
		GameEventDispatcher.AddListener(GameEventType.MarkerDestroyed, AddMarkerFinishedNotification);
		GameEventDispatcher.AddListener(GameEventType.LandmarkActionCompleted, AddLandmarkActionCompletedNotification);
		GameEventDispatcher.AddListener(GameEventType.ResearchStationBuilt, AddResearchStationNotification);
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, AddSalvageRadiusIncreasedNotification);
		_notifiedNotifications.Remove(GameManager.Settings.UISettings.ResearchUnlockedNotification);
	}

	public void Clear()
	{
		_notifiedNotifications.Clear();
		NotificationData.Clear();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MarkerDestroyed, AddMarkerFinishedNotification);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkActionCompleted, AddLandmarkActionCompletedNotification);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStationBuilt, AddResearchStationNotification);
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, AddSalvageRadiusIncreasedNotification);
	}

	public void AddNotification(NotificationProperties properties, GameObject objectOfInterest, ObjectType objectOfInterestType)
	{
		AddNotification(properties, new DefaultObjectOfInterest(objectOfInterest, objectOfInterestType));
	}

	public void AddNotification(NotificationProperties properties, INotificationObjectOfInterest objectOfInterest)
	{
		if (!(properties == null) && !Notification.Exists(properties, objectOfInterest))
		{
			_notifiedNotifications.Add(properties);
			if (!properties.AudioOnly)
			{
				_log.AddNotification(properties, objectOfInterest, GameManager.TimeManager.ReturnTotalTimePlayed());
			}
			AudioManager.Play(properties.Audio);
		}
	}

	public void RestoreNotification(NotificationProperties properties, INotificationObjectOfInterest objectOfInterest, bool addCanvasNotification, float timeStamp)
	{
		_log.AddNotification(properties, objectOfInterest, timeStamp);
	}

	private void AddLandmarkActionCompletedNotification(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && (bool)landmarkNotificationEvent.LandmarkAction.CompletedNotification)
		{
			AddNotification(landmarkNotificationEvent.LandmarkAction.CompletedNotification, new LandmarkObjectOfInterest(landmarkNotificationEvent.LandmarkBehaviour));
		}
	}

	private void AddMarkerFinishedNotification(GameEvent gameEvent)
	{
		MarkerEvent markerEvent = gameEvent as MarkerEvent;
		if (!markerEvent.Marker.ManuallyRemoved)
		{
			if ((markerEvent.Marker.MarkerCursorProperties.AllowedItemTags & Item.Tags.FishMarker) != Item.Tags.None)
			{
				AddNotification(GameManager.Settings.UISettings.FishingMarkerFinishedNotification, markerEvent.Marker.gameObject, ObjectType.Marker);
			}
			else
			{
				AddNotification(GameManager.Settings.UISettings.SalvageMarkerFinishedNotification, markerEvent.Marker.gameObject, ObjectType.Marker);
			}
		}
	}

	private void AddResearchStationNotification(GameEvent gameEvent)
	{
		if (!_notifiedNotifications.Contains(GameManager.Settings.UISettings.ResearchUnlockedNotification))
		{
			_notifiedNotifications.Add(GameManager.Settings.UISettings.ResearchUnlockedNotification);
			AddNotification(GameManager.Settings.UISettings.ResearchUnlockedNotification, new DefaultObjectOfInterest(Community.PlayerCommunity.Research.ResearchStations[0].gameObject, ObjectType.Research));
		}
	}

	private void AddSalvageRadiusIncreasedNotification(GameEvent gameEvent)
	{
		if ((gameEvent as BuildableEvent).BuildableProperties.RequiresMooringPoint && Community.PlayerCommunity.ReturnAllBoats().Count == 1)
		{
			AddNotification(GameManager.Settings.UISettings.SalvageRadiusIncreasedNotification, new DefaultObjectOfInterest(Community.PlayerCommunity.ReturnAllBoats()[0].gameObject, ObjectType.None));
		}
	}
}
