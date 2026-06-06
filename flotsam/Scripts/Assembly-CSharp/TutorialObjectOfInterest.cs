using UnityEngine;

public class TutorialObjectOfInterest : INotificationObjectOfInterest, IPanelContext
{
	public GameObject GameObjectOfInterest => null;

	public ObjectType ObjectOfInterestType => ObjectType.Tutorial;

	public TutorialID TutorialID { get; private set; }

	public PanelID PanelID => PanelID.TutorialPanel;

	public TutorialObjectOfInterest(TutorialID id)
	{
		TutorialID = id;
	}

	public bool IsMatch(INotificationObjectOfInterest notificationObjectOfInterest)
	{
		if (notificationObjectOfInterest is TutorialObjectOfInterest tutorialObjectOfInterest)
		{
			return tutorialObjectOfInterest.TutorialID == TutorialID;
		}
		return false;
	}

	public void NotificationLeftClick()
	{
		GameManager.UIManager.DisplayPanel(this);
	}

	public string NotificationReplaceVariables(string str)
	{
		return str + ": " + Tutorial.GetTitle(TutorialID);
	}
}
