using UnityEngine;

public class BuildableObjectOfInterest : INotificationObjectOfInterest
{
	private bool _selectObjectOfInterest;

	public GameObject GameObjectOfInterest { get; private set; }

	public ObjectType ObjectOfInterestType => ObjectType.Buildable;

	public BuildableProperties BuildableProperties { get; private set; }

	public BuildableObjectOfInterest(GameObject objectOfInterest, BuildableProperties buildableProperties, bool selectObjectOfInterest = false)
	{
		GameObjectOfInterest = objectOfInterest;
		BuildableProperties = buildableProperties;
		_selectObjectOfInterest = selectObjectOfInterest;
	}

	public string NotificationReplaceVariables(string message)
	{
		return TextManager.ReplaceVariables(message, BuildableProperties);
	}

	public void NotificationLeftClick()
	{
		if (!(GameObjectOfInterest == null))
		{
			CameraController.Instance.Lock(GameObjectOfInterest);
			if (_selectObjectOfInterest)
			{
				Selector.Select(GameObjectOfInterest, ObjectOfInterestType);
			}
		}
	}

	public bool IsMatch(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest.ObjectOfInterestType == ObjectType.Buildable)
		{
			BuildableObjectOfInterest buildableObjectOfInterest = objectOfInterest as BuildableObjectOfInterest;
			if (GameObjectOfInterest == objectOfInterest.GameObjectOfInterest)
			{
				return BuildableProperties == buildableObjectOfInterest.BuildableProperties;
			}
			return false;
		}
		return false;
	}
}
