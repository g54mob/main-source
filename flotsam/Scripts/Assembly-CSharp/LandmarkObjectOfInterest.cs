using UnityEngine;

public class LandmarkObjectOfInterest : INotificationObjectOfInterest
{
	public GameObject GameObjectOfInterest { get; private set; }

	public ObjectType ObjectOfInterestType => ObjectType.Landmark;

	public LandmarkBehaviour LandmarkBehaviour { get; private set; }

	public LandmarkObjectOfInterest(LandmarkBehaviour landmarkBehaviour)
	{
		LandmarkBehaviour = landmarkBehaviour;
		if ((bool)landmarkBehaviour.Landmark)
		{
			GameObjectOfInterest = landmarkBehaviour.Landmark.gameObject;
		}
	}

	public string NotificationReplaceVariables(string text)
	{
		if (LandmarkBehaviour.Actor != null)
		{
			text = TextManager.ReplaceVariables(text, LandmarkBehaviour.Actor.Vitals);
		}
		return TextManager.ReplaceVariables(text, LandmarkBehaviour);
	}

	public void NotificationLeftClick()
	{
		if (!(LandmarkBehaviour.Landmark == null) && WorldManager.IsInInteractionRadius(GameObjectOfInterest.transform.position))
		{
			CameraController.Instance.CenterOnTransform(GameObjectOfInterest.transform, LandmarkBehaviour.Landmark.CameraZoomLevel, CameraController.TargetFocusOrientationType.LookAtTarget, delegate
			{
				Selector.Select(GameObjectOfInterest, ObjectType.Landmark);
			});
		}
	}

	public bool IsMatch(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest.ObjectOfInterestType == ObjectType.Landmark)
		{
			LandmarkObjectOfInterest landmarkObjectOfInterest = objectOfInterest as LandmarkObjectOfInterest;
			if (GameObjectOfInterest == objectOfInterest.GameObjectOfInterest)
			{
				return LandmarkBehaviour == landmarkObjectOfInterest.LandmarkBehaviour;
			}
			return false;
		}
		return false;
	}

	public LandmarkBehaviour ReturnPersistentLandmarkBehaviour()
	{
		if (!LandmarkBehaviour.Prefab)
		{
			return LandmarkBehaviour;
		}
		return LandmarkBehaviour.Prefab;
	}
}
