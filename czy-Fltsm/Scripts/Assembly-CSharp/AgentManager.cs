using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
	private AgentSettings _settings;

	private bool _sendVitalsUpdatedEvent;

	private bool _sendDiseasesUpdatedEvent;

	private readonly List<Agent> _diseasedAgents = new List<Agent>(50);

	private readonly List<ItemProperties> _unavailableMedication = new List<ItemProperties>(4);

	public bool Initialized { get; private set; }

	public Transform AgentParent { get; private set; }

	public Dictionary<AssignmentType, AssignmentPriority> AssignmentPriorityTemplates { get; } = new Dictionary<AssignmentType, AssignmentPriority>();

	public float AgentInventoryCapacity { get; private set; }

	public void Initialize()
	{
		if (AgentParent == null)
		{
			AgentParent = new GameObject("AgentParent").transform;
		}
		foreach (AssignmentSetting assignmentSetting in GameManager.Settings.ProjectSettings.AssignmentSettings)
		{
			AssignmentPriorityTemplates.Add(assignmentSetting.Type, AssignmentPriority.Lowest);
		}
		GameEventDispatcher.AddListener(GameEventType.DaytimeStarted, OnDayStart);
		AgentInventoryCapacity = AgentDescriptor.GetProperties().Prefab.GetComponentInChildren<Inventory>().StorageCapacity;
		Initialized = true;
	}

	public void LateUpdate()
	{
		if (_sendVitalsUpdatedEvent)
		{
			new GameEvent(GameEventType.VitalsUpdated).Dispatch();
			_sendVitalsUpdatedEvent = false;
		}
		if (_sendDiseasesUpdatedEvent)
		{
			new GameEvent(GameEventType.DiseasesUpdated).Dispatch();
			_sendDiseasesUpdatedEvent = false;
		}
		int count = _diseasedAgents.Count;
		while (0 < count--)
		{
			Agent agent = _diseasedAgents[count];
			Disease currentDisease = agent.Vitals.Pollution.CurrentDisease;
			if (currentDisease == null)
			{
				_diseasedAgents.RemoveAt(count);
			}
			else if (!_unavailableMedication.Contains(currentDisease.Medication) && !currentDisease.TryReserveMedPod(agent))
			{
				_unavailableMedication.Add(currentDisease.Medication);
			}
		}
		_unavailableMedication.Clear();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DaytimeStarted, OnDayStart);
	}

	public void SendVitalsEvent()
	{
		_sendVitalsUpdatedEvent = true;
	}

	public void SendDiseaseEvent()
	{
		_sendDiseasesUpdatedEvent = true;
	}

	public void SpawnStartingAgent(AgentDescriptor agentDescriptor)
	{
		agentDescriptor.Spawn(Community.PlayerCommunity, GameManager.Settings.SessionSettings.StartingScenario.PositionTownheart + SpawnPoint(GameManager.Settings.SessionSettings.StartingScenario.InhabitantSpawnRadius));
	}

	public void RegisterDiseasedAgent(Agent agent)
	{
		if ((bool)agent.Vitals.Pollution.CurrentDisease)
		{
			_diseasedAgents.AddUnique(agent);
		}
		SendDiseaseEvent();
	}

	public void UnregisterDiseasedAgent(Agent agent)
	{
		_diseasedAgents.Remove(agent);
		SendDiseaseEvent();
	}

	private Vector3 SpawnPoint(float radius)
	{
		return (Random.insideUnitSphere * radius).Leveled();
	}

	private void OnDayStart(GameEvent gameEvent)
	{
		if (GameManager.TimeManager.Days.Count == 0)
		{
			return;
		}
		DistributeConsumables(isSimulation: false);
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			agent.Vitals.OnDayStarted(gameEvent);
		}
	}

	public void DistributeConsumables(bool isSimulation)
	{
		DistributeConsumables();
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (isSimulation)
			{
				agent.Vitals.UnreserveItemToConsume(VitalType.Hunger, VitalType.Thirst);
			}
			else
			{
				agent.Vitals.TryAddConsumeProject(VitalType.Hunger);
				agent.Vitals.TryAddConsumeProject(VitalType.Thirst);
			}
		}
	}

	public void DistributeConsumables(Agent targetAgent)
	{
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent == targetAgent)
			{
				agent.Vitals.TryAddConsumeProject(VitalType.Hunger);
				agent.Vitals.TryAddConsumeProject(VitalType.Thirst);
			}
			else
			{
				agent.Vitals.UnreserveItemToConsume(VitalType.Hunger, VitalType.Thirst);
			}
		}
	}

	private void DistributeConsumables()
	{
		using ListPool<Agent>.List list = ListPool<Agent>.Get(Community.PlayerCommunity.Agents);
		foreach (Agent item in list)
		{
			item.Vitals.ClearLastReservedItemToConsume(VitalType.Hunger);
		}
		Sorting.SlowSort(list, Agent.SortByHunger);
		DistributeFood(list);
		Sorting.SlowSort(list, Agent.SortByThirst);
		DistributeWater(list);
	}

	private void DistributeFood(List<Agent> agents)
	{
		using ListPool<Agent>.List list = ListPool<Agent>.Get(agents);
		using ListPool<Agent>.List list2 = ListPool<Agent>.Get();
		RemoveAgentsWithVitalProject(list, VitalType.Hunger);
		foreach (Agent item in list)
		{
			if (0 < item.Vitals.Hunger.Amount)
			{
				list2.Add(item);
			}
		}
		DistributeFood(list, list2);
		if (0 < list2.Count)
		{
			Sorting.SlowSort(list2, Agent.SortByHunger);
			int count = list2.Count;
			while (0 < count--)
			{
				list2[count].Vitals.TryReserveItemToConsume(VitalType.Hunger, AssignmentPriority.Lowest);
			}
		}
	}

	private void DistributeFood(List<Agent> unfedAgents, List<Agent> hungryAgents)
	{
		int num = Community.PlayerCommunity.Inventory.ReturnItemContainingTagCount(Item.Tags.Food);
		if (num <= hungryAgents.Count)
		{
			return;
		}
		AssignmentPriority assignmentPriority = AssignmentPriority.Highest;
		while (AssignmentPriority.None < assignmentPriority)
		{
			int count = unfedAgents.Count;
			while (0 < count--)
			{
				Agent agent = unfedAgents[count];
				if (agent.Vitals.TryReserveItemToConsume(VitalType.Hunger, assignmentPriority))
				{
					unfedAgents.Remove(agent);
					hungryAgents.Remove(agent);
					if (--num <= hungryAgents.Count)
					{
						return;
					}
				}
			}
			assignmentPriority--;
		}
	}

	private void DistributeWater(List<Agent> agents)
	{
		using ListPool<Agent>.List list = ListPool<Agent>.Get(agents);
		RemoveAgentsWithVitalProject(list, VitalType.Thirst);
		Sorting.SlowSort(list, Agent.SortByThirst);
		using List<Agent>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext() && enumerator.Current.Vitals.TryReserveItemToConsume(VitalType.Thirst, AssignmentPriority.Lowest))
		{
		}
	}

	private void RemoveAgentsWithVitalProject(List<Agent> agents, VitalType vital)
	{
		int count = agents.Count;
		while (0 < count--)
		{
			if (agents[count].Vitals.ReturnHasProject(vital))
			{
				agents.RemoveAt(count);
			}
		}
	}
}
