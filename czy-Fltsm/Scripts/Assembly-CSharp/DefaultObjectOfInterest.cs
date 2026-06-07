using UnityEngine;

public struct DefaultObjectOfInterest : INotificationObjectOfInterest
{
	public GameObject GameObjectOfInterest { get; private set; }

	public ObjectType ObjectOfInterestType { get; private set; }

	public DefaultObjectOfInterest(GameObject objectOfInterest, ObjectType objectOfInterestType)
	{
		GameObjectOfInterest = objectOfInterest;
		ObjectOfInterestType = objectOfInterestType;
	}

	public string NotificationReplaceVariables(string message)
	{
		if ((bool)GameObjectOfInterest)
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
		}
		return message;
	}

	public void NotificationLeftClick()
	{
		if (!(GameObjectOfInterest == null) && (ObjectOfInterestType != ObjectType.Buildable || Community.PlayerCommunity.Constructions.Contains(GameObjectOfInterest.GetComponent<Construction>())))
		{
			if (ObjectOfInterestType == ObjectType.Research)
			{
				GameManager.UIManager.DisplayPanel(PanelID.TechTreePanel);
				return;
			}
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
