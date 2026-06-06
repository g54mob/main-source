using UnityEngine;

public struct EnergyGridObjectOfInterest : INotificationObjectOfInterest
{
	private EnergyGrid _grid;

	public GameObject GameObjectOfInterest => _grid.Links[0].gameObject;

	public ObjectType ObjectOfInterestType { get; private set; }

	public EnergyGridObjectOfInterest(EnergyGrid grid)
	{
		_grid = grid;
		ObjectOfInterestType = ObjectType.Buildable;
	}

	public string NotificationReplaceVariables(string message)
	{
		switch (ObjectOfInterestType)
		{
		case ObjectType.CommunityMember:
		case ObjectType.Agent:
			message = TextManager.ReplaceVariables(message, GameObjectOfInterest.GetComponent<Vitals>());
			break;
		case ObjectType.Bird:
			message = TextManager.ReplaceVariables(message, GameObjectOfInterest.GetComponent<Bird>());
			break;
		}
		return message;
	}

	public void NotificationLeftClick()
	{
		if (!(GameObjectOfInterest == null))
		{
			CameraController.Instance.Lock(GameObjectOfInterest);
			Selector.Select(GameObjectOfInterest, ObjectOfInterestType);
		}
	}

	public bool IsMatch(INotificationObjectOfInterest objectOfInterest)
	{
		if (ObjectOfInterestType == objectOfInterest.ObjectOfInterestType)
		{
			return GameObjectOfInterest == objectOfInterest.GameObjectOfInterest;
		}
		return false;
	}
}
