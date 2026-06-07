using System.Collections.Generic;
using UnityEngine;

public class CrewExpertisePanel : MonoBehaviour
{
	[SerializeField]
	private AgentReference[] _agentReferences = new AgentReference[0];

	[SerializeField]
	private CrewExpertisePanelEntry _expertisePrefab;

	[SerializeField]
	private Transform _expertiseParent;

	private Agent[] _agents;

	private List<CrewExpertisePanelEntry> _crewExpertiseEntries;

	public void Initialize()
	{
		_agents = new Agent[_agentReferences.Length];
		_crewExpertiseEntries = new List<CrewExpertisePanelEntry>();
		AgentReference[] agentReferences = _agentReferences;
		for (int i = 0; i < agentReferences.Length; i++)
		{
			agentReferences[i].OnAgentUpdated.AddListener(OnAgentUpdated);
		}
		OnAgentUpdated();
	}

	private void OnDestroy()
	{
		AgentReference[] agentReferences = _agentReferences;
		for (int i = 0; i < agentReferences.Length; i++)
		{
			agentReferences[i].OnAgentUpdated.RemoveListener(OnAgentUpdated);
		}
	}

	protected void Subscribe(Agent agent)
	{
		agent.Attributes.AttributesUpdatedEvent.AddListener(UpdatePanel);
		UpdatePanel();
	}

	protected void Unsubscribe(Agent agent)
	{
		agent.Attributes.AttributesUpdatedEvent.RemoveListener(UpdatePanel);
	}

	private void OnAgentUpdated()
	{
		for (int i = 0; i < _agentReferences.Length; i++)
		{
			UpdateAgent(_agentReferences[i].Agent, i);
		}
	}

	protected virtual void UpdateAgent(Agent agent, int index)
	{
		Agent agent2 = _agents[index];
		if (agent2 != null)
		{
			Unsubscribe(agent2);
		}
		_agents[index] = agent;
		Subscribe(agent);
	}

	private void UpdatePanel()
	{
		DrifterAttributes.AttributeType[] array = DrifterAttributes.ReturnAttributeTypes();
		foreach (DrifterAttributes.AttributeType attributeType in array)
		{
			if (attributeType != DrifterAttributes.AttributeType.None)
			{
				int num = 0;
				int num2 = 0;
				AgentReference[] agentReferences = _agentReferences;
				foreach (AgentReference agentReference in agentReferences)
				{
					num += agentReference.Agent.Attributes.ReturnAttributeExpertise(attributeType);
					num2 += agentReference.Agent.Attributes.ReturnAffinityAmount(attributeType);
				}
				ReturnEntry(attributeType).Initialize(attributeType, num, num2);
			}
		}
	}

	private CrewExpertisePanelEntry ReturnEntry(DrifterAttributes.AttributeType type)
	{
		foreach (CrewExpertisePanelEntry crewExpertiseEntry in _crewExpertiseEntries)
		{
			if (crewExpertiseEntry.Type == type)
			{
				return crewExpertiseEntry;
			}
		}
		CrewExpertisePanelEntry crewExpertisePanelEntry = Object.Instantiate(_expertisePrefab, _expertiseParent);
		_crewExpertiseEntries.Add(crewExpertisePanelEntry);
		return crewExpertisePanelEntry;
	}
}
