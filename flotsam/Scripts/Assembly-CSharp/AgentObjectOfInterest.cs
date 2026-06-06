using System.Text.RegularExpressions;
using UnityEngine;

public class AgentObjectOfInterest : INotificationObjectOfInterest
{
	public GameObject GameObjectOfInterest { get; private set; }

	public ObjectType ObjectOfInterestType => ObjectType.Agent;

	public Agent Agent { get; private set; }

	public AgentObjectOfInterest(Agent agent)
	{
		GameObjectOfInterest = agent.gameObject;
		Agent = agent;
	}

	public string NotificationReplaceVariables(string message)
	{
		return Regex.Replace(message, "%NAME%", Agent.Name, RegexOptions.IgnoreCase);
	}

	public void NotificationLeftClick()
	{
		if (!(GameObjectOfInterest == null))
		{
			Selector.Select(GameObjectOfInterest, ObjectOfInterestType);
		}
	}

	public bool IsMatch(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest.ObjectOfInterestType == ObjectType.Agent)
		{
			AgentObjectOfInterest agentObjectOfInterest = objectOfInterest as AgentObjectOfInterest;
			if (GameObjectOfInterest == objectOfInterest.GameObjectOfInterest)
			{
				return Agent == agentObjectOfInterest.Agent;
			}
			return false;
		}
		return false;
	}
}
