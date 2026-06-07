using System.Text.RegularExpressions;
using UnityEngine;

public class ResearchObjectOfInterest : INotificationObjectOfInterest
{
	public GameObject GameObjectOfInterest { get; private set; }

	public ObjectType ObjectOfInterestType => ObjectType.Research;

	public CommunityResearch.Research Research { get; private set; }

	public ResearchObjectOfInterest(CommunityResearch.Research research)
	{
		Research = research;
		GameObjectOfInterest = Construction.Townheart.gameObject;
	}

	public void NotificationLeftClick()
	{
		GameManager.UIManager.SelectResearch(Research);
	}

	public string NotificationReplaceVariables(string str)
	{
		return Regex.Replace(str, "%RESEARCH%", $"<b>{Research.Name}</b>", RegexOptions.IgnoreCase);
	}

	public bool IsMatch(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest.ObjectOfInterestType == ObjectType.Research)
		{
			ResearchObjectOfInterest researchObjectOfInterest = objectOfInterest as ResearchObjectOfInterest;
			if (GameObjectOfInterest == objectOfInterest.GameObjectOfInterest)
			{
				return Research == researchObjectOfInterest.Research;
			}
			return false;
		}
		return false;
	}
}
