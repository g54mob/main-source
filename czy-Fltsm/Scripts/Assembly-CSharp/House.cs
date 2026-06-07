using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Construction))]
public class House : MonoBehaviour, IBuildableExtendable, IPersistentReference
{
	public delegate void HouseEventHandler();

	[Tooltip("Properties of this house.")]
	public HouseProperties Properties;

	public int InhabitantCount { get; private set; }

	public Agent[] Inhabitants { get; private set; }

	public Buildable Buildable { get; private set; }

	public Rejuvenator Rejuvenator { get; private set; }

	public bool Active { get; private set; }

	public bool HasCapacity => InhabitantCount < Inhabitants.Length;

	public int PersistentIndex { get; set; } = -1;

	public event HouseEventHandler InhabitantsUpdated;

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Rejuvenator = GetComponent<Rejuvenator>();
		InhabitantCount = 0;
		Inhabitants = new Agent[Properties.Capacity];
	}

	public void Finish(bool restored = false)
	{
		new GameEvent(GameEventType.HouseFinished).Dispatch();
		Buildable.Community.AddHouse(this);
		GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnCommunityAgentAdded);
		GameEventDispatcher.AddListener(GameEventType.AgentRemovedFromPlayerCommunity, OnCommunityAgentRemoved);
		GameEventDispatcher.AddListener(GameEventType.HouseDeconstructed, TryFillCapacity);
		TryFillCapacity();
	}

	public void Remove()
	{
		for (int i = 0; i < Inhabitants.Length; i++)
		{
			Agent agent = Inhabitants[i];
			if ((bool)agent)
			{
				agent.SetHouse(null);
				Inhabitants[i] = null;
			}
		}
		if (this.InhabitantsUpdated != null)
		{
			this.InhabitantsUpdated();
		}
		new GameEvent(GameEventType.HouseDeconstructed).Dispatch();
		Buildable.Community.RemoveHouse(this);
	}

	private void OnCommunityAgentAdded(GameEvent gameEvent)
	{
		if (!LoadingScreen.IsLoading)
		{
			Agent agent = (gameEvent as AgentEvent).Agent;
			if (agent.ReservedHouse == null && Buildable.Community == agent.Community && AddAgent(agent) && this.InhabitantsUpdated != null)
			{
				this.InhabitantsUpdated();
			}
		}
	}

	private void OnCommunityAgentRemoved(GameEvent gameEvent)
	{
		Agent agent = (gameEvent as AgentEvent).Agent;
		if (Buildable.Community == agent.Community && RemoveAgent(agent))
		{
			TryFillCapacity();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnCommunityAgentAdded);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnCommunityAgentRemoved);
		GameEventDispatcher.RemoveListener(GameEventType.HouseDeconstructed, TryFillCapacity);
	}

	public bool AddAgent(Agent agent)
	{
		if (InhabitantCount == Inhabitants.Length)
		{
			return false;
		}
		for (int i = 0; i < Properties.Capacity; i++)
		{
			if (Inhabitants[i] == null)
			{
				agent.SetHouse(this);
				Inhabitants[i] = agent;
				InhabitantCount++;
				return true;
			}
		}
		return false;
	}

	public bool RemoveAgent(Agent agent)
	{
		for (int i = 0; i < Properties.Capacity; i++)
		{
			if (Inhabitants[i] == agent)
			{
				agent.SetHouse(null);
				Inhabitants[i] = null;
				InhabitantCount--;
				return true;
			}
		}
		return false;
	}

	private void TryFillCapacity(GameEvent gameEvent = null)
	{
		if (!IsEnabled())
		{
			return;
		}
		List<Agent> agents = Buildable.Community.Agents;
		bool flag = false;
		foreach (Agent item in agents)
		{
			if (!(item.ReservedHouse != null))
			{
				if (!AddAgent(item))
				{
					break;
				}
				flag = true;
			}
		}
		if (flag && this.InhabitantsUpdated != null)
		{
			this.InhabitantsUpdated();
		}
	}

	public bool HasFreeSlot()
	{
		return InhabitantCount < Properties.Capacity;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Shutdown()
	{
		Deactivate();
		GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnCommunityAgentAdded);
		GameEventDispatcher.RemoveListener(GameEventType.AgentRemovedFromPlayerCommunity, OnCommunityAgentRemoved);
		GameEventDispatcher.RemoveListener(GameEventType.HouseDeconstructed, TryFillCapacity);
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new HousePersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		HousePersistentData housePersistentData = persistentData as HousePersistentData;
		for (int i = 0; i < housePersistentData.Inhabitants.Length; i++)
		{
			if (i < Inhabitants.Length && housePersistentData.Inhabitants[i].TryReturn(out var instance))
			{
				instance.SetHouse(this);
				Inhabitants[i] = instance;
				InhabitantCount++;
			}
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		HousePersistentData housePersistentData = persistentData as HousePersistentData;
		housePersistentData.Inhabitants = new PersistentReference<Agent>.Reference[Inhabitants.Length];
		for (int i = 0; i < Inhabitants.Length; i++)
		{
			housePersistentData.Inhabitants[i] = Inhabitants[i];
		}
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public bool ReturnIsInhabitant(Agent agent)
	{
		for (int i = 0; i < Properties.Capacity; i++)
		{
			if (Inhabitants[i] == agent)
			{
				return true;
			}
		}
		return false;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
