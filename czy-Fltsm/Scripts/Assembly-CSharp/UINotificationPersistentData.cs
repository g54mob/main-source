using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class UINotificationPersistentData
{
	public int PropertiesPersistentIndex;

	public PersistentGameObjectPeristentReference ObjectOfInterest;

	public ObjectType ObjectOfInterestType;

	[OptionalField(VersionAdded = 2)]
	public bool InGameCanvas;

	[OptionalField(VersionAdded = 2)]
	public float TimeStamp;

	public int BuildablePropertiesPersistentIndex;

	[OptionalField(VersionAdded = 4)]
	public string ResearchGuid;

	public int LandmarkBehaviourPersistentIndex;

	public int DayIndex;

	[OptionalField(VersionAdded = 5)]
	public TutorialID TutorialID;

	public UINotificationPersistentData(NotificationData notification)
	{
		PropertiesPersistentIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(notification.Properties);
		ObjectOfInterest = notification.ObjectOfInterest.GameObjectOfInterest;
		ObjectOfInterestType = notification.ObjectOfInterest.ObjectOfInterestType;
		TimeStamp = notification.Timestamp;
		switch (ObjectOfInterestType)
		{
		case ObjectType.Research:
			if (notification.ObjectOfInterest is ResearchObjectOfInterest researchObjectOfInterest)
			{
				ResearchGuid = researchObjectOfInterest.Research.Guid;
			}
			break;
		case ObjectType.Buildable:
			if (notification.ObjectOfInterest is BuildableObjectOfInterest buildableObjectOfInterest)
			{
				BuildablePropertiesPersistentIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(buildableObjectOfInterest.BuildableProperties);
			}
			break;
		case ObjectType.Landmark:
			if (notification.ObjectOfInterest is LandmarkObjectOfInterest landmarkObjectOfInterest)
			{
				LandmarkBehaviourPersistentIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(landmarkObjectOfInterest.ReturnPersistentLandmarkBehaviour());
			}
			break;
		case ObjectType.Day:
			if (notification.ObjectOfInterest is DayObjectOfInterest dayObjectOfInterest)
			{
				DayIndex = dayObjectOfInterest.DayIndex;
			}
			break;
		case ObjectType.Tutorial:
			if (notification.ObjectOfInterest is TutorialObjectOfInterest tutorialObjectOfInterest)
			{
				TutorialID = tutorialObjectOfInterest.TutorialID;
			}
			break;
		}
	}

	public void Restore(UIManager uiManager)
	{
		if (!((!PersistenceManager.DoesSaveInfoVersionComeBefore(0, 3, 4)) ? GameManager.PersistenceManager.TryReturnPropertiesReference<NotificationProperties>(PropertiesPersistentIndex, out var reference) : GameManager.Settings.UISettings.NotificationProperties.TryReturnReference(PropertiesPersistentIndex, out reference)))
		{
			return;
		}
		INotificationObjectOfInterest notificationObjectOfInterest = null;
		GameObject gameObject;
		switch (ObjectOfInterestType)
		{
		case ObjectType.Research:
		{
			if (CommunityResearch.Research.TryInstantiateFromGuid(ResearchGuid, out var research))
			{
				notificationObjectOfInterest = new ResearchObjectOfInterest(research);
			}
			break;
		}
		case ObjectType.Buildable:
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<BuildableProperties>(BuildablePropertiesPersistentIndex, out var reference2) && ObjectOfInterest.TryRestore(out gameObject))
			{
				notificationObjectOfInterest = new BuildableObjectOfInterest(gameObject, reference2);
			}
			break;
		}
		case ObjectType.Landmark:
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<LandmarkBehaviour>(LandmarkBehaviourPersistentIndex, out var reference3))
			{
				notificationObjectOfInterest = new LandmarkObjectOfInterest(reference3);
			}
			break;
		}
		case ObjectType.Day:
			notificationObjectOfInterest = new DayObjectOfInterest(DayIndex);
			break;
		case ObjectType.Agent:
		{
			if (ObjectOfInterest.TryRestoreAgent(out var agent))
			{
				notificationObjectOfInterest = new AgentObjectOfInterest(agent);
			}
			break;
		}
		case ObjectType.Marker:
			notificationObjectOfInterest = new DefaultObjectOfInterest(null, ObjectOfInterestType);
			break;
		case ObjectType.Tutorial:
			if (TutorialID != TutorialID.None)
			{
				notificationObjectOfInterest = new TutorialObjectOfInterest(TutorialID);
			}
			break;
		}
		if (notificationObjectOfInterest == null)
		{
			if (!ObjectOfInterest.TryRestore(out gameObject))
			{
				Debug.LogWarningFormat("An object of interest of type '{0}' could not be restored!", ObjectOfInterestType);
				return;
			}
			notificationObjectOfInterest = new DefaultObjectOfInterest(gameObject, ObjectOfInterestType);
		}
		uiManager.NotificationHandler.RestoreNotification(reference, notificationObjectOfInterest, InGameCanvas, TimeStamp);
	}
}
